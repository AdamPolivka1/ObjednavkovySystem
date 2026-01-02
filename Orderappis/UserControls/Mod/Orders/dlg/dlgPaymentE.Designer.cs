namespace Orderappis.UserControls.Mod.Orders.dlg
{
    partial class dlgPaymentE
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
            comboBoxStatus = new ComboBox();
            labelStatus = new Label();
            buttonSave = new Button();
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
            groupBoxPayment.Controls.Add(comboBoxStatus);
            groupBoxPayment.Controls.Add(labelStatus);
            groupBoxPayment.Controls.Add(buttonSave);
            groupBoxPayment.Location = new Point(3, 3);
            groupBoxPayment.Name = "groupBoxPayment";
            groupBoxPayment.Size = new Size(304, 423);
            groupBoxPayment.TabIndex = 0;
            groupBoxPayment.TabStop = false;
            groupBoxPayment.Text = "Platba";
            // 
            // textBoxOrderId
            // 
            textBoxOrderId.Location = new Point(113, 29);
            textBoxOrderId.Name = "textBoxOrderId";
            textBoxOrderId.Size = new Size(185, 27);
            textBoxOrderId.TabIndex = 6;
            // 
            // labelOrderId
            // 
            labelOrderId.AutoSize = true;
            labelOrderId.Location = new Point(2, 32);
            labelOrderId.Name = "labelOrderId";
            labelOrderId.Size = new Size(105, 20);
            labelOrderId.TabIndex = 5;
            labelOrderId.Text = "Id objednávky:";
            // 
            // textBoxNote
            // 
            textBoxNote.Location = new Point(64, 106);
            textBoxNote.Multiline = true;
            textBoxNote.Name = "textBoxNote";
            textBoxNote.Size = new Size(234, 159);
            textBoxNote.TabIndex = 4;
            // 
            // labelNote
            // 
            labelNote.AutoSize = true;
            labelNote.Location = new Point(2, 106);
            labelNote.Name = "labelNote";
            labelNote.Size = new Size(50, 20);
            labelNote.TabIndex = 3;
            labelNote.Text = "Pozn. :";
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new Point(64, 66);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(234, 28);
            comboBoxStatus.TabIndex = 2;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(0, 66);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(52, 20);
            labelStatus.TabIndex = 1;
            labelStatus.Text = "Status:";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(204, 388);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Uložit";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // labelErrors
            // 
            labelErrors.AutoSize = true;
            labelErrors.Location = new Point(6, 280);
            labelErrors.Name = "labelErrors";
            labelErrors.Size = new Size(41, 20);
            labelErrors.TabIndex = 7;
            labelErrors.Text = "Log :";
            // 
            // textBoxErrors
            // 
            textBoxErrors.BackColor = SystemColors.Info;
            textBoxErrors.ForeColor = Color.Red;
            textBoxErrors.Location = new Point(64, 277);
            textBoxErrors.Multiline = true;
            textBoxErrors.Name = "textBoxErrors";
            textBoxErrors.Size = new Size(234, 105);
            textBoxErrors.TabIndex = 8;
            // 
            // dlgPaymentE
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxPayment);
            Name = "dlgPaymentE";
            Size = new Size(313, 429);
            groupBoxPayment.ResumeLayout(false);
            groupBoxPayment.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxPayment;
        private Button buttonSave;
        private Label labelStatus;
        private ComboBox comboBoxStatus;
        private TextBox textBoxNote;
        private Label labelNote;
        private Label labelOrderId;
        private TextBox textBoxOrderId;
        private Label labelErrors;
        private TextBox textBoxErrors;
    }
}
