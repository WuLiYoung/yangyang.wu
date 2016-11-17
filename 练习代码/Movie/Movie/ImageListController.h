//
//  ImageListController.h
//  Movie
//
//  Created by apple on 15/6/9.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface ImageListController : UIViewController<UICollectionViewDataSource,UICollectionViewDelegateFlowLayout>{


    UICollectionView *_collectionView;
}
@property(nonatomic,retain)NSMutableArray *imageList;
@end
