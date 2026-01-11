using Npgsql;
using Orderis.Data;
using Orderis.Data.Model;

namespace Orderappis.Data.Repositories
{
    public class CustomerAccountRepository
    {
        public CustomerAccount? GetByUserEmail(string email)
        {
            CustomerAccount? customerAccount = null;

            string sql = @"SELECT ca.customer_account_id,
            ca.user_id,
            ca.created_at,
            ca.valid_to
            FROM amain.customer_account ca
            JOIN amain.""user"" u on
            ca.user_id = u.user_id
            where u.email = @email";

            using var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);
            cmd.Parameters.AddWithValue("@email", email);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                customerAccount = new CustomerAccount()
                {
                    CustomerAccountId = reader.GetInt32(reader.GetOrdinal("customer_account_id")),
                    UserId = reader.GetInt32(reader.GetOrdinal("user_id")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("created_at")),
                    ValidTo = reader.GetDateTime(reader.GetOrdinal("valid_to"))
                };
            }

            DbConnProvider.Instance.ConnClose();
            return customerAccount;
        }
    }
}
