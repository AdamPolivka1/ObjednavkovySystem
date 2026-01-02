using Npgsql;
using Orderis.Data;
using Orderis.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderappis.Services.DeliveryServ
{
    public class DeliveryRepository
    {
        public int CreateDelivery(Delivery delivery)
        {
            string sql = @"INSERT INTO amain.delivery
            (delivery_type, delivery_date, delivery_address,
            status, price_czk, note)
            VALUES(@delivery_type, @delivery_date, @delivery_address,
            @status, @price_czk, @note)";

            using var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);
            cmd.Parameters.AddWithValue("@delivery_type", delivery.DeliveryType);
            cmd.Parameters.AddWithValue("@delivery_date", delivery.DeliveryDate);
            cmd.Parameters.AddWithValue("@delivery_address", delivery.DeliveryAddress);
            cmd.Parameters.AddWithValue("@status", delivery.Status);
            cmd.Parameters.AddWithValue("@price_czk", delivery.PriceCZK);
            cmd.Parameters.AddWithValue("@note", delivery.Note);

            var result = cmd.ExecuteNonQuery(); 

            DbConnProvider.Instance.ConnClose();
            // vrací počet afektovaných řádků
            // => (> 0) = (success)
            return result;
        }
    }
}
