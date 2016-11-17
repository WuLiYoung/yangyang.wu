//
//  CHPlayerToolbar.m
//  --ios音乐播放器
//
//  Created by 吴洋洋 on 15/12/22.
//  Copyright © 2015年 吴洋洋. All rights reserved.
//

#import "CHPlayerToolbar.h"
#import "UIButton+CZ.h"
#import "CHMusic.h"
#import "UIImage+CZ.h"
#import "CHMusicTool.h"
#import "NSString+CZ.h"

@interface CHPlayerToolbar ()


@property (weak, nonatomic) IBOutlet UIImageView *singericonView;
@property (weak, nonatomic) IBOutlet UILabel *musicName;
@property (weak, nonatomic) IBOutlet UILabel *singerName;
@property (weak, nonatomic) IBOutlet UISlider *timeSlider;
@property (weak, nonatomic) IBOutlet UILabel *totalTime;
@property (weak, nonatomic) IBOutlet UILabel *currentTime;

@property (strong,nonatomic) CADisplayLink *link; //定时器
@property (nonatomic,assign,getter=isdraging) BOOL draging;


@end

@implementation CHPlayerToolbar

/*
// Only override drawRect: if you perform custom drawing.
// An empty implementation adversely affects performance during animation.
- (void)drawRect:(CGRect)rect {
    // Drawing code
}
*/

- (CADisplayLink *)link
{
    if (!_link) {
        _link = [CADisplayLink displayLinkWithTarget:self selector:@selector(update)];
    }
    return _link;
}

+ (instancetype)playerToolBar
{
    return [[[NSBundle mainBundle] loadNibNamed:@"CHPlayerToolbar" owner:nil options:nil] lastObject];
}

- (void)setPlayingMusic:(CHMusic *)playingMusic
{
    //先赋值
    _playingMusic = playingMusic;
    
    //歌手头像，歌手的头像是圆形的，有边框
    UIImage *circleImage = [UIImage circleImageWithName:playingMusic.singerIcon borderWidth:2.0 borderColor:[UIColor blueColor]];
    
    self.singerName.text      = playingMusic.singer;
    
    self.musicName.text       = playingMusic.name;
    
    self.singericonView.image = circleImage;

    //设置总时间
    double duration     = [CHMusicTool sharedCHMusicTool].player.duration;
    self.totalTime.text = [NSString getMinuteSecondWithSecond:duration];
    
    //设置slider最大数值
    self.timeSlider.maximumValue  = duration;

    //重新设置进度条slider
    self.timeSlider.value         = 0;

    self.singericonView.transform = CGAffineTransformIdentity;
    
    
}

- (IBAction)playBtnClicl:(UIButton *)btn {
    //更改状态
    self.playing = !self.playing;
    if (self.playing) {
        NSLog(@"开始播放");
        //如果是播放状态，图片应该改为暂停图片
        [btn setNBg:@"playbar_pausebtn_nomal" hBg:@"playbar_pausebtn_click"];
        
        [self notifyDelegateClickWithBtnType:BtnTypePaly];
        
    }else
    {
        NSLog(@"暂停播放");
        //如果是暂停状态，图片应该改为播放图片
        [btn setNBg:@"playbar_playbtn_nomal" hBg:@"playbar_playbtn_click"];
        [self notifyDelegateClickWithBtnType:BtnTypePause];

    }
    

}

//下一首
- (IBAction)nextClick:(id)sender {
    [self notifyDelegateClickWithBtnType:BtnTypeNext];
    
    //恢复头像的位置
    self.singericonView.transform = CGAffineTransformIdentity;
    
}

//上一首
- (IBAction)preBtnClick:(id)sender {
    [self notifyDelegateClickWithBtnType:BtnTypePrevious];

}

//通知代理
- (void)notifyDelegateClickWithBtnType: (BtnType)btnType
{
    if ([self.delegate respondsToSelector:@selector(playerToolBar:btnClickWithType:)]) {
        [self.delegate playerToolBar:self btnClickWithType:btnType];
    }
}


- (void)awakeFromNib
{
    //设置slider的按钮图片
    [self.timeSlider setThumbImage:[UIImage imageNamed:@"playbar_slider_thumb"] forState:UIControlStateNormal];
    
    //开启定时器
    [self.link addToRunLoop:[NSRunLoop mainRunLoop] forMode:NSDefaultRunLoopMode];
}

- (void)dealloc
{
    //移除定时器
    [self.link removeFromRunLoop:[NSRunLoop mainRunLoop] forMode:NSDefaultRunLoopMode];
}

- (void)update
{
    if (self.isplaying && self.isdraging == NO) {
        // 1.更新进度条
        double cureentTime            = [CHMusicTool sharedCHMusicTool].player.currentTime;
        self.timeSlider.value         = cureentTime;

        // 2.更新时间
        self.currentTime.text         = [NSString getMinuteSecondWithSecond:cureentTime];

        //转动头像
        CGFloat angle                 = M_PI_4 / 60;
        self.singericonView.transform = CGAffineTransformRotate(self.singericonView.transform, angle);
    }

    
}

//slider拖动
- (IBAction)sliderChange:(UISlider *)sender {
    
    // 1.播放的进度
    [CHMusicTool sharedCHMusicTool].player.currentTime = sender.value;
    
    // 2.工具条的当前时间
    self.currentTime.text = [NSString getMinuteSecondWithSecond:sender.value];
}

//点击时，暂停播放
- (IBAction)stopPlay:(UISlider *)sender {
    
    self.draging = YES;
    
    [[CHMusicTool sharedCHMusicTool] pause];
}

//松开时，继续播放
- (IBAction)rePlay:(UISlider *)sender {
    
    self.draging = NO;
    
    if (self.isplaying) {
        [[CHMusicTool sharedCHMusicTool] play];
    }
}

@end
