//
//  CHLoginController.m
//  --ios百思不得其姐
//
//  Created by 吴洋洋 on 16/4/6.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHLoginController.h"

@interface CHLoginController ()
@property (weak, nonatomic) IBOutlet UIImageView *loginBg;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *leftViewMargin;

@end

@implementation CHLoginController
- (IBAction)dismiss:(id)sender {
    [self dismissViewControllerAnimated:YES completion:^{
        
    }];
}
- (IBAction)loginOrRegisterClick:(UIButton *)btn {
    
    //退出键盘
    [self.view endEditing:YES];
    
    if (self.leftViewMargin.constant == 0) {
        
        self.leftViewMargin.constant = - 2 * self.view.width;
//        [btn setTitle:@"已有账号？" forState:UIControlStateNormal];
        btn.selected = YES;
        
    }else
    {
        self.leftViewMargin.constant =  0;
//          [btn setTitle:@"登录注册" forState:UIControlStateNormal];
           btn.selected = NO;
    }
    
    
    
    [UIView animateWithDuration:0.25 animations:^{
        [self.view layoutIfNeeded];
    }];
    
}

- (void)viewDidLoad {
    [super viewDidLoad];
  
    [self.view insertSubview:self.loginBg atIndex:0];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (UIStatusBarStyle)preferredStatusBarStyle
{
    return UIStatusBarStyleLightContent;
}

@end
