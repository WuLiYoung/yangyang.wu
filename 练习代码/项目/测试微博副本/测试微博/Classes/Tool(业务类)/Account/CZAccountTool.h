//
//  CZAccountTool.h
//  微博
//
//  Created by 吴洋洋 on 16/2/21.
//  Copyright © 2016年 apple. All rights reserved.
//  专门处理账号保存

#import <Foundation/Foundation.h>

@class CZAccount;

@interface CZAccountTool : NSObject

+ (void)saveAccount: (CZAccount *)account;

+ (CZAccount *)account;

@end
