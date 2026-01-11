using Npgsql;
using NpgsqlTypes;
using Orderappis.UserControls.Mod.Users.dlg;
using Orderis.Data;
using Orderis.Services.Auth;
using System.Data;

namespace Orderis.UserControls.Mod.Users
{
    public partial class ModUsersMain : UserControl
    {
        // Tab 1
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalPages = 0;

        // Tab 2
        private int currentPageR = 1;
        private int pageSizeR = 10;
        private int totalPagesR = 0;

        // Tab 3
        private int currentPageA = 1;
        private int pageSizeA = 10;
        private int totalPagesA = 0;

        // Auth Info ---------------------
        private Boolean isZ { get; set; }
        private Boolean isM { get; set; }
        private Boolean isS { get; set; }
        private Boolean isA { get; set; }
        //--------------------------------

        private DataTable dtUsers = new DataTable();
        private DataTable dtRoles = new DataTable();
        private DataTable dtAccounts = new DataTable();
        private NpgsqlDataAdapter userAdapter = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter roleAdapter = new NpgsqlDataAdapter();
        private NpgsqlDataAdapter accountAdapter = new NpgsqlDataAdapter();

        public ModUsersMain()
        {
            InitializeComponent(); // default init
            SetAuthInfo(); // auth info
            Init(); // načtení dat tab1
            SetElementsDefaults(); // nastavení vzhledu tab1
            SetElementsDefaultsTab2(); // .. tab2
            SetElementsDefaultsTab3(); // .. tab3
        }

        private void SetAuthInfo()
        {
            isZ = AuthService.Instance.InUserRole("zákazník");
            isM = AuthService.Instance.InUserRole("manažer");
            isS = AuthService.Instance.InUserRole("skladník");
            isA = AuthService.Instance.InUserRole("administrátor");
        }

        private void Init()
        {
            LoadAllUsers();
            LoadPage();
        }

        private void InitTab2()
        {
            LoadAllRoles();
            LoadPageTab2();
        }

        private void InitTab3()
        {
            LoadAllAccounts();
            LoadPageTab3();
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

            // search combobox
            cBoxSearch.Items.Clear();
            cBoxSearch.Items.AddRange(new object[] {
                "Login",    // "Login"
                "Jméno",    // "Firstname"
                "Přijmení", // "Lastname"
                "Email",    // "Email"
                "Firma"     // "CompanyName"
            });
            cBoxSearch.SelectedIndex = 0;
            cBoxSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxSearch.Cursor = Cursors.Hand;

            // grid buttons set images
            btnRefresh.Image = Image.FromFile(@"Images\refresh.png");
            btnRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            btnRefresh.TextAlign = ContentAlignment.MiddleRight;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.Click += GridRefresh_Click;

            btnCreate.Image = Image.FromFile(@"Images\create.png");
            btnCreate.ImageAlign = ContentAlignment.MiddleLeft;
            btnCreate.TextAlign = ContentAlignment.MiddleRight;
            btnCreate.Cursor = Cursors.Hand;
            btnCreate.Click += GridCreate_Click;

            if (!isA)
            { 
                btnCreate.Visible = false;
            }

            btnEdit.Image = Image.FromFile(@"Images\edit.png");
            btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
            btnEdit.TextAlign = ContentAlignment.MiddleRight;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Click += GridEdit_Click;

            if (!isA)
            {
                btnEdit.Visible = false;
            }

            btnDelete.Image = Image.FromFile(@"Images\trash.png");
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.TextAlign = ContentAlignment.MiddleRight;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Click += GridDelete_Click;

            if (!isA)
            {
                btnDelete.Visible = false;
            }

            // combobox
            cBoxPerPage.Items.Clear();
            cBoxPerPage.Items.AddRange(new object[] { 3, 5, 10, 20, 50, 100 });
            cBoxPerPage.SelectedIndex = 2;
            cBoxPerPage.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxPerPage.SelectedIndexChanged += ChangePerPage_Click;

            dataGridViewUsers.ReadOnly = true;

            DefineGridColumns();
            ApplyDefaultGridStyles(dataGridViewUsers);
        }

