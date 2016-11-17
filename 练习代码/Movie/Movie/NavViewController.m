//
//  NavViewController.m
//  Movie
//
//  Created by apple on 15/6/5.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "NavViewController.h"

@interface NavViewController ()

@end

@implementation NavViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    
    NSLog(@"%d",self.navigationBar.translucent); // 1

    // 1.设置导航栏背景图片
    [self.navigationBar setBackgroundImage:[UIImage imageNamed:@"nav_bg_all-64.png"] forBarMetrics:UIBarMetricsDefault];
    
    //translucent是否半透明 iOS7以后默认为半透明
    NSLog(@"%d",self.navigationBar.translucent); // 0
    
    self.navigationBar.translucent = YES;
    
    // 2. 设置导航栏样式 --->间接控制导航栏标题的颜色,状态栏颜色
    // self.navigationBar.barStyle = UIBarStyleBlack;

}

// iOS7以后需要重写此方法,控制器状态栏的样式,在子控制器中重写此方法,无效
// 如果存在多级控制器 只有在导航控制器中重写此方法,才有作用
- (UIStatusBarStyle)preferredStatusBarStyle{
        
     // 最顶层的子控制器,正在显示的控制器,通过此种方式让不同的控制器显示不同的颜色
     // return [self.topViewController preferredStatusBarStyle];
    
     // 返回白色
    return UIStatusBarStyleLightContent;
    
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
