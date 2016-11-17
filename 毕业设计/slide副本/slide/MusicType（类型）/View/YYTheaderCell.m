//
//  YYTheaderCell.m
//  slide
//
//  Created by 吴洋洋 on 16/5/3.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYTheaderCell.h"
#import "UIImageView+WebCache.h"

@implementation YYTheaderCell

- (void)awakeFromNib {
    // Initialization code
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

- (void)setUserDict:(NSDictionary *)userDict
{
    [self.listBgkImage sd_setImageWithURL:[NSURL URLWithString:[userDict[@"pics"] firstObject]] placeholderImage:[UIImage imageNamed:@"default.jpg"]];
    [self.typeImage sd_setImageWithURL:[NSURL URLWithString:[userDict[@"pics"] firstObject]] placeholderImage:[UIImage imageNamed:@"default.jpg"]];
    self.desc.text = [userDict[@"nick_name"] stringByReplacingOccurrencesOfString:@"动听" withString:@"微乐"];
    self.songCount.text = [userDict[@"label"] stringByReplacingOccurrencesOfString:@"动听" withString:@"微乐"];
}

@end
