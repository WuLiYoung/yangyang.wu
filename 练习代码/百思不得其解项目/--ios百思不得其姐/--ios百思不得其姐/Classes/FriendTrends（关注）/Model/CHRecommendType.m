//
//  CHRecommendType.m
//  --ios百思不得其姐
//
//  Created by 吴洋洋 on 16/4/3.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHRecommendType.h"

@implementation CHRecommendType

- (NSMutableArray *)users
{
    if (_users == nil) {
        _users = [NSMutableArray array];
    }
    return _users;
}

@end
