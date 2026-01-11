using Npgsql;
using NpgsqlTypes;
using Orderappis.UserControls.Mod.Products.dlg;
using Orderis.Data;
using Orderis.Services.Auth;
using System.Data;

namespace Orderis.UserControls.Mod.Products
{
    public partial class ModProductsMain : UserControl
    {
        // Tab 1
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalPages = 0;

        // Tab 2
        private int currentPageC = 1;
        private int pageSizeC = 10;
        private int totalPagesC = 0;

        private DataTable dtProducts = new DataTable();
        private DataTable dtCategories = new DataTable();
        private NpgsqlDataAdapter? productAdapter;
        private NpgsqlDataAdapter? categoryAdapter;

        // Auth Info ---------------------
        private Boolean isZ { get; set; } = false;
        private Boolean isM { get; set; } = false;      
        private Boolean isS { get; set; } = false;
        private Boolean isA { get; set; } = false;  
        //--------------------------------

        public ModProductsMain()
        {
            InitializeComponent();
            SetAuthInfo(); // auth info
            Init();
            SetElementsDefaults();
            SetElementsDefaultsTab2();
        }

        private void SetAuthInfo()
        {
            isZ = AuthService.Instance.InUserRole("zákazník");
            isM = AuthService.Instance.InUserRole("manažer");
            isS = AuthService.Instance.InUserRole("skladník");
            isA = AuthService.Instance.InUserRole("administrátor");
        }

        private void Init()
        {
            LoadAllProducts();
            LoadPage();
        }

        private void InitTab2()
        {
            LoadAllCategories();
            LoadPageTab2();
        }

        private void SetElementsDefaults()
        {
            btnFirst.Click += PaginationButton_Click;
            btnPrev.Click += PaginationButton_Click;
            btnNext.Click += PaginationButton_Click;
            btnLast.Click += PaginationButton_Click;

            btnFirst.Cursor = Cursors.Hand;
            btnPrev.Cursor = Cursors.Hand;
            btnNext.Cursor = Cursors.Hand;
            btnLast.Cursor = Cursors.Hand;

            // search combobox
            cBoxSearch.Items.Clear();
            cBoxSearch.Items.AddRange(new object[] {
                "Kód",// "Kód"
                "Název",// "Název"
                "Popis"// "Popis"
            });
            cBoxSearch.SelectedIndex = 0;
            cBoxSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxSearch.Cursor = Cursors.Hand;

            // grid buttons set images
            btnRefresh.Image = Image.FromFile(@"Images\refresh.png");
            btnRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            btnRefresh.TextAlign = ContentAlignment.MiddleRight;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.Click += GridRefresh_Click;

            btnCreate.Image = Image.FromFile(@"Images\create.png");
            btnCreate.ImageAlign = ContentAlignment.MiddleLeft;
            btnCreate.TextAlign = ContentAlignment.MiddleRight;
            btnCreate.Cursor = Cursors.Hand;
            btnCreate.Click += GridCreate_Click;

            if (!isA && !isM)
            { 
                btnCreate.Visible = false;
            }

            btnEdit.Image = Image.FromFile(@"Images\edit.png");
            btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
            btnEdit.TextAlign = ContentAlignment.MiddleRight;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Click += GridEdit_Click;

            if (!isA && !isM)
            {
                btnEdit.Visible = false;
            }

            btnDelete.Image = Image.FromFile(@"Images\trash.png");
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.TextAlign = ContentAlignment.MiddleRight;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Click += GridDelete_Click;

            if (!isA && !isM)
            {
                btnDelete.Visible = false;
            }

            // combobox
            cBoxPerPage.Items.Clear();
            cBoxPerPage.Items.AddRange(new object[] { 3, 5, 10, 20, 50, 100 });
            cBoxPerPage.SelectedIndex = 2;
            cBoxPerPage.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxPerPage.SelectedIndexChanged += ChangePerPage_Click;

            dataGridViewProducts.ReadOnly = true;

            if (!isA && !isM)
            {
                buttonImportCSV.Visible = false;
                buttonExportCSV.Visible = false;
            }

            DefineGridColumns();
            ApplyDefaultGridStyles(dataGridViewProducts);
        }

