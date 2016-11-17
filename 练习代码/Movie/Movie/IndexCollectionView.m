//
//  IndexCollectionView.m
//  Movie
//
//  Created by apple on 15/6/15.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "IndexCollectionView.h"
#import "IndexCell.h"
static NSString *identy = @"IndexCell";
@implementation IndexCollectionView

- (id)initWithFrame:(CGRect)frame collectionViewLayout:(UICollectionViewLayout *)layout{

    self = [super initWithFrame:frame collectionViewLayout:layout];
    
    if (self) {
        
        //注册单元格
        [self registerClass:[IndexCell class] forCellWithReuseIdentifier:identy];
        
    }

    return self;
}

- (UICollectionViewCell *)collectionView:(UICollectionView *)collectionView cellForItemAtIndexPath:(NSIndexPath *)indexPath {
    
    IndexCell *cell =  [collectionView dequeueReusableCellWithReuseIdentifier:identy forIndexPath:indexPath];
    
    cell.movie = self.movieList[indexPath.row];
    return cell;

}


//点击单元格
- (void)collectionView:(UICollectionView *)collectionView didSelectItemAtIndexPath:(NSIndexPath *)indexPath{
    
    if (indexPath.row != self.currentIndex) {
        
        //滚动单元格
        [self scrollToItemAtIndexPath:indexPath atScrollPosition:UICollectionViewScrollPositionCenteredHorizontally animated:YES];
    
        //更新当前页(触发KVO)
        self.currentIndex = indexPath.row;
        
    }
}

@end
