//
//  NHPushAndWarmVC.m
//  --ios彩票
//
//  Created by 吴洋洋 on 16/1/3.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "NHPushAndWarmVC.h"
#import "NHSettingVC.h"
#import "NHSettingItem.h"
#import "NHArrow.h"
#import "NHSwitch.h"
#import "NHsettingCell.h"
#import "ViewController.h"
#import "MBProgressHUD+Extend.h"
#import "NHAwardNumVC.h"
#import "NHScoreLMVC.h"


@interface NHPushAndWarmVC ()

@end

@implementation NHPushAndWarmVC

- (void)viewDidLoad {
    [super viewDidLoad];
    
    self.title = @"推送和提醒";

    NHSettingItem *item1 = [NHArrow  itemWithIcon:nil title:@"开奖号码"];
    item1.vcClass        = [NHAwardNumVC class];
    NHSettingItem *item2 = [NHArrow itemWithIcon:nil title:@"摇一摇"];
    NHSettingItem *item3 = [NHArrow itemWithIcon:nil title:@"比分直播提醒"];
    item3.vcClass        = [NHScoreLMVC class];
    NHSettingItem *item4 = [NHArrow itemWithIcon:nil title:@"摇一摇"];
    NSArray *array1      = @[item1,item2,item3,item4];
    
    [self.cellData addObject:array1];

}

@end
