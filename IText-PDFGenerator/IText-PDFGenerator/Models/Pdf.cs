using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Xobject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IText_PDFGenerator.Models
{
    public class Pdf : IDisposable
    {
        private FileStream _fileStream;
        private PdfWriter _pdfWriter;
        private PdfDocument _pdfDoc;
        private PdfXObject _xObject;
        public Pdf(FileStream fileStream)
        {
            _fileStream = fileStream;

            _pdfWriter = new PdfWriter(_fileStream);

            _pdfDoc = new PdfDocument(_pdfWriter);
        }

        public PdfDocument PdfDoc
        {
            get
            {
                return _pdfDoc;
            }
        }

        public int GetCountPages
        {
            get
            {
                return _pdfDoc.GetNumberOfPages();
            }
        }

        public void SetBarcode(Barcode barcode, int numberPage, float paddingY)
        {
            _xObject = barcode.GetBarcode.CreateFormXObject(null, _pdfDoc);
            PdfCanvas canvas = new PdfCanvas(_pdfDoc.GetPage(numberPage));
            canvas.AddXObject(_xObject, 2, 0, 0, 2, 40, paddingY);
        }

        public void SetAnnotation(int numberPage, Watermark watermark)
        {
            var page = _pdfDoc.GetPage(numberPage);

            page.AddAnnotation(watermark.GetWatermarkAnnotation);
        }

        public void GetSizesPage(out float[] sizes, int number)
        {
            var page = _pdfDoc.GetPage(number);
            var mediaBox = page.GetMediaBox();
            sizes = new float[6] { mediaBox.GetWidth(), mediaBox.GetHeight(), mediaBox.GetTop(), mediaBox.GetRight(), mediaBox.GetBottom(), mediaBox.GetLeft() };
        }

        public void AddPage(PageSize pageSize)
        {
            _pdfDoc.AddNewPage(pageSize);
        }

        public void Dispose()
        {
            _pdfDoc.Close();
            _pdfWriter.Close();
            _fileStream.Close();
        }
    }
}
