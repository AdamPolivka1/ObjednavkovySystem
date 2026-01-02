using Orderappis.Dev.Fonts;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;

namespace Orderappis.Dev.PDF
{
    class PDFHelper
    {
        public void ExportOrdersList(DataGridView dgv, string filename)
        {
            // Zdroj informací: https://docs.pdfsharp.net/
            GlobalFontSettings.FontResolver = new OrderappisFontResolver();
            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "Objednávky Export";

            PdfPage page = pdf.AddPage(); // přidá se první stránka
            XGraphics gfx = XGraphics.FromPdfPage(page); // grafický podklad pro vykreslování

            // PÍSMA aplikace
            XFont font = new XFont("Arial", 10); // načte se písmo Arial z ttf
            XFont headerFont = new XFont("Arial", 12); // načte se písmo Arial z ttf

            int rHeight = 25; // výška řádku
            int rHHeight = 20; // výška řádku hlavičky
            int yVal = 0; // souřadnice Y
            int xVal = 20; // souřadnice X

            // 1. Výpis nadpisu
            gfx.DrawString("OrderAppIS Export Objednávek", headerFont, XBrushes.Black,
                new XRect(xVal,
                   yVal + 2, // aby se zobrazovalo rovnoměrně s obrázkem
                   100,
                   rHHeight),
               XStringFormats.TopLeft);
            xVal = 195; // stanoveno ručním odzkoušením
            XImage img = XImage.FromFile(@"Images\container.png");
            gfx.DrawImage(img, xVal, yVal, 20, 20);

            // 2. Výpis hlavičky
            yVal += rHHeight + 5; // + něco málo navíc pro odsazení
            xVal = 20; // reset X souřadnice
            int maxColWidth = 160; // maximální šířka sloupce
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                string headerValue = "";
                // switch zde nastaví headerValue
                switch (column.Index)
                {
                    case 0:
                        headerValue = "ID objednávky";
                        break;
                    case 1:
                        headerValue = "CZK bez DPH";
                        break;
                    case 3:
                        headerValue = "Vytvořena";
                        break;
                    case 6:
                        headerValue = "Email zákazníka";
                        break;
                }
                if (headerValue != "")
                {
                    int usedWidth = column.Width > maxColWidth
                           ? maxColWidth
                           : column.Width;
                    // mřížka
                    gfx.DrawRectangle(XPens.Blue,
                        xVal,
                        yVal,
                        usedWidth,
                        rHHeight);
                    // popis sloupce
                    gfx.DrawString(
                        headerValue,
                        headerFont,
                        XBrushes.Blue,
                        new XRect(xVal+2, // padding
                            yVal+2, // padding
                            usedWidth,
                            rHHeight),
                        XStringFormats.TopLeft);
                    xVal += usedWidth;
                }

            }

            // 3. Výpis objednávek
            yVal += rHHeight + 5; // + něco málo navíc pro odsazení
            xVal = 20; // reset X souřadnice

            int numRecord = 1;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                // max 25 záznamů na stránce
                if ((numRecord % 26 == 0) && (numRecord > 1))
                {
                    page = pdf.AddPage(); // nová stránka PDF
                    gfx = XGraphics.FromPdfPage(page); // nové plátno
                    // reset
                    xVal = 20;
                    yVal = 20; // zde odsazení 20 (na dalších stranách není hlavička..)
                }
                if (!row.IsNewRow)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // pokud je ve zvoleném sloupci -> vypiš
                        if (cell.ColumnIndex == 0 || cell.ColumnIndex == 1
                            || cell.ColumnIndex == 3 || cell.ColumnIndex == 6
                            || cell.ColumnIndex == 7)
                        {
                            var cellValue = cell.Value.ToString();
                            gfx.DrawString(cellValue,
                            font,
                                XBrushes.Black,
                                new XRect(xVal + 2, // padding
                                    yVal,
                                    page.Width,
                                    page.Height),
                                XStringFormats.TopLeft);
                            xVal += cell.Size.Width;
                        }
                    }
                    yVal += rHeight; // přičtení výšky řádku pro každý řádek
                    xVal = 20; // reset pro každý řádek
                }
                numRecord += 1;
            }

            pdf.Save(filename); // Zde už jen uložení do souboru
        }
    }
}
