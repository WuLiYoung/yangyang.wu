//
//  HWBotton.m
//  Movie
//
//  Created by apple on 15/6/3.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "HWBotton.h"
@implementation HWBotton

- (id)initWithFrame:(CGRect)frame withImage:(UIImage *)image withTitle:(NSString *)title {

    self = [super initWithFrame:frame];
    
    if (self) {
        
        //创建子视图
        imgView = [[UIImageView alloc] initWithFrame:CGRectZero];
        //等比例拉伸视图
        imgView.contentMode = UIViewContentModeScaleAspectFit;
        imgView.image = image;
        [self addSubview:imgView];
        
        lable = [[UILabel alloc] initWithFrame:CGRectZero];
        lable.text = title;
        lable.textColor = [UIColor whiteColor];
        lable.font = [UIFont systemFontOfSize:11];
        lable.textAlignment = NSTextAlignmentCenter;
        [self addSubview:lable];
        
    }
    
    return self;

}

//布局子视图
- (void)layoutSubviews{
    [super layoutSubviews];
    
    imgView.frame = CGRectMake((self.frame.size.width - 20) / 2, 5, 20, 20);
    lable.frame = CGRectMake(0, CGRectGetMaxY(imgView.frame), self.frame.size.width, 20);


}

@end
