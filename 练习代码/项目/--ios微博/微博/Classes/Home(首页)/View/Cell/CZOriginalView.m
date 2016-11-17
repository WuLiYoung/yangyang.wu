//
//  CZOriginalView.m
//  微博
//
//  Created by 吴洋洋 on 16/2/23.
//  Copyright © 2016年 apple. All rights reserved.
//

#import "CZOriginalView.h"
#import "CZStatusFrame.h"
#import "CZStatus.h"

#import "UIImageView+WebCache.h"

#import "CZPhotosView.h"

@interface CZOriginalView ()

//头像
@property (nonatomic,weak) UIImageView *iconView;

//昵称
@property (nonatomic,weak) UILabel *nameView;

//VIP
@property (nonatomic,weak) UIImageView *VIPView;

//时间
@property (nonatomic,weak) UILabel *timeView;

//来源
@property (nonatomic,weak) UILabel *sourceView;

//正文
@property (nonatomic,weak) UILabel *textView;

//配图
@property (nonatomic,weak) CZPhotosView *photoView;


@end

@implementation CZOriginalView

- (instancetype)initWithFrame:(CGRect)frame
{
    if (self = [super initWithFrame:frame]) {
        
        [self setUpAllChildView];
        
        self.userInteractionEnabled = YES;
        
        self.image = [UIImage imageWithStretchableName:@"timeline_card_top_background"];
    }
    return self;
}

//添加所有子控件
- (void)setUpAllChildView
{
    //头像
    UIImageView *iconView = [[UIImageView alloc] init];
    [self addSubview:iconView];
    _iconView = iconView;
    
    //昵称
    UILabel *nameView = [[UILabel alloc] init];
    nameView.font = CZNameFont;
    [self addSubview:nameView];
    _nameView = nameView;
    
    //VIP
    UIImageView *VIPView = [[UIImageView alloc] init];
    [self addSubview:VIPView];
    _VIPView = VIPView;
    
    //时间
    UILabel *timeView = [[UILabel alloc] init];
    timeView.font = CZTimeFont;
    timeView.textColor = [UIColor orangeColor];
    [self addSubview:timeView];
    _timeView = timeView;
    
    //来源
    UILabel *sourceView = [[UILabel alloc] init];
    sourceView.font = CZSourceFont;
    sourceView.textColor = [UIColor grayColor];
    [self addSubview:sourceView];
    _sourceView = sourceView;
    
    //正文
    UILabel *textView = [[UILabel alloc] init];
    textView.font = CZTextFont;
    textView.numberOfLines = 0;
    [self addSubview:textView];
    _textView = textView;
    
    //配图
    CZPhotosView *photoView = [[CZPhotosView alloc] init];
    [self addSubview:photoView];
    _photoView = photoView;
}

//设置子控件的大小
- (void)setStatusF:(CZStatusFrame *)statusF
{
    _statusF = statusF;
    //设置frame
    [self setUpFrame];
    
    //设置数据
    [self setUpData];
}

-  (void)setUpFrame
{
    _iconView.frame = _statusF.oringinalIconFrame;
    
    _nameView.frame = _statusF.oringinalNameFrame;
    
    if (_statusF.status.user.vip) {
        
        _VIPView.hidden = NO;
        
        _VIPView.frame = _statusF.oringinalVIPFrame;
        
    }
//    else{
//    
//        _VIPView.hidden = YES;
//    }
//    
    CZStatus *status = _statusF.status;
    //每次都计算时间的frame（每次的时间不同）
    
    CGFloat timeX     = _nameView.frame.origin.x;
    CGFloat timeY     = CGRectGetMaxY(_nameView.frame) + CZStatusCellMargin * 0.5;
    CGSize timeSize   = [status.created_at sizeWithFont:CZTimeFont];
    
    _timeView.frame   = (CGRect){{timeX,timeY},timeSize};
    
    CGFloat sourceX   = CGRectGetMaxX(_nameView.frame) + CZStatusCellMargin;
    CGFloat sourceY   = timeY;
    CGSize sourceSize = [status.source sizeWithFont:CZSourceFont];
    
    //每次都计算来源的frame（微博的来源不同）
    _sourceView.frame = (CGRect){{sourceX,sourceY},sourceSize};
    
    _textView.frame   = _statusF.oringinalTextFrame;
    
    _photoView.frame  = _statusF.oringinalphotoFrame;
    
}

- (void)setUpData
{
    CZStatus *status = _statusF.status;
    
    //头像数据
    [_iconView sd_setImageWithURL:status.user.profile_image_url placeholderImage:[UIImage imageNamed:@"timeline_image_placeholder"]];
    
    //昵称数据
    _nameView.text = status.user.name;
    
    //vip数据
    NSString *imageName = [NSString stringWithFormat:@"common_icon_membership_level%d",status.user.mbrank];
    
    if (status.user.vip) {
        
        _VIPView.image = [UIImage imageNamed:imageName];
        _nameView.textColor = [UIColor redColor];
        
    }else{
        _VIPView.image = [UIImage imageNamed:@"common_icon_membership_expired"];
        _nameView.textColor = [UIColor blackColor];
    }
    
    //时间数据
    _timeView.text = status.created_at;
    
    //来源
    _sourceView.text = status.source;
    
    //正文
    _textView.text = status.text;
    
    //配图
    _photoView.pic_urls = status.pic_urls;
}

@end
