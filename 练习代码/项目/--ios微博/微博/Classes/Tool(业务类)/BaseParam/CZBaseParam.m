//
//  CZBaseParam.m
//  微博
//
//  Created by 吴洋洋 on 16/2/23.
//  Copyright © 2016年 apple. All rights reserved.
//

#import "CZBaseParam.h"
#import "CZAccount.h"
#import "CZAccountTool.h"

@implementation CZBaseParam

+(instancetype)param
{
    CZBaseParam *param = [[self alloc] init];
    
    param.access_token = [CZAccountTool account].access_token;
    
    return param;
}

@end
