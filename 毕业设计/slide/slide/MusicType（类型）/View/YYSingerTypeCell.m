//
//  YYSingerTypeCell.m
//  slide
//
//  Created by 吴洋洋 on 16/5/12.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYSingerTypeCell.h"
#import "UIImageView+WebCache.h"
#import "YYSingerTypeModel.h"

@implementation YYSingerTypeCell

- (void)setModel:(YYSingerTypeModel *)model
{
    _model = model;
    
    self.singerType.text = model.title;
    
    self.faceImage.layer.shadowColor = [UIColor blackColor].CGColor;
    self.faceImage.layer.shadowOffset = CGSizeMake(0,0);
    self.faceImage.layer.shadowOpacity = 3.0;
    self.faceImage.layer.shadowRadius= 1.5;
    
    [self.faceImage sd_setImageWithURL:[NSURL URLWithString:model.pic_url] placeholderImage:[UIImage imageNamed:@"default"]];
}

- (void)awakeFromNib {
    // Initialization code
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

@end
