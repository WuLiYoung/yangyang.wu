//
//  News.h
//  Movie
//
//  Created by apple on 15/6/8.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import <Foundation/Foundation.h>
/*
 
 {
 "id" : 1491537,
 "type" : 0,
 "image" : "http://img31.mtime.cn/mg/2012/06/28/110832.94975548.jpg",
 "title" : "＂权力的游戏＂第三季新动向",
 "summary" : "权力的游戏,冰与火之歌,动态"
 }
 
 
 */
@interface News : NSObject
@property (nonatomic,assign)NSInteger newId;
@property (nonatomic,copy)NSString *title;
@property (nonatomic,copy)NSString *image;
@property (nonatomic,copy)NSString *summary;
@property (nonatomic,assign)NSInteger type; //新闻类型


@end
