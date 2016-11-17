//
//  YYBottomView.m
//  slide
//
//  Created by 吴洋洋 on 16/5/10.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYBottomView.h"
#import "UIButton+CZ.h"

@implementation YYBottomView

+ (instancetype)bottomView
{
    return [[[NSBundle mainBundle] loadNibNamed:@"YYBottomView" owner:nil options:nil] lastObject];
}
- (IBAction)playOrPauseClickBtn:(UIButton *)btn {
    
    self.playing = !self.playing;
    
    //如果为暂停状态，图片为播放
    if (self.playing) {
        
        [btn setNBg:@"play" hBg:@"playHight"];
        
        [self.showPlayingImage stopAnimating];
        
        self.showPlayingImage.image = [UIImage imageNamed:@"playLine"];
        
        [self delegateBtnType:BtnTypePause];
        
    }
    //如果为播放状态，图片为暂停
    else{
        
        [btn setNBg:@"pasue" hBg:@"pasueHight"];
    
        [self.showPlayingImage startAnimating];
        
        [self delegateBtnType:BtnTypePlay];
        
    }
}

- (void)delegateBtnType: (BtnType)btnType
{
    if ([self.myDelegate respondsToSelector:@selector(bottomPlayBar:btnType:)]) {
        [self.myDelegate bottomPlayBar:self btnType:btnType];
    }
}

//重写方法
- (void)setHeadImage:(UIImageView *)headImage
{
    _headImage = headImage;
    _headImage.layer.cornerRadius = 3;
    _headImage.layer.masksToBounds = YES;
    
}

- (void)awakeFromNib
{
    self.showPlayingImage.animationImages = [NSArray arrayWithObjects:[UIImage imageNamed:@"line1"],[UIImage imageNamed:@"line2"],[UIImage imageNamed:@"line3"],[UIImage imageNamed:@"line4"], nil];
    self.showPlayingImage.animationDuration = 1.0;
    
     [self.showPlayingImage startAnimating];

}

@end
