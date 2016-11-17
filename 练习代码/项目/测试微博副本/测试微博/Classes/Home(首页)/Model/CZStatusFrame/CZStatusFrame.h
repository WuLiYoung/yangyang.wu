//
//  CZStatusFrame.h
//  微博
//
//  Created by 吴洋洋 on 16/2/24.
//  Copyright © 2016年 apple. All rights reserved.
//

#import <UIKit/UIKit.h>

@class CZStatus;
@interface CZStatusFrame : UIView

/**
 *  微博数据
 */
@property (nonatomic,strong) CZStatus *status;

//原创微博的frame
@property (nonatomic,assign) CGRect oringinalViewFrame;

/***************原创微博的子控件frame***************/
//头像frame
@property (nonatomic,assign) CGRect oringinalIconFrame;

//昵称frame
@property (nonatomic,assign) CGRect oringinalNameFrame;

//VIPframe
@property (nonatomic,assign) CGRect oringinalVIPFrame;

//时间frame
@property (nonatomic,assign) CGRect oringinalTimeFrame;

//来源frame
@property (nonatomic,assign) CGRect oringinalSourceFrame;

//正文frame
@property (nonatomic,assign) CGRect oringinalTextFrame;

//原创微博的配图
@property (nonatomic,assign) CGRect oringinalphotoFrame;

/**
 *  转发微博
 */
@property (nonatomic,assign) CGRect retweetViewFrame;

/***************转发微博的子控件frame***************/
//昵称frame
@property (nonatomic,assign) CGRect retweetNameFrame;

//正文frame
@property (nonatomic,assign) CGRect retweetTextFrame;

//转发微博的配图
@property (nonatomic,assign) CGRect retweetphotoFrame;

//工具条frame
@property (nonatomic,assign) CGRect toolBarFrame;

//返回cell高度
@property (nonatomic,assign) CGFloat cellHeight;


@end
