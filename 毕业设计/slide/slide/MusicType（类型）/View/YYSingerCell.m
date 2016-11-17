//
//  YYSingerCell.m
//  slide
//
//  Created by 吴洋洋 on 16/5/11.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYSingerCell.h"
#import "YYSingerModel.h"
#import "UIImageView+WebCache.h"

@implementation YYSingerCell

- (void)setModel:(YYSingerModel *)model
{
    _model = model;
    
    self.singerIcon.layer.cornerRadius = self.singerIcon.frame.size.width / 2;
    self.singerIcon.layer.masksToBounds = YES;
    [self.singerIcon sd_setImageWithURL:[NSURL URLWithString:model.pic_url] placeholderImage:[UIImage imageNamed:@"default.jpg"]];
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
