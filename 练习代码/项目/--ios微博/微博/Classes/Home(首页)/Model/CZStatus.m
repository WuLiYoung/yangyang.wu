//
//  CZStatus.m
//  微博
//
//  Created by 吴洋洋 on 16/2/21.
//  Copyright © 2016年 apple. All rights reserved.
//

#import "CZStatus.h"
#import "CZPhoto.h"
#import "NSDate+MJ.h"

@implementation CZStatus

+ (NSDictionary *)mj_objectClassInArray
{
    return @{@"pic_urls" : [CZPhoto class]};
}


//重写get方法
- (NSString *)created_at
{
    //字符串转换成NSDate
    
    //创建日期格式
    NSDateFormatter *fmt = [[NSDateFormatter alloc] init];
    
    fmt.dateFormat = @"EEE MMM d HH:mm:ss Z yyyy";
    
    //本地格式化
    fmt.locale = [NSLocale localeWithLocaleIdentifier:@"en_us"];
    
    NSDate *created_at = [fmt dateFromString:_created_at];
    
    if ([created_at isThisYear]) {//今年
        
        if ([created_at isToday]) {//今天
            
            //计算微博发布的时间和当前时间的差距
            NSDateComponents *cmt = [created_at deltaWithNow];
            
            if (cmt.hour >= 1) {
                return [NSString stringWithFormat:@"%ld小时之前",cmt.hour];
            }else if (cmt.minute >= 1){
            
                 return [NSString stringWithFormat:@"%ld分钟之前",cmt.minute];
                
            }else{
            
                return @"刚刚";
                
            }
            
        }else if ([created_at isYesterday]){//昨天
        
            fmt.dateFormat = @"昨天 HH:mm";
            return [fmt stringFromDate:created_at];
            
        }else{
        
            fmt.dateFormat = @"MM-dd HH:mm";
            return [fmt stringFromDate:created_at];
        }
        
    }else{//不是今年
        
        fmt.dateFormat = @"yyyy-MM-dd HH:mm";
        return [fmt stringFromDate:created_at];
        
    }
    return _created_at;
}

//重写source的set方法
- (void)setSource:(NSString *)source
{
    //abc>jljlj<
    NSRange range = [source rangeOfString:@">"];
    source = [source substringFromIndex:range.length + range.location];
    
    range = [source rangeOfString:@"<"];
    source = [source substringToIndex:range.location];
    source = [NSString stringWithFormat:@"来自%@",source];
    
    _source = source;
}

- (void)setRetweeted_status:(CZStatus *)retweeted_status
{
    _retweeted_status = retweeted_status;
    
    _retweeted_name = [NSString stringWithFormat:@"@%@",retweeted_status.user.name];
}

@end
