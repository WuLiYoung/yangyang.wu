//
//  NHBuyTogetherVC.m
//  --ios彩票
//
//  Created by 吴洋洋 on 16/1/1.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "NHBuyTogetherVC.h"

@interface NHBuyTogetherVC ()
- (IBAction)btnClick:(id)sender;

@end

@implementation NHBuyTogetherVC

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
}



- (IBAction)btnClick:(UIButton *)btn {

    //设置图片的旋转
    [UIView animateWithDuration:0.5 animations:^{
        if (CGAffineTransformIsIdentity(btn.imageView.transform)) {
            //要旋转
             btn.imageView.transform = CGAffineTransformMakeRotation(M_PI);
        }else{
        
            btn.imageView.transform = CGAffineTransformIdentity;
        }
       
    }];
  
}
@end
