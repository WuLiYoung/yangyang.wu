//
//  CZStatusFrame.m
//  微博
//
//  Created by 吴洋洋 on 16/2/24.
//  Copyright © 2016年 apple. All rights reserved.
//

#import "CZStatusFrame.h"
#import "CZStatus.h"
#import "CZUser.h"



@implementation CZStatusFrame

- (void)setStatus:(CZStatus *)status
{
    _status = status;
    
    // 计算原创微博
    [self setUpOriginalViewFrame];
    
    CGFloat toolBarY = CGRectGetMaxY(_oringinalViewFrame);
    
    if (status.retweeted_status) {
        
        // 计算转发微博
        [self setUpRetweetViewFrame];
        
        toolBarY = CGRectGetMaxY(_retweetViewFrame);
    }
    // 计算工具条
    CGFloat toolBarX = 0;
    CGFloat toolBarW = CZScreenW;
    CGFloat toolBarH = 35;
    _toolBarFrame = CGRectMake(toolBarX, toolBarY, toolBarW, toolBarH);
    
    // 计算cell高度
    _cellHeight = CGRectGetMaxY(_toolBarFrame);
    
}

#pragma mark - 计算原创微博
- (void)setUpOriginalViewFrame
{
    // 头像
    CGFloat imageX = CZStatusCellMargin;
    CGFloat imageY = imageX;
    CGFloat imageWH = 35;
    _oringinalIconFrame = CGRectMake(imageX, imageY, imageWH, imageWH);
    
    // 昵称
    CGFloat nameX = CGRectGetMaxX(_oringinalIconFrame) + CZStatusCellMargin;
    CGFloat nameY = imageY;
    CGSize nameSize = [_status.user.name sizeWithFont:CZNameFont];
    _oringinalNameFrame = (CGRect){{nameX,nameY},nameSize};
    
    // vip
    if (_status.user.vip) {
        CGFloat vipX = CGRectGetMaxX(_oringinalNameFrame) + CZStatusCellMargin;
        CGFloat vipY = nameY;
        CGFloat vipWH = 14;
        _oringinalVIPFrame = CGRectMake(vipX, vipY, vipWH, vipWH);
        
    }
    
    
    // 正文
    CGFloat textX = imageX;
    CGFloat textY = CGRectGetMaxY(_oringinalIconFrame) + CZStatusCellMargin;
    
    CGFloat textW = CZScreenW - 2 * CZStatusCellMargin;
    CGSize textSize = [_status.text sizeWithFont:CZTextFont constrainedToSize:CGSizeMake(textW, MAXFLOAT)];
    _oringinalTextFrame = (CGRect){{textX,textY},textSize};
    
    CGFloat originH = CGRectGetMaxY(_oringinalTextFrame) + CZStatusCellMargin;
    
    // 配图
    if (_status.pic_urls.count) {
        CGFloat photosX = CZStatusCellMargin;
        CGFloat photosY = CGRectGetMaxY(_oringinalTextFrame) + CZStatusCellMargin;
        CGSize photosSize = [self photosSizeWithCount:_status.pic_urls.count];
        
        _oringinalphotoFrame = (CGRect){{photosX,photosY},photosSize};
        originH = CGRectGetMaxY(_oringinalphotoFrame) + CZStatusCellMargin;
    }
    
    // 原创微博的frame
    CGFloat originX = 0;
    CGFloat originY = 10;
    CGFloat originW = CZScreenW;
    
    _oringinalViewFrame = CGRectMake(originX, originY, originW, originH);
    
}
#pragma mark - 计算配图的尺寸
- (CGSize)photosSizeWithCount:(int)count
{
    // 获取总列数
    int cols = count == 4? 2 : 3;
    // 获取总行数 = (总个数 - 1) / 总列数 + 1
    int rols = (count - 1) / cols + 1;
    CGFloat photoWH = 70;
    CGFloat w = cols * photoWH + (cols - 1) * CZStatusCellMargin;
    CGFloat h = rols * photoWH + (rols - 1) * CZStatusCellMargin;
    
    
    return CGSizeMake(w, h);
    
}

#pragma mark - 计算转发微博
- (void)setUpRetweetViewFrame
{
    // 昵称frame
    // 昵称
    CGFloat nameX = CZStatusCellMargin;
    CGFloat nameY = nameX;
    // 注意：一定要是转发微博的用户昵称
    CGSize nameSize = [_status.retweeted_name sizeWithFont:CZNameFont];
    _retweetNameFrame = (CGRect){{nameX,nameY},nameSize};
    
    // 正文
    CGFloat textX = nameX;
    CGFloat textY = CGRectGetMaxY(_retweetNameFrame) + CZStatusCellMargin;
    
    CGFloat textW = CZScreenW - 2 * CZStatusCellMargin;
    // 注意：一定要是转发微博的正文
    CGSize textSize = [_status.retweeted_status.text sizeWithFont:CZTextFont constrainedToSize:CGSizeMake(textW, MAXFLOAT)];
    _retweetTextFrame = (CGRect){{textX,textY},textSize};
    
    CGFloat retweetH = CGRectGetMaxY(_retweetTextFrame) + CZStatusCellMargin;
    // 配图
    NSInteger count = _status.retweeted_status.pic_urls.count;
    if (count) {
        CGFloat photosX = CZStatusCellMargin;
        CGFloat photosY = CGRectGetMaxY(_retweetTextFrame) + CZStatusCellMargin;
        CGSize photosSize = [self photosSizeWithCount:count];
        
        _retweetphotoFrame = (CGRect){{photosX,photosY},photosSize};
        
        retweetH = CGRectGetMaxY(_retweetphotoFrame) + CZStatusCellMargin;
    }
    
    // 原创微博的frame
    CGFloat retweetX = 0;
    CGFloat retweetY = CGRectGetMaxY(_oringinalViewFrame);
    CGFloat retweetW = CZScreenW;
    
    _retweetViewFrame = CGRectMake(retweetX, retweetY, retweetW, retweetH);
    
}
@end

