//
//  News.m
//  Movie
//
//  Created by apple on 15/6/8.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "News.h"

@implementation News


//如果字典中存在model中没有的属性,则此方法会被调用.此方法可以是空的实现,防止崩溃
- (void)setValue:(id)value forUndefinedKey:(NSString *)key{

    NSLog(@"key%@ : value%@ ",key,value);
    
    if ([key isEqualToString:@"id"]) {
        
        self.newId = [value integerValue];
    }

}
@end
