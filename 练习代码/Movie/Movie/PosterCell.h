//
//  PosterCell.h
//  Movie
//
//  Created by apple on 15/6/14.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Movie.h"
@interface PosterCell : UICollectionViewCell

@property(nonatomic,retain)Movie *movie;

//翻转

- (void)flipView;
@end
