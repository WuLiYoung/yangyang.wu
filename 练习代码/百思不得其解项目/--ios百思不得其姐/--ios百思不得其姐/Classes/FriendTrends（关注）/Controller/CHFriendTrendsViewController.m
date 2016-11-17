//
//  CHFriendTrendsViewController.m
//  --ios百思不得其姐
//
//  Created by 吴洋洋 on 16/3/30.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHFriendTrendsViewController.h"
#import "CHCommendController.h"
#import "CHLoginController.h"

@interface CHFriendTrendsViewController ()

@end

@implementation CHFriendTrendsViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    //设置导航栏的内容
    self.navigationItem.title = @"我的关注";
    
    //设置导航栏左边按钮
    UIButton *friendsBtn = [UIButton buttonWithType:UIButtonTypeCustom];
    [friendsBtn setBackgroundImage:[UIImage imageNamed:@"friendsRecommentIcon"] forState:UIControlStateNormal];
    [friendsBtn setBackgroundImage:[UIImage imageNamed:@"friendsRecommentIcon-click"] forState:UIControlStateHighlighted];
    [friendsBtn sizeToFit];
    [friendsBtn addTarget:self action:@selector(friendsBtnClick) forControlEvents:UIControlEventTouchUpInside];
    
    self.navigationItem.leftBarButtonItem = [UIBarButtonItem itemWithImageName:@"friendsRecommentIcon" highImageName:@"friendsRecommentIcon-click" target:self action:@selector(friendsBtnClick)];
    self.view.backgroundColor = [UIColor colorWithRed:(223)/255.0 green:(223)/255.0 blue:(223)/255.0 alpha:1.0];
    
}

- (void)friendsBtnClick
{
    CHCommendController *vc = [[CHCommendController alloc] init];
    [self.navigationController pushViewController:vc animated:YES];
}

- (IBAction)login:(id)sender {
    
    CHLoginController *login = [[CHLoginController alloc] init];
    
    [self presentViewController:login animated:YES completion:^{
        
    }];
    
}


@end
