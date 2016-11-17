//
//  PosterDetailView.h
//  Movie
//
//  Created by apple on 15/6/14.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Movie.h"
#import "StarView.h"
@interface PosterDetailView : UIView
@property (weak, nonatomic) IBOutlet UIImageView *movieImageView;
@property (weak, nonatomic) IBOutlet UILabel *titleLable;
@property (weak, nonatomic) IBOutlet UILabel *yearLable;
@property (weak, nonatomic) IBOutlet UILabel *ratingLabel;
@property (weak, nonatomic) IBOutlet StarView *starView;

@property (weak, nonatomic) IBOutlet UILabel *engTitleLable;

@property(nonatomic,retain)Movie *movie;
@end
