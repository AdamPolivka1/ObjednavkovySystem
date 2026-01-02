namespace Orderappis.UserControls.Mod.Products.dlg
{
    partial class dlgProductEA
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
            gbProductEA = new GroupBox();
            numericAvailableQty = new NumericUpDown();
            textBoxErrors = new TextBox();
            lblErrors = new Label();
            comboBoxProductCategory = new ComboBox();
            textBoxPrice = new TextBox();
            labelCenaCzk = new Label();
            textBoxDescr = new TextBox();
            labelDescr = new Label();
            buttonSave = new Button();
            labelName = new Label();
            labelCode = new Label();
            textBoxName = new TextBox();
            labelAvailableQty = new Label();
            textBoxCode = new TextBox();
            labelProductCategoryId = new Label();
            gbProductEA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericAvailableQty).BeginInit();
            SuspendLayout();
            // 
            // gbProductEA
            // 
            gbProductEA.Controls.Add(numericAvailableQty);
            gbProductEA.Controls.Add(textBoxErrors);
            gbProductEA.Controls.Add(lblErrors);
            gbProductEA.Controls.Add(comboBoxProductCategory);
            gbProductEA.Controls.Add(textBoxPrice);
            gbProductEA.Controls.Add(labelCenaCzk);
            gbProductEA.Controls.Add(textBoxDescr);
            gbProductEA.Controls.Add(labelDescr);
            gbProductEA.Controls.Add(buttonSave);
            gbProductEA.Controls.Add(labelName);
            gbProductEA.Controls.Add(labelCode);
            gbProductEA.Controls.Add(textBoxName);
            gbProductEA.Controls.Add(labelAvailableQty);
            gbProductEA.Controls.Add(textBoxCode);
            gbProductEA.Controls.Add(labelProductCategoryId);
            gbProductEA.Dock = DockStyle.Fill;
            gbProductEA.Location = new Point(0, 0);
            gbProductEA.Name = "gbProductEA";
            gbProductEA.Size = new Size(372, 470);
            gbProductEA.TabIndex = 1;
            gbProductEA.TabStop = false;
            gbProductEA.Text = "Produkt";
            // 
            // numericAvailableQty
            // 
            numericAvailableQty.Location = new Point(218, 63);
            numericAvailableQty.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numericAvailableQty.Name = "numericAvailableQty";
            numericAvailableQty.Size = new Size(125, 27);
            numericAvailableQty.TabIndex = 19;
            numericAvailableQty.ValueChanged += numericAvailableQty_ValueChanged;
            // 
            // textBoxErrors
            // 
            textBoxErrors.BackColor = SystemColors.Info;
            textBoxErrors.Font = new Font("Segoe UI", 10F);
            textBoxErrors.ForeColor = Color.Red;
            textBoxErrors.Location = new Point(55, 261);
            textBoxErrors.Multiline = true;
            textBoxErrors.Name = "textBoxErrors";
            textBoxErrors.ReadOnly = true;
            textBoxErrors.Size = new Size(288, 154);
            textBoxErrors.TabIndex = 18;
            // 
            // lblErrors
            // 
            lblErrors.AutoSize = true;
            lblErrors.Location = new Point(7, 266);
            lblErrors.Name = "lblErrors";
            lblErrors.Size = new Size(37, 20);
            lblErrors.TabIndex = 17;
            lblErrors.Text = "Log:";
            // 
            // comboBoxProductCategory
            // 
            comboBoxProductCategory.FormattingEnabled = true;
            comboBoxProductCategory.Location = new Point(218, 29);
            comboBoxProductCategory.Name = "comboBoxProductCategory";
            comboBoxProductCategory.Size = new Size(125, 28);
            comboBoxProductCategory.TabIndex = 1;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(85, 211);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(259, 27);
            textBoxPrice.TabIndex = 8;
            // 
            // labelCenaCzk
            // 
            labelCenaCzk.AutoSize = true;
            labelCenaCzk.Location = new Point(6, 214);
            labelCenaCzk.Name = "labelCenaCzk";
            labelCenaCzk.Size = new Size(70, 20);
            labelCenaCzk.TabIndex = 11;
            labelCenaCzk.Text = "Cena czk:";
            // 
            // textBoxDescr
            // 
            textBoxDescr.Location = new Point(86, 174);
            textBoxDescr.Name = "textBoxDescr";
            textBoxDescr.Size = new Size(258, 27);
            textBoxDescr.TabIndex = 7;
            // 
            // labelDescr
            // 
            labelDescr.AutoSize = true;
            labelDescr.Location = new Point(6, 177);
            labelDescr.Name = "labelDescr";
            labelDescr.Size = new Size(47, 20);
            labelDescr.TabIndex = 9;
            labelDescr.Text = "Popis:";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(249, 431);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 12;
            buttonSave.Text = "Uložit";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(7, 139);
            labelName.Name = "labelName";
            labelName.Size = new Size(53, 20);
            labelName.TabIndex = 6;
            labelName.Text = "Název:";
            // 
            // labelCode
            // 
            labelCode.AutoSize = true;
            labelCode.Location = new Point(6, 103);
            labelCode.Name = "labelCode";
            labelCode.Size = new Size(39, 20);
            labelCode.TabIndex = 4;
            labelCode.Text = "Kód:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(86, 136);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(258, 27);
            textBoxName.TabIndex = 6;
            // 
            // labelAvailableQty
            // 
            labelAvailableQty.AutoSize = true;
            labelAvailableQty.Location = new Point(7, 66);
            labelAvailableQty.Name = "labelAvailableQty";
            labelAvailableQty.Size = new Size(152, 20);
            labelAvailableQty.TabIndex = 2;
            labelAvailableQty.Text = "Dostupných jednotek:";
            // 
            // textBoxCode
            // 
            textBoxCode.Location = new Point(85, 100);
            textBoxCode.Name = "textBoxCode";
            textBoxCode.Size = new Size(258, 27);
            textBoxCode.TabIndex = 3;
            // 
            // labelProductCategoryId
            // 
            labelProductCategoryId.AutoSize = true;
            labelProductCategoryId.Location = new Point(6, 32);
            labelProductCategoryId.Name = "labelProductCategoryId";
            labelProductCategoryId.Size = new Size(141, 20);
            labelProductCategoryId.TabIndex = 0;
            labelProductCategoryId.Text = "Kategorie produktu:";
            // 
            // dlgProductEA
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gbProductEA);
            Name = "dlgProductEA";
            Size = new Size(372, 470);
            gbProductEA.ResumeLayout(false);
            gbProductEA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericAvailableQty).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbProductEA;
        private TextBox textBoxErrors;
        private Label lblErrors;
        private ComboBox comboBoxProductCategory;
        private TextBox textBoxPrice;
        private Label labelCenaCzk;
        private TextBox textBoxDescr;
        private Label labelDescr;
        private Button buttonSave;
        private Label labelName;
        private Label labelCode;
        private TextBox textBoxName;
        private Label labelAvailableQty;
        private TextBox textBoxCode;
        private Label labelProductCategoryId;
        private NumericUpDown numericAvailableQty;
    }
}
