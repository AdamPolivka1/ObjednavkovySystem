using Npgsql;
using Orderappis.Data.Model;
using Orderappis.UserControls.Mod.Orders.dlg;
using Orderis.Data;
using Orderis.Services.Auth;
using System.Data;

namespace Orderis.UserControls.Mod.Orders
{
    public partial class ModOrdersPayment : UserControl
    {
        // TAB 1 currentPage
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalPages = 0;

        // TAB 1
        private DataTable dtPayments = new DataTable();
        private NpgsqlDataAdapter? paymentsAdapter;

        // Auth Info ---------------------
        private Boolean isZ { get; set; } = false;
        private Boolean isM { get; set; } = false;
        private Boolean isS { get; set; } = false;
        private Boolean isA { get; set; } = false;
        //--------------------------------

        public ModOrdersPayment()
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
            LoadAllPayments();
            LoadPagePayments();
        }

        private void LoadPagePayments()
        {
            double divP = Math.Ceiling((double)dtPayments.Rows.Count / pageSize);
            totalPages = Convert.ToInt32(divP);

            int skip = (currentPage - 1) * pageSize;
            int eIndexRow = skip + pageSize;

            if (eIndexRow > dtPayments.Rows.Count)
            {
                eIndexRow = dtPayments.Rows.Count;
            }

            DataTable pageTable = dtPayments.Clone();
            for (int i = skip; i < eIndexRow; i++)
            {
                pageTable.ImportRow(dtPayments.Rows[i]);
            }

            dataGridViewPayments.DataSource = pageTable;

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

            if (!isA && !isM) 
            { 
                btnCreate.Visible = false;
            }

            btnEdit.Image = System.Drawing.Image.FromFile(@"Images\edit.png");
            btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
            btnEdit.TextAlign = ContentAlignment.MiddleRight;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Click += GridEdit_Click;

            if (!isA && !isM)
            {
                btnEdit.Visible = false;
            }

            btnDelete.Image = System.Drawing.Image.FromFile(@"Images\trash.png");
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.TextAlign = ContentAlignment.MiddleRight;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Click += GridDelete_Click;

            if (!isA && !isM)
            {
                btnDelete.Visible = false;
            }

            // combobox
            cBoxPerPage.Items.Clear();
            cBoxPerPage.Items.AddRange(new object[] { 3, 5, 10, 20, 50, 100 });
            cBoxPerPage.SelectedIndex = 2;
            cBoxPerPage.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxPerPage.SelectedIndexChanged += ChangePerPage_Click;

            dataGridViewPayments.ReadOnly = true;
            dataGridViewPayments.CellFormatting += GridCellFormatting;

            // cBoxPaymentMethod
            List<PaymentStatus> listVals = new List<PaymentStatus>();
            listVals.Add(new PaymentStatus(0, "Vše"));
            listVals.Add(new PaymentStatus(1, "Plac. hotově"));
            listVals.Add(new PaymentStatus(2, "Plac. kartou"));
            listVals.Add(new PaymentStatus(3, "Dobírka"));

            cBoxPaymentMethod.DataSource = listVals;
            cBoxPaymentMethod.DisplayMember = "Name";
            cBoxPaymentMethod.ValueMember = "Id";
            cBoxPaymentMethod.SelectedIndex = 0;
            cBoxPaymentMethod.SelectedValueChanged += SelectedValueChanged;

            DefineGridColumnsTab();
            ApplyDefaultGridStyles(dataGridViewPayments);
        }

        private int GetSelectedRow_PaymentId()
        {
            if (dataGridViewPayments.Rows.Count == 0) // nejsou řádky
                return 0;

            var cIdVar = dataGridViewPayments.CurrentRow.Cells[0].Value;

            if (cIdVar != null)
            {
                return (int)cIdVar;
            }
            else
            {
                return 0; // není vybráno
            }
        }

        private void GridEdit_Click(object? sender, EventArgs e)
        {
            int cId = GetSelectedRow_PaymentId();

            if (cId > 0)
            {
                var dlgPaymentE = new dlgPaymentE();
                dlgPaymentE.PaymentId = GetSelectedRow_PaymentId();
                dlgPaymentE.LoadData();
                ShowUserControlModal(dlgPaymentE, "Editace platby");
                LoadTab1(); // refresh
            }
        }

