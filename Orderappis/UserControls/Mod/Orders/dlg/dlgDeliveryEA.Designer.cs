namespace Orderappis.UserControls.Mod.Orders.dlg
{
    partial class dlgDeliveryEA
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
            groupBoxDelivery = new GroupBox();
            textBoxOrderId = new TextBox();
            labelOrder = new Label();
            textBoxErrors = new TextBox();
            labelErrors = new Label();
            textBoxNote = new TextBox();
            labelNote = new Label();
            buttonSave = new Button();
            numericUpDownPrice = new NumericUpDown();
            labelPriceCZK = new Label();
            labelStatus = new Label();
            comboBoxStatus = new ComboBox();
            labelDeliveryAddress = new Label();
            textBoxAddress = new TextBox();
            dateTimePickerDeliveryDate = new DateTimePicker();
            labelDeliveryDate = new Label();
            labelDeliveryType = new Label();
            comboBoxDeliveryType = new ComboBox();
            groupBoxDelivery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            SuspendLayout();
            // 
            // groupBoxDelivery
            // 
            groupBoxDelivery.Controls.Add(textBoxOrderId);
            groupBoxDelivery.Controls.Add(labelOrder);
            groupBoxDelivery.Controls.Add(textBoxErrors);
            groupBoxDelivery.Controls.Add(labelErrors);
            groupBoxDelivery.Controls.Add(textBoxNote);
            groupBoxDelivery.Controls.Add(labelNote);
            groupBoxDelivery.Controls.Add(buttonSave);
            groupBoxDelivery.Controls.Add(numericUpDownPrice);
            groupBoxDelivery.Controls.Add(labelPriceCZK);
            groupBoxDelivery.Controls.Add(labelStatus);
            groupBoxDelivery.Controls.Add(comboBoxStatus);
            groupBoxDelivery.Controls.Add(labelDeliveryAddress);
            groupBoxDelivery.Controls.Add(textBoxAddress);
            groupBoxDelivery.Controls.Add(dateTimePickerDeliveryDate);
            groupBoxDelivery.Controls.Add(labelDeliveryDate);
            groupBoxDelivery.Controls.Add(labelDeliveryType);
            groupBoxDelivery.Controls.Add(comboBoxDeliveryType);
            groupBoxDelivery.Location = new Point(3, 3);
            groupBoxDelivery.Name = "groupBoxDelivery";
            groupBoxDelivery.Size = new Size(356, 619);
            groupBoxDelivery.TabIndex = 0;
            groupBoxDelivery.TabStop = false;
            groupBoxDelivery.Text = "Doručení";
            groupBoxDelivery.Enter += groupBox1_Enter;
            // 
            // textBoxOrderId
            // 
            textBoxOrderId.Location = new Point(117, 43);
            textBoxOrderId.Name = "textBoxOrderId";
            textBoxOrderId.Size = new Size(225, 27);
            textBoxOrderId.TabIndex = 18;
            // 
            // labelOrder
            // 
            labelOrder.AutoSize = true;
            labelOrder.Location = new Point(6, 43);
            labelOrder.Name = "labelOrder";
            labelOrder.Size = new Size(105, 20);
            labelOrder.TabIndex = 17;
            labelOrder.Text = "Id objednávky:";
            // 
            // textBoxErrors
            // 
            textBoxErrors.BackColor = SystemColors.Info;
            textBoxErrors.ForeColor = Color.Red;
            textBoxErrors.Location = new Point(84, 446);
            textBoxErrors.Multiline = true;
            textBoxErrors.Name = "textBoxErrors";
            textBoxErrors.Size = new Size(258, 132);
            textBoxErrors.TabIndex = 16;
            // 
            // labelErrors
            // 
            labelErrors.AutoSize = true;
            labelErrors.Location = new Point(6, 446);
            labelErrors.Name = "labelErrors";
            labelErrors.Size = new Size(37, 20);
            labelErrors.TabIndex = 15;
            labelErrors.Text = "Log:";
            // 
            // textBoxNote
            // 
            textBoxNote.Location = new Point(84, 363);
            textBoxNote.Multiline = true;
            textBoxNote.Name = "textBoxNote";
            textBoxNote.Size = new Size(258, 77);
            textBoxNote.TabIndex = 14;
            // 
            // labelNote
            // 
            labelNote.AutoSize = true;
            labelNote.Location = new Point(0, 366);
            labelNote.Name = "labelNote";
            labelNote.Size = new Size(79, 20);
            labelNote.TabIndex = 13;
            labelNote.Text = "Poznámka:";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(248, 584);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 12;
            buttonSave.Text = "Uložit";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // numericUpDownPrice
            // 
            numericUpDownPrice.DecimalPlaces = 2;
            numericUpDownPrice.Location = new Point(84, 314);
            numericUpDownPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new Size(258, 27);
            numericUpDownPrice.TabIndex = 9;
            // 
            // labelPriceCZK
            // 
            labelPriceCZK.AutoSize = true;
            labelPriceCZK.Location = new Point(6, 316);
            labelPriceCZK.Name = "labelPriceCZK";
            labelPriceCZK.Size = new Size(45, 20);
            labelPriceCZK.TabIndex = 8;
            labelPriceCZK.Text = "Cena:";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(6, 259);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(52, 20);
            labelStatus.TabIndex = 7;
            labelStatus.Text = "Status:";
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new Point(84, 256);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(258, 28);
            comboBoxStatus.TabIndex = 6;
            // 
            // labelDeliveryAddress
            // 
            labelDeliveryAddress.AutoSize = true;
            labelDeliveryAddress.Location = new Point(6, 167);
            labelDeliveryAddress.Name = "labelDeliveryAddress";
            labelDeliveryAddress.Size = new Size(58, 20);
            labelDeliveryAddress.TabIndex = 5;
            labelDeliveryAddress.Text = "Adresa:";
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(84, 164);
            textBoxAddress.Multiline = true;
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(258, 77);
            textBoxAddress.TabIndex = 4;
            // 
            // dateTimePickerDeliveryDate
            // 
            dateTimePickerDeliveryDate.Location = new Point(92, 126);
            dateTimePickerDeliveryDate.Name = "dateTimePickerDeliveryDate";
            dateTimePickerDeliveryDate.Size = new Size(250, 27);
            dateTimePickerDeliveryDate.TabIndex = 3;
            // 
            // labelDeliveryDate
            // 
            labelDeliveryDate.AutoSize = true;
            labelDeliveryDate.Location = new Point(6, 131);
            labelDeliveryDate.Name = "labelDeliveryDate";
            labelDeliveryDate.Size = new Size(72, 20);
            labelDeliveryDate.TabIndex = 2;
            labelDeliveryDate.Text = "Doručení:";
            // 
            // labelDeliveryType
            // 
            labelDeliveryType.AutoSize = true;
            labelDeliveryType.Location = new Point(6, 91);
            labelDeliveryType.Name = "labelDeliveryType";
            labelDeliveryType.Size = new Size(35, 20);
            labelDeliveryType.TabIndex = 1;
            labelDeliveryType.Text = "Typ:";
            // 
            // comboBoxDeliveryType
            // 
            comboBoxDeliveryType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDeliveryType.FormattingEnabled = true;
            comboBoxDeliveryType.Location = new Point(92, 88);
            comboBoxDeliveryType.Name = "comboBoxDeliveryType";
            comboBoxDeliveryType.Size = new Size(250, 28);
            comboBoxDeliveryType.TabIndex = 0;
            // 
            // dlgDeliveryEA
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxDelivery);
            Name = "dlgDeliveryEA";
            Size = new Size(365, 625);
            groupBoxDelivery.ResumeLayout(false);
            groupBoxDelivery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxDelivery;
        private ComboBox comboBoxDeliveryType;
        private Label labelDeliveryType;
        private Label labelDeliveryDate;
        private DateTimePicker dateTimePickerDeliveryDate;
        private TextBox textBoxAddress;
        private Label labelDeliveryAddress;
        private ComboBox comboBoxStatus;
        private Label labelStatus;
        private Label labelPriceCZK;
        private NumericUpDown numericUpDownPrice;
        private Button buttonSave;
        private Label labelNote;
        private TextBox textBoxNote;
        private Label labelErrors;
        private TextBox textBoxErrors;
        private Label labelOrder;
        private TextBox textBoxOrderId;
    }
}
