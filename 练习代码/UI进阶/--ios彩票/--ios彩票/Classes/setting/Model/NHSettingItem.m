//
//  NHSetting.m
//  --ios彩票
//
//  Created by 吴洋洋 on 16/1/2.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "NHSettingItem.h"

@implementation NHSettingItem

- (instancetype)initWithIcon: (NSString *)icon title: (NSString *)title
{
    if (self = [super init]) {
        self.icon = icon;
        self.title = title;
    }
    return self;
}
+ (instancetype)itemWithIcon: (NSString *)icon title: (NSString *)title
{
    return [[self alloc] initWithIcon:icon title:title];
}

+ (instancetype)itemWithIcon: (NSString *)icon title: (NSString *)title vcClass: (Class)vcClass
{
    NHSettingItem *item = [NHSettingItem itemWithIcon:icon title:title];
    item.vcClass = vcClass;
    
    return item;
}

@end
