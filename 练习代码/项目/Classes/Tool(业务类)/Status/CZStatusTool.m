//
//  CZStatusTool.m
//  微博
//
//  Created by 吴洋洋 on 16/2/22.
//  Copyright © 2016年 apple. All rights reserved.
//

#import "CZStatusTool.h"
#import "CZStatus.h"
#import "CZAccount.h"
#import "CZAccountTool.h"
#import "CZHttpTool.h"

@implementation CZStatusTool

+ (void)newStatusWithSinceID:(NSString *)sinceID success:(void (^)(NSArray *))success failure:(void (^)(NSError *))failure
{
    //创建参数字典
    NSMutableDictionary *parame = [NSMutableDictionary dictionary];
    
    parame[@"access_token"] = [CZAccountTool account].access_token;
    
    if (sinceID) {
        parame[@"since_id"] = sinceID;
    }
    
    [CZHttpTool GET:@"https://api.weibo.com/2/statuses/friends_timeline.json" parameters:parame success:^(id responseObject) {//CZHttpTool请求成功时调用
       
        
        //获取微博的数据，转成模型
        //首先获取数组
        NSArray *dicArray = responseObject[@"statuses"];
        
        //把字典数组转换成模型数组
        NSMutableArray *statuses = [CZStatus mj_objectArrayWithKeyValuesArray:dicArray];
        
        if (success) {
            success(statuses);
        }

        

    } failure:^(NSError *error) {
        
        if (failure) {
            failure(error);
        }
        
    }];
}

+ (void)morePreStatusWithMaxID:(NSString *)maxID success:(void (^)(NSArray *))success failure:(void (^)(NSError *))failure
{
    //创建参数字典
    NSMutableDictionary *parame = [NSMutableDictionary dictionary];
    
    parame[@"access_token"] = [CZAccountTool account].access_token;
    
    if (maxID) {
        parame[@"max_id"] = maxID;
    }
    
    [CZHttpTool GET:@"https://api.weibo.com/2/statuses/friends_timeline.json" parameters:parame success:^(id responseObject) {//CZHttpTool请求成功时调用
        
        
        //获取微博的数据，转成模型
        //首先获取数组
        NSArray *dicArray = responseObject[@"statuses"];
        
        //把字典数组转换成模型数组
        NSMutableArray *statuses = [CZStatus mj_objectArrayWithKeyValuesArray:dicArray];
        
        if (success) {
            success(statuses);
        }
        
    } failure:^(NSError *error) {
        
        if (failure) {
            failure(error);
        }
        
    }];
}

@end
