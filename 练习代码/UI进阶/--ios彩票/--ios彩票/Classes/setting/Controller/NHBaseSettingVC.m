//
//  NHSettingVC.m
//  --ios彩票
//
//  Created by 吴洋洋 on 16/1/2.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "NHBaseSettingVC.h"
#import "NHSettingVC.h"
#import "NHSettingItem.h"
#import "NHArrow.h"
#import "NHSwitch.h"
#import "NHsettingCell.h"
#import "ViewController.h"
#import "MBProgressHUD+Extend.h"
#import "NHSettingGroup.h"



@interface NHBaseSettingVC ()

@end

@implementation NHBaseSettingVC

#pragma mark - 只要调用init方法，就返回组样式的表格
- (instancetype)init
{
    if (self = [super initWithStyle:UITableViewStyleGrouped]) {
        
    }
    return self;
}


//懒加载
- (NSMutableArray *)cellData
{
    if (_cellData == nil) {
        _cellData = [NSMutableArray array];
    }
    return _cellData;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    
    //背景平铺
    self.view.backgroundColor = [UIColor colorWithPatternImage:[UIImage imageNamed:@"bg"]];
}

#pragma mark - Table view data source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    
    return self.cellData.count;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    NSArray *group = self.cellData[section];
    
    return group.count;
}


- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    
    NHsettingCell *cell = [NHsettingCell tableView:tableView];
    
    //获取组模型数据显示
    NSArray *group = self.cellData[indexPath.section];
    
    NHSettingItem *item = group[indexPath.row];
    
    //设置模型，显示数据
    cell.item = item;
    
    return cell;
}

#pragma mark - cell的选中
- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    //获取组模型vcClass控制器的类型
    NSArray *group = self.cellData[indexPath.section];
    
    NHSettingItem *item = group[indexPath.row];
    
    if (item.operation) {
        item.operation();
    }else if (item.vcClass) {
        //创建控制器再显示
        id vc = [[item.vcClass alloc] init];
        
        [self.navigationController pushViewController:vc animated:YES];
    }
}

#pragma mark - 头部标题和尾部标题
//头部标题
//- (NSString *)tableView:(UITableView *)tableView titleForHeaderInSection:(NSInteger)section
//{
//    NHSettingGroup *group = self.cellData[section];
//    return group.headerTitle;
//    
//}
//
////尾部标题
//- (NSString *)tableView:(UITableView *)tableView titleForFooterInSection:(NSInteger)section
//{
//    NHSettingGroup *group = self.cellData[section];
//    return group.fooderTitle;
//}

@end
