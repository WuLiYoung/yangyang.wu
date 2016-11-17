//
//  CZUserTool.m
//  微博
//
//  Created by 吴洋洋 on 16/2/23.
//  Copyright © 2016年 apple. All rights reserved.
//

#import "CZUserTool.h"
#import "CZUserParamTool.h"
#import "MJExtension.h"
#import "CZAccountTool.h"
#import "CZAccount.h"
#import "CZHttpTool.h"
#import "CZUserResultTool.h"
#import "CZUser.h"

@implementation CZUserTool

+ (void)unreadWithSuccess:(void (^)(CZUserResultTool *))success failure:(void (^)(NSError *))failure
{
    //创建参数模型
    CZUserParamTool *param = [CZUserParamTool param];
    param.uid = [CZAccountTool account].uid;
    
    //用CZHttpTool发送请求
    [CZHttpTool GET:@"https://rm.api.weibo.com/2/remind/unread_count.json" parameters:param.mj_keyValues success:^(id responseObject) {
        
        //字典转模型
        CZUserResultTool *result = [CZUserResultTool mj_objectWithKeyValues:responseObject];
        if (success) {
            success(result);
        }
        
    } failure:^(NSError *error) {
        
        if (failure) {
            failure(error);
        }
        
    }];
}

+ (void)userInfoWithSuccess:(void (^)(CZUser *))success failure:(void (^)(NSError *))failure
{
    //创建参数模型
    CZUserParamTool *param = [CZUserParamTool param];
    param.uid = [CZAccountTool account].uid;
    
    //用HttpTool发送请求
    [CZHttpTool GET:@"https://api.weibo.com/2/users/show.json" parameters:param.mj_keyValues success:^(id responseObject) {
        
        //字典转模型
       CZUser *user =  [CZUser mj_objectWithKeyValues:responseObject];
        
        if (success) {
            success(user);
        }
        
    } failure:^(NSError *error) {
        
        if (failure) {
            failure(error);
        }
        
    }];
}

@end
