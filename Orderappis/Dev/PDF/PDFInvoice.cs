using HtmlRendererCore.PdfSharp;
using PdfSharpCore.Pdf;

namespace Orderappis.Dev.PDF
{
    public class PDFInvoice
    {

        public class PdfInvoiceOrderItem
        {
            // Kód zboží
            public string ProductCode { get; set; } = string.Empty;
            // Název produktu
            public string ProductName { get; set; } = string.Empty;
            // Počet produktů
            public int ProductQty { get; set; }
        }

        public class PDFInvoiceDTO
        {
            // Číslo faktury
            public string InvoiceNumber { get; set; } = string.Empty;
            // Číslo bankovního účtu
            public string InvoiceAccNum { get; set; } = string.Empty;
            // Datum vystavení
            public string Date1 { get; set; } = string.Empty;
            // Datum splatnosti
            public string Date2 { get; set; } = string.Empty;
            // Celková cena
            public string TotalPriceCZK { get; set; } = string.Empty;
            // Variabilní symbol
            public string VS { get; set; } = string.Empty;

            // Dodavatel =============================
            public string Dod_Name { get; set; } = string.Empty;
            public string Dod_Address { get; set; } = string.Empty;
            public string Dod_IC { get; set; } = string.Empty;
            //----------------------------------------

            // Odběratel =============================
            public string Odb_Name { get; set; } = string.Empty;
            public string Odb_Address { get; set; } = string.Empty;
            public string Odb_IC { get; set; } = string.Empty;
            //----------------------------------------

            public override string ToString()
            {
                return $"PDFInvoiceDTO(InvoiceNumber={InvoiceNumber}," +
                    $"InvoiceAccNum={InvoiceAccNum}," +
                    $"Date1={Date1}," +
                    $"Date2={Date2}," +
                    $"TotalPriceCZK={TotalPriceCZK}," +
                    $"Dod_Name={Dod_Name}," +
                    $"Dod_Address={Dod_Address}," +
                    $"Dod_IC={Dod_IC}," +
                    $"Odb_Name={Odb_Name}," +
                    $"Dod_Address={Dod_Address}," +
                    $"Odb_IC={Odb_IC}," +
                    $"Odb_Name={Odb_Name}," +
                    $"Odb_Address={Odb_Address}," +
                    $"VS={VS})";
            }
        }

        private string DefineHTML_Template()
        {
            string htmlTemplate = @"<!DOCTYPE html>
            <html lang=""cs"">
            <head>
                <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
                <style>
                    body {
                        font-family: Arial;
                        font-size: 12px;
                    }

                    h1 {
                        text-align: center;
                    }

                    table {
                        width: 100%;
                        border-collapse: collapse;
                    }

                    .invoice-info {
                        border: 1px solid black;
                        padding: 6px;
                    }

                    .align-right {
                        text-align: right;
                    }

                    th, td {
                        border: 1px solid black;
                        padding: 5px;
                    }

                    .no-border td {
                        border: none;
                    }

                    .price {
                        text-align: right;
                        font-weight: bold;
                        font-size: 14px;
                    }

                    .heading-main {
                        text-align: left;
                    }

                    .conthead {
                        border: 1px solid black;
                    }
                </style>
            </head>

            <body>

            <h1 class=""heading-main"">FAKTURA</h1>

            <table class=""no-border"">
                <tr>
                    <td class=""conthead"" width=""50%"">
                        <strong>Dodavatel</strong><br />
                        [DODAVATEL_NAZEV]<br />
                        [DODAVATEL_ADRESA]<br />
                        IČ: [DODAVATEL_IC]
                    </td>
                    <td class=""conthead align-right"" width=""50%"">
                        <strong>Odběratel</strong><br />
                        [ODBERATEL_NAZEV]<br />
                        [ODBERATEL_ADRESA]<br />
                        IČ: [ODBERATEL_IC]
                    </td>
                </tr>
            </table>

            <br />

            <table>
                <tr>
                    <td class=""invoice-info"">
                        <strong>Číslo faktury:</strong> [CISLO_FAKTURY]<br />
                        <strong>Číslo objednávky:</strong> [CISLO_OBJEDNAVKY]<br />
                        <strong>Datum vystavení:</strong> [DATUM_VYSTAVENI]<br />
                        <strong>Datum splatnosti:</strong> [DATUM_SPLATNOSTI]<br />
                        <strong>Číslo účtu:</strong> [CISLO_UCTU]
                        <strong>Variabilní symbol:</strong> [VS]
                    </td>
                </tr>
            </table>

            <br />

            <table>
                <thead>
                    <tr>
                        <th>Kód zboží</th>
                        <th>Název</th>
                        <th class=""right"">Počet</th>
                    </tr>
                </thead>
                <tbody>
                    [POLOZKY]
                </tbody>
            </table>

            <br />

            <table class=""no-border"">
                <tr>
                    <td class=""price"">
                        Celková cena: [CELKOVA_CENA] Kč
                    </td>
                </tr>
            </table>

            </body>
            </html>
            ";

            return htmlTemplate;
        }

        public void SaveToPdf(string filename,
            PDFInvoiceDTO pdfInvoiceDTO,
            List<PdfInvoiceOrderItem> orderItems, int orderId)
        {
            string htmlTemplate = DefineHTML_Template();

            htmlTemplate = htmlTemplate
                .Replace("[DODAVATEL_NAZEV]",  pdfInvoiceDTO.Dod_Name)
                .Replace("[DODAVATEL_ADRESA]", pdfInvoiceDTO.Dod_Address)
                .Replace("[DODAVATEL_IC]",     pdfInvoiceDTO.Dod_IC)
                .Replace("[ODBERATEL_NAZEV]",  pdfInvoiceDTO.Odb_Name)
                .Replace("[ODBERATEL_ADRESA]", pdfInvoiceDTO.Odb_Address)
                .Replace("[ODBERATEL_IC]",     pdfInvoiceDTO.Odb_IC)
                .Replace("[CISLO_FAKTURY]",    "FA_"+pdfInvoiceDTO.InvoiceNumber)
                .Replace("[DATUM_VYSTAVENI]",  pdfInvoiceDTO.Date1)
                .Replace("[DATUM_SPLATNOSTI]", pdfInvoiceDTO.Date2)
                .Replace("[CISLO_UCTU]",       pdfInvoiceDTO.InvoiceAccNum)
                .Replace("[CELKOVA_CENA]",     pdfInvoiceDTO.TotalPriceCZK)
                .Replace("[CISLO_OBJEDNAVKY]", orderId.ToString())
                .Replace("[VS]",               pdfInvoiceDTO.VS);

            string orderItemsStr = "";
            if (orderItems != null)
            {
                foreach (PdfInvoiceOrderItem item in orderItems)
                {
                    string newLineData = @"
                    <tr>
                        <td>"+item.ProductCode+"</td>"+
                        "<td>"+item.ProductName+"</td>"+
                        "<td style=\"\"text-align:right;\"\">"+item.ProductQty+"</td>"+
                    "</tr>";
                    orderItemsStr += newLineData + Environment.NewLine;
                }
            }
            htmlTemplate = htmlTemplate.Replace("[POLOZKY]", orderItemsStr);

            PdfDocument pdf = PdfGenerator.GeneratePdf(
                htmlTemplate,
                PdfSharpCore.PageSize.A4
            );

            pdf.Save(filename);
        }

    }
}