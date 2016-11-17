//
//  CZStatusTool.h
//  微博
//
//  Created by 吴洋洋 on 16/2/22.
//  Copyright © 2016年 apple. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface CZStatusTool : NSObject

/**
 *  请求最新的微博数据
 *
 *  @param sinceID 返回比这个更大的微博数据
 *  @param success 成功时调用这个block，传statuses
 *  @param failure 失败时调用这个block，错误传给外界
 */
+ (void)newStatusWithSinceID:(NSString *)sinceID success:(void(^)(NSArray *statuses))success failure:(void(^)(NSError *error))failure;

/**
 *  请求更多的微博数据
 *
 *  @param maxID   返回比这个id更小的微博数据
 *  @param success 成功时调用这个block，传statuses
 *  @param failure 失败时调用这个block，错误传给外界
 */
+ (void)morePreStatusWithMaxID:(NSString *)maxID success:(void(^)(NSArray *statuses))success failure:(void(^)(NSError *error))failure;

@end
