//
//  myTabBarVc.m
//  app
//
//  Created by 吴洋洋 on 16/4/16.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHMyTabBarVc.h"
#import "CHMyTabBar.h"
#import "ViewController.h"

@interface CHMyTabBarVc ()<CHMyTabBarDelegate>




@end

@implementation CHMyTabBarVc

- (void)viewDidLoad {
    
    [super viewDidLoad];
    
    
    
    CHMyTabBar *tabBar = [[CHMyTabBar alloc] initWithFrame:self.tabBar.bounds];
    
    tabBar.myDelegate = self;
    
    [self setValue:tabBar forKeyPath:@"tabBar"];
    
    [self setUpAllChilds];
    
}

- (void)setUpAllChilds
{
    [self setController:[[UITableViewController alloc] init] backgroundColor:[UIColor grayColor]];
    
//    UIViewController *vc1 = [[UIViewController alloc] init];
//    vc1.view.backgroundColor = [UIColor grayColor];
//    [self addChildViewController:vc1];
    
    ViewController *vc2 = [[ViewController alloc] init];
    vc2.view.backgroundColor = [UIColor redColor];
    [self addChildViewController:vc2];

    
    UIViewController *vc3 = [[UIViewController alloc] init];
    vc3.view.backgroundColor = [UIColor blueColor];
    [self addChildViewController:vc3];

    
    UIViewController *vc4 = [[UIViewController alloc] init];
    vc4.view.backgroundColor = [UIColor brownColor];
    [self addChildViewController:vc4];

}

- (void)setController: (UIViewController *)ViewController backgroundColor: (UIColor *)color
{
    ViewController.view.backgroundColor = color;
    ViewController.navigationItem.title = @"就是我";
    ViewController.tabBarItem.title = @"22222";
    ViewController.tabBarItem.image = [UIImage imageNamed:@"tabBar_essence_icon"];
    ViewController.tabBarItem.selectedImage = [UIImage imageNamed:@"tabBar_essence_click_icon"];
    
    UINavigationController *ngr = [[UINavigationController alloc] initWithRootViewController:ViewController];
    
    [self addChildViewController:ngr];
    
}

- (void)setCHMyTabBarClickBtn:(CHMyTabBar *)tabBar
{
    UITableViewController *vc = [[UITableViewController alloc] init];
    
    vc.view.backgroundColor = [UIColor yellowColor];
    
    UINavigationController *ngr = [[UINavigationController alloc] initWithRootViewController:vc];
    
    [self presentViewController:ngr animated:YES completion:^{
        
    }];
}





@end
