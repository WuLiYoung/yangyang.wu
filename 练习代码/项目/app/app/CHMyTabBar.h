//
//  CHMyTabBar.h
//  app
//
//  Created by 吴洋洋 on 16/4/16.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>

@class CHMyTabBar;

@protocol  CHMyTabBarDelegate <NSObject>

- (void)setCHMyTabBarClickBtn: (CHMyTabBar *)tabBar;

@end

@interface CHMyTabBar : UITabBar

@property (nonatomic,weak) id<CHMyTabBarDelegate> myDelegate;


@end
