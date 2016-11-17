//
//  CHMusicTypeCell.m
//  slideHeadView
//
//  Created by 吴洋洋 on 16/4/26.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHMusicTypeCell.h"
#import "CHMusicTypeModel.h"

@interface CHMusicTypeCell ()
@property (weak, nonatomic) IBOutlet UILabel *musicTypeName;
@property (weak, nonatomic) IBOutlet UIImageView *musicTypeImage;

@end

@implementation CHMusicTypeCell

- (void)setModel:(CHMusicTypeModel *)model
{
    _model = model;
    
    self.musicTypeImage.image = [UIImage imageNamed:model.typeImageName];
    self.musicTypeName.text = model.typeName;
}

- (void)awakeFromNib {
    // Initialization code
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

@end
