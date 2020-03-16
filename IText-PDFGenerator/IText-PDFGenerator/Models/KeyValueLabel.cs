using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Text;

namespace IText_PDFGenerator.Models
{
    public class KeyValueLabel
    {
        private Font _fontKey;
        private Font _fontValue;
        private Paragraph _paragraph;
        public KeyValueLabel(string keyS, string valueS, Models.Font fontKey, Models.Font fontValue, float fontSize)
        {
            _fontKey = fontKey;
            _fontValue = fontValue;
            Text keyT = new Text(keyS + ": ").SetFont(fontKey.PdfFont).SetFontSize(fontSize);
            Text valueT = new Text(valueS).SetFont(fontValue.PdfFont).SetFontSize(fontSize);
            _paragraph = new Paragraph().Add(keyT).Add(valueT);
        }

        public void SetText(Doc doc)
        {
            doc.AddText(_paragraph);
        }
    }
}
