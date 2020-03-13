using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Annot;
using System;
using System.Collections.Generic;
using System.Text;

namespace IText_PDFGenerator.Services
{
    public class WatermarkService
    {
        private PdfDocument _pdfDocument;
        public WatermarkService(PdfDocument pdfDoc)
        {
            _pdfDocument = pdfDoc;
        }
    }
}
