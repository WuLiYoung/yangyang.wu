//
//  PosterDetailView.m
//  Movie
//
//  Created by apple on 15/6/14.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "PosterDetailView.h"
#import "UIImageView+WebCache.h"

@implementation PosterDetailView

/*
// Only override drawRect: if you perform custom drawing.
// An empty implementation adversely affects performance during animation.
- (void)drawRect:(CGRect)rect {
    // Drawing code
}
*/
- (void)awakeFromNib{

    self.backgroundColor = [UIColor darkGrayColor];

}

- (void)setMovie:(Movie *)movie{

    _movie = movie;
    [self setNeedsLayout];

}


- (void)layoutSubviews{

    [super layoutSubviews];
    
    //添加数
    _titleLable.text = [NSString stringWithFormat:@"原名:%@",_movie.title];
    _engTitleLable.text = [NSString stringWithFormat:@"英文名:%@",_movie.original_title];
    _yearLable.text = [NSString stringWithFormat:@"年份:%@",_movie.year];
    
    [_movieImageView sd_setImageWithURL:[NSURL URLWithString:_movie.images[@"medium"]]];
    _starView.rating = _movie.average;
    
    _ratingLabel.text = [NSString stringWithFormat:@"%.1lf",_movie.average];
    


}
@end
