//
//  YYPlayMusicController.m
//  slide
//
//  Created by 吴洋洋 on 16/5/8.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYPlayMusicController.h"
#import "YYPlayToolBar.h"
#import "UIImage+CZ.h"
#import "MBProgressHUD.h"

#import "MJExtension.h"
#import "UIImage+ImageEffects.h"
#import "YYPlayTool.h"
#import "YYLocalMusicModel.h"

#import <AVFoundation/AVFoundation.h>

@interface YYPlayMusicController () <YYPlayToolBarDelegate,AVAudioPlayerDelegate>

@property (weak, nonatomic) IBOutlet UIImageView *BgImage;

@property (nonatomic,weak) YYPlayToolBar *toolBar;
@property (nonatomic,strong) NSMutableArray *musics;

@property (nonatomic,strong) CADisplayLink *link;


//@property (nonatomic,strong) UIVisualEffectView *blurEffectView;

@end

@implementation YYPlayMusicController

- (CADisplayLink *)link
{
    if (!_link) {
        _link = [CADisplayLink displayLinkWithTarget:self selector:@selector(run)];
    }
    return _link;
}

//加载音乐数据
- (NSMutableArray *)musics
{
    if (_musics == nil) {
        _musics = [YYLocalMusicModel mj_objectArrayWithFilename:@"songs.plist"];
    }
    return _musics;
}

- (void)viewDidAppear:(BOOL)animated
{
    [super viewDidAppear:animated];
    
    //背景动画
//    [self animation];
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    //开启定时器
    [self.link addToRunLoop:[NSRunLoop mainRunLoop] forMode:NSDefaultRunLoopMode];
    
    YYPlayToolBar *toolBar = [YYPlayToolBar playToolBar];
    
    self.toolBar = toolBar;
    
    //设置代理
    toolBar.myDelegate = self;
    
    [self.bottomView addSubview:toolBar];
    
    //设置左边的返回按钮
    UIBarButtonItem *leftBack = [[UIBarButtonItem alloc] initWithImage:[UIImage imageNamed:@"btn_back"] style:UIBarButtonItemStylePlain target:self action:@selector(back:)];
    self.navigationItem.leftBarButtonItem = leftBack;
    
    //设置中心图片
    UIImage *circleImage = [UIImage circleImageWithName:@"song_400" borderWidth:2.0 borderColor:[UIColor blueColor]];
    
    self.centerImage.image = circleImage;
    
    //设置毛玻璃效果
    self.BgImage.image = [[UIImage imageNamed:@"LaunchImage"] applyDarkEffect];
    
    
    YYLocalMusicModel *model = self.musics[self.musicIndex];
    
    self.toolBar.playingMusic = model;
    
    self.singerName.text = model.singer;
    
    NSLog(@"正在播放第%ld首歌",self.musicIndex + 1);
    

    
}
//定时器running
- (void)run
{
    if (!self.toolBar.playing) {
        
        CGFloat angle = M_PI_4 / 250;
        self.centerImage.transform = CGAffineTransformRotate(self.centerImage.transform, angle);
    }
    
}

//结束销毁定时器
- (void)dealloc
{
    [self.link removeFromRunLoop:[NSRunLoop mainRunLoop] forMode:NSDefaultRunLoopMode];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}



#pragma mark - YYPlayToolBar代理方法

- (void)playToolBar:(YYPlayToolBar *)toolBar btnType:(BtnType)btnType
{
    switch (btnType) {
        case BtnTypePlay:
            [[YYPlayTool sharedYYPlayTool] play];
            break;
        case BtnTypePause:
             [[YYPlayTool sharedYYPlayTool] pause];
            break;
        case BtnTypePrevious:
            [self previous];
            break;
        case BtnTypeNext:
            [self next];
            break;
        case BtnTypePlayModel:
            [self palyModel];
            break;
            
        default:
            break;
    }
}

//上一首
- (void)previous
{
    if (self.musicIndex == 0) {
        self.musicIndex = self.musics.count - 1;
    }
    else{
    self.musicIndex--;
        
    }
     NSLog(@"正在播放第%ld首歌",self.musicIndex + 1);
    [self playMusicNextOrPrevious];
}

//下一首
- (void)next
{
    if (self.musicIndex == self.musics.count - 1) {
        self.musicIndex = 0;
    }
    else{
        self.self.musicIndex++;
        
    }
     NSLog(@"正在播放第%ld首歌",self.musicIndex + 1);
    [self playMusicNextOrPrevious];
    
    
}