        private void SetElementsDefaultsTab2()
        {
            btnFirstC.Click += PaginationButtonC_Click;
            btnPrevC.Click += PaginationButtonC_Click;
            btnNextC.Click += PaginationButtonC_Click;
            btnLastC.Click += PaginationButtonC_Click;

            btnFirstC.Cursor = Cursors.Hand;
            btnPrevC.Cursor = Cursors.Hand;
            btnNextC.Cursor = Cursors.Hand;
            btnLastC.Cursor = Cursors.Hand;

            // grid
            btnRefreshC.Image = Image.FromFile(@"Images\refresh.png");
            btnRefreshC.ImageAlign = ContentAlignment.MiddleLeft;
            btnRefreshC.TextAlign = ContentAlignment.MiddleRight;
            btnRefreshC.Cursor = Cursors.Hand;
            btnRefreshC.Click += GridRefreshC_Click;

            // combobox
            cBoxPerPageC.Items.Clear();
            cBoxPerPageC.Items.AddRange(new object[] { 3, 5, 10, 20, 50, 100 });
            cBoxPerPageC.SelectedIndex = 2;
            cBoxPerPageC.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxPerPageC.SelectedIndexChanged += ChangePerPageC_Click;

            dataGridViewCategories.ReadOnly = true;

            DefineGridColumnsC();
            ApplyDefaultGridStyles(dataGridViewCategories);
        }

        private void SearchGrid()
        {
            if (dataGridViewProducts.DataSource == null)
                return;

            string searchText = textBoxSearch.Text.Trim();
            int selectedColumnIndex = cBoxSearch.SelectedIndex;

            if (selectedColumnIndex < 0)
                return;

            // 0 => "Kód"
            // 1 => "Název"
            // 2 => "Popis"
            // namapomvání na sloupce gridu
            switch (selectedColumnIndex)
            {
                case 0:
                    selectedColumnIndex = 3;
                    break;
                case 1:
                    selectedColumnIndex = 4;
                    break;
                case 2:
                    selectedColumnIndex = 5;
                    break;
            }

            string columnName = dataGridViewProducts.Columns[selectedColumnIndex].DataPropertyName;
            DataView view;

            if (dataGridViewProducts.DataSource is DataTable dt)
            {
                view = dt.DefaultView;
            }
            else
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(searchText))
            {
                view.RowFilter = "";
            }
            else
            {
                string escaped = searchText.Replace("'", "''");
                view.RowFilter = $"{columnName} LIKE '%{escaped}%'";
            }
        }

        private void GridRefresh_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void GridRefreshC_Click(object sender, EventArgs e)
        {
            InitTab2();
        }

        public DialogResult ShowUserControlModal(UserControl control, string title)
        {
            Form modal = new Form();
            modal.StartPosition = FormStartPosition.CenterParent;
            modal.FormBorderStyle = FormBorderStyle.FixedDialog;
            modal.MaximizeBox = false;
            modal.MinimizeBox = false;
            modal.ShowInTaskbar = false;
            modal.Text = title;
            modal.ClientSize = control.Size;
            control.Dock = DockStyle.Fill;
            modal.Controls.Add(control);

            return modal.ShowDialog(this);
        }

