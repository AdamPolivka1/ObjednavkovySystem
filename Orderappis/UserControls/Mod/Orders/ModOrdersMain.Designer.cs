namespace Orderis.UserControls.Mod.Orders
{
    partial class ModOrdersMain
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
            tabPageInvoice = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            btnFirst_Inv = new Button();
            btnPrev_Inv = new Button();
            lblCurrentPage_Inv = new Label();
            btnNext_Inv = new Button();
            btnLast_Inv = new Button();
            label2 = new Label();
            cBoxPerPage_Inv = new ComboBox();
            dataGridViewInvoice = new DataGridView();
            panel2 = new Panel();
            flowLayoutPanel4 = new FlowLayoutPanel();
            flowLayoutPanel5 = new FlowLayoutPanel();
            btnRefresh_Inv = new Button();
            tabPageOrdersSummary = new TabPage();
            panelChart = new Panel();
            formsPlot = new ScottPlot.WinForms.FormsPlot();
            tabPageOrderItems = new TabPage();
            tableLayoutPanelOrderItems = new TableLayoutPanel();
            dataGridViewDown = new DataGridView();
            dataGridViewUp = new DataGridView();
            buttonsGridUp = new Panel();
            flowLayoutPanelUp = new FlowLayoutPanel();
            flowLayoutPanelButtonsUp = new FlowLayoutPanel();
            btnRefreshU = new Button();
            paginationGridUp = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnFirstU = new Button();
            btnPrevU = new Button();
            lblCurrentPageU = new Label();
            btnNextU = new Button();
            btnLastU = new Button();
            lblPageNumU = new Label();
            cBoxPerPageU = new ComboBox();
            buttonsGridDown = new Panel();
            flowLayoutPanelDown = new FlowLayoutPanel();
            flowLayoutPanelButtonsDown = new FlowLayoutPanel();
            btnRefreshD = new Button();
            btnEditD = new Button();
            tabPageOrders = new TabPage();
            tableLayoutPanelOrders = new TableLayoutPanel();
            pGCOrders = new Panel();
            flowLayoutPanelImportExport = new FlowLayoutPanel();
            buttonExportPDF = new Button();
            buttonInvoice = new Button();
            fLPPagination = new FlowLayoutPanel();
            btnFirst = new Button();
            btnPrev = new Button();
            lblCurrentPage = new Label();
            btnNext = new Button();
            btnLast = new Button();
            lblPageNum = new Label();
            cBoxPerPage = new ComboBox();
            dataGridViewOrders = new DataGridView();
            pGCHeaderOrders = new Panel();
            flowLayoutPanelSearch = new FlowLayoutPanel();
            cBoxStatus = new ComboBox();
            cBoxSearch = new ComboBox();
            textBoxSearch = new TextBox();
            fLPButtons = new FlowLayoutPanel();
            btnRefresh = new Button();
            btnCreate = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            tabPageContrMain = new TabControl();
            tabPageInvoice.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInvoice).BeginInit();
            panel2.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            tabPageOrdersSummary.SuspendLayout();
            panelChart.SuspendLayout();
            tabPageOrderItems.SuspendLayout();
            tableLayoutPanelOrderItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUp).BeginInit();
            buttonsGridUp.SuspendLayout();
            flowLayoutPanelButtonsUp.SuspendLayout();
            paginationGridUp.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            buttonsGridDown.SuspendLayout();
            flowLayoutPanelButtonsDown.SuspendLayout();
            tabPageOrders.SuspendLayout();
            tableLayoutPanelOrders.SuspendLayout();
            pGCOrders.SuspendLayout();
            flowLayoutPanelImportExport.SuspendLayout();
            fLPPagination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
            pGCHeaderOrders.SuspendLayout();
            flowLayoutPanelSearch.SuspendLayout();
            fLPButtons.SuspendLayout();
            tabPageContrMain.SuspendLayout();
            SuspendLayout();
            // 
            // tabPageInvoice
            // 
            tabPageInvoice.Controls.Add(tableLayoutPanel1);
            tabPageInvoice.Location = new Point(4, 29);
            tabPageInvoice.Name = "tabPageInvoice";
            tabPageInvoice.Padding = new Padding(3);
            tabPageInvoice.Size = new Size(815, 479);
            tabPageInvoice.TabIndex = 4;
            tabPageInvoice.Text = "[Log] Vystavené faktury";
            tabPageInvoice.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Controls.Add(dataGridViewInvoice, 1, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.Size = new Size(809, 473);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(flowLayoutPanel3);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(3, 396);
            panel1.Name = "panel1";
            panel1.Size = new Size(803, 74);
            panel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = DockStyle.Right;
            flowLayoutPanel1.Location = new Point(606, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(197, 74);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(btnFirst_Inv);
            flowLayoutPanel3.Controls.Add(btnPrev_Inv);
            flowLayoutPanel3.Controls.Add(lblCurrentPage_Inv);
            flowLayoutPanel3.Controls.Add(btnNext_Inv);
            flowLayoutPanel3.Controls.Add(btnLast_Inv);
            flowLayoutPanel3.Controls.Add(label2);
            flowLayoutPanel3.Controls.Add(cBoxPerPage_Inv);
            flowLayoutPanel3.Dock = DockStyle.Left;
            flowLayoutPanel3.Location = new Point(0, 0);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(211, 74);
            flowLayoutPanel3.TabIndex = 5;
            // 
            // btnFirst_Inv
            // 
            btnFirst_Inv.Anchor = AnchorStyles.None;
            btnFirst_Inv.Location = new Point(3, 3);
            btnFirst_Inv.Name = "btnFirst_Inv";
            btnFirst_Inv.Size = new Size(40, 29);
            btnFirst_Inv.TabIndex = 0;
            btnFirst_Inv.Text = "<<";
            btnFirst_Inv.UseVisualStyleBackColor = true;
            // 
            // btnPrev_Inv
            // 
            btnPrev_Inv.Anchor = AnchorStyles.None;
            btnPrev_Inv.Location = new Point(49, 3);
            btnPrev_Inv.Name = "btnPrev_Inv";
            btnPrev_Inv.Size = new Size(40, 29);
            btnPrev_Inv.TabIndex = 1;
            btnPrev_Inv.Text = "<";
            btnPrev_Inv.UseVisualStyleBackColor = true;
            // 
            // lblCurrentPage_Inv
            // 
            lblCurrentPage_Inv.Anchor = AnchorStyles.None;
            lblCurrentPage_Inv.AutoSize = true;
            lblCurrentPage_Inv.Location = new Point(95, 7);
            lblCurrentPage_Inv.Name = "lblCurrentPage_Inv";
            lblCurrentPage_Inv.Size = new Size(17, 20);
            lblCurrentPage_Inv.TabIndex = 4;
            lblCurrentPage_Inv.Text = "1";
            // 
            // btnNext_Inv
            // 
            btnNext_Inv.Anchor = AnchorStyles.None;
            btnNext_Inv.Location = new Point(118, 3);
            btnNext_Inv.Name = "btnNext_Inv";
            btnNext_Inv.Size = new Size(40, 29);
            btnNext_Inv.TabIndex = 2;
            btnNext_Inv.Text = ">";
            btnNext_Inv.UseVisualStyleBackColor = true;
            // 
            // btnLast_Inv
            // 
            btnLast_Inv.Anchor = AnchorStyles.None;
            btnLast_Inv.Location = new Point(164, 3);
            btnLast_Inv.Name = "btnLast_Inv";
            btnLast_Inv.Size = new Size(40, 29);
            btnLast_Inv.TabIndex = 3;
            btnLast_Inv.Text = ">>";
            btnLast_Inv.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(3, 35);
            label2.Name = "label2";
            label2.Size = new Size(138, 37);
            label2.TabIndex = 5;
            label2.Text = "Počet prvků stránky:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cBoxPerPage_Inv
            // 
            cBoxPerPage_Inv.Font = new Font("Segoe UI", 10F);
            cBoxPerPage_Inv.FormattingEnabled = true;
            cBoxPerPage_Inv.Location = new Point(147, 38);
            cBoxPerPage_Inv.Name = "cBoxPerPage_Inv";
            cBoxPerPage_Inv.Size = new Size(57, 31);
            cBoxPerPage_Inv.TabIndex = 6;
            // 
            // dataGridViewInvoice
            // 
            dataGridViewInvoice.BackgroundColor = SystemColors.Window;
            dataGridViewInvoice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInvoice.Dock = DockStyle.Fill;
            dataGridViewInvoice.GridColor = SystemColors.Window;
            dataGridViewInvoice.Location = new Point(3, 48);
            dataGridViewInvoice.Name = "dataGridViewInvoice";
            dataGridViewInvoice.RowHeadersWidth = 51;
            dataGridViewInvoice.Size = new Size(803, 342);
            dataGridViewInvoice.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(flowLayoutPanel4);
            panel2.Controls.Add(flowLayoutPanel5);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(803, 39);
            panel2.TabIndex = 0;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Dock = DockStyle.Right;
            flowLayoutPanel4.Location = new Point(219, 0);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(584, 39);
            flowLayoutPanel4.TabIndex = 4;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Controls.Add(btnRefresh_Inv);
            flowLayoutPanel5.Dock = DockStyle.Left;
            flowLayoutPanel5.Location = new Point(0, 0);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(158, 39);
            flowLayoutPanel5.TabIndex = 0;
            // 
            // btnRefresh_Inv
            // 
            btnRefresh_Inv.Location = new Point(3, 3);
            btnRefresh_Inv.Name = "btnRefresh_Inv";
            btnRefresh_Inv.Size = new Size(30, 30);
            btnRefresh_Inv.TabIndex = 0;
            btnRefresh_Inv.UseVisualStyleBackColor = true;
            // 
            // tabPageOrdersSummary
            // 
            tabPageOrdersSummary.Controls.Add(panelChart);
            tabPageOrdersSummary.Location = new Point(4, 29);
            tabPageOrdersSummary.Name = "tabPageOrdersSummary";
            tabPageOrdersSummary.Padding = new Padding(3);
            tabPageOrdersSummary.Size = new Size(815, 479);
            tabPageOrdersSummary.TabIndex = 2;
            tabPageOrdersSummary.Text = "Souhrn";
            tabPageOrdersSummary.UseVisualStyleBackColor = true;
            // 
            // panelChart
            // 
            panelChart.Controls.Add(formsPlot);
            panelChart.Dock = DockStyle.Fill;
            panelChart.Location = new Point(3, 3);
            panelChart.Margin = new Padding(0);
            panelChart.Name = "panelChart";
            panelChart.Size = new Size(809, 473);
            panelChart.TabIndex = 0;
            // 
            // formsPlot
            // 
            formsPlot.DisplayScale = 1.25F;
            formsPlot.Dock = DockStyle.Fill;
            formsPlot.Location = new Point(0, 0);
            formsPlot.Margin = new Padding(0);
            formsPlot.Name = "formsPlot";
            formsPlot.Padding = new Padding(50);
            formsPlot.Size = new Size(809, 473);
            formsPlot.TabIndex = 0;
            // 
            // tabPageOrderItems
            // 
            tabPageOrderItems.Controls.Add(tableLayoutPanelOrderItems);
            tabPageOrderItems.Location = new Point(4, 29);
            tabPageOrderItems.Name = "tabPageOrderItems";
            tabPageOrderItems.Padding = new Padding(3);
            tabPageOrderItems.Size = new Size(815, 479);
            tabPageOrderItems.TabIndex = 1;
            tabPageOrderItems.Text = "Položky objednávky";
            tabPageOrderItems.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelOrderItems
            // 
            tableLayoutPanelOrderItems.ColumnCount = 1;
            tableLayoutPanelOrderItems.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelOrderItems.Controls.Add(dataGridViewDown, 0, 3);
            tableLayoutPanelOrderItems.Controls.Add(dataGridViewUp, 0, 1);
            tableLayoutPanelOrderItems.Controls.Add(buttonsGridUp, 0, 0);
            tableLayoutPanelOrderItems.Controls.Add(paginationGridUp, 0, 2);
            tableLayoutPanelOrderItems.Controls.Add(buttonsGridDown, 0, 3);
            tableLayoutPanelOrderItems.Dock = DockStyle.Fill;
            tableLayoutPanelOrderItems.Location = new Point(3, 3);
            tableLayoutPanelOrderItems.Name = "tableLayoutPanelOrderItems";
            tableLayoutPanelOrderItems.RowCount = 4;
            tableLayoutPanelOrderItems.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanelOrderItems.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelOrderItems.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanelOrderItems.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanelOrderItems.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            tableLayoutPanelOrderItems.Size = new Size(809, 473);
            tableLayoutPanelOrderItems.TabIndex = 1;
            // 
            // dataGridViewDown
            // 
            dataGridViewDown.BackgroundColor = SystemColors.Window;
            dataGridViewDown.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDown.Dock = DockStyle.Fill;
            dataGridViewDown.Location = new Point(3, 336);
            dataGridViewDown.Name = "dataGridViewDown";
            dataGridViewDown.RowHeadersWidth = 51;
            dataGridViewDown.Size = new Size(803, 134);
            dataGridViewDown.TabIndex = 7;
            // 
            // dataGridViewUp
            // 
            dataGridViewUp.BackgroundColor = SystemColors.Window;
            dataGridViewUp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUp.Dock = DockStyle.Fill;
            dataGridViewUp.Location = new Point(3, 48);
            dataGridViewUp.Name = "dataGridViewUp";
            dataGridViewUp.RowHeadersWidth = 51;
            dataGridViewUp.Size = new Size(803, 192);
            dataGridViewUp.TabIndex = 6;
            // 
            // buttonsGridUp
            // 
            buttonsGridUp.Controls.Add(flowLayoutPanelUp);
            buttonsGridUp.Controls.Add(flowLayoutPanelButtonsUp);
            buttonsGridUp.Dock = DockStyle.Top;
            buttonsGridUp.Location = new Point(3, 3);
            buttonsGridUp.Name = "buttonsGridUp";
            buttonsGridUp.Size = new Size(803, 39);
            buttonsGridUp.TabIndex = 7;
            // 
            // flowLayoutPanelUp
            // 
            flowLayoutPanelUp.Dock = DockStyle.Right;
            flowLayoutPanelUp.Location = new Point(219, 0);
            flowLayoutPanelUp.Name = "flowLayoutPanelUp";
            flowLayoutPanelUp.Size = new Size(584, 39);
            flowLayoutPanelUp.TabIndex = 4;
            // 
            // flowLayoutPanelButtonsUp
            // 
            flowLayoutPanelButtonsUp.Controls.Add(btnRefreshU);
            flowLayoutPanelButtonsUp.Dock = DockStyle.Left;
            flowLayoutPanelButtonsUp.Location = new Point(0, 0);
            flowLayoutPanelButtonsUp.Name = "flowLayoutPanelButtonsUp";
            flowLayoutPanelButtonsUp.Size = new Size(158, 39);
            flowLayoutPanelButtonsUp.TabIndex = 0;
            // 
            // btnRefreshU
            // 
            btnRefreshU.Location = new Point(3, 3);
            btnRefreshU.Name = "btnRefreshU";
            btnRefreshU.Size = new Size(30, 30);
            btnRefreshU.TabIndex = 0;
            btnRefreshU.UseVisualStyleBackColor = true;
            // 
            // paginationGridUp
            // 
            paginationGridUp.Controls.Add(flowLayoutPanel2);
            paginationGridUp.Dock = DockStyle.Bottom;
            paginationGridUp.Location = new Point(3, 246);
            paginationGridUp.Name = "paginationGridUp";
            paginationGridUp.Size = new Size(803, 39);
            paginationGridUp.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnFirstU);
            flowLayoutPanel2.Controls.Add(btnPrevU);
            flowLayoutPanel2.Controls.Add(lblCurrentPageU);
            flowLayoutPanel2.Controls.Add(btnNextU);
            flowLayoutPanel2.Controls.Add(btnLastU);
            flowLayoutPanel2.Controls.Add(lblPageNumU);
            flowLayoutPanel2.Controls.Add(cBoxPerPageU);
            flowLayoutPanel2.Dock = DockStyle.Left;
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(439, 39);
            flowLayoutPanel2.TabIndex = 5;
            // 
            // btnFirstU
            // 
            btnFirstU.Anchor = AnchorStyles.None;
            btnFirstU.Location = new Point(3, 4);
            btnFirstU.Name = "btnFirstU";
            btnFirstU.Size = new Size(40, 29);
            btnFirstU.TabIndex = 0;
            btnFirstU.Text = "<<";
            btnFirstU.UseVisualStyleBackColor = true;
            // 
            // btnPrevU
            // 
            btnPrevU.Anchor = AnchorStyles.None;
            btnPrevU.Location = new Point(49, 4);
            btnPrevU.Name = "btnPrevU";
            btnPrevU.Size = new Size(40, 29);
            btnPrevU.TabIndex = 1;
            btnPrevU.Text = "<";
            btnPrevU.UseVisualStyleBackColor = true;
            // 
            // lblCurrentPageU
            // 
            lblCurrentPageU.Anchor = AnchorStyles.None;
            lblCurrentPageU.AutoSize = true;
            lblCurrentPageU.Location = new Point(95, 8);
            lblCurrentPageU.Name = "lblCurrentPageU";
            lblCurrentPageU.Size = new Size(17, 20);
            lblCurrentPageU.TabIndex = 4;
            lblCurrentPageU.Text = "1";
            // 
            // btnNextU
            // 
            btnNextU.Anchor = AnchorStyles.None;
            btnNextU.Location = new Point(118, 4);
            btnNextU.Name = "btnNextU";
            btnNextU.Size = new Size(40, 29);
            btnNextU.TabIndex = 2;
            btnNextU.Text = ">";
            btnNextU.UseVisualStyleBackColor = true;
            // 
            // btnLastU
            // 
            btnLastU.Anchor = AnchorStyles.None;
            btnLastU.Location = new Point(164, 4);
            btnLastU.Name = "btnLastU";
            btnLastU.Size = new Size(40, 29);
            btnLastU.TabIndex = 3;
            btnLastU.Text = ">>";
            btnLastU.UseVisualStyleBackColor = true;
            // 
            // lblPageNumU
            // 
            lblPageNumU.AutoSize = true;
            lblPageNumU.Dock = DockStyle.Left;
            lblPageNumU.Font = new Font("Segoe UI", 9F);
            lblPageNumU.Location = new Point(210, 0);
            lblPageNumU.Name = "lblPageNumU";
            lblPageNumU.Size = new Size(138, 37);
            lblPageNumU.TabIndex = 5;
            lblPageNumU.Text = "Počet prvků stránky:";
            lblPageNumU.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cBoxPerPageU
            // 
            cBoxPerPageU.Font = new Font("Segoe UI", 10F);
            cBoxPerPageU.FormattingEnabled = true;
            cBoxPerPageU.Location = new Point(354, 3);
            cBoxPerPageU.Name = "cBoxPerPageU";
            cBoxPerPageU.Size = new Size(62, 31);
            cBoxPerPageU.TabIndex = 6;
            // 
            // buttonsGridDown
            // 
            buttonsGridDown.Controls.Add(flowLayoutPanelDown);
            buttonsGridDown.Controls.Add(flowLayoutPanelButtonsDown);
            buttonsGridDown.Dock = DockStyle.Top;
            buttonsGridDown.Location = new Point(3, 291);
            buttonsGridDown.Name = "buttonsGridDown";
            buttonsGridDown.Size = new Size(803, 39);
            buttonsGridDown.TabIndex = 0;
            // 
            // flowLayoutPanelDown
            // 
            flowLayoutPanelDown.Dock = DockStyle.Right;
            flowLayoutPanelDown.Location = new Point(219, 0);
            flowLayoutPanelDown.Name = "flowLayoutPanelDown";
            flowLayoutPanelDown.Size = new Size(584, 39);
            flowLayoutPanelDown.TabIndex = 4;
            // 
            // flowLayoutPanelButtonsDown
            // 
            flowLayoutPanelButtonsDown.Controls.Add(btnRefreshD);
            flowLayoutPanelButtonsDown.Controls.Add(btnEditD);
            flowLayoutPanelButtonsDown.Dock = DockStyle.Left;
            flowLayoutPanelButtonsDown.Location = new Point(0, 0);
            flowLayoutPanelButtonsDown.Name = "flowLayoutPanelButtonsDown";
            flowLayoutPanelButtonsDown.Size = new Size(158, 39);
            flowLayoutPanelButtonsDown.TabIndex = 0;
            // 
            // btnRefreshD
            // 
            btnRefreshD.Location = new Point(3, 3);
            btnRefreshD.Name = "btnRefreshD";
            btnRefreshD.Size = new Size(30, 30);
            btnRefreshD.TabIndex = 0;
            btnRefreshD.UseVisualStyleBackColor = true;
            // 
            // btnEditD
            // 
            btnEditD.Location = new Point(39, 3);
            btnEditD.Name = "btnEditD";
            btnEditD.Size = new Size(30, 30);
            btnEditD.TabIndex = 2;
            btnEditD.UseVisualStyleBackColor = true;
            // 
            // tabPageOrders
            // 
            tabPageOrders.Controls.Add(tableLayoutPanelOrders);
            tabPageOrders.Location = new Point(4, 29);
            tabPageOrders.Name = "tabPageOrders";
            tabPageOrders.Padding = new Padding(3);
            tabPageOrders.Size = new Size(815, 479);
            tabPageOrders.TabIndex = 0;
            tabPageOrders.Text = "Přehled objednávek";
            tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelOrders
            // 
            tableLayoutPanelOrders.ColumnCount = 1;
            tableLayoutPanelOrders.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelOrders.Controls.Add(pGCOrders, 0, 1);
            tableLayoutPanelOrders.Controls.Add(dataGridViewOrders, 1, 0);
            tableLayoutPanelOrders.Controls.Add(pGCHeaderOrders, 0, 0);
            tableLayoutPanelOrders.Dock = DockStyle.Fill;
            tableLayoutPanelOrders.Location = new Point(3, 3);
            tableLayoutPanelOrders.Name = "tableLayoutPanelOrders";
            tableLayoutPanelOrders.RowCount = 3;
            tableLayoutPanelOrders.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanelOrders.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelOrders.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanelOrders.Size = new Size(809, 473);
            tableLayoutPanelOrders.TabIndex = 1;
            // 
            // pGCOrders
            // 
            pGCOrders.Controls.Add(flowLayoutPanelImportExport);
            pGCOrders.Controls.Add(fLPPagination);
            pGCOrders.Dock = DockStyle.Bottom;
            pGCOrders.Location = new Point(3, 396);
            pGCOrders.Name = "pGCOrders";
            pGCOrders.Size = new Size(803, 74);
            pGCOrders.TabIndex = 2;
            // 
            // flowLayoutPanelImportExport
            // 
            flowLayoutPanelImportExport.Controls.Add(buttonExportPDF);
            flowLayoutPanelImportExport.Controls.Add(buttonInvoice);
            flowLayoutPanelImportExport.Dock = DockStyle.Right;
            flowLayoutPanelImportExport.Location = new Point(606, 0);
            flowLayoutPanelImportExport.Name = "flowLayoutPanelImportExport";
            flowLayoutPanelImportExport.Size = new Size(197, 74);
            flowLayoutPanelImportExport.TabIndex = 6;
            // 
            // buttonExportPDF
            // 
            buttonExportPDF.Cursor = Cursors.Hand;
            buttonExportPDF.Location = new Point(3, 3);
            buttonExportPDF.Name = "buttonExportPDF";
            buttonExportPDF.Size = new Size(191, 29);
            buttonExportPDF.TabIndex = 1;
            buttonExportPDF.Text = "Export Stránky PDF";
            buttonExportPDF.UseVisualStyleBackColor = true;
            buttonExportPDF.Click += buttonExportPDF_Click;
            // 
            // buttonInvoice
            // 
            buttonInvoice.Cursor = Cursors.Hand;
            buttonInvoice.Location = new Point(3, 38);
            buttonInvoice.Name = "buttonInvoice";
            buttonInvoice.Size = new Size(190, 29);
            buttonInvoice.TabIndex = 2;
            buttonInvoice.Text = "Faktura (vybrané)";
            buttonInvoice.UseVisualStyleBackColor = true;
            buttonInvoice.Click += buttonInvoice_Click;
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
            // dataGridViewOrders
            // 
            dataGridViewOrders.BackgroundColor = SystemColors.Window;
            dataGridViewOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrders.Dock = DockStyle.Fill;
            dataGridViewOrders.GridColor = SystemColors.Window;
            dataGridViewOrders.Location = new Point(3, 48);
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.RowHeadersWidth = 51;
            dataGridViewOrders.Size = new Size(803, 342);
            dataGridViewOrders.TabIndex = 1;
            // 
            // pGCHeaderOrders
            // 
            pGCHeaderOrders.Controls.Add(flowLayoutPanelSearch);
            pGCHeaderOrders.Controls.Add(fLPButtons);
            pGCHeaderOrders.Dock = DockStyle.Top;
            pGCHeaderOrders.Location = new Point(3, 3);
            pGCHeaderOrders.Name = "pGCHeaderOrders";
            pGCHeaderOrders.Size = new Size(803, 39);
            pGCHeaderOrders.TabIndex = 0;
            // 
            // flowLayoutPanelSearch
            // 
            flowLayoutPanelSearch.Controls.Add(cBoxStatus);
            flowLayoutPanelSearch.Controls.Add(cBoxSearch);
            flowLayoutPanelSearch.Controls.Add(textBoxSearch);
            flowLayoutPanelSearch.Dock = DockStyle.Right;
            flowLayoutPanelSearch.Location = new Point(219, 0);
            flowLayoutPanelSearch.Name = "flowLayoutPanelSearch";
            flowLayoutPanelSearch.Size = new Size(584, 39);
            flowLayoutPanelSearch.TabIndex = 4;
            // 
            // cBoxStatus
            // 
            cBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxStatus.Font = new Font("Segoe UI", 10F);
            cBoxStatus.FormattingEnabled = true;
            cBoxStatus.Location = new Point(3, 3);
            cBoxStatus.Name = "cBoxStatus";
            cBoxStatus.Size = new Size(140, 31);
            cBoxStatus.TabIndex = 3;
            // 
            // cBoxSearch
            // 
            cBoxSearch.DropDownHeight = 200;
            cBoxSearch.Font = new Font("Segoe UI", 10F);
            cBoxSearch.FormattingEnabled = true;
            cBoxSearch.IntegralHeight = false;
            cBoxSearch.ItemHeight = 23;
            cBoxSearch.Location = new Point(149, 3);
            cBoxSearch.Name = "cBoxSearch";
            cBoxSearch.Size = new Size(161, 31);
            cBoxSearch.TabIndex = 1;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Dock = DockStyle.Right;
            textBoxSearch.Font = new Font("Segoe UI", 10F);
            textBoxSearch.Location = new Point(316, 3);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(264, 30);
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
            // tabPageContrMain
            // 
            tabPageContrMain.Controls.Add(tabPageOrders);
            tabPageContrMain.Controls.Add(tabPageOrderItems);
            tabPageContrMain.Controls.Add(tabPageOrdersSummary);
            tabPageContrMain.Controls.Add(tabPageInvoice);
            tabPageContrMain.Dock = DockStyle.Fill;
            tabPageContrMain.Location = new Point(0, 0);
            tabPageContrMain.Name = "tabPageContrMain";
            tabPageContrMain.SelectedIndex = 0;
            tabPageContrMain.Size = new Size(823, 512);
            tabPageContrMain.TabIndex = 1;
            tabPageContrMain.SelectedIndexChanged += tabControlOrders_SelectedIndexChanged;
            // 
            // ModOrdersMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabPageContrMain);
            Name = "ModOrdersMain";
            Size = new Size(823, 512);
            tabPageInvoice.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInvoice).EndInit();
            panel2.ResumeLayout(false);
            flowLayoutPanel5.ResumeLayout(false);
            tabPageOrdersSummary.ResumeLayout(false);
            panelChart.ResumeLayout(false);
            tabPageOrderItems.ResumeLayout(false);
            tableLayoutPanelOrderItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUp).EndInit();
            buttonsGridUp.ResumeLayout(false);
            flowLayoutPanelButtonsUp.ResumeLayout(false);
            paginationGridUp.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            buttonsGridDown.ResumeLayout(false);
            flowLayoutPanelButtonsDown.ResumeLayout(false);
            tabPageOrders.ResumeLayout(false);
            tableLayoutPanelOrders.ResumeLayout(false);
            pGCOrders.ResumeLayout(false);
            flowLayoutPanelImportExport.ResumeLayout(false);
            fLPPagination.ResumeLayout(false);
            fLPPagination.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
            pGCHeaderOrders.ResumeLayout(false);
            flowLayoutPanelSearch.ResumeLayout(false);
            flowLayoutPanelSearch.PerformLayout();
            fLPButtons.ResumeLayout(false);
            tabPageContrMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabPageInvoice;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button btnFirst_Inv;
        private Button btnPrev_Inv;
        private Label lblCurrentPage_Inv;
        private Button btnNext_Inv;
        private Button btnLast_Inv;
        private Label label2;
        private ComboBox cBoxPerPage_Inv;
        private DataGridView dataGridViewInvoice;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel5;
        private Button btnRefresh_Inv;
        private TabPage tabPageOrdersSummary;
        private Panel panelChart;
        private ScottPlot.WinForms.FormsPlot formsPlot;
        private TabPage tabPageOrderItems;
        private TableLayoutPanel tableLayoutPanelOrderItems;
        private DataGridView dataGridViewDown;
        private DataGridView dataGridViewUp;
        private Panel buttonsGridUp;
        private FlowLayoutPanel flowLayoutPanelUp;
        private FlowLayoutPanel flowLayoutPanelButtonsUp;
        private Button btnRefreshU;
        private Panel paginationGridUp;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnFirstU;
        private Button btnPrevU;
        private Label lblCurrentPageU;
        private Button btnNextU;
        private Button btnLastU;
        private Label lblPageNumU;
        private ComboBox cBoxPerPageU;
        private Panel buttonsGridDown;
        private FlowLayoutPanel flowLayoutPanelDown;
        private FlowLayoutPanel flowLayoutPanelButtonsDown;
        private Button btnRefreshD;
        private Button btnEditD;
        private TabPage tabPageOrders;
        private TableLayoutPanel tableLayoutPanelOrders;
        private Panel pGCOrders;
        private FlowLayoutPanel flowLayoutPanelImportExport;
        private Button buttonExportPDF;
        private Button buttonInvoice;
        private FlowLayoutPanel fLPPagination;
        private Button btnFirst;
        private Button btnPrev;
        private Label lblCurrentPage;
        private Button btnNext;
        private Button btnLast;
        private Label lblPageNum;
        private ComboBox cBoxPerPage;
        private DataGridView dataGridViewOrders;
        private Panel pGCHeaderOrders;
        private FlowLayoutPanel flowLayoutPanelSearch;
        private ComboBox cBoxStatus;
        private ComboBox cBoxSearch;
        private TextBox textBoxSearch;
        private FlowLayoutPanel fLPButtons;
        private Button btnRefresh;
        private Button btnCreate;
        private Button btnEdit;
        private Button btnDelete;
        private TabControl tabPageContrMain;
    }
}
