//
//  CZUserResultTool.h
//  微博
//
//  Created by 吴洋洋 on 16/2/23.
//  Copyright © 2016年 apple. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface CZUserResultTool : NSObject

/**
 *  微博未读数
 */
@property (nonatomic,assign) int status;

/**
 *  新粉丝数
 */
@property (nonatomic,assign) int follower;

/**
 *  新评论数
 */
@property (nonatomic,assign) int cmt;

/**
 *  新私信数
 */
@property (nonatomic,assign) int dm;

/**
 *  提及我的微博数
 */
@property (nonatomic,assign) int mention_status;

/**
 *  提及我的评论数
 */
@property (nonatomic,assign) int mention_cmt;

//信息总数
- (int)messageCount;

//所有未读数总数
- (int)totalCount;

@end