        private int GetCurrentRowProductId()
        {
            if (dataGridViewProducts.CurrentRow != null)
            {
                int selectedProductId = Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells[0].Value);
                return selectedProductId;
            }
            return -1;
        }

        private void InsertProductDataSet(Data.Model.Product product)
        {
            // definice InsertCommand pro adapter
            productAdapter.InsertCommand = new NpgsqlCommand(@"
                INSERT INTO amain.product 
                    (product_category_id, available_qty, code, ""name"", descr, price_czk)
                VALUES 
                    (@ProductCategoryId, @AvailableQty, @Code, @Name, @Descr, @PriceCzk)
                RETURNING product_id
            ", DbConnProvider.Instance.Conn);

            productAdapter.InsertCommand.Parameters.Add("@ProductCategoryId", NpgsqlDbType.Integer, 0, "ProductCategoryId");
            productAdapter.InsertCommand.Parameters.Add("@AvailableQty", NpgsqlDbType.Integer, 0, "AvailableQty");
            productAdapter.InsertCommand.Parameters.Add("@Code", NpgsqlDbType.Varchar, 0, "Code");
            productAdapter.InsertCommand.Parameters.Add("@Name", NpgsqlDbType.Varchar, 0, "Name");
            productAdapter.InsertCommand.Parameters.Add("@Descr", NpgsqlDbType.Varchar, 0, "Descr");
            productAdapter.InsertCommand.Parameters.Add("@PriceCzk", NpgsqlDbType.Numeric, 0, "PriceCzk");

            // přidání nového DataRow do DataTable
            DataRow newRow = dtProducts.NewRow();
            newRow["ProductCategoryId"] = product.ProductCategoryId;
            newRow["AvailableQty"] = product.AvailableQty;
            newRow["Code"] = product.Code;
            newRow["Name"] = product.Name;
            newRow["Descr"] = product.Description;
            newRow["PriceCzk"] = product.PriceCzk;
            dtProducts.ImportRow(newRow);

            productAdapter.Update(dtProducts);

            Init();
        }

        private void DeleteProductDG()
        {
            if (dataGridViewProducts.CurrentRow != null)
            {
                int rowIndex = dataGridViewProducts.CurrentRow.Index;
                DataRow row = dtProducts.Rows[rowIndex];
                row.Delete();

                productAdapter.DeleteCommand = new NpgsqlCommand(@"
                    DELETE FROM amain.product
                    WHERE product_id = @ProductId
                ", DbConnProvider.Instance.Conn);

                // 0 je zde jen placeholder
                productAdapter.DeleteCommand.Parameters.Add("@ProductId", NpgsqlDbType.Integer, 0, "ProductId");
                productAdapter.Update(dtProducts);

                Init();
            }
        }

        private void UpdateProductDataSet(Data.Model.Product product)
        {
            DataRow row = dtProducts.Rows
                .Cast<DataRow>()
                .First(r => (int)r["ProductId"] == product.ProductId);

            if (row != null)
            {
                // definice update commandu
                productAdapter.UpdateCommand = new NpgsqlCommand(@"
                UPDATE amain.product
                SET
                    product_category_id = @ProductCategoryId,
                    available_qty = @AvailableQty,
                    code = @Code,
                    ""name"" = @Name,
                    descr = @Descr,
                    price_czk = @PriceCzk
                WHERE product_id = @ProductId
                ", DbConnProvider.Instance.Conn);

                // 0 je zde jen placeholder, tady jsou i varchary, kdyžtak přenastavit
                productAdapter.UpdateCommand.Parameters.Add("@ProductCategoryId", NpgsqlDbType.Integer, 0, "ProductCategoryId");
                productAdapter.UpdateCommand.Parameters.Add("@AvailableQty", NpgsqlDbType.Integer, 0, "AvailableQty");
                productAdapter.UpdateCommand.Parameters.Add("@Code", NpgsqlDbType.Varchar, 0, "Code");
                productAdapter.UpdateCommand.Parameters.Add("@Name", NpgsqlDbType.Varchar, 0, "Name");
                productAdapter.UpdateCommand.Parameters.Add("@Descr", NpgsqlDbType.Varchar, 0, "Descr");
                productAdapter.UpdateCommand.Parameters.Add("@PriceCzk", NpgsqlDbType.Numeric, 0, "PriceCzk");
                productAdapter.UpdateCommand.Parameters.Add("@ProductId", NpgsqlDbType.Integer, 0, "ProductId");

                // aktualizace řádku v DataTable
                row["ProductCategoryId"] = product.ProductCategoryId;
                row["AvailableQty"] = product.AvailableQty;
                row["Code"] = product.Code;
                row["Name"] = product.Name;
                row["Descr"] = product.Description;
                row["PriceCzk"] = product.PriceCzk;

                // provedení updatu přes adapter
                productAdapter.Update(dtProducts);

                // refresh grid
                Init();
            }
        }


        private void GridCreate_Click(object sender, EventArgs e)
        {
            bool ModalAllowInsert = false;
            using (var modal = new dlgProductEA())
            {
                modal.LoadData();
                ShowUserControlModal(modal, "Přidání produktu");
                ModalAllowInsert = modal.AllowInsert;
                if (ModalAllowInsert)
                {
                    InsertProductDataSet(modal.ProductModel);
                }
            }
        }

        private void GridEdit_Click(object sender, EventArgs e)
        {
            bool ModalAllowEdit = false;
            int productId = GetCurrentRowProductId();
            if (productId > 0)
            {
                using (var modal = new dlgProductEA())
                {
                    modal.ProductModel.ProductId = productId;
                    modal.LoadData();
                    ShowUserControlModal(modal, "Editace produktu");
                    // check if modal edit OK
                    ModalAllowEdit = modal.AllowEdit;
                    if (ModalAllowEdit)
                    {
                        UpdateProductDataSet(modal.ProductModel);
                    }
                }
            }
        }

        private void GridDelete_Click(object sender, EventArgs e)
        {
            if (MessageDialog.ShowMessage("question", "Přejete si smazat produkt?") == DialogResult.OK)
            {
                DeleteProductDG();
            }
        }

        private void ApplyDefaultGridStyles(DataGridView dgv)
        {
            dgv.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowTemplate.Height = 28;
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgv.RowsDefaultCellStyle.ForeColor = Color.Black;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.LightGray;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.AllowUserToResizeRows = false;
            dgv.ScrollBars = ScrollBars.Both;
            dgv.DefaultCellStyle.SelectionBackColor = Color.MediumTurquoise;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.AllowUserToAddRows = false;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.MediumTurquoise;
        }

        private void ChangePerPage_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            pageSize = (int)cBoxPerPage.SelectedItem;
            LoadPage();
        }

        private void ChangePerPageC_Click(object sender, EventArgs e)
        {
            currentPageC = 1;
            var selectedItem = cBoxPerPageC.SelectedItem;
            if (selectedItem != null)
            {
                pageSizeC = (int)selectedItem;
                LoadPageTab2();
            }
        }

        private void PaginationButton_Click(object? sender, EventArgs e)
        {
            if (sender == null) return;
            if (sender == btnFirst) currentPage = 1;
            else if (sender == btnPrev) currentPage = Math.Max(1, currentPage - 1);
            else if (sender == btnNext) currentPage = Math.Min(totalPages, currentPage + 1);
            else if (sender == btnLast) currentPage = totalPages;

            LoadPage();
        }

        private void PaginationButtonC_Click(object sender, EventArgs e)
        {
            if (sender == btnFirstC) currentPageC = 1;
            else if (sender == btnPrevC) currentPageC = Math.Max(1, currentPageC - 1);
            else if (sender == btnNextC) currentPageC = Math.Min(totalPagesC, currentPageC + 1);
            else if (sender == btnLastC) currentPageC = totalPagesC;

            LoadPageTab2();
        }

        private void LoadPage()
        {
            double divP = Math.Ceiling((double)dtProducts.Rows.Count / pageSize);
            totalPages = Convert.ToInt32(divP);

            DataView dv = new DataView(dtProducts);

            int skip = (currentPage - 1) * pageSize;
            int eIndexRow = skip + pageSize;

            if (eIndexRow > dtProducts.Rows.Count) {
                eIndexRow = dtProducts.Rows.Count;
            }

            DataTable pageT = dtProducts.Clone();
            for (int i = skip; i < eIndexRow; i++)
            {
                pageT.ImportRow(dtProducts.Rows[i]);
            }

            dataGridViewProducts.DataSource = pageT;

            // tlačítka
            btnFirst.Enabled = currentPage > 1;
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
            btnLast.Enabled = currentPage < totalPages;

            // nastavení aktuální strany (popis)
            lblCurrentPage.Text = currentPage.ToString();
        }

        private void LoadPageTab2()
        {
            double divP = Math.Ceiling((double)dtCategories.Rows.Count / pageSizeC);
            totalPagesC = Convert.ToInt32(divP);
            DataView dv = new DataView(dtCategories);

            int skip = (currentPageC - 1) * pageSizeC;
            int eIndexRow = skip + pageSizeC;

            if (eIndexRow > dtCategories.Rows.Count) {
                eIndexRow = dtCategories.Rows.Count;
            }

            DataTable pageT = dtCategories.Clone();
            for (int i = skip; i < eIndexRow; i++)
            {
                pageT.ImportRow(dtCategories.Rows[i]);
            }

            dataGridViewCategories.DataSource = pageT;

            // tlačítka
            btnFirstC.Enabled = currentPageC > 1;
            btnPrevC.Enabled = currentPageC > 1;
            btnNextC.Enabled = currentPageC < totalPagesC;
            btnLastC.Enabled = currentPageC < totalPagesC;

            // nastavení aktuální strany (popis)
            lblCurrentPageC.Text = currentPageC.ToString();
        }

        private void DefineGridColumns()
        {
            dataGridViewProducts.AutoGenerateColumns = false;
            dataGridViewProducts.Columns.Clear();

            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductId",
                HeaderText = "ID produktu",
                Name = "colProductId"
            });

            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductCategoryId",
                HeaderText = "Kategorie",
                Name = "colProductCategoryId"
            });

            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AvailableQty",
                HeaderText = "Dostupné množství",
                Name = "colAvailableQty"
            });

            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Code",
                HeaderText = "Kód",
                Name = "colCode"
            });

            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Název",
                Name = "colName"
            });

            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descr",
                HeaderText = "Popis",
                Name = "colDescription",
                Width = 300
            });

            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PriceCzk",
                HeaderText = "Cena (CZK)",
                Name = "colPriceCzk",
                DefaultCellStyle = { Format = "N2" } // formátování ceny
            });
        }

        private void DefineGridColumnsC()
        {
            dataGridViewCategories.AutoGenerateColumns = false;
            dataGridViewCategories.Columns.Clear();

            dataGridViewCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductCategoryId",
                HeaderText = "ID kategorie",
                Name = "colProductCategoryId"
            });

            dataGridViewCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CategoryName",
                HeaderText = "Název",
                Name = "colCategoryName",
                Width = 250
            });

            dataGridViewCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descr",
                HeaderText = "Popis",
                Name = "colDescr",
                Width = 300
            });
        }

        // Load Data Tab Categories
        private void LoadAllCategories()
        {
            string sql = @"SELECT product_category_id AS ProductCategoryId,
                category_name AS CategoryName,
                descr as Descr
            FROM amain.product_category ORDER BY product_category_id ASC";

            using var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);
            categoryAdapter = new NpgsqlDataAdapter(cmd);

            dtCategories.Clear();
            categoryAdapter.Fill(dtCategories);

            DbConnProvider.Instance.ConnClose();
        }

        // Load Data Tab Products
        private void LoadAllProducts()
        {
            string sql = @"SELECT product_id AS ProductId,
            product_category_id AS ProductCategoryId,
            available_qty AS AvailableQty,
            code as Code,
            ""name"" as Name,
            descr as Descr,
            price_czk as PriceCZK
            FROM amain.product
            ORDER BY product_id ASC";

            using var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn);
            productAdapter = new NpgsqlDataAdapter(cmd);

            dtProducts.Clear();
            productAdapter.Fill(dtProducts);

            DbConnProvider.Instance.ConnClose();
        }

        private void tabControlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // reakce na změnu záložky
            int selectedTabIndex = tabControlProducts.SelectedIndex;
            if (selectedTabIndex == 0) // = Tab1
            {
                Init();
            }
            if (selectedTabIndex == 1) // = Tab2
            {
                InitTab2();
            }
        }

        private void cBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Search
            SearchGrid();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            //Search
            SearchGrid();
        }

        private void Products_ImportDataCSV(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(filename);

                DataTable table = (DataTable)dataGridViewProducts.DataSource;

                NpgsqlCommand insertCommand = new NpgsqlCommand(@"
                INSERT INTO amain.product
                (product_category_id, available_qty, code, ""name"", descr, price_czk)
                VALUES (@CategoryId, @Qty, @Code, @Name, @Descr, @Price)
                RETURNING product_id;
                ", DbConnProvider.Instance.Conn);

                insertCommand.Parameters.Add("@CategoryId", NpgsqlDbType.Integer, 0, "ProductCategoryId");
                insertCommand.Parameters.Add("@Qty", NpgsqlDbType.Integer, 0, "AvailableQty");
                insertCommand.Parameters.Add("@Code", NpgsqlDbType.Varchar, 50, "Code");
                insertCommand.Parameters.Add("@Name", NpgsqlDbType.Varchar, 100, "Name");
                insertCommand.Parameters.Add("@Descr", NpgsqlDbType.Varchar, 200, "Descr");
                insertCommand.Parameters.Add("@Price", NpgsqlDbType.Numeric, 0, "PriceCZK");

                productAdapter.InsertCommand = insertCommand;

                // Přeskočíme hlavičku
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] cols = lines[i].Split(';');

                    if (cols.Length >= 7)
                    {
                        DataRow row = table.NewRow();

                        row["ProductId"] = int.Parse(cols[0]);
                        row["ProductCategoryId"] = int.Parse(cols[1]);
                        row["AvailableQty"] = int.Parse(cols[2]);
                        row["Code"] = cols[3];
                        row["Name"] = cols[4];
                        row["Descr"] = cols[5];
                        row["PriceCZK"] = decimal.Parse(cols[6]);

                        table.ImportRow(row);
                    }
                }

                productAdapter.Update(table);
                // refresh
                Init();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Došlo k chybě při importu souboru:\n" + ex.Message,
                    "Chyba",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private string Products_PageExportDataCSV()
        {
            string csvData = "";

            string fileHeader = "ProductId;ProductCategoryId;AvailableQty;" +
                "Code;Name;Descr;PriceCZK;\n";

            csvData += fileHeader;

            // iterace DataGridView
            for (int i = 0; i < dataGridViewProducts.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridViewProducts.Rows[i];

                // ignoruje nově vložené neuložené řádky
                if (row.IsNewRow) continue;

                csvData += row.Cells["colProductId"].Value + ";";
                csvData += row.Cells["colProductCategoryId"].Value + ";";
                csvData += row.Cells["colAvailableQty"].Value + ";";
                csvData += row.Cells["colCode"].Value + ";";
                csvData += row.Cells["colName"].Value + ";";
                csvData += row.Cells["colDescription"].Value + ";";
                csvData += row.Cells["colPriceCZK"].Value + ";";

                csvData += "\n";
            }

            return csvData;
        }

        private void buttonExportCSV_Click(object sender, EventArgs e)
        {
            if (MessageDialog.ShowMessage("question", "Přejete si export dat\naktuální stránky do CSV?") == DialogResult.OK)
            {
                SaveFileDialog saveFileDialogExport = new SaveFileDialog();
                saveFileDialogExport.Filter = "CSV soubor|*.csv";
                saveFileDialogExport.Title = "Uložit export produktů";
                saveFileDialogExport.FileName = "products_export";
                if (saveFileDialogExport.ShowDialog() == DialogResult.OK)
                {
                    string exportCSVContent = Products_PageExportDataCSV();
                    File.WriteAllText(saveFileDialogExport.FileName, exportCSVContent);
                }
            }
        }

        private void buttonImportCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "CSV soubory|*.csv";
            open.Title = "Vyberte CSV soubor k importu";

            if (open.ShowDialog() == DialogResult.OK)
            {
                Products_ImportDataCSV(open.FileName);
            }
        }

    }
}
