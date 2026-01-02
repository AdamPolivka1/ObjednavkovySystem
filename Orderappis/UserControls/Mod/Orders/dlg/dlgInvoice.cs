using Npgsql;
using Orderappis.Dev.PDF;
using Orderis.Data;
using Orderis.Services.Auth;
using System.Text.RegularExpressions;
using static Orderappis.Dev.PDF.PDFInvoice;

namespace Orderappis.UserControls.Mod.Orders.dlg
{

    public partial class dlgInvoice : UserControl
    {

        public int OrderId { get; set; }

        public dlgInvoice()
        {
            InitializeComponent();
        }

        private PDFInvoice.PDFInvoiceDTO GetPdfInvoiceDTO()
        {
            var pdfInvoiceDTO = new PDFInvoice.PDFInvoiceDTO();

            // Odběratel
            string odbName = textBoxOdb_Name.Text;
            string odbAddress = textBoxOdb_Address.Text;
            string odbIC = textBoxOdb_IC.Text;
            // Dodavatel
            string dodName = textBoxDod_Name.Text;
            string dodAddress = textBoxDod_Address.Text;
            string dodIC = textBoxDod_IC.Text;
            // Datum vystavení
            string dt1 = dateTimePickerDate1.Value.Date.ToString();
            // Datum splatnosti
            string dt2 = dateTimePickerDate2.Value.Date.ToString();
            // číslo faktury
            string invoiceNumber = textBox_InvoiceNumber.Text;
            // číslo dokladu
            string accountNumber = textBox_BAccNum.Text;
            // celokvá cena objednávky
            string totalPriceCZK = numericUpDownTotalPriceCZK.Value.ToString();
            // variabilní symbol
            string varSymbol = textBoxVS.Text;

            pdfInvoiceDTO.Odb_Name = odbName;
            pdfInvoiceDTO.Odb_Address = odbAddress;
            pdfInvoiceDTO.Odb_IC = odbIC;
            pdfInvoiceDTO.Dod_Name = dodName;
            pdfInvoiceDTO.Dod_Address = dodAddress;
            pdfInvoiceDTO.Dod_IC = dodIC;
            pdfInvoiceDTO.Date1 = dt1;
            pdfInvoiceDTO.Date2 = dt2;
            pdfInvoiceDTO.InvoiceNumber = invoiceNumber;
            pdfInvoiceDTO.InvoiceAccNum = accountNumber;
            pdfInvoiceDTO.TotalPriceCZK = totalPriceCZK;
            pdfInvoiceDTO.VS = varSymbol;

            return pdfInvoiceDTO;
        }

        private List<PdfInvoiceOrderItem> GetOrderItems()
        { 
            var orderItems = new List<PdfInvoiceOrderItem>();

            string sql = @"SELECT
                p.code      AS ProductCode,
                p.""name""  AS ProductName,
                oi.qty      AS ProductQty
            FROM amain.order_item oi
            JOIN amain.product p
                ON p.product_id = oi.product_id
            WHERE oi.order_id = @OrderId";

            using (var cmd = new NpgsqlCommand(sql, DbConnProvider.Instance.Conn))
            {
                cmd.Parameters.AddWithValue("@OrderId", OrderId);

                using var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    var item = new PdfInvoiceOrderItem();
                    item.ProductCode = reader.GetString(0);
                    item.ProductName = reader.GetString(1);
                    item.ProductQty  = reader.GetInt32(2);

                    orderItems.Add(item);
                }
            }

            return orderItems;
        }

        public void LoadData()
        {
            string sqlInvoiceInfo = @"SELECT 
                    CONCAT(u.firstname, ' ', u.lastname) as Odb_Fullname,
                    d.delivery_address as Odb_Address,
                    o.total_price_czk as TotalPriceCzk
                FROM amain.""order"" o
                LEFT JOIN amain.delivery d
                    ON o.delivery_id = d.delivery_id
                JOIN amain.customer_account ca
                    ON o.customer_account_id = ca.customer_account_id
                JOIN amain.user u
                    ON u.user_id = ca.user_id
                WHERE o.order_id = @OrderId";

            using (var cmd = new NpgsqlCommand(sqlInvoiceInfo, DbConnProvider.Instance.Conn))
            {
                cmd.Parameters.AddWithValue("@OrderId", OrderId);
                using var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    textBoxOdb_Name.Text = reader.GetString(0);
                    
                    if (!reader.IsDBNull(1))
                        textBoxOdb_Address.Text = reader.GetString(1);
                    else
                        textBoxOdb_Address.Text = "";

                    numericUpDownTotalPriceCZK.Value = reader.GetDecimal(2);
                }
            }

