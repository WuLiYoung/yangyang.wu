//
//  NHSettingGroup.h
//  --ios彩票
//
//  Created by 吴洋洋 on 16/1/3.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface NHSettingGroup : NSObject

/**
 *  头部标题
 */
@property (nonatomic,copy) NSString *headerTitle;

/**
 *  尾部标题
 */
@property (nonatomic,copy) NSString *fooderTitle;


@property (nonatomic,strong) NSArray *items;


@end
