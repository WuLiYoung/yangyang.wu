//
//  CZUserTool.h
//  微博
//
//  Created by 吴洋洋 on 16/2/23.
//  Copyright © 2016年 apple. All rights reserved.
//

#import <Foundation/Foundation.h>

@class CZUserResultTool,CZUser;
@interface CZUserTool : NSObject

/**
 *  请求用户的未读数
 *
 *  @param success 请求成功时回调
 *  @param failure 请求失败时回调
 */
+ (void)unreadWithSuccess: (void(^)(CZUserResultTool *result))success failure: (void(^)(NSError *error))failure;

/**
 *  请求用户的信息
 *
 *  @param success 请求成功时回调
 *  @param failure 请求失败时回调
 */
+ (void)userInfoWithSuccess: (void(^)(CZUser *user))success failure: (void(^)(NSError *error))failure;

@end
