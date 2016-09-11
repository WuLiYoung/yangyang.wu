//
//  MusicController.m
//  slideHeadView
//
//  Created by 吴洋洋 on 16/4/21.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "SettingController.h"
#import "SettingCell.h"
#import "MBProgressHUD.h"


@interface SettingController () <UITableViewDelegate,UITableViewDataSource>
@property (nonatomic, strong) NSMutableArray *dataName;
@property (nonatomic, strong) NSMutableArray *dataImage;

@end

@implementation SettingController

- (NSMutableArray *)dataImage
{
    if (_dataImage == nil) {
        _dataImage = [NSMutableArray arrayWithObjects:@"", @"icon_icommentd",@"icon_myfavourate",@"icon_nightmode", @"icon_posted", @"icon_myfriends",@"",@"icon_setting", nil];
    }
    return _dataImage;
}

- (NSMutableArray *)dataName
{
    if (_dataName == nil) {
        
        _dataName =  [NSMutableArray arrayWithObjects: @"", @"最近播放", @"我的喜爱", @"清除缓存", @"免责声明", @"关于我",@"",@"其他", nil];
        
    }
    return _dataName;
    
}


- (void)viewDidLoad {
    [super viewDidLoad];
    
    self.tableView.rowHeight = 54;
    
//    self.tableView.backgroundColor = [UIColor clearColor];
    self.tableView.backgroundView = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"background"]];
    
    self.tableView.separatorStyle = 0;
    
//    self.tableView.tableFooterView = [[UIView alloc] init];
    
    [self.tableView registerNib:[UINib nibWithNibName:NSStringFromClass([SettingCell class]) bundle:nil] forCellReuseIdentifier:@"musicCell"];

}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];

}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return 8;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    SettingCell *cell = [tableView dequeueReusableCellWithIdentifier:@"musicCell" forIndexPath:indexPath];
    
    cell.titleImage.image = [UIImage imageNamed:self.dataImage[indexPath.row]];
    
    cell.title.text = self.dataName[indexPath.row];
    
    cell.count.text = @"";
    
    if(indexPath.row == 0) {
        cell.selectionStyle = UITableViewCellSelectionStyleNone;
       
    }

    return cell;
}


- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {

    [tableView deselectRowAtIndexPath:indexPath animated:YES];
    if (indexPath.row == 3) {
        UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"真的要清除吗" message:nil delegate:self cancelButtonTitle:@"取消" otherButtonTitles:@"确定", nil];
        [alert show];
        return;
    } else if (indexPath.row == 4) {
        UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"本APP旨在技术分享，不涉及任何商业利益。" message:nil delegate:self cancelButtonTitle:nil otherButtonTitles:@"确定", nil];
        [alert show];
    } else if (indexPath.row == 5) {
     
        UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"我的毕业设计！！！" message:nil delegate:self cancelButtonTitle:nil otherButtonTitles:@"确定", nil];
        [alert show];
    }else if (indexPath.row == 7) {
        
        UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"其他没有了>-<" message:nil delegate:self cancelButtonTitle:nil otherButtonTitles:@"确定", nil];
        [alert show];
    }
    
    
}

#pragma mark Method
- (void)alertView:(UIAlertView *)alertView clickedButtonAtIndex:(NSInteger)buttonIndex  {
    if (buttonIndex == 1) {
        MBProgressHUD *hud = [[MBProgressHUD alloc] init];
        [self.view addSubview:hud];
        //加载条上显示文本
        hud.labelText = @"急速清理中";
        //设置对话框样式
        hud.mode = MBProgressHUDModeDeterminate;
        [hud showAnimated:YES whileExecutingBlock:^{
            while (hud.progress < 1.0) {
                hud.progress += 0.01;
                [NSThread sleepForTimeInterval:0.02];
            }
            hud.labelText = @"清理完成";
        } completionBlock:^{

            [self.tableView reloadData];
            [hud removeFromSuperview];
        }];
        
        
    }
}

@end
