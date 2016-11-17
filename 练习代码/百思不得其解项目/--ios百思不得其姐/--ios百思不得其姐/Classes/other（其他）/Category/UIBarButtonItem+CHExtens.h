//
//  UIBarButtonItem+CHExtens.h
//  --ios百思不得其姐
//
//  Created by 吴洋洋 on 16/3/31.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface UIBarButtonItem (CHExtens)

+ (instancetype)itemWithImageName: (NSString *)imageName highImageName: (NSString *)highImageName target: (id)target action: (SEL)action;

@end
