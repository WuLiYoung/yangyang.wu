//
//  YYBodyCell.m
//  slide
//
//  Created by 吴洋洋 on 16/5/3.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYBodyCell.h"
#import "MusicModel.h"

@implementation YYBodyCell

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
    
    NSString *num = nil;
    
    if (model.pick_count < 10000) {
        
        num = [NSString stringWithFormat:@"%ld",model.pick_count];
    }else{
    
        num = [NSString stringWithFormat:@"%.1f万",model.pick_count / 10000.0];
    }
    
    self.favoriteCount.text = num;
    
    
}

@end
