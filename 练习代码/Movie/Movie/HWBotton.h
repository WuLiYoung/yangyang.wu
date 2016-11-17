//
//  HWBotton.h
//  Movie
//
//  Created by apple on 15/6/3.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface HWBotton : UIControl{


    UIImageView *imgView;
    UILabel *lable;
}
//自定义初始化方法

- (id)initWithFrame:(CGRect)frame withImage:(UIImage *)image withTitle:(NSString *)title;
@end
