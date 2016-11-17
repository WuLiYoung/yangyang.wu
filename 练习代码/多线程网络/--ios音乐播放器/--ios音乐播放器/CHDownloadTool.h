//
//  CHDownloadTool.h
//  --ios音乐播放器
//
//  Created by 吴洋洋 on 16/3/10.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Singleton.h"

@class CHDownloadMusic;

@interface CHDownloadTool : NSObject
singleton_interface(CHDownloadTool)

- (void)downloadMusicWithUrl: (CHDownloadMusic *)DLMusic;

@end
