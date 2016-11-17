//
//  CHMusicTool.m
//  --ios音乐播放器
//
//  Created by 吴洋洋 on 15/12/22.
//  Copyright © 2015年 吴洋洋. All rights reserved.
//

#import "CHMusicTool.h"
#import "CHMusic.h"
#import <MediaPlayer/MediaPlayer.h>

@interface CHMusicTool ()





@end

@implementation CHMusicTool
singleton_implementation(CHMusicTool)

//准备播放
- (void)prepareToPlayerWithMusic:(CHMusic *)music
{
    
    //1.根据url获取到文件名
    NSString *fileName = [music.url lastPathComponent];
    
    
    
    //指定路径
    NSString *mp3 = @"/Users/wuyangyang/Desktop/练习代码/多线程网络/--ios音乐播放器/--ios音乐播放器/MP3";
    
    NSString *path = [mp3 stringByAppendingPathComponent:fileName];
    
    
    NSURL *musicUrl = [NSURL fileURLWithPath:path];
    //NSURL *musicUrlLocation = [[NSBundle mainBundle] URLForResource:music.filename withExtension:nil];
    self.player = [[AVAudioPlayer alloc] initWithContentsOfURL:musicUrl error:nil];
    
    
    
    //准备
    [self.player prepareToPlay];
    
    //设置锁屏音乐信息
    NSMutableDictionary *info           = [NSMutableDictionary dictionary];

    //设置专辑名称
    info[MPMediaItemPropertyAlbumTitle] = @"好听的歌";

    //设置歌手
    info[MPMediaItemPropertyArtist]     = music.singer;

    //设置歌曲名
    info[MPMediaItemPropertyTitle]      = music.name;

    //设置专辑的图片
    UIImage *img                     = [UIImage imageNamed:music.icon];
    MPMediaItemArtwork *artWork      = [[MPMediaItemArtwork alloc] initWithImage:img];
    info[MPMediaItemPropertyArtwork] = artWork;
    
    //设置时间
    info[MPMediaItemPropertyPlaybackDuration]             = @(self.player.duration);

    [MPNowPlayingInfoCenter defaultCenter].nowPlayingInfo = info;
    
    
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
