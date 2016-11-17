//
//  CZFeatureCell.h
//  微博
//
//  Created by 吴洋洋 on 16/2/19.
//  Copyright © 2016年 apple. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface CZFeatureCell : UICollectionViewCell

@property (nonatomic,strong) UIImage *image;

// 判断是否是最后一页
- (void)setIndexPath:(NSIndexPath *)indexPath count:(int)count;

@end
