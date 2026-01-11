using Npgsql;
using Orderappis.Data.Model;
using Orderappis.Dev.PDF;
using Orderappis.UserControls.Mod.Orders.dlg;
using Orderis.Data;
using Orderis.Services.Auth;
using ScottPlot;
using System.Data;
using System.Text.RegularExpressions;

namespace Orderis.UserControls.Mod.Orders
{
    public partial class ModOrdersMain : UserControl
    {
        // TAB 1
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalPages = 0;
        private string filter1 = string.Empty;
        private string filter2 = string.Empty;

        // TAB 2 Up
        private int currentPage2U = 1;
        private int pageSize2U = 10;
        private int totalPages2U = 0;

        // TAB 1 objects
        private DataTable dtOrders = new DataTable();
        private NpgsqlDataAdapter? ordersAdapter;

        // TAB 2 Up
        private DataTable dtOrders2 = new DataTable();
        private NpgsqlDataAdapter? orders2Adapter;

        // TAB 2 Down
        private DataTable dtOrderItems = new DataTable();
        private NpgsqlDataAdapter? orderItemsAdapter;

        // TAB 4
        private DataTable dtInvoice = new DataTable();
        private NpgsqlDataAdapter invoiceAdapter;

        // TAB 4 pages
        private int currentPage_Inv = 1;
        private int pageSize_Inv = 10;
        private int totalPages_Inv = 0;

        // Auth Info ---------------------
        private Boolean isZ { get; set; } = false;
        private Boolean isM { get; set; } = false;
        private Boolean isS { get; set; } = false;
        private Boolean isA { get; set; } = false;
        //--------------------------------

        public ModOrdersMain()
        {
            InitializeComponent();
            SetAuthInfo(); // auth info
            InitTab1();
            SetElementsDefaults();
            SetElementDefaultsTab2();
            SetElementsDefaultsTab4();
        }

        private void SetAuthInfo()
        {
            isZ = AuthService.Instance.InUserRole("zákazník");
            isM = AuthService.Instance.InUserRole("manažer");
            isS = AuthService.Instance.InUserRole("skladník");
            isA = AuthService.Instance.InUserRole("administrátor");
        }

        public void InitTab1()
        {
            LoadAllOrders();
            LoadPage();
        }

        public void InitTab2()
        {
            LoadAllOrdersTab2Up(); // down se načte také
            LoadPageTab2Up();
        }

        public void InitTab3()
        {
            DrawBarChart();
        }

        public void InitTab4()
        {
            LoadAllInvoices();
            LoadPageTab4();
        }
        
        private void LoadAllInvoices() 
        {
            string sql = @"SELECT order_invoice_id as OrderInvoiceId,
                generated_by_user_id as GeneratedByUserId,
                created_at as CreatedAt, code_num as CodeNum,
                order_id as OrderId
            FROM amain.order_invoice";

            using var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);
            invoiceAdapter = new NpgsqlDataAdapter(cmd);

            dtInvoice.Clear();
            invoiceAdapter.Fill(dtInvoice);

            DbConnProvider.Instance.ConnClose();
        }

        private void LoadPageTab4() 
        {
            double divP = Math.Ceiling((double)dtInvoice.Rows.Count / pageSize_Inv);
            totalPages_Inv = Convert.ToInt32(divP);

            int skip_Inv = (currentPage_Inv - 1) * pageSize_Inv;
            int eIndexRow_Inv = skip_Inv + pageSize_Inv;

            if (eIndexRow_Inv > dtInvoice.Rows.Count)
            {
                eIndexRow_Inv = dtInvoice.Rows.Count;
            }

            DataTable pageTable_Inv = dtInvoice.Clone();
            for (int i = skip_Inv; i < eIndexRow_Inv; i++)
            {
                pageTable_Inv.ImportRow(dtInvoice.Rows[i]);
            }

            dataGridViewInvoice.DataSource = pageTable_Inv;

            // tlačítka
            btnFirst_Inv.Enabled = currentPage_Inv > 1;
            btnPrev_Inv.Enabled = currentPage_Inv > 1;
            btnNext_Inv.Enabled = currentPage_Inv < totalPages_Inv;
            btnLast_Inv.Enabled = currentPage_Inv < totalPages_Inv;

            // nastavení aktuální strany (popis)
            lblCurrentPage_Inv.Text = currentPage_Inv.ToString();
        }

