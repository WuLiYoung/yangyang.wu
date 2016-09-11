//
//  YYLocalMusicCell.m
//  slide
//
//  Created by 吴洋洋 on 16/5/8.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYLocalMusicCell.h"
#import "YYLocalMusicModel.h"

@implementation YYLocalMusicCell

- (void)setModel:(YYLocalMusicModel *)model
{
    _model = model;
    
    self.textLabel.text = model.songName;
    self.detailTextLabel.text = model.singer;
}

- (void)awakeFromNib {
    // Initialization code
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

@end
