using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system0.system
{
    public static class WriteMessage
    {
        public static void WriteError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[ERROR] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(error);
        }
        public static void WriteWarn(string warn)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[Warning] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(warn);
        }
        public static void WriteInfo(string info)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[Info] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(info);
        }
        public static void WriteLogo()
        {
            Console.WriteLine(CenterText(@" __                       __       __  "));
            Console.WriteLine(CenterText(@"|  \    |    |    |      |  \     /  \ "));
            Console.WriteLine(CenterText(@"|__/    |    |    |      |__/    |    |"));
            Console.WriteLine(CenterText(@"|  \    |    |    |      |  \    |    |"));
            Console.WriteLine(CenterText(@"|__/     \__/     \__    |__/     \__/ "));
        }
        public static string CenterText(string text) {
            int consoleWidth = 90;
            int padding = (consoleWidth - text.Length) / 2;
            string centeredText = text.PadLeft(padding + text.Length).PadRight(consoleWidth);
            return centeredText;
        }
        public static void WriteOk(string ok)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[OK] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(ok);
        }
    }
}