//播放上一首或下一首
- (void)playMusicNextOrPrevious
{
    
    //获取模型
    YYLocalMusicModel *model = self.musics[self.musicIndex];
    
    //初始化播放器
    [[YYPlayTool sharedYYPlayTool] preparePlayMusic:self.musics[self.musicIndex]];
    
    
    self.toolBar.playingMusic = self.musics[self.musicIndex];
    
    //设置代理
    [YYPlayTool sharedYYPlayTool].player.delegate = self;
    
    self.navigationItem.title = model.songName;
    
    self.singerName.text = model.singer;
    
    //判断是否正在播放
    if (!self.toolBar.playing) {
        
        //播放
        [[YYPlayTool sharedYYPlayTool] play];
        
    }
    
    //随机
    if (self.toolBar.random) {
        
        NSInteger randomIndex = arc4random() % self.musics.count;
        
        self.musicIndex = randomIndex;
        
    }
    
    //让图片复原
    self.centerImage.transform = CGAffineTransformIdentity;
    
}

//完成时，自动播放下一首
- (void)audioPlayerDidFinishPlaying:(AVAudioPlayer *)player successfully:(BOOL)flag
{
    [self next];
}

- (void)palyModel
{
    MBProgressHUD *mb = [MBProgressHUD showHUDAddedTo:self.view animated:YES];
    mb.mode = MBProgressHUDModeText;
    
    if (self.toolBar.random) {//随机模式
        [self.toolBar.playModelBtn setImage:[UIImage imageNamed:@"repeat4.png"] forState:UIControlStateNormal];
        
            mb.labelText = @"随机模式";
        
    } else {//循环模式
        [self.toolBar.playModelBtn setImage:[UIImage imageNamed:@"repeat1.png"] forState:UIControlStateNormal];
        
            mb.labelText = @"循环模式";
    }
    
    //0.8秒后隐藏
    [mb hide:YES afterDelay:0.8];
}

#pragma mark - Setter
- (void)setMusicIndex:(NSInteger)musicIndex {
    
    if (_musicIndex == musicIndex) {
        return;
    }
    _musicIndex = musicIndex;
    
    [self playMusicNextOrPrevious];
}

//背景动画
- (void)animation{
    
    // =================== 背景图片 ===========================
    //    UIImageView * backgroundView = [[UIImageView alloc] initWithFrame:CGRectMake(0, 0, self.view.bounds.size.width, self.view.bounds.size.height)];
//      self.BgImage.image = [UIImage imageNamed:@"樱花树3"];
    self.BgImage.contentMode = UIViewContentModeScaleAspectFill;
    //    [self.view addSubview:backgroundView];
    
    
    // =================== 樱花飘落 ====================
    CAEmitterLayer * snowEmitterLayer = [CAEmitterLayer layer];
    snowEmitterLayer.emitterPosition = CGPointMake(100, -30);
    snowEmitterLayer.emitterSize = CGSizeMake(self.view.bounds.size.width * 2, 0);
    snowEmitterLayer.emitterMode = kCAEmitterLayerOutline;
    snowEmitterLayer.emitterShape = kCAEmitterLayerLine;
    //    snowEmitterLayer.renderMode = kCAEmitterLayerAdditive;
    
    CAEmitterCell * snowCell = [CAEmitterCell emitterCell];
    snowCell.contents = (__bridge id)[UIImage imageNamed:@"樱花瓣2"].CGImage;
    
    // 花瓣缩放比例
    snowCell.scale = 0.02;
    snowCell.scaleRange = 0.5;
    
    // 每秒产生的花瓣数量
    snowCell.birthRate = 7;
    snowCell.lifetime = 80;
    
    // 每秒花瓣变透明的速度
    snowCell.alphaSpeed = -0.01;
    
    // 秒速“五”厘米～～
    snowCell.velocity = 40;
    snowCell.velocityRange = 60;
    
    // 花瓣掉落的角度范围
    snowCell.emissionRange = M_PI;
    
    // 花瓣旋转的速度
    snowCell.spin = M_PI_4;
    
    // 每个cell的颜色
    //    snowCell.color = [[UIColor redColor] CGColor];
    
    // 阴影的 不透明 度
    snowEmitterLayer.shadowOpacity = 1;
    // 阴影化开的程度（就像墨水滴在宣纸上化开那样）
    snowEmitterLayer.shadowRadius = 8;
    // 阴影的偏移量
    snowEmitterLayer.shadowOffset = CGSizeMake(3, 3);
    // 阴影的颜色
    snowEmitterLayer.shadowColor = [[UIColor whiteColor] CGColor];
    
    
    snowEmitterLayer.emitterCells = [NSArray arrayWithObject:snowCell];
    [self.BgImage.layer addSublayer:snowEmitterLayer];
    
    
}


//返回上一个控制器
- (void)back: (UIBarButtonItem *)item
{
    [self.navigation popToRootViewControllerAnimated:YES];
}

@end
