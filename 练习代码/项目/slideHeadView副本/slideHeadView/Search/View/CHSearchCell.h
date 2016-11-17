//
//  CHSearchCell.h
//  slideHeadView
//
//  Created by 吴洋洋 on 16/4/28.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>

@class CHMusicModel;
@interface CHSearchCell : UITableViewCell

@property (nonatomic,strong) CHMusicModel *model;

@property (weak, nonatomic) IBOutlet UILabel *songName;

@end
