//
//  CHRecommendType.h
//  --ios百思不得其姐
//
//  Created by 吴洋洋 on 16/4/3.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//  左边的类型模型

#import <Foundation/Foundation.h>

@interface CHRecommendType : NSObject

/**
 *
 返回值字段	字段类型	字段说明
 total	int	左侧标签总数
 list	array	标签数组
 name	string	标签名称
 count	string	此标签下的用户数
 id	string	标签id
 */

/**
 *  标签id
 */
@property (nonatomic,assign) NSInteger id;

/**
 *  此标签下的用户数
 */
@property (nonatomic,assign) NSInteger count;

/**
 *  标签名称
 */
@property (nonatomic,copy) NSString *name;


@property (nonatomic,strong) NSMutableArray *users;

/**
 *  总数
 */
@property (nonatomic,assign) NSInteger  total;

/**
 *  当前的页码
 */
@property (nonatomic,assign) NSInteger currentPage ;


@end
