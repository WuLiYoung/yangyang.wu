//
//  CHMeViewController.m
//  --ios百思不得其姐
//
//  Created by 吴洋洋 on 16/3/30.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHMeViewController.h"

@interface CHMeViewController ()

@end

@implementation CHMeViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    //设置导航栏的内容
    self.navigationItem.title = @"我的";
    
    //设置导航栏左边按钮
    UIBarButtonItem *item1 = [UIBarButtonItem itemWithImageName:@"mine-setting-icon" highImageName:@"mine-setting-icon-click" target:self action:@selector(settingBtnClick)];
    UIBarButtonItem *item2 = [UIBarButtonItem itemWithImageName:@"mine-moon-icon" highImageName:@"mine-moon-icon-click" target:self action:@selector(moonBtnBtnClick)];
    
    self.navigationItem.rightBarButtonItems = @[item1,item2];
    self.view.backgroundColor = [UIColor colorWithRed:(223)/255.0 green:(223)/255.0 blue:(223)/255.0 alpha:1.0];
    
}

- (void)settingBtnClick
{
    CHLog(@"%s",__func__);
}

- (void)moonBtnBtnClick
{
    CHLog(@"%s",__func__);
}
@end
