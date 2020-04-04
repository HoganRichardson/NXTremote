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
                this.groupBoxControls.Enabled = false;
                this.groupBoxAux.Enabled = false;
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
                this.groupBoxControls.Enabled = true;
                this.groupBoxAux.Enabled = true;

            }
            this.buttonConnect.Enabled = true;

        }

        /* Direction Buttons */
        private void buttonMoveUp_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void buttonMoveUp_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void buttonMoveDown_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void buttonMoveDown_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void buttonTurnLeft_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void buttonTurnLeft_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void buttonTurnRight_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void buttonTurnRight_MouseUp(object sender, MouseEventArgs e)
        {

        }

        /* Speed Control */
        private void trackBarSpeed_ValueChanged(object sender, EventArgs e)
        {

        }

        /* Auxiliary Buttons */
        private void buttonHorn_Click(object sender, EventArgs e)
        {

        }

        private void buttonSiren_Click(object sender, EventArgs e)
        {

        }

    }
}