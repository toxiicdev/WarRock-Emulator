using System;
using System.Collections.Generic;
using System.Text;

namespace AuthenticationServer.Managers
{
    class PacketManager
    {
        internal enum Packets : int
        {
            Login = 4352 // Example
        }

        private static Dictionary<int, Packet_Structure.Handler> packet_Table = new Dictionary<int, Packet_Structure.Handler>();

        public static void InitializePacketTable()
        {
            // Here fill will the handlers and packets
        }

        private static bool AddPacket(int packetId, Packet_Structure.Handler handler)
        {
            if (!packet_Table.ContainsKey(packetId))
            {
                packet_Table.Add(packetId, handler);
                return true;
            }
            Log.WriteError("DUPLICATE Packet ID Handler: " + packetId);
            return false;
        }

        public static Packet_Structure.Handler ParsePacket(string packet)
        {
            string[] packetBlocks = packet.Split(' ');
            long timestamp;
            long.TryParse(packetBlocks[0], out timestamp);
            int packetId;
            int.TryParse(packetBlocks[1], out packetId);

            if (timestamp > 0 && packetId > 0)
            {
                if (packet_Table.ContainsKey(packetId))
                {
                    string[] resizedBlocks = new string[packetBlocks.Length - 2];
                    Array.Copy(packetBlocks, 2, resizedBlocks, 0, packetBlocks.Length - 2);
                    Packet_Structure.Handler handler = (Packet_Structure.Handler)packet_Table[packetId];
                    handler.FillData(timestamp, packetId, resizedBlocks);
                    return handler;
                }
            }
            return null;
        }
    }
}
