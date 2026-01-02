namespace Orderappis.UIComponents.AuthForm
{
    partial class AuthForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxLogin = new TextBox();
            textBoxPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnSignin = new Button();
            lblOrderappisHeader = new Label();
            lblError = new Label();
            btnShowPassword = new Button();
            labelHost = new Label();
            textBoxHost = new TextBox();
            SuspendLayout();
            // 
            // textBoxLogin
            // 
            textBoxLogin.Font = new Font("Segoe UI", 10F);
            textBoxLogin.Location = new Point(93, 117);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(361, 30);
            textBoxLogin.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Segoe UI", 10F);
            textBoxPassword.Location = new Point(93, 166);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(306, 30);
            textBoxPassword.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(7, 117);
            label1.Name = "label1";
            label1.Size = new Size(56, 23);
            label1.TabIndex = 2;
            label1.Text = "Login:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(7, 169);
            label2.Name = "label2";
            label2.Size = new Size(56, 23);
            label2.TabIndex = 3;
            label2.Text = "Heslo:";
            // 
            // btnSignin
            // 
            btnSignin.Font = new Font("Segoe UI", 10F);
            btnSignin.Location = new Point(7, 208);
            btnSignin.Name = "btnSignin";
            btnSignin.Size = new Size(94, 29);
            btnSignin.TabIndex = 5;
            btnSignin.Text = "Přihlásit se";
            btnSignin.UseVisualStyleBackColor = true;
            btnSignin.Click += buttonSignin_Click;
            // 
            // lblOrderappisHeader
            // 
            lblOrderappisHeader.AutoSize = true;
            lblOrderappisHeader.Font = new Font("Segoe UI", 12F);
            lblOrderappisHeader.Location = new Point(7, 9);
            lblOrderappisHeader.Name = "lblOrderappisHeader";
            lblOrderappisHeader.Size = new Size(95, 28);
            lblOrderappisHeader.TabIndex = 6;
            lblOrderappisHeader.Text = "Přihlášení";
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI", 10F);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(7, 37);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 23);
            lblError.TabIndex = 7;
            // 
            // btnShowPassword
            // 
            btnShowPassword.Location = new Point(405, 166);
            btnShowPassword.Name = "btnShowPassword";
            btnShowPassword.Size = new Size(49, 29);
            btnShowPassword.TabIndex = 8;
            btnShowPassword.UseVisualStyleBackColor = true;
            btnShowPassword.Click += btnShowPassword_Click;
            // 
            // labelHost
            // 
            labelHost.AutoSize = true;
            labelHost.Font = new Font("Segoe UI", 10F);
            labelHost.Location = new Point(7, 71);
            labelHost.Name = "labelHost";
            labelHost.Size = new Size(76, 23);
            labelHost.TabIndex = 9;
            labelHost.Text = "DB Host:";
            // 
            // textBoxHost
            // 
            textBoxHost.Font = new Font("Segoe UI", 10F);
            textBoxHost.Location = new Point(93, 68);
            textBoxHost.Name = "textBoxHost";
            textBoxHost.Size = new Size(361, 30);
            textBoxHost.TabIndex = 10;
            textBoxHost.Text = "localhost";
            // 
            // AuthForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(466, 246);
            Controls.Add(textBoxHost);
            Controls.Add(labelHost);
            Controls.Add(btnShowPassword);
            Controls.Add(lblError);
            Controls.Add(lblOrderappisHeader);
            Controls.Add(btnSignin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxLogin);
            Name = "AuthForm";
            Text = "OrderAppIS AuthForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
        private Label label1;
        private Label label2;
        private Button btnSignin;
        private Label lblOrderappisHeader;
        private Label lblError;
        private Button btnShowPassword;
        private Label labelHost;
        private TextBox textBoxHost;
    }
}