        private void SetElementsDefaultsTab2()
        {
            btnFirstR.Click += PaginationButtonR_Click;
            btnPrevR.Click += PaginationButtonR_Click;
            btnNextR.Click += PaginationButtonR_Click;
            btnLastR.Click += PaginationButtonR_Click;

            btnFirstR.Cursor = Cursors.Hand;
            btnPrevR.Cursor = Cursors.Hand;
            btnNextR.Cursor = Cursors.Hand;
            btnLastR.Cursor = Cursors.Hand;

            // grid
            btnRefreshR.Image = Image.FromFile(@"Images\refresh.png");
            btnRefreshR.ImageAlign = ContentAlignment.MiddleLeft;
            btnRefreshR.TextAlign = ContentAlignment.MiddleRight;
            btnRefreshR.Cursor = Cursors.Hand;
            btnRefreshR.Click += GridRefreshR_Click;

            // combobox
            cBoxPerPageR.Items.Clear();
            cBoxPerPageR.Items.AddRange(new object[] { 3, 5, 10, 20, 50, 100 });
            cBoxPerPageR.SelectedIndex = 2;
            cBoxPerPageR.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxPerPageR.SelectedIndexChanged += ChangePerPageR_Click;

            dataGridViewUserRoles.ReadOnly = true;

            DefineGridColumnsR();
            ApplyDefaultGridStyles(dataGridViewUserRoles);
        }

        private void SetElementsDefaultsTab3()
        {
            btnFirstA.Click += PaginationButtonA_Click;
            btnPrevA.Click += PaginationButtonA_Click;
            btnNextA.Click += PaginationButtonA_Click;
            btnLastA.Click += PaginationButtonA_Click;

            btnFirstA.Cursor = Cursors.Hand;
            btnPrevA.Cursor = Cursors.Hand;
            btnNextA.Cursor = Cursors.Hand;
            btnLastA.Cursor = Cursors.Hand;

            // grid
            btnRefreshA.Image = Image.FromFile(@"Images\refresh.png");
            btnRefreshA.ImageAlign = ContentAlignment.MiddleLeft;
            btnRefreshA.TextAlign = ContentAlignment.MiddleRight;
            btnRefreshA.Cursor = Cursors.Hand;
            btnRefreshA.Click += GridRefreshA_Click;

            btnCreateA.Image = Image.FromFile(@"Images\create.png");
            btnCreateA.ImageAlign = ContentAlignment.MiddleLeft;
            btnCreateA.TextAlign = ContentAlignment.MiddleRight;
            btnCreateA.Cursor = Cursors.Hand;
            btnCreateA.Click += GridCreateA_Click;

            if (!isA)
            {
                btnCreateA.Visible = false;
            }

            btnDeleteA.Image = Image.FromFile(@"Images\trash.png");
            btnDeleteA.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeleteA.TextAlign = ContentAlignment.MiddleRight;
            btnDeleteA.Cursor = Cursors.Hand;
            btnDeleteA.Click += GridDeleteA_Click;

            if (!isA)
            {
                btnDeleteA.Visible = false;
            }

            // combobox
            cBoxPerPageA.Items.Clear();
            cBoxPerPageA.Items.AddRange(new object[] { 3, 5, 10, 20, 50, 100 });
            cBoxPerPageA.SelectedIndex = 2;
            cBoxPerPageA.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxPerPageA.SelectedIndexChanged += ChangePerPageA_Click;

            dataGridViewUserAccounts.ReadOnly = true;

            DefineGridColumnsA();
            ApplyDefaultGridStyles(dataGridViewUserAccounts);
        }

        private void GridRefreshA_Click(object? sender, EventArgs e)
        {
            InitTab3();
        }

