using Npgsql;
using Orderappis.Data.Model;
using Orderis.Data;

namespace Orderappis.UserControls.Mod.Orders.dlg
{
    public partial class dlgDeliveryEA : UserControl
    {
        private int DeliveryId { get; set; }

        private Boolean _insertMode;

        private Boolean _updateMode;
        
        public Boolean InsertMode {
            get { return _insertMode; }
            set {
                _insertMode = value;
                SetDefaults();
            }
        }

        public Boolean UpdateMode {
            get { return _updateMode; }
            set { 
                _updateMode = value;
                SetDefaults();
            }
        }

        public dlgDeliveryEA()
        {
            InitializeComponent();
            SetDefaults();
        }

        public void LoadData(int deliveryId)
        {
            DeliveryId = deliveryId;

            string sql = @"SELECT d.delivery_id as DeliveryId,
                d.delivery_type as DeliveryType,
                d.delivery_date as DeliveryDate,
                d.delivery_address as DeliveryAddress,
                d.status as Status, d.price_czk as PriceCZK,
                d.note as Note, o.order_id as OrderId
                FROM amain.delivery as d LEFT JOIN amain.""order"" as o
                ON d.delivery_id = o.delivery_id
                WHERE d.delivery_id = @DeliveryId";

            using (var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn))
            {
                cmd.Parameters.AddWithValue("@DeliveryId",
                    NpgsqlTypes.NpgsqlDbType.Integer,
                    deliveryId);

                using var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int deliveryId_Read = reader.GetInt32(0);
                    int deliveryType = reader.GetInt32(1);
                    DateTime deliveryDate = reader.GetDateTime(2);
                    string deliveryAddress = reader.GetString(3);
                    int deliveryStatus = reader.GetInt32(4);
                    decimal deliveryPrice = reader.GetDecimal(5);
                    string deliveryNote = reader.GetString(6);

                    string orderIdStr = string.Empty;
                    if (!reader.IsDBNull(7))
                        orderIdStr = reader.GetInt32(7).ToString();

                    comboBoxDeliveryType.SelectedValue = deliveryType;
                    dateTimePickerDeliveryDate.Value = deliveryDate;
                    textBoxAddress.Text = deliveryAddress;
                    comboBoxStatus.SelectedIndex = deliveryStatus;
                    numericUpDownPrice.Value = deliveryPrice;
                    textBoxNote.Text = deliveryNote;
                    textBoxOrderId.Text = orderIdStr;
                }