            // defaulty
            dateTimePickerDate1.Value = DateTime.Now.Date;
            dateTimePickerDate2.Value = DateTime.Now.Date.AddDays(30);

            // DOD IFO
            string sqlDodInfo = @"
                SELECT
                    company_name as CompanyName
                FROM amain.user
                WHERE user_id = @UserId
            ";

            using (var cmd = new NpgsqlCommand(sqlDodInfo, DbConnProvider.Instance.Conn))
            {
                if (AuthService.Instance.CurrentUser != null)
                    cmd.Parameters.AddWithValue("@UserId", AuthService.Instance.CurrentUser.UserId);
                else
                    cmd.Parameters.AddWithValue("@UserId", 0); // nic nenajde

                using var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    textBoxDod_Name.Text = reader.GetString(0);
                }
                else 
                {
                    // => bez akce
                    //textBoxDod_Name.Text = "";
                }
            }

            // číslo faktury
            string sqlFa = @"SELECT coalesce(MAX(code_num)+1, 0) AS max_code_num
                FROM amain.order_invoice";

            using (var cmd = new NpgsqlCommand(sqlFa, DbConnProvider.Instance.Conn))
            {
                using var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int invoiceNum = reader.GetInt32(0);
                    textBox_InvoiceNumber.Text = invoiceNum.ToString("D10");
                }
            }
        }

        private void buttonPDF_Click(object sender, EventArgs e)
        {
            if (textBox_InvoiceNumber.Text == null)
            {
                MessageBox.Show(
                    "Nepodařilo se vygenerovat číslo faktury.",
                    "Chyba",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF soubor|*.pdf";
            var createdAt = DateTime.Now.ToString();
            createdAt = createdAt.Replace(":", "_").Replace(".", "_");
            createdAt = Regex.Replace(createdAt, @"\s+", "__");
            sfd.FileName = "faktura_" + createdAt + ".pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                PDFInvoice pdfInvoice = new PDFInvoice();
                var pdfInvoiceDTO = GetPdfInvoiceDTO();

                List<PdfInvoiceOrderItem> orderItems = GetOrderItems();
                pdfInvoice.SaveToPdf(sfd.FileName, pdfInvoiceDTO, orderItems, OrderId);
                LogNewInvoice(pdfInvoiceDTO);
            }
        }

        private void LogNewInvoice(PDFInvoiceDTO pdfInvoiceDTO)
        {
            string sqlInsert = @"INSERT INTO amain.order_invoice
                (generated_by_user_id, created_at, code_num, order_id, detail_info)
                VALUES(@GeneratedByUserId, CURRENT_TIMESTAMP, @CodeNum, @OrderId, @DetailInfo)";

            using (var cmd = new NpgsqlCommand(sqlInsert, DbConnProvider.Instance.Conn))
            {
                cmd.Parameters.AddWithValue("@GeneratedByUserId", AuthService.Instance.CurrentUser.UserId);
                cmd.Parameters.AddWithValue("@CodeNum", Convert.ToInt32(textBox_InvoiceNumber.Text));
                cmd.Parameters.AddWithValue("@OrderId", OrderId);
                if (pdfInvoiceDTO != null)
                    cmd.Parameters.AddWithValue("@DetailInfo", pdfInvoiceDTO.ToString());
                else
                    cmd.Parameters.AddWithValue("@DetailInfo", "");

                cmd.ExecuteNonQuery();
            }
        }

        private void checkBox_jeDPH_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Aktuálně není podporována verze generování pro plátce DPH.",
                "Upozornění",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

    }
}
