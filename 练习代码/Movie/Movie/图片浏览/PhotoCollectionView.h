//
//  PhotoCollectionView.h
//  Movie
//
//  Created by apple on 15/6/10.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface PhotoCollectionView : UICollectionView<UICollectionViewDataSource,UICollectionViewDelegateFlowLayout>

@property(nonatomic,retain)NSArray *images;
@end
