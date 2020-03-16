using System;

namespace IText_PDFGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var s = new ITextService();
            s.GeneratePDF();
        }
    }
}
