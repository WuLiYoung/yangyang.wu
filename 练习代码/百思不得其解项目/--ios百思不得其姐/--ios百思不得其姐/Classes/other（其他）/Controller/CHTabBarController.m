//
//  CHTabBarController.m
//  --ios百思不得其姐
//
//  Created by 吴洋洋 on 16/3/30.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHTabBarController.h"
#import "CHMeViewController.h"
#import "CHNewViewController.h"
#import "CHEssenceViewController.h"
#import "CHFriendTrendsViewController.h"

#import "CHTabBar.h"
#import "CHNavigationController.h"


@interface CHTabBarController ()

@end

@implementation CHTabBarController

+(void)initialize
{
    NSMutableDictionary *attr0 = [NSMutableDictionary dictionary];
    attr0[NSFontAttributeName] = [UIFont systemFontOfSize:12];
    attr0[NSForegroundColorAttributeName] = [UIColor grayColor];
    
    NSMutableDictionary *attr1 = [NSMutableDictionary dictionary];
    attr1[NSFontAttributeName] = [UIFont systemFontOfSize:12];
    attr1[NSForegroundColorAttributeName] = [UIColor darkGrayColor];
    
    UITabBarItem *item = [UITabBarItem appearance];
    
    [item setTitleTextAttributes:attr0 forState:UIControlStateNormal];
    [item setTitleTextAttributes:attr1 forState:UIControlStateSelected];

}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    CHTabBar *tabBar = [[CHTabBar alloc] initWithFrame:self.tabBar.frame];
    
    [self setValue:tabBar forKeyPath:@"tabBar"];
    
    [self setUpAllChildren];
}

- (void)setUpAllChildren
{
    
    [self setUpVC:[[CHEssenceViewController alloc] init] image:[UIImage imageNamed:@"tabBar_essence_icon"] selectedImage:[UIImage imageNamed:@"tabBar_essence_click_icon"] title:@"精华"];
    [self setUpVC:[[CHNewViewController alloc] init] image:[UIImage imageNamed:@"tabBar_new_icon"] selectedImage:[UIImage imageNamed:@"tabBar_new_click_icon"] title:@"新帖"];
    [self setUpVC:[[CHFriendTrendsViewController alloc] init] image:[UIImage imageNamed:@"tabBar_friendTrends_icon"] selectedImage:[UIImage imageNamed:@"tabBar_friendTrends_click_icon"] title:@"关注"];
    [self setUpVC:[[CHMeViewController alloc] init] image:[UIImage imageNamed:@"tabBar_me_icon"] selectedImage:[UIImage imageNamed:@"tabBar_me_click_icon"] title:@"我"];
    
}

- (void)setUpVC:(UIViewController *)vc image:(UIImage *)image selectedImage: (UIImage *)selectedImage title: (NSString *)title
{
    vc.navigationItem.title = title;
    vc.tabBarItem.title = title;
    vc.tabBarItem.image = image;
    vc.tabBarItem.selectedImage = selectedImage;
    
    CHNavigationController *ngr = [[CHNavigationController alloc] initWithRootViewController:vc];
    [self addChildViewController:ngr];
}

@end
