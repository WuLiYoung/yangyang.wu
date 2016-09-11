//
//  YYPlayMusicController.h
//  slide
//
//  Created by 吴洋洋 on 16/5/8.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface YYPlayMusicController : UIViewController

@property (nonatomic,strong) UINavigationController *navigation;
@property (weak, nonatomic) IBOutlet UIView *bottomView;
@property (weak, nonatomic) IBOutlet UILabel *singerName;
@property (weak, nonatomic) IBOutlet UIImageView *centerImage;
@property (nonatomic,assign) NSInteger musicIndex;
@end
