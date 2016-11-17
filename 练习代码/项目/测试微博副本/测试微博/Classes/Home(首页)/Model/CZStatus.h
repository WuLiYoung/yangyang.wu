//
//  CZStatus.h
//  微博
//
//  Created by 吴洋洋 on 16/2/21.
//  Copyright © 2016年 apple. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "CZUser.h"
#import "MJExtension.h"

/**
 user	object	微博作者的用户信息字段 详细
 retweeted_status	object	被转发的原微博信息字段，当该微博为转发微博时返回 详细
 pic_urls 配图数组
 */

@interface CZStatus : NSObject <MJKeyValue>

/**
 *  微博作者的用户信息字段 详细
 */
@property (nonatomic,strong) CZUser *user;

/**
 *  被转发的原微博信息字段
 */
@property (nonatomic,strong) CZStatus *retweeted_status;

/**
 *  转发微博的名字
 */
@property (nonatomic,strong) NSString *retweeted_name;


/**
 *  微博创建时间
 */
@property (nonatomic,copy) NSString *created_at;

/**
 *  字符串型的微博ID
 */
@property (nonatomic,copy) NSString *idstr;

/**
 *  微博信息内容
 */
@property (nonatomic,copy) NSString *text;

/**
 *  微博来源
 */
@property (nonatomic,copy) NSString *source;

/**
 *  转发数
 */
@property (nonatomic,assign) int reposts_count;

/**
 *  评论数
 */
@property (nonatomic,assign) int comments_count;

/**
 *  表态数（赞）
 */
@property (nonatomic,assign) int attitudes_count;

/**
 *  配图数组
 */
@property (nonatomic,strong) NSArray *pic_urls;


@end
