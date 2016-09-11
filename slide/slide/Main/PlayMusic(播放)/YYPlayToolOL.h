//
//  YYPlayToolOL.h
//  slide
//
//  Created by 吴洋洋 on 16/5/11.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <AVFoundation/AVFoundation.h>
#import "Singleton.h"
#import "PlayerHelper.h"
@class MusicModel;

@interface YYPlayToolOL : NSObject
singleton_interface(YYPlayToolOL)
@property (nonatomic,strong) AVPlayerItem *playerItem;
@property (nonatomic,strong) PlayerHelper *player;


- (void)prepareToPlayWithMusic: (MusicModel *)model;

- (void)play;

- (void)pause;

@end
