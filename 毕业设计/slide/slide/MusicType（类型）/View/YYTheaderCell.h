//
//  YYTheaderCell.h
//  slide
//
//  Created by 吴洋洋 on 16/5/3.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface YYTheaderCell : UITableViewCell
@property (weak, nonatomic) IBOutlet UIImageView *typeImage;
@property (weak, nonatomic) IBOutlet UILabel *desc;
@property (weak, nonatomic) IBOutlet UILabel *songCount;
@property (weak, nonatomic) IBOutlet UIImageView *listBgkImage;

@property (nonatomic, strong) NSDictionary *userDict;
@end
