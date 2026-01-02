namespace Orderappis.UserControls.Mod.Orders.dlg
{
    partial class dlgInvoice
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
            groupBoxInvoice = new GroupBox();
            numericUpDownTotalPriceCZK = new NumericUpDown();
            textBox_BAccNum = new TextBox();
            label_BAccNum = new Label();
            label_InvoiceNumber = new Label();
            buttonPDF = new Button();
            textBox_InvoiceNumber = new TextBox();
            groupBoxDPH = new GroupBox();
            dateTimePicker1 = new DateTimePicker();
            labelDUZP = new Label();
            textBoxDIC_dod = new TextBox();
            textBoxDIC_odb = new TextBox();
            labelDIC_dod = new Label();
            labelDIC_od = new Label();
            comboBoxDPH_Sazba = new ComboBox();
            checkBox_jeDPH = new CheckBox();
            dateTimePickerDate2 = new DateTimePicker();
            labelDate2 = new Label();
            dateTimePickerDate1 = new DateTimePicker();
            labelDate = new Label();
            groupBoxDod = new GroupBox();
            textBoxDod_IC = new TextBox();
            labelDod_IC = new Label();
            textBoxDod_Address = new TextBox();
            labelDod_Address = new Label();
            textBoxDod_Name = new TextBox();
            labelDod_Name = new Label();
            groupBoxOdb = new GroupBox();
            textBoxOdb_IC = new TextBox();
            labelOdb_IC = new Label();
            textBoxOdb_Address = new TextBox();
            labelOdb_Address = new Label();
            textBoxOdb_Name = new TextBox();
            labelOdb_Name = new Label();
            labelVS = new Label();
            textBoxVS = new TextBox();
            groupBoxInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTotalPriceCZK).BeginInit();
            groupBoxDPH.SuspendLayout();
            groupBoxDod.SuspendLayout();
            groupBoxOdb.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxInvoice
            // 
            groupBoxInvoice.Controls.Add(textBoxVS);
            groupBoxInvoice.Controls.Add(labelVS);
            groupBoxInvoice.Controls.Add(numericUpDownTotalPriceCZK);
            groupBoxInvoice.Controls.Add(textBox_BAccNum);
            groupBoxInvoice.Controls.Add(label_BAccNum);
            groupBoxInvoice.Controls.Add(label_InvoiceNumber);
            groupBoxInvoice.Controls.Add(buttonPDF);
            groupBoxInvoice.Controls.Add(textBox_InvoiceNumber);
            groupBoxInvoice.Controls.Add(groupBoxDPH);
            groupBoxInvoice.Controls.Add(checkBox_jeDPH);
            groupBoxInvoice.Controls.Add(dateTimePickerDate2);
            groupBoxInvoice.Controls.Add(labelDate2);
            groupBoxInvoice.Controls.Add(dateTimePickerDate1);
            groupBoxInvoice.Controls.Add(labelDate);
            groupBoxInvoice.Controls.Add(groupBoxDod);
            groupBoxInvoice.Controls.Add(groupBoxOdb);
            groupBoxInvoice.Location = new Point(3, 3);
            groupBoxInvoice.Name = "groupBoxInvoice";
            groupBoxInvoice.Size = new Size(630, 504);
            groupBoxInvoice.TabIndex = 0;
            groupBoxInvoice.TabStop = false;
            groupBoxInvoice.Text = "Faktura";
            // 
            // numericUpDownTotalPriceCZK
            // 
            numericUpDownTotalPriceCZK.DecimalPlaces = 2;
            numericUpDownTotalPriceCZK.Location = new Point(241, 346);
            numericUpDownTotalPriceCZK.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownTotalPriceCZK.Name = "numericUpDownTotalPriceCZK";
            numericUpDownTotalPriceCZK.ReadOnly = true;
            numericUpDownTotalPriceCZK.Size = new Size(168, 27);
            numericUpDownTotalPriceCZK.TabIndex = 15;
            numericUpDownTotalPriceCZK.Visible = false;
            // 
            // textBox_BAccNum
            // 
            textBox_BAccNum.Location = new Point(111, 430);
            textBox_BAccNum.Name = "textBox_BAccNum";
            textBox_BAccNum.Size = new Size(298, 27);
            textBox_BAccNum.TabIndex = 14;
            // 
            // label_BAccNum
            // 
            label_BAccNum.AutoSize = true;
            label_BAccNum.Location = new Point(12, 433);
            label_BAccNum.Name = "label_BAccNum";
            label_BAccNum.Size = new Size(76, 20);
            label_BAccNum.TabIndex = 13;
            label_BAccNum.Text = "Číslo účtu:";
            // 
            // label_InvoiceNumber
            // 
            label_InvoiceNumber.AutoSize = true;
            label_InvoiceNumber.Location = new Point(12, 392);
            label_InvoiceNumber.Name = "label_InvoiceNumber";
            label_InvoiceNumber.Size = new Size(93, 20);
            label_InvoiceNumber.TabIndex = 12;
            label_InvoiceNumber.Text = "Číslo faktury:";
            // 
            // buttonPDF
            // 
            buttonPDF.BackColor = Color.FromArgb(0, 192, 0);
            buttonPDF.Cursor = Cursors.Hand;
            buttonPDF.ForeColor = SystemColors.ButtonFace;
            buttonPDF.Location = new Point(321, 463);
            buttonPDF.Name = "buttonPDF";
            buttonPDF.Size = new Size(88, 29);
            buttonPDF.TabIndex = 11;
            buttonPDF.Text = "Generuj";
            buttonPDF.UseVisualStyleBackColor = false;
            buttonPDF.Click += buttonPDF_Click;
            // 
            // textBox_InvoiceNumber
            // 
            textBox_InvoiceNumber.Enabled = false;
            textBox_InvoiceNumber.Location = new Point(111, 389);
            textBox_InvoiceNumber.Name = "textBox_InvoiceNumber";
            textBox_InvoiceNumber.Size = new Size(298, 27);
            textBox_InvoiceNumber.TabIndex = 10;
            // 
            // groupBoxDPH
            // 
            groupBoxDPH.Controls.Add(dateTimePicker1);
            groupBoxDPH.Controls.Add(labelDUZP);
            groupBoxDPH.Controls.Add(textBoxDIC_dod);
            groupBoxDPH.Controls.Add(textBoxDIC_odb);
            groupBoxDPH.Controls.Add(labelDIC_dod);
            groupBoxDPH.Controls.Add(labelDIC_od);
            groupBoxDPH.Controls.Add(comboBoxDPH_Sazba);
            groupBoxDPH.Enabled = false;
            groupBoxDPH.Location = new Point(415, 249);
            groupBoxDPH.Name = "groupBoxDPH";
            groupBoxDPH.Size = new Size(209, 249);
            groupBoxDPH.TabIndex = 9;
            groupBoxDPH.TabStop = false;
            groupBoxDPH.Text = "DPH";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(6, 199);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(203, 27);
            dateTimePicker1.TabIndex = 6;
            // 
            // labelDUZP
            // 
            labelDUZP.AutoSize = true;
            labelDUZP.Location = new Point(7, 176);
            labelDUZP.Name = "labelDUZP";
            labelDUZP.Size = new Size(47, 20);
            labelDUZP.TabIndex = 5;
            labelDUZP.Text = "DUZP";
            // 
            // textBoxDIC_dod
            // 
            textBoxDIC_dod.Location = new Point(6, 137);
            textBoxDIC_dod.Name = "textBoxDIC_dod";
            textBoxDIC_dod.Size = new Size(203, 27);
            textBoxDIC_dod.TabIndex = 4;
            // 
            // textBoxDIC_odb
            // 
            textBoxDIC_odb.Location = new Point(7, 76);
            textBoxDIC_odb.Name = "textBoxDIC_odb";
            textBoxDIC_odb.Size = new Size(202, 27);
            textBoxDIC_odb.TabIndex = 3;
            // 
            // labelDIC_dod
            // 
            labelDIC_dod.AutoSize = true;
            labelDIC_dod.Location = new Point(7, 114);
            labelDIC_dod.Name = "labelDIC_dod";
            labelDIC_dod.Size = new Size(112, 20);
            labelDIC_dod.TabIndex = 2;
            labelDIC_dod.Text = "DIČ dodavatele";
            // 
            // labelDIC_od
            // 
            labelDIC_od.AutoSize = true;
            labelDIC_od.Location = new Point(7, 53);
            labelDIC_od.Name = "labelDIC_od";
            labelDIC_od.Size = new Size(110, 20);
            labelDIC_od.TabIndex = 1;
            labelDIC_od.Text = "DIČ odběratele";
            // 
            // comboBoxDPH_Sazba
            // 
            comboBoxDPH_Sazba.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDPH_Sazba.FormattingEnabled = true;
            comboBoxDPH_Sazba.Items.AddRange(new object[] { "21", "12", "0" });
            comboBoxDPH_Sazba.Location = new Point(7, 22);
            comboBoxDPH_Sazba.Name = "comboBoxDPH_Sazba";
            comboBoxDPH_Sazba.Size = new Size(151, 28);
            comboBoxDPH_Sazba.TabIndex = 0;
            // 
            // checkBox_jeDPH
            // 
            checkBox_jeDPH.AutoSize = true;
            checkBox_jeDPH.Enabled = false;
            checkBox_jeDPH.Location = new Point(12, 346);
            checkBox_jeDPH.Name = "checkBox_jeDPH";
            checkBox_jeDPH.Size = new Size(209, 24);
            checkBox_jeDPH.TabIndex = 8;
            checkBox_jeDPH.Text = "Vystavovatel je plátce DPH";
            checkBox_jeDPH.UseVisualStyleBackColor = true;
            checkBox_jeDPH.Click += checkBox_jeDPH_Click;
            // 
            // dateTimePickerDate2
            // 
            dateTimePickerDate2.Location = new Point(158, 306);
            dateTimePickerDate2.Name = "dateTimePickerDate2";
            dateTimePickerDate2.Size = new Size(251, 27);
            dateTimePickerDate2.TabIndex = 7;
            // 
            // labelDate2
            // 
            labelDate2.AutoSize = true;
            labelDate2.Location = new Point(6, 311);
            labelDate2.Name = "labelDate2";
            labelDate2.Size = new Size(125, 20);
            labelDate2.TabIndex = 6;
            labelDate2.Text = "Datum splatnosti:";
            // 
            // dateTimePickerDate1
            // 
            dateTimePickerDate1.Location = new Point(158, 268);
            dateTimePickerDate1.Name = "dateTimePickerDate1";
            dateTimePickerDate1.Size = new Size(251, 27);
            dateTimePickerDate1.TabIndex = 5;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(6, 273);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(121, 20);
            labelDate.TabIndex = 4;
            labelDate.Text = "Datum vystavení:";
            // 
            // groupBoxDod
            // 
            groupBoxDod.Controls.Add(textBoxDod_IC);
            groupBoxDod.Controls.Add(labelDod_IC);
            groupBoxDod.Controls.Add(textBoxDod_Address);
            groupBoxDod.Controls.Add(labelDod_Address);
            groupBoxDod.Controls.Add(textBoxDod_Name);
            groupBoxDod.Controls.Add(labelDod_Name);
            groupBoxDod.Location = new Point(12, 33);
            groupBoxDod.Name = "groupBoxDod";
            groupBoxDod.Size = new Size(329, 207);
            groupBoxDod.TabIndex = 3;
            groupBoxDod.TabStop = false;
            groupBoxDod.Text = "Dodavatel";
            // 
            // textBoxDod_IC
            // 
            textBoxDod_IC.Location = new Point(6, 162);
            textBoxDod_IC.Name = "textBoxDod_IC";
            textBoxDod_IC.Size = new Size(307, 27);
            textBoxDod_IC.TabIndex = 7;
            // 
            // labelDod_IC
            // 
            labelDod_IC.AutoSize = true;
            labelDod_IC.Location = new Point(6, 139);
            labelDod_IC.Name = "labelDod_IC";
            labelDod_IC.Size = new Size(25, 20);
            labelDod_IC.TabIndex = 6;
            labelDod_IC.Text = "IČ:";
            // 
            // textBoxDod_Address
            // 
            textBoxDod_Address.Location = new Point(6, 109);
            textBoxDod_Address.Name = "textBoxDod_Address";
            textBoxDod_Address.Size = new Size(307, 27);
            textBoxDod_Address.TabIndex = 5;
            // 
            // labelDod_Address
            // 
            labelDod_Address.AutoSize = true;
            labelDod_Address.Location = new Point(6, 86);
            labelDod_Address.Name = "labelDod_Address";
            labelDod_Address.Size = new Size(58, 20);
            labelDod_Address.TabIndex = 4;
            labelDod_Address.Text = "Adresa:";
            // 
            // textBoxDod_Name
            // 
            textBoxDod_Name.Location = new Point(6, 56);
            textBoxDod_Name.Name = "textBoxDod_Name";
            textBoxDod_Name.Size = new Size(307, 27);
            textBoxDod_Name.TabIndex = 3;
            // 
            // labelDod_Name
            // 
            labelDod_Name.AutoSize = true;
            labelDod_Name.Location = new Point(6, 33);
            labelDod_Name.Name = "labelDod_Name";
            labelDod_Name.Size = new Size(102, 20);
            labelDod_Name.TabIndex = 0;
            labelDod_Name.Text = "Jméno/Název:";
            // 
            // groupBoxOdb
            // 
            groupBoxOdb.Controls.Add(textBoxOdb_IC);
            groupBoxOdb.Controls.Add(labelOdb_IC);
            groupBoxOdb.Controls.Add(textBoxOdb_Address);
            groupBoxOdb.Controls.Add(labelOdb_Address);
            groupBoxOdb.Controls.Add(textBoxOdb_Name);
            groupBoxOdb.Controls.Add(labelOdb_Name);
            groupBoxOdb.Location = new Point(341, 33);
            groupBoxOdb.Name = "groupBoxOdb";
            groupBoxOdb.Size = new Size(283, 207);
            groupBoxOdb.TabIndex = 2;
            groupBoxOdb.TabStop = false;
            groupBoxOdb.Text = "Odběratel";
            // 
            // textBoxOdb_IC
            // 
            textBoxOdb_IC.Location = new Point(6, 162);
            textBoxOdb_IC.Name = "textBoxOdb_IC";
            textBoxOdb_IC.Size = new Size(256, 27);
            textBoxOdb_IC.TabIndex = 8;
            // 
            // labelOdb_IC
            // 
            labelOdb_IC.AutoSize = true;
            labelOdb_IC.Location = new Point(6, 139);
            labelOdb_IC.Name = "labelOdb_IC";
            labelOdb_IC.Size = new Size(25, 20);
            labelOdb_IC.TabIndex = 7;
            labelOdb_IC.Text = "IČ:";
            // 
            // textBoxOdb_Address
            // 
            textBoxOdb_Address.Location = new Point(5, 109);
            textBoxOdb_Address.Name = "textBoxOdb_Address";
            textBoxOdb_Address.Size = new Size(257, 27);
            textBoxOdb_Address.TabIndex = 6;
            // 
            // labelOdb_Address
            // 
            labelOdb_Address.AutoSize = true;
            labelOdb_Address.Location = new Point(6, 86);
            labelOdb_Address.Name = "labelOdb_Address";
            labelOdb_Address.Size = new Size(58, 20);
            labelOdb_Address.TabIndex = 3;
            labelOdb_Address.Text = "Adresa:";
            // 
            // textBoxOdb_Name
            // 
            textBoxOdb_Name.Location = new Point(6, 56);
            textBoxOdb_Name.Name = "textBoxOdb_Name";
            textBoxOdb_Name.Size = new Size(257, 27);
            textBoxOdb_Name.TabIndex = 2;
            // 
            // labelOdb_Name
            // 
            labelOdb_Name.AutoSize = true;
            labelOdb_Name.Location = new Point(6, 33);
            labelOdb_Name.Name = "labelOdb_Name";
            labelOdb_Name.Size = new Size(102, 20);
            labelOdb_Name.TabIndex = 1;
            labelOdb_Name.Text = "Jméno/Název:";
            // 
            // labelVS
            // 
            labelVS.AutoSize = true;
            labelVS.Location = new Point(12, 468);
            labelVS.Name = "labelVS";
            labelVS.Size = new Size(126, 20);
            labelVS.TabIndex = 16;
            labelVS.Text = "Variabilní symbol:";
            // 
            // textBoxVS
            // 
            textBoxVS.Location = new Point(144, 465);
            textBoxVS.Name = "textBoxVS";
            textBoxVS.Size = new Size(171, 27);
            textBoxVS.TabIndex = 17;
            // 
            // dlgInvoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxInvoice);
            Name = "dlgInvoice";
            Size = new Size(636, 512);
            groupBoxInvoice.ResumeLayout(false);
            groupBoxInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTotalPriceCZK).EndInit();
            groupBoxDPH.ResumeLayout(false);
            groupBoxDPH.PerformLayout();
            groupBoxDod.ResumeLayout(false);
            groupBoxDod.PerformLayout();
            groupBoxOdb.ResumeLayout(false);
            groupBoxOdb.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxInvoice;
        private Label labelDod_Name;
        private Label labelOdb_Name;
        private GroupBox groupBoxDod;
        private GroupBox groupBoxOdb;
        private Label labelDate;
        private DateTimePicker dateTimePickerDate1;
        private Label labelDate2;
        private DateTimePicker dateTimePickerDate2;
        private TextBox textBoxDod_Name;
        private TextBox textBoxOdb_Name;
        private Label labelOdb_Address;
        private Label labelDod_Address;
        private CheckBox checkBox_jeDPH;
        private GroupBox groupBoxDPH;
        private ComboBox comboBoxDPH_Sazba;
        private Label labelDIC_dod;
        private Label labelDIC_od;
        private TextBox textBoxDIC_dod;
        private TextBox textBoxDIC_odb;
        private Label labelDUZP;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox_InvoiceNumber;
        private Button buttonPDF;
        private Label label_InvoiceNumber;
        private TextBox textBoxDod_Address;
        private TextBox textBoxOdb_Address;
        private Label label_BAccNum;
        private TextBox textBox_BAccNum;
        private Label labelOdb_IC;
        private Label labelDod_IC;
        private TextBox textBoxDod_IC;
        private TextBox textBoxOdb_IC;
        private NumericUpDown numericUpDownTotalPriceCZK;
        private Label labelVS;
        private TextBox textBoxVS;
    }
}
