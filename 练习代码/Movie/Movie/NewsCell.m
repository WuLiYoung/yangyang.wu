//
//  NewsCell.m
//  Movie
//
//  Created by apple on 15/6/8.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "NewsCell.h"
#import "UIImageView+WebCache.h"
#import "Common.h"
//enum NewsType{
//    
//    kWordType,
//    kImageType,
//    kVideoType
//    
//};

@implementation NewsCell

- (void)awakeFromNib {
    // Initialization code
    
    self.backgroundColor = [UIColor clearColor];
    
    self.selectionStyle = UITableViewCellSelectionStyleNone;
    }

//- (void)setNews:(News *)news{
//
//    _news = news;
//    
//    [self setNeedsLayout];
//    
//}

- (void)layoutSubviews{

    [super layoutSubviews];
    
    //填充数据
    _newsTitle.text = _news.title; //新闻标题
    [_newsImage sd_setImageWithURL:[NSURL URLWithString:_news.image]]; //图片
    _summryLable.text = _news.summary; //副标题
    
      //0 文字新闻  1图片新闻 2视频新闻
    
    if (_news.type == kWordType) {
        
        _typeImage.image = nil;
        
    }else if(_news.type == kImageType){
    
        _typeImage.image = [UIImage imageNamed:@"sctpxw.png"];
        
    }else if(_news.type == kVideoType){
    
        
        _typeImage.image = [UIImage imageNamed:@"scspxw.png"];

    }
    
}

@end
