using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXTremote
{
    class PlaySound
    {
        private int MSG_SIZE = 22;
        private byte CommandType { get; }
        private byte Command { get; }
        private bool Loop { get; }
        private string Filename { get; }
        public PlaySound (string filename, bool loop = false)
        {
            CommandType = 0x00;     // Byte 0
            Command = 0x02;         // Byte 1
            Loop = loop;            // Byte 2
            Filename = filename;    // Byte 3-22 (null-terminated string)

        }
        public byte[] ToCommand()
        {
            List<byte> cmdList = new List<byte>();
            cmdList.Add((byte)CommandType);
            cmdList.Add((byte)Command);
            cmdList.AddRange(BitConverter.GetBytes(Loop));
            cmdList.AddRange(Encoding.ASCII.GetBytes(Filename));
            for (int i = 0; i < (MSG_SIZE - cmdList.Count); i++)
            {
                cmdList.Add(0); // null terminator/padding
            }
            byte[] command = cmdList.ToArray();

            return command;
        }
    }
}
