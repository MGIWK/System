using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system0.system
{
    public static class ConsolCommands
    {
        public static void RunCommand(string command)
        {

            string[] words = command.Split(' ');
            if (words.Length > 0)
            {
                if (words[0] == "info")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    WriteMessage.WriteLogo();
                    Console.WriteLine(WriteMessage.CenterText(Kernel.SystemName + " " + Kernel.version));
                    Console.WriteLine(WriteMessage.CenterText("Created by zeolomk, MikiYT, GOC"));
                    Console.WriteLine(WriteMessage.CenterText("https://mikolais.pl"));
                }
                else if (words[0] == "space")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
            else
            {

            }
        }
    }
}
