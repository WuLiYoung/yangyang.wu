//
//  Movie.m
//  Movie
//
//  Created by apple on 15/6/5.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "Movie.h"

@implementation Movie


- (void)setValue:(id)value forUndefinedKey:(NSString *)key{

    
    NSLog(@"%@,%@",key,value);
    
    if ([key isEqualToString:@"rating"]) {
       
        
        self.average = [value[@"average"] floatValue];
    }
    

}
@end
