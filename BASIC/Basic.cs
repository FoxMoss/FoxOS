using System;
using System.Collections.Generic;

namespace FoxOS
{
    public class Basic
    {
        public IDictionary<int, string> lines = new Dictionary<int, string>();
        public List<int> linehits = new List<int>();
        public int curentline = 0;
        public object memoryPoint;
        string kill = "";
        public void ParseLines(string code)
        {
            string[] splitbyline = code.Split("\n");
            foreach (string item in splitbyline)
            {

                int index = int.Parse(item.Split(" ")[0]);
                lines.Add(index, item);
                linehits.Add(index);
            }
        }
        public static List<int> SortList(List<int> og)
        {
            List<int> sorted = og;
            bool tampered = true;
            while (tampered)
            {
                tampered = false;

                for (int x = 0; x < sorted.Count; x++)
                {

                    for (int y = 0; y < sorted.Count; y++)
                    {
                        if (x > y && sorted[x] < sorted[y])
                        {
                            sorted[x - 1] = sorted[x];
                            sorted[x] = sorted[x - 1];
                            tampered = true;
                        }
                        if (x < y && sorted[x] > sorted[y])
                        {
                            int store = sorted[x + 1];
                            sorted[x + 1] = sorted[x];
                            sorted[x] = store;
                            tampered = true;

                        }

                    }
                }

            }

            return sorted;

        }
        public void Run(string code)
        {
            try
            {
                ParseLines(code);
                linehits = SortList(linehits);
                if (kill != "")
                {
                    Commands.Write(kill, ConsoleColor.Red);
                }
                while (linehits.Count != curentline)
                {
                    if (Console.KeyAvailable == true)
                    {
                        var input = Console.ReadKey();
                        if (input.Key == ConsoleKey.Escape)
                        {
                            return;
                        }
                    }
                    RunLine();
                    if (kill != "")
                    {
                        Commands.Write(kill, ConsoleColor.Red);
                    }
                }

            }
            catch (Exception)
            {
                Commands.Write("BASIC ERROR: I HAVE NO CLUE WHAT THE HELL HAPPENED. IT BROKE ON LINE " + curentline, ConsoleColor.Red);
            }

        }
        public void RunLine()
        {
            string curline = lines[linehits[curentline]];
            switch (curline.Split(" ")[1])
            {
                case "PRINT":
                    Console.WriteLine(curline.Split("PRINT ")[1]);
                    break;
                case "GOTO":
                    try
                    {
                        curentline = linehits.IndexOf(int.Parse(curline.Split(" ")[2]));
                        return;
                    }
                    catch (Exception)
                    {
                        kill = "BASIC ERROR: LINE NOT FOUND " + curline.Split(" ")[2];
                        return;
                    }
                case "STORE":
                    try
                    {
                        if (memoryPoint == null) {
                            kill = "BASIC ERROR: VAR NOT FOUND IN SAVE ON LINE : " + linehits[curentline];
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        kill = "BASIC ERROR: LINE NOT FOUND " + curline.Split(" ")[2];
                        return;
                    }
                    break;
                case "":
                    break;
                default:
                    kill = "BASIC ERROR: COMMAND NOT FOUND ON LINE " + linehits[curentline] + "|" + curline;
                    return;
            }
            curentline++;
        }
    }
}
