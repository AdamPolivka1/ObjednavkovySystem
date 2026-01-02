
namespace Orderappis.UserControls.Mod.Orders.dlg
{
    partial class dlgOrderItems
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
            groupBoxOrderItems = new GroupBox();
            fLPPagination = new FlowLayoutPanel();
            btnFirst = new Button();
            btnPrev = new Button();
            lblCurrentPage = new Label();
            btnNext = new Button();
            btnLast = new Button();
            dataGridViewOrderItems = new DataGridView();
            dataGridViewSource = new DataGridView();
            labelOrderItems = new Label();
            groupBoxOrderItemsProps = new GroupBox();
            buttonClose = new Button();
            numericUpDownQty = new NumericUpDown();
            textBoxNote = new TextBox();
            labelNote = new Label();
            labelQty = new Label();
            buttonSave = new Button();
            buttonRemoveOrderItem = new Button();
            buttonAddOrderItem = new Button();
            label1 = new Label();
            groupBoxOrderItems.SuspendLayout();
            fLPPagination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrderItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSource).BeginInit();
            groupBoxOrderItemsProps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQty).BeginInit();
            SuspendLayout();
            // 
            // groupBoxOrderItems
            // 
            groupBoxOrderItems.Controls.Add(fLPPagination);
            groupBoxOrderItems.Controls.Add(dataGridViewOrderItems);
            groupBoxOrderItems.Controls.Add(dataGridViewSource);
            groupBoxOrderItems.Controls.Add(labelOrderItems);
            groupBoxOrderItems.Controls.Add(groupBoxOrderItemsProps);
            groupBoxOrderItems.Controls.Add(buttonRemoveOrderItem);
            groupBoxOrderItems.Controls.Add(buttonAddOrderItem);
            groupBoxOrderItems.Controls.Add(label1);
            groupBoxOrderItems.Location = new Point(3, 3);
            groupBoxOrderItems.Name = "groupBoxOrderItems";
            groupBoxOrderItems.Size = new Size(1033, 384);
            groupBoxOrderItems.TabIndex = 0;
            groupBoxOrderItems.TabStop = false;
            groupBoxOrderItems.Text = "Položky objednávky";
            // 
            // fLPPagination
            // 
            fLPPagination.Controls.Add(btnFirst);
            fLPPagination.Controls.Add(btnPrev);
            fLPPagination.Controls.Add(lblCurrentPage);
            fLPPagination.Controls.Add(btnNext);
            fLPPagination.Controls.Add(btnLast);
            fLPPagination.Location = new Point(6, 202);
            fLPPagination.Name = "fLPPagination";
            fLPPagination.Size = new Size(211, 40);
            fLPPagination.TabIndex = 10;
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
            btnFirst.Click += btnPagClick;
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
            btnPrev.Click += btnPagClick;
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
            btnNext.Click += btnPagClick;
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
            btnLast.Click += btnPagClick;
            // 
            // dataGridViewOrderItems
            // 
            dataGridViewOrderItems.BackgroundColor = SystemColors.Window;
            dataGridViewOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrderItems.Location = new Point(685, 57);
            dataGridViewOrderItems.Name = "dataGridViewOrderItems";
            dataGridViewOrderItems.RowHeadersWidth = 51;
            dataGridViewOrderItems.Size = new Size(342, 321);
            dataGridViewOrderItems.TabIndex = 9;
            // 
            // dataGridViewSource
            // 
            dataGridViewSource.BackgroundColor = SystemColors.Window;
            dataGridViewSource.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSource.Location = new Point(6, 57);
            dataGridViewSource.Name = "dataGridViewSource";
            dataGridViewSource.RowHeadersWidth = 51;
            dataGridViewSource.Size = new Size(630, 139);
            dataGridViewSource.TabIndex = 8;
            // 
            // labelOrderItems
            // 
            labelOrderItems.AutoSize = true;
            labelOrderItems.Location = new Point(685, 34);
            labelOrderItems.Name = "labelOrderItems";
            labelOrderItems.Size = new Size(139, 20);
            labelOrderItems.TabIndex = 7;
            labelOrderItems.Text = "Položky objednávky";
            // 
            // groupBoxOrderItemsProps
            // 
            groupBoxOrderItemsProps.Controls.Add(buttonClose);
            groupBoxOrderItemsProps.Controls.Add(numericUpDownQty);
            groupBoxOrderItemsProps.Controls.Add(textBoxNote);
            groupBoxOrderItemsProps.Controls.Add(labelNote);
            groupBoxOrderItemsProps.Controls.Add(labelQty);
            groupBoxOrderItemsProps.Controls.Add(buttonSave);
            groupBoxOrderItemsProps.Location = new Point(6, 248);
            groupBoxOrderItemsProps.Name = "groupBoxOrderItemsProps";
            groupBoxOrderItemsProps.Size = new Size(673, 130);
            groupBoxOrderItemsProps.TabIndex = 6;
            groupBoxOrderItemsProps.TabStop = false;
            groupBoxOrderItemsProps.Text = "Vlastnosti";
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(565, 95);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(94, 29);
            buttonClose.TabIndex = 5;
            buttonClose.Text = "Zavřít";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // numericUpDownQty
            // 
            numericUpDownQty.Location = new Point(108, 23);
            numericUpDownQty.Name = "numericUpDownQty";
            numericUpDownQty.Size = new Size(150, 27);
            numericUpDownQty.TabIndex = 4;
            numericUpDownQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // textBoxNote
            // 
            textBoxNote.Location = new Point(108, 60);
            textBoxNote.Multiline = true;
            textBoxNote.Name = "textBoxNote";
            textBoxNote.Size = new Size(451, 64);
            textBoxNote.TabIndex = 3;
            // 
            // labelNote
            // 
            labelNote.AutoSize = true;
            labelNote.Location = new Point(13, 60);
            labelNote.Name = "labelNote";
            labelNote.Size = new Size(79, 20);
            labelNote.TabIndex = 2;
            labelNote.Text = "Poznámka:";
            // 
            // labelQty
            // 
            labelQty.AutoSize = true;
            labelQty.Location = new Point(11, 23);
            labelQty.Name = "labelQty";
            labelQty.Size = new Size(81, 20);
            labelQty.TabIndex = 1;
            labelQty.Text = "Počet kusů:";
            // 
            // buttonSave
            // 
            buttonSave.Cursor = Cursors.Hand;
            buttonSave.Location = new Point(565, 60);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Propsat";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonRemoveOrderItem
            // 
            buttonRemoveOrderItem.Cursor = Cursors.Hand;
            buttonRemoveOrderItem.Location = new Point(642, 126);
            buttonRemoveOrderItem.Name = "buttonRemoveOrderItem";
            buttonRemoveOrderItem.Size = new Size(37, 29);
            buttonRemoveOrderItem.TabIndex = 5;
            buttonRemoveOrderItem.UseVisualStyleBackColor = true;
            buttonRemoveOrderItem.Click += buttonRemoveOrderItem_Click;
            // 
            // buttonAddOrderItem
            // 
            buttonAddOrderItem.Cursor = Cursors.Hand;
            buttonAddOrderItem.Location = new Point(642, 91);
            buttonAddOrderItem.Name = "buttonAddOrderItem";
            buttonAddOrderItem.Size = new Size(37, 29);
            buttonAddOrderItem.TabIndex = 4;
            buttonAddOrderItem.Text = ">>";
            buttonAddOrderItem.UseVisualStyleBackColor = true;
            buttonAddOrderItem.Click += buttonAddOrderItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 34);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 2;
            label1.Text = "Seznam Produktů";
            // 
            // dlgOrderItems
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxOrderItems);
            Name = "dlgOrderItems";
            Size = new Size(1042, 393);
            groupBoxOrderItems.ResumeLayout(false);
            groupBoxOrderItems.PerformLayout();
            fLPPagination.ResumeLayout(false);
            fLPPagination.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrderItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSource).EndInit();
            groupBoxOrderItemsProps.ResumeLayout(false);
            groupBoxOrderItemsProps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQty).EndInit();
            ResumeLayout(false);
        }

        private void btnPagClick(object sender, EventArgs e)
        {
            PaginationButton_Click(sender, e);
        }

        #endregion

        private GroupBox groupBoxOrderItems;
        private Button buttonSave;
        private Label label1;
        private Button buttonRemoveOrderItem;
        private Button buttonAddOrderItem;
        private GroupBox groupBoxOrderItemsProps;
        private Label labelQty;
        private Label labelNote;
        private TextBox textBoxNote;
        private NumericUpDown numericUpDownQty;
        private Label labelOrderItems;
        private DataGridView dataGridViewOrderItems;
        private DataGridView dataGridViewSource;
        private FlowLayoutPanel fLPPagination;
        private Button btnFirst;
        private Button btnPrev;
        private Label lblCurrentPage;
        private Button btnNext;
        private Button btnLast;
        private Button buttonClose;
    }
}