        private void SearchGrid()
        {
            if (dataGridViewUsers.DataSource == null)
                return;

            string searchText = textBoxSearch.Text.Trim();
            int selectedColumnIndex = cBoxSearch.SelectedIndex;

            if (selectedColumnIndex < 0)
                return;

            // 0 => "Login"
            // 1 => "Firstname"
            // 2 => "Lastname"
            // 3 => "Email"
            // 4 => "CompanyName"
            // namapomvání na sloupce gridu
            switch (selectedColumnIndex) {
                case 0:
                    selectedColumnIndex = 2;
                    break;
                case 1:
                    selectedColumnIndex = 3;
                    break;
                case 2:
                    selectedColumnIndex = 4;
                    break;
                case 3:
                    selectedColumnIndex = 5;
                    break;
                case 4:
                    selectedColumnIndex = 6;
                    break;
            }

            string columnName = dataGridViewUsers.Columns[selectedColumnIndex].DataPropertyName;
            DataView view;

            if (dataGridViewUsers.DataSource is DataTable dt)
            {
                view = dt.DefaultView;
            }
            else
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(searchText))
            {
                view.RowFilter = "";
            }
            else
            {
                string escaped = searchText.Replace("'", "''");
                view.RowFilter = $"{columnName} LIKE '%{escaped}%'";
            }
        }

        private void GridRefresh_Click(object? sender, EventArgs e)
        {
            //if(sender ==  null) return;
            Init();
        }

