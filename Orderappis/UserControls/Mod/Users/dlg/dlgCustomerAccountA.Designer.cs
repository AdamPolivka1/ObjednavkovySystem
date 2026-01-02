namespace Orderappis.UserControls.Mod.Users.dlg
{
    partial class dlgCustomerAccountA
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBoxCustomerAccount = new GroupBox();
            numericUpDownUserId = new NumericUpDown();
            buttonSave = new Button();
            textBoxErrors = new TextBox();
            dateTimePickerValidTo = new DateTimePicker();
            label3 = new Label();
            labelUserId = new Label();
            label2 = new Label();
            groupBoxCustomerAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownUserId).BeginInit();
            SuspendLayout();
            // 
            // groupBoxCustomerAccount
            // 
            groupBoxCustomerAccount.Controls.Add(numericUpDownUserId);
            groupBoxCustomerAccount.Controls.Add(buttonSave);
            groupBoxCustomerAccount.Controls.Add(textBoxErrors);
            groupBoxCustomerAccount.Controls.Add(dateTimePickerValidTo);
            groupBoxCustomerAccount.Controls.Add(label3);
            groupBoxCustomerAccount.Controls.Add(labelUserId);
            groupBoxCustomerAccount.Controls.Add(label2);
            groupBoxCustomerAccount.Location = new Point(3, 3);
            groupBoxCustomerAccount.Name = "groupBoxCustomerAccount";
            groupBoxCustomerAccount.Size = new Size(380, 277);
            groupBoxCustomerAccount.TabIndex = 0;
            groupBoxCustomerAccount.TabStop = false;
            groupBoxCustomerAccount.Text = "Zákaznický účet";
            // 
            // numericUpDownUserId
            // 
            numericUpDownUserId.Location = new Point(109, 44);
            numericUpDownUserId.Name = "numericUpDownUserId";
            numericUpDownUserId.Size = new Size(92, 27);
            numericUpDownUserId.TabIndex = 9;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(265, 242);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 8;
            buttonSave.Text = "Uložit";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // textBoxErrors
            // 
            textBoxErrors.BackColor = SystemColors.Info;
            textBoxErrors.ForeColor = Color.Red;
            textBoxErrors.Location = new Point(64, 130);
            textBoxErrors.Multiline = true;
            textBoxErrors.Name = "textBoxErrors";
            textBoxErrors.Size = new Size(295, 97);
            textBoxErrors.TabIndex = 7;
            // 
            // dateTimePickerValidTo
            // 
            dateTimePickerValidTo.Location = new Point(109, 86);
            dateTimePickerValidTo.Name = "dateTimePickerValidTo";
            dateTimePickerValidTo.Size = new Size(250, 27);
            dateTimePickerValidTo.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 130);
            label3.Name = "label3";
            label3.Size = new Size(37, 20);
            label3.TabIndex = 5;
            label3.Text = "Log:";
            // 
            // labelUserId
            // 
            labelUserId.AutoSize = true;
            labelUserId.Location = new Point(11, 46);
            labelUserId.Name = "labelUserId";
            labelUserId.Size = new Size(88, 20);
            labelUserId.TabIndex = 4;
            labelUserId.Text = "Id uživatele:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 91);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 3;
            label2.Text = "Platnost do:";
            // 
            // dlgCustomerAccountA
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxCustomerAccount);
            Name = "dlgCustomerAccountA";
            Size = new Size(386, 282);
            groupBoxCustomerAccount.ResumeLayout(false);
            groupBoxCustomerAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownUserId).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox groupBoxCustomerAccount;
        private Label label3;
        private Label labelUserId;
        private Label label2;
        private DateTimePicker dateTimePickerValidTo;
        private TextBox textBoxErrors;
        private Button buttonSave;
        private NumericUpDown numericUpDownUserId;
    }
}
