//
//  PosterCell.m
//  Movie
//
//  Created by apple on 15/6/14.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "PosterCell.h"
#import "UIImageView+WebCache.h"
#import "PosterDetailView.h"

@implementation PosterCell{

    UIImageView *imageView;
    PosterDetailView *detailView;
}

- (id)initWithFrame:(CGRect)frame{

    self = [super initWithFrame:frame];
    
    if (self) {
        
//        self.contentView.transform = CGAffineTransformMakeScale(.9, .9);
        
        //1.
        /*
        [self.contentView.layer setValue:@.9 forKeyPath:@"transform.scale"];
        
        UIImageView *imageView = [[UIImageView alloc] initWithFrame:self.contentView.bounds];
        imageView.backgroundColor = [UIColor greenColor];
        [self.contentView addSubview:imageView];
         */
        //2.
        CGFloat width = self.width * .9;
        CGFloat height = self.height * .9;
        imageView = [[UIImageView alloc] initWithFrame:CGRectMake((self.width - width) / 2, (self.height - height) / 2, width, height)];
        [self.contentView addSubview:imageView];
        
        
        //3.海报详情
        detailView = [[[NSBundle mainBundle] loadNibNamed:@"PosterDetailView" owner:nil options:nil] lastObject];
        detailView.frame = imageView.frame;
        detailView.hidden = YES;
        [self.contentView addSubview:detailView];
        
        
    }
    return self;
}
- (void)setMovie:(Movie *)movie{

    _movie = movie;
    
    //填充数据,设置图片
    [imageView sd_setImageWithURL:[NSURL URLWithString:_movie.images[@"large"]]];
    
    //将数据交给电影详情
    detailView.movie = _movie;
    
    
    
}


- (void)flipView {

    UIViewAnimationOptions option = detailView.hidden ? UIViewAnimationOptionTransitionFlipFromLeft :UIViewAnimationOptionTransitionFlipFromRight;
    
    [UIView transitionWithView:self duration:.3 options:option animations:NULL completion:NULL];
    //改变子视图的显示状态
    imageView.hidden = !imageView.hidden;
    detailView.hidden = !detailView.hidden;
}

@end
