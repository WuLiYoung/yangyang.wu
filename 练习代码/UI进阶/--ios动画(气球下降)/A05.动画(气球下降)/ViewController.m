//
//  ViewController.m
//  A05.动画(气球下降)
//
//  Created by Apple on 15/1/2.
//  Copyright (c) 2015年 itcast. All rights reserved.
//

#import "ViewController.h"
#import "BallonView.h"

@interface ViewController ()

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view, typically from a nib.
    
    // 添加 自定义气球的view到控制器view
    BallonView *ballonView = [[BallonView alloc] init];
    ballonView.frame = self.view.bounds;
    ballonView.backgroundColor = [UIColor grayColor];
    [self.view addSubview:ballonView];
    
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

@end
