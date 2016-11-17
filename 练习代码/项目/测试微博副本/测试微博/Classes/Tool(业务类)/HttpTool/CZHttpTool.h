//
//  CZHttpTool.h
//  微博
//
//  Created by 吴洋洋 on 16/2/22.
//  Copyright © 2016年 apple. All rights reserved.
//  处理网络请求

#import <Foundation/Foundation.h>

@interface CZHttpTool : NSObject

/**
 *  发送get 请求
    不需要返回值：网络数据会延迟，并不会马上返回
 */
+ (void)GET:(NSString *)URLString
                     parameters:(id)parameters
                        success:(void (^)(id responseObject))success
                        failure:(void (^)(NSError *error))failure;


@end
