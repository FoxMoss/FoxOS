using System;
using System.Collections.Generic;
using Sys = Cosmos.System;

namespace FoxOS
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        public static string filePointer = @"0:\";
        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Clear();
            Console.WriteLine("FoxOS booted");
            var available_space = fs.GetAvailableFreeSpace(@"0:\");
            Console.WriteLine("Available Free Space: " + available_space);
            var fs_type = fs.GetFileSystemType(@"0:\");
            Console.WriteLine("File System Type: " + fs_type);

        }

        protected override void Run()
        {
            Console.Write(filePointer + ">");
            var input = Console.ReadLine();
            Commands.ParseCommand(input);
        }
        public static void Clear()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
        }

    }
}
