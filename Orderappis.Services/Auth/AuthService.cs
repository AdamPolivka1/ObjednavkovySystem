using Npgsql;
using Orderis.Data;
using Orderis.Data.Model;

namespace Orderis.Services.Auth
{
    public class AuthService
    {
        private static AuthService? _instance;
        private AuthService() { }

        public static AuthService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AuthService();
                return _instance;
            }
        }

        public User? CurrentUser { get; private set; }

        public string HashPassword(string plainText)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainText);
        }

        public bool VerifyPassword(string plainText, string hashed)
        {
            return BCrypt.Net.BCrypt.Verify(plainText, hashed);
        }

        public bool StartLoginAction(string username, string password)
        {
            string sql = @"SELECT user_id, user_role_id, login, ""password"",
                firstname, lastname, email,
                company_name, phone_num1, phone_num2
            FROM amain.""user""
            WHERE login = @login";

            using var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);
            cmd.Parameters.AddWithValue("@login", NpgsqlTypes.NpgsqlDbType.Varchar, username);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string storedPassword = reader.GetString(3); // =password
                if (VerifyPassword(password, storedPassword))
                {
                    CurrentUser = new User(
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetString(2),
                        storedPassword,
                        reader.GetString(4),
                        reader.GetString(5),
                        reader.GetString(6),
                        reader.GetString(7),
                        reader.GetString(8),
                        reader.IsDBNull(9) ? null : reader.GetString(9)
                    );

                    DbConnProvider.Instance.ConnClose();
                    return true;
                }
            }

            DbConnProvider.Instance.ConnClose();
            return false;
        }

        public bool InUserRole(string roleName)
        {
            if (CurrentUser == null)
                return false;

            string sql = @"SELECT user_role_id 
                FROM amain.user_role 
                WHERE ""name"" = @roleName";

            using var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);
            cmd.Parameters.AddWithValue("@roleName", NpgsqlTypes.NpgsqlDbType.Varchar, roleName);

            object? result = cmd.ExecuteScalar();
            DbConnProvider.Instance.ConnClose();

            if (result != null && int.TryParse(result.ToString(), out int roleId))
                return CurrentUser.UserRoleId == roleId;

            return false;
        }

        public string GetCurrentUserRole() 
        {
            if (CurrentUser == null)
                return "";

            string sql = @"SELECT 
                    ur.name as Name
                FROM amain.""user"" u
                JOIN amain.user_role ur
                    ON u.user_role_id = ur.user_role_id
                WHERE user_id = @UserId";

            using var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);
            cmd.Parameters.AddWithValue("@UserId", AuthService.Instance.CurrentUser.UserId);

            object? result = cmd.ExecuteScalar();
            DbConnProvider.Instance.ConnClose();

            return result?.ToString() ?? "";
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }

}
