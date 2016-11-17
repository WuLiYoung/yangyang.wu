//
//  CHRecommendUserCell.m
//  --ios百思不得其姐
//
//  Created by 吴洋洋 on 16/4/3.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHRecommendUserCell.h"
#import "CHRecommendUser.h"
#import "UIImageView+WebCache.h"

@interface CHRecommendUserCell ()
@property (weak, nonatomic) IBOutlet UIImageView *userIcon;
@property (weak, nonatomic) IBOutlet UILabel *screenName;
@property (weak, nonatomic) IBOutlet UILabel *fansCount;

@end
@implementation CHRecommendUserCell

- (void)awakeFromNib {
    // Initialization code
}

- (void)setUser:(CHRecommendUser *)user
{
    _user = user;
    
    [self.userIcon sd_setImageWithURL:[NSURL URLWithString:user.header] placeholderImage:[UIImage imageNamed:@"defaultUserIcon"]];
    self.screenName.text = user.screen_name;
    
    NSString *num = nil;
    if (user.fans_count < 10000) {
        num = [NSString stringWithFormat:@"%zd人关注",user.fans_count];
        
    }else{
        
        num = [NSString stringWithFormat:@"%.1f万人关注",user.fans_count / 10000.0];
    }
    
    self.fansCount.text = num;
    
}

@end
