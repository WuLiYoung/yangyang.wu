//
//  CHTextField.m
//  --ios百思不得其姐
//
//  Created by 吴洋洋 on 16/4/6.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHTextField.h"

@implementation CHTextField

- (void)drawPlaceholderInRect:(CGRect)rect
{
    [self.placeholder drawInRect:CGRectMake(0, 15, 100, 25) withAttributes:@{NSForegroundColorAttributeName : [UIColor grayColor]}];
}

@end
