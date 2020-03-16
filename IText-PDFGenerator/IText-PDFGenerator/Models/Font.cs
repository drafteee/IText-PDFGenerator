using iText.IO.Font.Constants;
using iText.Kernel.Font;
using System;
using System.Collections.Generic;
using System.Text;

namespace IText_PDFGenerator.Models
{
    public class Font
    {
        private PdfFont _font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
        private float _fontSize = 14;
        public Font()
        {
        }

        public Font(string pathToFont, string encoding)
        {
            _font = PdfFontFactory.CreateFont(String.IsNullOrEmpty(pathToFont) ? StandardFonts.TIMES_ROMAN : pathToFont, encoding, true);
        }

        public Font(string pathToFont, string encoding, float fontSize)
        {
            _font = PdfFontFactory.CreateFont(String.IsNullOrEmpty(pathToFont) ? StandardFonts.TIMES_ROMAN : pathToFont, encoding, true);
            _fontSize = fontSize;
        }

        public float FontSize 
        {
            get
            {
                return _fontSize;
            }
        }

        public PdfFont PdfFont
        {
            get
            {
                return _font;
            }
        }
    }
}
