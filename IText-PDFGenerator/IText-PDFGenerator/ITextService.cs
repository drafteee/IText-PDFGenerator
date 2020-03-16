using iText.Kernel.Colors;
using iText.Kernel.Geom;
using IText_PDFGenerator.Models;
using System;
using System.Drawing;
using System.IO;

namespace IText_PDFGenerator
{
    public class ITextService
    {
        public ITextService()
        {
            using(var pdf = new Pdf(new FileStream($"../../../OutputFIles/generatePDF.pdf", FileMode.OpenOrCreate)))
            {

                pdf.AddPage(PageSize.A4);
                pdf.AddPage(PageSize.A4);
                pdf.AddPage(PageSize.A3);
                pdf.AddPage(PageSize.A4);

                using (var doc = new Doc(pdf, PageSize.A4, false))
                {
                    doc.SetMargins(100, 40, 100, 48);

                    IText_PDFGenerator.Models.Font font = new IText_PDFGenerator.Models.Font();
                    IText_PDFGenerator.Models.Font font1251 = new IText_PDFGenerator.Models.Font("../../../Fonts/TIMES.ttf", "Cp1251", 36);

                    Barcode barcode = new Barcode("https://www.webopedia.com/TERM/Q/QR_Code.html");
                    
                    

                    doc.AddText("ti pidor");
                    doc.AddText("ti pidor1");
                    doc.AddText("ti pidor2");

                    doc.GoNextPage();

                    doc.AddText("ti pidor4");

                    doc.GoNextPage();
                    doc.AddText("ti pidor5");



                    for (int i = 1; i <= pdf.GetCountPages; i++)
                    {
                        float[] sizesPage;
                        pdf.GetSizesPage(out sizesPage, i);
                        var pW = sizesPage[0];
                        var pH = sizesPage[1];

                        pdf.SetBarcode(barcode, i, pH - 100);
                        doc.SetFootnotePage($"Специальное разрешение, {i}", font1251, i, pW - 50);

                        float bottomLeftX = pW / 2 - pW / 2;
                        float bottomLeftY = pH / 2 - pH / 2;
                        //Center the annotation
                        Watermark watermark = new Watermark(bottomLeftX, bottomLeftY, pW, pH, 0.6f, pdf.PdfDoc);

                        using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(1, 1)))
                        {
                            SizeF size = graphics.MeasureString("Единый реестр лицензий Руспублики Беларусь", new System.Drawing.Font("TIMES", 36, FontStyle.Regular, GraphicsUnit.Pixel));
                            
                            var textW = size.Width;
                            var textH = size.Height;
                            var catetH = (textW * (Math.Sqrt(3)/2)) / 1;
                            var catetW = (textW * 1/2) / 1;
                            var indentW = (pW - catetW) / 2;
                            var indentH = (pH - catetH) / 2;
                            watermark.TranslateAndRotate(indentW, indentH, Math.PI / 3);
                        }

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
