//
//  NHScoreLMVC.m
//  --ios彩票
//
//  Created by 吴洋洋 on 16/1/3.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "NHScoreLMVC.h"
#import "NHArrow.h"
#import "NHSwitch.h"
#import "NHLable.h"
#import "NHSettingGroup.h"

@interface NHScoreLMVC ()

@end

@implementation NHScoreLMVC

- (void)viewDidLoad {
    [super viewDidLoad];
    
     self.title = @"比分直播提醒";
    
    
    //第一组
    NHSettingItem *item1 = [NHSwitch itemWithIcon:nil title:@"提醒我关注的比赛"];
    
      NSArray *group1 = @[item1];
    
//    NHSettingGroup *group1 = [[NHSettingGroup alloc] init];
//    group1.headerTitle = @"xxxxx";
//    
//    group1.items = @[item1];
//    
    [self.cellData addObject:group1];
    
    
    //第二组
    NHSettingItem *item2 = [NHLable itemWithIcon:nil title:@"起始时间"];
    NHSettingItem *item3 = [NHLable itemWithIcon:nil title:@"结束时间"];
    
     NSArray *group2 = @[item2,item3];
 
//    NHSettingGroup *group2 = [[NHSettingGroup alloc] init];
//    group2.headerTitle = @"xxxxxx";
//    group2.fooderTitle = @"xxxxxx";
//    group2.items = @[item2,item3];
//    
    [self.cellData addObject:group2];
    
    
}



@end
