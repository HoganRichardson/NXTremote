using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;

namespace NXTremote
{
    class Bluetooth
    {
        public
        SerialPort BluetoothConnection { get; }
        public TextBox Log { get; }
        public Bluetooth(TextBox log)
        {
            BluetoothConnection = new SerialPort();
            Log = log;
        }
        public void Open(string portName, int timeout)
        {
            BluetoothConnection.PortName = portName;
            BluetoothConnection.Open();
            BluetoothConnection.ReadTimeout = timeout;
        }
        public void Close ()
        {
            BluetoothConnection.Close();
        }
        public byte[] SendCommand(byte[] Command)
        {
            Byte[] MessageLength = { 0x00, 0x00 };
            string log = "";

            // Send Message
            MessageLength[0] = (byte)Command.Length;
            log += "TX: ";
            for (int i = 0; i < Command.Length; i++)
                log += Command[i].ToString("X2") + " ";
            log += Environment.NewLine;

            BluetoothConnection.Write(MessageLength, 0, MessageLength.Length);
            BluetoothConnection.Write(Command, 0, Command.Length);

            // Get Response
            List<byte> response = new List<byte>();
            int length = BluetoothConnection.ReadByte() + 256 * BluetoothConnection.ReadByte();
            log += "RX: ";
            for (int i = 0; i < length; i++)
            {
                response.Add((byte)BluetoothConnection.ReadByte());
                log += response.Last().ToString("X2") + " ";
            }
            log += Environment.NewLine;

            logWrite(log);
            return response.ToArray();
        }

        private void logWrite (string logText)
        {
            Log.Text += logText;
            Log.Select(Log.Text.Length, 0);
            Log.ScrollToCaret();
        }
    }
}
