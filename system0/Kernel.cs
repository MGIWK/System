using Cosmos.System.FileSystem;
using System;
using System.Collections.Generic;
using System.Text;
using system0.system;
using Sys = Cosmos.System;

namespace system0
{
    public class Kernel : Sys.Kernel
    {

        public static string version = "0.1.0";
        public static string SystemName = "SKIBIDI";
        public string path = @"0:\";
        public static CosmosVFS fs;
        protected override void BeforeRun()
        {
            Console.SetWindowSize(90,30);
            Console.OutputEncoding = Cosmos.System.ExtendedASCII.CosmosEncodingProvider.Instance.GetEncoding(437);
            fs = new Cosmos.System.FileSystem.CosmosVFS();
            Cosmos.System.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(SystemName + " started on version " + version);
            Console.ForegroundColor = ConsoleColor.White;

        }

        protected override void Run()
        {
            Console.Write(path + ">");
            var command = Console.ReadLine();
            ConsolCommands.RunCommand(command);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
