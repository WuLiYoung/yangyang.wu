//
//  CZHttpTool.m
//  微博
//
//  Created by 吴洋洋 on 16/2/22.
//  Copyright © 2016年 apple. All rights reserved.
//

#import "CZHttpTool.h"
#import "AFNetworking.h"

@implementation CZHttpTool

+ (void)GET:(NSString *)URLString parameters:(id)parameters success:(void (^)(id))success failure:(void (^)(NSError *))failure
{
    //用AFN发送请求
    //创建请求管理者
    AFHTTPRequestOperationManager *mgr = [AFHTTPRequestOperationManager manager];
    
    [mgr GET:URLString parameters:parameters success:^(AFHTTPRequestOperation *operation, id responseObject) {
        
        //判断block是否有值
        if (success) {
            success(responseObject);
        }
        
    } failure:^(AFHTTPRequestOperation *operation, NSError *error) {
        
    }];
}

@end
