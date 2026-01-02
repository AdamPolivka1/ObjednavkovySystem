namespace Orderappis.UserControls.Mod.Orders.dlg
{
    partial class dlgOrderE
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
            comboBoxStatus = new ComboBox();
            labelStatus = new Label();
            buttonSave = new Button();
            labelTotalPriceCZK = new Label();
            numericUpDownTotalPriceCZK = new NumericUpDown();
            groupBoxOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTotalPriceCZK).BeginInit();
            SuspendLayout();
            // 
            // groupBoxOrder
            // 
            groupBoxOrder.Controls.Add(numericUpDownTotalPriceCZK);
            groupBoxOrder.Controls.Add(labelTotalPriceCZK);
            groupBoxOrder.Controls.Add(comboBoxStatus);
            groupBoxOrder.Controls.Add(labelStatus);
            groupBoxOrder.Controls.Add(buttonSave);
            groupBoxOrder.Location = new Point(3, 3);
            groupBoxOrder.Name = "groupBoxOrder";
            groupBoxOrder.Size = new Size(329, 204);
            groupBoxOrder.TabIndex = 0;
            groupBoxOrder.TabStop = false;
            groupBoxOrder.Text = "Objednávka";
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new Point(16, 51);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(307, 28);
            comboBoxStatus.TabIndex = 2;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(16, 28);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(52, 20);
            labelStatus.TabIndex = 1;
            labelStatus.Text = "Status:";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(229, 160);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Uložit";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // labelTotalPriceCZK
            // 
            labelTotalPriceCZK.AutoSize = true;
            labelTotalPriceCZK.Location = new Point(16, 92);
            labelTotalPriceCZK.Name = "labelTotalPriceCZK";
            labelTotalPriceCZK.Size = new Size(99, 20);
            labelTotalPriceCZK.TabIndex = 3;
            labelTotalPriceCZK.Text = "Celková cena:";
            // 
            // numericUpDownTotalPriceCZK
            // 
            numericUpDownTotalPriceCZK.DecimalPlaces = 2;
            numericUpDownTotalPriceCZK.Location = new Point(16, 115);
            numericUpDownTotalPriceCZK.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownTotalPriceCZK.Name = "numericUpDownTotalPriceCZK";
            numericUpDownTotalPriceCZK.Size = new Size(307, 27);
            numericUpDownTotalPriceCZK.TabIndex = 4;
            // 
            // dlgOrderE
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxOrder);
            Name = "dlgOrderE";
            Size = new Size(335, 212);
            groupBoxOrder.ResumeLayout(false);
            groupBoxOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTotalPriceCZK).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxOrder;
        private Button buttonSave;
        private Label labelStatus;
        private ComboBox comboBoxStatus;
        private Label labelTotalPriceCZK;
        private NumericUpDown numericUpDownTotalPriceCZK;
    }
}
