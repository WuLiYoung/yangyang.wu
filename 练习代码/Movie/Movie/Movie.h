//
//  Movie.h
//  Movie
//
//  Created by apple on 15/6/5.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Movie : NSObject

@property (nonatomic,copy)NSString *title; //存储电影标题

@property (nonatomic,assign)float average; //评分

@property (nonatomic,retain)NSDictionary *images; //图片

@property (nonatomic,copy)NSString *year;

@property (nonatomic,copy)NSString *original_title;//英文标题



@end
