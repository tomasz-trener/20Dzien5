using P02Biblioteka.Domain;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01AplikacjaZawodnicy.Services
{
    internal class PDFManager
    {

        private readonly string sciezka;

        public PDFManager(string sciezka)
        {
            this.sciezka = sciezka;
        }

        public void WygenerujPDF(Zawodnik[] zawodnicy)
        {
            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Raport zawodnicy";

            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);

            for (int i = 0; i < zawodnicy.Length; i++)
            {
                gfx.DrawString(zawodnicy[i].DaneRaportowe, font, XBrushes.Aqua, 20, 50+ 25*i);
            }

            document.Save(sciezka);



        }
    }
}
