//
//  YYBottomView.h
//  slide
//
//  Created by 吴洋洋 on 16/5/10.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import <UIKit/UIKit.h>

typedef enum {
    BtnTypePlay,
    BtnTypePause
}BtnType;
@class YYBottomView;
@protocol YYBottomViewDelegate <NSObject>

- (void)bottomPlayBar: (YYBottomView *)bottomPlayBar btnType: (BtnType)btnType;

@end

@interface YYBottomView : UIView

+ (instancetype)bottomView;
@property (weak, nonatomic) IBOutlet UIImageView *headImage;
@property (weak, nonatomic) IBOutlet UILabel *songName;
@property (weak, nonatomic) IBOutlet UILabel *singerName;
@property (weak, nonatomic) IBOutlet UIImageView *showPlayingImage;

@property (nonatomic,assign,getter=isPlaying) BOOL playing;

//代理属性
@property (nonatomic,weak) id<YYBottomViewDelegate> myDelegate;


@end