                if (UpdateMode)
                { 
                    textBoxOrderId.Enabled = false;
                }
            }
        }

        private void SetDefaults()
        {
            // typ
            // 1 = express, 2 = 24h, 3 = basic
            List<DeliveryTypes> listVals = new List<DeliveryTypes>();
            listVals.Add(new DeliveryTypes(1, "Express"));
            listVals.Add(new DeliveryTypes(2, "24h"));
            listVals.Add(new DeliveryTypes(3, "Basic"));

            comboBoxDeliveryType.DataSource = listVals;
            comboBoxDeliveryType.SelectedIndex = 0;
            comboBoxDeliveryType.DisplayMember = "Name";
            comboBoxDeliveryType.ValueMember = "Id";

            // status
            List<OrderStatus> listVals2 = new List<OrderStatus>();
            listVals2.Add(new OrderStatus(0, "Nedoručeno"));
            listVals2.Add(new OrderStatus(1, "Doručeno"));

            comboBoxStatus.DataSource = listVals2;
            comboBoxStatus.SelectedIndex = 0;
            comboBoxStatus.DisplayMember = "Name";
            comboBoxStatus.ValueMember = "Id";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {}

        private void buttonSave_Click(object sender, EventArgs e)
        {

            if (UpdateMode)
            {
                MessageBox.Show(
                    "V případě ruční změny objednávky se cena automaticky nepřepočítává.",
                    "Upozornění",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else {
                MessageBox.Show(
                    "K objednávce bude přičtena cena dopravy.",
                    "Upozornění",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }

            List<string> errorsList = new List<string>();

            // zkotroluj zda existuje objednávka
            string orderIdStr = textBoxOrderId.Text;
            int orderId = -1;
            int oldDeliveryId = -1;
            try
            {
                orderId = Convert.ToInt32(orderIdStr);
                ///
                string findOrderSql = @"Select order_id, delivery_id From amain.""order""
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
                        if (!reader.IsDBNull(reader.GetOrdinal("delivery_id")))
                        {
                            oldDeliveryId = reader.GetInt32(1);
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

            // kontrola zda už není přiřazeno k objednávce
            if (oldDeliveryId != -1) 
            {
                if (oldDeliveryId != DeliveryId)
                {
                    errorsList.Add("Objednávka již má přiřazenou dopravu.");
                }
            }

            var deliveryTypeVar = comboBoxDeliveryType.SelectedValue;

            int deliveryType = -1;
            if (deliveryTypeVar == null)
            {
                errorsList.Add("Nevalidní typ.");
            } else
            {
                deliveryType = (int)deliveryTypeVar;
                if (deliveryType < 0 || deliveryType > 3)
                {
                    errorsList.Add("Nevalidní typ.");
                }
            }

            DateTime deliveryDate = dateTimePickerDeliveryDate.Value;
            if (deliveryDate < DateTime.Now)
            {
                errorsList.Add("Nevalidní datum doručení.");
            }

            string deliveryAddress = textBoxAddress.Text;
            if (deliveryAddress == "")
            {
                errorsList.Add("Nevalidní adresa doručení.");
            }

            int deliveryStatus = comboBoxStatus.SelectedIndex;
            if (deliveryStatus < 0 || deliveryStatus > 2)
            {
                errorsList.Add("Status není správně.");
            }

            decimal deliveryPrice = numericUpDownPrice.Value;
            if (deliveryPrice < 0)
            {
                errorsList.Add("Nevalidní cena doručení.");
            }

            string deliveryNote = textBoxNote.Text;

            // zachycení chyb
            if (errorsList.Count > 0)
            {
                string errorsLines = string.Join(Environment.NewLine, errorsList);
                textBoxErrors.Text = errorsLines;
                return;
            }

            string sql = "";
            int retInsertDeliveryId = -1;
            if (InsertMode)
            {
                sql = "INSERT INTO amain.delivery (" +
                    "delivery_type," +
                    "delivery_date," +
                    "delivery_address," +
                    "status," +
                    "price_czk," +
                    "note) VALUES(@DeliveryType, @DeliveryDate, @DeliveryAddress," +
                    "@Status, @PriceCZK, @Note) RETURNING delivery_id";

                using (var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn))
                {
                    cmd.Parameters.AddWithValue("@DeliveryType",
                        NpgsqlTypes.NpgsqlDbType.Integer,
                        deliveryType);
                    cmd.Parameters.AddWithValue("@DeliveryDate",
                        NpgsqlTypes.NpgsqlDbType.Date,
                        deliveryDate);
                    cmd.Parameters.AddWithValue("@DeliveryAddress",
                        NpgsqlTypes.NpgsqlDbType.Text,
                        deliveryAddress);
                    cmd.Parameters.AddWithValue("@Status",
                        NpgsqlTypes.NpgsqlDbType.Integer,
                        deliveryStatus);
                    cmd.Parameters.AddWithValue("@PriceCZK",
                        NpgsqlTypes.NpgsqlDbType.Money,
                        deliveryPrice);
                    cmd.Parameters.AddWithValue("@Note",
                        NpgsqlTypes.NpgsqlDbType.Text,
                        deliveryNote);

                    // exec
                    var retInsertDeliveryIdVar = cmd.ExecuteScalar();
                    if (retInsertDeliveryIdVar != null) {
                        retInsertDeliveryId = Convert.ToInt32(retInsertDeliveryIdVar);
                        if (!(retInsertDeliveryId > 0))
                        {
                            textBoxErrors.Text = "Nepodařilo se vytvořit doručení.";
                            return;
                        }
                    }
                }
            }
            else
            {   //= UpdateMode
                sql = "UPDATE amain.delivery SET " +
                    "delivery_type=@DeliveryType," +
                    "delivery_date=@DeliveryDate," +
                    "delivery_address=@DeliveryAddress," +
                    "status=@Status," +
                    "price_czk=@PriceCZK," +
                    "note=@Note " +
                    "WHERE delivery_id=@DeliveryId";

                using (var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn))
                {
                    cmd.Parameters.AddWithValue("@DeliveryType",
                        NpgsqlTypes.NpgsqlDbType.Integer,
                        deliveryType);
                    cmd.Parameters.AddWithValue("@DeliveryDate",
                        NpgsqlTypes.NpgsqlDbType.Date,
                        deliveryDate);
                    cmd.Parameters.AddWithValue("@DeliveryAddress",
                        NpgsqlTypes.NpgsqlDbType.Text,
                        deliveryAddress);
                    cmd.Parameters.AddWithValue("@Status",
                        NpgsqlTypes.NpgsqlDbType.Integer,
                        deliveryStatus);
                    cmd.Parameters.AddWithValue("@PriceCZK",
                        NpgsqlTypes.NpgsqlDbType.Money,
                        deliveryPrice);
                    cmd.Parameters.AddWithValue("@Note",
                        NpgsqlTypes.NpgsqlDbType.Text,
                        deliveryNote);
                    cmd.Parameters.AddWithValue("@DeliveryId",
                        NpgsqlTypes.NpgsqlDbType.Integer,
                        DeliveryId);

                    // exec
                    cmd.ExecuteNonQuery();
                }
            }

            // Update Order ///////////////
            string sqlUpdateOrder = "";

            if (InsertMode)
            {
                sqlUpdateOrder = @"
                UPDATE amain.""order""
                SET delivery_id = @DeliveryId,
                    total_price_czk = total_price_czk + @DeliveryPrice,
                    updated_at = CURRENT_TIMESTAMP
                WHERE order_id = @OrderId;
                ";
            }

            if (UpdateMode)
            {
                sqlUpdateOrder = @"
                UPDATE amain.""order""
                SET delivery_id = @DeliveryId,
                    updated_at = CURRENT_TIMESTAMP
                WHERE order_id = @OrderId;
                ";
            }

            using (var cmd = new NpgsqlCommand(sqlUpdateOrder, DbConnProvider.Instance.Conn))
            {
                if (UpdateMode)
                {
                    cmd.Parameters.AddWithValue("@DeliveryId",
                        NpgsqlTypes.NpgsqlDbType.Integer,
                        DeliveryId);
                }

                if (InsertMode)
                {
                    cmd.Parameters.AddWithValue("@DeliveryId",
                        NpgsqlTypes.NpgsqlDbType.Integer,
                        retInsertDeliveryId);
                }

                cmd.Parameters.AddWithValue("@OrderId",
                    NpgsqlTypes.NpgsqlDbType.Integer,
                    orderId);

                cmd.Parameters.AddWithValue("@DeliveryPrice",
                    NpgsqlTypes.NpgsqlDbType.Numeric,
                    deliveryPrice);

                // exec
                cmd.ExecuteNonQuery();
            }
            ///////////////////////////////

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
