using Npgsql;
using Orderis.Data.Model;
using Orderis.Data;
using System.Data;

namespace Orderappis.UserControls.Mod.Products.dlg
{
    public partial class dlgProductEA : UserControl
    {
        public Product ProductModel { get; set; }
        public bool AllowEdit { get; private set; }
        public bool AllowInsert { get; private set; }
        private bool _StLoad = true;

        public dlgProductEA()
        {
            InitializeComponent();
            SetDefaults();
        }

        private void SetDefaults()
        {
            ProductModel = new Product();
            ProductModel.ProductId = 0;
            ProductModel.ProductCategoryId = 1;
            AllowEdit = false;
            AllowInsert = false;
            buttonSave.Cursor = Cursors.Hand;
        }

        private void BindProductToControls()
        {
            comboBoxProductCategory.DataBindings.Add(
                "SelectedValue",
                ProductModel,
                "ProductCategoryId",
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );

            textBoxCode.DataBindings.Add(
                "Text",
                ProductModel,
                "Code",
                false,
                DataSourceUpdateMode.OnPropertyChanged
            );

            textBoxName.DataBindings.Add(
                "Text",
                ProductModel,
                "Name",
                false,
                DataSourceUpdateMode.OnPropertyChanged
            );

            textBoxDescr.DataBindings.Add(
                "Text",
                ProductModel,
                "Description",
                false,
                DataSourceUpdateMode.OnPropertyChanged
            );

            textBoxPrice.DataBindings.Add(
                "Text",
                ProductModel,
                "PriceCzk",
                false,
                DataSourceUpdateMode.OnPropertyChanged
            );

            numericAvailableQty.DataBindings.Add(
                "Value",
                ProductModel,
                "AvailableQty",
                false,
                DataSourceUpdateMode.OnPropertyChanged
            );
        }

        // mode = 1 ... insert
        // mode = 2 ... update
        public bool LoadData(int mode = 1)
        {
            try
            {
                // načtení produktu podle ID
                var editProduct = GetProductById(ProductModel.ProductId);
                if (editProduct != null)
                {
                    ProductModel = editProduct;
                }

                comboBoxProductCategory.DropDownStyle = ComboBoxStyle.DropDownList;

                // načtení kategorií produktů
                DataTable dtCategories = new DataTable();
                string sql = "SELECT product_category_id AS ProductCategoryId, category_name AS Name FROM amain.product_category ORDER BY product_category_id ASC";

                using (var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn))
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    adapter.Fill(dtCategories);
                }

                DbConnProvider.Instance.ConnClose();

                comboBoxProductCategory.DataSource = dtCategories;
                comboBoxProductCategory.ValueMember = "ProductCategoryId";
                comboBoxProductCategory.DisplayMember = "Name";

                BindProductToControls();

                /*
                if (mode == 2)
                {
                    numericAvailableQty.Enabled = false;
                }
                */

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při načítání produktu: {ex.Message}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }


        public Product GetProductById(int productId)
        {
            Product product = null;

            string sql = @"
               SELECT product_id,
               product_category_id,
               available_qty,
               code,
               ""name"",
               descr,
               price_czk
               FROM amain.product
               WHERE product_id = @productId ORDER BY product_id ASC";

            using var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);
            cmd.Parameters.AddWithValue("@productId", productId);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                product = new Product
                {
                    ProductId = reader.GetInt32(reader.GetOrdinal("product_id")),
                    ProductCategoryId = reader.GetInt32(reader.GetOrdinal("product_category_id")),
                    AvailableQty = reader.GetInt32(reader.GetOrdinal("available_qty")),
                    Code = reader.GetString(reader.GetOrdinal("code")),
                    Name = reader.GetString(reader.GetOrdinal("name")),
                    Description = reader.IsDBNull(reader.GetOrdinal("descr"))
                                  ? null
                                  : reader.GetString(reader.GetOrdinal("descr")),
                    PriceCzk = reader.GetDecimal(reader.GetOrdinal("price_czk"))
                };
            }

            DbConnProvider.Instance.ConnClose();
            return product;
        }

        public List<string> Validate()
        {
            List<string> errors = new List<string>();

            // Id kategorie
            if (ProductModel.ProductCategoryId <= 0)
                errors.Add("Kategorie produktu musí být vybrána.");

            // Kód produktu
            if (string.IsNullOrWhiteSpace(ProductModel.Code))
                errors.Add("Kód produktu nesmí být prázdný.");
            else if (ProductModel.Code.Length < 2)
                errors.Add("Kód produktu musí mít alespoň 2 znaky.");

            // Název produktu
            if (string.IsNullOrWhiteSpace(ProductModel.Name))
                errors.Add("Název produktu nesmí být prázdný.");
            else if (ProductModel.Name.Length < 3)
                errors.Add("Název produktu musí mít alespoň 3 znaky.");

            // Popis (volitelný, max 500 znaků)
            if (!string.IsNullOrWhiteSpace(ProductModel.Description) && ProductModel.Description.Length > 500)
                errors.Add("Popis produktu nesmí mít více než 500 znaků.");

            // Dostupné množství
            if (ProductModel.AvailableQty < 0)
                errors.Add("Dostupné množství nesmí být záporné.");

            // Cena
            if (ProductModel.PriceCzk < 0)
                errors.Add("Cena produktu nesmí být záporná.");

            return errors;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var errors = Validate();

            if (errors.Count > 0)
            {
                textBoxErrors.Text = string.Join(Environment.NewLine, errors);
                return;
            }
            else
            {
                textBoxErrors.Text = "";
            }

            if (ProductModel.ProductId != 0) // edit mode
            {
                AllowEdit = true;
            }
            else // insert mode
            {
                AllowInsert = true;
            }

            var parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.DialogResult = DialogResult.OK;
                parentForm.Close();
            }
        }

        private void numericAvailableQty_ValueChanged(object sender, EventArgs e)
        {
            if (!_StLoad)
            {
                MessageBox.Show(
                    "Po změně dojde k uložení změn na skladě!",
                    "Informace",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            _StLoad = false;
        }
    }
}
