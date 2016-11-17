//
//  ViewController.m
//  slideHeadView
//
//  Created by 吴洋洋 on 16/4/20.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "ViewController.h"
#import "SlideHeadView.h"
#import "OneViewController.h"
#import "SettingController.h"
#import "CHMusicTypeController.h"
#import "CHSearchController.h"
#import "CHOpenSearchController.h"
#import "CHMyMusicController.h"


@interface ViewController ()

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];

    [self addChildViewController];
    
}

- (void)addChildViewController
{
    SlideHeadView *shv = [[SlideHeadView alloc] init];
    
    [self.view addSubview:shv];
    
    CHMusicTypeController *oneVC = [[CHMusicTypeController alloc] init];
    oneVC.navigation = self.navigationController;
    
    OneViewController *twoVC = [[OneViewController alloc] init];
    twoVC.view.backgroundColor = [UIColor grayColor];
    
    CHOpenSearchController *threeVC = [self.storyboard instantiateViewControllerWithIdentifier:@"chOpenSearch"];
    threeVC.navigation = self.navigationController;
    
    
    CHMyMusicController *fourVC = [self.storyboard instantiateViewControllerWithIdentifier:@"chMyMusic"];
    fourVC.navigation = self.navigationController;
    //fourVC.view.backgroundColor = [UIColor yellowColor];
    
    SettingController *fiveVC = [[SettingController alloc] init];

    
    NSArray *arr = @[@"乐库",@"热听",@"搜索",@"我的音乐",@"设置"];
    
    
    [shv addChildViewController:oneVC title:arr[0]];
    [shv addChildViewController:twoVC title:arr[1]];
    [shv addChildViewController:threeVC title:arr[2]];
    [shv addChildViewController:fourVC title:arr[3]];
    [shv addChildViewController:fiveVC title:arr[4]];
    
    
    [shv setSlideHeadView];
}

@end
