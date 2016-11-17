//
//  CZToolBar.m
//  微博
//
//  Created by 吴洋洋 on 16/2/23.
//  Copyright © 2016年 apple. All rights reserved.
//

#import "CZToolBar.h"
#import "CZStatus.h"

@interface  CZToolBar ()

@property (nonatomic,strong) NSMutableArray *btns;

@property (nonatomic,strong) NSMutableArray *lines;

@property (nonatomic,weak) UIButton *unlike;
@property (nonatomic,weak) UIButton *comment;
@property (nonatomic,weak) UIButton *retweet;


@end

@implementation CZToolBar

- (NSMutableArray *)btns
{
    if (_btns == nil) {
        _btns = [NSMutableArray array];
    }
    return _btns;
}

- (NSMutableArray *)lines
{
    if (_lines == nil) {
        _lines = [NSMutableArray array];
    }
    return _lines;
}

- (instancetype)initWithFrame:(CGRect)frame
{
    if (self = [super initWithFrame:frame]) {
        
        [self setUpAllChildView];
        
        self.userInteractionEnabled = YES;
        self.image = [UIImage imageNamed:@"timeline_card_bottom_background"];
    }
    return self;
}

//添加所有子控件
- (void)setUpAllChildView
{
    //赞
    UIButton *unlike = [self setUpOneChildViewWithTitle:@"赞" image:[UIImage imageNamed:@"timeline_icon_unlike"]];
    
    //评论
        UIButton *comment = [self setUpOneChildViewWithTitle:@"评论" image:[UIImage imageNamed:@"timeline_icon_comment"]];
    
    //转发
        UIButton *retweet = [self setUpOneChildViewWithTitle:@"转发" image:[UIImage imageNamed:@"timeline_icon_retweet"]];
    
    //分割线
    for (int i = 0; i < 2; i++) {
        UIImageView *image = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"timeline_card_bottom_line"]];
        
        [self.lines addObject:image];
    }
    
}

//添加一个控件
- (UIButton *)setUpOneChildViewWithTitle: (NSString *)title image: (UIImage *)image
{
    UIButton *btn = [UIButton buttonWithType:UIButtonTypeCustom];
    
    [btn setImage:image forState:UIControlStateNormal];
    [btn setTitle:title forState:UIControlStateNormal];
    [btn setTitleColor:[UIColor grayColor] forState:UIControlStateNormal];
    btn.titleLabel.font = [UIFont systemFontOfSize:12];
    btn.titleEdgeInsets = UIEdgeInsetsMake(0, 6, 0, 0);
    
    [self addSubview:btn];
    [self.btns addObject:btn];
    return btn;
}

- (void)layoutSubviews
{
    [super layoutSubviews];
    
    CGFloat w = CZScreenW / self.btns.count;
    CGFloat h = self.height;
    CGFloat x = 0;
    CGFloat y = 0;
    
    NSInteger count = self.btns.count;
    
    for (int i = 0; i < count; i++) {
        UIButton *btn = self.btns[i];
        
        x = i * w;
        
        btn.frame = CGRectMake(x, y, w, h);
    }
    
    int  i = 1;
    for (UIImageView *imageV in self.lines) {
        UIButton *btn = self.btns[i];
        
        imageV.x = btn.x;
        
        i++;
        
    }
}

- (void)setStatus:(CZStatus *)status
{
    _status = status;
    
    /************************转发数************************/
    NSString *reposts_count = nil;
    if (status.reposts_count) {
        
        if (status.reposts_count > 10000) {
            CGFloat floatreposts_count = status.reposts_count / 10000.0;
            reposts_count = [NSString stringWithFormat:@"%.1fW",floatreposts_count];
            reposts_count = [reposts_count stringByReplacingOccurrencesOfString:@".0" withString:@""];
        }else{
        
             reposts_count = [NSString stringWithFormat:@"%d",status.reposts_count];
        }
        
        //设置转发数
        [_retweet setTitle:reposts_count forState:UIControlStateNormal];
    }
    
    /***********************评论数************************/
    NSString *comments_count = nil;
    if (status.comments_count) {
        
        if(status.comments_count > 10000) {
            CGFloat floatreposts_count = status.comments_count / 10000.0;
            reposts_count = [NSString stringWithFormat:@"%.1fW",floatreposts_count];
            reposts_count = [reposts_count stringByReplacingOccurrencesOfString:@".0" withString:@""];
        }else{
            
            comments_count = [NSString stringWithFormat:@"%d",status.comments_count];
        }

        
        //设置评论数
        [_retweet setTitle:comments_count forState:UIControlStateNormal];
    }
    
    /************************赞数************************/
    NSString *attitudes_count = nil;
    if (status.attitudes_count) {
        if (status.attitudes_count > 10000) {
            CGFloat floatreposts_count = status.attitudes_count / 10000.0;
            reposts_count = [NSString stringWithFormat:@"%.1fW",floatreposts_count];
            reposts_count = [reposts_count stringByReplacingOccurrencesOfString:@".0" withString:@""];
        }else{
            
            attitudes_count = [NSString stringWithFormat:@"%d",status.attitudes_count];
        }
        
        //设置赞数
        [_retweet setTitle:attitudes_count forState:UIControlStateNormal];
    }
    
}

@end
