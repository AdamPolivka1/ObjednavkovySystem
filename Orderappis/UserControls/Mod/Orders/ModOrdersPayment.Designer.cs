namespace Orderis.UserControls.Mod.Orders
{
    partial class ModOrdersPayment
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
            tabControlPayment = new TabControl();
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
            dataGridViewPayments = new DataGridView();
            pGCHeaderOrders = new Panel();
            flowLayoutPanelSearch = new FlowLayoutPanel();
            cBoxPaymentMethod = new ComboBox();
            fLPButtons = new FlowLayoutPanel();
            btnRefresh = new Button();
            btnCreate = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            tabControlPayment.SuspendLayout();
            tabPageOrders.SuspendLayout();
            tableLayoutPanelOrders.SuspendLayout();
            pGCOrders.SuspendLayout();
            fLPPagination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPayments).BeginInit();
            pGCHeaderOrders.SuspendLayout();
            flowLayoutPanelSearch.SuspendLayout();
            fLPButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlPayment
            // 
            tabControlPayment.Controls.Add(tabPageOrders);
            tabControlPayment.Dock = DockStyle.Fill;
            tabControlPayment.Location = new Point(0, 0);
            tabControlPayment.Name = "tabControlPayment";
            tabControlPayment.SelectedIndex = 0;
            tabControlPayment.Size = new Size(799, 539);
            tabControlPayment.TabIndex = 0;
            // 
            // tabPageOrders
            // 
            tabPageOrders.Controls.Add(tableLayoutPanelOrders);
            tabPageOrders.Location = new Point(4, 29);
            tabPageOrders.Name = "tabPageOrders";
            tabPageOrders.Padding = new Padding(3);
            tabPageOrders.Size = new Size(791, 506);
            tabPageOrders.TabIndex = 1;
            tabPageOrders.Text = "Přehled plateb";
            tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelOrders
            // 
            tableLayoutPanelOrders.ColumnCount = 1;
            tableLayoutPanelOrders.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelOrders.Controls.Add(pGCOrders, 0, 1);
            tableLayoutPanelOrders.Controls.Add(dataGridViewPayments, 1, 0);
            tableLayoutPanelOrders.Controls.Add(pGCHeaderOrders, 0, 0);
            tableLayoutPanelOrders.Dock = DockStyle.Fill;
            tableLayoutPanelOrders.Location = new Point(3, 3);
            tableLayoutPanelOrders.Name = "tableLayoutPanelOrders";
            tableLayoutPanelOrders.RowCount = 3;
            tableLayoutPanelOrders.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanelOrders.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelOrders.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanelOrders.Size = new Size(785, 500);
            tableLayoutPanelOrders.TabIndex = 1;
            // 
            // pGCOrders
            // 
            pGCOrders.Controls.Add(flowLayoutPanelImportExport);
            pGCOrders.Controls.Add(fLPPagination);
            pGCOrders.Dock = DockStyle.Bottom;
            pGCOrders.Location = new Point(3, 423);
            pGCOrders.Name = "pGCOrders";
            pGCOrders.Size = new Size(779, 74);
            pGCOrders.TabIndex = 2;
            // 
            // flowLayoutPanelImportExport
            // 
            flowLayoutPanelImportExport.Dock = DockStyle.Right;
            flowLayoutPanelImportExport.Location = new Point(582, 0);
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
            // dataGridViewPayments
            // 
            dataGridViewPayments.BackgroundColor = SystemColors.Window;
            dataGridViewPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPayments.Dock = DockStyle.Fill;
            dataGridViewPayments.GridColor = SystemColors.Window;
            dataGridViewPayments.Location = new Point(3, 48);
            dataGridViewPayments.Name = "dataGridViewPayments";
            dataGridViewPayments.RowHeadersWidth = 51;
            dataGridViewPayments.Size = new Size(779, 369);
            dataGridViewPayments.TabIndex = 1;
            // 
            // pGCHeaderOrders
            // 
            pGCHeaderOrders.Controls.Add(flowLayoutPanelSearch);
            pGCHeaderOrders.Controls.Add(fLPButtons);
            pGCHeaderOrders.Dock = DockStyle.Top;
            pGCHeaderOrders.Location = new Point(3, 3);
            pGCHeaderOrders.Name = "pGCHeaderOrders";
            pGCHeaderOrders.Size = new Size(779, 39);
            pGCHeaderOrders.TabIndex = 0;
            // 
            // flowLayoutPanelSearch
            // 
            flowLayoutPanelSearch.Controls.Add(cBoxPaymentMethod);
            flowLayoutPanelSearch.Dock = DockStyle.Right;
            flowLayoutPanelSearch.Location = new Point(195, 0);
            flowLayoutPanelSearch.Name = "flowLayoutPanelSearch";
            flowLayoutPanelSearch.Size = new Size(584, 39);
            flowLayoutPanelSearch.TabIndex = 4;
            // 
            // cBoxPaymentMethod
            // 
            cBoxPaymentMethod.DropDownHeight = 200;
            cBoxPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxPaymentMethod.Font = new Font("Segoe UI", 10F);
            cBoxPaymentMethod.FormattingEnabled = true;
            cBoxPaymentMethod.IntegralHeight = false;
            cBoxPaymentMethod.ItemHeight = 23;
            cBoxPaymentMethod.Location = new Point(3, 3);
            cBoxPaymentMethod.Name = "cBoxPaymentMethod";
            cBoxPaymentMethod.Size = new Size(151, 31);
            cBoxPaymentMethod.TabIndex = 1;
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
            btnEdit.TabIndex = 4;
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
            // ModOrdersPayment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControlPayment);
            Name = "ModOrdersPayment";
            Size = new Size(799, 539);
            tabControlPayment.ResumeLayout(false);
            tabPageOrders.ResumeLayout(false);
            tableLayoutPanelOrders.ResumeLayout(false);
            pGCOrders.ResumeLayout(false);
            fLPPagination.ResumeLayout(false);
            fLPPagination.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPayments).EndInit();
            pGCHeaderOrders.ResumeLayout(false);
            flowLayoutPanelSearch.ResumeLayout(false);
            fLPButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlPayment;
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
        private DataGridView dataGridViewPayments;
        private Panel pGCHeaderOrders;
        private FlowLayoutPanel flowLayoutPanelSearch;
        private ComboBox cBoxPaymentMethod;
        private FlowLayoutPanel fLPButtons;
        private Button btnRefresh;
        private Button btnCreate;
        private Button btnDelete;
        private Button btnEdit;
    }
}
