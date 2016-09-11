//
//  YYtestController.m
//  slide
//
//  Created by 吴洋洋 on 16/5/5.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYtestController.h"
#import "AFNetworking.h"
#import "YYSearchController.h"
#import "YYTestCell.h"
#import "UINavigationController+FDFullscreenPopGesture.h"

#import "MBProgressHUD.h"

@interface YYtestController ()
@property (nonatomic,strong) NSMutableArray *dataArr;
@end

@implementation YYtestController
- (NSMutableArray *)dataArr
{
    if (_dataArr == nil) {
        _dataArr = [NSMutableArray arrayWithObjects:@"小幸运",@"五月天",@"徐佳莹",@"田馥甄",@"周杰伦",@"林宥嘉", nil];
    }
    return _dataArr;
}

- (void)viewDidAppear:(BOOL)animated
{
    [super viewDidAppear:animated];
    
    self.navigation.navigationBar.hidden = NO;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    self.tableView.separatorStyle = 0;
    
    [self readData];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

#pragma mark - Table view data source

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {

    return 7;
}


- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    YYTestCell *cell = [tableView dequeueReusableCellWithIdentifier:@"testCell" forIndexPath:indexPath];
    
    if (indexPath.row == 0) {
        cell.lbl.text = @"搜索";
    }
    else if (indexPath.row == 1)
    {
        cell.lbl.text = @"大家在搜";
        cell.userInteractionEnabled = NO;
    }
    else if (indexPath.row == 2)
    {
        cell.lbl.text = self.dataArr[0];
        cell.lbl.textColor = [UIColor lightGrayColor];
        
    }else if (indexPath.row == 3)
    {
        cell.lbl.text = self.dataArr[1];
        cell.lbl.textColor = [UIColor lightGrayColor];
    }else if (indexPath.row == 4)
    {
        cell.lbl.text = self.dataArr[2];
        cell.lbl.textColor = [UIColor lightGrayColor];
    }else if (indexPath.row == 5)
    {
        cell.lbl.text = self.dataArr[3];
        cell.lbl.textColor = [UIColor lightGrayColor];
    }else if (indexPath.row == 6)
    {
        cell.lbl.text = self.dataArr[4];
        cell.lbl.textColor = [UIColor lightGrayColor];
    }else if(indexPath.row == 7)
    {
        cell.lbl.text = self.dataArr[5];
        cell.lbl.textColor = [UIColor lightGrayColor];
    }
    
    cell.selectionStyle = 0;
    
    return cell;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath
{
    if (indexPath.row == 0) {
        return 60;
    }else{
    
        return 40;
    }
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    YYTestCell *cell = [tableView cellForRowAtIndexPath:indexPath];
    
    if (indexPath.row == 0) {
        [self push:nil];
    }
    if (indexPath.row == 1) {
        
        
    }else if (indexPath.row == 2){
    
        [self push:cell];
        
    }else if (indexPath.row == 3){
        
        [self push:cell];
    }else if (indexPath.row == 4){
        
        [self push:cell];
    }else if (indexPath.row == 5){
        
        [self push:cell];
    }else if (indexPath.row == 6){
        [self push:cell];
        
    }else if (indexPath.row == 7){
        [self push:cell];
        
    }
}

- (void)push: (YYTestCell *)cell
{
    UIStoryboard *sb = [UIStoryboard storyboardWithName:@"Main" bundle:nil];
    
    YYSearchController *vc = [sb instantiateViewControllerWithIdentifier:@"sbSearch"];
    vc.navigation = self.navigation;
        vc.keyword = [cell.lbl.text isEqualToString:@" "] || cell.lbl.text == nil ? @" " : cell.lbl.text;
    [self.navigation pushViewController:vc animated:YES];
}

- (void)readData
{
    [[AFHTTPSessionManager manager] GET:@"http://so.ard.iyyin.com/sug/billboard" parameters:nil success:^(NSURLSessionDataTask *task, id responseObject) {
        
        for (NSDictionary *dict in responseObject[@"data"]) {
            
            NSString *dic = dict[@"val"];
            
            [self.dataArr addObject:dic];
        }

        
    } failure:^(NSURLSessionDataTask *task, NSError *error) {

        
    }];
}

@end
