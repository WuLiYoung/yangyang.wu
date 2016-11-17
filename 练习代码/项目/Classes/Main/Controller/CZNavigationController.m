//
//  CZNavigationController.m
//  传智微博
//
//  Created by apple on 15-3-7.
//  Copyright (c) 2015年 apple. All rights reserved.
//

#import "CZNavigationController.h"
#import "UIBarButtonItem+Item.h"


@interface CZNavigationController () <UINavigationControllerDelegate>

@property (nonatomic,strong) id popDelegate;


@end

@implementation CZNavigationController

+ (void)initialize
{
    // 获取当前类下面的UIBarButtonItem
    UIBarButtonItem *item = [UIBarButtonItem appearanceWhenContainedInInstancesOfClasses:@[self]];
    
    // 设置导航条按钮的文字颜色
    NSMutableDictionary *titleAttr = [NSMutableDictionary dictionary];
    titleAttr[NSForegroundColorAttributeName] = [UIColor orangeColor];
    [item setTitleTextAttributes:titleAttr forState:UIControlStateNormal];
    
    
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    self.popDelegate = self.interactivePopGestureRecognizer.delegate;
    
    self.delegate = self;
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)pushViewController:(UIViewController *)viewController animated:(BOOL)animated
{
    
    //设置非根控制器的内容
    if (self.viewControllers.count != 0) {
        
        
        //设置导航条左边和右边
        //左边
        viewController.navigationItem.leftBarButtonItem = [UIBarButtonItem barButtonItemWithImage:[UIImage imageNamed:@"navigationbar_back"] highImage:[UIImage imageNamed:@"navigationbar_back_highlighted"] target:self action:@selector(backToPro) forControlEvents:UIControlEventTouchUpInside];
        
        //右边
        viewController.navigationItem.rightBarButtonItem = [UIBarButtonItem barButtonItemWithImage:[UIImage imageNamed:@"navigationbar_more"] highImage:[UIImage imageNamed:@"navigationbar_more_highlighted"] target:self action:@selector(moreTORoot) forControlEvents:UIControlEventTouchUpInside];
        
    }
    
    [super pushViewController:viewController animated:animated];

}

- (void)backToPro
{
    [self popViewControllerAnimated:YES];
}

- (void)moreTORoot
{
    [self popToRootViewControllerAnimated:YES];
}

#pragma mark - UINavigationControllerDelegate的代理方法
//即将显示的时候调用
//- (void)navigationController:(UINavigationController *)navigationController willShowViewController:(UIViewController *)viewController animated:(BOOL)animated
//{
//    //获取主窗口
//    UIWindow *keyWindow = [UIApplication sharedApplication].keyWindow;
//    
//    //获取tabBarVc的根控制器
//    UITabBarController *tabBarVc = (UITabBarController *)keyWindow.rootViewController;
//    
//}


//导航控制器跳转完成的时候会调用
- (void)navigationController:(UINavigationController *)navigationController didShowViewController:(UIViewController *)viewController animated:(BOOL)animated
{
    //如果是返回根控制器，则还原手势代理
    if (viewController == self.viewControllers[0]) {
        
        self.interactivePopGestureRecognizer.delegate = self.popDelegate;
    }else{
        
        //实现滑动返回功能
        //清空滑动手势的代理
        self.interactivePopGestureRecognizer.delegate = nil;
    }
}

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

@end
