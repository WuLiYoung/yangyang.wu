//
//  DMCell.h
//  --ios音乐播放器
//
//  Created by 吴洋洋 on 16/3/4.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "MDRadialProgressView.h"
#import "MDRadialProgressTheme.h"
#import "MDRadialProgressView.h"

@class CHDownloadMusic;


@interface DMCell : UITableViewCell

@property (weak, nonatomic) IBOutlet UIButton *btn;


@property (nonatomic,strong) CHDownloadMusic *dm;

+ (instancetype)musicDownCellWithTableView:(UITableView *)tableView;

@end
