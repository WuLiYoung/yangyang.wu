//
//  CHRecommendUser.h
//  --ios百思不得其姐
//
//  Created by 吴洋洋 on 16/4/3.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface CHRecommendUser : NSObject

/**
 *  uid	string	推荐的用户id
 fans_count	string	所推荐用户的被关注量
 is_follow	int	是否是我关注的用户
 gender	int	性别,0为男，1为女
 screen_name	string	所推荐的用户昵称
 header	string	所推荐的用户的头像url
 introduction	string	用户描述
 tiezi_count	int	所发表的贴子数量
 total	int	一共加载了多少个推荐用户
 next_page	int	下一页的页码
 total_page	int	总共页码数
 */

/**
 *  所推荐的用户的头像url
 */
@property (nonatomic,strong) NSString *header;

/**
 *  所推荐的用户昵称
 */
@property (nonatomic,strong) NSString *screen_name;

/**
 *  所推荐用户的被关注量
 */
@property (nonatomic,assign) NSInteger fans_count;


@end
