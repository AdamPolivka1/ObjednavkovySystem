using Npgsql;
using Orderappis.Data.Model;
using Orderappis.UserControls.Mod.Orders.dlg;
using Orderis.Data;
using Orderis.Services.Auth;
using System.Data;

namespace Orderis.UserControls.Mod.Orders
{
    public partial class ModOrdersDelivery : UserControl
    {
        // TAB 1 currentPage
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalPages = 0;

        // TAB 1
        private DataTable dtDeliveries = new DataTable();
        private NpgsqlDataAdapter? deliveriesAdapter;

        // Auth Info ---------------------
        private Boolean isZ { get; set; }
        private Boolean isM { get; set; }
        private Boolean isS { get; set; }
        private Boolean isA { get; set; }
        //--------------------------------

        public ModOrdersDelivery()
        {
            InitializeComponent();
            SetAuthInfo(); // auth info
            LoadTab1();
            SetElementDefaultsTab1();
        }

        private void SetAuthInfo()
        {
            isZ = AuthService.Instance.InUserRole("zákazník");
            isM = AuthService.Instance.InUserRole("manažer");
            isS = AuthService.Instance.InUserRole("skladník");
            isA = AuthService.Instance.InUserRole("administrátor");
        }

        private void LoadTab1()
        {
            LoadAllDeliveries();
            LoadPageDeliveries();
        }

        private void LoadPageDeliveries()
        {
            double divP = Math.Ceiling((double)dtDeliveries.Rows.Count / pageSize);
            totalPages = Convert.ToInt32(divP);

            int skip = (currentPage - 1) * pageSize;
            int eIndexRow = skip + pageSize;

            if (eIndexRow > dtDeliveries.Rows.Count)
            {
                eIndexRow = dtDeliveries.Rows.Count;
            }

            DataTable pageTable = dtDeliveries.Clone();
            for (int i = skip; i < eIndexRow; i++)
            {
                pageTable.ImportRow(dtDeliveries.Rows[i]);
            }

            dataGridViewDeliveries.DataSource = pageTable;

            // tlačítka
            btnFirst.Enabled = currentPage > 1;
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
            btnLast.Enabled = currentPage < totalPages;

            // nastavení aktuální strany (popis)
            lblCurrentPage.Text = currentPage.ToString();
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
            modal.Controls.Add(control);
            control.Dock = DockStyle.Fill;

            return modal.ShowDialog(this);
        }

        private void SetElementDefaultsTab1()
        {
            // Up
            btnFirst.Click += PaginationButton_Click;
            btnPrev.Click += PaginationButton_Click;
            btnNext.Click += PaginationButton_Click;
            btnLast.Click += PaginationButton_Click;

            btnFirst.Cursor = Cursors.Hand;
            btnPrev.Cursor = Cursors.Hand;
            btnNext.Cursor = Cursors.Hand;
            btnLast.Cursor = Cursors.Hand;

            // grid buttons set images
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

            if (!isM && !isA)
            {
                btnCreate.Visible = false;
            }

            btnEdit.Image = System.Drawing.Image.FromFile(@"Images\edit.png");
            btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
            btnEdit.TextAlign = ContentAlignment.MiddleRight;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Click += GridEdit_Click;

            if (!isM && !isA)
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

            dataGridViewDeliveries.ReadOnly = true;
            dataGridViewDeliveries.CellFormatting += GridCellFormatting;
           
            // cBoxStatus
            List<OrderStatus> listVals = new List<OrderStatus>();
            listVals.Add(new OrderStatus(0, "Vše"));
            listVals.Add(new OrderStatus(1, "Nedoručené"));
            listVals.Add(new OrderStatus(2, "Doručené"));

            cBoxStatus.DataSource = listVals;
            cBoxStatus.DisplayMember = "Name";
            cBoxStatus.ValueMember = "Id";
            cBoxStatus.SelectedIndex = 0;
            cBoxStatus.SelectedValueChanged += SelectedValueChanged;

            DefineGridColumnsTab();
            ApplyDefaultGridStyles(dataGridViewDeliveries);
        }

        private void SelectedValueChanged(object? sender, EventArgs e)
        {
            // filtruj dataview
            if (dataGridViewDeliveries.DataSource == null)
                return;

            int selectedFilterStatus = cBoxStatus.SelectedIndex - 1;

            // -1 => "Vše"
            //  0 => "Doručené"
            //  1 => "Nedoručené"
            DataView view;

            if (dataGridViewDeliveries.DataSource is DataTable dt)
            {
                view = dt.DefaultView;
            }
            else
            {
                return;
            }

            if (selectedFilterStatus == -1)
            {
                view.RowFilter = "";
            }
            else
            {
                view.RowFilter = $"Status = {selectedFilterStatus}";
            }
        }

        private void GridCellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (sender == null)
            { return; }
            // nedoručena (0), doručena (1)
            if (dataGridViewDeliveries.Columns[e.ColumnIndex].Name == "colStatus"
                && e.Value != null)
            {
                switch (e.Value)
                {
                    case 0:
                        e.Value = "Nedoručeno";
                        break;
                    case 1:
                        e.Value = "Doručeno";
                        break;
                }
            }

            // Express (1), 24h (2), Basic (3)
            if (dataGridViewDeliveries.Columns[e.ColumnIndex].Name == "colDeliveryType"
                && e.Value != null)
            {
                switch (e.Value)
                {
                    case 1:
                        e.Value = "Express";
                        break;
                    case 2:
                        e.Value = "24h";
                        break;
                    case 3:
                        e.Value = "Basic";
                        break;
                }
            }
        }

        private void ChangePerPage_Click(object? sender, EventArgs e)
        {
            currentPage = 1;
            var objSelected = cBoxPerPage.SelectedItem;
            if (objSelected != null)
            {
                pageSize = (int)objSelected;
                LoadPageDeliveries();
            }
        }

