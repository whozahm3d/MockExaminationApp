using System.Diagnostics;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

public static class PDFExporter
{
    public static void ExportMedicinesToPDF(string[] medicines)
    {
        PdfDocument document = new PdfDocument();
        document.Info.Title = "Medicine Listings";

        PdfPage page = document.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);

        // Correct font styles
        XFont titleFont = new XFont("Verdana", 14, XFontStyle.Bold);
        XFont normalFont = new XFont("Verdana", 12, XFontStyle.Regular);

        int y = 40;
        gfx.DrawString("Medicine List", titleFont, XBrushes.Black, new XPoint(40, 20));

        foreach (string med in medicines)
        {
            gfx.DrawString(med, normalFont, XBrushes.Black, new XPoint(40, y));
            y += 25;
        }

        string filename = "Medicines.pdf";
        document.Save(filename);
        Process.Start(new ProcessStartInfo(filename) { UseShellExecute = true });
    }
}
