namespace Orderis.UserControls.Mod.Products
{
    partial class ModProductsMain
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
            tabControlProducts = new TabControl();
            tabPageProducts = new TabPage();
            tableLayoutPanelProducts = new TableLayoutPanel();
            pGCUsers = new Panel();
            flowLayoutPanelImportExport = new FlowLayoutPanel();
            buttonImportCSV = new Button();
            buttonExportCSV = new Button();
            fLPPagination = new FlowLayoutPanel();
            btnFirst = new Button();
            btnPrev = new Button();
            lblCurrentPage = new Label();
            btnNext = new Button();
            btnLast = new Button();
            lblPageNum = new Label();
            cBoxPerPage = new ComboBox();
            dataGridViewProducts = new DataGridView();
            pGCHeaderUsers = new Panel();
            flowLayoutPanelSearch = new FlowLayoutPanel();
            cBoxSearch = new ComboBox();
            textBoxSearch = new TextBox();
            fLPButtons = new FlowLayoutPanel();
            btnRefresh = new Button();
            btnCreate = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            tabPageProductCategories = new TabPage();
            tableLayoutPanelCategories = new TableLayoutPanel();
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnFirstC = new Button();
            btnPrevC = new Button();
            lblCurrentPageC = new Label();
            btnNextC = new Button();
            btnLastC = new Button();
            lblPageNumC = new Label();
            cBoxPerPageC = new ComboBox();
            dataGridViewCategories = new DataGridView();
            panel2 = new Panel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            btnRefreshC = new Button();
            btnCreateC = new Button();
            btnEditC = new Button();
            btnDeleteC = new Button();
            tabControlProducts.SuspendLayout();
            tabPageProducts.SuspendLayout();
            tableLayoutPanelProducts.SuspendLayout();
            pGCUsers.SuspendLayout();
            flowLayoutPanelImportExport.SuspendLayout();
            fLPPagination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            pGCHeaderUsers.SuspendLayout();
            flowLayoutPanelSearch.SuspendLayout();
            fLPButtons.SuspendLayout();
            tabPageProductCategories.SuspendLayout();
            tableLayoutPanelCategories.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategories).BeginInit();
            panel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlProducts
            // 
            tabControlProducts.Controls.Add(tabPageProducts);
            tabControlProducts.Controls.Add(tabPageProductCategories);
            tabControlProducts.Dock = DockStyle.Fill;
            tabControlProducts.Location = new Point(0, 0);
            tabControlProducts.Name = "tabControlProducts";
            tabControlProducts.SelectedIndex = 0;
            tabControlProducts.Size = new Size(787, 582);
            tabControlProducts.TabIndex = 1;
            tabControlProducts.SelectedIndexChanged += tabControlProducts_SelectedIndexChanged;
            // 
            // tabPageProducts
            // 
            tabPageProducts.Controls.Add(tableLayoutPanelProducts);
            tabPageProducts.Cursor = Cursors.Hand;
            tabPageProducts.Location = new Point(4, 29);
            tabPageProducts.Name = "tabPageProducts";
            tabPageProducts.Padding = new Padding(3);
            tabPageProducts.Size = new Size(779, 549);
            tabPageProducts.TabIndex = 1;
            tabPageProducts.Text = "Produkty";
            tabPageProducts.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelProducts
            // 
            tableLayoutPanelProducts.ColumnCount = 1;
            tableLayoutPanelProducts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelProducts.Controls.Add(pGCUsers, 0, 1);
            tableLayoutPanelProducts.Controls.Add(dataGridViewProducts, 1, 0);
            tableLayoutPanelProducts.Controls.Add(pGCHeaderUsers, 0, 0);
            tableLayoutPanelProducts.Dock = DockStyle.Fill;
            tableLayoutPanelProducts.Location = new Point(3, 3);
            tableLayoutPanelProducts.Name = "tableLayoutPanelProducts";
            tableLayoutPanelProducts.RowCount = 3;
            tableLayoutPanelProducts.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanelProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelProducts.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanelProducts.Size = new Size(773, 543);
            tableLayoutPanelProducts.TabIndex = 0;
            // 
            // pGCUsers
            // 
            pGCUsers.Controls.Add(flowLayoutPanelImportExport);
            pGCUsers.Controls.Add(fLPPagination);
            pGCUsers.Dock = DockStyle.Bottom;
            pGCUsers.Location = new Point(3, 466);
            pGCUsers.Name = "pGCUsers";
            pGCUsers.Size = new Size(767, 74);
            pGCUsers.TabIndex = 2;
            // 
            // flowLayoutPanelImportExport
            // 
            flowLayoutPanelImportExport.Controls.Add(buttonImportCSV);
            flowLayoutPanelImportExport.Controls.Add(buttonExportCSV);
            flowLayoutPanelImportExport.Dock = DockStyle.Right;
            flowLayoutPanelImportExport.Location = new Point(570, 0);
            flowLayoutPanelImportExport.Name = "flowLayoutPanelImportExport";
            flowLayoutPanelImportExport.Size = new Size(197, 74);
            flowLayoutPanelImportExport.TabIndex = 6;
            // 
            // buttonImportCSV
            // 
            buttonImportCSV.Cursor = Cursors.Hand;
            buttonImportCSV.Location = new Point(3, 3);
            buttonImportCSV.Name = "buttonImportCSV";
            buttonImportCSV.Size = new Size(191, 29);
            buttonImportCSV.TabIndex = 0;
            buttonImportCSV.Text = "Import CSV";
            buttonImportCSV.UseVisualStyleBackColor = true;
            buttonImportCSV.Click += buttonImportCSV_Click;
            // 
            // buttonExportCSV
            // 
            buttonExportCSV.Cursor = Cursors.Hand;
            buttonExportCSV.Location = new Point(3, 38);
            buttonExportCSV.Name = "buttonExportCSV";
            buttonExportCSV.Size = new Size(191, 29);
            buttonExportCSV.TabIndex = 1;
            buttonExportCSV.Text = "Export Stránky CSV";
            buttonExportCSV.UseVisualStyleBackColor = true;
            buttonExportCSV.Click += buttonExportCSV_Click;
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
            // dataGridViewProducts
            // 
            dataGridViewProducts.BackgroundColor = SystemColors.Window;
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.Dock = DockStyle.Fill;
            dataGridViewProducts.GridColor = SystemColors.Window;
            dataGridViewProducts.Location = new Point(3, 48);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.RowHeadersWidth = 51;
            dataGridViewProducts.Size = new Size(767, 412);
            dataGridViewProducts.TabIndex = 1;
            // 
            // pGCHeaderUsers
            // 
            pGCHeaderUsers.Controls.Add(flowLayoutPanelSearch);
            pGCHeaderUsers.Controls.Add(fLPButtons);
            pGCHeaderUsers.Dock = DockStyle.Top;
            pGCHeaderUsers.Location = new Point(3, 3);
            pGCHeaderUsers.Name = "pGCHeaderUsers";
            pGCHeaderUsers.Size = new Size(767, 39);
            pGCHeaderUsers.TabIndex = 0;
            // 
            // flowLayoutPanelSearch
            // 
            flowLayoutPanelSearch.Controls.Add(cBoxSearch);
            flowLayoutPanelSearch.Controls.Add(textBoxSearch);
            flowLayoutPanelSearch.Dock = DockStyle.Right;
            flowLayoutPanelSearch.Location = new Point(183, 0);
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
            // tabPageProductCategories
            // 
            tabPageProductCategories.Controls.Add(tableLayoutPanelCategories);
            tabPageProductCategories.Cursor = Cursors.Hand;
            tabPageProductCategories.Location = new Point(4, 29);
            tabPageProductCategories.Name = "tabPageProductCategories";
            tabPageProductCategories.Padding = new Padding(3);
            tabPageProductCategories.Size = new Size(779, 549);
            tabPageProductCategories.TabIndex = 2;
            tabPageProductCategories.Text = "Kategorie";
            tabPageProductCategories.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelCategories
            // 
            tableLayoutPanelCategories.ColumnCount = 1;
            tableLayoutPanelCategories.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelCategories.Controls.Add(panel1, 0, 1);
            tableLayoutPanelCategories.Controls.Add(dataGridViewCategories, 1, 0);
            tableLayoutPanelCategories.Controls.Add(panel2, 0, 0);
            tableLayoutPanelCategories.Dock = DockStyle.Fill;
            tableLayoutPanelCategories.Location = new Point(3, 3);
            tableLayoutPanelCategories.Name = "tableLayoutPanelCategories";
            tableLayoutPanelCategories.RowCount = 3;
            tableLayoutPanelCategories.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanelCategories.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelCategories.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanelCategories.Size = new Size(773, 543);
            tableLayoutPanelCategories.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(3, 466);
            panel1.Name = "panel1";
            panel1.Size = new Size(767, 74);
            panel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnFirstC);
            flowLayoutPanel1.Controls.Add(btnPrevC);
            flowLayoutPanel1.Controls.Add(lblCurrentPageC);
            flowLayoutPanel1.Controls.Add(btnNextC);
            flowLayoutPanel1.Controls.Add(btnLastC);
            flowLayoutPanel1.Controls.Add(lblPageNumC);
            flowLayoutPanel1.Controls.Add(cBoxPerPageC);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(211, 74);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // btnFirstC
            // 
            btnFirstC.Anchor = AnchorStyles.None;
            btnFirstC.Location = new Point(3, 3);
            btnFirstC.Name = "btnFirstC";
            btnFirstC.Size = new Size(40, 29);
            btnFirstC.TabIndex = 0;
            btnFirstC.Text = "<<";
            btnFirstC.UseVisualStyleBackColor = true;
            // 
            // btnPrevC
            // 
            btnPrevC.Anchor = AnchorStyles.None;
            btnPrevC.Location = new Point(49, 3);
            btnPrevC.Name = "btnPrevC";
            btnPrevC.Size = new Size(40, 29);
            btnPrevC.TabIndex = 1;
            btnPrevC.Text = "<";
            btnPrevC.UseVisualStyleBackColor = true;
            // 
            // lblCurrentPageC
            // 
            lblCurrentPageC.Anchor = AnchorStyles.None;
            lblCurrentPageC.AutoSize = true;
            lblCurrentPageC.Location = new Point(95, 7);
            lblCurrentPageC.Name = "lblCurrentPageC";
            lblCurrentPageC.Size = new Size(17, 20);
            lblCurrentPageC.TabIndex = 4;
            lblCurrentPageC.Text = "1";
            // 
            // btnNextC
            // 
            btnNextC.Anchor = AnchorStyles.None;
            btnNextC.Location = new Point(118, 3);
            btnNextC.Name = "btnNextC";
            btnNextC.Size = new Size(40, 29);
            btnNextC.TabIndex = 2;
            btnNextC.Text = ">";
            btnNextC.UseVisualStyleBackColor = true;
            // 
            // btnLastC
            // 
            btnLastC.Anchor = AnchorStyles.None;
            btnLastC.Location = new Point(164, 3);
            btnLastC.Name = "btnLastC";
            btnLastC.Size = new Size(40, 29);
            btnLastC.TabIndex = 3;
            btnLastC.Text = ">>";
            btnLastC.UseVisualStyleBackColor = true;
            // 
            // lblPageNumC
            // 
            lblPageNumC.AutoSize = true;
            lblPageNumC.Dock = DockStyle.Left;
            lblPageNumC.Font = new Font("Segoe UI", 9F);
            lblPageNumC.Location = new Point(3, 35);
            lblPageNumC.Name = "lblPageNumC";
            lblPageNumC.Size = new Size(138, 37);
            lblPageNumC.TabIndex = 5;
            lblPageNumC.Text = "Počet prvků stránky:";
            lblPageNumC.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cBoxPerPageC
            // 
            cBoxPerPageC.Font = new Font("Segoe UI", 10F);
            cBoxPerPageC.FormattingEnabled = true;
            cBoxPerPageC.Location = new Point(147, 38);
            cBoxPerPageC.Name = "cBoxPerPageC";
            cBoxPerPageC.Size = new Size(57, 31);
            cBoxPerPageC.TabIndex = 6;
            // 
            // dataGridViewCategories
            // 
            dataGridViewCategories.BackgroundColor = SystemColors.Window;
            dataGridViewCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCategories.Dock = DockStyle.Fill;
            dataGridViewCategories.GridColor = SystemColors.Window;
            dataGridViewCategories.Location = new Point(3, 48);
            dataGridViewCategories.Name = "dataGridViewCategories";
            dataGridViewCategories.RowHeadersWidth = 51;
            dataGridViewCategories.Size = new Size(767, 412);
            dataGridViewCategories.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(flowLayoutPanel3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(767, 39);
            panel2.TabIndex = 0;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(btnRefreshC);
            flowLayoutPanel3.Controls.Add(btnCreateC);
            flowLayoutPanel3.Controls.Add(btnEditC);
            flowLayoutPanel3.Controls.Add(btnDeleteC);
            flowLayoutPanel3.Dock = DockStyle.Left;
            flowLayoutPanel3.Location = new Point(0, 0);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(158, 39);
            flowLayoutPanel3.TabIndex = 0;
            // 
            // btnRefreshC
            // 
            btnRefreshC.Location = new Point(3, 3);
            btnRefreshC.Name = "btnRefreshC";
            btnRefreshC.Size = new Size(30, 30);
            btnRefreshC.TabIndex = 0;
            btnRefreshC.UseVisualStyleBackColor = true;
            // 
            // btnCreateC
            // 
            btnCreateC.Location = new Point(39, 3);
            btnCreateC.Name = "btnCreateC";
            btnCreateC.Size = new Size(30, 30);
            btnCreateC.TabIndex = 1;
            btnCreateC.UseVisualStyleBackColor = true;
            btnCreateC.Visible = false;
            // 
            // btnEditC
            // 
            btnEditC.Location = new Point(75, 3);
            btnEditC.Name = "btnEditC";
            btnEditC.Size = new Size(30, 30);
            btnEditC.TabIndex = 2;
            btnEditC.UseVisualStyleBackColor = true;
            btnEditC.Visible = false;
            // 
            // btnDeleteC
            // 
            btnDeleteC.Location = new Point(111, 3);
            btnDeleteC.Name = "btnDeleteC";
            btnDeleteC.Size = new Size(30, 30);
            btnDeleteC.TabIndex = 3;
            btnDeleteC.UseVisualStyleBackColor = true;
            btnDeleteC.Visible = false;
            // 
            // ModProductsMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControlProducts);
            Name = "ModProductsMain";
            Size = new Size(787, 582);
            tabControlProducts.ResumeLayout(false);
            tabPageProducts.ResumeLayout(false);
            tableLayoutPanelProducts.ResumeLayout(false);
            pGCUsers.ResumeLayout(false);
            flowLayoutPanelImportExport.ResumeLayout(false);
            fLPPagination.ResumeLayout(false);
            fLPPagination.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            pGCHeaderUsers.ResumeLayout(false);
            flowLayoutPanelSearch.ResumeLayout(false);
            flowLayoutPanelSearch.PerformLayout();
            fLPButtons.ResumeLayout(false);
            tabPageProductCategories.ResumeLayout(false);
            tableLayoutPanelCategories.ResumeLayout(false);
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategories).EndInit();
            panel2.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControlProducts;
        private TabPage tabPageProducts;
        private TableLayoutPanel tableLayoutPanelProducts;
        private Panel pGCUsers;
        private FlowLayoutPanel fLPPagination;
        private Button btnFirst;
        private Button btnPrev;
        private Label lblCurrentPage;
        private Button btnNext;
        private Button btnLast;
        private Label lblPageNum;
        private ComboBox cBoxPerPage;
        private DataGridView dataGridViewProducts;
        private Panel pGCHeaderUsers;
        private FlowLayoutPanel flowLayoutPanelSearch;
        private ComboBox cBoxSearch;
        private TextBox textBoxSearch;
        private FlowLayoutPanel fLPButtons;
        private Button btnRefresh;
        private Button btnCreate;
        private Button btnEdit;
        private Button btnDelete;
        private TabPage tabPageProductCategories;
        private TableLayoutPanel tableLayoutPanelCategories;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnFirstC;
        private Button btnPrevC;
        private Label lblCurrentPageC;
        private Button btnNextC;
        private Button btnLastC;
        private Label lblPageNumC;
        private ComboBox cBoxPerPageC;
        private DataGridView dataGridViewCategories;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button btnRefreshC;
        private Button btnCreateC;
        private Button btnEditC;
        private Button btnDeleteC;
        private FlowLayoutPanel flowLayoutPanelImportExport;
        private Button buttonImportCSV;
        private Button buttonExportCSV;
    }
}
