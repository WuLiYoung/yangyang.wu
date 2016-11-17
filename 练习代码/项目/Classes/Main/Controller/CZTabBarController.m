//
//  CZTabBarController.m
//  传智微博
//
//  Created by apple on 15-3-4.
//  Copyright (c) 2015年 apple. All rights reserved.
//

#import "CZTabBarController.h"
#import "UIImage+Image.h"
#import "CZTabBar.h"

#import "CZHomeViewController.h"
#import "CZMessageViewController.h"
#import "CZDiscoverViewController.h"
#import "CZProfileViewController.h"

#import "CZNavigationController.h"

#import "CZUserTool.h"
#import "CZUserResultTool.h"

#import "MJRefresh.h"

#import "CZCmpController.h"

@interface CZTabBarController ()<CZTabBarDelegate>

@property (nonatomic, strong) NSMutableArray *items;

@property (nonatomic, weak) CZHomeViewController *home;

@property (nonatomic,weak) CZMessageViewController *message;

@property (nonatomic,weak) CZProfileViewController *profile;


@end

@implementation CZTabBarController

- (NSMutableArray *)items
{
    if (_items == nil) {
        
        _items = [NSMutableArray array];
        
    }
    return _items;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    
    // 添加所有子控制器
    [self setUpAllChildViewController];
    
 
    // 自定义tabBar
    [self setUpTabBar];
    
    //每隔一段时间刷新
    [NSTimer scheduledTimerWithTimeInterval:2.0 target:self selector:@selector(requestUnread) userInfo:nil repeats:YES];
}

/**
 *  请求微博数
 */
- (void)requestUnread
{
    //请求微博的未读数
    [CZUserTool unreadWithSuccess:^(CZUserResultTool *result) {
        
        _home.tabBarItem.badgeValue = [NSString stringWithFormat:@"%d",result.status];
        
        _message.tabBarItem.badgeValue = [NSString stringWithFormat:@"%d",result.messageCount];
        
        _profile.tabBarItem.badgeValue = [NSString stringWithFormat:@"%d",result.follower];
        
        //设置未读数总和
        [UIApplication sharedApplication].applicationIconBadgeNumber = result.totalCount;
        
    } failure:^(NSError *error) {
        
        
    }];
    

}

#pragma mark - 设置tabBar
- (void)setUpTabBar
{
    // 自定义tabBar
    CZTabBar *tabBar = [[CZTabBar alloc] initWithFrame:self.tabBar.bounds];
    tabBar.backgroundColor = [UIColor whiteColor];
    
    // 设置代理
    tabBar.delegate = self;
    
    // 给tabBar传递tabBarItem模型
    tabBar.items = self.items;
    
    // 添加自定义tabBar
    [self.tabBar addSubview:tabBar];
    
//    // 移除系统的tabBar
//    [self.tabBar removeFromSuperview];
    
}

#pragma mark - 当点击tabBar上的按钮调用
- (void)tabBar:(CZTabBar *)tabBar didClickButton:(NSInteger)index
{
    if (index == 0 && self.selectedIndex == index) {
        [_home homeRefresh];
    }
    self.selectedIndex = index;
}

- (void)tabBarDidClickButton:(CZTabBar *)tabBar
{
    CZCmpController *vc = [[CZCmpController alloc] init];
    
    CZNavigationController *nvc = [[CZNavigationController alloc] initWithRootViewController:vc];
    
    [self presentViewController:nvc animated:YES completion:^{
        
    }];
}

- (void)viewWillAppear:(BOOL)animated
{
    [super viewWillAppear:animated];
    
    
    // 移除系统的tabBar
    for (UIView *tabBarButton in self.tabBar.subviews) {
        if ([tabBarButton isKindOfClass:NSClassFromString(@"UITabBarButton")]) {
            
            [tabBarButton removeFromSuperview];
        }
    }
    
}



#pragma mark - 添加所有的子控制器
- (void)setUpAllChildViewController
{
    // 首页
    CZHomeViewController *home = [[CZHomeViewController alloc] init];
    
    [self setUpOneChildViewController:home image:[UIImage imageNamed:@"tabbar_home"] selectedImage:[UIImage imageWithOriginalName:@"tabbar_home_selected"] title:@"首页"];
    _home = home;
    
    
    // 消息
    CZMessageViewController *message = [[CZMessageViewController alloc] init];
    [self setUpOneChildViewController:message image:[UIImage imageNamed:@"tabbar_message_center"] selectedImage:[UIImage imageWithOriginalName:@"tabbar_message_center_selected"] title:@"消息"];
    _message = message;
    
    // 发现
    CZDiscoverViewController *discover = [[CZDiscoverViewController alloc] init];
    [self setUpOneChildViewController:discover image:[UIImage imageNamed:@"tabbar_discover"] selectedImage:[UIImage imageWithOriginalName:@"tabbar_discover_selected"] title:@"发现"];

    

    // 我
    CZProfileViewController *profile = [[CZProfileViewController alloc] init];
    [self setUpOneChildViewController:profile image:[UIImage imageNamed:@"tabbar_profile"] selectedImage:[UIImage imageWithOriginalName:@"tabbar_profile_selected"] title:@"我"];
    _profile = profile;
    
}
// navigationItem决定导航条上的内容
// 导航条上的内容由栈顶控制器的navigationItem决定

#pragma mark - 添加一个子控制器
- (void)setUpOneChildViewController:(UIViewController *)vc image:(UIImage *)image selectedImage:(UIImage *)selectedImage title:(NSString *)title
{
//    // navigationItem模型
//    vc.navigationItem.title = title;
//    
//    // 设置子控件对应tabBarItem的模型属性
//    vc.tabBarItem.title = title;
    vc.title = title;
    vc.tabBarItem.image = image;
    vc.tabBarItem.selectedImage = selectedImage;
    
    // 保存tabBarItem模型到数组
    [self.items addObject:vc.tabBarItem];
    
    CZNavigationController *nav = [[CZNavigationController alloc] initWithRootViewController:vc];

    [self addChildViewController:nav];
}


@end
