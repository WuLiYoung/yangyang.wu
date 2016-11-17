//
//  YYSearchCell.m
//  slide
//
//  Created by 吴洋洋 on 16/5/5.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYSearchCell.h"
#import "MusicModel.h"

@implementation YYSearchCell

- (void)awakeFromNib {
    // Initialization code
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

- (void)setModel:(MusicModel *)model
{
    _model = model;
    
    self.singerName.text = model.singer_name;
    self.songName.text = model.song_name;
    
    NSString *count = nil;
    if (model.pick_count < 10000) {
        count = [NSString stringWithFormat:@"%ld",model.pick_count];
    }else{
    
        count = [NSString stringWithFormat:@"%.1f万",model.pick_count / 10000.0];
    }
    
    self.favoriteCount.text = count;
}

@end
