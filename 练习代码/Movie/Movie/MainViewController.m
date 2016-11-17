//
//  MainViewController.m
//  Movie
//
//  Created by apple on 15/6/3.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "MainViewController.h"
#import "MovieViewController.h"
#import "NewsViewController.h"
#import "TopViewController.h"
#import "CinemaViewController.h"
#import "MoreViewController.h"
#import "HWBotton.h"
#import "NavViewController.h"
#import "Common.h"


@interface MainViewController ()

@end

@implementation MainViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    //创建子控制器
    [self _createSubCtrls];
    
    //自定义tabbar
    [self _createTabbar];
}

- (void)_createTabbar{
    
   //1 .移除系统Tabbar按钮  UITabBarButton内部类型 父类为UIControl
    NSLog(@"%@",self.tabBar.subviews);
    
    for (UIView *view in self.tabBar.subviews) {
        
//        NSLog(@"%@",view.superclass);
//        NSClassFromString(@"UIButton") 等价于 [UIButton class];
        
        Class c = NSClassFromString(@"UITabBarButton");
        //如果view是UITabBarButton类创建的对象才移除
        if ([view isKindOfClass:c]) { //更严谨
            //移除tababr的子视图
            [view removeFromSuperview];
        }
        
    }
    NSLog(@"%d",self.tabBar.translucent);
    //2. 设置tabb背景
    /*
    self.tabBar.backgroundImage = [UIImage imageNamed:@"tab_bg_all.png"];
    NSLog(@"%d",self.tabBar.translucent); //NO ,设置图片时,会影响标签栏的透明度
//    self.tabBar.translucent = YES;
     */
    UIImageView *bgImgView = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"tab_bg_all.png"]];
    bgImgView.frame = CGRectMake(0, 0, kScreenWidth, 49);
    [self.tabBar addSubview:bgImgView];

    //3. 创建选择视图
    selectImg = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"selectTabbar_bg_all1.png"]];
    selectImg.frame = CGRectMake(0, 0, 55, 45);
    [self.tabBar addSubview:selectImg];
    
    //4. 创建自定义按钮
    //图片名字
    NSArray *imgNames = @[@"movie_home.png",@"msg_select_new.png",@"start_top250.png",@"icon_cinema.png",@"more_setting.png"];
    
    //按钮标题
    NSArray *titles = @[@"电影",@"新闻",@"TOP",@"影院",@"更多"];
    
    CGFloat width = kScreenWidth / imgNames.count;
    CGFloat height = kTabbarHeight;
    for (NSInteger i = 0; i < imgNames.count; i++) {
        
        NSString *imageName = [imgNames objectAtIndex:i];
        NSString *title = [titles objectAtIndex:i];
        /*
        UIButton *btn = [UIButton buttonWithType:UIButtonTypeCustom];
        btn.frame = CGRectMake(i * width, 0, width, height);
        
        [btn setImage:[UIImage imageNamed:imageName] forState:UIControlStateNormal];
        [btn setTitle:title forState:UIControlStateNormal];
        
        btn.titleLabel.font = [UIFont systemFontOfSize:11];
        
        //调整标题的位置
        btn.titleEdgeInsets = UIEdgeInsetsMake(30, 0, 0, 18);
        
        //调整图片的位置
        btn.imageEdgeInsets  = UIEdgeInsetsMake(0, 20, 10, 0);
        [self.tabBar addSubview:btn];
         */
        
        //封装自定义按钮
        HWBotton *btn = [[HWBotton alloc] initWithFrame:CGRectMake(i * width, 0, width, height) withImage:[UIImage imageNamed:imageName] withTitle:title];
        btn.tag = i;
        [btn addTarget:self action:@selector(clickAction:) forControlEvents:UIControlEventTouchUpInside];
        [self.tabBar addSubview:btn];
        
        if (i == 0) {
            
            selectImg.center = btn.center;
        }
        
    }
 }

//- (void)viewDidAppear:(BOOL)animated{
//
//    [super viewDidAppear:animated];
//    
//    NSLog(@"%@",self.tabBar.subviews);
//
//}
- (void)_createSubCtrls{
    
    //第三级控制器
    //首页
    MovieViewController *movieCtrl = [[MovieViewController alloc] init];
    //新闻
    NewsViewController *newsCtrl = [[NewsViewController alloc] init];
    //TOP
    TopViewController *topCtrl = [[TopViewController alloc] init];
    
    //影院
    CinemaViewController *cinameCtrl = [[CinemaViewController alloc] init];
    //更多
    MoreViewController *moreCtrl = [[MoreViewController alloc] init];
    
    //创建数组
    NSArray *viewCtrls = @[movieCtrl,newsCtrl,topCtrl,cinameCtrl,moreCtrl];
    
    //创建可变数组,存储导航控制器
    NSMutableArray *navs = [NSMutableArray arrayWithCapacity:viewCtrls.count];
   //创建二级控制器导航控制器
    for (UIViewController *ctrl in viewCtrls) {
        NavViewController *nav = [[NavViewController alloc] initWithRootViewController:ctrl];
//        //导航栏背景图片
//        [nav.navigationBar setBackgroundImage:[UIImage imageNamed:@"nav_bg_all-64.png"] forBarMetrics:UIBarMetricsDefault];
        
        //将导航控制器加入到数组中
        [navs addObject:nav];
    }
    
    //将导航控制器交给标签控制器管理
    self.viewControllers = navs;

}

- (void)clickAction:(HWBotton *)btn{
    
    [UIView beginAnimations:nil context:nil];
    [UIView setAnimationDuration:.3];
    selectImg.center = btn.center;
    [UIView commitAnimations];
    //切换控制器
    self.selectedIndex = btn.tag;

}

@end
