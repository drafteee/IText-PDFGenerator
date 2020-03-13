using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Extgstate;
using iText.Kernel.Pdf.Xobject;
using System;
using System.Collections.Generic;
using System.Text;

namespace IText_PDFGenerator.Models
{
    public class Canvas
    {
        private PdfCanvas _canvas;
        private PdfExtGState _gs;
        public Canvas(float opacity, PdfDocument pdfDoc, PdfFormXObject form)
        {
            _gs = new PdfExtGState().SetFillOpacity(opacity);

            _canvas = new PdfCanvas(form, pdfDoc);
        }

        public void SetColor(Color color)
        {
            _canvas.SetColor(color, true);
        }

        public void WriteText(Color color, float[] transformValues, Font font, string text)
        {
            _canvas.SaveState()
                        .BeginText().SetColor(color, true).SetExtGState(_gs)
                        .SetTextMatrix(transformValues[0], transformValues[1], transformValues[2], transformValues[3], transformValues[4], transformValues[5])
                        .SetFontAndSize(font.PdfFont, font.FontSize)
                        .ShowText(text)
                        .EndText()
                        .RestoreState();

            _canvas.Release();
        }
    }
}
