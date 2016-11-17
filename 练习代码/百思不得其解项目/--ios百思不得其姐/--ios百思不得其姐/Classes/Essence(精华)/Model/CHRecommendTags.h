//
//  CHRecommendTags.h
//  --ios百思不得其姐
//
//  Created by 吴洋洋 on 16/4/5.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface CHRecommendTags : NSObject

/**
 *
 返回值字段	字段类型	字段说明
 is_sub	int	是否含有子标签
 theme_id	string	此标签的id
 theme_name	string	标签名称
 sub_number	string	此标签的订阅量
 is_default	int	是否是默认的推荐标签
 image_list	string	推荐标签的图片url地址
 */

/**
*  推荐标签的图片url地址
*/
@property (nonatomic,copy) NSString *image_list;

/**
 *  标签名称
 */
@property (nonatomic,copy) NSString *theme_name;

/**
 *  此标签的订阅量
 */
@property (nonatomic,assign) NSInteger sub_number;

@end
