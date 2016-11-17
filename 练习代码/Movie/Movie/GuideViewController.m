//
//  GuideViewController.m
//  WXMovie
//
//  Created by mac on 15/3/11.
//  Copyright (c) 2015年 mac. All rights reserved.
//

#import "GuideViewController.h"

#import "LaunchViewContrller.h"

@interface GuideViewController ()

@end

@implementation GuideViewController

- (void)viewDidLoad {
    [super viewDidLoad];

    
    [self _creatSubView];
    // Do any additional setup after loading the view.
}

- (void)_creatSubView{

    for (NSInteger i= 0; i < 5; i++) {
        
        NSString *imageName = [NSString stringWithFormat:@"guide%ld@2x.png",i + 1];
        NSString *pageImageName = [NSString stringWithFormat:@"guideProgress%ld@2x.png",i + 1];
        
        UIImageView *imageView = [[UIImageView alloc] initWithFrame:CGRectMake(kScreenWidth * i, 0, kScreenWidth, kScreenHeight)];
        
        [imageView setImage:[UIImage imageNamed:imageName]];
        [_scrollView addSubview:imageView];
        
        
        UIImageView *pageImageView = [[UIImageView alloc] initWithFrame:CGRectMake((kScreenWidth - 173) / 2 +kScreenWidth * i  , kScreenHeight - 50, 173, 26)];
        
        [pageImageView setImage:[UIImage imageNamed:pageImageName]];
        [_scrollView addSubview:pageImageView];
    }
    
    _scrollView.delegate = self;
    _scrollView.contentSize = CGSizeMake(5*kScreenWidth, kScreenHeight);
    _scrollView.pagingEnabled = YES;

}


//当滑动视图,减速停止时,调用
- (void)scrollViewDidEndDecelerating:(UIScrollView *)scrollView {

    NSInteger index =  scrollView.contentOffset.x / kScreenWidth;
    
    if (index == 4) {
        
        _btn.hidden = NO;
    }
    

}      // called when scroll view grinds to a halt

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/



- (IBAction)btnAction:(id)sender {
    
    LaunchViewContrller *launch = [[LaunchViewContrller alloc] init];
    
    self.view.window.rootViewController = launch;
//    [UIApplication sharedApplication].keyWindow;
    
   
}
@end
