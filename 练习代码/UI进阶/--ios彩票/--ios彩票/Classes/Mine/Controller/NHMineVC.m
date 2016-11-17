//
//  NHMineVC.m
//  --ios彩票
//
//  Created by 吴洋洋 on 16/1/2.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "NHMineVC.h"
#import "NHSettingVC.h"

@interface NHMineVC ()
- (IBAction)settingBtnClick:(id)sender;

@end

@implementation NHMineVC

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}



- (IBAction)settingBtnClick:(id)sender {
    
    //点击“设置”进入 页面
    NHSettingVC *setVC = [[NHSettingVC alloc] init];
    [self.navigationController pushViewController:setVC animated:YES];
}
@end
