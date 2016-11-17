//
//  YYPlayToolBar.m
//  slide
//
//  Created by 吴洋洋 on 16/5/8.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYPlayToolBar.h"
#import "UIButton+CZ.h"
#import "YYPlayTool.h"
#import "NSString+CZ.h"


#import "UIImage+ImageEffects.h"



@interface YYPlayToolBar ()
@property (weak, nonatomic) IBOutlet UIImageView *playBarView;
@property (weak, nonatomic) IBOutlet UIImageView *playLineView;
@property (weak, nonatomic) IBOutlet UISlider *sliderTime;
@property (weak, nonatomic) IBOutlet UILabel *currenttTime;
@property (weak, nonatomic) IBOutlet UILabel *totalTime;

@property (nonatomic,strong) CADisplayLink *link;

@property (nonatomic,assign,getter=isdragging) BOOL dragging;

@end

@implementation YYPlayToolBar


- (CADisplayLink *)link
{
    if (!_link) {
        _link = [CADisplayLink displayLinkWithTarget:self selector:@selector(updateTime)];
    }
    return _link;
}

+ (instancetype)playToolBar
{
    return [[[NSBundle mainBundle] loadNibNamed:@"YYPlayToolBar" owner:nil options:nil] lastObject];
}

//正在播放的音乐
- (void)setPlayingMusic:(YYLocalMusicModel *)playingMusic
{
    _playingMusic = playingMusic;
    
    [self setTime];
    
    self.playLineView.animationImages = [NSArray arrayWithObjects:[UIImage imageNamed:@"line1"],[UIImage imageNamed:@"line2"],[UIImage imageNamed:@"line3"],[UIImage imageNamed:@"line4"], nil];
    self.playLineView.animationDuration = 1.0;
    
    if (!self.playing) {
        [self.playLineView startAnimating];
    }
}


//设置时间
- (void)setTime
{
    //获取采样时间
    double duration = [YYPlayTool sharedYYPlayTool].player.duration;
    
    //设置总时间
    self.totalTime.text = [NSString getMinuteSecondWithSecond:duration];
    
    //设置slider的总时间
    self.sliderTime.maximumValue = duration;
    
    //重置slider的起始时间
    self.sliderTime.value = 0;
    

}

- (IBAction)palyBtnClick:(UIButton *)btn {
    
    self.playing = !self.playing;
    //如果为暂停状态，图片为播放
    if (self.playing) {
        
        [btn setNBg:@"playbar_playbtn_nomal" hBg:@"playbar_playbtn_click"];
        
        [self.playLineView stopAnimating];
        
        self.playLineView.image = [UIImage imageNamed:@"playLine"];
        
        [self delegateBtnType:BtnTypePause];
        
    }
    //如果为播放状态，图片为暂停
    else{
    
        [btn setNBg:@"playbar_pausebtn_nomal" hBg:@"playbar_pausebtn_click"];
        
        [self.playLineView startAnimating];
        
        [self delegateBtnType:BtnTypePlay];

    }
    
}

- (IBAction)preClickBtn:(UIButton *)btn {
    [self animation];
    
    [self delegateBtnType:BtnTypePrevious];
    self.currenttTime.text = [NSString getMinuteSecondWithSecond:0];
}

- (IBAction)nextClickBtn:(UIButton *)btn {
    
    [self animation];
    
    [self delegateBtnType:BtnTypeNext];
    self.currenttTime.text = [NSString getMinuteSecondWithSecond:0];
}

- (void)animation
{
    
    if (!self.playing) {
        [self.playLineView startAnimating];
    }
    else
    {
        [self.playLineView stopAnimating];
    }

}

- (void)delegateBtnType: (BtnType)btnType
{
    //通知代理
    if ([self.myDelegate respondsToSelector:@selector(playToolBar:btnType:)]) {
        [self.myDelegate playToolBar:self btnType:btnType];
    }
}

- (void)awakeFromNib
{
    [self.sliderTime setThumbImage:[UIImage imageNamed:@"playbar_slider_thumb"] forState:UIControlStateNormal];
    
    //开启定时器
    [self.link addToRunLoop:[NSRunLoop mainRunLoop] forMode:NSDefaultRunLoopMode];
    
}

//结束后移除定时器
- (void)dealloc
{
    [self.link removeFromRunLoop:[NSRunLoop mainRunLoop] forMode:NSDefaultRunLoopMode];
}

//更新时间
- (void)updateTime
{
    if (!self.isPlaying && self.isdragging == NO) {
        
        double currentTime = [YYPlayTool sharedYYPlayTool].player.currentTime;
        
        
        self.sliderTime.value = currentTime;
        
        //设置当前的时间
        self.currenttTime.text = [NSString getMinuteSecondWithSecond:currentTime];
        
    }
 
    
}

//拖动进度条
- (IBAction)sliderChange:(UISlider *)sender {
    
  
    [YYPlayTool sharedYYPlayTool].player.currentTime = sender.value;
    
    self.currenttTime.text = [NSString getMinuteSecondWithSecond:sender.value];
    
}

//点击进度条时，停止播放
- (IBAction)stopPlay:(id)sender {
    
    self.dragging = YES;
    
    [[YYPlayTool sharedYYPlayTool] pause];
    
    [self.playLineView stopAnimating];
    
}

//松开进度条时，开始播放
- (IBAction)rePlay:(id)sender {
    
    self.dragging = NO;
    
    if (!self.isPlaying) {
        
        [[YYPlayTool sharedYYPlayTool] play];
        
        [self.playLineView startAnimating];
    }
    
    
}

//播放模式
- (IBAction)playModel:(UIButton *)btn {
    
    self.random = !self.random;
    
    [self delegateBtnType:BtnTypePlayModel];
    
}

@end
