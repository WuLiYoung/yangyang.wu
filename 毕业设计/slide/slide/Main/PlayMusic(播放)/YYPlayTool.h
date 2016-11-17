//
//  YYPlayTool.h
//  slide
//
//  Created by 吴洋洋 on 16/5/9.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//
#import <AVFoundation/AVFoundation.h>
#import <Foundation/Foundation.h>

#import "Singleton.h"

@class YYLocalMusicModel;
@interface YYPlayTool : NSObject
singleton_interface(YYPlayTool)

@property (nonatomic,strong) AVAudioPlayer *player;
//@property (nonatomic,strong) AVPlayerItem *playerItem;
//@property (nonatomic,strong) PlayerHelper *PH;


//- (void)prepareToPlayWithMusic: (MusicModel *)model;

- (void)preparePlayMusic: (YYLocalMusicModel *)model;

- (void)play;

- (void)pause;

@end
