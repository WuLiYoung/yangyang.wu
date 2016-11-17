//
//  PhotoCell.m
//  Movie
//
//  Created by apple on 15/6/10.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "PhotoCell.h"
#import "PhotoScrollView.h"
@implementation PhotoCell{


    PhotoScrollView *scrollView;
}

- (id)initWithFrame:(CGRect)frame{

    self = [super initWithFrame:frame];
    if (self) {
        
        //创建子视图
        [self _createSubViewes];
    }
    return self;

}
//重写set方法
- (void)setImageUrl:(NSString *)imageUrl{

//    _imageUrl = imageUrl;
    //讲数据传给滑动视图
    scrollView.imageUrl = imageUrl;

}

- (void)_createSubViewes{
    
    //子类化滑动视图
    scrollView = [[PhotoScrollView alloc] initWithFrame:self.bounds];
    scrollView.tag = 2015;
    //此时还没有数据
//    scrollView.imageUrl = _imageUrl; 错误
    
    [self.contentView addSubview:scrollView];


}

@end
