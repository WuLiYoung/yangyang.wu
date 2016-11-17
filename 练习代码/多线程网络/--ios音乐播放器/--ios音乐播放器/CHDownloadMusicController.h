//
//  CHDownloadMusicController.h
//  --ios音乐播放器
//
//  Created by 吴洋洋 on 16/3/4.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface CHDownloadMusicController : UITableViewController

@property (nonatomic,strong) void(^myBlock)(NSDictionary *dic);


@end
