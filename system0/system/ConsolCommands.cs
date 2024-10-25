using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
                else if (words[0] == "format")
                {
                    if (Kernel.fs.Disks[0].Partitions.Count > 0)
                    {
                        Kernel.fs.Disks[0].DeletePartition(0);
                    }
                    Kernel.fs.Disks[0].Clear();
                    Kernel.fs.Disks[0].CreatePartition((int)(Kernel.fs.Disks[0].Size / (1024 * 1024)));
                    Kernel.fs.Disks[0].FormatPartition(0, "FAT32", true);
                    WriteMessage.WriteOk("Partition successful");
                    WriteMessage.WriteWarn(Kernel.SystemName + " will reboot in 3 seconds");
                    Thread.Sleep(3000);
                    Cosmos.System.Power.Reboot();
                }
                else if (words[0] == "weight")
                {
                    long free = Kernel.fs.GetAvailableFreeSpace(Kernel.path);
                    Console.WriteLine("Free space: " + free/1024 + "KB");
                }
                else if (words[0] == "dir")
                {
                    var Directories = Directory.GetDirectories(Kernel.path);
                    var Files = Directory.GetFiles(Kernel.path);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Directories (" + Directories.Length + ")");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    for (int i = 0; i < Directories.Length; i++)
                    {
                        Console.WriteLine(Directories[i]);
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Files (" + Files.Length + ")"); Console.ForegroundColor = ConsoleColor.Gray;
                    for (int i = 0; i < Files.Length; i++)
                    {
                        Console.WriteLine(Files[i]);
                    }
                   }
            }
            else
            {

            }
        }
    }
}
