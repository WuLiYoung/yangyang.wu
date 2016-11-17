//
//  Common.h
//  Movie
//
//  Created by apple on 15/6/5.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#ifndef Movie_Common_h
#define Movie_Common_h

#define kScreenWidth [UIScreen mainScreen].bounds.size.width
#define kScreenHeight [UIScreen mainScreen].bounds.size.height
#define kTabbarHeight 49
#define kNavHeight 64



#define Top250 @"top250.json"


//Xcode5 -->PCH文件,一些常用的头文件,可以导入到PCH中,以后就不需要在其它文件中导入
//Xcode6 以后将PCH文件取消,但仍可以手动创建
//设置PCH文件 1.build setting 中搜索 prefix  2.prefix Header中添加 ./项目名/PCH文件名

//新闻类型
enum NewsType{
    
    kWordType,
    kImageType,
    kVideoType
    
};

#endif
