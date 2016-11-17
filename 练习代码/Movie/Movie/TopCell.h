//
//  TopCell.h
//  Movie
//
//  Created by apple on 15/6/12.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Movie.h"
#import "StarView.h"
@interface TopCell : UICollectionViewCell
@property (weak, nonatomic) IBOutlet UIImageView *mvoieImageView;

@property (weak, nonatomic) IBOutlet UILabel *tiltleLable;
@property (weak, nonatomic) IBOutlet StarView *starView;
@property (weak, nonatomic) IBOutlet UILabel *ratingLable;

@property (nonatomic,retain)Movie *movie;
@end
