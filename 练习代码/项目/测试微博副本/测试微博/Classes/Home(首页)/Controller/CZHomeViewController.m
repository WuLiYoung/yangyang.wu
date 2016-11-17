//
//  CZHomeViewController.m
//  传智微博
//
//  Created by apple on 15-3-5.
//  Copyright (c) 2015年 apple. All rights reserved.
//

#import "CZHomeViewController.h"

#import "UIBarButtonItem+Item.h"
#import "CZTitleButton.h"

#import "CZPopMenu.h"
#import "CZCover.h"
#import "CZOneViewController.h"

#import "AFNetworking.h"
#import "CZAccount.h"
#import "CZAccountTool.h"

#import "CZStatus.h"
#import "CZUser.h"

#import "UIImageView+WebCache.h"
#import "MJExtension.h"
#import "MJRefresh.h"

#import "CZHttpTool.h"
#import "CZStatusTool.h"

#import "CZUserTool.h"

#import "CZAccount.h"
#import "CZAccountTool.h"

#import "CZStatusCell.h"
#import "CZStatusFrame.h"

@interface CZHomeViewController ()<CZCoverDelegate>

@property (nonatomic, weak) CZTitleButton *titleButton;

@property (nonatomic, strong) CZOneViewController *one;

/**
 *  viewModel:CZStatusFrame
 */
@property (nonatomic,strong) NSMutableArray *statusFrames;


@end

@implementation CZHomeViewController

//懒加载
- (NSMutableArray *)statusFrames
{
    if (_statusFrames == nil) {
        _statusFrames = [NSMutableArray array];
    }
    return _statusFrames;
}

- (CZOneViewController *)one
{
    if (_one == nil) {
        _one = [[CZOneViewController alloc] init];
    }
    
    return _one;
}

// UIBarButtonItem:决定导航条上按钮的内容
// UINavigationItem:决定导航条上内容
// UITabBarItem:决定tabBar上按钮的内容
// ios7之后，会把tabBar上和导航条上的按钮渲染
// 导航条上自定义按钮的位置是由系统决定，尺寸才需要自己设置。
- (void)viewDidLoad {
    [super viewDidLoad];

    self.tableView.backgroundColor = [UIColor lightGrayColor];
    
    //取消分割线
    self.tableView.separatorStyle = UITableViewCellSeparatorStyleNone;
    
    // 设置导航条内容
    [self setUpNavgationBar];
    
    //下拉刷新
    [self.tableView addHeaderWithTarget:self action:@selector(loadNewStatus)];
    
    //上拉更多
    [self.tableView addFooterWithTarget:self action:@selector(loadMorePreStatus)];
    //自动请求最新数据
    [self.tableView headerBeginRefreshing];
    
    //请求当前用户的昵称
    [CZUserTool userInfoWithSuccess:^(CZUser *user) {
        
        //设置导航条title
        [self.titleButton setTitle:user.name forState:UIControlStateNormal];
        
        //获取当前账户
        CZAccount *account = [CZAccountTool account];
        account.name = user.name;
        
        //保存name
        [CZAccountTool saveAccount:account];
        
        
    } failure:^(NSError *error) {
        
    }];
    
}
/*
- (void)loadnewstatus
{
    //    [mgr GET:@"https://api.weibo.com/2/statuses/friends_timeline.json" parameters:parame success:^(AFHTTPRequestOperation *operation, id responseObject) {
    //
    //        //结束下拉刷新
    //        [self.tableView headerEndRefreshing];
    //
    //        //获取微博的数据，转成模型
    //        //首先获取数组
    //        NSArray *dicArray = responseObject[@"statuses"];
    //
    //        //把字典数组转换成模型数组
    //        NSMutableArray *statuses = [CZStatus mj_objectArrayWithKeyValuesArray:dicArray];
    //        NSIndexSet *indexSet = [NSIndexSet indexSetWithIndexesInRange:NSMakeRange(0, statuses.count)];
    //        //把最新的微博插入到最前面
    //        [self.statuses insertObjects:statuses atIndexes:indexSet];
    //
    //        //显示数据，刷新表格
    //        [self.tableView reloadData];
    //
    //    } failure:^(AFHTTPRequestOperation *operation, NSError *error) {
    //        
    //    }];
}*/

