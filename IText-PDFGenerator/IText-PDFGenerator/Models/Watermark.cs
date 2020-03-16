using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Annot;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Extgstate;
using iText.Kernel.Pdf.Xobject;
using System;
using System.Collections.Generic;
using System.Text;

namespace IText_PDFGenerator.Models
{
    public class Watermark
    {
        private PdfWatermarkAnnotation _watermark;
        private AffineTransform _transform = new AffineTransform();
        private Canvas _canvas;
        private PdfFormXObject _form;

        public Watermark(float x, float y, float width, float height, float opacity, PdfDocument pdfDoc)
        {
            Rectangle watermarkTrimmingRectangle = new Rectangle(x, y, width, height);

            _watermark = new PdfWatermarkAnnotation(watermarkTrimmingRectangle);

            _form = new PdfFormXObject(watermarkTrimmingRectangle);

            _canvas = new Canvas(opacity, pdfDoc, _form);
        }

        public PdfWatermarkAnnotation GetWatermarkAnnotation
        {
            get
            {
                return _watermark;
            }
        }

        public void TranslateAndRotate(double xT, double yT, double rad)
        {
            _transform.Translate(xT, yT);
            _transform.Rotate(rad);
        }

        public void SetFixed()
        {
            PdfFixedPrint fixedPrint = new PdfFixedPrint();
            _watermark.SetFixedPrint(fixedPrint);
        }

        public void SetText(Color color, string text, Font font, float pageSize)
        {
            float[] transformValues = new float[6];
            _transform.GetMatrix(transformValues);

            _canvas.WriteText(color, transformValues, font, pageSize, text);
        }

        public void SetAnnotation()
        {
            _watermark.SetAppearance(PdfName.N, new PdfAnnotationAppearance(_form.GetPdfObject()));
            _watermark.SetFlags(PdfAnnotation.PRINT);
        }
    }
}
