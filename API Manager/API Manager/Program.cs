using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace API_Manager
{
    class Program
    {
        public static string[] conf;
        public static string configLoc = "C:/users/" + Environment.UserName + "/AppData/Local/Temp/apimgr/config.txt";
        
        static void Main(string[] args)
        {
            if(hasConfig() == false)
            {
                Console.Title = "API Manager Configure";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Create a configuration\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Server IP: ");
                string ip = Console.ReadLine();
                Console.WriteLine("Admin Key: ");
                string key = Console.ReadLine();
                if(ip.Contains(".") == false)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Server IP is invalid...\n");
                    Console.ReadLine();
                }
                else
                {
                    CreateConf(ip, key);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("[-] ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Loading Configuration...\n");
                ReadConf();
                Thread.Sleep(1200);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[+] ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Configuration Loaded...\n");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[+] ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Hooked Socket Components...\n");
                Console.ReadLine();
            }
        }

        protected static Boolean hasConfig()
        {
            if(File.Exists(configLoc))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected static void ReadConf()
        {
            conf = File.ReadLines(configLoc).ToArray();
        }

        protected static void CreateConf(string ip, string key)
        {
            string dir = "C:/users/" + Environment.UserName + "/AppData/Local/Temp/apimgr";
            if(Directory.Exists(dir) == false)
            {
                Directory.CreateDirectory(dir);
            }
            File.WriteAllText(configLoc, ip + "\n" + key);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[+] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Successfully Configured!");
            Console.ReadLine();
        }
    }
}
