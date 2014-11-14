/* WarRock Emulator 
 * 
 * Author: ToXiiC
 * Date: 14-11-14
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace AuthenticationServer.Network
{
    class NetworkSocket
    {
        private static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public static bool Initialize(int port)
        {
            Log.WriteLog("Initializing new socket on the port " + port + "..");
            try
            {
                socket.Bind(new IPEndPoint(IPAddress.Parse("0.0.0.0"), port));
                socket.Listen(0);
                Log.WriteLog("Socket initialized successfully!");
                socket.BeginAccept(new AsyncCallback(OnNewAuthConnection), socket);
                Log.WriteLog("Listening new authentication connections..");
            }
            catch(Exception ex)
            {
                Log.WriteError(string.Format("Error while initializing new socket on the port {0}.\r\n{1}.", port, ex.Message));
            }
            return true;
        }

        private static void OnNewAuthConnection(IAsyncResult iAr)
        {
            try
            {
                socket.BeginAccept(new AsyncCallback(OnNewAuthConnection), socket);
                Socket rSocket = ((Socket)(iAr.AsyncState)).EndAccept(iAr);

                string rIp = rSocket.RemoteEndPoint.ToString().Split(':')[0];

                User.User usr = new User.User(rSocket, rIp);

                Log.WriteLog("New user connected with ip " + rIp);
            }
            catch { }
        }
    }
}
