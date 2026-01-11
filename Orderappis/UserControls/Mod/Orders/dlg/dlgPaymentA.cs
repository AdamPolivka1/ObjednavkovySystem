using Npgsql;
using Orderappis.Data.Model;
using Orderis.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Orderappis.UserControls.Mod.Orders.dlg
{
    public partial class dlgPaymentA : UserControl
    {
        public dlgPaymentA()
        {
            InitializeComponent();
            SetDefaults();
        }

        private void SetDefaults()
        {
            List<PaymentStatus> listVals = new List<PaymentStatus>();
            listVals.Add(new PaymentStatus(0, "Hotově"));
            listVals.Add(new PaymentStatus(1, "Kartou"));
            listVals.Add(new PaymentStatus(2, "Dobírka"));

            comboBoxPaymentMethod.DataSource = listVals;
            comboBoxPaymentMethod.DisplayMember = "Name";
            comboBoxPaymentMethod.ValueMember = "Id";
            comboBoxPaymentMethod.SelectedIndex = 0;
        }

        private bool CreatePayment()
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

            DateTime paymentDate = dateTimePickerPaymentDate.Value;

            var paymentMethodVar = comboBoxPaymentMethod.SelectedValue;
            int paymentMethod = 0;
            if (paymentMethodVar != null)
            {
                paymentMethod = (int)paymentMethodVar;
            }
            else
            {
                errorsList.Add("Chybná platební metoda.");
            }

            int status = 1; //= platná platba

            int totalCZK = 0; //= vždy platí pro celou objednávku
            
            string note = textBoxNote.Text;

            // zachycení chyb
            if (errorsList.Count > 0)
            {
                string errorsLines = string.Join(Environment.NewLine, errorsList);
                textBoxErrors.Text = errorsLines;
                return false;
            }

            var conn = DbConnProvider.Instance.Conn;
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    // INSERT
                    int paymentId = -1;
                    string sql = "INSERT INTO amain.payment " +
                    "(payment_date, payment_method, total_czk, status, note)" +
                    " VALUES(@PaymentDate, @PaymentMethod, @TotalCZK, @Status, @Note) RETURNING payment_id";

                    using (var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn))
                    {
                        cmd.Parameters.AddWithValue("@PaymentDate", paymentDate);
                        cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                        cmd.Parameters.AddWithValue("@TotalCZK", totalCZK);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@Note", note);

                        var resultData = cmd.ExecuteScalar();
                        if (resultData != null)
                        {
                            paymentId = (int)resultData;
                        }
                    }

                    sql = "UPDATE amain.\"order\" SET payment_id = @PaymentId Where order_id = @OrderId";

                    if (paymentId != -1)
                    {
                        using (var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn))
                        {
                            cmd.Parameters.AddWithValue("@PaymentId", paymentId);
                            cmd.Parameters.AddWithValue("@OrderId", orderId);
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    else
                    {
                        throw new Exception();
                    }
                } catch 
                { 
                    transaction.Rollback();
                    textBoxErrors.Text = "Chyba insertu.";
                    return false;
                }
            }

            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!CreatePayment())
            {
                return;
            }
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
