//
//  YYPlayToolOL.m
//  slide
//
//  Created by 吴洋洋 on 16/5/11.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYPlayToolOL.h"
#import "MusicModel.h"


@implementation YYPlayToolOL
singleton_implementation(YYPlayToolOL)
- (void)prepareToPlayWithMusic:(MusicModel *)model
{
    NSURL *url = [NSURL URLWithString:[model.url_list firstObject][@"url"]];
    
    self.playerItem = [AVPlayerItem playerItemWithURL:url];
    
    self.player  = [PlayerHelper sharePlayerHelper];
    
    [self.player.aPlayer replaceCurrentItemWithPlayerItem:_playerItem];
    [self.player.aPlayer play];
}

- (void)play
{
    [self.player.aPlayer play];
}

- (void)pause
{
    [self.player.aPlayer pause];
}

@end
