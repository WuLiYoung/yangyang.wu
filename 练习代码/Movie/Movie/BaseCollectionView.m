//
//  BaseCollectionView.m
//  Movie
//
//  Created by apple on 15/6/15.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "BaseCollectionView.h"

@implementation BaseCollectionView

/*
 
    1.大海报与小海报内容相似,不同点为单元格大小不同.
    2.相同点:单元格个数,分页效果
    3.将共性内容抽出,定义到BaseCollectionView中,让大海报与小海报分别继承,如返回单元格的个数,分页的效果
    4.将单元格宽度属性抽出,让外部定义单元格宽度
 
 */
- (id)initWithFrame:(CGRect)frame collectionViewLayout:(UICollectionViewLayout *)layout{
    
    self = [super initWithFrame:frame collectionViewLayout:layout];
    
    if (self) {
        
        //代理
        self.dataSource = self;
        self.delegate = self;
        
        //让子类注册自己的单元格
        
    }
    
    return self;
}

//单元格个数
- (NSInteger)collectionView:(UICollectionView *)collectionView numberOfItemsInSection:(NSInteger)section {
    
    return _movieList.count;
    
}

//创建单元格
- (UICollectionViewCell *)collectionView:(UICollectionView *)collectionView cellForItemAtIndexPath:(NSIndexPath *)indexPath {
    
   
    //让子类重写此方法.打海报与小海报单元格不同
    return nil;
    
}

//单元格大小
- (CGSize)collectionView:(UICollectionView *)collectionView layout:(UICollectionViewLayout *)collectionViewLayout sizeForItemAtIndexPath:(NSIndexPath *)indexPath{
    
    
    return CGSizeMake(self.width, self.height);
    
}
//单元格相对于屏幕边缘的间隙
- (UIEdgeInsets)collectionView:(UICollectionView *)collectionView layout:(UICollectionViewLayout *)collectionViewLayout insetForSectionAtIndex:(NSInteger)section{
    
    
    return UIEdgeInsetsMake(0,(kScreenWidth - self.width) / 2, 0, (kScreenWidth - self.width) / 2);
    
}

//手指将要离开视图时,自定义分页效果
- (void)scrollViewWillEndDragging:(UIScrollView *)scrollView withVelocity:(CGPoint)velocity targetContentOffset:(inout CGPoint *)targetContentOffset{
    
    /*
     velocity:速度
     targetContentOffset:目标偏移量
     */
    
    //单元格宽度
    CGFloat itmeWidth = self.width;
    
    CGFloat x = targetContentOffset ->x;
    //计算最终会停留在第几页
    NSInteger index = (x + itmeWidth / 2) / itmeWidth;
    
    //改变最终偏移量
    targetContentOffset -> x = index * itmeWidth;
    
    //容错处理
    if (index < 0) {
        
        index = 0;
        
    }else if(index >= self.movieList.count){
    
        index = self.movieList.count - 1;
    }
    
    //更新当前页 触发KVO
    self.currentIndex = index;
}

@end
