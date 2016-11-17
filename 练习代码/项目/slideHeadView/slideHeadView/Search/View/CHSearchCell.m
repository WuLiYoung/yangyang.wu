//
//  CHSearchCell.m
//  slideHeadView
//
//  Created by 吴洋洋 on 16/4/28.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHSearchCell.h"
#import "CHMusicModel.h"

@interface CHSearchCell ()
@property (weak, nonatomic) IBOutlet UILabel *loveCount;
@property (weak, nonatomic) IBOutlet UILabel *singerName;

@end


@implementation CHSearchCell

- (void)setModel:(CHMusicModel *)model
{
    _model = model;
    
    self.loveCount.text = [NSString stringWithFormat:@"%ld",model.pick_count];
    self.singerName.text = model.singer_name;
}

- (void)awakeFromNib {
    // Initialization code
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

@end
