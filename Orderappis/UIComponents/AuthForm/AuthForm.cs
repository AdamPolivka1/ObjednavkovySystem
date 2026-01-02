using Orderis.Data;
using Orderis.Services.Auth;
namespace Orderappis.UIComponents.AuthForm
{
    public partial class AuthForm : Form
    {
        private bool ShowPassword { get; set; } = true;
        public Boolean IsLoggedIn { get; private set; } = false;

        public AuthForm()
        {
            InitializeComponent();
            SetDefaults();
        }

        private void SetDefaults()
        {
            btnShowPassword.Cursor = Cursors.Hand;
            btnSignin.Cursor = Cursors.Hand;
            StartPosition = FormStartPosition.CenterScreen;
            Icon = new Icon(@"Images\container.ico");
            HandleShowPassword();
        }

        private void HandleShowPassword()
        {
            ShowPassword = !ShowPassword;
            
            if (ShowPassword) {
                btnShowPassword.Image = Image.FromFile(@"Images\eye-off.png");
            }
            else {
                btnShowPassword.Image = Image.FromFile(@"Images\eye.png");
            }
            
            textBoxPassword.PasswordChar = ShowPassword ? '\0' : '*';
        }

        private void buttonSignin_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            string host = textBoxHost.Text;

            if (!string.IsNullOrEmpty(host) && host != "localhost")
                DbConnConfig.Instance.Host = textBoxHost.Text;

            try
            {
                if (AuthService.Instance.StartLoginAction(login, password))
                {
                    IsLoggedIn = true;
                    Close();
                }
                else
                {
                    lblError.Text = "Přihlášení se nezdařilo";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Přihlášení se nezdařilo (stat. 2)";
                DbConnProvider.ResetInstance();
            }
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            HandleShowPassword();
        }
    }
}
