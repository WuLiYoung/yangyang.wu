//
//  TopCell.m
//  Movie
//
//  Created by apple on 15/6/12.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "TopCell.h"
#import "UIImageView+WebCache.h"

@implementation TopCell

- (void)awakeFromNib {
   //设置电影标题的背景
    _tiltleLable.backgroundColor = [UIColor colorWithWhite:.2 alpha:.4];
    _tiltleLable.textAlignment = NSTextAlignmentCenter;
}

- (void)setMovie:(Movie *)movie{
    _movie = movie;
    [self setNeedsLayout];
}

- (void)layoutSubviews{

    [super layoutSubviews];
    
    //填充电影数据
    _tiltleLable.text = _movie.title;
    
    _ratingLable.text = [NSString stringWithFormat:@"%.1f",_movie.average];
    
    NSString *imageUrl = _movie.images[@"medium"];
    [_mvoieImageView sd_setImageWithURL:[NSURL URLWithString:imageUrl]];
    
    _starView.rating = _movie.average;
    
    

}

@end
