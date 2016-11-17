//
//  CHTagCell.m
//  --ios百思不得其姐
//
//  Created by 吴洋洋 on 16/4/5.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHTagCell.h"
#import "CHRecommendTags.h"
#import "UIImageView+WebCache.h"

@interface CHTagCell ()

@property (weak, nonatomic) IBOutlet UIImageView *tagImageView;
@property (weak, nonatomic) IBOutlet UILabel *nameLabel;
@property (weak, nonatomic) IBOutlet UILabel *numLabel;


@end

@implementation CHTagCell

- (void)awakeFromNib {
    // Initialization code
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

}

- (void)setRecommendTag:(CHRecommendTags *)recommendTag
{
    _recommendTag = recommendTag;
    
    [self.tagImageView sd_setImageWithURL:[NSURL URLWithString:recommendTag.image_list] placeholderImage:[UIImage imageNamed:@"defaultUserIcon"]];
    self.nameLabel.text = recommendTag.theme_name;
    
    NSString *num = nil;
    if (recommendTag.sub_number < 10000) {
        num = [NSString stringWithFormat:@"%zd人订阅",recommendTag.sub_number];

    }else{
    
        num = [NSString stringWithFormat:@"%.1ld万人订阅",recommendTag.sub_number / 10000];
    }
    
    self.numLabel.text = num;
}

- (void)setFrame:(CGRect)frame
{
    frame.origin.x = 5;
    frame.size.width -= 2 * frame.origin.x;
    frame.size.height -=1;
    
    [super setFrame:frame];
}

@end
