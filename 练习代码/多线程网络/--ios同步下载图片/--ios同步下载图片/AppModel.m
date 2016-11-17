//
//  appModel.m
//  --ios同步下载图片
//
//  Created by 吴洋洋 on 16/1/6.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "AppModel.h"

@implementation AppModel

- (instancetype)initWithDic:(NSDictionary *)dic
{
    if (self = [super init]) {
        [self setValuesForKeysWithDictionary:dic];
    }
    return self;
}

+(instancetype)appWithDic:(NSDictionary *)dic
{
    return [[self alloc] initWithDic:dic];
}

+(NSArray *)apps 
{
    //加载plist
    NSString *path = [[NSBundle mainBundle] pathForResource:@"apps" ofType:@"plist"];
    
    NSArray *dicArray = [NSArray arrayWithContentsOfFile:path];
    
    NSMutableArray *tempArray = [NSMutableArray array];
    
    for (NSDictionary *dic in dicArray) {
        AppModel *app = [AppModel appWithDic:dic];
        
        [tempArray addObject:app];
        
    }
    return tempArray;
}

@end
