namespace Orderis.UserControls.Mod.Users
{
    partial class ModUsersMain
    {
        /// <summary> 
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            tabControlUsers = new TabControl();
            tabPageUsers = new TabPage();
            tableLayoutPanelMain = new TableLayoutPanel();
            pGCUsers = new Panel();
            fLPPagination = new FlowLayoutPanel();
            btnFirst = new Button();
            btnPrev = new Button();
            lblCurrentPage = new Label();
            btnNext = new Button();
            btnLast = new Button();
            lblPageNum = new Label();
            cBoxPerPage = new ComboBox();
            dataGridViewUsers = new DataGridView();
            pGCHeaderUsers = new Panel();
            flowLayoutPanelSearch = new FlowLayoutPanel();
            cBoxSearch = new ComboBox();
            textBoxSearch = new TextBox();
            fLPButtons = new FlowLayoutPanel();
            btnRefresh = new Button();
            btnCreate = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            tabPageUserRoles = new TabPage();
            tableLayoutPanelUserRoles = new TableLayoutPanel();
            panelUserRoles = new Panel();
            flowLayoutPanelUserRoles = new FlowLayoutPanel();
            btnFirstR = new Button();
            btnPrevR = new Button();
            lblCurrentPageR = new Label();
            btnNextR = new Button();
            btnLastR = new Button();
            lblPageNumR = new Label();
            cBoxPerPageR = new ComboBox();
            dataGridViewUserRoles = new DataGridView();
            panelHeaderUserRoles = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnRefreshR = new Button();
            btnCreateR = new Button();
            btnEditR = new Button();
            btnDeleteR = new Button();
            tabPageCustomerAccounts = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnFirstA = new Button();
            btnPrevA = new Button();
            lblCurrentPageA = new Label();
            btnNextA = new Button();
            btnLastA = new Button();
            labelPageNumA = new Label();
            cBoxPerPageA = new ComboBox();
            dataGridViewUserAccounts = new DataGridView();
            panel2 = new Panel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            btnRefreshA = new Button();
            btnCreateA = new Button();
            btnDeleteA = new Button();
            tabPageUserActual = new TabPage();
            textBoxUserRole = new TextBox();
            labelUserRole = new Label();
            textBoxEmail = new TextBox();
            label6 = new Label();
            textBoxLastname = new TextBox();
            label5 = new Label();
            labelHeading = new Label();
            textBoxFirstname = new TextBox();
            textBoxLogin = new TextBox();
            label4 = new Label();
            label3 = new Label();
            tabControlUsers.SuspendLayout();
            tabPageUsers.SuspendLayout();
            tableLayoutPanelMain.SuspendLayout();
            pGCUsers.SuspendLayout();
            fLPPagination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            pGCHeaderUsers.SuspendLayout();
            flowLayoutPanelSearch.SuspendLayout();
            fLPButtons.SuspendLayout();
            tabPageUserRoles.SuspendLayout();
            tableLayoutPanelUserRoles.SuspendLayout();
            panelUserRoles.SuspendLayout();
            flowLayoutPanelUserRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUserRoles).BeginInit();
            panelHeaderUserRoles.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            tabPageCustomerAccounts.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUserAccounts).BeginInit();
            panel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            tabPageUserActual.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlUsers
            // 
            tabControlUsers.AccessibleName = "";
            tabControlUsers.Controls.Add(tabPageUsers);
            tabControlUsers.Controls.Add(tabPageUserRoles);
            tabControlUsers.Controls.Add(tabPageCustomerAccounts);
            tabControlUsers.Controls.Add(tabPageUserActual);
            tabControlUsers.Dock = DockStyle.Fill;
            tabControlUsers.Location = new Point(0, 0);
            tabControlUsers.Name = "tabControlUsers";
            tabControlUsers.SelectedIndex = 0;
            tabControlUsers.Size = new Size(794, 440);
            tabControlUsers.TabIndex = 1;
            tabControlUsers.SelectedIndexChanged += tabControlUsers_SelectedIndexChanged;
            // 
            // tabPageUsers
            // 
            tabPageUsers.Controls.Add(tableLayoutPanelMain);
            tabPageUsers.Cursor = Cursors.Hand;
            tabPageUsers.Location = new Point(4, 29);
            tabPageUsers.Name = "tabPageUsers";
            tabPageUsers.Padding = new Padding(3);
            tabPageUsers.Size = new Size(786, 407);
            tabPageUsers.TabIndex = 0;
            tabPageUsers.Text = "Uživatelé";
            tabPageUsers.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.ColumnCount = 1;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.Controls.Add(pGCUsers, 0, 1);
            tableLayoutPanelMain.Controls.Add(dataGridViewUsers, 1, 0);
            tableLayoutPanelMain.Controls.Add(pGCHeaderUsers, 0, 0);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.Location = new Point(3, 3);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 3;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanelMain.Size = new Size(780, 401);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // pGCUsers
            // 
            pGCUsers.Controls.Add(fLPPagination);
            pGCUsers.Dock = DockStyle.Bottom;
            pGCUsers.Location = new Point(3, 324);
            pGCUsers.Name = "pGCUsers";
            pGCUsers.Size = new Size(774, 74);
            pGCUsers.TabIndex = 2;
            // 
            // fLPPagination
            // 
            fLPPagination.Controls.Add(btnFirst);
            fLPPagination.Controls.Add(btnPrev);
            fLPPagination.Controls.Add(lblCurrentPage);
            fLPPagination.Controls.Add(btnNext);
            fLPPagination.Controls.Add(btnLast);
            fLPPagination.Controls.Add(lblPageNum);
            fLPPagination.Controls.Add(cBoxPerPage);
            fLPPagination.Dock = DockStyle.Left;
            fLPPagination.Location = new Point(0, 0);
            fLPPagination.Name = "fLPPagination";
            fLPPagination.Size = new Size(211, 74);
            fLPPagination.TabIndex = 5;
            // 
            // btnFirst
            // 
            btnFirst.Anchor = AnchorStyles.None;
            btnFirst.Location = new Point(3, 3);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(40, 29);
            btnFirst.TabIndex = 0;
            btnFirst.Text = "<<";
            btnFirst.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            btnPrev.Anchor = AnchorStyles.None;
            btnPrev.Location = new Point(49, 3);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(40, 29);
            btnPrev.TabIndex = 1;
            btnPrev.Text = "<";
            btnPrev.UseVisualStyleBackColor = true;
            // 
            // lblCurrentPage
            // 
            lblCurrentPage.Anchor = AnchorStyles.None;
            lblCurrentPage.AutoSize = true;
            lblCurrentPage.Location = new Point(95, 7);
            lblCurrentPage.Name = "lblCurrentPage";
            lblCurrentPage.Size = new Size(17, 20);
            lblCurrentPage.TabIndex = 4;
            lblCurrentPage.Text = "1";
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.None;
            btnNext.Location = new Point(118, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(40, 29);
            btnNext.TabIndex = 2;
            btnNext.Text = ">";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // btnLast
            // 
            btnLast.Anchor = AnchorStyles.None;
            btnLast.Location = new Point(164, 3);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(40, 29);
            btnLast.TabIndex = 3;
            btnLast.Text = ">>";
            btnLast.UseVisualStyleBackColor = true;
            // 
            // lblPageNum
            // 
            lblPageNum.AutoSize = true;
            lblPageNum.Dock = DockStyle.Left;
            lblPageNum.Font = new Font("Segoe UI", 9F);
            lblPageNum.Location = new Point(3, 35);
            lblPageNum.Name = "lblPageNum";
            lblPageNum.Size = new Size(138, 37);
            lblPageNum.TabIndex = 5;
            lblPageNum.Text = "Počet prvků stránky:";
            lblPageNum.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cBoxPerPage
            // 
            cBoxPerPage.Font = new Font("Segoe UI", 10F);
            cBoxPerPage.FormattingEnabled = true;
            cBoxPerPage.Location = new Point(147, 38);
            cBoxPerPage.Name = "cBoxPerPage";
            cBoxPerPage.Size = new Size(57, 31);
            cBoxPerPage.TabIndex = 6;
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.BackgroundColor = SystemColors.Window;
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Dock = DockStyle.Fill;
            dataGridViewUsers.GridColor = SystemColors.Window;
            dataGridViewUsers.Location = new Point(3, 48);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.RowHeadersWidth = 51;
            dataGridViewUsers.Size = new Size(774, 270);
            dataGridViewUsers.TabIndex = 1;
            dataGridViewUsers.CellContentClick += dataGridViewUsers_CellContentClick;
            // 
            // pGCHeaderUsers
            // 
            pGCHeaderUsers.Controls.Add(flowLayoutPanelSearch);
            pGCHeaderUsers.Controls.Add(fLPButtons);
            pGCHeaderUsers.Dock = DockStyle.Top;
            pGCHeaderUsers.Location = new Point(3, 3);
            pGCHeaderUsers.Name = "pGCHeaderUsers";
            pGCHeaderUsers.Size = new Size(774, 39);
            pGCHeaderUsers.TabIndex = 0;
            // 
            // flowLayoutPanelSearch
            // 
            flowLayoutPanelSearch.Controls.Add(cBoxSearch);
            flowLayoutPanelSearch.Controls.Add(textBoxSearch);
            flowLayoutPanelSearch.Dock = DockStyle.Right;
            flowLayoutPanelSearch.Location = new Point(190, 0);
            flowLayoutPanelSearch.Name = "flowLayoutPanelSearch";
            flowLayoutPanelSearch.Size = new Size(584, 39);
            flowLayoutPanelSearch.TabIndex = 4;
            // 
            // cBoxSearch
            // 
            cBoxSearch.DropDownHeight = 200;
            cBoxSearch.Font = new Font("Segoe UI", 10F);
            cBoxSearch.FormattingEnabled = true;
            cBoxSearch.IntegralHeight = false;
            cBoxSearch.ItemHeight = 23;
            cBoxSearch.Location = new Point(3, 3);
            cBoxSearch.Name = "cBoxSearch";
            cBoxSearch.Size = new Size(151, 31);
            cBoxSearch.TabIndex = 1;
            cBoxSearch.SelectedIndexChanged += cBoxSearch_SelectedIndexChanged;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Dock = DockStyle.Right;
            textBoxSearch.Font = new Font("Segoe UI", 10F);
            textBoxSearch.Location = new Point(160, 3);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(421, 30);
            textBoxSearch.TabIndex = 2;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // fLPButtons
            // 
            fLPButtons.Controls.Add(btnRefresh);
            fLPButtons.Controls.Add(btnCreate);
            fLPButtons.Controls.Add(btnEdit);
            fLPButtons.Controls.Add(btnDelete);
            fLPButtons.Dock = DockStyle.Left;
            fLPButtons.Location = new Point(0, 0);
            fLPButtons.Name = "fLPButtons";
            fLPButtons.Size = new Size(158, 39);
            fLPButtons.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(3, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(30, 30);
            btnRefresh.TabIndex = 0;
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(39, 3);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(30, 30);
            btnCreate.TabIndex = 1;
            btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(75, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(30, 30);
            btnEdit.TabIndex = 2;
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(111, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(30, 30);
            btnDelete.TabIndex = 3;
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // tabPageUserRoles
            // 
            tabPageUserRoles.Controls.Add(tableLayoutPanelUserRoles);
            tabPageUserRoles.Cursor = Cursors.Hand;
            tabPageUserRoles.Location = new Point(4, 29);
            tabPageUserRoles.Name = "tabPageUserRoles";
            tabPageUserRoles.Padding = new Padding(3);
            tabPageUserRoles.Size = new Size(786, 407);
            tabPageUserRoles.TabIndex = 1;
            tabPageUserRoles.Text = "Role";
            tabPageUserRoles.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelUserRoles
            // 
            tableLayoutPanelUserRoles.ColumnCount = 1;
            tableLayoutPanelUserRoles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelUserRoles.Controls.Add(panelUserRoles, 0, 1);
            tableLayoutPanelUserRoles.Controls.Add(dataGridViewUserRoles, 1, 0);
            tableLayoutPanelUserRoles.Controls.Add(panelHeaderUserRoles, 0, 0);
            tableLayoutPanelUserRoles.Dock = DockStyle.Fill;
            tableLayoutPanelUserRoles.Location = new Point(3, 3);
            tableLayoutPanelUserRoles.Name = "tableLayoutPanelUserRoles";
            tableLayoutPanelUserRoles.RowCount = 3;
            tableLayoutPanelUserRoles.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanelUserRoles.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelUserRoles.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanelUserRoles.Size = new Size(780, 401);
            tableLayoutPanelUserRoles.TabIndex = 1;
            // 
            // panelUserRoles
            // 
            panelUserRoles.Controls.Add(flowLayoutPanelUserRoles);
            panelUserRoles.Dock = DockStyle.Bottom;
            panelUserRoles.Location = new Point(3, 324);
            panelUserRoles.Name = "panelUserRoles";
            panelUserRoles.Size = new Size(774, 74);
            panelUserRoles.TabIndex = 2;
            // 
            // flowLayoutPanelUserRoles
            // 
            flowLayoutPanelUserRoles.Controls.Add(btnFirstR);
            flowLayoutPanelUserRoles.Controls.Add(btnPrevR);
            flowLayoutPanelUserRoles.Controls.Add(lblCurrentPageR);
            flowLayoutPanelUserRoles.Controls.Add(btnNextR);
            flowLayoutPanelUserRoles.Controls.Add(btnLastR);
            flowLayoutPanelUserRoles.Controls.Add(lblPageNumR);
            flowLayoutPanelUserRoles.Controls.Add(cBoxPerPageR);
            flowLayoutPanelUserRoles.Dock = DockStyle.Left;
            flowLayoutPanelUserRoles.Location = new Point(0, 0);
            flowLayoutPanelUserRoles.Name = "flowLayoutPanelUserRoles";
            flowLayoutPanelUserRoles.Size = new Size(211, 74);
            flowLayoutPanelUserRoles.TabIndex = 5;
            // 
            // btnFirstR
            // 
            btnFirstR.Anchor = AnchorStyles.None;
            btnFirstR.Location = new Point(3, 3);
            btnFirstR.Name = "btnFirstR";
            btnFirstR.Size = new Size(40, 29);
            btnFirstR.TabIndex = 0;
            btnFirstR.Text = "<<";
            btnFirstR.UseVisualStyleBackColor = true;
            // 
            // btnPrevR
            // 
            btnPrevR.Anchor = AnchorStyles.None;
            btnPrevR.Location = new Point(49, 3);
            btnPrevR.Name = "btnPrevR";
            btnPrevR.Size = new Size(40, 29);
            btnPrevR.TabIndex = 1;
            btnPrevR.Text = "<";
            btnPrevR.UseVisualStyleBackColor = true;
            // 
            // lblCurrentPageR
            // 
            lblCurrentPageR.Anchor = AnchorStyles.None;
            lblCurrentPageR.AutoSize = true;
            lblCurrentPageR.Location = new Point(95, 7);
            lblCurrentPageR.Name = "lblCurrentPageR";
            lblCurrentPageR.Size = new Size(17, 20);
            lblCurrentPageR.TabIndex = 4;
            lblCurrentPageR.Text = "1";
            // 
            // btnNextR
            // 
            btnNextR.Anchor = AnchorStyles.None;
            btnNextR.Location = new Point(118, 3);
            btnNextR.Name = "btnNextR";
            btnNextR.Size = new Size(40, 29);
            btnNextR.TabIndex = 2;
            btnNextR.Text = ">";
            btnNextR.UseVisualStyleBackColor = true;
            // 
            // btnLastR
            // 
            btnLastR.Anchor = AnchorStyles.None;
            btnLastR.Location = new Point(164, 3);
            btnLastR.Name = "btnLastR";
            btnLastR.Size = new Size(40, 29);
            btnLastR.TabIndex = 3;
            btnLastR.Text = ">>";
            btnLastR.UseVisualStyleBackColor = true;
            // 
            // lblPageNumR
            // 
            lblPageNumR.AutoSize = true;
            lblPageNumR.Dock = DockStyle.Left;
            lblPageNumR.Font = new Font("Segoe UI", 9F);
            lblPageNumR.Location = new Point(3, 35);
            lblPageNumR.Name = "lblPageNumR";
            lblPageNumR.Size = new Size(138, 37);
            lblPageNumR.TabIndex = 5;
            lblPageNumR.Text = "Počet prvků stránky:";
            lblPageNumR.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cBoxPerPageR
            // 
            cBoxPerPageR.Font = new Font("Segoe UI", 10F);
            cBoxPerPageR.FormattingEnabled = true;
            cBoxPerPageR.Location = new Point(147, 38);
            cBoxPerPageR.Name = "cBoxPerPageR";
            cBoxPerPageR.Size = new Size(57, 31);
            cBoxPerPageR.TabIndex = 6;
            // 
            // dataGridViewUserRoles
            // 
            dataGridViewUserRoles.BackgroundColor = SystemColors.Window;
            dataGridViewUserRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUserRoles.Dock = DockStyle.Fill;
            dataGridViewUserRoles.GridColor = SystemColors.Window;
            dataGridViewUserRoles.Location = new Point(3, 48);
            dataGridViewUserRoles.Name = "dataGridViewUserRoles";
            dataGridViewUserRoles.RowHeadersWidth = 51;
            dataGridViewUserRoles.Size = new Size(774, 270);
            dataGridViewUserRoles.TabIndex = 1;
            // 
            // panelHeaderUserRoles
            // 
            panelHeaderUserRoles.Controls.Add(flowLayoutPanel2);
            panelHeaderUserRoles.Dock = DockStyle.Top;
            panelHeaderUserRoles.Location = new Point(3, 3);
            panelHeaderUserRoles.Name = "panelHeaderUserRoles";
            panelHeaderUserRoles.Size = new Size(774, 39);
            panelHeaderUserRoles.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnRefreshR);
            flowLayoutPanel2.Controls.Add(btnCreateR);
            flowLayoutPanel2.Controls.Add(btnEditR);
            flowLayoutPanel2.Controls.Add(btnDeleteR);
            flowLayoutPanel2.Dock = DockStyle.Left;
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(158, 39);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // btnRefreshR
            // 
            btnRefreshR.Location = new Point(3, 3);
            btnRefreshR.Name = "btnRefreshR";
            btnRefreshR.Size = new Size(30, 30);
            btnRefreshR.TabIndex = 0;
            btnRefreshR.UseVisualStyleBackColor = true;
            // 
            // btnCreateR
            // 
            btnCreateR.Location = new Point(39, 3);
            btnCreateR.Name = "btnCreateR";
            btnCreateR.Size = new Size(30, 30);
            btnCreateR.TabIndex = 1;
            btnCreateR.UseVisualStyleBackColor = true;
            btnCreateR.Visible = false;
            // 
            // btnEditR
            // 
            btnEditR.Location = new Point(75, 3);
            btnEditR.Name = "btnEditR";
            btnEditR.Size = new Size(30, 30);
            btnEditR.TabIndex = 2;
            btnEditR.UseVisualStyleBackColor = true;
            btnEditR.Visible = false;
            // 
            // btnDeleteR
            // 
            btnDeleteR.Location = new Point(111, 3);
            btnDeleteR.Name = "btnDeleteR";
            btnDeleteR.Size = new Size(30, 30);
            btnDeleteR.TabIndex = 3;
            btnDeleteR.UseVisualStyleBackColor = true;
            btnDeleteR.Visible = false;
            // 
            // tabPageCustomerAccounts
            // 
            tabPageCustomerAccounts.Controls.Add(tableLayoutPanel1);
            tabPageCustomerAccounts.Cursor = Cursors.Hand;
            tabPageCustomerAccounts.Location = new Point(4, 29);
            tabPageCustomerAccounts.Name = "tabPageCustomerAccounts";
            tabPageCustomerAccounts.Padding = new Padding(3);
            tabPageCustomerAccounts.Size = new Size(786, 407);
            tabPageCustomerAccounts.TabIndex = 2;
            tabPageCustomerAccounts.Text = "Uživatelské účty";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Controls.Add(dataGridViewUserAccounts, 1, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.Size = new Size(780, 401);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(3, 324);
            panel1.Name = "panel1";
            panel1.Size = new Size(774, 74);
            panel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnFirstA);
            flowLayoutPanel1.Controls.Add(btnPrevA);
            flowLayoutPanel1.Controls.Add(lblCurrentPageA);
            flowLayoutPanel1.Controls.Add(btnNextA);
            flowLayoutPanel1.Controls.Add(btnLastA);
            flowLayoutPanel1.Controls.Add(labelPageNumA);
            flowLayoutPanel1.Controls.Add(cBoxPerPageA);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(211, 74);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // btnFirstA
            // 
            btnFirstA.Anchor = AnchorStyles.None;
            btnFirstA.Location = new Point(3, 3);
            btnFirstA.Name = "btnFirstA";
            btnFirstA.Size = new Size(40, 29);
            btnFirstA.TabIndex = 0;
            btnFirstA.Text = "<<";
            btnFirstA.UseVisualStyleBackColor = true;
            // 
            // btnPrevA
            // 
            btnPrevA.Anchor = AnchorStyles.None;
            btnPrevA.Location = new Point(49, 3);
            btnPrevA.Name = "btnPrevA";
            btnPrevA.Size = new Size(40, 29);
            btnPrevA.TabIndex = 1;
            btnPrevA.Text = "<";
            btnPrevA.UseVisualStyleBackColor = true;
            // 
            // lblCurrentPageA
            // 
            lblCurrentPageA.Anchor = AnchorStyles.None;
            lblCurrentPageA.AutoSize = true;
            lblCurrentPageA.Location = new Point(95, 7);
            lblCurrentPageA.Name = "lblCurrentPageA";
            lblCurrentPageA.Size = new Size(17, 20);
            lblCurrentPageA.TabIndex = 4;
            lblCurrentPageA.Text = "1";
            // 
            // btnNextA
            // 
            btnNextA.Anchor = AnchorStyles.None;
            btnNextA.Location = new Point(118, 3);
            btnNextA.Name = "btnNextA";
            btnNextA.Size = new Size(40, 29);
            btnNextA.TabIndex = 2;
            btnNextA.Text = ">";
            btnNextA.UseVisualStyleBackColor = true;
            // 
            // btnLastA
            // 
            btnLastA.Anchor = AnchorStyles.None;
            btnLastA.Location = new Point(164, 3);
            btnLastA.Name = "btnLastA";
            btnLastA.Size = new Size(40, 29);
            btnLastA.TabIndex = 3;
            btnLastA.Text = ">>";
            btnLastA.UseVisualStyleBackColor = true;
            // 
            // labelPageNumA
            // 
            labelPageNumA.AutoSize = true;
            labelPageNumA.Dock = DockStyle.Left;
            labelPageNumA.Font = new Font("Segoe UI", 9F);
            labelPageNumA.Location = new Point(3, 35);
            labelPageNumA.Name = "labelPageNumA";
            labelPageNumA.Size = new Size(138, 37);
            labelPageNumA.TabIndex = 5;
            labelPageNumA.Text = "Počet prvků stránky:";
            labelPageNumA.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cBoxPerPageA
            // 
            cBoxPerPageA.Font = new Font("Segoe UI", 10F);
            cBoxPerPageA.FormattingEnabled = true;
            cBoxPerPageA.Location = new Point(147, 38);
            cBoxPerPageA.Name = "cBoxPerPageA";
            cBoxPerPageA.Size = new Size(57, 31);
            cBoxPerPageA.TabIndex = 6;
            // 
            // dataGridViewUserAccounts
            // 
            dataGridViewUserAccounts.BackgroundColor = SystemColors.Window;
            dataGridViewUserAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUserAccounts.Dock = DockStyle.Fill;
            dataGridViewUserAccounts.GridColor = SystemColors.Window;
            dataGridViewUserAccounts.Location = new Point(3, 48);
            dataGridViewUserAccounts.Name = "dataGridViewUserAccounts";
            dataGridViewUserAccounts.RowHeadersWidth = 51;
            dataGridViewUserAccounts.Size = new Size(774, 270);
            dataGridViewUserAccounts.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(flowLayoutPanel3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(774, 39);
            panel2.TabIndex = 0;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(btnRefreshA);
            flowLayoutPanel3.Controls.Add(btnCreateA);
            flowLayoutPanel3.Controls.Add(btnDeleteA);
            flowLayoutPanel3.Dock = DockStyle.Left;
            flowLayoutPanel3.Location = new Point(0, 0);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(158, 39);
            flowLayoutPanel3.TabIndex = 0;
            // 
            // btnRefreshA
            // 
            btnRefreshA.Location = new Point(3, 3);
            btnRefreshA.Name = "btnRefreshA";
            btnRefreshA.Size = new Size(30, 30);
            btnRefreshA.TabIndex = 0;
            btnRefreshA.UseVisualStyleBackColor = true;
            // 
            // btnCreateA
            // 
            btnCreateA.Location = new Point(39, 3);
            btnCreateA.Name = "btnCreateA";
            btnCreateA.Size = new Size(30, 30);
            btnCreateA.TabIndex = 1;
            btnCreateA.UseVisualStyleBackColor = true;
            // 
            // btnDeleteA
            // 
            btnDeleteA.Location = new Point(75, 3);
            btnDeleteA.Name = "btnDeleteA";
            btnDeleteA.Size = new Size(30, 30);
            btnDeleteA.TabIndex = 3;
            btnDeleteA.UseVisualStyleBackColor = true;
            // 
            // tabPageUserActual
            // 
            tabPageUserActual.Controls.Add(textBoxUserRole);
            tabPageUserActual.Controls.Add(labelUserRole);
            tabPageUserActual.Controls.Add(textBoxEmail);
            tabPageUserActual.Controls.Add(label6);
            tabPageUserActual.Controls.Add(textBoxLastname);
            tabPageUserActual.Controls.Add(label5);
            tabPageUserActual.Controls.Add(labelHeading);
            tabPageUserActual.Controls.Add(textBoxFirstname);
            tabPageUserActual.Controls.Add(textBoxLogin);
            tabPageUserActual.Controls.Add(label4);
            tabPageUserActual.Controls.Add(label3);
            tabPageUserActual.Cursor = Cursors.Hand;
            tabPageUserActual.Location = new Point(4, 29);
            tabPageUserActual.Name = "tabPageUserActual";
            tabPageUserActual.Padding = new Padding(3);
            tabPageUserActual.Size = new Size(786, 407);
            tabPageUserActual.TabIndex = 3;
            tabPageUserActual.Text = "Osobní";
            tabPageUserActual.UseVisualStyleBackColor = true;
            // 
            // textBoxUserRole
            // 
            textBoxUserRole.Location = new Point(144, 253);
            textBoxUserRole.Name = "textBoxUserRole";
            textBoxUserRole.ReadOnly = true;
            textBoxUserRole.Size = new Size(189, 27);
            textBoxUserRole.TabIndex = 10;
            // 
            // labelUserRole
            // 
            labelUserRole.AutoSize = true;
            labelUserRole.Location = new Point(6, 256);
            labelUserRole.Name = "labelUserRole";
            labelUserRole.Size = new Size(116, 20);
            labelUserRole.TabIndex = 9;
            labelUserRole.Text = "Uživatelská role:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(79, 194);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.ReadOnly = true;
            textBoxEmail.Size = new Size(255, 27);
            textBoxEmail.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 197);
            label6.Name = "label6";
            label6.Size = new Size(49, 20);
            label6.TabIndex = 7;
            label6.Text = "Email:";
            // 
            // textBoxLastname
            // 
            textBoxLastname.Location = new Point(78, 148);
            textBoxLastname.Name = "textBoxLastname";
            textBoxLastname.ReadOnly = true;
            textBoxLastname.Size = new Size(255, 27);
            textBoxLastname.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 151);
            label5.Name = "label5";
            label5.Size = new Size(66, 20);
            label5.TabIndex = 5;
            label5.Text = "Přijmení:";
            // 
            // labelHeading
            // 
            labelHeading.AutoSize = true;
            labelHeading.Font = new Font("Segoe UI", 12F);
            labelHeading.Location = new Point(6, 13);
            labelHeading.Name = "labelHeading";
            labelHeading.Size = new Size(226, 28);
            labelHeading.TabIndex = 4;
            labelHeading.Text = "Aktuální uživatelský účet";
            // 
            // textBoxFirstname
            // 
            textBoxFirstname.Location = new Point(79, 103);
            textBoxFirstname.Name = "textBoxFirstname";
            textBoxFirstname.ReadOnly = true;
            textBoxFirstname.Size = new Size(255, 27);
            textBoxFirstname.TabIndex = 3;
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(79, 63);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.ReadOnly = true;
            textBoxLogin.Size = new Size(255, 27);
            textBoxLogin.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 106);
            label4.Name = "label4";
            label4.Size = new Size(55, 20);
            label4.TabIndex = 1;
            label4.Text = "Jméno:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 63);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 0;
            label3.Text = "Login:";
            // 
            // ModUsersMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControlUsers);
            Name = "ModUsersMain";
            Size = new Size(794, 440);
            tabControlUsers.ResumeLayout(false);
            tabPageUsers.ResumeLayout(false);
            tableLayoutPanelMain.ResumeLayout(false);
            pGCUsers.ResumeLayout(false);
            fLPPagination.ResumeLayout(false);
            fLPPagination.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            pGCHeaderUsers.ResumeLayout(false);
            flowLayoutPanelSearch.ResumeLayout(false);
            flowLayoutPanelSearch.PerformLayout();
            fLPButtons.ResumeLayout(false);
            tabPageUserRoles.ResumeLayout(false);
            tableLayoutPanelUserRoles.ResumeLayout(false);
            panelUserRoles.ResumeLayout(false);
            flowLayoutPanelUserRoles.ResumeLayout(false);
            flowLayoutPanelUserRoles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUserRoles).EndInit();
            panelHeaderUserRoles.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            tabPageCustomerAccounts.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUserAccounts).EndInit();
            panel2.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            tabPageUserActual.ResumeLayout(false);
            tabPageUserActual.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControlUsers;
        private TabPage tabPageUsers;
        private Panel pGCUsers;
        private DataGridView dataGridViewUsers;
        private Panel pGCHeaderUsers;
        private TableLayoutPanel tableLayoutPanelMain;
        private Button btnLast;
        private Button btnNext;
        private Button btnPrev;
        private Button btnFirst;
        private Label lblCurrentPage;
        private FlowLayoutPanel fLPPagination;
        private Label lblPageNum;
        private ComboBox cBoxPerPage;
        private FlowLayoutPanel fLPButtons;
        private Button btnRefresh;
        private Button btnCreate;
        private Button btnEdit;
        private Button btnDelete;
        private TabPage tabPageUserRoles;
        private TableLayoutPanel tableLayoutPanelUserRoles;
        private Panel panelUserRoles;
        private FlowLayoutPanel flowLayoutPanelUserRoles;
        private Button btnFirstR;
        private Button btnPrevR;
        private Label lblCurrentPageR;
        private Button btnNextR;
        private Button btnLastR;
        private Label lblPageNumR;
        private ComboBox cBoxPerPageR;
        private DataGridView dataGridViewUserRoles;
        private Panel panelHeaderUserRoles;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnRefreshR;
        private Button btnCreateR;
        private Button btnEditR;
        private Button btnDeleteR;
        private TextBox textBoxSearch;
        private ComboBox cBoxSearch;
        private FlowLayoutPanel flowLayoutPanelSearch;
        private TabPage tabCustomerAccounts;
        private Panel panel1;
        private TabPage tabPageUserActual;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnFirstA;
        private Button btnPrevA;
        private Label lblCurrentPageA;
        private Button btnNextA;
        private Button btnLastA;
        private Label labelPageNumA;
        private ComboBox cBoxPerPageA;
        private DataGridView dataGridViewUserAccounts;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button btnRefreshA;
        private Button btnCreateA;
        private Button btnDeleteA;
        private Label label4;
        private Label label3;
        private Label labelHeading;
        private TextBox textBoxFirstname;
        private TextBox textBoxLogin;
        private TextBox textBoxEmail;
        private Label label6;
        private TextBox textBoxLastname;
        private Label label5;
        private TabPage tabPageCustomerAccounts;
        private Label labelUserRole;
        private TextBox textBoxUserRole;
    }
}
