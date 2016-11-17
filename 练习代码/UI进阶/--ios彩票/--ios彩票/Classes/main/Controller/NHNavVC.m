//
//  NHNavVC.m
//  --ios彩票
//
//  Created by 吴洋洋 on 16/1/1.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "NHNavVC.h"

@interface NHNavVC ()

@end

@implementation NHNavVC

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
   
}

//#pragma mark - 如果有导航控制器，状态栏的样式要在导航控制器中设置，不能在子控制器中设置，但是只能设置局部
////设置状态栏的样式
//-(UIStatusBarStyle)preferredStatusBarStyle
//{
//    return UIStatusBarStyleLightContent;
//}

#pragma mark - 类第一次使用时被调用
+(void)initialize
{
    
#warning 一般在导航控制器中设置背景图片，而不是在子控制器中设置
    //一次性全局设置导航控制器的背景
    UINavigationBar *navBar = [UINavigationBar appearance];
    [navBar setBackgroundImage:[UIImage imageNamed:@"NavBar64"] forBarMetrics:UIBarMetricsDefault];
    
    //设置标题的字体和颜色
    NSDictionary *dicAttr = @{
                              NSForegroundColorAttributeName:[UIColor whiteColor],
                              NSFontAttributeName:[UIFont systemFontOfSize:17]
                              };
    [navBar setTitleTextAttributes:dicAttr];
    
#pragma mark - tintColor是设置导航条的所有color
    //设置按钮的返回样式
    navBar.tintColor = [UIColor whiteColor];
    
    //设置baritem字体大小
    UIBarButtonItem *barItem = [UIBarButtonItem appearance];
    
    [barItem setTitleTextAttributes:@{NSFontAttributeName:[UIFont systemFontOfSize:15]} forState:UIControlStateNormal];
    
    //设置状态栏的样式
    [UIApplication sharedApplication].statusBarStyle = UIStatusBarStyleLightContent;
}

- (NSArray<UIViewController *> *)popToViewController:(UIViewController *)viewController animated:(BOOL)animated
{
    return [super popToViewController:viewController animated:YES];
}

-(void)pushViewController:(UIViewController *)viewController animated:(BOOL)animated
{
    viewController.hidesBottomBarWhenPushed = YES;
    [super pushViewController:viewController animated:YES];
}

@end
