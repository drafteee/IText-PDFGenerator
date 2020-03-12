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
            FileStream fileStream = new FileStream($"../../../OutputFIles/generatePDF.pdf", FileMode.OpenOrCreate);

            PdfWriter pdfWriter = new PdfWriter(fileStream);

            PdfDocument pdfDoc = new PdfDocument(pdfWriter);

            BarcodeQRCode barcode = new BarcodeQRCode("https://www.webopedia.com/TERM/Q/QR_Code.html");
            Document doc = new Document(pdfDoc, PageSize.A4, false);
            doc.SetMargins(100, 40, 100, 48);
            string FONT = "../../../Fonts/TIMES.ttf";
            PdfFont font1251 = PdfFontFactory.CreateFont(FONT, "Cp1251", true);

            try
            {
                PdfFormXObject barcodeObject = barcode.CreateFormXObject(null, pdfDoc);



                var p1 = pdfDoc.AddNewPage();

                var p2 = pdfDoc.AddNewPage();
                var p3 = pdfDoc.AddNewPage();
                var p4 = pdfDoc.AddNewPage();
                var mediabox = pdfDoc.GetPage(1).GetMediaBox();
                int numberOfPages = pdfDoc.GetNumberOfPages();
                float watermarkTrimmingRectangleWidth = mediabox.GetWidth();
                float watermarkTrimmingRectangleHeight = mediabox.GetHeight();

                float formWidth = mediabox.GetWidth();
                float formHeight = mediabox.GetHeight();
                float formXOffset = 0;
                float formYOffset = 0;

                float xTranslation = 50;
                float yTranslation = 25;

                double rotationInRads = Math.PI / 3;
                PdfPage page = null;
                PdfFont font = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.TIMES_ROMAN);
                float fontSize = 50;

                for (int i = 1; i <= numberOfPages; i++)
                {
                    page = pdfDoc.GetPage(i);
                    Rectangle ps = page.GetPageSize();

                    //Center the annotation
                    float bottomLeftX = ps.GetWidth() / 2 - watermarkTrimmingRectangleWidth / 2;
                    float bottomLeftY = ps.GetHeight() / 2 - watermarkTrimmingRectangleHeight / 2;
                    Rectangle watermarkTrimmingRectangle = new Rectangle(bottomLeftX, bottomLeftY, watermarkTrimmingRectangleWidth, watermarkTrimmingRectangleHeight);

                    PdfWatermarkAnnotation watermark = new PdfWatermarkAnnotation(watermarkTrimmingRectangle);

                    //Apply linear algebra rotation math
                    //Create identity matrix
                    AffineTransform transform = new AffineTransform();//No-args constructor creates the identity transform
                                                                      //Apply translation
                    transform.Translate(xTranslation, yTranslation);
                    //Apply rotation
                    transform.Rotate(rotationInRads);

                    PdfFixedPrint fixedPrint = new PdfFixedPrint();
                    watermark.SetFixedPrint(fixedPrint);
                    //Create appearance
                    Rectangle formRectangle = new Rectangle(formXOffset, formYOffset, formWidth, formHeight);

                    //Observation: font XObject will be resized to fit inside the watermark rectangle
                    PdfFormXObject form = new PdfFormXObject(formRectangle);
                    PdfExtGState gs1 = new PdfExtGState().SetFillOpacity(0.6f);
                    PdfCanvas canvas = new PdfCanvas(form, pdfDoc);

                    float[] transformValues = new float[6];
                    transform.GetMatrix(transformValues);
                    canvas.SaveState()
                        .BeginText().SetColor(ColorConstants.GRAY, true).SetExtGState(gs1)
                        .SetTextMatrix(transformValues[0], transformValues[1], transformValues[2], transformValues[3], transformValues[4], transformValues[5])
                        .SetFontAndSize(font, fontSize)
                        .ShowText("watermark textwatermark textwatermark textwatermark textwatermark text")
                        .EndText()
                        .RestoreState();

                    canvas.Release();

                    watermark.SetAppearance(PdfName.N, new PdfAnnotationAppearance(form.GetPdfObject()));
                    watermark.SetFlags(PdfAnnotation.PRINT);

                    page.AddAnnotation(watermark);
                }

                doc.Add(new Paragraph("Hello worldHello worldHello worldHello worldHello worldHello worldHello worldHello worldHello worldHello worldHello worldHello worldHello worldHello worldHello worldHello worldHello worldHello worldHello worldHello worldHello worldHello worldHello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world1"));
                doc.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                doc.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                for (int i = 1; i <= numberOfPages; i++)
                {
                    doc.ShowTextAligned(new Paragraph().SetFont(font1251).Add($"Специальное разрешение, {i}"),
                            559, 50, i, TextAlignment.RIGHT, VerticalAlignment.BOTTOM, 0);

                    PdfCanvas canvas = new PdfCanvas(pdfDoc.GetPage(i));
                    canvas.AddXObject(barcodeObject, 2, 0, 0, 2, 40, 750);
                }
                doc.Flush();
                doc.Close();
            }catch(Exception e)
            {
                doc.Flush();
                doc.Close();
            }
        }
    }
}
