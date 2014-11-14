using System;
using System.Collections.Generic;
using System.Text;

namespace AuthenticationServer.Packet_Structure
{
    class Handler
    {
        private long timestamp = 0;
        public int packetId = 0;
        public string[] blocks;

        public void FillData(long timestamp, int packetId, string[] blocks)
        {
            this.timestamp = timestamp;
            this.packetId = packetId;
            this.blocks = blocks;
        }

        public string[] getAllBlocks
        {
            get
            {
                return this.blocks;
            }
        }

        public string getBlock(int i)
        {
            if (blocks[i] != null)
            {
                return blocks[i];
            }
            return null;
        }

        public virtual void Handle(User.User usr)
        {
            /* Override */
        }
    }
}
