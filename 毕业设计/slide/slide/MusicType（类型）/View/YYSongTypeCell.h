//
//  YYSongTypeCell.h
//  slide
//
//  Created by 吴洋洋 on 16/5/11.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>
@class YYSongTypeModel;
@interface YYSongTypeCell : UICollectionViewCell
@property (weak, nonatomic) IBOutlet UIImageView *typeImage;
@property (weak, nonatomic) IBOutlet UILabel *title;


@property (nonatomic,strong) YYSongTypeModel *model;


@end
