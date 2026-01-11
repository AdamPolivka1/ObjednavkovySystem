using Orderappis.Data.Model;
using System.Globalization;
using Orderis.Data.Model;
using Orderappis.Data.Repositories;
using Npgsql;
using Orderis.Data;

namespace Orderappis.UserControls.Mod.Orders.dlg
{
    public partial class dlgOrderA : UserControl
    {
        private Delivery DeliveryModel { get; set; }
        private Order OrderModel { get; set; }
        private CustomerAccountRepository _caRepository;
        private List<DeliveryTypes> _deliveryTypes { get; set; }

        public dlgOrderA()
        {
            InitializeComponent();
            SetDeliveryTypes();
            _caRepository = new CustomerAccountRepository();
            DeliveryModel = new Delivery();
            OrderModel = new Order();
            _deliveryTypes = new List<DeliveryTypes>();
        }

        private void SetDeliveryTypes()
        {
            _deliveryTypes = new List<DeliveryTypes>() {
                new DeliveryTypes(1, "express"),
                new DeliveryTypes(2, "24h"),
                new DeliveryTypes(3, "basic")
            };
            comboBoxDeliveryType.Items.Clear();
            comboBoxDeliveryType.DisplayMember = "DeliveryTypeName";
            comboBoxDeliveryType.ValueMember = "DeliveryTypeId";
            comboBoxDeliveryType.DataSource = _deliveryTypes;
            comboBoxDeliveryType.SelectedValue = 1;
        }

        private List<string> CheckErrors()
        {
            List<string> errors = new List<string>();

            string customerEmail = textBoxCustomerEmail.Text;
            var customerAccount = _caRepository.GetByUserEmail(customerEmail);
            if (customerAccount == null)
            {
                errors.Add("Zákazník neexistuje.");
            }
            else
            {
                OrderModel.CustomerAccountId = customerAccount.CustomerAccountId;
            }

            // price delivery
            decimal price = numericUpDownOrderPrice.Value;
            OrderModel.TotalPriceCZK = price;
            // end price delivery

            OrderModel.Status = 1;
            DeliveryModel.PriceCZK = 0;

            if (!checkBoxCreateDelivery.Checked) // vynech kontrolu delivery
            {
                return errors;
            }
            ///////////////////////////////////////////////////////////////////////

            // price delivery
            decimal priceDelivery = numericUpDownDeliveryPrice.Value;
            DeliveryModel.PriceCZK = priceDelivery;
            OrderModel.TotalPriceCZK += price;
            // end price delivery

            string textDeliveryAddress = textBoxDeliveryAddress.Text;
            if (string.IsNullOrEmpty(textDeliveryAddress))
            {
                errors.Add("Adresa doručení není vyplněná.");
            }
            else
            {
                DeliveryModel.DeliveryAddress = textDeliveryAddress;
            }

            var deliveryDate = dateTimePickerDeliveryDate.Value;
            if (deliveryDate <= DateTime.Now)
            {
                errors.Add("Datum doručení je nevalidní.");
            }
            else
            {
                DeliveryModel.DeliveryDate = deliveryDate;
            }

            if (textBoxNote.Text.Length > 0)
            {
                DeliveryModel.Note = textBoxNote.Text;
            }
            else
            {
                DeliveryModel.Note = "";
            }

            DeliveryModel.DeliveryType = comboBoxDeliveryType.SelectedIndex + 1;
            DeliveryModel.Status = 0; // nedoruřena

            return errors;
        }

        private int SaveDelivery()
        {
            string sql = @"
                INSERT INTO amain.delivery
                (delivery_type, delivery_date, delivery_address, status, price_czk, note)
                VALUES(@type, @date, @address, @status, @price, @note) RETURNING delivery_id
            ";

            using (var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn))
            {
                cmd.Parameters.AddWithValue("@type", NpgsqlTypes.NpgsqlDbType.Numeric, DeliveryModel.DeliveryType);
                cmd.Parameters.AddWithValue("@date", NpgsqlTypes.NpgsqlDbType.Timestamp, DeliveryModel.DeliveryDate.Date);
                cmd.Parameters.AddWithValue("@address", NpgsqlTypes.NpgsqlDbType.Text, DeliveryModel.DeliveryAddress);
                cmd.Parameters.AddWithValue("@status", NpgsqlTypes.NpgsqlDbType.Integer, DeliveryModel.Status);
                cmd.Parameters.AddWithValue("@price", NpgsqlTypes.NpgsqlDbType.Money, DeliveryModel.PriceCZK);
                cmd.Parameters.AddWithValue("@note", NpgsqlTypes.NpgsqlDbType.Text, DeliveryModel.Note == null ? (object)DBNull.Value : DeliveryModel.Note);

                var returnObj = cmd.ExecuteScalar();
                if (returnObj != null)
                {
                    return (int)returnObj;
                } else { return -1; }
            }
        }

        private int SaveOrder(int? DeliveryId)
        {
            string sql = @"
                INSERT INTO amain.order
                (payment_id, customer_account_id, delivery_id, total_price_czk, status, ordered_at, updated_at)
                VALUES(null, @customer, @delivery, @total, @status, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)
            ";

            using (var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn))
            {
                cmd.Parameters.AddWithValue("@customer", NpgsqlTypes.NpgsqlDbType.Integer, OrderModel.CustomerAccountId);
                if (DeliveryId != null)
                    cmd.Parameters.AddWithValue("@delivery", NpgsqlTypes.NpgsqlDbType.Integer, (int)DeliveryId);
                else
                    cmd.Parameters.AddWithValue("@delivery", NpgsqlTypes.NpgsqlDbType.Integer, (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@total", NpgsqlTypes.NpgsqlDbType.Money, OrderModel.TotalPriceCZK + DeliveryModel.PriceCZK);
                cmd.Parameters.AddWithValue("@status", NpgsqlTypes.NpgsqlDbType.Integer, OrderModel.Status);

                return cmd.ExecuteNonQuery();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var errors = CheckErrors();
            if (errors != null && errors.Count > 0)
            {
                textBoxErrors.Text = string.Join(Environment.NewLine, errors);
                return;
            }

            if (checkBoxCreateDelivery.Checked)
            {
                // save delivery
                int deliveryId = SaveDelivery();

                // save order
                if (deliveryId > 0)
                {
                    SaveOrder(deliveryId);
                }
                else
                {
                    MessageBox.Show("Nepodařlo se vytvořit dodání.");
                    return;
                }
            }
            else
            {
                SaveOrder(null);
            }

            var parentForm = FindForm();
            if (parentForm != null)
            {
                parentForm.DialogResult = DialogResult.OK;
                parentForm.Close();
            }
        }

        private void checkBoxCreateDelivery_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCreateDelivery.Checked)
            {
                groupBoxDelivery.Enabled = true;
            }
            else {
                groupBoxDelivery.Enabled = false;
            }
        }
    }
}
