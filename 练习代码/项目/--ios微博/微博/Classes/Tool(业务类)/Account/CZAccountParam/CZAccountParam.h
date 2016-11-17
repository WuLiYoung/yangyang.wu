//
//  CZAccountParam.h
//  微博
//
//  Created by 吴洋洋 on 16/2/23.
//  Copyright © 2016年 apple. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface CZAccountParam : NSObject

@property (nonatomic,copy) NSString *client_id;

@property (nonatomic,copy) NSString *client_secret;

@property (nonatomic,copy) NSString *grant_ype;

@property (nonatomic,copy) NSString *code;

@property (nonatomic,copy) NSString *redirect_uri;

@end
