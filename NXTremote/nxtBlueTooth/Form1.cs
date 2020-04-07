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
        private PlaySound sirenSound = null;
        private PlaySound hornSound = null;
        private bool siren_on = false;
        public Form1()
        {
            InitializeComponent();
            bt = new Bluetooth(this.textBoxLog);
            sirenSound = new PlaySound("siren.rso", true);
            hornSound = new PlaySound("horn.rso");
        }

        /* Sound Helpers */
        private void soundSiren()
        {
            if (siren_on)
            {
                car.stopSound();
                siren_on = false;
                buttonSiren.Text = "Turn on siren";
                
            }
            else
            {
                car.stopSound(); // Stop any currently-playing sound
                car.playSound(sirenSound);
                siren_on = true;
                buttonSiren.Text = "Turn off siren";
            }
        }
        private void soundHorn()
        {
            car.stopSound(); // Stop any currently-playing sound
            car.playSound(hornSound);
        }

        /*** EVENT HANDLERS ***/
        private void GetVersion_Click(object sender, EventArgs e)
        {
            byte[] NxtMessage = { 0x01, 0x88 };
            bt.SendCommand(NxtMessage);
           
        }

        private void GetInfo_Click(object sender, EventArgs e)
        {
            byte[] NxtMessage = { 0x01, 0x9B };
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
            car.startDrive(trackBarSpeed.Value, Car.Direction.forward);
        }

        private void buttonMoveUp_MouseUp(object sender, MouseEventArgs e)
        {
            car.stopDrive();
        }

        private void buttonMoveDown_MouseDown(object sender, MouseEventArgs e)
        {
            car.startDrive(trackBarSpeed.Value, Car.Direction.reverse);
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
            soundHorn();
        }

        private void buttonSiren_Click(object sender, EventArgs e)
        {
            soundSiren();
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
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Car.Motor driveMotor = 0;
                Car.Motor steerMotor = 0;

                bool drive_reverse = false;
                bool steer_reverse = false;

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

                if (checkBoxReverseDrive.Checked == true)
                {
                    drive_reverse = true;
                }
                if (checkBoxReverseSteer.Checked == true)
                {
                    steer_reverse = true;
                }

                // Initialise Car Instance
                car = new Car(bt, driveMotor, steerMotor, drive_reverse, steer_reverse);
             
                // UI Changes
                this.groupBoxControls.Enabled = true;
                this.groupBoxAux.Enabled = true;
                this.groupBoxSettings.Enabled = false;

                // Enable keyboard shortcuts
                this.KeyPreview = true;
            }
        }

        private void buttonSendDebugCommand_Click(object sender, EventArgs e)
        {
            string[] vals = textBoxDebug.Text.Split(' ');
            List<byte> MsgList = new List<byte>();
            foreach (string v in vals)
            {
                int val = Convert.ToInt32(v, 16);
                MsgList.Add((byte)val);
            }
            byte[] command = MsgList.ToArray();

            bt.SendCommand(command);
        }

        private void buttonDebugParse_Click(object sender, EventArgs e)
        {
            string[] vals = textBoxDebugResponse.Text.Split(' ');
            List<byte> MsgList = new List<byte>();
            foreach (string v in vals)
            {
                int val = Convert.ToInt32(v, 16);
                MsgList.Add((byte)val);
            }
            byte[] command = MsgList.ToArray();

            SetOutputState s = new SetOutputState();
            s.FromCommand(command);

            textBoxLog.Text += s.ToString();
            textBoxLog.Select(textBoxLog.Text.Length, 0);
            textBoxLog.ScrollToCaret();
        }

        private void buttonDebugGetState_Click(object sender, EventArgs e)
        {
            byte[] getoutputstate = { 0x00, 0x06, 0x00 }; // 0, cmd, outputPort
            byte[] response = bt.SendCommand(getoutputstate);
            
            SetOutputState s = new SetOutputState();
            s.FromCommand(response);
            
            textBoxLog.Text += s.ToString();
            textBoxLog.Select(textBoxLog.Text.Length, 0);
            textBoxLog.ScrollToCaret();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            /* Comma Key: Slow Down */
            if (e.KeyCode == Keys.Oemcomma)
            {
                int newspeed = trackBarSpeed.Value - trackBarSpeed.SmallChange;
                if (newspeed < trackBarSpeed.Minimum)
                {
                    trackBarSpeed.Value = trackBarSpeed.Minimum;
                }
                else
                {
                    trackBarSpeed.Value = newspeed;
                }
            }
            /* Period Key: Speed Up */
            if (e.KeyCode == Keys.OemPeriod)
            {
                int newspeed = trackBarSpeed.Value + trackBarSpeed.SmallChange;
                if (newspeed > trackBarSpeed.Maximum)
                {
                    trackBarSpeed.Value = trackBarSpeed.Maximum;
                }
                else
                {
                    trackBarSpeed.Value = newspeed;
                }
            }

            /* Arrow Keys: Movement Control */
            if (e.KeyCode == Keys.Up)
            {
                car.startDrive(trackBarSpeed.Value, Car.Direction.forward);
            }
            if (e.KeyCode == Keys.Down)
            {
                car.startDrive(trackBarSpeed.Value, Car.Direction.reverse);
            }
            if (e.KeyCode == Keys.Left)
            {
                car.startTurn(Car.Turn.left);
            }
            if (e.KeyCode == Keys.Right)
            {
                car.startTurn(Car.Turn.right);
            }

            /* Auxiliary Control */
            if (e.KeyCode == Keys.H)
            {
                // Horn
                soundHorn();
            }
            if (e.KeyCode == Keys.S)
            {
                // Siren
                soundSiren();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            /* Arrow Keys: Movement Control Release */
            if (e.KeyCode == Keys.Up)
            {
                car.stopDrive();
            }
            if (e.KeyCode == Keys.Down)
            {
                car.stopDrive();
            }
            if (e.KeyCode == Keys.Left)
            {
                car.stopTurn();
            }
            if (e.KeyCode == Keys.Right)
            {
                car.stopTurn();
            }
        }
    }
}