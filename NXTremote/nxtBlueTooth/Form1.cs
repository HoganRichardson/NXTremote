using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace NXTremote
{
    public partial class Form1 : Form
    {

        private Bluetooth bt = null;
        private Car car = null;
        public Form1()
        {
            InitializeComponent();
            bt = new Bluetooth(this.textBoxLog);
        }

        /*** EVENT HANDLERS ***/
        private void GetVersion_Click(object sender, EventArgs e)
        {
            byte[] NxtMessage = {0x01, 0x88 };
            bt.SendCommand(NxtMessage);
           
        }

        private void GetInfo_Click(object sender, EventArgs e)
        {
            byte[] NxtMessage = {0x01, 0x9B };
            bt.SendCommand(NxtMessage);
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            this.buttonConnect.Enabled = false;
            if (bt.BluetoothConnection.IsOpen)
            {
                bt.Close();

                // UI changes
                this.buttonGetInfo.Enabled = false;
                this.buttonGetVersion.Enabled = false;
                this.groupBoxControls.Enabled = false;
                this.groupBoxAux.Enabled = false;
                this.groupBoxSettings.Enabled = false;
                this.buttonConnect.Text = "Connect";
            }
            else
            {
                bt.Open(this.textBox1.Text.Trim(), 1500);

                // UI changes
                this.buttonConnect.Text = "Disconnect";
                this.buttonGetInfo.Enabled = true;
                this.buttonGetVersion.Enabled = true;
                this.groupBoxSettings.Enabled = true;
            }
            this.buttonConnect.Enabled = true;
        }

        /* Direction Buttons */
        private void buttonMoveUp_MouseDown(object sender, MouseEventArgs e)
        {
            car.startDrive(trackBarSpeed.Value);
        }

        private void buttonMoveUp_MouseUp(object sender, MouseEventArgs e)
        {
            car.stopDrive();
        }

        private void buttonMoveDown_MouseDown(object sender, MouseEventArgs e)
        {
            car.startDrive(-trackBarSpeed.Value);
        }

        private void buttonMoveDown_MouseUp(object sender, MouseEventArgs e)
        {
            car.stopDrive();
        }

        private void buttonTurnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            car.startTurn(Car.Turn.left);
        }

        private void buttonTurnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            car.stopTurn();
        }

        private void buttonTurnRight_MouseDown(object sender, MouseEventArgs e)
        {
            car.startTurn(Car.Turn.right);
        }

        private void buttonTurnRight_MouseUp(object sender, MouseEventArgs e)
        {
            car.stopTurn();
        }

        /* Speed Control */
        private void trackBarSpeed_ValueChanged(object sender, EventArgs e)
        {
            car.speedAdjust(trackBarSpeed.Value);
        }

        /* Auxiliary Buttons */
        private void buttonHorn_Click(object sender, EventArgs e)
        {

        }

        private void buttonSiren_Click(object sender, EventArgs e)
        {

        }

        /* Settings */
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            if ((radioButtonDriveA.Checked == true && radioButtonSteerA.Checked == true) ||
                    (radioButtonDriveB.Checked == true && radioButtonSteerB.Checked == true) ||
                    (radioButtonDriveC.Checked == true && radioButtonSteerC.Checked == true))
            {
                string message = "Cannot set same motor for drive and steer!";
                string caption = "Motor Configuration Error";
                MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
            else
            {
                Car.Motor driveMotor = 0;
                Car.Motor steerMotor = 0;

                if (radioButtonDriveA.Checked == true)
                {
                    driveMotor = Car.Motor.A;
                }
                else if (radioButtonDriveB.Checked == true)
                {
                    driveMotor = Car.Motor.B;
                }
                else if (radioButtonDriveC.Checked == true)
                {
                    driveMotor = Car.Motor.C;
                }

                if (radioButtonSteerA.Checked == true)
                {
                    steerMotor = Car.Motor.A;
                }
                else if (radioButtonSteerB.Checked == true)
                {
                    steerMotor = Car.Motor.B;
                }
                else if (radioButtonSteerC.Checked == true)
                {
                    steerMotor = Car.Motor.C;
                }

                // Initialise Car Instance
                car = new Car(bt, driveMotor, steerMotor); // TODO add limit
             
                this.groupBoxControls.Enabled = true;
                this.groupBoxAux.Enabled = true;
                this.groupBoxSettings.Enabled = false;
            }
        }
    }
}