#pragma mark - 请求最新数据
- (void)loadNewStatus
{
    NSString *sinceID = nil;
    if (self.statusFrames.count) {
        
        CZStatus *s = [self.statusFrames[0] status];
        
        sinceID = s.idstr;
    }
    
    //请求最新的微博数据
    [CZStatusTool newStatusWithSinceID:sinceID success:^(NSArray *statuses) {
        //结束下拉刷新
        [self.tableView headerEndRefreshing];
        
        [self showNewStatusCount:statuses.count];
        
        NSIndexSet *indexSet = [NSIndexSet indexSetWithIndexesInRange:NSMakeRange(0, statuses.count)];
        
        //模型->视图模型
        NSMutableArray *statusFs = [NSMutableArray array];
        for (CZStatus *status in statuses) {
            
            CZStatusFrame *statusF = [[CZStatusFrame alloc] init];
            
            statusF.status = status;
            
            [statusFs addObject:statusF];
            
        }
        
        //把最新的微博插入到最前面
        [self.statusFrames insertObjects:statusFs atIndexes:indexSet];
        
        //显示数据，刷新表格
        [self.tableView reloadData];
        
    } failure:^(NSError *error) {
        
        
    }];
    
}

#pragma mark - 展示最新的微博数
- (void)showNewStatusCount: (NSInteger)count
{
    if (count == 0) return;
    
    CGFloat h = 35;
    CGFloat w = self.view.width;
    CGFloat x = 0;
    CGFloat y = CGRectGetMinY(self.navigationController.navigationBar.frame) - 35;
    
    
    UILabel *label = [[UILabel alloc] initWithFrame:CGRectMake(x, y, w, h)];
    
    label.textColor = [UIColor whiteColor];
    
    label.backgroundColor = [UIColor colorWithPatternImage:[UIImage imageNamed:@"timeline_new_status_background"]];
    
    label.text = [NSString stringWithFormat:@"最新的微博数%ld",count];
    
    label.textAlignment =  NSTextAlignmentCenter;
    
    //插入到导航控制器的导航条下面
    [self.view  insertSubview:label belowSubview:self.navigationController.navigationBar];
    
    //动画平移
    [UIView animateWithDuration:0.35 animations:^{
        
        label.transform = CGAffineTransformMakeTranslation(0, 16);
        
    } completion:^(BOOL finished) {
       
        [UIView animateWithDuration:0.35 delay:2 options:( UIViewAnimationOptionCurveLinear ) animations:^{
            
            //返回
            label.transform = CGAffineTransformIdentity;
            
        } completion:^(BOOL finished) {
            
            //返回后消除label
            [label removeFromSuperview];
            
        }];
        
    }];
    
    
}

//点击home 下拉刷新
- (void)homeRefresh
{
    //下拉刷新
    [self.tableView headerBeginRefreshing];
}

#pragma mark - 获取更多的数据
- (void)loadMorePreStatus
{
    NSString *maxID = nil;

    if (self.statusFrames.count) {
        CZStatus *s = [[self.statusFrames lastObject] status];
        long long max_id = [s.idstr longLongValue] - 1;
        maxID = [NSString stringWithFormat:@"%lld",max_id];
    }
    
    //请求更多的微博数据
    [CZStatusTool morePreStatusWithMaxID:maxID success:^(NSArray *statuses) {
        //结束上拉刷新
        [self.tableView footerEndRefreshing];
        
        
        //模型->视图模型
        NSMutableArray *statusFs = [NSMutableArray array];
        for (CZStatus *status in statuses) {
            
            CZStatusFrame *statusF = [[CZStatusFrame alloc] init];
            
            statusF.status = status;
            
            [statusFs addObject:statusF];
            
        }
        
        //添加数组元素
        [self.statusFrames addObjectsFromArray:statusFs];
        
        //显示数据，刷新表格
        [self.tableView reloadData];
        
    } failure:^(NSError *error) {
        
    }];
    
//    [mgr GET:@"https://api.weibo.com/2/statuses/friends_timeline.json" parameters:parame success:^(AFHTTPRequestOperation *operation, id responseObject) {
//        
//        //结束上拉刷新
//        [self.tableView footerEndRefreshing];
//        
//        //获取微博的数据，转成模型
//        //首先获取数组
//        NSArray *dicArray = responseObject[@"statuses"];
//        
//        //把字典数组转换成模型数组
//        NSMutableArray *statuses = [CZStatus mj_objectArrayWithKeyValuesArray:dicArray];
//        
//        [self.statuses addObjectsFromArray:statuses];
//        
//        //显示数据，刷新表格
//        [self.tableView reloadData];
//        
//    } failure:^(AFHTTPRequestOperation *operation, NSError *error) {
//        
//    }];
    
}

