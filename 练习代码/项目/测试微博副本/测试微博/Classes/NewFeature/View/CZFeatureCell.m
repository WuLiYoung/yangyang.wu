//
//  CZFeatureCell.m
//  微博
//
//  Created by 吴洋洋 on 16/2/19.
//  Copyright © 2016年 apple. All rights reserved.
//

#import "CZFeatureCell.h"
#import "CZTabBarController.h"

@interface CZFeatureCell ()

@property (nonatomic,weak) UIImageView *imageView;

@property (nonatomic,weak) UIButton *shareBtn;

@property (nonatomic,weak) UIButton *startBtn;


@end

@implementation CZFeatureCell
- (UIButton *)shareBtn
{
    if (_shareBtn == nil) {
        UIButton *btn = [UIButton buttonWithType:UIButtonTypeCustom];
        
        [btn setTitle:@"分享给大家" forState:UIControlStateNormal];
        [btn setImage:[UIImage imageNamed:@"new_feature_share_false"] forState:UIControlStateNormal];
        [btn setImage:[UIImage imageNamed:@"new_feature_share_true"] forState:UIControlStateSelected];
        [btn setTitleColor:[UIColor blackColor] forState:UIControlStateNormal];
        
        //自动适配
        [btn sizeToFit];
        
        [self.contentView addSubview:btn];
        
        _shareBtn = btn;
        
    }
    return _shareBtn;
}

- (UIButton *)startBtn
{
    if (_startBtn == nil) {
        UIButton *btn = [UIButton buttonWithType:UIButtonTypeCustom];
        
        [btn setTitle:@"开始微博" forState:UIControlStateNormal];
        [btn setBackgroundImage:[UIImage imageNamed:@"new_feature_finish_button"] forState:UIControlStateNormal];
        [btn setBackgroundImage:[UIImage imageNamed:@"new_feature_finish_button_highlighted"] forState:UIControlStateHighlighted];
        [btn setTitleColor:[UIColor blackColor] forState:UIControlStateNormal];
        
        [btn addTarget:self action:@selector(startWb) forControlEvents:UIControlEventTouchUpInside];
        
        //自动适配
        [btn sizeToFit];
        
        [self addSubview:btn];
        
        _startBtn = btn;
        
    }
    return _startBtn;
}

//懒加载
- (UIImageView *)imageView
{
    if (_imageView == nil) {
        UIImageView *IV = [[UIImageView alloc] init];
        
        _imageView = IV;
        
        //注意：一定要加在contentView上面
        [self.contentView addSubview:IV];
    }
    return _imageView;
}

//布局子控件
- (void)layoutSubviews
{
    [super layoutSubviews];
    
    self.imageView.frame = self.bounds;
    
    self.shareBtn.center = CGPointMake(self.width * 0.5, self.height * 0.8);
    
    self.startBtn.center = CGPointMake(self.width * 0.5, self.height * 0.9);
}

- (void)setImage:(UIImage *)image
{
    _image = image;
    
    self.imageView.image = image;
}

- (void)startWb
{
    //进入tabBarVc控制器
    CZTabBarController *tabBarVc = [[CZTabBarController alloc] init];
    
    //切换控制器，直接清除掉原来的控制器
    CZKeyWindow.rootViewController = tabBarVc;
}

//判断是否为最一页
- (void)setIndexPath:(NSIndexPath *)indexPath count:(int)count
{
    if (indexPath.row == count - 1) {
        
        self.shareBtn.hidden = NO;
        
        self.startBtn.hidden = NO;
        
    }else{
    
        self.shareBtn.hidden = YES;
        
        self.startBtn.hidden = YES;
    }
}
@end
