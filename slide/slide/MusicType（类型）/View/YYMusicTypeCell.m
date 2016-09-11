//
//  YYMusicTypeCell.m
//  slide
//
//  Created by 吴洋洋 on 16/5/3.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYMusicTypeCell.h"
#import "YYMusicTypeModel.h"

@interface YYMusicTypeCell ()
@property (weak, nonatomic) IBOutlet UIImageView *image;
@property (weak, nonatomic) IBOutlet UILabel *lbl;


@end

@implementation YYMusicTypeCell

- (void)setModel:(YYMusicTypeModel *)model
{
    _model = model;
    
    self.image.image = [UIImage imageNamed:model.typeImageName];
    
    self.lbl.text = model.typeName;
    
}

- (void)awakeFromNib {
    // Initialization code
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

@end
