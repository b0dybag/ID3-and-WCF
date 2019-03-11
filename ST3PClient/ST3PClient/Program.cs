using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST3PClient
{
    class Program
    {
        static void CWError(string text, ConsoleColor color = ConsoleColor.Red)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void Main(string[] args)
        {
            bool isFileOk = false;
            List<List<string>> body = new List<List<string>>() { };
            List<string> head = new List<string>();
            int decPos = 0;
            bool fileOpened = false;
            bool Work = true;
            Parsing parser = new Parsing();

            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            while (Work)
            {
                Console.WriteLine("Write command or type 'Help' to get help");
                string command = Console.ReadLine();
                switch (command.ToLower())
                {
                    case "help":
                        {
                            Console.WriteLine("'Help' - get help");
                            Console.WriteLine("'Open' - to open file");
                            Console.WriteLine("'Line' - to insert one more record");
                            Console.WriteLine("'Tree' - to get a decision tree");
                            Console.WriteLine("'Exit' - to close application");
                            break;
                        }
                    case "open":
                        {
                            while (!isFileOk)
                            {
                                try
                                {
                                    Console.WriteLine("                         Enter the filename");
                                    Console.WriteLine("For example 'SOCZ_v07.tab' (file must be in same folder with program)");
                                    string fileName = Console.ReadLine();
                                    string[] text = System.IO.File.ReadAllLines(fileName);
                                    //Parsing parser = new Parsing();
                                    decPos = parser.GetDecisionPos(text);
                                    head = parser.GetHead(text);
                                    body = parser.GetBody(text);
                                    isFileOk = true;
                                    fileOpened = true;
                                    CWError("SUCCESS: File successfully opened!", ConsoleColor.Green);

                                    string[] mhead = head.Select(n => n.ToString()).ToArray();
                                    int count = body.Count;
                                    string[][] mbody = new string[count][];
                                    int i = 0;
                                    foreach (var item in body)
                                    {
                                        mbody[i++] = item.Select(n => n.ToString()).ToArray();
                                    }
                                    bool isSuccess = client.SetTreeInfo(mbody, mhead, decPos);

                                    if (isSuccess) CWError("SUCCESS: Serwer get your data!",ConsoleColor.Green);
                                    else
                                        CWError("ERROR: Serwer do not get your data!");

                                }
                                catch
                                {
                                    Console.Clear();
                                    CWError("ERROR: File not found!");
                                    isFileOk = false;
                                }
                            }
                            isFileOk = false;
                            break;
                        }
                    case "line":
                        Console.WriteLine("Enter your record:");
                        string line = Console.ReadLine() + "      ";
                        //Parsing parser = new Parsing();
                        List<string> record = parser.LineParsing(line);
                        string[] mrecord = record.Select(n => n.ToString()).ToArray();
                        try
                        {
                            client.AddRecord(mrecord);
                            CWError("SUCCESS: You add one more record", ConsoleColor.Green);
                        } catch
                        {
                            CWError("ERROR: Serwer do not get your record!");
                        }
                        break;
                    case "tree":
                        {
                            try {
                                string[][] info = client.GetTree();
                                foreach (var item in info)
                                {
                                    foreach (var item2 in item)
                                    {
                                        Console.Write(item2 + " ");
                                    }
                                    Console.WriteLine();
                                }
                            }
                            catch (Exception e)
                            {
                                CWError("OOPS! Something went wrong...");
                                Console.WriteLine(e.ToString());
                            }
                            break;
                        }
                    case "exit":
                        Work = false;
                        break;
                    default:
                        CWError("Unknown command!");
                        break;
                }
                //Console.WriteLine();
                CWError("Press Enter to continue...",ConsoleColor.Magenta);
                Console.ReadLine();
            }

            //while (!isFileOk)
            //{
            //    try
            //    {
            //        Console.WriteLine("                         Enter the filename");
            //        Console.WriteLine("For example 'SOCZ_v07.tab' (file must be in same folder with program)");
            //        string fileName = Console.ReadLine();
            //        string[] text = System.IO.File.ReadAllLines(fileName);
            //        Parsing parser = new Parsing();
            //        decPos = parser.GetDecisionPos(text);
            //        head = parser.GetHead(text);
            //        body = parser.GetBody(text);
            //        isFileOk = true;
            //        Console.WriteLine("SUCCES: File successfully opened!");
            //    }
            //    catch
            //    {
            //        Console.Clear();
            //        Console.WriteLine("ERROR: File not found!");
            //        isFileOk = false;
            //    }
            //}
            //Console.Clear();
            //ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            //try
            //{
            //    string[] mhead = head.Select(n => n.ToString()).ToArray();
            //    int count = body.Count;
            //    string[][] mbody = new string[count][];
            //    int i = 0;
            //    foreach (var item in body)
            //    {
            //        mbody[i++]= item.Select(n => n.ToString()).ToArray();
            //    }
            //    string[] [] info = client.Income(mbody, mhead, decPos);

            //    foreach (var item in info)
            //    {
            //        foreach (var item2 in item)
            //        {
            //            Console.Write(item2 + " ");
            //        }
            //        Console.WriteLine();
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("OOPS! Something went wrong... ");
            //    Console.WriteLine(e.ToString());
            //}
            //Console.ReadLine();
        }
    }
}
