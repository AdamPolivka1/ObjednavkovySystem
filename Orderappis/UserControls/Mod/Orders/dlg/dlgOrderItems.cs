using Npgsql;
using Orderis.Data;
using System.Data;

namespace Orderappis.UserControls.Mod.Orders.dlg
{
    public partial class dlgOrderItems : UserControl
    {
        public int OrderID { get; set; }

        // pag
        private int pageSize = 5;
        private int totalPages = 0;
        private int totalItems = 0;
        private int pageCurrent = 1;

        public dlgOrderItems()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            LoadProducts();
            ReloadOrderItemData();
            ApplyDefaultStyles();
        }

        private int GetSelectedProductId()
        {
            if (dataGridViewSource.Rows.Count == 0)
            {
                return -1;
            }

            if (dataGridViewSource.CurrentRow == null ||
                dataGridViewSource.CurrentRow.IsNewRow)
            {
                var firstRow = dataGridViewSource.Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(r => !r.IsNewRow);

                if (firstRow == null)
                    return -1;

                dataGridViewSource.CurrentCell = firstRow.Cells[0];
            }

            if (dataGridViewSource.CurrentRow?.DataBoundItem is DataRowView row)
            {
                return (int)row["ID"];
            }

            return -1;
        }

        private int GetSelectedOrderItemId()
        {
            if (dataGridViewOrderItems.Rows.Count == 0)
            {
                return -1;
            }

            if (dataGridViewOrderItems.CurrentRow == null)
            {
                dataGridViewOrderItems.CurrentCell =
                    dataGridViewOrderItems.Rows[0].Cells[0];
            }

            if (dataGridViewOrderItems.CurrentRow?.DataBoundItem is DataRowView row)
            {
                if (row["ID"] != DBNull.Value)
                {
                    int orderItemId = Convert.ToInt32(row["ID"]);
                    return orderItemId;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        private void LoadProducts()
        {
            string sqlCount = "SELECT COUNT(*) FROM amain.product";
            using (var cmd = new NpgsqlCommand(sqlCount, DbConnProvider.Instance.Conn))
            {
                var totalItemsV = cmd.ExecuteScalar();
                if (totalItemsV != null)
                {
                    totalItems = Convert.ToInt32(totalItemsV);
                }
                else
                {
                    MessageBox.Show(
                        "Nepodařilo se načíst data.",
                        "Chyba",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }
            }

            // OFFSET = (page_number - 1) * page_size
            totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            int limit = pageSize;
            int offset = (pageCurrent - 1) * pageSize;

            string sqlStr = @"SELECT p.product_id as ProductId, p.code as Code,
            p.""name"" as Name, p.available_qty as AvailableQty,
            p.price_czk as PriceCzk FROM amain.product p ORDER BY p.product_id ASC
            LIMIT @limit OFFSET @offset";

            using (var cmd = new NpgsqlCommand(sqlStr, DbConnProvider.Instance.Conn))
            {
                cmd.Parameters.AddWithValue("@limit", limit);
                cmd.Parameters.AddWithValue("@offset", offset);
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    // nastavení hlaviček sloupců
                    dt.Columns["ProductId"].ColumnName = "ID";
                    dt.Columns["Code"].ColumnName = "Kód";
                    dt.Columns["Name"].ColumnName = "Název";
                    dt.Columns["AvailableQty"].ColumnName = "Počet";
                    dt.Columns["PriceCzk"].ColumnName = "Cena CZK";

                    dataGridViewSource.DataSource = dt;
                }
            }

            // tlačítka
            btnFirst.Enabled = pageCurrent > 1;
            btnPrev.Enabled = pageCurrent > 1;
            btnNext.Enabled = pageCurrent < totalPages;
            btnLast.Enabled = pageCurrent < totalPages;

            lblCurrentPage.Text = pageCurrent.ToString();
        }

        private void PaginationButton_Click(object sender, EventArgs e)
        {
            if (sender == btnFirst) pageCurrent = 1;
            else if (sender == btnPrev) pageCurrent = Math.Max(1, pageCurrent - 1);
            else if (sender == btnNext) pageCurrent = Math.Min(totalPages, pageCurrent + 1);
            else if (sender == btnLast) pageCurrent = totalPages;

            RefreshData();
        }

        private void ApplyDefaultStyles()
        {
            buttonRemoveOrderItem.Image = Image.FromFile("Images\\trash.png");
            // dataGridViewSource
            var dgv = dataGridViewSource;
            dgv.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowTemplate.Height = 28;
            dgv.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            dgv.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = System.Drawing.Color.LightGray;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.AllowUserToResizeRows = false;
            dgv.ScrollBars = ScrollBars.Both;
            dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.MediumTurquoise;
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dgv.AllowUserToAddRows = false;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.MediumTurquoise;
            dgv.AllowUserToResizeColumns = false;
            // dataGridViewOrderItems
            dgv = dataGridViewOrderItems;
            dgv.SelectionChanged += DGV_OrderItems_SelectionChanged;
            dgv.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowTemplate.Height = 28;
            dgv.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            dgv.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = System.Drawing.Color.LightGray;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.AllowUserToResizeRows = false;
            dgv.ScrollBars = ScrollBars.Both;
            dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.MediumTurquoise;
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dgv.AllowUserToAddRows = false;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.MediumTurquoise;
            dgv.AllowUserToResizeColumns = false;
        }

        private void ReloadOrderItemData()
        {
            // aktuální stav produktu
            string sqlProduct = "SELECT " +
               "oi.qty, " +
               "oi.note " +
               "FROM amain.order_item oi" +
               " WHERE oi.order_id = @OrderId ORDER BY oi.order_item_id ASC";

            using (var cmd = new NpgsqlCommand(sqlProduct, DbConnProvider.Instance.Conn))
            {
                cmd.Parameters.AddWithValue("@OrderId", OrderID);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        numericUpDownQty.Value = reader.GetInt32(0);
                        if (!reader.IsDBNull(1))
                        {
                            textBoxNote.Text = reader.GetString(1);
                        }
                    }
                }
            }
            ///////////////////////////////////////
            string sqlCmd = @"SELECT oi.order_item_id as OrderItemId,
                  oi.product_id as ProductId,
                  oi.qty as Qty,
                  oi.note as Note
                FROM amain.order_item oi
                WHERE order_id = @orderId ORDER BY oi.order_item_id ASC";

            using (var cmd = new NpgsqlCommand(sqlCmd, DbConnProvider.Instance.Conn))
            {
                cmd.Parameters.AddWithValue("@orderId", OrderID);
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    // hlavičky
                    dt.Columns["OrderItemId"].ColumnName = "ID";
                    dt.Columns["ProductId"].ColumnName = "ID produktu";
                    dt.Columns["Qty"].ColumnName = "Počet";
                    dt.Columns["Note"].ColumnName = "Poznámka";
                    dataGridViewOrderItems.DataSource = dt;
                }
            }

            // update
            int orderItemId = GetSelectedOrderItemId();

            if (orderItemId == -1)
                return;

            string sqlCmdUpdate = @"Select qty as Qty, note as Note FROM amain.order_item
            WHERE order_item_id=@orderItemId";
            using (var cmd = new NpgsqlCommand(sqlCmdUpdate, DbConnProvider.Instance.Conn))
            {
                cmd.Parameters.AddWithValue("@orderItemId", orderItemId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            var qtyValue = reader.GetValue(0);
                            int qty = Convert.ToInt32(qtyValue);
                            numericUpDownQty.Value = qty;
                        }
                        else
                        {
                            numericUpDownQty.Value = 0;
                        }

                        if (!reader.IsDBNull(1))
                        {
                            var noteValue = reader.GetValue(1);
                            string note = (string)noteValue;
                            textBoxNote.Text = note;
                        }
                    }
                }
            }
        }

        private void buttonAddOrderItem_Click(object sender, EventArgs e)
        {
            string sqlInsert = "INSERT INTO amain.order_item (order_id, product_id, qty, note)" +
                               " VALUES(@OrderId, @ProductId, @Qty, @Note)";

            using (var cmd = new NpgsqlCommand(sqlInsert, DbConnProvider.Instance.Conn))
            {
                cmd.Parameters.AddWithValue("@OrderId", OrderID);
                cmd.Parameters.AddWithValue("@ProductId", GetSelectedProductId());
                cmd.Parameters.AddWithValue("@Qty", 0);
                cmd.Parameters.AddWithValue("@Note", DBNull.Value);
                cmd.ExecuteNonQuery();
            }

            RefreshData();
        }

        private void DGV_OrderItems_SelectionChanged(object? sender, EventArgs e)
        {
            int orderItemId = GetSelectedOrderItemId();
            string sqlProduct = "SELECT " +
                "oi.qty, oi.note FROM amain.order_item oi " +
                " WHERE order_item_id = @OrderItemId";
            int qty = 0;
            string note = "";

            using (var cmd = new NpgsqlCommand(sqlProduct, DbConnProvider.Instance.Conn))
            {
                cmd.Parameters.AddWithValue("@OrderItemId", orderItemId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        qty = reader.GetInt32(0);
                        numericUpDownQty.Value = qty;

                        if (!reader.IsDBNull(1))
                        {
                            note = reader.GetString(1);
                            textBoxNote.Text = note;
                        }
                    }
                    else
                    {
                        numericUpDownQty.Value = 0;
                        textBoxNote.Text = "";
                    }
                }
            }
        }

        private async void buttonRemoveOrderItem_Click(object sender, EventArgs e)
        {
            var conn = DbConnProvider.Instance.Conn;

            if (conn.State != ConnectionState.Open)
                conn.Open();

            using var transaction = await conn.BeginTransactionAsync();

            try
            {
                int orderItemId = GetSelectedOrderItemId();

                // 1) SMAZÁNÍ POLOŽKY A ZÍSKÁNÍ qty, product_id a order_id
                string sqlDelete = @"
                DELETE FROM amain.order_item 
                WHERE order_item_id = @OrderItemId 
                RETURNING qty, product_id, order_id";

                int backQty = 0;
                int productId = 0;
                int orderId = 0;

                using (var cmd = new NpgsqlCommand(sqlDelete, DbConnProvider.Instance.Conn))
                {
                    cmd.Parameters.AddWithValue("@OrderItemId", orderItemId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            backQty = reader.GetInt32(0);
                            productId = reader.GetInt32(1);
                            orderId = reader.GetInt32(2);
                        }
                        else
                        {
                            // položka neexistuje
                            return;
                        }
                    }
                }

                // === Pokud qty <= 0 nic se nevrací ===
                if (backQty <= 0)
                {
                    await transaction.CommitAsync();
                    RefreshData();
                    return;
                }

                // 2) PŘIČTENÍ ZPĚT DO SKLADU A ZÍSKÁNÍ VRÁCENÉ CENY
                string sqlUpdateQty = @"
                UPDATE amain.product 
                SET available_qty = available_qty + @qty 
                WHERE product_id = @productId
                RETURNING price_czk * @qty";

                decimal returnedPrice = 0;

                using (var cmd = new NpgsqlCommand(sqlUpdateQty, DbConnProvider.Instance.Conn))
                {
                    cmd.Parameters.AddWithValue("@qty", backQty);
                    cmd.Parameters.AddWithValue("@productId", productId);

                    var result = cmd.ExecuteScalar();
                    returnedPrice = Convert.ToDecimal(result);
                }

                // 3) ÚPRAVA CENY OBJEDNÁVKY PODLE order_id ZÍSKANÉHO Z RETURNING
                string sqlUpdateOrderPrice = @"
                UPDATE amain.""order"" 
                SET total_price_czk = total_price_czk - @returnedPrice
                WHERE order_id = @orderId";

                using (var cmd = new NpgsqlCommand(sqlUpdateOrderPrice, DbConnProvider.Instance.Conn))
                {
                    cmd.Parameters.AddWithValue("@returnedPrice", returnedPrice);
                    cmd.Parameters.AddWithValue("@orderId", orderId);
                    cmd.ExecuteNonQuery();
                }

                // COMMIT TRANSAKCE ===========
                await transaction.CommitAsync();

                RefreshData();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            var conn = DbConnProvider.Instance.Conn;

            if (conn.State != ConnectionState.Open)
                conn.Open();

            using var transaction = await conn.BeginTransactionAsync();

            try
            {
                int currentAvailableQty = (int)numericUpDownQty.Value;
                string? currentNote = textBoxNote.Text;

                if (currentAvailableQty <= 0)
                {
                    MessageBox.Show(
                        "Pro počet byla zadána nevalidní hodnota.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                if (currentNote == "")
                {
                    currentNote = null;
                }

                //////
                int orderItemId = GetSelectedOrderItemId();
                string sqlSelectDetail = @"SELECT oi.product_id, oi.qty FROM
                amain.order_item oi
                WHERE oi.order_item_id = @OrderItemId";
                int productId = 0;
                int orderItemQty = 0;

                using (var cmd = new NpgsqlCommand(sqlSelectDetail, DbConnProvider.Instance.Conn))
                {
                    cmd.Parameters.AddWithValue("@OrderItemId", orderItemId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            productId = reader.GetInt32(0);
                            orderItemQty = reader.GetInt32(1);
                        }
                        else
                        {
                            // položka neexistuje
                            MessageBox.Show(
                                "Položka neexistuje.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            return;
                        }
                    }
                }

                // aktuální stav produktu
                string sqlProduct = "SELECT " +
                    "p.available_qty," +
                    "p.price_czk FROM amain.product p " +
                    " WHERE product_id = @ProductId";
                int productAvailableQty = 0;
                decimal priceCzk = 0;

                using (var cmd = new NpgsqlCommand(sqlProduct, DbConnProvider.Instance.Conn))
                {
                    int productId_Selected = productId;
                    cmd.Parameters.AddWithValue("@ProductId", productId_Selected);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            productAvailableQty = reader.GetInt32(0);
                            priceCzk = reader.GetDecimal(1);
                        }
                    }
                }

                if (productAvailableQty < 0 || (productAvailableQty - currentAvailableQty < 0))
                {
                    MessageBox.Show(
                        "Nevalidní počet prod.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return; // nelze (zboží není na skladě)
                }

                // rozdíl staré ceny a nové ceny (dle počtu)
                decimal oldOiPrice = orderItemQty * priceCzk; // pokud není pak 0
                decimal newOiPrice = currentAvailableQty * priceCzk;

                // [A] Update orderItem
                string sqlUpdateOrderItem = "UPDATE amain.order_item SET qty = @qty, note = @note WHERE order_item_id=@orderItemId RETURNING order_id";
                var cmdUpdateOrderItem = new NpgsqlCommand(sqlUpdateOrderItem, DbConnProvider.Instance.Conn);
                cmdUpdateOrderItem.Parameters.AddWithValue("@qty", currentAvailableQty);
                cmdUpdateOrderItem.Parameters.AddWithValue("@orderItemId", orderItemId);
                if (currentNote != null)
                {
                    cmdUpdateOrderItem.Parameters.AddWithValue("@note", currentNote);
                }
                else
                {
                    cmdUpdateOrderItem.Parameters.AddWithValue("@note", DBNull.Value);
                }

                var orderId = cmdUpdateOrderItem.ExecuteScalar();

                if (orderId != null)
                {
                    if (OrderID == (int)orderId)
                    {
                        // [B] Update order
                        string sqlUpdateOrder = "UPDATE amain.\"order\" SET total_price_czk=(total_price_czk - @oldOiPrice + @newOiPrice) WHERE order_id=@orderId";
                        var cmdUpdateOrder = new NpgsqlCommand(sqlUpdateOrder, DbConnProvider.Instance.Conn);
                        cmdUpdateOrder.Parameters.AddWithValue("@oldOiPrice", oldOiPrice);
                        cmdUpdateOrder.Parameters.AddWithValue("@newOiPrice", newOiPrice);
                        cmdUpdateOrder.Parameters.AddWithValue("@orderId", OrderID);
                        cmdUpdateOrder.ExecuteNonQuery();
                    }
                }

                // COMMIT TRANSAKCE ===========
                await transaction.CommitAsync();

                // reload data
                RefreshData();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private void cBoxPerPage_SelectedIndexChanged(object sender, EventArgs e) { }

        private void buttonClose_Click(object sender, EventArgs e)
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