//
//  CZAccount.m
//  微博
//
//  Created by 吴洋洋 on 16/2/21.
//  Copyright © 2016年 apple. All rights reserved.
//

#import "CZAccount.h"
#import "MJExtension.h"

@implementation CZAccount
MJCodingImplementation
+ (instancetype)accountWithDic:(NSDictionary *)dic
{
    CZAccount *account = [[self alloc] init];
    
    [account setValuesForKeysWithDictionary:dic];
    
    return account;
}

- (void)setExpires_in:(NSString *)expires_in
{
    _expires_in = expires_in;
    
    //计算过期时间
    _expires_date = [NSDate dateWithTimeIntervalSinceNow:[expires_in longLongValue]];
}

//归档时调用
//- (void)encodeWithCoder:(NSCoder *)aCoder
//{
//    [aCoder encodeObject:_access_token forKey:@"access_token"];
//    [aCoder encodeObject:_expires_in   forKey:@"expires_in"];
//    [aCoder encodeObject:_expires_date    forKey:@"expires_date"];
//    [aCoder encodeObject:_uid          forKey:@"uid"];
//}
//
//
//
////解档时调用
//- (instancetype)initWithCoder:(NSCoder *)aDecoder
//{
//    if (self = [super init]) {
//        
//        _access_token = [aDecoder decodeObjectForKey:@"access_token"];
//        _expires_in = [aDecoder decodeObjectForKey:@"expires_in"];
//        _expires_date = [aDecoder decodeObjectForKey:@"expires_date"];
//        _uid = [aDecoder decodeObjectForKey:@"uid"];
//    }
//    return self;
//}


@end
