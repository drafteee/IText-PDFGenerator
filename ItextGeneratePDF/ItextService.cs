using iText.Barcodes;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Xobject;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ItextGeneratePDF
{
    public class ITextService : IDisposable
    {
        private FileStream _fileStream;
        private PdfWriter _pdfWriter;
        private PdfDocument _pdfDoc;
        public ITextService(string path)
        {
            _fileStream = new FileStream($"../../../GeneratedFiles/generatePDF.pdf", FileMode.OpenOrCreate);

            _pdfWriter = new PdfWriter(_fileStream);

            _pdfDoc = new PdfDocument(_pdfWriter);

            BarcodeQRCode barcode = new BarcodeQRCode("https://www.webopedia.com/TERM/Q/QR_Code.html");
            Document doc = new Document(_pdfDoc);
            doc.SetMargins(100, 40, 100, 48);

            doc.Add(new Paragraph("Hello world"));

            string FONT = "../../../Fonts/TIMES.ttf";
            PdfFont font1251 = PdfFontFactory.CreateFont(FONT, "Cp1251", true);

            try
            {
                PdfFormXObject barcodeObject = barcode.CreateFormXObject(null, _pdfDoc);

                //_pdfDoc.AddNewPage();
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));

                //_pdfDoc.AddNewPage();

                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                doc.Add(new Paragraph("Hello world"));
                Table table = new Table(2, true);
                
                var name = new Paragraph("test");
                var length = new Paragraph("TEST");
                var column1 = new Cell().Add(name);
                var column2 = new Cell().Add(length);
                table.AddCell(column1);
                table.AddCell(column2);
                var page = _pdfDoc.AddNewPage();

                doc.Add(new AreaBreak());
                
                doc.Add(table);
                doc.Add(new Paragraph("Hello world"));

                _pdfDoc.AddNewPage();
                Table table2 = new Table(2, true);

                var name1 = new Paragraph("test");
                var length1 = new Paragraph("TEST");
                var column11 = new Cell().Add(name1);
                var column21 = new Cell().Add(length1);
                table2.AddCell(column11);
                table2.AddCell(column21);
                doc.Add(new AreaBreak());
                doc.Add(table2);
                doc.Add(new Paragraph("Hello world"));


                int numberOfPages = _pdfDoc.GetNumberOfPages();
                for (int i = 1; i <= numberOfPages; i++)
                {
                    doc.ShowTextAligned(new Paragraph().SetFont(font1251).Add($"Специальное разрешение, {i}"),
                            559, 50, i, TextAlignment.RIGHT, VerticalAlignment.BOTTOM, 0);
                    PdfCanvas canvas = new PdfCanvas(_pdfDoc.GetPage(i));
                    canvas.AddXObject(barcodeObject, 2, 0, 0, 2, 40, 750);
                }

                doc.Flush();
                doc.Close();
            }
            catch (Exception e)
            {
                doc.Close();

            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
