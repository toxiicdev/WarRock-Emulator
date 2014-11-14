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
using System.Threading;

namespace AuthenticationServer.User
{
    class User
    {
        public User(Socket socket, string ip)
        {
            this.socket = socket;
            this.ip = ip;

            // Why thread? Because async call back will make the server laggy..not so async due it isn't using multi thread

            Thread dataThread = new Thread(ReceiveNetworkData);
            dataThread.Start();
        }

        #region Networking

        private Socket socket;
        private byte[] buffer = new byte[1024];
        public bool disconnected = false;
        public string ip;

        private void SendCallback(IAsyncResult iAr)
        {
            try { socket.EndSend(iAr); }
            catch { }
        }

        private void ReceiveNetworkData()
        {
            try
            {
                while (!disconnected)
                {
                    int length = socket.Receive(buffer);

                    if (length > 0)
                    {
                        byte[] packetBuffer = new byte[length];
                        Array.Copy(buffer, 0, packetBuffer, 0, length);
                        
                        /* To do: Handle packets*/
                    }
                    else { disconnect(); }
                }
            }
            catch { disconnect(); }
        }

        public void disconnect()
        {
            try { socket.Close(); }
            catch { }
        }

        #endregion
    }
}
