using iText.Barcodes;
using iText.Kernel.Pdf.Xobject;
using System;
using System.Collections.Generic;
using System.Text;

namespace IText_PDFGenerator.Models
{
    public class Barcode
    {
        private BarcodeQRCode _barcode;

        public Barcode(string path)
        {
            _barcode = new BarcodeQRCode(path);
        }

        public BarcodeQRCode GetBarcode
        {
            get
            {
                return _barcode;
            }
        }
    }
}
