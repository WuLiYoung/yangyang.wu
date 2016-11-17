//
//  YYModaController.m
//  slide
//
//  Created by 吴洋洋 on 16/5/10.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYModaController.h"
#import "YYBottomView.h"
#import "UIImage+CZ.h"
#import "UIImage+ImageEffects.h"
#import "YYMusicListController.h"

#import "YYPlayToolOL.h"

@interface YYModaController () <YYBottomViewDelegate>
@property (weak, nonatomic) IBOutlet UIView *bottomView;
@property (nonatomic,strong) YYBottomView *BV;
@property (nonatomic,strong) CADisplayLink *link; //定时器
@property (nonatomic,assign,getter=isClick) BOOL click;


@end

@implementation YYModaController

- (CADisplayLink *)link
{
    if (_link == nil) {
        _link = [CADisplayLink displayLinkWithTarget:self selector:@selector(run)];
    }
    return _link;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    [self animation];
    
    //开启定时器
    [self.link addToRunLoop:[NSRunLoop mainRunLoop] forMode:NSDefaultRunLoopMode];
    
    /****************添加底部播放条****************/
    YYBottomView *bv = [YYBottomView bottomView];
    
    self.BV = bv;
    
    self.BV.myDelegate = self;
    
    [self.bottomView addSubview:bv];
    
    /***************背景添加加毛玻璃效果***************/
    UIImage *image = [[UIImage imageNamed:@"LaunchImage"] applyDarkEffect];
    
    self.bgImage.image = image;
    
    /****************中心图片变圆角****************/
    self.centerImage.image = [UIImage circleImageWithName:@"circle" borderWidth:2.0 borderColor:[UIColor yellowColor]];
    
    //开始播放
    [[YYPlayToolOL sharedYYPlayToolOL] play];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    
   
}

//中心图片旋转
- (void)run
{
    if (!self.BV.playing) {
        
        CGFloat angle = M_PI_4 / 200;
        
        self.centerImage.transform = CGAffineTransformRotate(self.centerImage.transform, angle);
    }

}

//结束，移除定时器
- (void)dealloc
{
    [self.link removeFromRunLoop:[NSRunLoop mainRunLoop] forMode:NSDefaultRunLoopMode];
}

//YYBottomViewDelegate方法
- (void)bottomPlayBar:(YYBottomView *)bottomPlayBar btnType:(BtnType)btnType
{
    switch (btnType) {
        case BtnTypePlay:
            [[YYPlayToolOL sharedYYPlayToolOL] play];
            break;
        case BtnTypePause:
            [[YYPlayToolOL sharedYYPlayToolOL] pause];
            break;
            
        default:
            break;
    }
}

- (IBAction)dismiss:(id)sender {
    
    [self dismissViewControllerAnimated:YES completion:^{
        
    }];
}
- (IBAction)love:(UIButton *)btn {
    self.click = !self.click;
    if (self.click) {
        [btn setImage:[UIImage imageNamed:@"cm2_operbar_icn_love"] forState:UIControlStateNormal];
    }else{
    
        [btn setImage:[UIImage imageNamed:@"cm2_operbar_icn_loved"] forState:UIControlStateNormal];
    }
    
}
- (IBAction)praise:(UIButton *)btn {
    self.click = !self.click;
    if (self.click) {
        [btn setImage:[UIImage imageNamed:@"cm2_btm_tab_icn_praise"] forState:UIControlStateNormal];
    }else{
        
        [btn setImage:[UIImage imageNamed:@"cm2_btm_tab_icn_praised"] forState:UIControlStateNormal];
    }
}

// 樱花飘落
- (void)animation{

    self.bgImage.contentMode = UIViewContentModeScaleAspectFill;
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
    [self.bgImage.layer addSublayer:snowEmitterLayer];

    
}

@end
