//
//  YYPlayTool.m
//  slide
//
//  Created by 吴洋洋 on 16/5/9.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//


#import "YYPlayTool.h"
#import "YYLocalMusicModel.h"
#import "MusicModel.h"


@interface YYPlayTool ()

@end

@implementation YYPlayTool
singleton_implementation(YYPlayTool)

//本地播放
- (void)preparePlayMusic:(YYLocalMusicModel *)model
{
    NSURL *url = [[NSBundle mainBundle] URLForResource:model.filename
        withExtension:nil];
    
    self.player = [[AVAudioPlayer alloc] initWithContentsOfURL:url error:nil];
    
    [self.player prepareToPlay];
}

- (void)play
{
    [self.player play];
}

- (void)pause
{
    [self.player pause];
}
@end
