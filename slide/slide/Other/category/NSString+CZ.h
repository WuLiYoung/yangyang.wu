//
//  NSString+CZ.h
//  D02-音乐播放
//
//  Created by Vincent_Guo on 16-3-28.
//  Copyright (c) 2016年 vgios. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface NSString (CZ)


/**
 *  返回分与秒的字符串 如:01:60
 */
+(NSString *)getMinuteSecondWithSecond:(NSTimeInterval)time;

@end
