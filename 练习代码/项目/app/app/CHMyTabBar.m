//
//  CHMyTabBar.m
//  app
//
//  Created by 吴洋洋 on 16/4/16.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHMyTabBar.h"

@interface CHMyTabBar ()

@property (nonatomic,weak) UIButton *btnPlus;


@end

@implementation CHMyTabBar

- (instancetype)initWithFrame:(CGRect)frame
{
    if (self = [super initWithFrame:frame]) {
        
        
        
    }
    return self;
}

- (UIButton *)btnPlus
{
    if (_btnPlus == nil) {
        
        UIButton *btn = [UIButton buttonWithType:UIButtonTypeCustom];
        
        [btn setImage:[UIImage imageNamed:@"tabBar_publish_icon"] forState:UIControlStateNormal];
        [btn setImage:[UIImage imageNamed:@"tabBar_publish_click_icon"] forState:UIControlStateHighlighted];
        
        [btn addTarget:self action:@selector(btnPlusClick) forControlEvents:UIControlEventTouchUpInside];
        
        [btn sizeToFit];
        
        _btnPlus = btn;
        
        [self addSubview:btn];
        
    }
    return _btnPlus;
}

- (void)layoutSubviews
{
    [super layoutSubviews];
    
    self.btnPlus.center = CGPointMake(self.bounds.size.width / 2, self.bounds.size.height / 2);
    
    CGFloat btnX = 0;
    CGFloat btnY = 0;
    CGFloat btnW = self.bounds.size.width / (self.items.count + 1);
    CGFloat btnH = self.bounds.size.height;
    
    NSInteger i = 0;
    
    for (UIView *tabBarBtn in self.subviews) {
        
        if ([tabBarBtn isKindOfClass:NSClassFromString(@"UITabBarButton")]) {
            
            if (i==2) {
                i = 3;
            }
            
            btnX = i * btnW;
            
            tabBarBtn.frame = CGRectMake(btnX, btnY, btnW, btnH);
            
            i++;
        }
    }
    
}

- (void)btnPlusClick
{
    if ([_myDelegate respondsToSelector:@selector(setCHMyTabBarClickBtn:)]) {
        [_myDelegate setCHMyTabBarClickBtn:self];
    }
}

@end
