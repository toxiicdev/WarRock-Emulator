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
    class Program
    {
        private const double rev = 0.1;
        static void Main(string[] args)
        {
            Console.Title = "WarRock Emulator Rev " + rev + "a";
            
            Network.NetworkSocket.Initialize(4002);
            Managers.PacketManager.InitializePacketTable();

            Console.ReadLine(); // Just a temporary way to avoid window to close
        }
    }
}
