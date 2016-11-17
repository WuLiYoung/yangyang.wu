//
//  Person.m
//  --iosNSCoding
//
//  Created by 吴洋洋 on 15/12/3.
//  Copyright © 2015年 吴洋洋. All rights reserved.
//

#import "Person.h"

@implementation Person
- (void)encodeWithCoder:(NSCoder *)aCoder
{
    //每个属性是 怎么存的
    [aCoder encodeObject:self.name forKey:@"name"];
    [aCoder encodeInt:self.age forKey:@"age"];
}

- (instancetype)initWithCoder:(NSCoder *)aDecoder
{
    //读取数据 设置每一个属性
    if (self = [super init]) {
        self.name = [aDecoder decodeObjectForKey:@"name"];
        self.age = [aDecoder decodeIntForKey:@"age"];
        
    }
    return self;
}
@end
