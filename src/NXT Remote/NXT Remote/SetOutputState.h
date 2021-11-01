//
//  SetOutputState.h
//  NXT Remote
//
//  Created by Hogan Richardson on 7/4/20.
//  Copyright © 2020 Hogan Richardson. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface SetOutputState : NSObject

// Enums
enum ModeType { MotorOn = 0x01, Brake = 0x02, Regulated = 0x04 };
enum RegulationType { Idle = 0x00, MotorSpeed = 0x01, MotorSync = 0x02 };
enum RunStateType { RunIdle = 0x00, RampUp = 0x10, Running = 0x20, RampDown = 0x40 };

// Public Properties
@property (class, readonly) Byte commandType;
@property (class, readonly) Byte command;
@property (class) int outputPort;
@property (class) int power;
@property (class) enum ModeType mode;
@property (class) enum RegulationType regulation;
@property (class) int turnRatio;
@property (class) enum RunStateType runState;
@property (class) u_long tachoLimit;

// Functions
+ (Byte*) ToCommand;
@end

NS_ASSUME_NONNULL_END
