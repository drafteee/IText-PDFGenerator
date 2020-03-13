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
        public Pdf(string path, FileMode mode)
        {
            _fileStream = new FileStream(path, mode);

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

        public void SetBarcode(Barcode barcode, int numberPage)
        {
            _xObject = barcode.GetBarcode.CreateFormXObject(null, _pdfDoc);
            PdfCanvas canvas = new PdfCanvas(_pdfDoc.GetPage(numberPage));
            canvas.AddXObject(_xObject, 2, 0, 0, 2, 40, 750);
        }

        public void SetAnnotation(int numberPage, Watermark watermark)
        {
            var page = _pdfDoc.GetPage(numberPage);

            page.AddAnnotation(watermark.GetWatermarkAnnotation);
        }

        public void GetSizesPage(out float[] sizes)
        {
            var page = _pdfDoc.GetPage(1);
            var mediaBox = page.GetMediaBox();
            sizes = new float[2] { mediaBox.GetWidth(), mediaBox.GetHeight() };
        }

        public void AddPage()
        {
            _pdfDoc.AddNewPage();
        }

        public void Dispose()
        {
            _pdfDoc.Close();
            _pdfWriter.Close();
            _fileStream.Close();
        }
    }
}
