//
//  CHSearchController.m
//  slideHeadView
//
//  Created by 吴洋洋 on 16/4/28.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHSearchController.h"
#import "CHSearchCell.h"
#import "CHMusicModel.h"
#import "NetworkHelper.h"
#import "AFNetworking.h"
#import "MJExtension.h"

@interface CHSearchController () <UITableViewDataSource,UITableViewDelegate,UISearchBarDelegate,UISearchControllerDelegate>

@property (nonatomic,strong) NSMutableArray *dataArr;

@property (weak, nonatomic) IBOutlet UITableView *tableView;

@property (weak, nonatomic) IBOutlet UISearchBar *searchBar;

@end

@implementation CHSearchController

- (NSMutableArray *)dataArr
{
    if (_dataArr == nil) {
        _dataArr = [NSMutableArray array];
    }
    return _dataArr;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    self.tableView.delegate = self;
    
    self.tableView.separatorStyle = UITableViewCellSeparatorStyleNone;
    
    UIBarButtonItem *leftBtn = [[UIBarButtonItem alloc] initWithImage:[UIImage imageNamed:@"btn_back"] style:UIBarButtonItemStylePlain target:self action:@selector(back:)];
    self.navigationItem.leftBarButtonItem = leftBtn;
    
    self.navigationItem.titleView = self.searchBar;
    if (![self.keyWord isEqualToString:@"  "]) {
        self.searchBar.text = self.keyWord;
    }
    
    self.searchBar.delegate = self;
    
    [self.searchBar sizeToFit];
    
    [self readSearchData:self.keyWord];


    
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return self.dataArr.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    CHMusicModel *model = self.dataArr[indexPath.row];
    
    CHSearchCell *cell = [tableView dequeueReusableCellWithIdentifier:@"searchCell" forIndexPath:indexPath];
    
    cell.model = model;
    cell.songName.text = [NSString stringWithFormat:@"%ld.%@",indexPath.row + 1,model.song_name];
    
    return cell;
}

#pragma mark - 网络请求获取数据
- (void)readSearchData: (NSString *)keyWord
{
    NSMutableDictionary *parames = [NSMutableDictionary dictionary];
    parames[@"q"] = keyWord;
    parames[@"page"] = @(1);
    parames[@"size"] = @(50);
    
    [[AFHTTPSessionManager manager] GET:@"http://so.ard.iyyin.com/s/song_with_out" parameters:parames success:^(NSURLSessionDataTask *task, id responseObject) {
        
        NSMutableArray *dicArr = responseObject[@"data"];
        
        NSLog(@"%@",responseObject[@"data"]);
        
        self.dataArr = [CHMusicModel mj_objectArrayWithKeyValuesArray:dicArr];
        
        [self.tableView reloadData];
        
    } failure:^(NSURLSessionDataTask *task, NSError *error) {
        
    }];
  
}

- (void)searchBar:(UISearchBar *)searchBar textDidChange:(NSString *)searchText {
    //处理没有搜索词的情况
    if ([searchText isEqualToString:@""] || !searchText) {
        return;
    }
    if (self.dataArr) {
        [self.dataArr removeAllObjects];
    }
    //根据关键字，重新请求
    [self readSearchData:searchText];
}
//点击搜索回收键盘
- (void)searchBarSearchButtonClicked:(UISearchBar *)searchBar {
    [searchBar resignFirstResponder];
}

- (void)scrollViewDidScroll:(UIScrollView *)scrollView {
    [self.searchBar resignFirstResponder];
}

- (void)back:(UIBarButtonItem *)item
{
    [self.navigation popToRootViewControllerAnimated:YES];
}


@end
