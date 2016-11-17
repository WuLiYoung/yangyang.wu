//
//  ViewController.m
//  --网络基础
//
//  Created by 吴洋洋 on 16/1/27.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "ViewController.h"
#import "Reachability.h"

@interface ViewController ()

@property (nonatomic,strong) Reachability *reach;


@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    self.reach = [Reachability reachabilityWithHostName:@"baidu.com"];
    
    //添加通知
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(reachabilityStatusChange) name:kReachabilityChangedNotification object:nil];
    
    [self.reach startNotifier];

}

- (void)dealloc
{
    [[NSNotificationCenter defaultCenter] removeObserver:self];
}

- (void)reachabilityStatusChange
{
    
    switch (self.reach.currentReachabilityStatus) {
        case NotReachable:
            NSLog(@"没有联网");
            break;
        case ReachableViaWiFi:
            NSLog(@"免费联网");
            break;
        case ReachableViaWWAN:
            NSLog(@"付费联网");
            break;
            
        default:
            break;
    }
}


@end
