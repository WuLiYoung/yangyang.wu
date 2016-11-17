//
//  CHMusicTool.h
//  --ios音乐播放器
//
//  Created by 吴洋洋 on 15/12/22.
//  Copyright © 2015年 吴洋洋. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <AVFoundation/AVFoundation.h>
#import "Singleton.h"

@class CHMusic;

@interface CHMusicTool : NSObject
singleton_interface(CHMusicTool)

@property (nonatomic,strong) AVAudioPlayer *player;

- (void)prepareToPlayerWithMusic: (CHMusic *)music;

- (void)play;
- (void)pause;

@end
