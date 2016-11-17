//
//  CHMusicCellTableViewCell.h
//  --ios音乐播放器
//
//  Created by 吴洋洋 on 15/12/22.
//  Copyright © 2015年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>
@class CHMusic;

@interface CHMusicCell : UITableViewCell

+ (instancetype)musicCellWithTableView: (UITableView *)tableView;

@property (nonatomic,strong) CHMusic *musicScr;

@end
