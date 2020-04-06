using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NXTremote
{
    class SetOutputState
    {
        public enum ModeType
        {
            MotorOn = 0x01, // Turns on specified motor
            Brake = 0x02, // USe run/brake instead of run/float in PWM
            Regulated = 0x04  // Turns on the regulation
        }
        public enum RegulationType
        {
            Idle = 0x00, // No regulation enabled
            MotorSpeed = 0x01, // Power control will be enabled on specified output
            MotorSync = 0x02  // Synchronisation will be enabled (needs to be enabled on two outputs)
        }
        public enum RunStateType
        {
            Idle = 0x00, // Output will be idle
            RampUp = 0x10, // Output will ramp-up
            Running = 0x20, // Output will be running
            RampDown = 0x40  // Output will ramp-down
        }

        private bool _reverse { get; }
        public byte CommandType { get; set; }
        public byte Command { get; set; }
        private int _outputPort;
        public int OutputPort
        {
            get => _outputPort;
            set
            {
                // Must be 0, 1 or 2 (or 0xFF - all)
                if ((value >= 0) && (value <= 2))
                {
                    _outputPort = value;
                }
                else if (value == 0xFF)
                {
                    _outputPort = value;
                }
                else
                {
                    throw new System.ArgumentOutOfRangeException("Output Port value out of range!");
                }
            }
        }
        private int _power;
        public int Power
        {
            get 
            {
                if (_reverse)
                {
                    return -_power;
                }
                else
                {
                    return _power;
                }
                
            }
            set
            {
                // Must be in range [-100, 100]
                if ((value >= -100) && (value <= 100))
                {
                    _power = value;
                }
                else
                {
                    throw new System.ArgumentOutOfRangeException("Power value out of range!");
                }
            }
        }
        public ModeType Mode { get; set; }
        public RegulationType Regulation { get; set; }
        private int _turnRatio;
        public int TurnRatio
        {
            get => _turnRatio;
            set
            {
                // Must be in range [-100, 100]
                if ((value >= -100) && (value <= 100))
                {
                    _turnRatio = value;
                }
                else
                {
                    throw new System.ArgumentOutOfRangeException("Turn Ratio value out of range!");
                }
            }
        }
        public RunStateType RunState { get; set; }
        public ulong TachoLimit { get; set; }

        public SetOutputState(int outputPort, int power, 
            ModeType m, RegulationType r, int turnRatio,
            RunStateType runState, ulong tachoLimit, bool reverse=false)
        {
            _reverse = reverse;      // Should direction be reversed?
            CommandType = 0x00;      // Byte 0
            Command = 0x04;          // Byte 1
            OutputPort = outputPort; // Byte 2
            Power = power;           // Byte 3
            Mode = m;                // Byte 4
            Regulation = r;          // Byte 5
            TurnRatio = turnRatio;   // Byte 6
            RunState = runState;     // Byte 7
            TachoLimit = tachoLimit; // Byte 8-12 (ulong)
        }

        public SetOutputState ()
        {
            // Alternate empty constructor
        }

        public byte[] ToCommand()
        {
            List<byte> cmdList = new List<byte>();
            cmdList.Add((byte)CommandType);
            cmdList.Add((byte)Command);
            cmdList.Add((byte)OutputPort);
            cmdList.Add((byte)Power);
            cmdList.Add((byte)Mode);
            cmdList.Add((byte)Regulation);
            cmdList.Add((byte)TurnRatio);
            cmdList.Add((byte)RunState);
            cmdList.AddRange(BitConverter.GetBytes(TachoLimit));
            byte[] command = cmdList.ToArray();

            /* Debug */
            Console.WriteLine("Command is:");
            for (int i = 0; i < command.Length; i++)
                Console.Write(command[i].ToString("X2") + " ");
            Console.WriteLine("");
            
            return command;
        }

        public void FromCommand(byte[] command)
        {
            CommandType = command[0];       // Byte 0
            Command = command[1];           // Byte 1
            OutputPort = command[2];        // Byte 2
            Power = command[3];             // Byte 3
            Mode = (ModeType)command[4];    // Byte 4
            Regulation = (RegulationType)command[5];        // Byte 5
            TurnRatio = command[6];                         // Byte 6
            RunState = (RunStateType)command[7];            // Byte 7
            TachoLimit = BitConverter.ToUInt64(command, 8); // Byte 8-12 (ulong)
        }

        public override string ToString()
        {
            string str = "";
            str += "HEX: ";
            byte[] command = ToCommand();
            for (int i = 0; i < command.Length; i++)
                str += command[i].ToString("X2") + " ";
            str += Environment.NewLine + "---" + Environment.NewLine;
            str += "CommandType: " + CommandType + Environment.NewLine;
            str += "    Command: " + Command + Environment.NewLine;
            str += " OutputPort: " + OutputPort + Environment.NewLine;
            str += "      Power: " + Power + Environment.NewLine;
            str += "       Mode: " + Mode.ToString("G") + Environment.NewLine;
            str += " Regulation: " + Regulation.ToString("G") + Environment.NewLine;
            str += "  TurnRatio: " + TurnRatio + Environment.NewLine;
            str += "   RunState: " + RunState.ToString("G") + Environment.NewLine;
            str += " TachoLimit: " + TachoLimit + Environment.NewLine;

            return str; 
        }
    }
}
