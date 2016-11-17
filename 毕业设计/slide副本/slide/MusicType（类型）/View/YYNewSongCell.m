
//
//  YYNewSongCell.m
//  slide
//
//  Created by 吴洋洋 on 16/5/3.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYNewSongCell.h"
#import "MJExtension.h"
#import "UIImageView+WebCache.h"
#import "YYNewSongModel.h"

@implementation YYNewSongCell

- (void)setModel:(YYNewSongModel *)model
{
    _model = model;
    
    [[SDImageCache sharedImageCache] clearMemory];
    [self.albumImageView sd_setImageWithURL:[NSURL URLWithString:model.pic] placeholderImage:[UIImage imageNamed:@"default"]];
    self.albumSingerName.text = [model.desc componentsSeparatedByString:@"-"][0];
    self.albumSongName.text = [model.desc componentsSeparatedByString:@"-"][1];
}

@end
