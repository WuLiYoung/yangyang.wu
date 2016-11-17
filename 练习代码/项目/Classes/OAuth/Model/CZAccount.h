//
//  CZAccount.h
//  微博
//
//  Created by 吴洋洋 on 16/2/21.
//  Copyright © 2016年 apple. All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 *       "access_token" = "2.00P8C8ME0khHsH74f9128492ngXGRC";
 *        "expires_in" = 157679999;
 *        "remind_in" = 157679999;
 *        uid = 3848291593;
 */

@interface CZAccount : NSObject <NSCoding>

//获取数据的访问牌
@property (nonatomic,copy) NSString *access_token;

//账号的有效期
@property (nonatomic,copy) NSString *expires_in;

//账号的有效期
@property (nonatomic,copy) NSString *remind_in;

//用户的唯一标识
@property (nonatomic,copy) NSString *uid;

/**
 *  用户昵称
 */
@property (nonatomic,copy) NSString *name;

//过期时间 = 当前时间 + 有效期
@property (nonatomic,strong) NSDate *expires_date;

+ (instancetype)accountWithDic: (NSDictionary *)dic;

@end