        private void GridRefreshR_Click(object? sender, EventArgs e)
        {
            //if (sender == null) return;
            InitTab2();
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

        private int GetCurrentRowUserId()
        {
            if (dataGridViewUsers.CurrentRow != null)
            {
                int selectedUserId = Convert.ToInt32(dataGridViewUsers.CurrentRow.Cells[0].Value);
                return selectedUserId;
            }
            return -1;
        }

        private void InsertUserDataSet(Data.Model.User user)
        {
            // definice InsertCommand pro adapter
            userAdapter.InsertCommand = new NpgsqlCommand(@"
                INSERT INTO amain.""user"" 
                    (user_role_id, login, password, firstname, lastname, email, company_name, phone_num1, phone_num2)
                VALUES 
                    (@UserRoleId, @Login, @Password, @Firstname, @Lastname, @Email, @CompanyName, @PhoneNum1, @PhoneNum2)
                RETURNING user_id
            ", DbConnProvider.Instance.Conn);

            userAdapter.InsertCommand.Parameters.Add("@UserRoleId", NpgsqlDbType.Integer, 0, "UserRoleId");
            userAdapter.InsertCommand.Parameters.Add("@Login", NpgsqlDbType.Varchar, 0, "Login");
            userAdapter.InsertCommand.Parameters.Add("@Password", NpgsqlDbType.Varchar, 0, "Password");
            userAdapter.InsertCommand.Parameters.Add("@Firstname", NpgsqlDbType.Varchar, 0, "Firstname");
            userAdapter.InsertCommand.Parameters.Add("@Lastname", NpgsqlDbType.Varchar, 0, "Lastname");
            userAdapter.InsertCommand.Parameters.Add("@Email", NpgsqlDbType.Varchar, 0, "Email");
            userAdapter.InsertCommand.Parameters.Add("@CompanyName", NpgsqlDbType.Varchar, 0, "CompanyName");
            userAdapter.InsertCommand.Parameters.Add("@PhoneNum1", NpgsqlDbType.Varchar, 0, "PhoneNum1");
            userAdapter.InsertCommand.Parameters.Add("@PhoneNum2", NpgsqlDbType.Varchar, 0, "PhoneNum2");

            // přidání nového DataRow do DataTable
            DataRow newRow = dtUsers.NewRow();
            newRow["UserRoleId"] = user.UserRoleId;
            newRow["Login"] = user.Login;
            newRow["Password"] = user.Password;
            newRow["Firstname"] = user.Firstname;
            newRow["Lastname"] = user.Lastname;
            newRow["Email"] = user.Email;
            newRow["CompanyName"] = user.CompanyName;
            newRow["PhoneNum1"] = user.PhoneNum1;
            newRow["PhoneNum2"] = string.IsNullOrEmpty(user.PhoneNum2)
                ? (object)DBNull.Value
                : user.PhoneNum2;

            dtUsers.ImportRow(newRow);

            // provedení insertu přes adapter
            userAdapter.Update(dtUsers);

            // refresh grid
            Init();
        }

        private void DeleteCustomerAccountDataSet()
        {
            if (dataGridViewUserAccounts.CurrentRow != null) {
                int rowIndex = dataGridViewUserAccounts.CurrentRow.Index;
                DataRow row = dtAccounts.Rows[rowIndex];
                row.Delete();

                accountAdapter.DeleteCommand = new NpgsqlCommand(@"
                    DELETE FROM amain.""customer_account"" 
                    WHERE customer_account_id = @CustomerAccountId
                ", DbConnProvider.Instance.Conn);

                accountAdapter.DeleteCommand.Parameters.Add("@CustomerAccountId",
                    NpgsqlDbType.Integer, 0, "CustomerAccountId");
                accountAdapter.Update(dtAccounts);

                InitTab3(); // refresh
            }
        }

        private void DeleteUserDataSet()
        {
            if (dataGridViewUsers.CurrentRow != null)
            {
                int rowIndex = dataGridViewUsers.CurrentRow.Index;
                DataRow row = dtUsers.Rows[rowIndex];
                row.Delete();

                userAdapter.DeleteCommand = new NpgsqlCommand(@"
                    DELETE FROM amain.""user"" 
                    WHERE user_id = @UserId
                ", DbConnProvider.Instance.Conn);

                userAdapter.DeleteCommand.Parameters.Add("@UserId", NpgsqlDbType.Integer, 0, "UserId");
                userAdapter.Update(dtUsers);

                Init(); // refresh
            }
        }

        private void UpdateUserDataSet(Data.Model.User user)
        {
            DataRow row = dtUsers.Rows
                .Cast<DataRow>()
                .First(r => (int)r["UserId"] == user.UserId);

            if (row != null)
            {
                // definice updatu pro data adapter
                userAdapter.UpdateCommand = new NpgsqlCommand(@"
                UPDATE amain.""user""
                SET
                    user_role_id = @UserRoleId,
                    login = @Login,
                    password = @Password,
                    firstname = @Firstname,
                    lastname = @Lastname,
                    email = @Email,
                    company_name = @CompanyName,
                    phone_num1 = @PhoneNum1,
                    phone_num2 = @PhoneNum2
                WHERE user_id = @UserId
                ", DbConnProvider.Instance.Conn);

                userAdapter.UpdateCommand.Parameters.Add("@UserRoleId", NpgsqlDbType.Integer, 0, "UserRoleId");
                userAdapter.UpdateCommand.Parameters.Add("@Login", NpgsqlDbType.Varchar, 0, "Login");
                userAdapter.UpdateCommand.Parameters.Add("@Password", NpgsqlDbType.Varchar, 0, "Password");
                userAdapter.UpdateCommand.Parameters.Add("@Firstname", NpgsqlDbType.Varchar, 0, "Firstname");
                userAdapter.UpdateCommand.Parameters.Add("@Lastname", NpgsqlDbType.Varchar, 0, "Lastname");
                userAdapter.UpdateCommand.Parameters.Add("@Email", NpgsqlDbType.Varchar, 0, "Email");
                userAdapter.UpdateCommand.Parameters.Add("@CompanyName", NpgsqlDbType.Varchar, 0, "CompanyName");
                userAdapter.UpdateCommand.Parameters.Add("@PhoneNum1", NpgsqlDbType.Varchar, 0, "PhoneNum1");
                userAdapter.UpdateCommand.Parameters.Add("@PhoneNum2", NpgsqlDbType.Varchar, 0, "PhoneNum2");
                userAdapter.UpdateCommand.Parameters.Add("@UserId", NpgsqlDbType.Integer, 0, "UserId");

                row["UserRoleId"] = user.UserRoleId;
                row["Login"] = user.Login;
                row["Password"] = user.Password;
                row["Firstname"] = user.Firstname;
                row["Lastname"] = user.Lastname;
                row["Email"] = user.Email;
                row["CompanyName"] = user.CompanyName;
                row["PhoneNum1"] = user.PhoneNum1;
                row["PhoneNum2"] = string.IsNullOrEmpty(user.PhoneNum2)
                    ? (object)DBNull.Value
                    : user.PhoneNum2;

                userAdapter.Update(dtUsers);
                
                Init(); // refresh
            }
        }

        private void GridCreate_Click(object? sender, EventArgs e)
        {
            if (sender == null) return;
            bool ModalAllowInsert = false;
            using (var modal = new dlgUserEA())
            {
                modal.LoadData();
                ShowUserControlModal(modal, "Přidání uživatele");
                ModalAllowInsert = modal.AllowInsert;
                if (ModalAllowInsert)
                {
                    InsertUserDataSet(modal.UserModel);
                }
            }
        }

        private void GridDeleteA_Click(object? sender, EventArgs e)
        {
            if (MessageDialog.ShowMessage("question", "Přejete si smazat zákaznický účet?") == DialogResult.OK)
            {
                DeleteCustomerAccountDataSet();
            }
        }

        private void GridCreateA_Click(object? sender, EventArgs e)
        {
            using (var modal = new dlgCustomerAccountA())
            {
                ShowUserControlModal(modal, "Přidání zákaznického účtu");
                
                if (modal.InsertSuccess)
                {
                    InitTab3(); // refresh
                }
            }
        }

        private void GridEdit_Click(object? sender, EventArgs e)
        {
            if (sender == null) return;
            bool ModalAllowEdit = false;
            int userId = GetCurrentRowUserId();
            if (userId > 0)
            {
                using (var modal = new dlgUserEA())
                {
                    modal.UserModel.UserId = userId;
                    modal.LoadData();
                    ShowUserControlModal(modal, "Editace uživatele");
                    // check if modal edit OK
                    ModalAllowEdit = modal.AllowEdit;
                    if (ModalAllowEdit)
                    {
                        UpdateUserDataSet(modal.UserModel);
                    }
                }
            }
        }

        private void GridDelete_Click(object? sender, EventArgs e)
        {
            if (MessageDialog.ShowMessage("question", "Přejete si smazat uživatele?") == DialogResult.OK)
            {
                DeleteUserDataSet();
            }
        }

        private void ApplyDefaultGridStyles(DataGridView dgv)
        {
            dgv.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.EnableHeadersVisualStyles = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.RowTemplate.Height = 28;
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgv.RowsDefaultCellStyle.ForeColor = Color.Black;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.LightGray;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.AllowUserToResizeRows = false;
            dgv.ScrollBars = ScrollBars.Both;
            dgv.RowHeadersVisible = false;
            dgv.DefaultCellStyle.SelectionBackColor = Color.MediumTurquoise;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.AllowUserToAddRows = false;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.MediumTurquoise;
        }

        private void ChangePerPage_Click(object? sender, EventArgs e)
        {
            currentPage = 1;
            var selectedI = cBoxPerPage.SelectedItem;
            if (selectedI != null)
            {
                pageSize = (int)selectedI;
                LoadPage();
            }
        }

        private void ChangePerPageR_Click(object? sender, EventArgs e)
        {
            currentPageR = 1;
            var selectedR = cBoxPerPage.SelectedItem;
            if (selectedR != null)
            {
                pageSizeR = (int)selectedR;
                LoadPageTab2();
            }
        }

        private void ChangePerPageA_Click(object? sender, EventArgs e)
        {
            currentPageA = 1;
            var pgS = cBoxPerPageA.SelectedItem;
            if (pgS != null) {
                pageSizeA = (int)pgS;
                LoadPageTab3();
            }
        }

        private void PaginationButton_Click(object? sender, EventArgs e)
        {
            if (sender == null) return; 
            if (sender == btnFirst) currentPage = 1;
            else if (sender == btnPrev) currentPage = Math.Max(1, currentPage - 1);
            else if (sender == btnNext) currentPage = Math.Min(totalPages, currentPage + 1);
            else if (sender == btnLast) currentPage = totalPages;

            LoadPage();
        }

        private void PaginationButtonR_Click(object? sender, EventArgs e)
        {
            if (sender == null) return;
            if (sender == btnFirstR) currentPageR = 1;
            else if (sender == btnPrevR) currentPageR = Math.Max(1, currentPageR - 1);
            else if (sender == btnNextR) currentPageR = Math.Min(totalPagesR, currentPageR + 1);
            else if (sender == btnLastR) currentPageR = totalPagesR;

            LoadPageTab2();
        }

        private void PaginationButtonA_Click(object? sender, EventArgs e)
        {
            if (sender == null) return;
            if (sender == btnFirstA) currentPageA = 1;
            else if (sender == btnPrevA) currentPageA = Math.Max(1, currentPageA - 1);
            else if (sender == btnNextA) currentPageA = Math.Min(totalPagesA, currentPageA + 1);
            else if (sender == btnLastA) currentPageA = totalPagesA;

            LoadPageTab3();
        }

        private void LoadPage()
        {
            double divP = Math.Ceiling((double)dtUsers.Rows.Count / pageSize);
            totalPages = Convert.ToInt32(divP);

            int skip = (currentPage - 1) * pageSize;
            int eRowIndex = skip + pageSize;

            // pokud je pageSize větší než zbylý počet prvků
            if (eRowIndex > dtUsers.Rows.Count)
                eRowIndex = dtUsers.Rows.Count;

            DataTable pageTable = dtUsers.Clone();
            for (int i = skip; i < eRowIndex; i++)
            {
                pageTable.ImportRow(dtUsers.Rows[i]);
            }

            dataGridViewUsers.DataSource = pageTable;

            // tlačítka
            btnFirst.Enabled = currentPage > 1;
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
            btnLast.Enabled = currentPage < totalPages;

            // nastavení aktuální strany (popis)
            lblCurrentPage.Text = currentPage.ToString();
        }

        private void LoadPageTab2()
        {
            double divP = Math.Ceiling((double)dtRoles.Rows.Count / pageSizeR);
            totalPagesR = Convert.ToInt32(divP);

            int skip = (currentPageR - 1) * pageSizeR;
            int eRowIndex = skip + pageSizeR;

            if (eRowIndex > dtRoles.Rows.Count)
                eRowIndex = dtRoles.Rows.Count;

            DataTable actualPageTable = dtRoles.Clone();
            for (int i = skip; i < eRowIndex; i++)
            {
                actualPageTable.ImportRow(dtRoles.Rows[i]);
            }

            dataGridViewUserRoles.DataSource = actualPageTable;

            // tlačítka
            btnFirstR.Enabled = currentPageR > 1;
            btnPrevR.Enabled = currentPageR > 1;
            btnNextR.Enabled = currentPageR < totalPagesR;
            btnLastR.Enabled = currentPageR < totalPagesR;

            // nastavení aktuální strany (popis)
            lblCurrentPageR.Text = currentPageR.ToString();
        }

        private void LoadPageTab3()
        {
            double divP = Math.Ceiling((double)dtAccounts.Rows.Count / pageSizeA);
            totalPagesA = Convert.ToInt32(divP);

            DataView dv = new DataView(dtAccounts);

            int skip = (currentPageA - 1) * pageSizeA;
            int eRowIndex = skip + pageSizeA;
            
            if (eRowIndex > dtAccounts.Rows.Count)
                eRowIndex = dtAccounts.Rows.Count;

            DataTable pageTable = dtAccounts.Clone();
            for (int i = skip; i < eRowIndex; i++)
            {
                pageTable.ImportRow(dtAccounts.Rows[i]);
            }

            dataGridViewUserAccounts.DataSource = pageTable;

            // tlačítka
            btnFirstA.Enabled = currentPageA > 1;
            btnPrevA.Enabled = currentPageA > 1;
            btnNextA.Enabled = currentPageA < totalPagesA;
            btnLastA.Enabled = currentPageA < totalPagesA;

            // nastavení aktuální strany (popis)
            lblCurrentPageA.Text = currentPageA.ToString();
        }

        private void DefineGridColumnsA()
        {
            dataGridViewUserAccounts.AutoGenerateColumns = false;
            dataGridViewUserAccounts.Columns.Clear();

            dataGridViewUserAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerAccountId",
                HeaderText = "ID účtu",
                Name = "colCustomerAccountId"
            });

            dataGridViewUserAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UserId",
                HeaderText = "ID uživatele",
                Name = "colUserId"
            });

            dataGridViewUserAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CreatedAt",
                HeaderText = "Vytvořeno",
                Name = "colCreatedAt",
                DefaultCellStyle = { Format = "yyyy-MM-dd HH:mm" },
                Width = 250
            });

            dataGridViewUserAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ValidTo",
                HeaderText = "Platný do",
                Name = "colValidTo",
                DefaultCellStyle = { Format = "yyyy-MM-dd" },
                Width = 250
            });
        }

        private void DefineGridColumns()
        {
            dataGridViewUsers.AutoGenerateColumns = false;
            dataGridViewUsers.Columns.Clear();

            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UserId",
                HeaderText = "ID uživatele",
                Name = "colUserId"
            });
            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UserRoleId",
                HeaderText = "Role",
                Name = "colUserRoleId"
            });
            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Login",
                HeaderText = "Přihlašovací jméno",
                Name = "colLogin"
            });
            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Firstname",
                HeaderText = "Jméno",
                Name = "colFirstname"
            });
            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Lastname",
                HeaderText = "Příjmení",
                Name = "colLastname"
            });
            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Name = "colEmail"
            });
            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CompanyName",
                HeaderText = "Firma",
                Name = "colCompanyName"
            });
            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PhoneNum1",
                HeaderText = "Telefon 1",
                Name = "colPhoneNum1"
            });
            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PhoneNum2",
                HeaderText = "Telefon 2",
                Name = "colPhoneNum2"
            });
        }

        private void DefineGridColumnsR()
        {
            dataGridViewUserRoles.AutoGenerateColumns = false;
            dataGridViewUserRoles.Columns.Clear();

            dataGridViewUserRoles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UserRoleId",
                HeaderText = "ID role",
                Name = "colUserRoleId"
            });
            dataGridViewUserRoles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Název role",
                Name = "colName"
            });
        }

        // Load Data Tab UserRoles
        private void LoadAllRoles()
        {
            string sql = @"SELECT user_role_id as UserRoleId, ""name"" as Name
                        FROM amain.user_role ORDER BY user_role_id ASC";

            using var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);
            roleAdapter = new NpgsqlDataAdapter(cmd);

            dtRoles.Clear();
            roleAdapter.Fill(dtRoles);

            DbConnProvider.Instance.ConnClose();
        }

        // Load Data Tab Users
        private void LoadAllUsers()
        {
            string sql = @"SELECT user_id as UserId,
                    user_role_id as UserRoleId,
                    login as Login,
                    password as Password,
                    firstname as Firstname,
                    lastname as Lastname,
                    email as Email,
                    company_name as CompanyName,
                    phone_num1 as PhoneNum1,
                    phone_num2 as PhoneNum2
            FROM amain.user
            ORDER BY user_id";

            using var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);
            userAdapter = new NpgsqlDataAdapter(cmd);

            dtUsers.Clear();
            userAdapter.Fill(dtUsers);

            DbConnProvider.Instance.ConnClose();
        }

        private void LoadAllAccounts()
        {
            string sql = @"
            SELECT customer_account_id AS CustomerAccountId,
                   user_id AS UserId,
                   created_at AS CreatedAt,
                   valid_to AS ValidTo
            FROM amain.customer_account
            ORDER BY customer_account_id";

            using var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);
            accountAdapter = new NpgsqlDataAdapter(cmd);

            dtAccounts.Clear();
            accountAdapter.Fill(dtAccounts);

            DbConnProvider.Instance.ConnClose();
        }

        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { }

        private void tabControlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // reakce na změnu záložky
            int selectedTabIndex = tabControlUsers.SelectedIndex;
            if (selectedTabIndex == 0) // Tab1
            {
                Init();
            }
            if (selectedTabIndex == 1) // Tab2
            {
                InitTab2();
            }
            if (selectedTabIndex == 2) // Tab3
            {
                InitTab3();
            }
            if (selectedTabIndex == 3) // Tab4
            {
                PageCurrentUser();
            }
        }

        private void PageCurrentUser() {
            var user = AuthService.Instance.CurrentUser;
            if (user != null)
            {
                // textBoxLogin
                textBoxLogin.Text = user.Login;
                // textBoxFirstname
                textBoxFirstname.Text = user.Firstname;
                // textBoxLastname
                textBoxLastname.Text = user.Lastname;
                // textBoxEmail
                textBoxEmail.Text = user.Email;
                // TextBoxUserRole
                textBoxUserRole.Text = AuthService.Instance.GetCurrentUserRole();
            }
        }

        private void cBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Search
            SearchGrid();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            //Search
            SearchGrid();
        }

    }
}
