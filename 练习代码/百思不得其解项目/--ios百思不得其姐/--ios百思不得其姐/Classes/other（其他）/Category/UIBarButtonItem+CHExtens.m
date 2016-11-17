//
//  UIBarButtonItem+CHExtens.m
//  --ios百思不得其姐
//
//  Created by 吴洋洋 on 16/3/31.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "UIBarButtonItem+CHExtens.h"

@implementation UIBarButtonItem (CHExtens)

+ (instancetype)itemWithImageName:(NSString *)imageName highImageName:(NSString *)highImageName target:(id)target action:(SEL)action
{
    UIButton *btn = [UIButton buttonWithType:UIButtonTypeCustom];
    [btn setBackgroundImage:[UIImage imageNamed:imageName] forState:UIControlStateNormal];
    [btn setBackgroundImage:[UIImage imageNamed:highImageName] forState:UIControlStateHighlighted];
    [btn sizeToFit];
    [btn addTarget:target action:action forControlEvents:UIControlEventTouchUpInside];
    
    return [[self alloc] initWithCustomView:btn];
}

@end
