//
//  CZBaseParam.h
//  微博
//
//  Created by 吴洋洋 on 16/2/23.
//  Copyright © 2016年 apple. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface CZBaseParam : NSObject

//获取数据的访问牌
@property (nonatomic,copy) NSString *access_token;

+ (instancetype)param;

@end
