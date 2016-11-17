//
//  MovieHeaderView.m
//  Movie
//
//  Created by apple on 15/6/16.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "MovieHeaderView.h"
#import "UIImageView+WebCache.h"
#import <MediaPlayer/MediaPlayer.h> //播放视频

@implementation MovieHeaderView

- (void)awakeFromNib{

    //滑动视图的边框与圆角
    _scrollView.layer.cornerRadius = 5;
    _scrollView.layer.borderWidth = 1;
    _scrollView.layer.borderColor = [UIColor whiteColor].CGColor;

}


- (void)setModel:(MovieDetaiModel *)model{

    _model = model;
    [self setNeedsLayout];
    
    //创建图片列表
    [self _createImageListView];
}

- (void)_createImageListView{
    
    NSArray *images = _model.images;
    
    for (NSInteger i = 0; i < images.count; i++) {
        
        UIImageView *imageView = [[UIImageView alloc] initWithFrame:CGRectMake(5 + 65 * i, 5, 60, 60)];
        
        //图片圆角
        imageView.layer.cornerRadius = 5;
        imageView.layer.masksToBounds = YES;
        
        //设置图片
        NSString *url = images[i];
        [imageView sd_setImageWithURL:[NSURL URLWithString:url]];
        [_scrollView addSubview:imageView];
        
        
    }
    
    //滑动视图的内容大小
    _scrollView.contentSize = CGSizeMake(5 + images.count * 65, 70);
    //取消滑动条
    _scrollView.showsHorizontalScrollIndicator = NO;
    


}

- (void)layoutSubviews{

    [super layoutSubviews];
    
    [_movieImage sd_setImageWithURL:[NSURL URLWithString:_model.image]];
    
    //电影标题
    _movieTitle.text = _model.titleCn;
    
    //导演
    NSString *directors = [_model.directors componentsJoinedByString:@","];
    _directorLable.text = [NSString stringWithFormat:@"导演: %@",directors];
    
    //演员
    NSString *actors = [_model.actors componentsJoinedByString:@","];
    _actorLable.text = [NSString stringWithFormat:@"演员: %@",actors];
    
    //类型
    NSString *type = [_model.type componentsJoinedByString:@","];
    _typeLable.text = [NSString stringWithFormat:@"类型: %@",type];
    
    //年份
    NSString *location = _model.movieRelease[@"location"];
    NSString *date = _model.movieRelease[@"date"];
    
    _yearLable.text = [NSString stringWithFormat:@"%@ %@",location,date];
    

}
- (IBAction)playActin:(id)sender {
    
    //发送播放电影的通知
    [[NSNotificationCenter defaultCenter] postNotificationName:@"playMovieNotification" object:nil];
    

}
@end
