//
//  CZDownloadMusic.h
//  --ios音乐播放器
//
//  Created by 吴洋洋 on 16/3/4.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface CHDownloadMusic : NSObject

//+ (instancetype)downloadWithDic: (NSDictionary *)dic;

/**
 *  下载路径
 */
@property (nonatomic,copy) NSString *url;


/**
 * 歌曲名字
 */
@property(nonatomic,copy)NSString *name;

/**
 * 歌手名字
 */
@property(nonatomic,copy)NSString *singer;

/**
 * 专辑头像
 */
@property (nonatomic,copy) NSString *icon;

/**
 * 歌手头像
 */
@property (nonatomic,copy) NSString *singerIcon;

/**
 * 文件名
 */
@property (nonatomic,copy) NSString *filename;

@end