#pragma mark - 设置导航条
- (void)setUpNavgationBar
{
    // 左边
    self.navigationItem.leftBarButtonItem = [UIBarButtonItem barButtonItemWithImage:[UIImage imageNamed:@"navigationbar_friendsearch"] highImage:[UIImage imageNamed:@"navigationbar_friendsearch_highlighted"] target:self action:@selector(friendsearch) forControlEvents:UIControlEventTouchUpInside];
    
    // 右边
    self.navigationItem.rightBarButtonItem = [UIBarButtonItem barButtonItemWithImage:[UIImage imageNamed:@"navigationbar_pop"] highImage:[UIImage imageNamed:@"navigationbar_pop_highlighted"] target:self action:@selector(pop) forControlEvents:UIControlEventTouchUpInside];
    
    // titleView
    CZTitleButton *titleButton = [CZTitleButton buttonWithType:UIButtonTypeCustom];
    _titleButton = titleButton;
    
    NSString *title = [CZAccountTool account].name?[CZAccountTool account].name:@"首页";
    [titleButton setTitle:title forState:UIControlStateNormal];
    [titleButton setImage:[UIImage imageNamed:@"navigationbar_arrow_up"] forState:UIControlStateNormal];
    [titleButton setImage:[UIImage imageNamed:@"navigationbar_arrow_down"] forState:UIControlStateSelected];
    
    // 高亮的时候不需要调整图片
    titleButton.adjustsImageWhenHighlighted = NO;
    
    [titleButton addTarget:self action:@selector(titleClick:) forControlEvents:UIControlEventTouchUpInside];
    
    self.navigationItem.titleView = titleButton;
}


// 以后只要显示在最前面的控件，一般都加在主窗口
// 点击标题按钮
- (void)titleClick:(UIButton *)button
{
    button.selected = !button.selected;
    
    // 弹出蒙板
    CZCover *cover = [CZCover show];
    cover.delegate = self;
    
    
    // 弹出pop菜单
    CGFloat popW = 200;
    CGFloat popX = (self.view.width - 200) * 0.5;
    CGFloat popH = popW;
    CGFloat popY = 55;
   CZPopMenu *menu = [CZPopMenu showInRect:CGRectMake(popX, popY, popW, popH)];
    menu.contentView = self.one.view;
    
    
}

// 点击蒙板的时候调用
- (void)coverDidClickCover:(CZCover *)cover
{
    // 隐藏pop菜单
    [CZPopMenu hide];
    
    _titleButton.selected = NO;
    
}

- (void)friendsearch
{
//    NSLog(@"%s",__func__);
}

- (void)pop
{
    
    //创建一个控制器
    CZOneViewController *one = [[CZOneViewController alloc] initWithNibName:nil bundle:nil];
    one.hidesBottomBarWhenPushed = YES;
    
    //跳转到下一个控制器
    [self.navigationController pushViewController:one animated:YES];
    
    

}


#pragma mark - Table view data source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {

    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {

    return self.statusFrames.count;
}


- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    
    CZStatusCell *cell = [CZStatusCell cellWithTableView:tableView];
//    static NSString *reuseID = @"Cell";
//    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:reuseID];
//    
//    if (cell == nil) {
//        cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleSubtitle reuseIdentifier:reuseID];
//    }
    
    //创建cell
    CZStatusFrame *statusF = self.statusFrames[indexPath.row];
    
    //给cell专递模型
    cell.statusF = statusF;
    
//    //用户昵称
//    cell.textLabel.text = statusF.status.user.name;
//    
//    //用户头像
//    [cell.imageView sd_setImageWithURL:statusF.status.user.profile_image_url placeholderImage:[UIImage imageNamed:@"timeline_image_placeholder"]];
//    
//    cell.detailTextLabel.text = statusF.status.text;
    
    return cell;
}

//返回cell的高度
- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath
{
     CZStatusFrame *statusF = self.statusFrames[indexPath.row];
    
    return statusF.cellHeight;
}
@end
