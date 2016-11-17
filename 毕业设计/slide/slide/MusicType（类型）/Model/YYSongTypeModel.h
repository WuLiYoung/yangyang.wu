//
//  YYSongType.h
//  slide
//
//  Created by 吴洋洋 on 16/5/11.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface YYSongTypeModel : NSObject
@property (nonatomic, strong) NSNumber *songlist_id;
@property (nonatomic, copy) NSString *songlist_name;
@property (nonatomic, copy) NSString *details;
@property (nonatomic, copy) NSString *parentname; //分区名
@property (nonatomic, copy) NSString *large_pic_url, *small_pic_url, *pic_url_240_200;
@end
