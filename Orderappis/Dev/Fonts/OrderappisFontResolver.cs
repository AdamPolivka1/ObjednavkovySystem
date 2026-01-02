using PdfSharp.Fonts;

// Čerpáno ze zdroje: https://docs.pdfsharp.net/PDFsharp/Topics/Fonts/Sample-Font-Resolvers.html
namespace Orderappis.Dev.Fonts
{
    public class OrderappisFontResolver : IFontResolver
    {
        public byte[]? GetFont(string faceName)
        {
            return File.ReadAllBytes(@"Fonts\arial.ttf");
        }

        public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
        {
            return new FontResolverInfo("Arial#");
        }
    }
}
