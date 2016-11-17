//
//  MovieCell.h
//  Movie
//
//  Created by apple on 15/6/5.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Movie.h"
#import "StarView.h"
@interface MovieCell : UITableViewCell
@property (weak, nonatomic) IBOutlet UIImageView *movieImage;
@property (weak, nonatomic) IBOutlet UILabel *yearLable;
@property (weak, nonatomic) IBOutlet UILabel *ratingLable;

@property (weak, nonatomic) IBOutlet UILabel *movieTitleLable;

@property (weak, nonatomic) IBOutlet StarView *starView;
@property (nonatomic,retain)Movie *movie; //绑定的数据
@end
