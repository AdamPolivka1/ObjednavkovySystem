using Npgsql;
using Orderis.Data;
using Orderis.Data.Model;

namespace Orderappis.Data.Repositories
{
    public class OrderRepository
    {

        public Order GetById(int orderId)
        {
            string sql = @"
            SELECT ord.order_id, ord.payment_id, ord.customer_account_id,
            ord.delivery_id, ord.total_price_czk, ord.status,
            ord.ordered_at, ord.updated_at
            FROM amain.""order"" ord
            WHERE ord.order_id = @orderId
            ";

            using (var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn))
            {
                cmd.Parameters.AddWithValue("@orderId", orderId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Order
                        {
                            OrderId = reader.GetInt32(reader.GetOrdinal("order_id")),
                            PaymentId = reader.IsDBNull(reader.GetOrdinal("payment_id"))
                                        ? (int?)null
                                        : reader.GetInt32(reader.GetOrdinal("payment_id")),
                            CustomerAccountId = reader.GetInt32(reader.GetOrdinal("customer_account_id")),
                            DeliveryId = reader.IsDBNull(reader.GetOrdinal("delivery_id"))
                                         ? (int?)null
                                         : reader.GetInt32(reader.GetOrdinal("delivery_id")),
                            TotalPriceCZK = reader.GetDecimal(reader.GetOrdinal("total_price_czk")),
                            Status = reader.GetInt32(reader.GetOrdinal("status")),
                            OrderedAt = reader.GetDateTime(reader.GetOrdinal("ordered_at")),
                            UpdatedAt = reader.GetDateTime(reader.GetOrdinal("updated_at"))
                        };
                    }
                }
            }

            return null;
        }

        public int UpdateOrderStatusAndPrice(int status, decimal price, int orderId)
        {
            string sql = @"
            UPDATE amain.""order""
            SET
                status = @status,
                total_price_czk = @price 
            WHERE order_id = @orderId;
            ";

            using (var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn))
            {
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@orderId", orderId);
                return cmd.ExecuteNonQuery();
            }
        }

    }
}