        private Bar[] LoadBarChartData()
        {
            Bar[] bars = new Bar[5];

            int countOrders = 0;
            object? countOrdersObj = null;
            for (int i = 0; i < bars.Length; i++)
            {
                DateTime currentDate = DateTime.Now;
                currentDate = currentDate.AddMonths(-(bars.Length - i - 1));

                DateTime startDate = new DateTime(currentDate.Year, currentDate.Month, 1);
                DateTime endDate = startDate.AddMonths(1).AddTicks(-1);
                endDate = endDate.AddDays(-1);

                string sql = @"SELECT COUNT(*) AS order_count FROM amain.""order""
                WHERE ordered_at >= @startDate AND ordered_at < @endDate";

                var commandData = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);

                commandData.Parameters.AddWithValue("@startdate", startDate);
                commandData.Parameters.AddWithValue("@enddate", endDate);

                countOrdersObj = commandData.ExecuteScalar();

                if (countOrdersObj == null)
                    throw new Exception();

                countOrders = Convert.ToInt32(countOrdersObj);

                var bar = new Bar();
                bar.Position = i + 1;
                bar.ValueBase = 0;
                bar.Value = countOrders;
                bar.FillColor = Colors.Blue;

                // přidej Bar do pole
                bars[i] = bar;
            }

