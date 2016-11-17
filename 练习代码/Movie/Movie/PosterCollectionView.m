//
//  PosterCollectionView.m
//  Movie
//
//  Created by apple on 15/6/14.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "PosterCollectionView.h"
#import "PosterCell.h"

static NSString *identy = @"PosterCell";
@implementation PosterCollectionView

- (id)initWithFrame:(CGRect)frame collectionViewLayout:(UICollectionViewLayout *)layout{


    self = [super initWithFrame:frame collectionViewLayout:layout];
    
    if (self) {

       //注册单元格
        [self registerClass:[PosterCell class] forCellWithReuseIdentifier:identy];
    }
    return self;
}

#pragma mark -UICollectionViewDataSource

- (UICollectionViewCell *)collectionView:(UICollectionView *)collectionView cellForItemAtIndexPath:(NSIndexPath *)indexPath {

    PosterCell *cell = [collectionView dequeueReusableCellWithReuseIdentifier:identy forIndexPath:indexPath];
    
    //将数据交给单元格
    cell.movie = self.movieList[indexPath.row];
    return cell;
}

//点击单元格
- (void)collectionView:(UICollectionView *)collectionView didSelectItemAtIndexPath:(NSIndexPath *)indexPath{ 

    if (indexPath.row != self.currentIndex) { // 0
       
        //滚动单元格
        [self scrollToItemAtIndexPath:indexPath atScrollPosition:UICollectionViewScrollPositionCenteredHorizontally animated:YES];
        
        //更新当前页(触发KVO)
        self.currentIndex = indexPath.row;
        
    }else{
        
    //翻转单元格
    PosterCell *cell = (PosterCell *)[collectionView cellForItemAtIndexPath:indexPath];
    
    [cell flipView];
    }

}
@end
