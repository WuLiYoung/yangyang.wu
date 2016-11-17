//
//  CZComposeToolBar.m
//  微博
//
//  Created by 吴洋洋 on 16/2/26.
//  Copyright © 2016年 apple. All rights reserved.
//

#import "CZComposeToolBar.h"

@implementation CZComposeToolBar

- (instancetype)initWithFrame:(CGRect)frame
{
    if (self =[super initWithFrame:frame]) {
        
        [self setUpAllChildView];
        
    }
    return self;
}

- (void)setUpAllChildView
{
    //相册
    [self setButtonWithImage:[UIImage imageNamed:@"compose_toolbar_picture"] highImage:[UIImage imageNamed:@"compose_toolbar_picture_highlighted"] target:self action:@selector(btnClick:)];
    //提及
    [self setButtonWithImage:[UIImage imageNamed:@"compose_toolbar_picture"] highImage:[UIImage imageNamed:@"compose_toolbar_picture_highlighted"] target:self action:@selector(btnClick:)];
    //话题
    [self setButtonWithImage:[UIImage imageNamed:@"compose_toolbar_picture"] highImage:[UIImage imageNamed:@"compose_toolbar_picture_highlighted"] target:self action:@selector(btnClick:)];
    //表情
    [self setButtonWithImage:[UIImage imageNamed:@"compose_toolbar_picture"] highImage:[UIImage imageNamed:@"compose_toolbar_picture_highlighted"] target:self action:@selector(btnClick:)];
    //键盘
    [self setButtonWithImage:[UIImage imageNamed:@"compose_toolbar_picture"] highImage:[UIImage imageNamed:@"compose_toolbar_picture_highlighted"] target:self action:@selector(btnClick:)];
    
}


- (void)setButtonWithImage:(UIImage *)image highImage:(UIImage *)highImage target:(id)target action:(SEL)action {
    // btn
    UIButton *btn = [UIButton buttonWithType:UIButtonTypeCustom];
    [btn setImage:image forState:UIControlStateNormal];
    [btn setImage:highImage forState:UIControlStateHighlighted];
   
    [btn addTarget:target action:action forControlEvents:UIControlEventTouchUpInside];
    
    [self addSubview:btn];
    
}

- (void)btnClick: (UIButton *)btn
{
    
}

-(void)layoutSubviews
{
    [super layoutSubviews];
    
    NSInteger  count = self.subviews.count;
    
    CGFloat x = 0;
    CGFloat y = 0;
    CGFloat w = self.width / count;
    CGFloat h = self.height;
    
    for (NSInteger i = 0; i < count; i++) {
        UIButton *btn = self.subviews[i];
        
        x = i * w;
        
        btn.frame = CGRectMake(x, y, w, h);
    }
}

@end
