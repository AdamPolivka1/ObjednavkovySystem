namespace Orderis.UserControls.Mod.Orders
{
    partial class ModOrdersDelivery
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
            tabControl1 = new TabControl();
            tabPageOrders = new TabPage();
            tableLayoutPanelOrders = new TableLayoutPanel();
            pGCOrders = new Panel();
            flowLayoutPanelImportExport = new FlowLayoutPanel();
            fLPPagination = new FlowLayoutPanel();
            btnFirst = new Button();
            btnPrev = new Button();
            lblCurrentPage = new Label();
            btnNext = new Button();
            btnLast = new Button();
            lblPageNum = new Label();
            cBoxPerPage = new ComboBox();
            dataGridViewDeliveries = new DataGridView();
            pGCHeaderOrders = new Panel();
            flowLayoutPanelSearch = new FlowLayoutPanel();
            cBoxStatus = new ComboBox();
            fLPButtons = new FlowLayoutPanel();
            btnRefresh = new Button();
            btnCreate = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            tabControl1.SuspendLayout();
            tabPageOrders.SuspendLayout();
            tableLayoutPanelOrders.SuspendLayout();
            pGCOrders.SuspendLayout();
            fLPPagination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDeliveries).BeginInit();
            pGCHeaderOrders.SuspendLayout();
            flowLayoutPanelSearch.SuspendLayout();
            fLPButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageOrders);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(795, 559);
            tabControl1.TabIndex = 0;
            // 
            // tabPageOrders
            // 
            tabPageOrders.Controls.Add(tableLayoutPanelOrders);
            tabPageOrders.Location = new Point(4, 29);
            tabPageOrders.Name = "tabPageOrders";
            tabPageOrders.Padding = new Padding(3);
            tabPageOrders.Size = new Size(787, 526);
            tabPageOrders.TabIndex = 1;
            tabPageOrders.Text = "Doprava k objednávkám";
            tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelOrders
            // 
            tableLayoutPanelOrders.ColumnCount = 1;
            tableLayoutPanelOrders.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelOrders.Controls.Add(pGCOrders, 0, 1);
            tableLayoutPanelOrders.Controls.Add(dataGridViewDeliveries, 1, 0);
            tableLayoutPanelOrders.Controls.Add(pGCHeaderOrders, 0, 0);
            tableLayoutPanelOrders.Dock = DockStyle.Fill;
            tableLayoutPanelOrders.Location = new Point(3, 3);
            tableLayoutPanelOrders.Name = "tableLayoutPanelOrders";
            tableLayoutPanelOrders.RowCount = 3;
            tableLayoutPanelOrders.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanelOrders.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelOrders.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanelOrders.Size = new Size(781, 520);
            tableLayoutPanelOrders.TabIndex = 1;
            // 
            // pGCOrders
            // 
            pGCOrders.Controls.Add(flowLayoutPanelImportExport);
            pGCOrders.Controls.Add(fLPPagination);
            pGCOrders.Dock = DockStyle.Bottom;
            pGCOrders.Location = new Point(3, 443);
            pGCOrders.Name = "pGCOrders";
            pGCOrders.Size = new Size(775, 74);
            pGCOrders.TabIndex = 2;
            // 
            // flowLayoutPanelImportExport
            // 
            flowLayoutPanelImportExport.Dock = DockStyle.Right;
            flowLayoutPanelImportExport.Location = new Point(578, 0);
            flowLayoutPanelImportExport.Name = "flowLayoutPanelImportExport";
            flowLayoutPanelImportExport.Size = new Size(197, 74);
            flowLayoutPanelImportExport.TabIndex = 6;
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
            // dataGridViewDeliveries
            // 
            dataGridViewDeliveries.BackgroundColor = SystemColors.Window;
            dataGridViewDeliveries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDeliveries.Dock = DockStyle.Fill;
            dataGridViewDeliveries.GridColor = SystemColors.Window;
            dataGridViewDeliveries.Location = new Point(3, 48);
            dataGridViewDeliveries.Name = "dataGridViewDeliveries";
            dataGridViewDeliveries.RowHeadersWidth = 51;
            dataGridViewDeliveries.Size = new Size(775, 389);
            dataGridViewDeliveries.TabIndex = 1;
            // 
            // pGCHeaderOrders
            // 
            pGCHeaderOrders.Controls.Add(flowLayoutPanelSearch);
            pGCHeaderOrders.Controls.Add(fLPButtons);
            pGCHeaderOrders.Dock = DockStyle.Top;
            pGCHeaderOrders.Location = new Point(3, 3);
            pGCHeaderOrders.Name = "pGCHeaderOrders";
            pGCHeaderOrders.Size = new Size(775, 39);
            pGCHeaderOrders.TabIndex = 0;
            // 
            // flowLayoutPanelSearch
            // 
            flowLayoutPanelSearch.Controls.Add(cBoxStatus);
            flowLayoutPanelSearch.Dock = DockStyle.Right;
            flowLayoutPanelSearch.Location = new Point(191, 0);
            flowLayoutPanelSearch.Name = "flowLayoutPanelSearch";
            flowLayoutPanelSearch.Size = new Size(584, 39);
            flowLayoutPanelSearch.TabIndex = 4;
            // 
            // cBoxStatus
            // 
            cBoxStatus.Dock = DockStyle.Left;
            cBoxStatus.DropDownHeight = 200;
            cBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxStatus.Font = new Font("Segoe UI", 10F);
            cBoxStatus.FormattingEnabled = true;
            cBoxStatus.IntegralHeight = false;
            cBoxStatus.ItemHeight = 23;
            cBoxStatus.Location = new Point(3, 3);
            cBoxStatus.Name = "cBoxStatus";
            cBoxStatus.Size = new Size(151, 31);
            cBoxStatus.TabIndex = 1;
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
            // ModOrdersDelivery
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Name = "ModOrdersDelivery";
            Size = new Size(795, 559);
            tabControl1.ResumeLayout(false);
            tabPageOrders.ResumeLayout(false);
            tableLayoutPanelOrders.ResumeLayout(false);
            pGCOrders.ResumeLayout(false);
            fLPPagination.ResumeLayout(false);
            fLPPagination.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDeliveries).EndInit();
            pGCHeaderOrders.ResumeLayout(false);
            flowLayoutPanelSearch.ResumeLayout(false);
            fLPButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageOrders;
        private TableLayoutPanel tableLayoutPanelOrders;
        private Panel pGCOrders;
        private FlowLayoutPanel flowLayoutPanelImportExport;
        private FlowLayoutPanel fLPPagination;
        private Button btnFirst;
        private Button btnPrev;
        private Label lblCurrentPage;
        private Button btnNext;
        private Button btnLast;
        private Label lblPageNum;
        private ComboBox cBoxPerPage;
        private DataGridView dataGridViewDeliveries;
        private Panel pGCHeaderOrders;
        private FlowLayoutPanel flowLayoutPanelSearch;
        private ComboBox cBoxStatus;
        private FlowLayoutPanel fLPButtons;
        private Button btnRefresh;
        private Button btnCreate;
        private Button btnEdit;
        private Button btnDelete;
    }
}
