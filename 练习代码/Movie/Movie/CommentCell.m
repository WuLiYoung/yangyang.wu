//
//  CommentCell.m
//  Movie
//
//  Created by apple on 15/6/16.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "CommentCell.h"
#import "UIImageView+WebCache.h"
@implementation CommentCell

- (void)awakeFromNib {
   
    
    _contentLable.numberOfLines = 0;
    
    //圆角
    _userImgView.layer.cornerRadius = 5;
    _userImgView.layer.masksToBounds = YES;
}

- (void)setComment:(Comment *)comment{

    _comment = comment;
    
    [self setNeedsLayout];
}


- (void)layoutSubviews{
    [super layoutSubviews];

    [_userImgView sd_setImageWithURL:[NSURL URLWithString:_comment.userImage]];
    _contentLable.text = _comment.content;
    _userNameLable.text = _comment.nickname;
    _ratingLable.text = _comment.rating;


}
@end
