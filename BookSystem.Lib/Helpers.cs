using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace BookSystem.Lib
{
    public class Helpers
    {  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="required"></param>
        /// <returns></returns>
        public static string ReadString(string caption, bool required = false)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string value = Console.ReadLine();
            Console.ResetColor();
            if (required == true && string.IsNullOrWhiteSpace(value))
            {
                PrintError("Bosh buraxila bilmez");
                goto l1;
            }
            return value;
        }

        public static int ReadInt(string caption, int minValue = 0)
        {
        l1:
            Console.Write(caption);
            string value = Console.ReadLine();

            if (!int.TryParse(value, out int number))
            {
                PrintError("Duzgun eded daxil edilmeyib");
                goto l1;
            }
            else if (minValue > number)
            {
                PrintError($"Minimal {minValue} daxil edile biler");
                goto l1;
            }
            return number;
        }

        public static double ReadDouble(string caption, double minValue = 0)
        {
        l1:
            Console.Write(caption);
            string value = Console.ReadLine();
            double number;
            if (!double.TryParse(value, out number))
            {
                PrintError("Duzgun eded daxil edilmeyib");
                goto l1;
            }
            else if (minValue > number)
            {
                PrintError($"Minimal {minValue} daxil edile biler");
                goto l1;
            }
            return number;
        }

        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void Init(string appName)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = appName;

            CultureInfo ci = new CultureInfo("az-Latn-Az");
            ci.NumberFormat.NumberDecimalSeparator = ".";

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public static MenuStates ReadMenu(string caption)
        {
        l1:
            Console.Write(caption);
            string value = Console.ReadLine();
            if (!Enum.TryParse(value,out MenuStates menu))
            {
                PrintError("Bele menu movcud deyil");
                goto l1;
            }

            bool success = Enum.IsDefined(typeof(MenuStates), menu);
            if (!success)
            {
                PrintError("Bele menu movcud deyil");
                goto l1;
            }
            return menu;
        }

        public static void PrintMenu()
        {

            Helpers.PrintWarning("--------------Menu------------");
            foreach (var item in Enum.GetValues(typeof(MenuStates)))
            {
                Helpers.PrintWarning($"{((byte)item).ToString().PadLeft(2)}.{item}");
            }
            Helpers.PrintWarning("------------------------------");
        }

        public static void PrintWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void SaveToFile(string filename,object graphData)
        {
            using (var fs = new FileStream(filename,FileMode.OpenOrCreate,FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs,graphData);
            }
        }

        public static object LoadFromFile(string filename)
        {

            if (!File.Exists(filename))
            {
                return null;
            }

            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return  bf.Deserialize(fs);
            }
        }

       
    }
}
