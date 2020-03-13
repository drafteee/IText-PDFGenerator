using iText.Barcodes;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Annot;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Extgstate;
using iText.Kernel.Pdf.Xobject;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using IText_PDFGenerator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Rectangle = iText.Kernel.Geom.Rectangle;

namespace IText_PDFGenerator
{
    public class ITextService
    {
        public ITextService()
        {
            using(var pdf = new Pdf($"../../../OutputFIles/generatePDF.pdf", FileMode.OpenOrCreate))
            {

                pdf.AddPage();
                pdf.AddPage();
                pdf.AddPage();
                pdf.AddPage();

                using (var doc = new Doc(pdf, PageSize.A4, false))
                {
                    doc.SetMargins(100, 40, 100, 48);

                    Font font = new Font();
                    Font font1251 = new Font("../../../Fonts/TIMES.ttf", "Cp1251", 36);

                    Barcode barcode = new Barcode("https://www.webopedia.com/TERM/Q/QR_Code.html");
                    float[] sizesPage;
                    pdf.GetSizesPage(out sizesPage);
                    float watermarkTrimmingRectangleWidth = sizesPage[0];
                    float watermarkTrimmingRectangleHeight = sizesPage[1];

                    doc.AddText("ti pidor");
                    doc.AddText("ti pidor1");
                    doc.AddText("ti pidor2");

                    doc.GoNextPage();

                    doc.AddText("ti pidor4");

                    doc.GoNextPage();
                    doc.AddText("ti pidor5");



                    for (int i = 1; i <= pdf.GetCountPages; i++)
                    {
                        pdf.SetBarcode(barcode, i);
                        doc.SetFootnotePage($"Специальное разрешение, {i}", font1251, i);

                        //Center the annotation
                        float bottomLeftX = sizesPage[0] / 2 - watermarkTrimmingRectangleWidth / 2;
                        float bottomLeftY = sizesPage[1] / 2 - watermarkTrimmingRectangleHeight / 2;
                        Watermark watermark = new Watermark(bottomLeftX, bottomLeftY, watermarkTrimmingRectangleWidth, watermarkTrimmingRectangleHeight, 0.6f, pdf.PdfDoc);

                        watermark.TranslateAndRotate(50, 25, Math.PI / 3);
                        watermark.SetFixed();
                        watermark.SetText(ColorConstants.GRAY, "Единый реестр лицензий Руспублики Беларусь", font1251);
                        watermark.SetAnnotation();

                        pdf.SetAnnotation(i, watermark);
                    }
                }
            }
        }
    }
}
