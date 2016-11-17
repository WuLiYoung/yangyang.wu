//
//  AppDelegate.m
//  WXMovie
//
//  Created by mac on 15/3/2.
//  Copyright (c) 2015年 mac. All rights reserved.
//

#import "AppDelegate.h"
#import "MainViewController.h"
#import "LaunchViewContrller.h"
#import "GuideViewController.h"

@interface AppDelegate ()

@end

@implementation AppDelegate

- (BOOL)application:(UIApplication*)application didFinishLaunchingWithOptions:(NSDictionary*)launchOptions
{

    UIWindow* window = [[UIWindow alloc] initWithFrame:[UIScreen mainScreen].bounds];
    self.window = window;

    //设为主window
    [window makeKeyAndVisible];

    //构建文件路径
    NSString* filePath = [NSHomeDirectory() stringByAppendingPathComponent:@"Documents/isFirst.plist"];

    //读取沙盒中的plist文件,当应用第一次运行时,沙盒中没有文件,num为nil
    NSNumber* num = [[NSDictionary dictionaryWithContentsOfFile:filePath] objectForKey:@"isFirst"];

    if (![num boolValue]) {

        NSLog(@"第一次运行");
        //满足条件,说明是第一次运行,然后用字典在沙盒中写入文件,并将值改为YES,项目以后再运行,读取到的值均为YES
        NSDictionary* dic = @{ @"isFirst" : @YES };
        [dic writeToFile:filePath atomically:YES];

        //将向导页面设为window的根控制器
        self.window.rootViewController = [[GuideViewController alloc] init];
    }
    else {

        self.window.rootViewController = [[LaunchViewContrller alloc] init];
    }

    /*
     
     if(第一次){
     
        window.rootViewCtrl = [[GuideCtrl alloc] init];
     
     }else{
     
     window.rootViewCtrl = [[LaunchViewContrller alloc] init];
     
     }
     
     
     
     */

    return YES;
}

- (void)applicationWillResignActive:(UIApplication*)application
{
    // Sent when the application is about to move from active to inactive state. This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) or when the user quits the application and it begins the transition to the background state.
    // Use this method to pause ongoing tasks, disable timers, and throttle down OpenGL ES frame rates. Games should use this method to pause the game.
}

- (void)applicationDidEnterBackground:(UIApplication*)application
{
    // Use this method to release shared resources, save user data, invalidate timers, and store enough application state information to restore your application to its current state in case it is terminated later.
    // If your application supports background execution, this method is called instead of applicationWillTerminate: when the user quits.
}

- (void)applicationWillEnterForeground:(UIApplication*)application
{
    // Called as part of the transition from the background to the inactive state; here you can undo many of the changes made on entering the background.
}

- (void)applicationDidBecomeActive:(UIApplication*)application
{
    // Restart any tasks that were paused (or not yet started) while the application was inactive. If the application was previously in the background, optionally refresh the user interface.
}

- (void)applicationWillTerminate:(UIApplication*)application
{
    // Called when the application is about to terminate. Save data if appropriate. See also applicationDidEnterBackground:.
}

@end
