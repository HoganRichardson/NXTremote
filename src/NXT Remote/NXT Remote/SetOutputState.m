//
//  SetOutputState.m
//  NXT Remote
//
//  Created by Hogan Richardson on 7/4/20.
//  Copyright © 2020 Hogan Richardson. All rights reserved.
//

#import "SetOutputState.h"

@implementation SetOutputState

int _reverse;
static Byte _commandType;
static Byte _command;
static int _outputPort;
static int _power;
static enum ModeType _mode;
static enum RegulationType _regulation;
static int _turnRatio;
static enum RunStateType _runState;
static u_long _tachoLimit;

/* Getters & Setters */
+(Byte)commandType {
    return _commandType;
}
+(Byte)command {
    return _command;
}
+(int)outputPort {
    return _outputPort;
}
+(void)setOutputPort:(int)outputPort {
    if ((outputPort >= 0) && (outputPort <= 2)) {
        _outputPort = outputPort;
        
    } else if (outputPort == 0xFF) {
        _outputPort = outputPort;
    } else {
        // Error
    }
}
+(int)power {
    if (_reverse) {
        return -_power;
    } else {
        return _power;
    }
}
+(void)setPower:(int)power {
    if ((power >= -100) && (power <= 100)) {
        _power = power;
    } else {
        // Error
    }
}
+(enum ModeType)mode {
    return _mode;
}
+(void)setMode:(enum ModeType)mode {
    _mode = mode;
}
+(enum RegulationType)regulation {
    return _regulation;
}
+(void)setRegulation:(enum RegulationType)regulation {
    _regulation = regulation;
}
+(int)turnRatio {
    return _turnRatio;
}
+(void)setTurnRatio:(int)turnRatio {
    if ((turnRatio >= -100) && (turnRatio <= 100)) {
        _turnRatio = turnRatio;
    } else {
        // Error
    }
}
+(enum RunStateType)runState {
    return _runState;
}
+(void)setRunState:(enum RunStateType)runState {
    _runState = runState;
}
+(u_long)tachoLimit {
    return _tachoLimit;
}
+(void)setTachoLimit:(u_long)tachoLimit {
    _tachoLimit = tachoLimit;
}


/* Functions */
+ (Byte) ToCommand {
    Byte * command = malloc(sizeof(Byte) * 13);
    
    command[0] = _commandType;
    command[1] = _command;
    command[2] = (Byte)_outputPort;
    command[3] = (Byte)_power;
    command[4] = (Byte)_mode;
    command[6] = (Byte)_regulation;
    command[7] = (Byte)_turnRatio;
    
    
    return command;
}

@end
