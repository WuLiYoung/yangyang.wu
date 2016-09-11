//
//  YYLocalMusicModel.h
//  slide
//
//  Created by 吴洋洋 on 16/5/8.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface YYLocalMusicModel : NSObject
/**
 * 歌曲名字
 */
@property(nonatomic,copy)NSString *songName;
/**
 * 本地音乐文件名
 */
@property(nonatomic,copy)NSString *filename;

/**
 * 歌手名字
 */
@property(nonatomic,copy)NSString *singer;

/**
 * 歌手相片
 */
@property(nonatomic,copy)NSString *singerIcon;

/**
 * 专辑图片
 */
@property(nonatomic,copy)NSString *icon;


@property (nonatomic,copy) NSString *url;
@end
