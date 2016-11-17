//
//  CZRetWeetView.m
//  微博
//
//  Created by 吴洋洋 on 16/2/23.
//  Copyright © 2016年 apple. All rights reserved.
//

#import "CZRetWeetView.h"
#import "CZStatus.h"
#import "CZStatusFrame.h"
#import "CZPhotosView.h"

@interface CZRetWeetView ()

//昵称
@property (nonatomic,weak) UILabel *nameView;

//正文
@property (nonatomic,weak) UILabel *textView;

//配图
@property (nonatomic,weak) CZPhotosView *photoView;

@end

@implementation CZRetWeetView
- (instancetype)initWithFrame:(CGRect)frame
{
    if (self = [super initWithFrame:frame]) {
        
        [self setUpAllChildView];
        
        //允许用户
        self.userInteractionEnabled = YES;
        self.image = [UIImage imageWithStretchableName:@"timeline_retweet_background"];
    }
    return self;
}

//添加所有子控件
- (void)setUpAllChildView
{
    //昵称
    UILabel *nameView = [[UILabel alloc] init];
    nameView.font = CZNameFont;
    nameView.textColor = [UIColor purpleColor];
    [self addSubview:nameView];
    _nameView = nameView;
    
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

- (void)setStatusF:(CZStatusFrame *)statusF
{
    _statusF = statusF;
    
    CZStatus *status = statusF.status;
    
    _nameView.frame = statusF.retweetNameFrame;
    _nameView.text = status.retweeted_name;
    
    _textView.frame = statusF.retweetTextFrame;
    _textView.text = status.retweeted_status.text;
    
    _photoView.frame = statusF.retweetphotoFrame;
    _photoView.pic_urls = status.retweeted_status.pic_urls;
    
}

@end
