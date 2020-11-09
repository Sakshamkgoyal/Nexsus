using System;
using System.IO;
using Sys = Cosmos.System;


namespace Nexsus
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            var fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("     ***** *     **                                                      ");
            Console.WriteLine("  ******  **    **** *                                                   ");
            Console.WriteLine(" **   *  * **    ****                                                    ");
            Console.WriteLine("*    *  *  **    * *                                                     ");
            Console.WriteLine("    *  *    **   *                ***    ***    **   ****        ****    ");
            Console.WriteLine("   ** **    **   *        ***    * ***  **** *   **    ***  *   * **** * ");
            Console.WriteLine("   ** **     **  *       * ***      *** *****    **     ****   **  ****  ");
            Console.WriteLine("   ** **     **  *      *   ***      ***  **     **      **   ****       ");
            Console.WriteLine("   ** **      ** *     **    ***      ***        **      **     ***      ");
            Console.WriteLine("   ** **      ** *     ********      * ***       **      **       ***    ");
            Console.WriteLine("   *  **       ***     *******      *   ***      **      **         ***  ");
            Console.WriteLine("      *        ***     **          *     ***     **      **    ****  **  ");
            Console.WriteLine("  ****          **     ****    *  *       *** *   ******* **  * **** *   ");
            Console.WriteLine(" *  *****               *******  *         ***     *****   **    ****    ");
            Console.WriteLine("*     **                 *****                                           ");
            Console.WriteLine("*                                                                        ");
            Console.WriteLine(" **                                                                      ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("*************************************************************************");

            string[] userName = new string[2] { "guest", "admin" };
            Console.WriteLine(">>Enter UserName to Login: ");
            string user = Console.ReadLine();
            switch (user)
            {
                case "guest":
                    {
                        Console.WriteLine("*Welcome Guest!*");
                        break;
                    }
                case "admin":
                    {
                        Console.WriteLine("*Welcome to NEXUS ALPHA*");
                        break;
                    }
                default:
                    {
                        Cosmos.HAL.Power.ACPIShutdown();
                        break;
                    }
            }
        }

        protected override void Run()
        {
            Console.WriteLine("User session started");
            Console.WriteLine("********");
            Console.WriteLine("");
            Console.WriteLine("Type 'help' for options");
            Console.WriteLine("********");
            Console.WriteLine("");
            string helpInput = Console.ReadLine();
            Console.WriteLine("********");
            Console.WriteLine("");
            //boot shutdown = false;
            while (helpInput == "help")
            {
                Console.WriteLine(">>cmd line for NEXUS ALPHA");
                Console.WriteLine(">> shutdown - Shutdown");
                Console.WriteLine(">>restart - Reboot");
                Console.WriteLine(">>snake - Snakes Gmae 1.0");
                Console.WriteLine(">> file - NEXUS File System 1.0");
                Console.WriteLine(">> calc - NEXUS Calculator v1.0");
                Console.WriteLine("about - About");

                string Command = Console.ReadLine();
                switch (Command)
                {
                    case "about":
                        {
                            Console.WriteLine("");
                            Console.WriteLine("*****************************************");
                            Console.WriteLine("NEXUS APHA Developed By Dhananjay, Saksham, Jay, Saatvik");
                            Console.WriteLine("*****************************************");
                            Console.WriteLine("");
                            break;
                        }

                    case "snake":
                        {
                            char ch;
                            int col = 38, row = 15;
                            System.Console.CursorVisible = false;
                            System.Console.SetCursorPosition(col, row);
                            System.Console.Write("*");
                            for (; ; )
                            {
                                ch = System.Console.ReadKey(true).KeyChar;
                                System.Console.SetCursorPosition(col, row);
                                System.Console.Write(" ");
                                switch (ch)
                                {
                                    case 'a':
                                        --col;
                                        break;
                                    case 'w':
                                        --row;
                                        break;
                                    case 's':
                                        ++row;
                                        break;
                                    case 'd':
                                        ++col;
                                        break;
                                    case 'q':
                                        goto EXIT;
                                }
                                System.Console.SetCursorPosition(col, row);
                                System.Console.Write("*");
                            }
                        EXIT:
                            System.Console.CursorVisible = true;
                            break;
                        }
                    case "shutdown":
                        {
                            Cosmos.HAL.Power.ACPIShutdown();
                            break;
                        }
                    case "restart":
                        {
                            Cosmos.HAL.Power.CPUReboot();
                            break;
                        }
                    case "calc":
                        {
                            double a, b;
                            char c;
                            Console.WriteLine("");

                            Console.WriteLine("*****************");
                            Console.WriteLine("NEXUS CALC");

                            Console.WriteLine("Enter First Number: ");
                            a = Double.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Second Number: ");
                            b = Double.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Sign (+ - * /): ");
                            c = Char.Parse(Console.ReadLine());

                            switch (c)
                            {
                                case '+':
                                    Console.WriteLine("{0}+{1}={2}", a, b, a + b);
                                    Console.WriteLine("");
                                    break;

                                case '-':
                                    Console.WriteLine("{0}-{1}={2}", a, b, a - b);
                                    Console.WriteLine("");
                                    break;

                                case '*':
                                    Console.WriteLine("{0}*{1}={2}", a, b, a * b);
                                    Console.WriteLine("");
                                    break;

                                case '/':
                                    Console.WriteLine("{0}/{1}={2}", a, b, a / b);
                                    Console.WriteLine("");
                                    break;

                                default:
                                    Console.WriteLine("Unknown  sign!");
                                    break;

                            }
                            break;
                        }
                    case "file":
                        {
                            Console.WriteLine("Enter the file name");
                            string fileName = Console.ReadLine();
                            try
                            {
                                // Delete the file if it exists.
                                if (File.Exists(fileName))
                                {
                                    File.Delete(fileName);
                                }
                                Console.Write("\n\n Append some text to an existing file  :\n");
                                Console.Write("--------------------------------------------\n");
                                // Create the file.
                                using (StreamWriter fileStr = File.CreateText(fileName))
                                {
                                    string content = Console.ReadLine();
                                    fileStr.WriteLine(content);
                                }
                                using (StreamReader sr = File.OpenText(fileName))
                                {
                                    string s = "";
                                    Console.WriteLine(" Here is the content of the file "+fileName+"  : ");
                                    while ((s = sr.ReadLine()) != null)
                                    {
                                        Console.WriteLine(s);
                                    }
                                    Console.WriteLine("");
                                }
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"mytest.txt", true))
                                {
                                    file.WriteLine(" This is the line appended at last line.");
                                }
                                using (StreamReader sr = File.OpenText(fileName))
                                {
                                    string s = "";
                                    Console.WriteLine(" Here is the content of the file after appending the text : ");
                                    while ((s = sr.ReadLine()) != null)
                                    {
                                        Console.WriteLine(s);
                                    }
                                    Console.WriteLine("");
                                }

                            }
                            catch (Exception MyExcep)
                            {
                                Console.WriteLine(MyExcep.ToString());
                            }
                            break;
                        }
                    case "read":
                        {
                            Console.WriteLine("Please enter the file name to be read: ");
                            String file_name = Console.ReadLine();

                            String line;

                            try
                            {
                                StreamReader sr = new StreamReader(file_name);

                                line = sr.ReadLine();

                                while (line != null)
                                {
                                    Console.WriteLine(line);
                                    line = sr.ReadLine();
                                }
                                sr.Close();
                                Console.ReadLine();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception: " + e.Message);
                            }
                            break;
                        }
                    case "Write":
                        {
                            Console.WriteLine("Please enter the file name to write: ");
                            String file_name = Console.ReadLine();
                            Console.WriteLine("\nPlease enter the content to write to the file:\n");
                            String content = Console.ReadLine();
                            try
                            {
                                StreamWriter sw = new StreamWriter(file_name);
                                sw.WriteLine(content);
                                sw.Close();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception : " + e.Message);
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("***");
                            Console.WriteLine("Invalid Command");
                            Console.WriteLine("Please refer to cmd line for NEXUS");
                            Console.WriteLine("***");
                            break;
                        }

                }
            }
        }
    }
}
