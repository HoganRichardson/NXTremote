using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace nxtBlueTooth
{
    public partial class Form1 : Form
    {
        private
        SerialPort BluetoothConnection= new SerialPort();
        public Form1()
        {
            InitializeComponent();
        }



        private void GetVersion_Click(object sender, EventArgs e)
        {
            byte[] NxtMessage = {0x01, 0x88 };
            NXTSendCommandAndGetReply(NxtMessage);
        }

        private void GetInfo_Click(object sender, EventArgs e)
        {
            byte[] NxtMessage = {0x01, 0x9B };
            NXTSendCommandAndGetReply(NxtMessage);
        }
        private void ReadMailBox_Click(object sender, EventArgs e)
        {
            byte[] NxtMessage = {0x00, 0x13, 0x00, 0x00,0x01 };
            NxtMessage[2] = (byte)(this.numericUpDownMailBoxNbr.Value-1+10);
            NXTSendCommandAndGetReply(NxtMessage);
        }
        private void WriteMailBoxBool_Click(object sender, EventArgs e)
        {
            byte[] NxtMessage = {0x00, 0x09, 0x00, 0x02, 0x00, 0x00 };
            NxtMessage[2] = (byte)(this.numericUpDownMailBoxNbr.Value-1);
            NxtMessage[4] = (byte)this.numericUpDownBool.Value;
            NXTSendCommandAndGetReply(NxtMessage);
        }
        private void WriteMailBoxInt_Click(object sender, EventArgs e)
        {
            byte[] NxtMessage = { 0x00, 0x09, 0x00, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00 };
            NxtMessage[2] = (byte)(this.numericUpDownMailBoxNbr.Value - 1);
            int tmp = (int)this.numericUpDownInt.Value;
            for (int ByteCtr = 0; ByteCtr <= 3; ByteCtr++)
            {
                NxtMessage[4+ByteCtr] = (byte) tmp;
                tmp>>=8;
            }
            NXTSendCommandAndGetReply(NxtMessage);
        }


        private void NXTSendCommandAndGetReply(byte[] Command)
        {

            Byte[] MessageLength= {0x00, 0x00};
            
            MessageLength[0]=(byte)Command.Length;
            this.textBox2.Text += "TX:";
            for (int i = 0; i < Command.Length; i++)
                this.textBox2.Text += Command[i].ToString("X2") + " ";
            this.textBox2.Text += Environment.NewLine;
            this.textBox2.Select(this.textBox2.Text.Length, 0);
            this.textBox2.ScrollToCaret();

            BluetoothConnection.Write(MessageLength, 0, MessageLength.Length);
            BluetoothConnection.Write(Command, 0, Command.Length);
            int length = BluetoothConnection.ReadByte() + 256 * BluetoothConnection.ReadByte();
            this.textBox2.Text += "RX:";
            for(int i=0;i<length ;i++)
                this.textBox2.Text+=BluetoothConnection.ReadByte().ToString("X2")+" ";
            this.textBox2.Text += Environment.NewLine;
            this.textBox2.Select(this.textBox2.Text.Length, 0);
            this.textBox2.ScrollToCaret();
            }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            this.buttonConnect.Enabled = false;
            if (BluetoothConnection.IsOpen)
            {
                this.buttonGetInfo.Enabled = false;
                this.buttonGetVersion.Enabled = false;
                this.buttonReadMailbox.Enabled = false;
                this.buttonWriteMailboxBool.Enabled = false;
                this.buttonWriteMailBoxInt.Enabled = false;
                BluetoothConnection.Close();
                this.buttonConnect.Text = "Connect";
            }
            else
            {
                this.buttonConnect.Text = "Disconnect";
                this.BluetoothConnection.PortName = this.textBox1.Text.Trim();
                BluetoothConnection.Open();
                BluetoothConnection.ReadTimeout = 1500;
                this.buttonGetInfo.Enabled = true;
                this.buttonGetVersion.Enabled = true;
                this.buttonReadMailbox.Enabled = true;
                this.buttonWriteMailboxBool.Enabled = true;
                this.buttonWriteMailBoxInt.Enabled = true;
            }
            this.buttonConnect.Enabled = true;

        }
    }
}