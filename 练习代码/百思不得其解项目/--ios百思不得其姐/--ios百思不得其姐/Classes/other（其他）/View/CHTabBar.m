//
//  CHTabBar.m
//  --ios百思不得其姐
//
//  Created by 吴洋洋 on 16/3/30.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHTabBar.h"

@interface CHTabBar ()

@property (nonatomic,weak) UIButton *plusBtn;


@end

@implementation CHTabBar

- (instancetype)initWithFrame:(CGRect)frame
{
    if (self = [super initWithFrame:frame]) {
        
        self.backgroundImage = [UIImage imageNamed:@"tabbar-light"];
        
    }
    return self;
}

- (UIButton *)plusBtn
{
    if (_plusBtn == nil) {
        UIButton *btn = [UIButton buttonWithType:UIButtonTypeCustom];
        [btn setBackgroundImage:[UIImage imageNamed:@"tabBar_publish_icon"] forState:UIControlStateNormal];
        [btn setBackgroundImage:[UIImage imageNamed:@"tabBar_publish_click_icon"] forState:UIControlStateHighlighted];
        
        [btn sizeToFit];
        
        [self addSubview:btn];
        
        _plusBtn = btn;
    }
    return _plusBtn;
}

- (void)layoutSubviews
{
    [super layoutSubviews];
    
    self.plusBtn.center = CGPointMake(self.bounds.size.width / 2,self.bounds.size.height / 2);
    
    CGFloat btnX = 0;
    CGFloat btnY = 0;
    CGFloat btnW = self.bounds.size.width / (self.items.count + 1);
    CGFloat btnH = self.bounds.size.height;
    NSInteger i = 0;
    //调整系统自带的tabbar上的按钮的位置
    for (UIView *tabBarButton in self.subviews) {
        
        if ([tabBarButton isKindOfClass:NSClassFromString(@"UITabBarButton")]) {
            
            if (i == 2) {
                i = 3;
            }
            
            btnX = i * btnW;
            
            tabBarButton.frame = CGRectMake(btnX, btnY, btnW, btnH);
            
            i++;
        }
        
    }
}

@end
