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
                else if (words[0] == "echo")
                {
                    if (words.Length > 1)
                    {
                        string wholestring = "";
                        for (int i = 1;i < words.Length;i++)
                        {
                            wholestring += words[i] + " "; 
                        }
                        int pathIndex = wholestring.LastIndexOf(">");
                        string text = wholestring.Substring(0, pathIndex);
                        string path = wholestring.Substring(pathIndex + 1);
                        if(!path.Contains(@"\"))
                            path = Kernel.path + path;
                        if(path.EndsWith(' '))
                        {
                            path = path.Substring(0, path.Length - 1);
                        }
                        var file_stream = File.Create(path);
                        file_stream.Close();
                        File.WriteAllText(path, text);
                    }
                    else
                        WriteMessage.WriteError("Invalid Syntax");
                }
                else if (words[0] == "cat")
                {
                    if (words.Length > 1)
                    {

                        string path = words[1];
                        if (!path.Contains(@"\"))
                            path = Kernel.path + path;
                        if (path.EndsWith(' '))
                        {
                            path = path.Substring(0, path.Length - 1);
                        }
                        if (File.Exists(path))
                        {
                            string text = File.ReadAllText(path);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine(text);
                        }
                        else
                            WriteMessage.WriteError("File " + path + " not found!");
                    }
                    else
                        WriteMessage.WriteError("Invalid Syntax");
                }
                else if (words[0] == "del")
                {
                    if (words.Length > 1)
                    {

                        string path = words[1];
                        if (!path.Contains(@"\"))
                            path = Kernel.path + path;
                        if (path.EndsWith(' '))
                        {
                            path = path.Substring(0, path.Length - 1);
                        }
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                            WriteMessage.WriteOk("Deleted " + path + "!");
                        }
                        else
                            WriteMessage.WriteError("File " + path + " not found!");
                    }
                    else
                        WriteMessage.WriteError("Invalid Syntax");
                }
                else if (words[0] == "mkdir")
                {
                    if (words.Length > 1)
                    {

                        string path = words[1];
                        if (!path.Contains(@"\"))
                            path = Kernel.path + path;
                        if (path.EndsWith(' '))
                        {
                            path = path.Substring(0, path.Length - 1);
                        }
                        Directory.CreateDirectory(path);
                    }
                    else
                        WriteMessage.WriteError("Invalid Syntax");
                }
                else if (words[0] == "cd")
                {
                    if (words.Length > 1)
                    {
                        if (words[1] == "..")
                        {
                            if (Kernel.path != @"0:\")
                            {
                                string tempPath = Kernel.path.Substring(0, Kernel.path.Length - 1);
                                Kernel.path = tempPath.Substring(0, tempPath.LastIndexOf(@"\") + 1);
                                return;
                            }
                            else
                                return;
                            
                        }
                        string path = words[1];
                        if (!path.Contains(@"\"))
                            path = Kernel.path + path;
                        if (path.EndsWith(' '))
                        {
                            path = path.Substring(0, path.Length - 1);
                        }
                        if(!path.EndsWith(@"\"))
                            path += @"\";
                        if (Directory.Exists(path))
                            Kernel.path = path;
                        else
                            WriteMessage.WriteError("Directory " + path + " not found!");

                        
                    }
                    else
                        Kernel.path = @"0:\";
                }
                else if (words[0] == "shutdown")
                {
                    Cosmos.System.Power.Shutdown();
                }
                else if (words[0] == "reboot")
                {
                    Cosmos.System.Power.Reboot();
                }
                else if(words[0] == "GUI")
                {
                    Boot.onBoot();
                }

            }
            
            else
            {
                WriteMessage.WriteError("Please enter valid command!");
            }
        }
    }
}
