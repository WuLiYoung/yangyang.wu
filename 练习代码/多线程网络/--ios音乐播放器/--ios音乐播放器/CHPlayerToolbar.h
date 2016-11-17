//
//  CHPlayerToolbar.h
//  --ios音乐播放器
//
//  Created by 吴洋洋 on 15/12/22.
//  Copyright © 2015年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>

typedef enum
{
    BtnTypePaly,      //播放
    BtnTypePause,     //暂停
    BtnTypePrevious,  //上一首
    BtnTypeNext       //下一首
}BtnType;

@class CHMusic,CHPlayerToolbar;
@protocol CHPlayerToolbarDelegate <NSObject>

@optional
- (void)playerToolBar: (CHPlayerToolbar *)toolBar btnClickWithType: (BtnType)btntype;

@end

@interface CHPlayerToolbar : UIView

+ (instancetype)playerToolBar;

@property (nonatomic,assign,getter=isplaying) BOOL playing;


//当前要播放的音乐
@property (nonatomic,strong) CHMusic *playingMusic;

@property (nonatomic,weak) id<CHPlayerToolbarDelegate> delegate;


@end
