//
//  Person.h
//  --iosNSCoding
//
//  Created by 吴洋洋 on 15/12/3.
//  Copyright © 2015年 吴洋洋. All rights reserved.
//

#import "Contact.h"

@interface Person : NSObject  <NSCoding>

@property (nonatomic,copy) NSString *name;
@property (nonatomic,assign) int age;

@end
