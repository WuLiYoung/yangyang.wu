//
//  NHSettingVC.m
//  --ios彩票
//
//  Created by 吴洋洋 on 16/1/2.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "NHSettingVC.h"
#import "NHSettingItem.h"
#import "NHArrow.h"
#import "NHSwitch.h"
#import "NHsettingCell.h"
#import "ViewController.h"
#import "MBProgressHUD+Extend.h"
#import "NHPushAndWarmVC.h"


@interface NHSettingVC ()

@end

@implementation NHSettingVC

- (void)viewDidLoad {
    [super viewDidLoad];
    
    self.title = @"设置";
    
    NHSettingItem *item1 = [NHArrow  itemWithIcon:@"handShake" title:@"推送和提醒"];
    item1.vcClass = [NHPushAndWarmVC class];
    NHSettingItem *item2 = [NHSwitch itemWithIcon:@"handShake" title:@"摇一摇"];
    NHSettingItem *item3 = [NHSwitch itemWithIcon:@"handShake" title:@"声音"];
    NSArray *array1 = @[item1,item2,item3];
    
    [self.cellData addObject:array1];
    
    NHSettingItem *item4 = [NHArrow itemWithIcon:@"handShake" title:@"版本更新"];
    item4.operation = ^(){
        NSLog(@"正在检查版本更新");
        
        //模拟版本更新
        [MBProgressHUD showMessage:@"正在检查版本..."];
        dispatch_after(dispatch_time(DISPATCH_TIME_NOW, (int64_t)(2 * NSEC_PER_SEC)), dispatch_get_main_queue(), ^{
            
            [MBProgressHUD hideHUD];
            [MBProgressHUD showSuccess:@"已经是最新版本"];
        });
    };
    
    
    NHSettingItem *item5 = [NHArrow itemWithIcon:@"handShake" title:@"摇一摇"];
    NHSettingItem *item6 = [NHArrow itemWithIcon:@"handShake" title:@"摇一摇"];
    NHSettingItem *item7 = [NHArrow itemWithIcon:@"handShake" title:@"摇一摇"];
    NHSettingItem *item8 = [NHArrow itemWithIcon:@"handShake" title:@"摇一摇"];
    NHSettingItem *item9 = [NHArrow itemWithIcon:@"handShake" title:@"摇一摇"];
    NSArray *array2 = @[item4,item5,item6,item7,item8,item9];
    
    [self.cellData addObject:array2];
}

@end
