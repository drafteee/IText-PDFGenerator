using System;
using System.Collections.Generic;
using System.Text;

namespace IText_PDFGenerator.Services
{
    public class WatermarkService
    {
        public WatermarkService(PdfDocoment)
        {
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
            float fontSize = 50;

        }
    }
}
