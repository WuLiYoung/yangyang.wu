//
//  CHRecommendTypeCell.m
//  --ios百思不得其姐
//
//  Created by 吴洋洋 on 16/4/3.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHRecommendTypeCell.h"

@interface CHRecommendTypeCell ()
@property (weak, nonatomic) IBOutlet UIView *selctID;



@end

@implementation CHRecommendTypeCell

- (void)awakeFromNib {
    self.backgroundColor = CHRGBColor(244, 244, 244);
//    self.textLabel.textColor = CHRGBColor(78, 78, 78);
//    self.textLabel.highlightedTextColor = CHRGBColor(219, 21, 26);
//    UIView *bg = [[UIView alloc] init];
//    bg.backgroundColor = [UIColor clearColor];
//    
//    self.selectedBackgroundView = bg;

}



- (void)setType:(CHRecommendType *)type
{
    _type = type;
    
    self.textLabel.text = type.name;
}

- (void)layoutSubviews
{
    [super layoutSubviews];
    
    self.textLabel.y = 2;
    self.textLabel.height = self.contentView.height - 2 * self.textLabel.y;
    
}

-(void)setSelected:(BOOL)selected animated:(BOOL)animated
{
    [super setSelected:selected animated:animated];
    
    self.selctID.hidden = !selected;
    
    self.textLabel.textColor = selected?CHRGBColor(219, 21, 26):CHRGBColor(78, 78, 78);
}

@end
