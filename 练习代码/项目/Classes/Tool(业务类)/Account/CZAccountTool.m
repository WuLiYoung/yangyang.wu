//
//  CZAccountTool.m
//  微博
//
//  Created by 吴洋洋 on 16/2/21.
//  Copyright © 2016年 apple. All rights reserved.
//  专门处理账号保存

#define CZAccountFileName [[NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES) lastObject] stringByAppendingString:@"account.data"]

#import "CZAccountTool.h"
#import "CZAccount.h"

@implementation CZAccountTool
static CZAccount *_account;

+ (void)saveAccount:(CZAccount *)account
{
    //保存信息
    [NSKeyedArchiver archiveRootObject:account toFile:CZAccountFileName];
    
}

+ (CZAccount *)account
{
    if (_account == nil) {
        
        _account = [NSKeyedUnarchiver unarchiveObjectWithFile:CZAccountFileName];
        
        //判断账号是否过期
        if ([[NSDate date] compare:_account.expires_date] != NSOrderedAscending) {
            return nil;
        }
    }
    

    
    return _account;
}

@end
