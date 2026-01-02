using Npgsql;
using Orderis.Data;
using Orderis.Data.Model;

namespace Orderappis.UserControls.Mod.Users.dlg
{
    public partial class dlgCustomerAccountA : UserControl
    {

        public bool InsertSuccess { get; private set; } = false;

        public dlgCustomerAccountA()
        {
            InitializeComponent();
        }

        private void Close() {
            var parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.DialogResult = DialogResult.OK;
                parentForm.Close();
            }
        }

        public int SaveCustomerAccount(int userId, DateTime selectedDate)
        {
            string sql = @"INSERT INTO amain.customer_account
                (user_id, created_at, valid_to)
                VALUES(:USER_ID, CURRENT_TIMESTAMP, :VALID_TO)";

            using var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);
            cmd.Parameters.AddWithValue("USER_ID", userId);
            cmd.Parameters.AddWithValue("VALID_TO", selectedDate);

            return cmd.ExecuteNonQuery(); //=1 if success
        }

        public User GetUserById(int userId)
        {
            User user = null;

            string sql = @"SELECT u.user_id,
                u.user_role_id,
                u.login,
                u.password,
                u.firstname,
                u.lastname,
                u.email,
                u.company_name,
                u.phone_num1,
                u.phone_num2
            FROM amain.user u
            LEFT JOIN amain.customer_account ca
                ON ca.user_id = u.user_id
            WHERE u.user_id = @userId
              AND ca.user_id IS NULL";

            using var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);
            cmd.Parameters.AddWithValue("@userId", userId);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                user = new User
                {
                    UserId = reader.GetInt32(reader.GetOrdinal("user_id")),
                    UserRoleId = reader.GetInt32(reader.GetOrdinal("user_role_id")),
                    Login = reader.GetString(reader.GetOrdinal("login")),
                    Password = reader.GetString(reader.GetOrdinal("password")),
                    Firstname = reader.GetString(reader.GetOrdinal("firstname")),
                    Lastname = reader.GetString(reader.GetOrdinal("lastname")),
                    Email = reader.GetString(reader.GetOrdinal("email")),
                    CompanyName = reader.GetString(reader.GetOrdinal("company_name")),
                    PhoneNum1 = reader.GetString(reader.GetOrdinal("phone_num1")),
                    PhoneNum2 = reader.IsDBNull(reader.GetOrdinal("phone_num2"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("phone_num2"))
                };
            }

            DbConnProvider.Instance.ConnClose();
            return user;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            List<string> errors = new List<string>();
            int userId = (int)numericUpDownUserId.Value;
            DateTime selectedDate = dateTimePickerValidTo.Value;

            var user = GetUserById(userId);
            // kontroly
            if (userId <= 0 || user == null)
            {
                errors.Add("Nevalidní uživatel");
            }

            if (selectedDate <= DateTime.Now)
            {
                errors.Add("Nevalidní datum platnosti");
            }

            if (errors.Count == 0)
            {
                // uložení záznamu
                if (SaveCustomerAccount(userId, selectedDate) == 1)
                {
                    InsertSuccess = true;
                    Close();
                }
                else {
                    textBoxErrors.Text = "Uživatelský účet nebyl uložen";
                }
            }
            else {
                // zobrazení chyb
                textBoxErrors.Text = string.Join(Environment.NewLine, errors);
                return;
            }

        }
    }
}
