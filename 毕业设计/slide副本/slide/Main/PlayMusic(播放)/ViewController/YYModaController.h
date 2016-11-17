//
//  YYModaController.h
//  slide
//
//  Created by 吴洋洋 on 16/5/10.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "MusicModel.h"

@interface YYModaController : UIViewController
@property (weak, nonatomic) IBOutlet UIImageView *centerImage;
@property (weak, nonatomic) IBOutlet UILabel *singerName;
@property (weak, nonatomic) IBOutlet UIImageView *bgImage;
@property (weak, nonatomic) IBOutlet UILabel *songName;
@property (nonatomic,strong) MusicModel *playingMusicModel;


@property (nonatomic,assign) NSInteger musicIndex;//当前索引



@property (nonatomic,strong) UINavigationController *navigation;



@end
