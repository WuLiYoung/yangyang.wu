//
//  YYNewSongCell.h
//  slide
//
//  Created by 吴洋洋 on 16/5/3.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>
@class YYNewSongModel;
@interface YYNewSongCell : UICollectionViewCell
@property (weak, nonatomic) IBOutlet UIImageView *albumImageView;
@property (weak, nonatomic) IBOutlet UILabel *albumSongName;
@property (weak, nonatomic) IBOutlet UILabel *albumSingerName;

@property (nonatomic,strong) YYNewSongModel *model;


@end
