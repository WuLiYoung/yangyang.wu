//
//  CZUserResultTool.m
//  微博
//
//  Created by 吴洋洋 on 16/2/23.
//  Copyright © 2016年 apple. All rights reserved.
//

#import "CZUserResultTool.h"

@implementation CZUserResultTool

- (int)messageCount
{
    return _cmt + _dm + _mention_cmt + _mention_status;
}


- (int)totalCount
{
    return self.messageCount + _status+ _follower;
}

@end
