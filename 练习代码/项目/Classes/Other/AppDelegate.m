//
//  AppDelegate.m
//  传智微博
//
//  Created by apple on 15-3-4.
//  Copyright (c) 2015年 apple. All rights reserved.
//



#import "AppDelegate.h"

#import "CZOneViewController.h"

#import "CZOAuthViewController.h"
#import "CZAccountTool.h"
#import "CZRootTool.h"

#import "UIImageView+WebCache.h"
#import <AVFoundation/AVFoundation.h>

@interface AppDelegate ()

@property (nonatomic,strong) AVAudioPlayer *player;


@end

@implementation AppDelegate
// 补充：控制器的view
// UITabBarController控制器的view在一创建控制器的时候就会加载view
// UIViewController的view，才是懒加载。
- (BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions {
    // Override point for customization after application launch.
    
    
    //注册通知，显示未读总数和
    UIUserNotificationSettings *setting = [UIUserNotificationSettings settingsForTypes:UIUserNotificationTypeBadge categories:nil];
    [application registerUserNotificationSettings:setting];
    
    //真机上后台播放，设置音频会话
    AVAudioSession *session = [AVAudioSession sharedInstance];
    
    //设置会话类型
    [session setCategory:AVAudioSessionCategoryPlayback error:nil];
    
    //激活
    [session setActive:YES error:nil];
    
    
    // 创建窗口
    self.window = [[UIWindow alloc] initWithFrame:[UIScreen mainScreen].bounds];
    
    //判断是否授权
    if ([CZAccountTool account]) {//已经授权
        
        [CZRootTool chooseRootVC:self.window];
        
    }else{//没有授权
        //选择控制器
        CZOAuthViewController *VC = [[CZOAuthViewController alloc] init];
        
        //设置根控制器
        self.window.rootViewController = VC;
        
    }
    
    // 显示窗口
    [self.window makeKeyAndVisible];
    // makeKeyAndVisible底层实现
    // 1. application.keyWindow = self.window
    // 2. self.window.hidden = NO;
    
    return YES;
}

#warning 当接收到内存警告时调用
- (void)applicationDidReceiveMemoryWarning:(UIApplication *)application
{
    //停止下载所有
    [[SDWebImageManager sharedManager] cancelAll];
    
    //清除缓存
    [[SDWebImageManager sharedManager].imageCache clearMemory];
}

//失去焦点时调用
- (void)applicationWillResignActive:(UIApplication *)application {
   
    NSURL *url = [[NSBundle mainBundle] URLForResource:@"silence.mp3" withExtension:nil];
    
    AVAudioPlayer *player = [[AVAudioPlayer alloc] initWithContentsOfURL:url error:nil];
    
    [player prepareToPlay];
    
    player.numberOfLoops = -1;
    
    [player play];
    
    _player = player;
}

//程序进入后台时调用
- (void)applicationDidEnterBackground:(UIApplication *)application {

     //开启一个后台任务
    UIBackgroundTaskIdentifier ID = [application beginBackgroundTaskWithExpirationHandler:^{
        
        //主动关闭
        [application endBackgroundTask:ID];
        
    }];
}

- (void)applicationWillEnterForeground:(UIApplication *)application {
    // Called as part of the transition from the background to the inactive state; here you can undo many of the changes made on entering the background.
}

- (void)applicationDidBecomeActive:(UIApplication *)application {
    // Restart any tasks that were paused (or not yet started) while the application was inactive. If the application was previously in the background, optionally refresh the user interface.
}

- (void)applicationWillTerminate:(UIApplication *)application {
    // Called when the application is about to terminate. Save data if appropriate. See also applicationDidEnterBackground:.
}

@end
