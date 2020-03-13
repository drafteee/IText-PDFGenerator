using iText.Kernel.Geom;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace IText_PDFGenerator.Models
{
    public class Doc : IDisposable
    {
        private Document _doc;
        public Doc(Pdf pdf, PageSize pageSize, bool immediateFlush)
        {
           _doc = new Document(pdf.PdfDoc, pageSize, immediateFlush);
        }

        public void SetMargins(float top, float right, float bottom, float left)
        {
            _doc.SetMargins(top, right, bottom, left);
        }

        public void SetFootnotePage(string content, Font font, int numberPage)
        {
            _doc.ShowTextAligned(new Paragraph().SetFont(font.PdfFont).Add(content),
                                559, 50, numberPage, TextAlignment.RIGHT, VerticalAlignment.BOTTOM, 0);
        }

        public void AddText(string content)
        {
            _doc.Add(new Paragraph(content));
        }
        public void GoNextPage()
        {
            _doc.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
        }

        public void Dispose()
        {
            _doc.Flush();
            _doc.Close();
        }
    }
}
