//
//  YYPlayToolBar.h
//  slide
//
//  Created by 吴洋洋 on 16/5/8.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>

typedef enum {
    BtnTypePlay,     //播放
    BtnTypePause,    //暂停
    BtnTypePrevious, //上一首
    BtnTypeNext,     //下一首
    BtnTypePlayModel //播放模式
    
}BtnType;

@class YYLocalMusicModel,MusicModel,YYPlayToolBar;

@protocol YYPlayToolBarDelegate <NSObject>

//代理方法
- (void)playToolBar: (YYPlayToolBar *)toolBar btnType: (BtnType)btnType;

@end
@interface YYPlayToolBar : UIView
@property (weak, nonatomic) IBOutlet UIButton *playModelBtn;

@property (nonatomic,strong) YYLocalMusicModel *playingMusic;
@property (nonatomic,strong) MusicModel *playingMusicOL;



@property (nonatomic,assign,getter=isPlaying) BOOL playing;
@property (nonatomic,assign,getter=isRandom) BOOL random;

+ (instancetype)playToolBar;

@property (nonatomic,weak) id<YYPlayToolBarDelegate> myDelegate;


@end
