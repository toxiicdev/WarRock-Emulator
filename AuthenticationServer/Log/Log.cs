/* WarRock Emulator 
 * 
 * Author: ToXiiC
 * Date: 14-11-14
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace AuthenticationServer
{
    class Log
    {
        private static object lockobject = new object();
        public static void WriteLog(string log)
        {
            Write(log, ConsoleColor.Gray);
        }

        public static void WriteDebug(string log)
        {
            Write(log, ConsoleColor.DarkMagenta);
        }
        public static void WriteUnknown(string log)
        {
            Write(log, ConsoleColor.DarkCyan);
        }

        public static void WriteError(string log)
        {
            Write(log, ConsoleColor.Red);
        }

        private static void Write(string log, ConsoleColor c)
        {
            lock (lockobject)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[" + DateTime.Now.ToString("HH:mm:ss") + "] >> ");
                Console.ForegroundColor = c;
                Console.Write(log);
                Console.WriteLine();
            }
        }
    }
}
