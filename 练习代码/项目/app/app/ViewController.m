//
//  ViewController.m
//  app
//
//  Created by 吴洋洋 on 16/4/16.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "ViewController.h"

@interface ViewController ()
@property (nonatomic,strong) UIButton *myBtn;
@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    self.myBtn = [UIButton buttonWithType:UIButtonTypeCustom];
    
    self.myBtn.frame = CGRectMake(100 , 100, 30, 30);
    
    self.myBtn.backgroundColor = [UIColor blueColor];
    
    [self.myBtn addObserver:self forKeyPath:@"highlighted" options:0 context:nil];
    
    [self.view addSubview:self.myBtn];
}

- (void)observeValueForKeyPath:(NSString *)keyPath ofObject:(id)object change:(NSDictionary<NSString *,id> *)change context:(void *)context
{
    if ([keyPath isEqualToString:@"highlighted"]) {
        [self.myBtn setNeedsDisplay];
    }
}

@end
