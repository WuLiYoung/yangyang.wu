//
//  CHNewViewController.m
//  --ios百思不得其姐
//
//  Created by 吴洋洋 on 16/3/30.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHNewViewController.h"

@interface CHNewViewController ()

@end

@implementation CHNewViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    //设置导航栏的内容
    self.navigationItem.titleView = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"MainTitle"]];
    
    //设置导航栏左边按钮
    self.navigationItem.leftBarButtonItem = [UIBarButtonItem itemWithImageName:@"MainTagSubIcon" highImageName:@"MainTagSubIconClick" target:self action:@selector(leftClick)];
     self.view.backgroundColor = [UIColor colorWithRed:(223)/255.0 green:(223)/255.0 blue:(223)/255.0 alpha:1.0];
    
}

- (void)leftClick
{
    
}

@end
