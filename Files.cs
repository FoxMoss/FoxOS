using System;
using System.IO;
using System.Text.RegularExpressions;

namespace FoxOS
{
    public static class Files
    {
        public static void GetFilesInDir(string dir)
        {
            var directory_list = Directory.GetFiles(dir);
            foreach (var file in directory_list)
            {
                Console.WriteLine(file);
            }
        }
        public static void Cat(string file)
        {
            var content = File.ReadAllText(file);
            Console.WriteLine(content);
        }
        public static void RemoveFile(string file)
        {
            File.Delete(file);
        }
        public static void WriteFile(string file)
        {
            string outText = "";
            int cursorIndex = 0;
            while (true)
            {
                Console.Clear();
                Console.Write(outText);
                var input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.LeftArrow)
                {
                    cursorIndex--;
                    Console.CursorLeft--;
                    if (cursorIndex < 0)
                    {
                        cursorIndex = 0;
                        Console.CursorLeft = 0;
                    }
                    if (Console.CursorLeft < 0 && Console.CursorTop != 0)
                    {
                        Console.CursorLeft = 0;
                        Console.CursorTop++;
                    }
                }
                else if (input.Key == ConsoleKey.RightArrow)
                {
                    cursorIndex++;
                    Console.CursorLeft++;
                    if (cursorIndex > outText.Length)
                    {
                        cursorIndex--;
                    }
                    if (Console.CursorLeft > Console.WindowWidth && Console.CursorLeft + Console.CursorTop * Console.WindowWidth != outText.Length)
                    {
                        Console.CursorLeft = 0;
                        Console.CursorTop++;
                    }
                }
                else if (input.Key == ConsoleKey.Escape)
                {
                    try
                    {
                        if (!File.Exists(file))
                        {
                            var file_stream = File.Create(file);
                        }
                        File.WriteAllText(file, outText);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    return;
                }
                else if (input.Key == ConsoleKey.Enter)
                {
                    outText = outText.Insert(cursorIndex, "\n");
                    cursorIndex++;
                    Console.CursorTop++;
                }
                else if (input.Key == ConsoleKey.Backspace)
                {
                    try
                    {
                        if (outText[cursorIndex - 1] == '\n')
                        {
                            Console.CursorTop--;
                        }
                        outText = outText.Remove(cursorIndex - 1);
                        cursorIndex--;
                    }
                    catch (Exception) 
                    {
                    }
                }
                else if (input.KeyChar >= 0 && input.KeyChar <= 126)
                {
                    outText = outText.Insert(cursorIndex, input.KeyChar.ToString());
                    cursorIndex++;
                }
            }

        }
        public static void Basic(string file) 
        {
            Basic basic = new Basic();
            basic.Run(File.ReadAllText(file));
        }
    }
}
