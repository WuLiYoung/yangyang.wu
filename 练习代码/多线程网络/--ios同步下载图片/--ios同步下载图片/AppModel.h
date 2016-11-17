//
//  appModel.h
//  --ios同步下载图片
//
//  Created by 吴洋洋 on 16/1/6.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface AppModel : NSObject

@property (nonatomic,copy) NSString *name;

@property (nonatomic,copy) NSString *icon;

@property (nonatomic,copy) NSString *download;



- (instancetype)initWithDic: (NSDictionary *)dic;
+ (instancetype)appWithDic: (NSDictionary *)dic;

+ (NSArray *)apps;

@end