        private void SelectedValueChanged(object? sender, EventArgs e)
        {
            // filtruj dataview
            if (dataGridViewPayments.DataSource == null)
                return;

            int selectedFilterStatus = cBoxPaymentMethod.SelectedIndex - 1;

            // -1 => "Vše" (= nevýbráno)
            //  0 => "Hotově"
            //  1 => "Kartou"
            //  2 => "Dobírka"
            DataView view;

            if (dataGridViewPayments.DataSource is DataTable dt)
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
                view.RowFilter = $"PaymentMethod = {selectedFilterStatus}";
            }
        }

        private void GridCellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            // status
            if (dataGridViewPayments.Columns[e.ColumnIndex].Name == "colStatus"
                && e.Value != null)
            {
                switch (e.Value)
                {
                    case 0:
                        e.Value = "Storno";
                        break;
                    case 1:
                        e.Value = "Platná";
                        break;
                }
            }

            // price
            if (dataGridViewPayments.Columns[e.ColumnIndex].Name == "colTotalCZK"
                && e.Value != null)
            {
                if ((decimal)e.Value == 0.0m)
                {
                    e.Value = "Vše (objednávka)";
                }
            }

            // payment method
            // 0 = hotově, 1 = kartou, 2 = dobírka
            if (dataGridViewPayments.Columns[e.ColumnIndex].Name == "colPaymentMethod"
                && e.Value != null)
            {
                switch (e.Value)
                {
                    case 0:
                        e.Value = "Hotově";
                        break;
                    case 1:
                        e.Value = "Kartou";
                        break;
                    case 2:
                        e.Value = "Dobírka";
                        break;
                }
            }
        }

        private void ChangePerPage_Click(object? sender, EventArgs e)
        {
            currentPage = 1;
            var selectedI = cBoxPerPage.SelectedItem;
            if (selectedI != null)
            {
                pageSize = (int)selectedI;
                LoadPagePayments();
            }
        }

        private void GridDelete_Click(object? sender, EventArgs e)
        {
            int cPaymentId = GetSelectedRow_PaymentId();

            if (cPaymentId <= 0)
            {
                return;
            }

            if (MessageBox.Show("Opravdu chcete smazat záznam (akce je nevratná)?",
                "Smazání záznamu",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (!isM)
                {
                    MessageBox.Show("Mazání plateb je zakázané",
                        "Důležité upozornění",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                else 
                {
                    var conn = DbConnProvider.Instance.Conn;

                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    string sqlDelete = @"DELETE FROM amain.payment
                        WHERE payment_id=@PaymentId";
                    using (var cmd = new NpgsqlCommand(sqlDelete, DbConnProvider.Instance.Conn))
                    {
                        cmd.Parameters.AddWithValue("@PaymentId",
                            NpgsqlTypes.NpgsqlDbType.Integer,
                            cPaymentId);

                        cmd.ExecuteScalar();
                    }
                }
            }
            LoadTab1();
        }

        private void GridCreate_Click(object? sender, EventArgs e)
        {
            var dlgDeliveryA = new dlgPaymentA();
            ShowUserControlModal(dlgDeliveryA, "Vytvoření platby");
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

            LoadPagePayments();
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
            dataGridViewPayments.AutoGenerateColumns = false;
            dataGridViewPayments.Columns.Clear();

            dataGridViewPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PaymentId",
                HeaderText = "ID",
                Name = "colPaymentId",
                ReadOnly = true,
                Width = 120
            });

            dataGridViewPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderId",
                HeaderText = "ID objednávky",
                Name = "colOrderId",
                ReadOnly = true,
                Width = 120
            });

            dataGridViewPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PaymentDate",
                HeaderText = "Datum splatnosti",
                Name = "colPaymentDate",
                ReadOnly = true,
                Width = 120
            });

            dataGridViewPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PaymentMethod",
                HeaderText = "Metoda",
                Name = "colPaymentMethod",
                ReadOnly = true,
                Width = 120
            });

            dataGridViewPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalCZK",
                HeaderText = "Částka",
                Name = "colTotalCZK",
                ReadOnly = true,
                Width = 200
            });

            dataGridViewPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Status",
                Name = "colStatus",
                ReadOnly = true,
                Width = 120
            });

            dataGridViewPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Note",
                HeaderText = "Poznámka",
                Name = "colNote",
                ReadOnly = true,
                Width = 120
            });
        }

        private void LoadAllPayments()
        {
            string sql = @"
            SELECT p.payment_id as PaymentId,
                o.order_id as OrderId,
                p.payment_date as PaymentDate,
                p.payment_method as PaymentMethod,
                p.total_czk as TotalCZK,
                p.status as Status,
                p.note as Note
            FROM amain.payment p
            LEFT JOIN amain.""order"" o ON p.payment_id = o.payment_id
            ORDER BY p.payment_id ASC
            ";

            using var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);
            paymentsAdapter = new NpgsqlDataAdapter(cmd);

            dtPayments.Clear();
            paymentsAdapter.Fill(dtPayments);

            // nastavení datasource
            dataGridViewPayments.DataSource = dtPayments;
            DbConnProvider.Instance.ConnClose();
        }

    }
}
