//
//  YYMusicListController.h
//  slide
//
//  Created by 吴洋洋 on 16/5/3.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface YYMusicListController : UITableViewController
@property (nonatomic,strong) UINavigationController *navigation;

@property (nonatomic,copy) NSString *navTitile;

@property (nonatomic, copy) NSString *msg_id;

@property (nonatomic, copy) NSString *from; //标识从哪个界面push来的
@property (nonatomic, copy) NSString *pic_url;//用来接收从排行传过来的图片

@property (nonatomic,strong) void(^myBlock)(NSString *songName,NSString *singerName);

@end
