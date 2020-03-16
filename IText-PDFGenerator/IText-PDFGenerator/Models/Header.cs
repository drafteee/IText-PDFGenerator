using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Text;

namespace IText_PDFGenerator.Models
{
    public class Header
    {
        private Font _font;
        private Paragraph _paragraph;
        public Header(string content, Models.Font font, float fontSize)
        {
            _font = font;
            _paragraph = new Paragraph().SetFont(font.PdfFont).SetFontSize(fontSize).Add(content);
        }

        public void SetHeader(Doc doc)
        {
            doc.AddTextCentered(_paragraph);
        }
    }
}
