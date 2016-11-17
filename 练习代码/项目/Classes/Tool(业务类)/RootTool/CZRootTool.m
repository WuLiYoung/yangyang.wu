//
//  CZRootTool.m
//  微博
//
//  Created by 吴洋洋 on 16/2/21.
//  Copyright © 2016年 apple. All rights reserved.
//
#define CZVersionKey @"version"
#import "CZRootTool.h"
#import "CZTabBarController.h"
#import "CZFeatureController.h"

@implementation CZRootTool

//选择控制器
+ (void)chooseRootVC: (UIWindow *)window
{
    //1.获取当前的版本号
    NSString *currentVersion = [NSBundle mainBundle].infoDictionary[@"CFBundleVersion"];
    //2.获取上一次的版本号
    NSString *lastVersion = [[NSUserDefaults standardUserDefaults] objectForKey:CZVersionKey];
    
    if ([currentVersion isEqualToString:lastVersion]) {
        
        // 创建tabBarVc
        CZTabBarController *tabBarVc = [[CZTabBarController alloc] init];
        
        // 设置窗口的根控制器
        window.rootViewController = tabBarVc;
        
    }else{
        
        //保存当前的版本号,用偏好设置
        [[NSUserDefaults standardUserDefaults] setObject:currentVersion forKey:CZVersionKey];
        
        //创建CZFeatureController
        CZFeatureController *ftVc = [[CZFeatureController alloc] init];
        
        // 设置窗口的根控制器
        window.rootViewController = ftVc;
    }
}


@end
