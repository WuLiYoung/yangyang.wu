//
//  CHCommendController.m
//  --ios百思不得其姐
//
//  Created by 吴洋洋 on 16/4/1.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHCommendController.h"
#import "AFNetworking.h"
#import "MBProgressHUD+MJ.h"
#import "CHRecommendTypeCell.h"
#import "CHRecommendUserCell.h"
#import "MJExtension.h"
#import "CHRecommendType.h"
#import "CHRecommendUser.h"
#import "MJRefresh.h"


@interface CHCommendController () <UITableViewDataSource,UITableViewDelegate>

@property (weak, nonatomic) IBOutlet UITableView *RecommendTableView;
@property (weak, nonatomic) IBOutlet UITableView *userTableView;

/**
 *  左边类型数组
 */
@property (nonatomic,strong) NSArray *types;

@property (nonatomic,strong) NSMutableDictionary *parames;

@property (nonatomic,strong) AFHTTPSessionManager *manager;



@end

@implementation CHCommendController

- (AFHTTPSessionManager *)manager
{
    if (_manager == nil) {
        _manager = [AFHTTPSessionManager manager];
    }
    return _manager;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    [self setUpTableView];
    
    [self setUpTypeData];
    
    [self setUpRefresh];
    
}

//请求左边的数据
- (void)setUpTypeData
{
    NSMutableDictionary *parames = [NSMutableDictionary dictionary];
    parames[@"a"] = @"category";
    parames[@"c"] = @"subscribe";
    
    [MBProgressHUD showMessage:@"正在加载..."];
    
    //使用AFN进行网络请求
    [self.manager GET:@"http:api.budejie.com/api/api_open.php" parameters:parames success:^(NSURLSessionDataTask *task, id responseObject) {
        
        //服务器返回的json数据，将字典转为模型
        self.types = [CHRecommendType mj_objectArrayWithKeyValuesArray:responseObject[@"list"]];
        
        //刷新表格
        [self.RecommendTableView reloadData];
        
        // 默认选中首行
        [self.RecommendTableView selectRowAtIndexPath:[NSIndexPath indexPathForRow:0 inSection:0] animated:NO scrollPosition:UITableViewScrollPositionTop];
        
        [self.userTableView headerBeginRefreshing];
        
        [MBProgressHUD hideHUD];
        
    } failure:^(NSURLSessionDataTask *task, NSError *error) {
        
        [MBProgressHUD hideHUD];
        
    }];

}

- (void)setUpTableView
{
  
    
    //注册cell
    [self.RecommendTableView registerNib:[UINib nibWithNibName:NSStringFromClass([CHRecommendTypeCell class]) bundle:nil] forCellReuseIdentifier:@"typeCell"];
    [self.userTableView registerNib:[UINib nibWithNibName:NSStringFromClass([CHRecommendUserCell class]) bundle:nil] forCellReuseIdentifier:@"userCell"];
    
    //设置inset
    self.automaticallyAdjustsScrollViewInsets = NO;
    self.RecommendTableView.contentInset = UIEdgeInsetsMake(64, 0, 0, 0);
    self.userTableView.contentInset = UIEdgeInsetsMake(64, 0, 0, 0);
    
    self.title = @"推荐关注";
    
    self.view.backgroundColor = [UIColor colorWithRed:(223)/255.0 green:(223)/255.0 blue:(223)/255.0 alpha:1.0];
}

- (void)setUpRefresh
{
    
    
    [self.userTableView addFooterWithTarget:self action:@selector(loadMoreUsers)];
    
    [self.userTableView addHeaderWithTarget:self action:@selector(loadNewUsers)];
    
}

- (void)loadNewUsers
{
    CHRecommendType *u = self.types[self.RecommendTableView.indexPathForSelectedRow.row];
    
    u.currentPage = 1;
    
    NSMutableDictionary *parames = [NSMutableDictionary dictionary];
    parames[@"a"] = @"list";
    parames[@"c"] = @"subscribe";
    parames[@"category_id"] = @(u.id);
    parames[@"page"] = @(u.currentPage);
    self.parames = parames;
    
    [self.manager GET:@"http://api.budejie.com/api/api_open.php" parameters:parames success:^(NSURLSessionDataTask *task, id responseObject) {
        
        
        
        NSArray *users = [CHRecommendUser mj_objectArrayWithKeyValuesArray:responseObject[@"list"]];
        
        //先移除数据中所有的数据
        [u.users removeAllObjects];
        
        [u.users addObjectsFromArray:users];
        
        //保存总数
        u.total = [responseObject[@"total"] integerValue];
        
        //是否是最后一次请求
        if (self.parames != parames) return ;
        
        //刷新表格
        [self.userTableView reloadData];
        
        //结束刷新
        [self.userTableView headerEndRefreshing];
        
    } failure:^(NSURLSessionDataTask *task, NSError *error) {
        
        [self.userTableView headerEndRefreshing];
        
    }];

}

//加载更多的数据
- (void)loadMoreUsers
{
    CHRecommendType *u = self.types[self.RecommendTableView.indexPathForSelectedRow.row];
    
    if (u.users.count == u.total) {
        
        [MBProgressHUD showMessage:@"全部加载完毕！"];
    }
    
    NSMutableDictionary *parames = [NSMutableDictionary dictionary];
    parames[@"a"] = @"list";
    parames[@"c"] = @"subscribe";
    parames[@"category_id"] = @(u.id);
    parames[@"page"] = @(++u.currentPage);
    
    [self.manager GET:@"http://api.budejie.com/api/api_open.php" parameters:parames success:^(NSURLSessionDataTask *task, id responseObject) {
      
        [MBProgressHUD hideHUD];
        //字典数据->模型数组
        NSArray *users = [CHRecommendUser mj_objectArrayWithKeyValuesArray:responseObject[@"list"]];
        
        //把数组插入到当前用户数组中
        [u.users addObjectsFromArray:users];
        
        [self.userTableView reloadData];
        
        [self.userTableView footerEndRefreshing];
        
    } failure:^(NSURLSessionDataTask *task, NSError *error) {
        
        [MBProgressHUD hideHUD];
        
    }];

}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    if (tableView == self.RecommendTableView) {
        
        return self.types.count;
        
    }else{
        
        CHRecommendType *t = self.types[self.RecommendTableView.indexPathForSelectedRow.row];
        
        return t.users.count;
    }
    
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    if (tableView == self.RecommendTableView) {
        
        static NSString *reuseID = @"typeCell";
        
        CHRecommendTypeCell *cell = [tableView dequeueReusableCellWithIdentifier:reuseID];
        
        cell.type = self.types[indexPath.row];
        
        return cell;
        
    }else{
        
        static NSString *reuseID = @"userCell";
        
        CHRecommendUserCell *cell = [tableView dequeueReusableCellWithIdentifier:reuseID];
        CHRecommendType *t = self.types[self.RecommendTableView.indexPathForSelectedRow.row];
        cell.user = t.users[indexPath.row];
    
        return cell;
    }

}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(nonnull NSIndexPath *)indexPath
{
    [self.userTableView headerEndRefreshing];
    [self.userTableView footerEndRefreshing];
    
    CHRecommendType *u = self.types[indexPath.row];
    
    if (u.users.count) {
        //显示原有的数据
        [self.userTableView reloadData];
    }
    else{
        [self.userTableView reloadData];
        
        [self.userTableView headerBeginRefreshing];
    }
 
}

- (void)dealloc
{
    [self.manager.operationQueue cancelAllOperations];
    
}

@end
