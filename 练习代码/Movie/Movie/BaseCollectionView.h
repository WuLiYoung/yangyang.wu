//
//  BaseCollectionView.h
//  Movie
//
//  Created by apple on 15/6/15.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface BaseCollectionView : UICollectionView<UICollectionViewDataSource,UICollectionViewDelegateFlowLayout>

@property(nonatomic,retain)NSArray *movieList; //_movieList private

@property(nonatomic,assign)CGFloat width; //单元格宽度

@property(nonatomic,assign)NSInteger currentIndex;//当前页

@end
