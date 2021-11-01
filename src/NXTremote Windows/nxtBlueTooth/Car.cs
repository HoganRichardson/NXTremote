using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NXTremote
{
    class Car
    {
        public enum Motor : int
        {
            A = 0,
            B = 1,
            C = 2
        }
        public enum Turn
        {
            left,
            right
        }
        public enum Direction
        {
            forward,
            reverse
        }
        public Bluetooth BT { get; }
        public Motor DriveMotor { get; }
        public Motor SteerMotor { get; }
        private int STEER_SPEED = 70; 
        private SetOutputState DriveOutput { get; }
        private SetOutputState SteerOutput { get; }

        public Car (Bluetooth bt, Motor driveMotor, Motor steerMotor, 
            bool drive_reverse = false, bool steer_reverse = false)
        {
            BT = bt;
            DriveMotor = driveMotor;
            SteerMotor = steerMotor;

            DriveOutput = new SetOutputState(DriveMotor.GetHashCode(), 0,
                SetOutputState.ModeType.MotorOn, SetOutputState.RegulationType.MotorSpeed, 0,
                SetOutputState.RunStateType.Running, 0, drive_reverse);

            SteerOutput = new SetOutputState(SteerMotor.GetHashCode(), 0,
                SetOutputState.ModeType.MotorOn, SetOutputState.RegulationType.MotorSpeed, 0,
                SetOutputState.RunStateType.Running, 0, steer_reverse);
        }

        /* Driving Control */
        public void startDrive(int speed, Direction d)
        {
            if (d == Direction.reverse)
            {
                speed = -speed;
            }
            DriveOutput.Power = speed;
            DriveOutput.TurnRatio = speed;
            DriveOutput.RunState = SetOutputState.RunStateType.Running;
            Console.WriteLine("Drive Speed: " + DriveOutput.getPower());

            BT.SendCommand(DriveOutput.ToCommand());
        }

        public void stopDrive()
        {
            DriveOutput.Power = 0;
            DriveOutput.TurnRatio = 0;
            DriveOutput.TachoLimit = 0;
            
            BT.SendCommand(DriveOutput.ToCommand());
        }

        public void speedAdjust(int newSpeed)
        {
            int power = DriveOutput.getPower();
            if (power != 0) // Don't drive motor if currently stopped
            {
                /* Exactly the same as 'start drive' */
                if (power < 0)
                {
                    newSpeed = -newSpeed; 
                }

                DriveOutput.Power = newSpeed;
                DriveOutput.TurnRatio = newSpeed;
                DriveOutput.RunState = SetOutputState.RunStateType.Running;

                BT.SendCommand(DriveOutput.ToCommand());
            }
           
        }

        /* Steering Control */
        public void startTurn (Turn direction)
        {
            int speed;   
            if (direction == Turn.left)
            {
                speed = STEER_SPEED;
            } 
            else
            {
                speed = -STEER_SPEED;
            }

            SteerOutput.Power = speed;
            SteerOutput.TurnRatio = speed;
            SteerOutput.RunState = SetOutputState.RunStateType.Running;

            BT.SendCommand(SteerOutput.ToCommand());
        }

        public void stopTurn ()
        {
            SteerOutput.Power = 0;
            SteerOutput.TurnRatio = 0;

            BT.SendCommand(SteerOutput.ToCommand());
        }

        public void playSound (PlaySound sound)
        {
            BT.SendCommand(sound.ToCommand());
        }

        public void stopSound()
        {
            byte[] stopSound = { 0x00, 0x0C };
            BT.SendCommand(stopSound);
        }
    }
}
