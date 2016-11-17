//
//  NHsettingCell.h
//  --ios彩票
//
//  Created by 吴洋洋 on 16/1/2.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>
@class NHSettingItem;

@interface NHsettingCell : UITableViewCell

+ (instancetype)tableView: (UITableView *)tableView;

@property (nonatomic,strong) NHSettingItem *item;


@end
