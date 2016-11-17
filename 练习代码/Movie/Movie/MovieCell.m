//
//  MovieCell.m
//  Movie
//
//  Created by apple on 15/6/5.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "MovieCell.h"
#import "UIImageView+WebCache.h"

@implementation MovieCell

//如果单元格存在在xib中,那么此方法不会被调用,只有当单元格是alloc方式创建时,才会被调用
- (id)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier{
    
    self = [super initWithStyle:style reuseIdentifier:reuseIdentifier];
    
    if (self) {
        
        //不要在此填充数据,因为数据还没有传入
//        _movieTitleLable.text = _movie.title;

    }
    
    return self;

}


//当从xib中加载单元格时,此方法会被调用,类似于初始化方法
- (void)awakeFromNib{
    //不要在此填充数据,因为数据还没有传入
//    _movieTitleLable.text = _movie.title;

    //去掉背景颜色
    self.backgroundColor = [UIColor clearColor];
    
    //取消选中效果
    self.selectionStyle = UITableViewCellSelectionStyleNone;

}

//复写set方法监听数据的传入
//- (void)setMovie:(Movie *)movie{
//
//    _movie = movie;
//    [self setNeedsLayout]; //当数据传入时,通知系统抽个空调用layoutSubviews
//    
////    [self layoutSubviews]; 错误,不要直接调用此方法
//    
//    //SDWebImage --- > GitHub
//}


//1. 布局子视图  2.填充数据
- (void)layoutSubviews{
    [super layoutSubviews];
    
    //给子视图填充数据
    //电影标题
    _movieTitleLable.text = _movie.title;
    
    //评分
    _ratingLable.text = [NSString stringWithFormat:@"%.1f",_movie.average];
    
    //年份
    _yearLable.text = [NSString stringWithFormat:@"年份:%@",_movie.year];
    
    //设置星星的分数
    _starView.rating = _movie.average;
    
    //取得图片url地址  medium:中图
    NSString *imageStr = [_movie.images objectForKey:@"medium"];
    NSURL *url = [NSURL URLWithString:imageStr];
    //通过SDWebImage第三方框架提供的方法,加载网络图片
    //SDWebImage框架中提供了UIImageView+WebCache.h类目给UIImageView扩展了从网络加载图片的方法
    [_movieImage sd_setImageWithURL:url];
    

}
@end
