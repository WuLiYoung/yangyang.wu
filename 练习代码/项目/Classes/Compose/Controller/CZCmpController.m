//
//  CZCmpController.m
//  微博
//
//  Created by 吴洋洋 on 16/2/25.
//  Copyright © 2016年 apple. All rights reserved.
//

#import "CZCmpController.h"
#import "CZTextView.h"
#import "CZComposeToolBar.h"

@interface CZCmpController () <UITextViewDelegate>

@property (nonatomic,weak) CZTextView *textView;
@property (nonatomic,weak) CZComposeToolBar *toolBar;


@end

@implementation CZCmpController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    self.view.backgroundColor = [UIColor whiteColor];
    
    //设置导航条
    [self setUpNavigationBar];
    
    //设置placeholder
    [self setUpTextView];
    
    
    //设置toolbar
    [self setUpComposeToolBar];
    
    
     [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(keyboardFrameChange:) name:UIKeyboardWillChangeFrameNotification object:nil];
}

- (void)setUpComposeToolBar
{
    CGFloat h = 35;
    CGFloat y = self.view.height - h;
    
    CZComposeToolBar *toolBar = [[CZComposeToolBar alloc] initWithFrame:CGRectMake(0, y, self.view.width, h)];
    
    [self.view addSubview:toolBar];
    
   
}

#pragma mark - 键盘frame改变时调用
- (void)keyboardFrameChange:(NSNotification *)note
{
    // 获取键盘弹出的动画时间
    CGFloat durtion = [note.userInfo[UIKeyboardAnimationDurationUserInfoKey] floatValue];
    
    // 获取键盘的frame
    CGRect frame = [note.userInfo[UIKeyboardFrameEndUserInfoKey] CGRectValue];
    
    if (frame.origin.y == self.view.height) { // 没有弹出键盘
        [UIView animateWithDuration:durtion animations:^{
            
            _toolBar.transform =  CGAffineTransformIdentity;
        }];
    }else{ // 弹出键盘
        // 工具条往上移动258
        [UIView animateWithDuration:durtion animations:^{
            
            _toolBar.transform = CGAffineTransformMakeTranslation(0, -frame.size.height);
        }];
    }

}

#pragma mark - 添加textView
- (void)setUpTextView
{
    CZTextView *textView = [[CZTextView alloc] initWithFrame:self.view.bounds];
    _textView = textView;
    // 设置占位符
    textView.placeHolder = @"abc";
    textView.font = [UIFont systemFontOfSize:18];
    [self.view addSubview:textView];
    
    // 默认允许垂直方向拖拽
    textView.alwaysBounceVertical = YES;
    
    // 监听文本框的输入
    /**
     *  Observer:谁需要监听通知
     *  name：监听的通知的名称
     *  object：监听谁发送的通知，nil:表示谁发送我都监听
     *
     */
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(textChange) name:UITextViewTextDidChangeNotification object:nil];
    
    // 监听拖拽
    _textView.delegate = self;
}

#pragma mark - 开始拖拽的时候调用
- (void)scrollViewWillBeginDragging:(UIScrollView *)scrollView
{
    [self.view endEditing:YES];
}

- (void)textChange
{
    // 判断下textView有木有内容
    if (_textView.text.length) { // 有内容
        _textView.hidePlaceHolder = YES;
    }else{
        _textView.hidePlaceHolder = NO;
    }
}

- (void)viewDidAppear:(BOOL)animated
{
    [super viewDidAppear:animated];
    
    
    [_textView becomeFirstResponder];
    
}

- (void)dealloc
{
    [[NSNotificationCenter defaultCenter] removeObserver:self];
}
- (void)setUpNavigationBar
{
    self.title = @"发送微博";
    
    self.navigationItem.leftBarButtonItem = [[UIBarButtonItem alloc] initWithTitle:@"取消" style:UIBarButtonItemStylePlain target:self action:@selector(dismiss)];
    
    UIButton *btn = [UIButton buttonWithType:UIButtonTypeCustom];
    [btn setTitle:@"发送" forState:UIControlStateNormal];
    [btn setTitleColor:[UIColor orangeColor] forState:UIControlStateNormal];
    [btn setTitleColor:[UIColor lightGrayColor] forState:UIControlStateDisabled];
    
    [btn sizeToFit];
    
    UIBarButtonItem *rightItem = [[UIBarButtonItem alloc] initWithCustomView:btn];
    rightItem.enabled = NO;
    self.navigationItem.rightBarButtonItem = rightItem;
}

- (void)dismiss
{
    [self dismissViewControllerAnimated:YES completion:^{
        
    }];
}

- (void)send
{
    
}

@end
