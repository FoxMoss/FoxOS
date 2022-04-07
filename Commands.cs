using System;
using Sys = Cosmos.System;

namespace FoxOS
{
    public static class Commands
    {
        public static void ParseCommand(string comm) 
        {
            string[] splits = comm.Split(" ");
            try
            {
            switch (splits[0])
            {
                case "hi":
                    Write("Hello :) \n", ConsoleColor.White);
                    break;
                case "dir":
                    Files.GetFilesInDir(Kernel.filePointer);
                    break;
                case "cat":
                    Files.Cat(Kernel.filePointer + splits[1]);
                    break;
                case "rm":
                    Files.RemoveFile(Kernel.filePointer + splits[1]);
                    break;
                case "wrf":
                    Files.WriteFile(Kernel.filePointer + splits[1]);
                    break;
                case "basic":
                    Files.Basic(Kernel.filePointer + splits[1]);
                    break;
                case "":
                    break;
                default:
                    Write("ERROR: COMMAND NOT FOUND \n", ConsoleColor.Red);
                break;
            }

            }
            catch (Exception)
            {
                Write("ERROR: ARGS NOT PRESENT", ConsoleColor.Red);
            }
        }

        public static void Write(string msg, ConsoleColor clr)
        {
            Console.ForegroundColor = clr;
            Console.Write(msg);
            Console.ResetColor();
        }

    }
}
