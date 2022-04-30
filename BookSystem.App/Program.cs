using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace BookSystem.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Init();
        }

        private static void Init()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "Book System v1.0";

            CultureInfo ci = new CultureInfo("az-Latn-Az");
            ci.NumberFormat.NumberDecimalSeparator = ".";

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
    }
}
