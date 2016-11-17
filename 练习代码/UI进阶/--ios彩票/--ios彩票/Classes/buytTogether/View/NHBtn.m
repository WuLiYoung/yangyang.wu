//
//  NHBtn.m
//  --ios彩票
//
//  Created by 吴洋洋 on 16/1/1.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#define imageW 30
#import "NHBtn.h"

@implementation NHBtn

- (instancetype)initWithCoder:(NSCoder *)aDecoder
{
    //设置图片样式
    if (self = [super initWithCoder:aDecoder]) {
        self.imageView.contentMode = UIViewContentModeCenter;
    }
    return self;
}

//标题的位置
- (CGRect)titleRectForContentRect:(CGRect)contentRect
{
    CGFloat titleW = contentRect.size.width - imageW;
    CGFloat titleH = contentRect.size.height;
    
    return CGRectMake(0, 0, titleW, titleH);
}

//图片的位置
- (CGRect)imageRectForContentRect:(CGRect)contentRect
{
    CGFloat imgW = imageW;
    CGFloat imgH = contentRect.size.height;
    CGFloat imgX = contentRect.size.width - imageW;
#pragma mark - Button的子控件都是空，不能设置样式
    return CGRectMake(imgX, 0, imgW, imgH);
}

- (void)setHighlighted:(BOOL)highlighted
{
    
}

@end
