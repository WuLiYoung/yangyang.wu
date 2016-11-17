//
//  NHAwardNumVC.m
//  --ios彩票
//
//  Created by 吴洋洋 on 16/1/3.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "NHAwardNumVC.h"
#import "NHPushAndWarmVC.h"
#import "NHSettingVC.h"
#import "NHSettingItem.h"
#import "NHArrow.h"
#import "NHSwitch.h"
#import "NHsettingCell.h"
#import "ViewController.h"
#import "MBProgressHUD+Extend.h"
#import "NHAwardNumVC.h"


@interface NHAwardNumVC ()

@end

@implementation NHAwardNumVC

- (void)viewDidLoad {
    [super viewDidLoad];
   
    
    NHSettingItem *item1 = [NHSwitch itemWithIcon:nil title:@"双色球"];
    NHSettingItem *item2 = [NHSwitch itemWithIcon:nil title:@"大透乐球"];

    NSArray *array1 = @[item1,item2];
    
    [self.cellData addObject:array1];
}



@end
