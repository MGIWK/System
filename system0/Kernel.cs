using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace system0
{
    public class Kernel : Sys.Kernel
    {

        static public string version = "0.1.0";
        static public string SystemName = "SKIBIDI";
        public string path = @"0:\";
        protected override void BeforeRun()
        {
            Console.SetWindowSize(90,30);
            Console.OutputEncoding = Cosmos.System.ExtendedASCII.CosmosEncodingProvider.Instance.GetEncoding(437);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(SystemName + " started on version " + version);
            Console.ForegroundColor = ConsoleColor.White;

        }

        protected override void Run()
        {
            Console.Write(path + ">");
            var command = Console.ReadLine();
        }
    }
}
