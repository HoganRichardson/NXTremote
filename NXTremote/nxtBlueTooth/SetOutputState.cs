﻿using System;
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

        public byte CommandType { get; }
        public byte Command { get; }
        public int OutputPort
        {
            get => OutputPort;
            set
            {
                // Must be 0, 1 or 2 (or 0xFF - all)
                if ((value >= 0) && (value <= 2))
                {
                    OutputPort = value;
                }
                else if (value == 0xFF)
                {
                    OutputPort = value;
                }
            }
        }
        public int Power
        {
            get => Power;
            set
            {
                // Must be in range [-100, 100]
                if ((value >= -100) && (value <= 100))
                {
                    Power = value;
                }
            }
        }
        public ModeType Mode { get; }
        public RegulationType Regulation { get; }
        public int TurnRatio
        {
            get => TurnRatio;
            set
            {
                // Must be in range [-100, 100]
                if ((value >= -100) && (value <= 100))
                {
                    TurnRatio = value;
                }
            }
        }
        public RunStateType RunState { get; }
        public ulong TachoLimit { get; }

        public SetOutputState(int outputPort, int power, 
            ModeType m, RegulationType r, int turnRatio,
            RunStateType runState, ulong tachoLimit)
        {
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

            return command;
        }
    }
}