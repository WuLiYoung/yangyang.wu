//
//  NHTabBar.m
//  --ios彩票
//
//  Created by 吴洋洋 on 15/12/30.
//  Copyright © 2015年 吴洋洋. All rights reserved.
//

#import "NHTabBarController.h"
#import "NHTabBar.h"

@interface NHTabBarController () <NHTabBarDelegate>



@end

@implementation NHTabBarController

- (void)viewDidLoad {
    [super viewDidLoad];
    NSLog(@"%s",__func__);
    // Do any additional setup after loading the view, typically from a nib.
    NHTabBar *myTabBar = [[NHTabBar alloc] initWithFrame:self.tabBar.bounds];
    myTabBar.backgroundColor = [UIColor redColor];
    
    //设置代理
    myTabBar.delegate = self;
    
    for (NSInteger i = 0; i < 5; i++) {
        
        NSString *nolImg = [NSString stringWithFormat:@"TabBar%ld",i+1];
        NSString *selImg = [NSString stringWithFormat:@"TabBar%ldSel",i+1];
        
        [myTabBar addTabBarWithNolImg:nolImg andselImg:selImg];
    }

    //添加到tabbar上
    [self.tabBar addSubview:myTabBar];
    
}

#pragma mark - 代理方法
- (void)tabBar:(NHTabBar *)tabBar didselectedFrom:(NSInteger)from to:(NSInteger)to
{
    //切换tabbar控制器的子控件
    self.selectedIndex = to;
}

@end
