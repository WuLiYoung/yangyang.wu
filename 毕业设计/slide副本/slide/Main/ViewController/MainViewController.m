//
//  MainViewController.m
//  WeiYueMusic
//
//  Created by lanou3g on 15/7/10.
//  Copyright (c) 2015年 Ashen. All rights reserved.
//

#import "MainViewController.h"
#import "SwipeView.h"
#import "AppDelegate.h"
#import "UINavigationController+FDFullscreenPopGesture.h"

#import "YYMusicTypeController.h"
#import "SettingController.h"
#import "YYSearchController.h"
#import "YYtestController.h"
#import "YYLocalMusicController.h"


@interface MainViewController ()<SwipeViewDataSource, SwipeViewDelegate>

@property (weak, nonatomic) IBOutlet UIView *moveView;
@property (weak, nonatomic) IBOutlet SwipeView *swipeView;

@property (nonatomic, strong) NSMutableArray *items;

@end

@implementation MainViewController

- (void)dealloc {
    //释放代理
    _swipeView.delegate = nil;
    _swipeView.dataSource = nil;
}



- (void)viewDidLoad {
    [super viewDidLoad];
    self.automaticallyAdjustsScrollViewInsets = NO;
    self.navigationController.navigationBarHidden = YES;
//    self.navigationController.hidesBarsOnSwipe = YES; //滑动隐藏
    self.fd_prefersNavigationBarHidden = YES;
    _swipeView.pagingEnabled = YES;
    _swipeView.delegate = self;
    _swipeView.dataSource = self;
    _swipeView.wrapEnabled = YES;
    [self setupView];
    [_swipeView reloadData];
     
}
#pragma mark - 配置swipeView视图

//设置子控制器
- (void)setupView {
    //乐库
    YYMusicTypeController *typeVC = [[YYMusicTypeController alloc] init];
    typeVC.navigation = self.navigationController;
    
    //搜索
    YYtestController *searchVC = [self.storyboard instantiateViewControllerWithIdentifier:@"sbTest"];
    searchVC.navigation = self.navigationController;
    
    //本地
    YYLocalMusicController *localMusic = [self.storyboard instantiateViewControllerWithIdentifier:@"sbLocalMusic"];
    localMusic.navigation = self.navigationController;
    
    //设置
    SettingController *settingVC = [[SettingController  alloc] init];
    
    self.items = [NSMutableArray arrayWithObjects:typeVC,  searchVC, localMusic, settingVC, nil];
    
}


#pragma mark - button action
- (IBAction)btnSearch:(id)sender {
    _swipeView.currentItemIndex = 2;
}
- (IBAction)btnMine:(id)sender {
    _swipeView.currentItemIndex = 3;
}
- (IBAction)btnHot:(id)sender {
    _swipeView.currentItemIndex = 1;
}
- (IBAction)btnMusic:(id)sender {
    _swipeView.currentItemIndex = 0;
}



#pragma mark -
#pragma mark iCarousel methods

- (NSInteger)numberOfItemsInSwipeView:(SwipeView *)swipeView
{
    //return the total number of items in the carousel
    return _items.count;
}

- (UIView *)swipeView:(SwipeView *)swipeView viewForItemAtIndex:(NSInteger)index reusingView:(UIView *)view
{
    return [_items[index] view];
}

- (CGSize)swipeViewItemSize:(SwipeView *)swipeView
{
    return self.swipeView.bounds.size;
}

- (void)swipeViewDidScroll:(SwipeView *)swipeView {
    
    for (int i = 0; i < _items.count; i++) {
        UIButton *btn = (UIButton *)[self.view viewWithTag:100 + i];
        [btn setTitleColor:[UIColor grayColor] forState:UIControlStateNormal];
    }
    switch (swipeView.currentItemIndex) {
        case 0:{
            [self updateLineViewFrame:0];
            break;
        }
        case 1:{
            [self updateLineViewFrame:1];
            break;
        }
        case 2: {
            [self updateLineViewFrame:2];
            break;
        }
        case 3: {
            [self updateLineViewFrame:3];
            break;
        }
        default:
            break;
    }
}


- (void)updateLineViewFrame:(NSInteger)index {
    CGRect frame = _moveView.frame;
    UIButton *btn = (UIButton *)[self.view viewWithTag:100 + index];
    [btn setTitleColor:[UIColor redColor] forState:UIControlStateNormal];
    frame.origin.x = index * ([UIScreen mainScreen].bounds.size.width / 4) + btn.frame.size.width / 3 / 2 + 1;
    _moveView.frame = frame;
}



@end
