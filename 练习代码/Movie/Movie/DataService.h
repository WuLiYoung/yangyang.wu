//
//  DataService.h
//  Movie
//
//  Created by apple on 15/6/8.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface DataService : NSObject

+ (id)loadJsonDataWithName:(NSString *)jsonName;
@end
