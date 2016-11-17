//
//  PhotoCollectionView.m
//  Movie
//
//  Created by apple on 15/6/10.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "PhotoCollectionView.h"
#import "PhotoCell.h"
static NSString *identy = @"PhotoCell";
@implementation PhotoCollectionView

- (id)initWithFrame:(CGRect)frame collectionViewLayout:(UICollectionViewLayout *)layout{

    self = [super initWithFrame:frame collectionViewLayout:layout];
    if (self) {
        
        //指定数据源,代理
        self.dataSource = self;
        self.delegate = self;
        
        //注册单元格
        [self registerClass:[PhotoCell class] forCellWithReuseIdentifier:identy];
        
        //分页效果
        self.pagingEnabled = YES;
    }
    return self;

}
//- (void)setImages:(NSArray *)images{
//
//
//    _images = images;
//    [self reloadData];
//
//}

#pragma mark UICollectionViewDataSource
- (NSInteger)collectionView:(UICollectionView *)collectionView numberOfItemsInSection:(NSInteger)section {
    
    return _images.count;
    
}
- (UICollectionViewCell *)collectionView:(UICollectionView *)collectionView cellForItemAtIndexPath:(NSIndexPath *)indexPath {
    
    PhotoCell *cell = [collectionView dequeueReusableCellWithReuseIdentifier:identy forIndexPath:indexPath];
    //将图片交给单元格
    cell.imageUrl = _images[indexPath.row];
    
    return cell;
}
//结束显示某个单元格
- (void)collectionView:(UICollectionView *)collectionView didEndDisplayingCell:(UICollectionViewCell *)cell forItemAtIndexPath:(NSIndexPath *)indexPath{

    //获取到单元格上的滑动视图
    UIScrollView *view = (UIScrollView *)[cell viewWithTag:2015];
    //还原缩放倍数
    view.zoomScale = 1;

}

@end
