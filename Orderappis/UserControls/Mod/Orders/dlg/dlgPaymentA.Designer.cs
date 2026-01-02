namespace Orderappis.UserControls.Mod.Orders.dlg
{
    partial class dlgPaymentA
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
            groupBoxPayment = new GroupBox();
            textBoxOrderId = new TextBox();
            labelOrderId = new Label();
            textBoxNote = new TextBox();
            labelNote = new Label();
            dateTimePickerPaymentDate = new DateTimePicker();
            comboBoxPaymentMethod = new ComboBox();
            checkBoxTotalCZK = new CheckBox();
            labelPaymentMethod = new Label();
            labelPaymentDate = new Label();
            buttonSave = new Button();
            npgsqlDataAdapter1 = new Npgsql.NpgsqlDataAdapter();
            labelErrors = new Label();
            textBoxErrors = new TextBox();
            groupBoxPayment.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxPayment
            // 
            groupBoxPayment.Controls.Add(textBoxErrors);
            groupBoxPayment.Controls.Add(labelErrors);
            groupBoxPayment.Controls.Add(textBoxOrderId);
            groupBoxPayment.Controls.Add(labelOrderId);
            groupBoxPayment.Controls.Add(textBoxNote);
            groupBoxPayment.Controls.Add(labelNote);
            groupBoxPayment.Controls.Add(dateTimePickerPaymentDate);
            groupBoxPayment.Controls.Add(comboBoxPaymentMethod);
            groupBoxPayment.Controls.Add(checkBoxTotalCZK);
            groupBoxPayment.Controls.Add(labelPaymentMethod);
            groupBoxPayment.Controls.Add(labelPaymentDate);
            groupBoxPayment.Controls.Add(buttonSave);
            groupBoxPayment.Location = new Point(3, 3);
            groupBoxPayment.Name = "groupBoxPayment";
            groupBoxPayment.Size = new Size(420, 491);
            groupBoxPayment.TabIndex = 0;
            groupBoxPayment.TabStop = false;
            groupBoxPayment.Text = "Platba";
            // 
            // textBoxOrderId
            // 
            textBoxOrderId.Location = new Point(154, 30);
            textBoxOrderId.Name = "textBoxOrderId";
            textBoxOrderId.Size = new Size(250, 27);
            textBoxOrderId.TabIndex = 9;
            // 
            // labelOrderId
            // 
            labelOrderId.AutoSize = true;
            labelOrderId.Location = new Point(8, 33);
            labelOrderId.Name = "labelOrderId";
            labelOrderId.Size = new Size(107, 20);
            labelOrderId.TabIndex = 8;
            labelOrderId.Text = "ID objednávky:";
            // 
            // textBoxNote
            // 
            textBoxNote.Location = new Point(67, 190);
            textBoxNote.Multiline = true;
            textBoxNote.Name = "textBoxNote";
            textBoxNote.Size = new Size(337, 108);
            textBoxNote.TabIndex = 7;
            // 
            // labelNote
            // 
            labelNote.AutoSize = true;
            labelNote.Location = new Point(7, 193);
            labelNote.Name = "labelNote";
            labelNote.Size = new Size(50, 20);
            labelNote.TabIndex = 6;
            labelNote.Text = "Pozn. :";
            // 
            // dateTimePickerPaymentDate
            // 
            dateTimePickerPaymentDate.Location = new Point(154, 70);
            dateTimePickerPaymentDate.Name = "dateTimePickerPaymentDate";
            dateTimePickerPaymentDate.Size = new Size(250, 27);
            dateTimePickerPaymentDate.TabIndex = 5;
            // 
            // comboBoxPaymentMethod
            // 
            comboBoxPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPaymentMethod.FormattingEnabled = true;
            comboBoxPaymentMethod.Location = new Point(154, 111);
            comboBoxPaymentMethod.Name = "comboBoxPaymentMethod";
            comboBoxPaymentMethod.Size = new Size(250, 28);
            comboBoxPaymentMethod.TabIndex = 4;
            // 
            // checkBoxTotalCZK
            // 
            checkBoxTotalCZK.AutoSize = true;
            checkBoxTotalCZK.Checked = true;
            checkBoxTotalCZK.CheckState = CheckState.Checked;
            checkBoxTotalCZK.Enabled = false;
            checkBoxTotalCZK.Location = new Point(7, 151);
            checkBoxTotalCZK.Name = "checkBoxTotalCZK";
            checkBoxTotalCZK.Size = new Size(184, 24);
            checkBoxTotalCZK.TabIndex = 3;
            checkBoxTotalCZK.Text = "Zaplaceno/Zaplatit vše";
            checkBoxTotalCZK.UseVisualStyleBackColor = true;
            // 
            // labelPaymentMethod
            // 
            labelPaymentMethod.AutoSize = true;
            labelPaymentMethod.Location = new Point(8, 114);
            labelPaymentMethod.Name = "labelPaymentMethod";
            labelPaymentMethod.Size = new Size(122, 20);
            labelPaymentMethod.TabIndex = 2;
            labelPaymentMethod.Text = "Platební metoda:";
            // 
            // labelPaymentDate
            // 
            labelPaymentDate.AutoSize = true;
            labelPaymentDate.Location = new Point(8, 70);
            labelPaymentDate.Name = "labelPaymentDate";
            labelPaymentDate.Size = new Size(125, 20);
            labelPaymentDate.TabIndex = 1;
            labelPaymentDate.Text = "Datum splatnosti:";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(310, 453);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 28);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Uložit";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // npgsqlDataAdapter1
            // 
            npgsqlDataAdapter1.DeleteCommand = null;
            npgsqlDataAdapter1.InsertCommand = null;
            npgsqlDataAdapter1.SelectCommand = null;
            npgsqlDataAdapter1.UpdateCommand = null;
            // 
            // labelErrors
            // 
            labelErrors.AutoSize = true;
            labelErrors.Location = new Point(16, 323);
            labelErrors.Name = "labelErrors";
            labelErrors.Size = new Size(41, 20);
            labelErrors.TabIndex = 10;
            labelErrors.Text = "Log :";
            // 
            // textBoxErrors
            // 
            textBoxErrors.BackColor = SystemColors.Info;
            textBoxErrors.ForeColor = Color.FromArgb(192, 0, 0);
            textBoxErrors.Location = new Point(67, 320);
            textBoxErrors.Multiline = true;
            textBoxErrors.Name = "textBoxErrors";
            textBoxErrors.Size = new Size(337, 118);
            textBoxErrors.TabIndex = 11;
            // 
            // dlgPaymentA
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxPayment);
            Name = "dlgPaymentA";
            Size = new Size(429, 497);
            groupBoxPayment.ResumeLayout(false);
            groupBoxPayment.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxPayment;
        private Button buttonSave;
        private Label labelPaymentDate;
        private Label labelPaymentMethod;
        private CheckBox checkBoxTotalCZK;
        private ComboBox comboBoxPaymentMethod;
        private DateTimePicker dateTimePickerPaymentDate;
        private Npgsql.NpgsqlDataAdapter npgsqlDataAdapter1;
        private Label labelNote;
        private TextBox textBoxNote;
        private Label labelOrderId;
        private TextBox textBoxOrderId;
        private Label labelErrors;
        private TextBox textBoxErrors;
    }
}
