//
//  NHTabBar.m
//  --ios彩票
//
//  Created by 吴洋洋 on 15/12/31.
//  Copyright © 2015年 吴洋洋. All rights reserved.
//

#import "NHTabBar.h"



@interface NHTabBar ()

//当前选中的按钮
@property (nonatomic,weak) UIButton *selectedBtn;


@end

@implementation NHTabBar

/**
 *  自定义控件
    1. 初始化的方法，添加子控件
    2. layoutSubViews 布局子控件的frame
 */


//-(instancetype)init{
//}

//当调用[[UIView alloc] initWithFrame]时被调用
//-(instancetype)initWithFrame:(CGRect)frame
//{
//}

//调用控件的创建从xib/storyboard的时候被调用
//-(instancetype)initWithCoder:(NSCoder *)aDecoder
//{
//}

-(instancetype)initWithFrame:(CGRect)frame
{
    
    if (self = [super initWithFrame:frame]) {
        //初始化按钮
        //[self setupBtn];
    }
    return self;
}

- (void)addTabBarWithNolImg:(NSString *)nolImg andselImg:(NSString *)selImg
{
    UIButton *btn = [NHTabBarBtn buttonWithType:UIButtonTypeCustom];
    [btn setBackgroundImage:[UIImage imageNamed:nolImg] forState:UIControlStateNormal];
    [btn setBackgroundImage:[UIImage imageNamed:selImg] forState:UIControlStateSelected];

    //监听事件
    [btn addTarget:self action:@selector(btnClick:) forControlEvents:UIControlEventTouchDown];
    //绑定tag
    btn.tag = self.subviews.count;
    
    [self addSubview:btn];
    
    if (btn.tag == 0) {
        [self btnClick:btn];
    }

}

//-(void)setupBtn
//{
//    //自定义tabbar，添加5个按钮
//    for (NSInteger i = 0; i < 5; i++) {
//        UIButton *btn = [UIButton buttonWithType:UIButtonTypeCustom];
//        
//        NSString *imagenol = [NSString stringWithFormat:@"TabBar%ld",i+1];
//        NSString *imagehet = [NSString stringWithFormat:@"TabBar%ldSel",i+1];
//        
//        
//        [btn setBackgroundImage:[UIImage imageNamed:imagenol] forState:UIControlStateNormal];
//        [btn setBackgroundImage:[UIImage imageNamed:imagehet] forState:UIControlStateSelected];
//        
//        //监听事件
//        [btn addTarget:self action:@selector(btnClick:) forControlEvents:UIControlEventTouchUpInside];
//        //绑定tag
//        btn.tag = i;
//        
//        [self addSubview:btn];
//        
//        if (i == 0) {
//            btn.selected = YES;
//            self.selectedBtn = btn;
//        }
//    
//    }
//}

//布局子控件
- (void)layoutSubviews
{
    [super layoutSubviews];
    //按钮的大小设置
    NSInteger count = self.subviews.count;

    CGFloat btnW    = self.bounds.size.width / count;
    CGFloat btnH    = self.bounds.size.height;

//    for (NSInteger i = 0; i < 5; i++) {
//        UIButton *btn = self.subviews[i];
//
//        //设置按钮的frame
//        btn.frame = CGRectMake(btnW * i,0,btnW,btnH);
//        
//   
//    }
      for (UIButton *btn in self.subviews) {
        btn.frame = CGRectMake(btnW * btn.tag,0,btnW,btnH);
    }
    
}
#pragma mark - 按钮的监听
- (void)btnClick: (UIButton *)btn
{
    //一点击就通知代理
    if ([self.delegate respondsToSelector:@selector(tabBar:didselectedFrom:to:)]) {
        [self.delegate tabBar:self didselectedFrom:self.selectedBtn.tag to:btn.tag];
    }
    
    //取消之前的选中
    self.selectedBtn.selected = NO;

    //选中按钮
    btn.selected     = YES;
    self.selectedBtn = btn;

}

@end

@implementation NHTabBarBtn

//图片高亮时会调用这个方法
-(void)setHighlighted:(BOOL)highlighted
{
    //只要不调用父类方法，就不会高亮状态
    //[super setHighlighted:highlighted];
    NSLog(@"%s",__func__);
}

@end

