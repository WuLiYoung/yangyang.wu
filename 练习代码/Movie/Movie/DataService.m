//
//  DataService.m
//  Movie
//
//  Created by apple on 15/6/8.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "DataService.h"

@implementation DataService
+ (id)loadJsonDataWithName:(NSString *)jsonName {

    //1.读取Json文件
    NSString *filePath = [[NSBundle mainBundle] pathForResource:jsonName ofType:nil];
    //2.读取json内容
    NSData *newsData  = [NSData dataWithContentsOfFile:filePath];
    //3.Json解析
    id jsonData = [NSJSONSerialization JSONObjectWithData:newsData options:NSJSONReadingMutableContainers error:nil];

    return jsonData;
    
}

@end
