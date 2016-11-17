//
//  IndexCell.m
//  Movie
//
//  Created by apple on 15/6/15.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "IndexCell.h"
#import "UIImageView+WebCache.h"
@implementation IndexCell{

    UIImageView *imageView;

}

- (id)initWithFrame:(CGRect)frame{
    
    self = [super initWithFrame:frame];

    if (self) {
        
        CGFloat width = self.width * .9;
        CGFloat height = self.height * .9;
        imageView = [[UIImageView alloc] initWithFrame:CGRectMake((self.width - width) / 2, (self.height - height) / 2, width, height)];
        [self.contentView addSubview:imageView];
    }
    
    return self;
    
}
- (void)setMovie:(Movie *)movie{
    
    _movie = movie;
    
    //填充数据,设置图片
    [imageView sd_setImageWithURL:[NSURL URLWithString:_movie.images[@"small"]]];
    

}

@end
