//
//  CHVerticalBtn.m
//  --ios百思不得其姐
//
//  Created by 吴洋洋 on 16/4/6.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHVerticalBtn.h"

@implementation CHVerticalBtn

- (void)awakeFromNib
{
    self.titleLabel.textAlignment = NSTextAlignmentCenter;
}

- (void)layoutSubviews
{
    [super layoutSubviews];
    
    //调整图片
    self.imageView.x = 0;
    self.imageView.y = 0;
    self.imageView.width = self.width;
    self.imageView.height = self.width;
    
    
    //调整文字
    self.titleLabel.x = 0;
    self.titleLabel.y = self.width;
    self.titleLabel.width =  self.width;
    self.titleLabel.height = self.height - self.titleLabel.y;
}

@end