            return bars;
        }

        private void DrawBarChart()
        {
            Bar[] bars = new Bar[] { };
            try
            {
                // pouze jedna hodnota na každé X pozici
                bars = LoadBarChartData();
            }
            catch
            {
                return;
            }

            formsPlot.Plot.Add.Bars(bars);

            DateTime now = DateTime.Now;
            int n = 5;

            Tick[] ticks = new Tick[n];

            for (int i = 0; i < n; i++)
            {
                DateTime dt = now.AddMonths(-(n - 1 - i));
                ticks[i] = new Tick(i + 1, dt.ToString("yyyy-MMMM"));
            }

            formsPlot.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
            formsPlot.Plot.Axes.Bottom.MajorTickStyle.Length = 0;
            formsPlot.Plot.HideGrid();

            formsPlot.Plot.Axes.Margins(bottom: 0);
            formsPlot.Plot.XLabel("Měsíc");
            formsPlot.Plot.YLabel("Počet objednávek");
            formsPlot.Plot.Title("Počet objednávek podle měsíců");

            foreach (var bar in bars)
            {
                bar.Label = bar.Value.ToString();
                bar.CenterLabel = true;
            }

            formsPlot.Refresh();
        }

        private void SetElementsDefaults()
        {
            btnFirst.Click += PaginationButton_Click;
            btnPrev.Click += PaginationButton_Click;
            btnNext.Click += PaginationButton_Click;
            btnLast.Click += PaginationButton_Click;

            btnFirst.Cursor = Cursors.Hand;
            btnPrev.Cursor = Cursors.Hand;
            btnNext.Cursor = Cursors.Hand;
            btnLast.Cursor = Cursors.Hand;

            buttonExportPDF.Cursor = Cursors.Hand;

            // cBoxStatus
            List<OrderStatus> listVals = new List<OrderStatus>();
            listVals.Add(new OrderStatus(0, "Vše"));
            listVals.Add(new OrderStatus(1, "Vytvořena"));
            listVals.Add(new OrderStatus(2, "Zpracování"));
            listVals.Add(new OrderStatus(3, "Připravena"));
            listVals.Add(new OrderStatus(4, "Doručování"));
            listVals.Add(new OrderStatus(5, "Dokončena"));
            listVals.Add(new OrderStatus(6, "Zrušena"));

            cBoxStatus.DataSource = listVals;
            cBoxStatus.DisplayMember = "Name";
            cBoxStatus.ValueMember = "Id";
            cBoxStatus.SelectedIndex = 0;
            cBoxStatus.SelectedValueChanged += GridSelectedValueChanged;

            cBoxSearch.Items.Clear();
            cBoxSearch.Items.AddRange(new object[] {
                "Email zákazníka",
                "Jméno zákazníka"
            });
            cBoxSearch.SelectedIndex = 0;
            cBoxSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxSearch.Cursor = Cursors.Hand;

            btnRefresh.Image = System.Drawing.Image.FromFile(@"Images\refresh.png");
            btnRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            btnRefresh.TextAlign = ContentAlignment.MiddleRight;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.Click += GridRefresh_Click;

            btnCreate.Image = System.Drawing.Image.FromFile(@"Images\create.png");
            btnCreate.ImageAlign = ContentAlignment.MiddleLeft;
            btnCreate.TextAlign = ContentAlignment.MiddleRight;
            btnCreate.Cursor = Cursors.Hand;
            btnCreate.Click += GridCreate_Click;

            if (!isM && !isA && !isZ) 
            {
                btnCreate.Visible = false;
            }

            btnEdit.Image = System.Drawing.Image.FromFile(@"Images\edit.png");
            btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
            btnEdit.TextAlign = ContentAlignment.MiddleRight;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Click += GridEdit_Click;

            if (!isM && !isA && !isS)
            {
                btnEdit.Visible = false;
            }

            btnDelete.Image = System.Drawing.Image.FromFile(@"Images\trash.png");
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.TextAlign = ContentAlignment.MiddleRight;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Click += GridDelete_Click;

            if (!isM && !isA)
            {
                btnDelete.Visible = false;
            }

            // combobox
            cBoxPerPage.Items.Clear();
            cBoxPerPage.Items.AddRange(new object[] { 3, 5, 10, 20, 50, 100 });
            cBoxPerPage.SelectedIndex = 2;
            cBoxPerPage.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxPerPage.SelectedIndexChanged += ChangePerPage_Click;

            dataGridViewOrders.ReadOnly = true;

            if (!isM && !isA)
            {
                buttonExportPDF.Visible = false;
                buttonInvoice.Visible = false;
            }

            DefineGridColumns();
            ApplyDefaultGridStyles(dataGridViewOrders);
        }

        private void SetElementsDefaultsTab4()
        {
            btnFirst_Inv.Click += PaginationButton_Inv_Click;
            btnPrev_Inv.Click += PaginationButton_Inv_Click;
            btnNext_Inv.Click += PaginationButton_Inv_Click;
            btnLast_Inv.Click += PaginationButton_Inv_Click;

            btnFirst_Inv.Cursor = Cursors.Hand;
            btnPrev_Inv.Cursor = Cursors.Hand;
            btnNext_Inv.Cursor = Cursors.Hand;
            btnLast_Inv.Cursor = Cursors.Hand;

            // grid buttons set images
            btnRefresh_Inv.Image = System.Drawing.Image.FromFile(@"Images\refresh.png");
            btnRefresh_Inv.ImageAlign = ContentAlignment.MiddleLeft;
            btnRefresh_Inv.TextAlign = ContentAlignment.MiddleRight;
            btnRefresh_Inv.Cursor = Cursors.Hand;
            btnRefresh_Inv.Click += GridRefresh_Inv_Click;

            // combobox
            cBoxPerPage_Inv.Items.Clear();
            cBoxPerPage_Inv.Items.AddRange(new object[] { 3, 5, 10, 20, 50, 100 });
            cBoxPerPage_Inv.SelectedIndex = 2;
            cBoxPerPage_Inv.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxPerPage_Inv.SelectedIndexChanged += ChangePerPage_Inv_Click;

            dataGridViewInvoice.ReadOnly = true;

            DefineGridColumns_Inv();
            ApplyDefaultGridStyles(dataGridViewInvoice);
        }

        private void ChangePerPage_Inv_Click(object? sender, EventArgs e)
        {
            currentPage_Inv = 1;
            pageSize_Inv = (int)cBoxPerPage_Inv.SelectedItem;
            LoadPageTab4();
        }

        private void GridRefresh_Inv_Click(object? sender, EventArgs e)
        {
            InitTab4();
        }

        private void PaginationButton_Inv_Click(object? sender, EventArgs e)
        {
            if (sender == btnFirst_Inv) currentPage_Inv = 1;
            else if (sender == btnPrev_Inv) currentPage_Inv = Math.Max(1, currentPage_Inv - 1);
            else if (sender == btnNext_Inv) currentPage_Inv = Math.Min(totalPages_Inv, currentPage_Inv + 1);
            else if (sender == btnLast_Inv) currentPage_Inv = totalPages_Inv;

            LoadPageTab4();
        }

        private void GridSelectedValueChanged(object? sender, EventArgs e)
        {
            DataView view;

            if (dataGridViewOrders.DataSource is DataTable dt)
            {
                view = dt.DefaultView;
            }
            else
            {
                return;
            }

            if ((cBoxStatus.SelectedValue != null) && ((int)cBoxStatus.SelectedValue == 0))
            {
                filter1 = "";
                view.RowFilter = "";
            }
            else
            {
                int selectedValue = (int)cBoxStatus.SelectedValue;
                string columnName = dataGridViewOrders.Columns[2].DataPropertyName;
                switch (selectedValue)
                {
                    case 1:
                        if (filter2.Length > 0)
                        {
                            filter1 = $"{columnName} = 1";
                            view.RowFilter = filter1 + " AND " + filter2;
                        }
                        else
                        {
                            filter1 = $"{columnName} = 1";
                            view.RowFilter = filter1;
                        }
                        break;
                    case 2:
                        if (filter2.Length > 0)
                        {
                            filter1 = $"{columnName} = 2";
                            view.RowFilter = filter1 + " AND " + filter2;
                        }
                        else
                        {
                            filter1 = $"{columnName} = 2";
                            view.RowFilter = filter1;
                        }
                        break;
                    case 3:
                        if (filter2.Length > 0)
                        {
                            filter1 = $"{columnName} = 3";
                            view.RowFilter = filter1 + " AND " + filter2;
                        }
                        else
                        {
                            filter1 = $"{columnName} = 3";
                            view.RowFilter = filter1;
                        }
                        break;
                    case 4:
                        if (filter2.Length > 0)
                        {
                            filter1 = $"{columnName} = 4";
                            view.RowFilter = filter1 + " AND " + filter2;
                        }
                        else
                        {
                            filter1 = $"{columnName} = 4";
                            view.RowFilter = filter1;
                        }
                        break;
                    case 5:
                        if (filter2.Length > 0)
                        {
                            filter1 = $"{columnName} = 5";
                            view.RowFilter = filter1 + " AND " + filter2;
                        }
                        else
                        {
                            filter1 = $"{columnName} = 5";
                            view.RowFilter = filter1;
                        }
                        break;
                    case 6:
                        if (filter2.Length > 0)
                        {
                            filter1 = $"{columnName} = 6";
                            view.RowFilter = filter1 + " AND " + filter2;
                        }
                        else
                        {
                            filter1 = $"{columnName} = 6";
                            view.RowFilter = filter1;
                        }
                        break;
                }
            }
        }

        private void SetElementDefaultsTab2()
        {
            // Up
            btnFirstU.Click += PaginationButtonU_Click;
            btnPrevU.Click += PaginationButtonU_Click;
            btnNextU.Click += PaginationButtonU_Click;
            btnLastU.Click += PaginationButtonU_Click;

            btnFirstU.Cursor = Cursors.Hand;
            btnPrevU.Cursor = Cursors.Hand;
            btnNextU.Cursor = Cursors.Hand;
            btnLastU.Cursor = Cursors.Hand;

            // grid buttons set images
            btnRefreshU.Image = System.Drawing.Image.FromFile(@"Images\refresh.png");
            btnRefreshU.ImageAlign = ContentAlignment.MiddleLeft;
            btnRefreshU.TextAlign = ContentAlignment.MiddleRight;
            btnRefreshU.Cursor = Cursors.Hand;
            btnRefreshU.Click += GridRefreshU_Click;

            // combobox
            cBoxPerPageU.Items.Clear();
            cBoxPerPageU.Items.AddRange(new object[] { 3, 5, 10, 20, 50, 100 });
            cBoxPerPageU.SelectedIndex = 2;
            cBoxPerPageU.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxPerPageU.SelectedIndexChanged += ChangePerPageU_Click;

            dataGridViewUp.ReadOnly = true;
            dataGridViewUp.SelectionChanged += dataGridViewUp_SelectionChanged;
            // Down ------------------------------------------------------------
            // grid buttons set images
            btnRefreshD.Image = System.Drawing.Image.FromFile(@"Images\refresh.png");
            btnRefreshD.ImageAlign = ContentAlignment.MiddleLeft;
            btnRefreshD.TextAlign = ContentAlignment.MiddleRight;
            btnRefreshD.Cursor = Cursors.Hand;
            btnRefreshD.Click += GridRefreshD_Click;

            btnEditD.Image = System.Drawing.Image.FromFile(@"Images\edit.png");
            btnEditD.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditD.TextAlign = ContentAlignment.MiddleRight;
            btnEditD.Cursor = Cursors.Hand;
            btnEditD.Click += GridEditD_Click;

            if (!isA && !isM)
            { 
                btnEdit.Visible = false;
            }

            dataGridViewDown.ReadOnly = true;

            DefineGridColumnsTab2Up();
            DefineGridColumnsTab2Down();
            ApplyDefaultGridStyles(dataGridViewUp);
            ApplyDefaultGridStyles(dataGridViewDown);
        }

        private void dataGridViewUp_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridViewUp.DataSource == null)
                return;

            if (dataGridViewUp.SelectedRows.Count == 0)
                return;

            var row = dataGridViewUp.SelectedRows[0];

            if (row.Cells["colOrderId"].Value == null)
                return;

            int orderId = Convert.ToInt32(row.Cells["colOrderId"].Value);

            LoadAllOrderItemsTab2Down(orderId);
        }

        private void ChangePerPageU_Click(object? sender, EventArgs e)
        {
            currentPage2U = 1;
            pageSize2U = (int)cBoxPerPageU.SelectedItem;
            LoadPageTab2Up();
        }

        public DialogResult ShowUserControlModal(UserControl control, string title)
        {
            Form modal = new Form();
            modal.StartPosition = FormStartPosition.CenterParent;
            modal.FormBorderStyle = FormBorderStyle.FixedDialog;
            modal.MaximizeBox = false; // nepůjde zvětšit
            modal.MinimizeBox = false; // nepůjde zmenšit
            modal.ShowInTaskbar = false; // nezobrazí se v taskbaru
            modal.Text = title;
            modal.ClientSize = control.Size;
            control.Dock = DockStyle.Fill;
            modal.Controls.Add(control);

            return modal.ShowDialog(this);
        }

        private void GridEditD_Click(object? sender, EventArgs e)
        {
            int cId = GridOrders_GetSelectedOrderIdUp();
            if (cId > 0)
            {
                var dlgOrderItems_Modal = new dlgOrderItems();
                dlgOrderItems_Modal.OrderID = cId;
                dlgOrderItems_Modal.RefreshData();
                ShowUserControlModal(dlgOrderItems_Modal, "Editace položek objednávky");
                InitTab2(); // refresh
            }
        }

        private void GridRefreshD_Click(object? sender, EventArgs e)
        {
            InitTab2();
        }

        private void GridRefreshU_Click(object? sender, EventArgs e)
        {
            InitTab2();
        }

        private void PaginationButtonU_Click(object? sender, EventArgs e)
        {
            if (sender == btnFirstU) currentPage2U = 1;
            else if (sender == btnPrevU) currentPage2U = Math.Max(1, currentPage2U - 1);
            else if (sender == btnNextU) currentPage2U = Math.Min(totalPages2U, currentPage2U + 1);
            else if (sender == btnLastU) currentPage2U = totalPages2U;

            LoadPageTab2Up();
        }

        private int GridOrders_GetSelectedOrderId()
        {
            if (dataGridViewOrders.Rows.Count == 0) 
                return 0;

            var selectedValue = dataGridViewOrders.CurrentRow.Cells[0].Value;

            if (selectedValue != null)
            {
                return (int)selectedValue;
            }
            else
            {
                return 0; // není vybráno
            }
        }

        private int GridOrders_GetSelectedOrderIdUp()
        {
            if (dataGridViewUp.Rows.Count == 0)
                return 0;

            var selectedValue = dataGridViewUp.CurrentRow.Cells[0].Value;

            if (selectedValue != null)
            {
                return (int)selectedValue;
            }
            else
            {
                return 0; // není vybráno
            }
        }

        private void GridDelete_Click(object? sender, EventArgs e)
        {
            int selectedOrderId = GridOrders_GetSelectedOrderId();
            
            if (selectedOrderId <= 0)
            {
                return; // není vybráno => žádná akce
            }

            if (MessageBox.Show("Opravdu chcete smazat záznam (akce je nevratná)?",
                "Smazání záznamu",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                // smazání záznamu
                string sqlDeleteCommand = "DELETE FROM amain.order WHERE order_id = @orderId";
                var cmd = new NpgsqlCommand(sqlDeleteCommand, DbConnProvider.Instance.Conn);

                cmd.Parameters.AddWithValue("@orderId", selectedOrderId);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Záznam byl smazán");
                    InitTab1();
                }
                else
                {
                    MessageBox.Show("Nastala chyba, zkontrolujte reference záznamu");
                }
            }
        }

        private void GridEdit_Click(object? sender, EventArgs e)
        {
            var dlgOrderE_Modal = new dlgOrderE();
            int cId = GridOrders_GetSelectedOrderId();
            if (cId > 0) // jinak žádná akce
            {
                dlgOrderE_Modal.OrderID = cId;
                dlgOrderE_Modal.LoadData();
                ShowUserControlModal(dlgOrderE_Modal, "Editace objednávky");
                InitTab1(); // refresh
            }
        }

        private void GridCreate_Click(object? sender, EventArgs e)
        {
            var dlgOrderA_Modal = new dlgOrderA();
            if (ShowUserControlModal(dlgOrderA_Modal, "Vytvoření objednávky") == DialogResult.OK)
            {
                MessageBox.Show("Objednávka byla vytvořena");
                var dlgOrderItems_Modal = new dlgOrderItems();
                ShowUserControlModal(dlgOrderItems_Modal, "Přiřazení položek do nové objednávky");
                InitTab1(); // refresh
            }
        }

        private void GridRefresh_Click(object? sender, EventArgs e)
        {
            InitTab1();
        }

        private void GridCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // vytvořena (1), zpracovává se (2)
            // připravena k odeslání (3), doručuje se (4)
            // dokončena(5), zrušena(6)
            if (dataGridViewOrders.Columns[e.ColumnIndex].Name == "colStatus"
                && e.Value != null)
            {
                switch (e.Value)
                {
                    case 1:
                        e.Value = "Vytvořena";
                        break;
                    case 2:
                        e.Value = "Zpracování";
                        break;
                    case 3:
                        e.Value = "Připravena";
                        break;
                    case 4:
                        e.Value = "Doručování";
                        break;
                    case 5:
                        e.Value = "Dokončena";
                        break;
                    case 6:
                        e.Value = "Zrušena";
                        break;
                }
            }
        }

        private void ChangePerPage_Click(object? sender, EventArgs e)
        {
            currentPage = 1;
            pageSize = (int)cBoxPerPage.SelectedItem;
            LoadPage();
        }

        private void LoadAllOrders()
        {
            string sql = @"SELECT 
                o.order_id as OrderId,
                o.total_price_czk as TotalPriceCZK,
                o.status as Status,
                o.ordered_at as OrderedAt,
                o.updated_at as UpdatedAt,
                concat(u.lastname, ' ', u.firstname) as CustomerFullname,
                u.email as CustomerEmail
            FROM amain.""order"" o
            JOIN amain.customer_account ca ON o.customer_account_id = ca.customer_account_id
            JOIN amain.""user"" u ON ca.user_id = u.user_id
            ORDER BY o.ordered_at DESC";

            using var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);
            ordersAdapter = new NpgsqlDataAdapter(cmd);

            dtOrders.Clear();
            ordersAdapter.Fill(dtOrders);

            DbConnProvider.Instance.ConnClose();
        }

        private void LoadAllOrdersTab2Up()
        {
            string sql = @"SELECT 
                o.order_id as OrderId,
                o.total_price_czk as TotalPriceCZK,
                concat(u.firstname, ' ', u.lastname) as CustomerFullname,
                u.phone_num1 as CustomerPhoneNumber1,
                u.phone_num2 as CustomerPhoneNumber2
            FROM amain.""order"" o
            JOIN amain.customer_account ca ON o.customer_account_id = ca.customer_account_id
            JOIN amain.""user"" u ON ca.user_id = u.user_id
            ORDER BY o.order_id DESC";

            using var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);
            orders2Adapter = new NpgsqlDataAdapter(cmd);

            dtOrders2.Clear();
            orders2Adapter.Fill(dtOrders2);

            DbConnProvider.Instance.ConnClose();

            if (dataGridViewUp.Rows.Count == 0)
                return;

            if (dataGridViewUp.SelectedRows.Count == 0)
                dataGridViewUp.Rows[0].Selected = true;

            var row = dataGridViewUp.SelectedRows[0];

            LoadAllOrderItemsTab2Down((int)row.Cells["colOrderId"].Value);
        }

        private void LoadAllOrderItemsTab2Down(int orderId)
        {
            string sql = @"
                SELECT 
                    oi.order_item_id as OrderItemId,
                    oi.order_id as OrderId,
                    oi.product_id as ProductId,
                    p.code as ProductCode,
                    p.name as ProductName,
                    oi.qty as Qty,
                    oi.note as Note
                FROM amain.order_item oi
                JOIN amain.product p ON oi.product_id = p.product_id
                WHERE oi.order_id = @orderId
                ORDER BY oi.order_item_id ASC
            ";

            using var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);
            cmd.Parameters.AddWithValue("@orderId", orderId);
            orderItemsAdapter = new NpgsqlDataAdapter(cmd);

            dtOrderItems.Clear();
            orderItemsAdapter.Fill(dtOrderItems);

            // nastavení datasource
            dataGridViewDown.DataSource = dtOrderItems;
            DbConnProvider.Instance.ConnClose();
        }

        private void LoadPage()
        {
            double divP = Math.Ceiling((double)dtOrders.Rows.Count / pageSize);
            totalPages = Convert.ToInt32(divP);

            int skip = (currentPage - 1) * pageSize;
            int eIndexRow = skip + pageSize;

            if (eIndexRow > dtOrders.Rows.Count)
            {
                eIndexRow = dtOrders.Rows.Count;
            }

            DataTable pageTable = dtOrders.Clone();
            for (int i = skip; i < eIndexRow; i++)
            {
                pageTable.ImportRow(dtOrders.Rows[i]);
            }

            dataGridViewOrders.DataSource = pageTable;

            // tlačítka
            btnFirst.Enabled = currentPage > 1;
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
            btnLast.Enabled = currentPage < totalPages;

            // nastavení aktuální strany (popis)
            lblCurrentPage.Text = currentPage.ToString();
        }

        private void LoadPageTab2Up()
        {
            double divP = Math.Ceiling((double)dtOrders2.Rows.Count / pageSize2U);
            totalPages2U = Convert.ToInt32(divP);

            int skip = (currentPage2U - 1) * pageSize2U;
            int eIndexRow = skip + pageSize2U;

            if (eIndexRow > dtOrders2.Rows.Count)
            {
                eIndexRow = dtOrders2.Rows.Count;
            }

            DataTable pageTable = dtOrders2.Clone();
            for (int i = skip; i < eIndexRow; i++)
            {
                pageTable.ImportRow(dtOrders2.Rows[i]);
            }
            
            dataGridViewUp.DataSource = pageTable;

            // tlačítka
            btnFirstU.Enabled = currentPage2U > 1;
            btnPrevU.Enabled = currentPage2U > 1;
            btnNextU.Enabled = currentPage2U < totalPages2U;
            btnLastU.Enabled = currentPage2U < totalPages2U;

            lblCurrentPageU.Text = currentPage2U.ToString();
        }

        private void PaginationButton_Click(object sender, EventArgs e)
        {
            if (sender == btnFirst) currentPage = 1;
            else if (sender == btnPrev) currentPage = Math.Max(1, currentPage - 1);
            else if (sender == btnNext) currentPage = Math.Min(totalPages, currentPage + 1);
            else if (sender == btnLast) currentPage = totalPages;

            LoadPage();
        }

        private void DefineGridColumns_Inv()
        {
            dataGridViewInvoice.AutoGenerateColumns = false;
            dataGridViewInvoice.Columns.Clear();

            dataGridViewInvoice.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderInvoiceId",
                HeaderText = "ID faktury",
                Name = "colOrderInvoiceId",
                ReadOnly = true
            });

            dataGridViewInvoice.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GeneratedByUserId",
                HeaderText = "Vystavil uživatel",
                Name = "colGeneratedByUserId",
                ReadOnly = true
            });

            dataGridViewInvoice.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CreatedAt",
                HeaderText = "Vytvořena",
                Name = "colCreatedAt",
                Width = 200,
                ReadOnly = true
            });

            dataGridViewInvoice.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CodeNum",
                HeaderText = "Číslo",
                Name = "colCodeNum",
                ReadOnly = true
            });

            dataGridViewInvoice.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderId",
                HeaderText = "Číslo obědnávky",
                Name = "colOrderId",
                Width= 200,
                ReadOnly = true
            });
        }

        private void DefineGridColumnsTab2Up()
        {
            dataGridViewUp.AutoGenerateColumns = false;
            dataGridViewUp.Columns.Clear();

            dataGridViewUp.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderId",
                HeaderText = "ID objednávky",
                Name = "colOrderId",
                ReadOnly = true,
                Width = 120
            });

            dataGridViewUp.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalPriceCZK",
                HeaderText = "Cena celkem (CZK)",
                Name = "colTotalPriceCZK",
                ReadOnly = true,
                Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N2"
                }
            });

            dataGridViewUp.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerFullname",
                HeaderText = "Zákazník",
                Name = "colCustomerFullname",
                ReadOnly = true,
                Width = 200
            });

            dataGridViewUp.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerPhoneNumber1",
                HeaderText = "Telefon 1",
                Name = "colCustomerPhoneNumber1",
                ReadOnly = true,
                Width = 120
            });

            dataGridViewUp.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerPhoneNumber2",
                HeaderText = "Telefon 2",
                Name = "colCustomerPhoneNumber2",
                ReadOnly = true,
                Width = 120
            });
        }

        private void DefineGridColumnsTab2Down()
        {
            dataGridViewDown.AutoGenerateColumns = false;
            dataGridViewDown.Columns.Clear();

            dataGridViewDown.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderItemId",
                HeaderText = "ID položky",
                Name = "colOrderItemId",
                ReadOnly = true,
                Width = 100
            });

            dataGridViewDown.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderId",
                HeaderText = "ID objednávky",
                Name = "colOrderId",
                ReadOnly = true,
                Width = 120
            });

            dataGridViewDown.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductCode",
                HeaderText = "Kód produktu",
                Name = "colProductCode",
                ReadOnly = true,
                Width = 120
            });

            dataGridViewDown.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductName",
                HeaderText = "Název produktu",
                Name = "colProductName",
                ReadOnly = true,
                Width = 200
            });

            dataGridViewDown.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Qty",
                HeaderText = "Množství",
                Name = "colQty",
                Width = 100
            });

            dataGridViewDown.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Note",
                HeaderText = "Poznámka",
                Name = "colNote",
                Width = 200
            });
        }

        private void DefineGridColumns()
        {
            dataGridViewOrders.AutoGenerateColumns = false;
            dataGridViewOrders.Columns.Clear();

            dataGridViewOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderId",
                HeaderText = "ID objednávky",
                Name = "colOrderId",
                ReadOnly = true
            });

            dataGridViewOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalPriceCZK",
                HeaderText = "Celková cena (CZK)",
                Name = "colTotalPriceCZK",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            dataGridViewOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Stav",
                Name = "colStatus",
                ReadOnly = true
            });

            dataGridViewOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderedAt",
                HeaderText = "Datum objednávky",
                Name = "colOrderedAt",
                Width = 140,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "g" }
            });

            dataGridViewOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UpdatedAt",
                HeaderText = "Aktualizováno",
                Name = "colUpdatedAt",
                Width = 140,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "g" }
            });

            dataGridViewOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerFullname",
                HeaderText = "Jméno zákazníka",
                Name = "colCustomerFullname",
                Width = 200,
                ReadOnly = true
            });

            dataGridViewOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerEmail",
                HeaderText = "Email zákazníka",
                Name = "colCustomerEmail",
                Width = 250,
                ReadOnly = true
            });

            dataGridViewOrders.CellFormatting += GridCellFormatting;
        }

        private void ApplyDefaultGridStyles(DataGridView dgv)
        {
            dgv.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowTemplate.Height = 28;
            dgv.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            dgv.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = System.Drawing.Color.LightGray;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.AllowUserToResizeRows = false;
            dgv.ScrollBars = ScrollBars.Both;
            dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.MediumTurquoise;
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dgv.AllowUserToAddRows = false;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.MediumTurquoise;
            dgv.AllowUserToResizeColumns = true;
        }

        private void buttonExportPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF soubor|*.pdf";
            var createdAt = DateTime.Now.ToString();
            createdAt = createdAt.Replace(":", "_").Replace(".", "_");
            createdAt = Regex.Replace(createdAt, @"\s+", "__");
            sfd.FileName = "orders_export_" + createdAt + ".pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                PDFHelper pdfHelper = new PDFHelper();
                pdfHelper.ExportOrdersList(dataGridViewOrders, sfd.FileName);
            }
        }

        private void buttonInvoice_Click(object sender, EventArgs e)
        {
            var dlgInvoice = new dlgInvoice();
            int cId = GridOrders_GetSelectedOrderId();
            if (cId > 0)
            {
                dlgInvoice.OrderId = cId;
                dlgInvoice.LoadData();
                ShowUserControlModal(dlgInvoice, "Vytvoření Faktury");
            }
        }

        private void SearchGrid()
        {
            if (dataGridViewOrders.DataSource == null)
                return;

            string searchText = textBoxSearch.Text.Trim();
            int selectedColumnIndex = cBoxSearch.SelectedIndex;

            if (selectedColumnIndex < 0)
                return;

            // 0 => "Email zákazníka",
            // 1 => "Jméno zákazníka"
            // namapování na sloupce gridu
            switch (selectedColumnIndex)
            {
                case 0:
                    selectedColumnIndex = 6;
                    break;
                case 1:
                    selectedColumnIndex = 5;
                    break;
            }

            string columnName = dataGridViewOrders.Columns[selectedColumnIndex].DataPropertyName;
            DataView view;

            if (dataGridViewOrders.DataSource is DataTable dt)
            {
                view = dt.DefaultView;
            }
            else
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(searchText))
            {
                filter2 = "";
                view.RowFilter = filter1 + filter2;
            }
            else
            {
                string escaped = searchText.Replace("'", "''");
                if (filter1.Length > 0)
                {
                    filter2 = $"{columnName} LIKE '%{escaped}%'";
                    view.RowFilter = filter1 + " AND " + filter2;
                }
                else
                {
                    filter2 = $"{columnName} LIKE '%{escaped}%'";
                    view.RowFilter = filter2;
                }
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchGrid();
        }

        private void tabControlOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = tabPageContrMain.SelectedTab;

            if (selectedTab == tabPageOrders)
            {
                InitTab1();
            }
            else if (selectedTab == tabPageOrderItems)
            {
                InitTab2();
            }
            else if (selectedTab == tabPageOrdersSummary)
            {
                InitTab3();
            }
            else if (selectedTab == tabPageInvoice)
            { 
                InitTab4();
            }
        }
    }
}