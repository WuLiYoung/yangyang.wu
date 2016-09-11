//
//  YYSongTypeCell.m
//  slide
//
//  Created by 吴洋洋 on 16/5/11.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYSongTypeCell.h"
#import "YYSongTypeModel.h"
#import "UIImageView+WebCache.h"

@implementation YYSongTypeCell

- (void)setModel:(YYSongTypeModel *)model
{
    _model = model;
    
    self.title.text = model.songlist_name;
    
    [self.typeImage sd_setImageWithURL:[NSURL URLWithString:model.pic_url_240_200] placeholderImage:[UIImage imageNamed:@"default"]];
}

@end
