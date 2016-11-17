//
//  UIImage+CZ.h
//  QQZone-HD
//
//  Created by Vincent_Guo on 16-3-28.
//  Copyright (c) 2016年 vgios. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface UIImage (CZ)




/**
 *  返回一张自由拉伸的图片
 */
+ (UIImage *)resizedImageWithName:(NSString *)name;

/**
 *  返回拉伸的图片
 */
+ (UIImage *)resizedImageWithName:(NSString *)name left:(CGFloat)left top:(CGFloat)top;


+ (instancetype)circleImageWithName:(NSString *)name borderWidth:(CGFloat)borderWidth borderColor:(UIColor *)borderColor;

+ (instancetype)circleImageWithImage:(UIImage *)image borderWidth:(CGFloat)borderWidth borderColor:(UIColor *)borderColor;

+(UIImage *)imageFromMainBundleWithName:(NSString *)name;
@end
