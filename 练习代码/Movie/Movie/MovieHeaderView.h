//
//  MovieHeaderView.h
//  Movie
//
//  Created by apple on 15/6/16.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "MovieDetaiModel.h"
@interface MovieHeaderView : UIView
@property (weak, nonatomic) IBOutlet UIImageView *movieImage;
@property (weak, nonatomic) IBOutlet UILabel *movieTitle;
@property (weak, nonatomic) IBOutlet UILabel *directorLable;
@property (weak, nonatomic) IBOutlet UILabel *actorLable;
@property (weak, nonatomic) IBOutlet UILabel *typeLable;
@property (weak, nonatomic) IBOutlet UILabel *yearLable;
@property (weak, nonatomic) IBOutlet UIScrollView *scrollView;

- (IBAction)playActin:(id)sender;
@property(nonatomic,retain)MovieDetaiModel *model;
@end
