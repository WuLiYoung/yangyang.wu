//
//  AppDelegate.h
//  --ios音乐播放器
//
//  Created by 吴洋洋 on 15/12/22.
//  Copyright © 2015年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>

远程播放事件的block
typedef  void(^PlayerRemoteEventBlock)(UIEvent *event);

@interface AppDelegate : UIResponder <UIApplicationDelegate>

@property (strong, nonatomic) UIWindow *window;

@property (copy,nonatomic)PlayerRemoteEventBlock mRemoteEventBlock;

@end

