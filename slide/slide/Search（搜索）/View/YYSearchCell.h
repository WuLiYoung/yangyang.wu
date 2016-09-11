//
//  YYSearchCell.h
//  slide
//
//  Created by 吴洋洋 on 16/5/5.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>

@class MusicModel;

@interface YYSearchCell : UITableViewCell

@property (nonatomic,strong) MusicModel *model;


@property (weak, nonatomic) IBOutlet UILabel *songName;
@property (weak, nonatomic) IBOutlet UILabel *singerName;
@property (weak, nonatomic) IBOutlet UILabel *favoriteCount;
@end
