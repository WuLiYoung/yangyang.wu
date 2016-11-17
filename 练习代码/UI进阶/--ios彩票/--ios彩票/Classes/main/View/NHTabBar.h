//
//  NHTabBar.h
//  --ios彩票
//
//  Created by 吴洋洋 on 15/12/31.
//  Copyright © 2015年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>
@class NHTabBar;

@protocol NHTabBarDelegate <NSObject>

- (void)tabBar: (NHTabBar *)tabBar didselectedFrom: (NSInteger)from to: (NSInteger)to;

@end

@interface NHTabBar : UIView

/**
 *  传图片进来，内部就会创建一个按钮
 *
 *  @param nolImg 普通图片
 *  @param selImg 选中状态图片
 */
- (void)addTabBarWithNolImg: (NSString *)nolImg andselImg: (NSString *)selImg;

@property (nonatomic,weak) id<NHTabBarDelegate> delegate;


@end

//自定义UIButton
@interface NHTabBarBtn : UIButton

@end
