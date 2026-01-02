namespace Orderappis.UserControls.Mod.Users.dlg
{
    partial class dlgUserEA
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
            gbUserEA = new GroupBox();
            textBoxErrors = new TextBox();
            lblErrors = new Label();
            btnPasswordCreate = new Button();
            textBoxPasswordCreate = new TextBox();
            comboBoxUserRoleId = new ComboBox();
            textBoxPhoneNumber2 = new TextBox();
            textBoxPhoneNumber1 = new TextBox();
            labelPhoneNum2 = new Label();
            labelPhoneNum1 = new Label();
            textBoxCompanyName = new TextBox();
            labelCompanyName = new Label();
            textBoxEmail = new TextBox();
            labelEmail = new Label();
            textBoxLastname = new TextBox();
            label1 = new Label();
            buttonSave = new Button();
            labelFirstname = new Label();
            textBoxLogin = new TextBox();
            labelPassword = new Label();
            textBoxFirstname = new TextBox();
            labelLogin = new Label();
            textBoxPassword = new TextBox();
            labelUserRoleId = new Label();
            gbUserEA.SuspendLayout();
            SuspendLayout();
            // 
            // gbUserEA
            // 
            gbUserEA.Controls.Add(textBoxErrors);
            gbUserEA.Controls.Add(lblErrors);
            gbUserEA.Controls.Add(btnPasswordCreate);
            gbUserEA.Controls.Add(textBoxPasswordCreate);
            gbUserEA.Controls.Add(comboBoxUserRoleId);
            gbUserEA.Controls.Add(textBoxPhoneNumber2);
            gbUserEA.Controls.Add(textBoxPhoneNumber1);
            gbUserEA.Controls.Add(labelPhoneNum2);
            gbUserEA.Controls.Add(labelPhoneNum1);
            gbUserEA.Controls.Add(textBoxCompanyName);
            gbUserEA.Controls.Add(labelCompanyName);
            gbUserEA.Controls.Add(textBoxEmail);
            gbUserEA.Controls.Add(labelEmail);
            gbUserEA.Controls.Add(textBoxLastname);
            gbUserEA.Controls.Add(label1);
            gbUserEA.Controls.Add(buttonSave);
            gbUserEA.Controls.Add(labelFirstname);
            gbUserEA.Controls.Add(textBoxLogin);
            gbUserEA.Controls.Add(labelPassword);
            gbUserEA.Controls.Add(textBoxFirstname);
            gbUserEA.Controls.Add(labelLogin);
            gbUserEA.Controls.Add(textBoxPassword);
            gbUserEA.Controls.Add(labelUserRoleId);
            gbUserEA.Dock = DockStyle.Fill;
            gbUserEA.Location = new Point(0, 0);
            gbUserEA.Name = "gbUserEA";
            gbUserEA.Size = new Size(360, 600);
            gbUserEA.TabIndex = 0;
            gbUserEA.TabStop = false;
            gbUserEA.Text = "Uživatel";
            gbUserEA.Enter += gbUserEA_Enter;
            // 
            // textBoxErrors
            // 
            textBoxErrors.BackColor = SystemColors.Info;
            textBoxErrors.Font = new Font("Segoe UI", 10F);
            textBoxErrors.ForeColor = Color.Red;
            textBoxErrors.Location = new Point(55, 405);
            textBoxErrors.Multiline = true;
            textBoxErrors.Name = "textBoxErrors";
            textBoxErrors.ReadOnly = true;
            textBoxErrors.Size = new Size(288, 154);
            textBoxErrors.TabIndex = 18;
            // 
            // lblErrors
            // 
            lblErrors.AutoSize = true;
            lblErrors.Location = new Point(12, 405);
            lblErrors.Name = "lblErrors";
            lblErrors.Size = new Size(37, 20);
            lblErrors.TabIndex = 17;
            lblErrors.Text = "Log:";
            // 
            // btnPasswordCreate
            // 
            btnPasswordCreate.Location = new Point(314, 128);
            btnPasswordCreate.Name = "btnPasswordCreate";
            btnPasswordCreate.Size = new Size(30, 30);
            btnPasswordCreate.TabIndex = 5;
            btnPasswordCreate.UseVisualStyleBackColor = true;
            // 
            // textBoxPasswordCreate
            // 
            textBoxPasswordCreate.Location = new Point(85, 129);
            textBoxPasswordCreate.Name = "textBoxPasswordCreate";
            textBoxPasswordCreate.Size = new Size(223, 27);
            textBoxPasswordCreate.TabIndex = 4;
            // 
            // comboBoxUserRoleId
            // 
            comboBoxUserRoleId.FormattingEnabled = true;
            comboBoxUserRoleId.Location = new Point(129, 29);
            comboBoxUserRoleId.Name = "comboBoxUserRoleId";
            comboBoxUserRoleId.Size = new Size(125, 28);
            comboBoxUserRoleId.TabIndex = 1;
            // 
            // textBoxPhoneNumber2
            // 
            textBoxPhoneNumber2.Location = new Point(127, 360);
            textBoxPhoneNumber2.Name = "textBoxPhoneNumber2";
            textBoxPhoneNumber2.Size = new Size(217, 27);
            textBoxPhoneNumber2.TabIndex = 11;
            // 
            // textBoxPhoneNumber1
            // 
            textBoxPhoneNumber1.Location = new Point(127, 321);
            textBoxPhoneNumber1.Name = "textBoxPhoneNumber1";
            textBoxPhoneNumber1.Size = new Size(217, 27);
            textBoxPhoneNumber1.TabIndex = 10;
            // 
            // labelPhoneNum2
            // 
            labelPhoneNum2.AutoSize = true;
            labelPhoneNum2.Location = new Point(7, 363);
            labelPhoneNum2.Name = "labelPhoneNum2";
            labelPhoneNum2.Size = new Size(99, 20);
            labelPhoneNum2.TabIndex = 16;
            labelPhoneNum2.Text = "Telefonní č. 2:";
            // 
            // labelPhoneNum1
            // 
            labelPhoneNum1.AutoSize = true;
            labelPhoneNum1.Location = new Point(6, 324);
            labelPhoneNum1.Name = "labelPhoneNum1";
            labelPhoneNum1.Size = new Size(99, 20);
            labelPhoneNum1.TabIndex = 15;
            labelPhoneNum1.Text = "Telefonní č. 1:";
            // 
            // textBoxCompanyName
            // 
            textBoxCompanyName.Location = new Point(86, 278);
            textBoxCompanyName.Name = "textBoxCompanyName";
            textBoxCompanyName.Size = new Size(258, 27);
            textBoxCompanyName.TabIndex = 9;
            // 
            // labelCompanyName
            // 
            labelCompanyName.AutoSize = true;
            labelCompanyName.Location = new Point(7, 285);
            labelCompanyName.Name = "labelCompanyName";
            labelCompanyName.Size = new Size(49, 20);
            labelCompanyName.TabIndex = 13;
            labelCompanyName.Text = "Firma:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(85, 241);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(259, 27);
            textBoxEmail.TabIndex = 8;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(6, 244);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(49, 20);
            labelEmail.TabIndex = 11;
            labelEmail.Text = "Email:";
            // 
            // textBoxLastname
            // 
            textBoxLastname.Location = new Point(86, 204);
            textBoxLastname.Name = "textBoxLastname";
            textBoxLastname.Size = new Size(258, 27);
            textBoxLastname.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 207);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 9;
            label1.Text = "Přijmení:";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(250, 565);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 12;
            buttonSave.Text = "Uložit";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // labelFirstname
            // 
            labelFirstname.AutoSize = true;
            labelFirstname.Location = new Point(7, 169);
            labelFirstname.Name = "labelFirstname";
            labelFirstname.Size = new Size(55, 20);
            labelFirstname.TabIndex = 6;
            labelFirstname.Text = "Jméno:";
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(86, 63);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(258, 27);
            textBoxLogin.TabIndex = 2;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(6, 103);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(50, 20);
            labelPassword.TabIndex = 4;
            labelPassword.Text = "Heslo:";
            // 
            // textBoxFirstname
            // 
            textBoxFirstname.Location = new Point(86, 166);
            textBoxFirstname.Name = "textBoxFirstname";
            textBoxFirstname.Size = new Size(258, 27);
            textBoxFirstname.TabIndex = 6;
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Location = new Point(7, 66);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(49, 20);
            labelLogin.TabIndex = 2;
            labelLogin.Text = "Login:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(85, 96);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(258, 27);
            textBoxPassword.TabIndex = 3;
            // 
            // labelUserRoleId
            // 
            labelUserRoleId.AutoSize = true;
            labelUserRoleId.Location = new Point(6, 32);
            labelUserRoleId.Name = "labelUserRoleId";
            labelUserRoleId.Size = new Size(105, 20);
            labelUserRoleId.TabIndex = 0;
            labelUserRoleId.Text = "Role uživatele:";
            // 
            // dlgUserEA
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gbUserEA);
            Name = "dlgUserEA";
            Size = new Size(360, 600);
            gbUserEA.ResumeLayout(false);
            gbUserEA.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbUserEA;
        private Label labelUserRoleId;
        private TextBox textBoxPassword;
        private Label labelLogin;
        private TextBox textBoxFirstname;
        private Label labelPassword;
        private TextBox textBoxLogin;
        private Label labelFirstname;
        private Button buttonSave;
        private Label label1;
        private TextBox textBoxLastname;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Label labelCompanyName;
        private TextBox textBoxCompanyName;
        private Label labelPhoneNum2;
        private Label labelPhoneNum1;
        private TextBox textBoxPhoneNumber2;
        private TextBox textBoxPhoneNumber1;
        private ComboBox comboBoxUserRoleId;
        private TextBox textBoxPasswordCreate;
        private Button btnPasswordCreate;
        private Label lblErrors;
        private TextBox textBoxErrors;
    }
}
