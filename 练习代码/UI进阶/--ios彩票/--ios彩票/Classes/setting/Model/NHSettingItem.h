//
//  NHSetting.h
//  --ios彩票
//
//  Created by 吴洋洋 on 16/1/2.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <Foundation/Foundation.h>

//自定义一个block
typedef void (^OpBlock)();

@interface NHSettingItem : NSObject

@property (nonatomic,copy) NSString *icon;
@property (nonatomic,copy) NSString *title;

/**
 *  控制器的类型
 */
@property (nonatomic,assign) Class vcClass;

/**
 *  存储一个特殊的block操作
    block用copy
 */
@property (nonatomic,copy)OpBlock operation;

- (instancetype)initWithIcon: (NSString *)icon title: (NSString *)title;
+ (instancetype)itemWithIcon: (NSString *)icon title: (NSString *)title;

+ (instancetype)itemWithIcon: (NSString *)icon title: (NSString *)title vcClass: (Class)vcClass;


@end
