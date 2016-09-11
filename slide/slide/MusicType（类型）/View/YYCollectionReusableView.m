//
//  YYCollectionReusableView.m
//  slide
//
//  Created by 吴洋洋 on 16/5/11.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYCollectionReusableView.h"

@implementation YYCollectionReusableView

- (instancetype)initWithFrame:(CGRect)frame {
    if (self = [super initWithFrame:frame]) {
        [self addSubview:self.lblTitle];
    }
    return self;
}
- (UILabel *)lblTitle {
    if (!_lblTitle) {
        self.lblTitle = [[UILabel alloc] initWithFrame:CGRectMake(10, 5, self.frame.size.width, 35)];
        _lblTitle.font = [UIFont systemFontOfSize:18];
    }
    return _lblTitle;
}

@end
