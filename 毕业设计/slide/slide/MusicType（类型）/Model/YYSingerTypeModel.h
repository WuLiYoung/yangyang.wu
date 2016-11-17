//
//  YYSingerTypeModel.h
//  slide
//
//  Created by 吴洋洋 on 16/5/12.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface YYSingerTypeModel : NSObject
@property (nonatomic, strong) NSNumber *id;
@property (nonatomic, copy) NSString *title, *details;
@property (nonatomic, copy) NSString *pic_url, *time;
@property (nonatomic, strong) NSNumber *count;
@end
