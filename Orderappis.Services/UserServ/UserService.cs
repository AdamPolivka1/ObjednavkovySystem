using Npgsql;
using Orderis.Data;
using Orderis.Data.Model;

namespace Orderappis.Services.UserServ
{
    public class UserService
    {
        public UserService() { }

        public User? GetUserById(int userId)
        {
            User? user = null;

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
                /*
                int userId,
                int userRoleId,
                string login,
                string password,
                string firstname,
                string lastname,
                string email,
                string companyName,
                string phoneNum1,
                string? phoneNum2
                 */
                user = new User
                (
                    reader.GetInt32(reader.GetOrdinal("user_id")),
                    reader.GetInt32(reader.GetOrdinal("user_role_id")),
                    reader.GetString(reader.GetOrdinal("login")),
                    reader.GetString(reader.GetOrdinal("password")),
                    reader.GetString(reader.GetOrdinal("firstname")),
                    reader.GetString(reader.GetOrdinal("lastname")),
                    reader.GetString(reader.GetOrdinal("email")),
                    reader.GetString(reader.GetOrdinal("company_name")),
                    reader.GetString(reader.GetOrdinal("phone_num1")),
                    reader.IsDBNull(reader.GetOrdinal("phone_num2"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("phone_num2"))
                );
            }

            DbConnProvider.Instance.ConnClose();
            return user;
        }


        public User? GetUserByEmail(string email)
        {
            User? user = null;

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
                (
                    reader.GetInt32(reader.GetOrdinal("user_id")),
                    reader.GetInt32(reader.GetOrdinal("user_role_id")),
                    reader.GetString(reader.GetOrdinal("login")),
                    reader.GetString(reader.GetOrdinal("password")),
                    reader.GetString(reader.GetOrdinal("firstname")),
                    reader.GetString(reader.GetOrdinal("lastname")),
                    reader.GetString(reader.GetOrdinal("email")),
                    reader.GetString(reader.GetOrdinal("company_name")),
                    reader.GetString(reader.GetOrdinal("phone_num1")),
                    reader.IsDBNull(reader.GetOrdinal("phone_num2"))
                        ? null
                        : reader.GetString(reader.GetOrdinal("phone_num2"))
                );
            }

            DbConnProvider.Instance.ConnClose();
            return user;
        }

    }
}
