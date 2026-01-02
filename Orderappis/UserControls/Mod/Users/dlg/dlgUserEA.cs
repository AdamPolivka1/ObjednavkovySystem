using Npgsql;
using Orderappis.Services.UserServ;
using Orderis.Data;
using Orderis.Data.Model;
using Orderis.Services.Auth;
using System.Data;
using System.Text.RegularExpressions;

namespace Orderappis.UserControls.Mod.Users.dlg
{
    public partial class dlgUserEA : UserControl
    {
        private UserService _userService { get; set; }
        public User UserModel { get; set; }
        public bool AllowEdit { get; private set; }
        public bool AllowInsert { get; private set; }

        public dlgUserEA()
        {
            InitializeComponent();
            SetDefaults();
            _userService = new UserService();
        }

        private void SetDefaults()
        {
            UserModel = new User();
            UserModel.UserId = 0;
            UserModel.UserRoleId = 1;
            AllowEdit = false;
            AllowInsert = false;
            buttonSave.Cursor = Cursors.Hand;

            //btnPasswordCreate
            string baseDir = Directory.GetCurrentDirectory();
            string pathUserPng = Path.Combine(baseDir, "Images", "lock.ico");

            if (File.Exists(pathUserPng))
            {
                btnPasswordCreate.Image = Image.FromFile(pathUserPng);
            }
            btnPasswordCreate.Click += btnPasswordCreate_Click;
        }

        private void btnPasswordCreate_Click(Object Sender, EventArgs eventArgs)
        {
            string plainText = textBoxPasswordCreate.Text;
            if (plainText != "")
                textBoxPassword.Text = AuthService.Instance.HashPassword(plainText);
        }

        private void BindUserToControls()
        {
            comboBoxUserRoleId.DataBindings.Add(
                "SelectedValue",
                UserModel,
                "UserRoleId",
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );
            textBoxLogin.DataBindings.Add("Text", UserModel, "Login", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxPassword.DataBindings.Add("Text", UserModel, "Password", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxFirstname.DataBindings.Add("Text", UserModel, "Firstname", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxLastname.DataBindings.Add("Text", UserModel, "Lastname", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxEmail.DataBindings.Add("Text", UserModel, "Email", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxCompanyName.DataBindings.Add("Text", UserModel, "CompanyName", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxPhoneNumber1.DataBindings.Add("Text", UserModel, "PhoneNum1", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxPhoneNumber2.DataBindings.Add("Text", UserModel, "PhoneNum2", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public bool LoadData()
        {
            try
            {
                // load other data
                var editUser = _userService.GetUserById(UserModel.UserId);
                if (editUser != null)
                {
                    UserModel = editUser;
                }

                comboBoxUserRoleId.DropDownStyle = ComboBoxStyle.DropDownList;

                DataTable dtRoles = new DataTable();
                string sql = "SELECT user_role_id as UserRoleId, name as Name FROM amain.user_role ORDER BY user_role_id ASC";

                using (var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn))
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    adapter.Fill(dtRoles);
                }

                DbConnProvider.Instance.ConnClose();

                comboBoxUserRoleId.DataSource = dtRoles;
                comboBoxUserRoleId.ValueMember = "UserRoleId";
                comboBoxUserRoleId.DisplayMember = "Name";

                // bind user to controls
                BindUserToControls();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při načítání rolí", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        

        public List<string> Validate()
        {
            List<string> errors = new List<string>();

            if (UserModel.UserId < 0)
                errors.Add("UserId musí být kladné číslo.");

            if (UserModel.UserRoleId <= 0)
                errors.Add("Není vybraná role.");

            if (string.IsNullOrWhiteSpace(UserModel.Login))
                errors.Add("Login nesmí být prázdný.");
            else if (UserModel.Login.Length < 3)
                errors.Add("Login musí mít alespoň 3 znaky.");

            if (string.IsNullOrWhiteSpace(UserModel.Password))
                errors.Add("Heslo nesmí být prázdné.");

            if (string.IsNullOrWhiteSpace(UserModel.Firstname))
                errors.Add("Jméno nesmí být prázdné.");

            if (string.IsNullOrWhiteSpace(UserModel.Lastname))
                errors.Add("Příjmení nesmí být prázdné.");

            if (string.IsNullOrWhiteSpace(UserModel.Email))
            {
                errors.Add("Email nesmí být prázdný.");
            }
            else
            {
                if (!Regex.IsMatch(UserModel.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                    errors.Add("Email není ve správném formátu (např. karel.krejci@email.com).");
            }

            // Telefon 1 (povinný, přesně 9 číslic)
            if (string.IsNullOrWhiteSpace(UserModel.PhoneNum1))
            {
                errors.Add("Telefon 1 nesmí být prázdný.");
            }
            else if (!Regex.IsMatch(UserModel.PhoneNum1, @"^\d{9}$"))
            {
                errors.Add("Telefon 1 musí mít přesně 9 číslic.");
            }

            // Telefon 2 (volitelný, pokud není prázdný, musí být 9 číslic)
            if (!string.IsNullOrWhiteSpace(UserModel.PhoneNum2) && !Regex.IsMatch(UserModel.PhoneNum2, @"^\d{9}$"))
            {
                errors.Add("Telefon 2 musí mít přesně 9 číslic.");
            }


            if (string.IsNullOrWhiteSpace(UserModel.CompanyName))
                errors.Add("Firma musí být vyplněná.");

            return errors;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var errors = Validate();

            if (errors.Count > 0)
            {
                textBoxErrors.Text = string.Join(Environment.NewLine, errors);
                return;
            }
            else
            {
                textBoxErrors.Text = "";
            }

            if (UserModel.UserId != 0) // edit mode
            {
                AllowEdit = true;
            }
            else // insert mode
            {
                AllowInsert = true;
            }
            var parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.DialogResult = DialogResult.OK;
                parentForm.Close();
            }
        }

        private void gbUserEA_Enter(object sender, EventArgs e) {}

    }
}
