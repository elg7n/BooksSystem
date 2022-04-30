using System;

namespace BookSystem.Lib
{
    public class Helpers
    {
        public static string ReadString(string caption,bool required=false)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string value = Console.ReadLine();
            Console.ResetColor();
            if (required==true && string.IsNullOrWhiteSpace(value))
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

            if (!int.TryParse(value,out int number))
            {
                PrintError("Duzgun eded daxil edilmeyib");
                goto l1;
            }
            else if(minValue > number)
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
            if (!double.TryParse(value,out  number))
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
    }
}
