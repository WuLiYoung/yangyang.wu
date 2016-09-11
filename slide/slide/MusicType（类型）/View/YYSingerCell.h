//
//  YYSingerCell.h
//  slide
//
//  Created by 吴洋洋 on 16/5/11.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>
@class YYSingerModel;
@interface YYSingerCell : UITableViewCell

@property (nonatomic,strong) YYSingerModel *model;

@property (weak, nonatomic) IBOutlet UIImageView *singerIcon;
@property (weak, nonatomic) IBOutlet UILabel *singerName;

@end