        private void GridDelete_Click(object? sender, EventArgs e)
        {
            int cId = GetSelectedRow_DeliveryId();

            if (cId <= 0) {
                return;
            }

            if (MessageBox.Show("Opravdu chcete smazat záznam (akce je nevratná)?",
                "Smazání záznamu",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultC = MessageBox.Show("Přejete si dopočítat cenu objednávky?",
                    "Dopočet ceny",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);

                var conn = DbConnProvider.Instance.Conn;

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                int currentDeliveryId = GetSelectedRow_DeliveryId();

                string sqlDelete = @"DELETE FROM amain.delivery
                    WHERE delivery_id = @DeliveryId
                    RETURNING delivery_id, price_czk";

                // s dopočtem ceny (-)
                if (resultC == DialogResult.OK)
                {
                    sqlDelete = @"WITH deleted AS (
                        DELETE FROM amain.delivery
                        WHERE delivery_id = @DeliveryId
                        RETURNING delivery_id, price_czk
                    )
                    UPDATE amain.order o
                    SET total_price_czk = total_price_czk - d.price_czk
                    FROM deleted d
                    WHERE o.delivery_id = d.delivery_id";
                }

                using (var cmd = new NpgsqlCommand(sqlDelete, DbConnProvider.Instance.Conn))
                {
                    cmd.Parameters.AddWithValue("@DeliveryId",
                        NpgsqlTypes.NpgsqlDbType.Integer,
                        cId);

                    cmd.ExecuteScalar();
                }
                LoadTab1(); // refresh
            }
        }

        private int GetSelectedRow_DeliveryId()
        {
            if (dataGridViewDeliveries.Rows.Count == 0) // nejsou řádky
                return 0;

            var selectedValue = dataGridViewDeliveries.CurrentRow.Cells[0].Value;

            if (selectedValue != null)
            {
                return (int)selectedValue;
            }
            else
            {
                return 0; // není vybráno
            }
        }

        private void GridEdit_Click(object? sender, EventArgs e)
        {
            int cId = GetSelectedRow_DeliveryId();

            if (cId > 0)
            {
                var dlgDeliveryE = new dlgDeliveryEA();
                dlgDeliveryE.UpdateMode = true;
                dlgDeliveryE.LoadData(GetSelectedRow_DeliveryId());
                ShowUserControlModal(dlgDeliveryE, "Editace doručení");
                LoadTab1(); // refresh
            }
        }

        private void GridCreate_Click(object? sender, EventArgs e)
        {
            var dlgDeliveryA = new dlgDeliveryEA();
            dlgDeliveryA.InsertMode = true;
            ShowUserControlModal(dlgDeliveryA, "Vytvoření doručení");
            LoadTab1(); // refresh
        }

        private void GridRefresh_Click(object? sender, EventArgs e)
        {
            LoadTab1();
        }

        private void PaginationButton_Click(object? sender, EventArgs e)
        {
            if (sender == btnFirst) currentPage = 1;
            else if (sender == btnPrev) currentPage = Math.Max(1, currentPage - 1);
            else if (sender == btnNext) currentPage = Math.Min(totalPages, currentPage + 1);
            else if (sender == btnLast) currentPage = totalPages;

            LoadPageDeliveries();
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

        private void DefineGridColumnsTab()
        {
            dataGridViewDeliveries.AutoGenerateColumns = false;
            dataGridViewDeliveries.Columns.Clear();

            dataGridViewDeliveries.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DeliveryId",
                HeaderText = "ID",
                Name = "colDeliveryId",
                ReadOnly = true,
                Width = 120
            });

            dataGridViewDeliveries.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderId",
                HeaderText = "ID objednávky",
                Name = "colOrderId",
                ReadOnly = true,
                Width = 120
            });

            dataGridViewDeliveries.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DeliveryType",
                HeaderText = "Typ",
                Name = "colDeliveryType",
                ReadOnly = true,
                Width = 120
            });

            dataGridViewDeliveries.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DeliveryDate",
                HeaderText = "Datum dodání",
                Name = "colDeliveryDate",
                ReadOnly = true,
                Width = 200
            });

            dataGridViewDeliveries.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DeliveryAddress",
                HeaderText = "Adresa",
                Name = "colDeliveryDate",
                ReadOnly = true,
                Width = 120
            });

            dataGridViewDeliveries.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Status",
                Name = "colStatus",
                ReadOnly = true,
                Width = 120
            });

            dataGridViewDeliveries.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PriceCZK",
                HeaderText = "Cena (CZK)",
                Name = "colPriceCZK",
                ReadOnly = true,
                Width = 120
            });

            dataGridViewDeliveries.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Note",
                HeaderText = "Poznámka",
                Name = "colNote",
                ReadOnly = true,
                Width = 120
            });
        }

        private void LoadAllDeliveries()
        {
            string sql = @"
            SELECT d.delivery_id as DeliveryId,
                o.order_id as OrderId,
                d.delivery_type as DeliveryType,
                d.delivery_date as DeliveryDate,
                d.delivery_address as DeliveryAddress,
                d.status as Status,
                d.price_czk as PriceCZK,
                d.note as Note
            FROM amain.delivery d
            LEFT JOIN amain.""order"" o ON d.delivery_id = o.delivery_id 
            ORDER BY d.delivery_id ASC
            ";

            using var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);
            deliveriesAdapter = new NpgsqlDataAdapter(cmd);

            dtDeliveries.Clear();
            deliveriesAdapter.Fill(dtDeliveries);

            // nastavení datasource
            dataGridViewDeliveries.DataSource = dtDeliveries;
            DbConnProvider.Instance.ConnClose();
        }

    }
}
