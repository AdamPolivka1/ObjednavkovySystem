using Npgsql;
using Orderappis.Data.Model;
using Orderis.Data;

namespace Orderappis.UserControls.Mod.Orders.dlg
{
    public partial class dlgPaymentE : UserControl
    {
        public int PaymentId { get; set; }

        public dlgPaymentE()
        {
            InitializeComponent();
            SetDefaults();
        }

        private void SetDefaults()
        {
            // cBoxPaymentMethod
            List<PaymentStatus> listVals = new List<PaymentStatus>();
            listVals.Add(new PaymentStatus(0, "Storno"));
            listVals.Add(new PaymentStatus(1, "Platná"));

            comboBoxStatus.DataSource = listVals;
            comboBoxStatus.DisplayMember = "Name";
            comboBoxStatus.ValueMember = "Id";
            comboBoxStatus.SelectedIndex = 0;
        }

        public void LoadData()
        {
            string sqlLoad = @"SELECT p.payment_id as PaymentId,
                 p.status as Status, p.note as Note, o.order_id
                 FROM amain.payment p
                 LEFT JOIN amain.""order"" o ON p.payment_id = o.payment_id 
                 WHERE p.payment_id = @PaymentId";

            using (var cmd = new NpgsqlCommand(sqlLoad, DbConnProvider.Instance.Conn))
            {
                cmd.Parameters.AddWithValue("@PaymentId", PaymentId);

                using var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int status = reader.GetInt32(1);
                    string note = "";
                    int? orderId = null;
                    
                    if (!reader.IsDBNull(2))
                        note = reader.GetString(2);

                    if (!reader.IsDBNull(3))
                        orderId = reader.GetInt32(3);

                    comboBoxStatus.SelectedValue = status;
                    textBoxNote.Text = note;
                    textBoxOrderId.Text = orderId.ToString(); 
                }
            }
        }

        private int UpdatePayment()
        {
            List<string> errorsList = new List<string>();
            // zkotrnluj zda existuje objednávka
            string orderIdStr = textBoxOrderId.Text;
            int orderId = -1;
            try
            {
                orderId = Convert.ToInt32(orderIdStr);
                ///
                string findOrderSql = @"Select order_id From amain.""order""
                    Where order_id = @OrderId";
                using (var cmd = new NpgsqlCommand(findOrderSql, DbConnProvider.Instance.Conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", NpgsqlTypes.NpgsqlDbType.Integer, orderId);

                    using var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("order_id")))
                        {
                            orderId = reader.GetInt32(0);
                        }
                        else
                        {
                            errorsList.Add("Objednávka nenalezena.");
                        }
                    }
                    else
                    {
                        errorsList.Add("Objednávka nenalezena.");
                    }
                }
                ////
            }
            catch
            {
                errorsList.Add("Id objednávky je nevalidní.");
            }

            if (errorsList.Count > 0)
            {
                string errorsLines = string.Join(Environment.NewLine, errorsList);
                textBoxErrors.Text = errorsLines;
                return -1;
            }

            var selectedVal = comboBoxStatus.SelectedValue;
            
            int status = -1;
            if (selectedVal != null)
                status = (int)selectedVal;    
            
            string note = textBoxNote.Text;

            string sqlUpdate = "UPDATE amain.payment" +
                " SET status = @Status, note = @Note" +
                " WHERE payment_id = @PaymentId";

            if (status == -1)
            {
                sqlUpdate = "UPDATE amain.payment" +
                    " SET note = @Note" +
                    " WHERE payment_id = @PaymentId";
            }

             using (var cmd = new NpgsqlCommand(sqlUpdate, DbConnProvider.Instance.Conn))
             {
                if (status != -1)
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                }
                cmd.Parameters.AddWithValue("@Note", note);
                cmd.Parameters.AddWithValue("@PaymentId", PaymentId);

                cmd.ExecuteNonQuery();

                // update order
                string sqlUO = @"
                            UPDATE amain.""order""
                            SET payment_id=@PaymentId,
                                updated_at=CURRENT_TIMESTAMP
                            WHERE order_id=@OrderId
                            ";
                using (var cmd2 = new NpgsqlCommand(sqlUO, DbConnProvider.Instance.Conn))
                {
                    cmd2.Parameters.AddWithValue("@PaymentId", PaymentId);
                    cmd2.Parameters.AddWithValue("@OrderId", orderId);

                    cmd2.ExecuteNonQuery();

                    return 1;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (UpdatePayment() != -1)
            {
                // zavření parent formu
                var parentForm = this.FindForm();
                if (parentForm != null)
                {
                    parentForm.DialogResult = DialogResult.OK;
                    parentForm.Close();
                }
            }
        }

    }
}
