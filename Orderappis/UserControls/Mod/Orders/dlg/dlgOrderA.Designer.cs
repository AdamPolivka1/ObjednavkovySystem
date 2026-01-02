namespace Orderappis.UserControls.Mod.Orders.dlg
{
    partial class dlgOrderA
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
            groupBoxOrder = new GroupBox();
            checkBoxCreateDelivery = new CheckBox();
            labelLog = new Label();
            textBoxErrors = new TextBox();
            btnSave = new Button();
            textBoxCustomerEmail = new TextBox();
            groupBoxDelivery = new GroupBox();
            labelDeliveryPrice = new Label();
            textBoxDeliveryAddress = new TextBox();
            labelDeliveryAddress = new Label();
            textBoxNote = new TextBox();
            labelNote = new Label();
            comboBoxDeliveryType = new ComboBox();
            labelDeliveryDate = new Label();
            dateTimePickerDeliveryDate = new DateTimePicker();
            labelType = new Label();
            labelOrderPrice = new Label();
            labelCustomer = new Label();
            numericUpDownDeliveryPrice = new NumericUpDown();
            numericUpDownOrderPrice = new NumericUpDown();
            groupBoxOrder.SuspendLayout();
            groupBoxDelivery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDeliveryPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOrderPrice).BeginInit();
            SuspendLayout();
            // 
            // groupBoxOrder
            // 
            groupBoxOrder.Controls.Add(numericUpDownOrderPrice);
            groupBoxOrder.Controls.Add(checkBoxCreateDelivery);
            groupBoxOrder.Controls.Add(labelLog);
            groupBoxOrder.Controls.Add(textBoxErrors);
            groupBoxOrder.Controls.Add(btnSave);
            groupBoxOrder.Controls.Add(textBoxCustomerEmail);
            groupBoxOrder.Controls.Add(groupBoxDelivery);
            groupBoxOrder.Controls.Add(labelOrderPrice);
            groupBoxOrder.Controls.Add(labelCustomer);
            groupBoxOrder.Location = new Point(3, 3);
            groupBoxOrder.Name = "groupBoxOrder";
            groupBoxOrder.Size = new Size(576, 517);
            groupBoxOrder.TabIndex = 0;
            groupBoxOrder.TabStop = false;
            groupBoxOrder.Text = "Objednávka";
            // 
            // checkBoxCreateDelivery
            // 
            checkBoxCreateDelivery.AutoSize = true;
            checkBoxCreateDelivery.Location = new Point(386, 100);
            checkBoxCreateDelivery.Name = "checkBoxCreateDelivery";
            checkBoxCreateDelivery.Size = new Size(175, 24);
            checkBoxCreateDelivery.TabIndex = 5;
            checkBoxCreateDelivery.Text = "Vytvořit i s doručením";
            checkBoxCreateDelivery.UseVisualStyleBackColor = true;
            checkBoxCreateDelivery.CheckedChanged += checkBoxCreateDelivery_CheckedChanged;
            // 
            // labelLog
            // 
            labelLog.AutoSize = true;
            labelLog.Location = new Point(6, 382);
            labelLog.Name = "labelLog";
            labelLog.Size = new Size(37, 20);
            labelLog.TabIndex = 17;
            labelLog.Text = "Log:";
            // 
            // textBoxErrors
            // 
            textBoxErrors.BackColor = SystemColors.Info;
            textBoxErrors.ForeColor = Color.Red;
            textBoxErrors.Location = new Point(6, 405);
            textBoxErrors.Multiline = true;
            textBoxErrors.Name = "textBoxErrors";
            textBoxErrors.Size = new Size(555, 70);
            textBoxErrors.TabIndex = 18;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(467, 481);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 19;
            btnSave.Text = "Uložit";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // textBoxCustomerEmail
            // 
            textBoxCustomerEmail.Location = new Point(6, 57);
            textBoxCustomerEmail.Name = "textBoxCustomerEmail";
            textBoxCustomerEmail.Size = new Size(256, 27);
            textBoxCustomerEmail.TabIndex = 2;
            // 
            // groupBoxDelivery
            // 
            groupBoxDelivery.Controls.Add(numericUpDownDeliveryPrice);
            groupBoxDelivery.Controls.Add(labelDeliveryPrice);
            groupBoxDelivery.Controls.Add(textBoxDeliveryAddress);
            groupBoxDelivery.Controls.Add(labelDeliveryAddress);
            groupBoxDelivery.Controls.Add(textBoxNote);
            groupBoxDelivery.Controls.Add(labelNote);
            groupBoxDelivery.Controls.Add(comboBoxDeliveryType);
            groupBoxDelivery.Controls.Add(labelDeliveryDate);
            groupBoxDelivery.Controls.Add(dateTimePickerDeliveryDate);
            groupBoxDelivery.Controls.Add(labelType);
            groupBoxDelivery.Enabled = false;
            groupBoxDelivery.Location = new Point(6, 117);
            groupBoxDelivery.Name = "groupBoxDelivery";
            groupBoxDelivery.Size = new Size(555, 258);
            groupBoxDelivery.TabIndex = 6;
            groupBoxDelivery.TabStop = false;
            groupBoxDelivery.Text = "Doprava";
            // 
            // labelDeliveryPrice
            // 
            labelDeliveryPrice.AutoSize = true;
            labelDeliveryPrice.Location = new Point(278, 50);
            labelDeliveryPrice.Name = "labelDeliveryPrice";
            labelDeliveryPrice.Size = new Size(154, 20);
            labelDeliveryPrice.TabIndex = 9;
            labelDeliveryPrice.Text = "Cena za doručení CZK";
            // 
            // textBoxDeliveryAddress
            // 
            textBoxDeliveryAddress.Location = new Point(6, 180);
            textBoxDeliveryAddress.Multiline = true;
            textBoxDeliveryAddress.Name = "textBoxDeliveryAddress";
            textBoxDeliveryAddress.Size = new Size(250, 66);
            textBoxDeliveryAddress.TabIndex = 14;
            // 
            // labelDeliveryAddress
            // 
            labelDeliveryAddress.AutoSize = true;
            labelDeliveryAddress.Location = new Point(5, 157);
            labelDeliveryAddress.Name = "labelDeliveryAddress";
            labelDeliveryAddress.Size = new Size(120, 20);
            labelDeliveryAddress.TabIndex = 13;
            labelDeliveryAddress.Text = "Adresa doručení:";
            // 
            // textBoxNote
            // 
            textBoxNote.Location = new Point(278, 134);
            textBoxNote.Multiline = true;
            textBoxNote.Name = "textBoxNote";
            textBoxNote.Size = new Size(250, 112);
            textBoxNote.TabIndex = 16;
            // 
            // labelNote
            // 
            labelNote.AutoSize = true;
            labelNote.Location = new Point(278, 111);
            labelNote.Name = "labelNote";
            labelNote.Size = new Size(79, 20);
            labelNote.TabIndex = 15;
            labelNote.Text = "Poznámka:";
            // 
            // comboBoxDeliveryType
            // 
            comboBoxDeliveryType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDeliveryType.FormattingEnabled = true;
            comboBoxDeliveryType.Location = new Point(6, 73);
            comboBoxDeliveryType.Name = "comboBoxDeliveryType";
            comboBoxDeliveryType.Size = new Size(250, 28);
            comboBoxDeliveryType.TabIndex = 8;
            // 
            // labelDeliveryDate
            // 
            labelDeliveryDate.AutoSize = true;
            labelDeliveryDate.Location = new Point(6, 104);
            labelDeliveryDate.Name = "labelDeliveryDate";
            labelDeliveryDate.Size = new Size(119, 20);
            labelDeliveryDate.TabIndex = 11;
            labelDeliveryDate.Text = "Datum doručení:";
            // 
            // dateTimePickerDeliveryDate
            // 
            dateTimePickerDeliveryDate.Location = new Point(6, 127);
            dateTimePickerDeliveryDate.Name = "dateTimePickerDeliveryDate";
            dateTimePickerDeliveryDate.Size = new Size(250, 27);
            dateTimePickerDeliveryDate.TabIndex = 12;
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Location = new Point(6, 50);
            labelType.Name = "labelType";
            labelType.Size = new Size(44, 20);
            labelType.TabIndex = 7;
            labelType.Text = "Druh:";
            // 
            // labelOrderPrice
            // 
            labelOrderPrice.AutoSize = true;
            labelOrderPrice.Location = new Point(307, 34);
            labelOrderPrice.Name = "labelOrderPrice";
            labelOrderPrice.Size = new Size(212, 20);
            labelOrderPrice.TabIndex = 3;
            labelOrderPrice.Text = "Základní cena objednávky CZK";
            // 
            // labelCustomer
            // 
            labelCustomer.AutoSize = true;
            labelCustomer.Location = new Point(6, 34);
            labelCustomer.Name = "labelCustomer";
            labelCustomer.Size = new Size(117, 20);
            labelCustomer.TabIndex = 1;
            labelCustomer.Text = "Email zákazníka:";
            // 
            // numericUpDownDeliveryPrice
            // 
            numericUpDownDeliveryPrice.DecimalPlaces = 2;
            numericUpDownDeliveryPrice.Location = new Point(282, 74);
            numericUpDownDeliveryPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownDeliveryPrice.Name = "numericUpDownDeliveryPrice";
            numericUpDownDeliveryPrice.Size = new Size(246, 27);
            numericUpDownDeliveryPrice.TabIndex = 10;
            // 
            // numericUpDownOrderPrice
            // 
            numericUpDownOrderPrice.DecimalPlaces = 2;
            numericUpDownOrderPrice.Location = new Point(307, 58);
            numericUpDownOrderPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownOrderPrice.Name = "numericUpDownOrderPrice";
            numericUpDownOrderPrice.Size = new Size(254, 27);
            numericUpDownOrderPrice.TabIndex = 4;
            // 
            // dlgOrderA
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxOrder);
            Name = "dlgOrderA";
            Size = new Size(584, 526);
            groupBoxOrder.ResumeLayout(false);
            groupBoxOrder.PerformLayout();
            groupBoxDelivery.ResumeLayout(false);
            groupBoxDelivery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDeliveryPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOrderPrice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxOrder;
        private Label labelCustomer;
        private GroupBox groupBoxDelivery;
        private TextBox textBoxCustomerEmail;
        private Button btnSave;
        private Label labelLog;
        private TextBox textBoxErrors;
        private Label labelType;
        private Label labelDeliveryDate;
        private DateTimePicker dateTimePickerDeliveryDate;
        private Label labelOrderPrice;
        private ComboBox comboBoxDeliveryType;
        private Label labelNote;
        private TextBox textBoxNote;
        private Label labelDeliveryAddress;
        private TextBox textBoxDeliveryAddress;
        private CheckBox checkBoxCreateDelivery;
        private Label labelDeliveryPrice;
        private NumericUpDown numericUpDownDeliveryPrice;
        private NumericUpDown numericUpDownOrderPrice;
    }
}
