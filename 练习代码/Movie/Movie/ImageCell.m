//
//  ImageCell.m
//  Movie
//
//  Created by apple on 15/6/9.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "ImageCell.h"
#import "UIImageView+WebCache.h"
@implementation ImageCell{

    UIImageView *imageView;

}

- (void)awakeFromNib{


}

//重写
- (id)initWithFrame:(CGRect)frame{

    self = [super initWithFrame:frame];
    if (self) {
        
        imageView = [[UIImageView alloc] initWithFrame:CGRectZero];
        imageView.backgroundColor = [UIColor redColor];
        [self.contentView addSubview:imageView];
        
        //设置圆角的半径
        imageView.layer.cornerRadius = 5;
        //边框宽度
        imageView.layer.borderWidth = 1;
        
        //imageView设置圆角比较特殊
        imageView.layer.masksToBounds = YES;
        
        //CGColorRef 边框颜色
        imageView.layer.borderColor = [UIColor whiteColor].CGColor;
        
    }
    return self;

}

- (void)setImage:(Image *)image{


    _image = image;
    [self setNeedsLayout];
}

- (void)layoutSubviews{

    [super layoutSubviews];
    
    //不要在此创建子视图
    imageView.frame = self.bounds;
    [imageView sd_setImageWithURL:[NSURL URLWithString:_image.image]];
    

}
@end
