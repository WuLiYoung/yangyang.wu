	//
//  YYSearchController.m
//  slide
//
//  Created by 吴洋洋 on 16/5/4.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYSearchController.h"
#import "YYBodyCell.h"
#import "MusicModel.h"
#import "AFNetworking.h"
#import "MJExtension.h"
#import "UINavigationController+FDFullscreenPopGesture.h"

#import "YYModaController.h"
#import "YYPlayToolOL.h"

@interface YYSearchController ()<UISearchBarDelegate>
@property (weak, nonatomic) IBOutlet UISearchBar *searchBar;

@property (nonatomic,strong) NSMutableArray *dataArr;


@end

@implementation YYSearchController

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    self.navigation.navigationBar.hidden = NO;
}

- (void)viewDidLoad {
    [super viewDidLoad];
   
    if ([self.keyword isEqualToString:@" "]) {
        self.searchBar.text = self.keyword;
    }
    
    self.searchBar.delegate = self;
    
    [self.searchBar sizeToFit];
    
    [self readData:self.keyword];
    
    self.tableView.separatorStyle = UITableViewCellSeparatorStyleNone;
    
    [self back];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return self.dataArr.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    MusicModel *model = self.dataArr[indexPath.row];
    
    YYBodyCell *cell = [tableView dequeueReusableCellWithIdentifier:@"searchCell" forIndexPath:indexPath];
    cell.model = model;
    cell.songName.text = [NSString stringWithFormat:@"%ld. %@",indexPath.row + 1,model.song_name];
    
    return cell;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    
    YYBodyCell *cell = [tableView cellForRowAtIndexPath:indexPath];
    
    YYModaController *vc = [self.storyboard instantiateViewControllerWithIdentifier:@"sbModa"];
    
    vc.navigation = self.navigation;

    [self presentViewController:vc animated:YES completion:^{
        
        //歌曲名字
        vc.songName.text = [cell.model.song_name isEqualToString:@" "] || cell.model.song_name == nil ? @" " : cell.model.song_name;
        //歌手名字
        vc.singerName.text = [cell.model.singer_name isEqualToString:@" "] || cell.model.singer_name == nil ? @" " : cell.model.singer_name;
        
        [[YYPlayToolOL sharedYYPlayToolOL] prepareToPlayWithMusic:cell.model];
        
    }];
    
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath
{
    return 75;
}

//数据请求
- (void)readData: (NSString *)keyword
{
    NSDictionary *parameDict = [NSDictionary dictionaryWithObjects:@[keyword, @"1", @"50"] forKeys:@[@"q", @"page", @"size"]];
    
    [[AFHTTPSessionManager manager] GET:@"http://so.ard.iyyin.com/s/song_with_out" parameters:parameDict success:^(NSURLSessionDataTask *task, id responseObject) {
        
          self.dataArr = [MusicModel mj_objectArrayWithKeyValuesArray:responseObject[@"data"]];
        [self.tableView reloadData];
        
    } failure:^(NSURLSessionDataTask *task, NSError *error) {
        
    }];
}

#pragma mark UISearchBarDelegate
- (void)searchBar:(UISearchBar *)searchBar textDidChange:(NSString *)searchText {
    //处理没有搜索词的情况
    if ([searchText isEqualToString:@""] || !searchText) {
        return;
    }
    if (self.dataArr) {
        [self.dataArr removeAllObjects];
    }
    //根据关键字，重新请求
    [self readData:searchText];
    
}
//点击搜索回收键盘
- (void)searchBarSearchButtonClicked:(UISearchBar *)searchBar {
    [searchBar resignFirstResponder];
}

- (void)scrollViewDidScroll:(UIScrollView *)scrollView {
    [self.searchBar resignFirstResponder];
}

//设置返回
- (void)back
{
    self.navigationItem.title = @"想听就搜呗";
    UIBarButtonItem *leftBack = [[UIBarButtonItem alloc] initWithImage:[UIImage imageNamed:@"btn_back"] style:UIBarButtonItemStylePlain target:self action:@selector(back:)];
    self.navigationItem.leftBarButtonItem = leftBack;
}

- (void)back: (UIBarButtonItem *)item
{
    [self.navigation popToRootViewControllerAnimated:YES];
}

@end
