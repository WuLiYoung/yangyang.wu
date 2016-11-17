//
//  MovieDetaiModel.m
//  Movie
//
//  Created by apple on 15/6/16.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "MovieDetaiModel.h"

@implementation MovieDetaiModel


- (void)setValue:(id)value forUndefinedKey:(NSString *)key{

    if ([key isEqualToString:@"release"]) {
        
        self.movieRelease = value;
    }


}
@end
