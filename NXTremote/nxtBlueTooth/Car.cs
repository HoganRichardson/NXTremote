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
        public Bluetooth BT { get; }
        public Motor DriveMotor { get; }
        public Motor SteerMotor { get; }
        public int SteerLimit { get; }
        private int TURN_RATIO = 100; // Default, may need to modify TODO
        private int STEER_SPEED = 50; // Default, may need to modify TODO
        private SetOutputState DriveOutput { get; }
        private SetOutputState SteerOutput { get; }

        public Car (Bluetooth bt, Motor driveMotor, Motor steerMotor, int steerLimit = 0)
        {
            BT = bt;
            DriveMotor = driveMotor;
            SteerMotor = steerMotor;
            SteerLimit = steerLimit;
            Console.WriteLine("The code is " + DriveMotor.GetHashCode());
            DriveOutput = new SetOutputState(DriveMotor.GetHashCode(), 0,
                SetOutputState.ModeType.MotorOn, SetOutputState.RegulationType.MotorSpeed, TURN_RATIO,
                SetOutputState.RunStateType.RampUp, 0);

            SteerOutput = new SetOutputState(SteerMotor.GetHashCode(), 0,
                SetOutputState.ModeType.MotorOn, SetOutputState.RegulationType.MotorSpeed, TURN_RATIO,
                SetOutputState.RunStateType.RampUp, 0);
        }

        /* Driving Control */
        public void startDrive(int speed)
        {
            // Set DriveOutput to ramp up to `speed` and send command
            DriveOutput.Power = speed;
            DriveOutput.RunState = SetOutputState.RunStateType.RampUp;
            DriveOutput.TachoLimit = 240;

            BT.SendCommand(DriveOutput.ToCommand());
        }

        public void stopDrive()
        {
            DriveOutput.Power = 0;
            DriveOutput.Mode = SetOutputState.ModeType.Brake;
            DriveOutput.RunState = SetOutputState.RunStateType.Running; // TODO check this?
            DriveOutput.TachoLimit = 0;
            
            BT.SendCommand(DriveOutput.ToCommand());
        }

        public void speedAdjust(int newSpeed)
        {

        }

        /* Steering Control */
        public void startTurn (Turn direction)
        {

        }

        public void stopTurn ()
        {

        }
    }
}
