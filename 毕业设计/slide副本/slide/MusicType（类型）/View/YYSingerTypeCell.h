//
//  YYSingerTypeCell.h
//  slide
//
//  Created by 吴洋洋 on 16/5/12.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>
@class YYSingerTypeModel;

@interface YYSingerTypeCell : UITableViewCell

@property (nonatomic,strong) YYSingerTypeModel *model;
@property (weak, nonatomic) IBOutlet UIImageView *faceImage;

@property (weak, nonatomic) IBOutlet UILabel *singerType;

@end
