using Npgsql;
using Orderis.Data;
using Orderis.Data.Model;

namespace Orderappis.Services.UserServ
{
    public class UserService
    {
        public UserService() { }

        public User GetUserById(int userId)
        {
            User user = null;

            string sql = @"SELECT user_id,
                user_role_id,
                login,
                password,
                firstname,
                lastname,
                email,
                company_name,
                phone_num1,
                phone_num2
            FROM amain.user
            WHERE user_id = @userId";

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


        public User GetUserByEmail(string email)
        {
            User user = null;

            string sql = @"SELECT user_id,
                user_role_id,
                login,
                password,
                firstname,
                lastname,
                email,
                company_name,
                phone_num1,
                phone_num2
            FROM amain.user
            WHERE email = @email";

            using var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);
            cmd.Parameters.AddWithValue("@email", email);

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

    }
}
