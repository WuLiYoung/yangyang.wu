//
//  CHLeftCell.m
//  --ios音乐播放器
//
//  Created by 吴洋洋 on 16/4/14.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#define CHRGBColor(r, g, b) [UIColor colorWithRed:(r)/255.0 green:(g)/255.0 blue:(b)/255.0 alpha:1.0]

#import "CHLeftCell.h"
#import "CHMF.h"

@interface CHLeftCell ()
@property (weak, nonatomic) IBOutlet UIView *selctView;
@property (weak, nonatomic) IBOutlet UILabel *showType;


@end

@implementation CHLeftCell

- (void)awakeFromNib {
    // Initialization code
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    self.selctView.hidden = !selected;
    
//    self.textLabel.textColor = selected?CHRGBColor(219, 21, 26):CHRGBColor(78, 78, 78);
}

- (void)setMF:(CHMF *)MF
{
    _MF = MF;
    
    self.showType.text = MF.type;
}

@end
