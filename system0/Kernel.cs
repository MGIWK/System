using Cosmos.Core.Memory;
using Cosmos.System.FileSystem;
using System;
using System.Collections.Generic;
using System.Text;
using system0.Graphics;
using system0.system;
using Sys = Cosmos.System;

namespace system0
{
    public class Kernel : Sys.Kernel
    {

        public static string version = "0.1.5";
        public static string SystemName = "bulboOS";
        public static string path = @"0:\";
        public static CosmosVFS fs;
        public static bool RunGui;
        int lastHeapCollect;

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
            if(!RunGui)
            {
                Console.Write(path + ">");
                var command = Console.ReadLine();
                ConsolCommands.RunCommand(command);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                GUI.Update();
            }
            if (lastHeapCollect >= 20)
            {
                Heap.Collect();
                lastHeapCollect = 0;
            }
            else
                lastHeapCollect++;
        }
    }
}
