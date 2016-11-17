//
//  YYSingerController.m
//  slide
//
//  Created by 吴洋洋 on 16/5/11.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYSingerController.h"
#import "AFNetworking.h"
#import "MJExtension.h"
#import "YYSingerModel.h"
#import "YYSingerCell.h"

#import "YYMusicListController.h"

@interface YYSingerController () <UITableViewDataSource,UITableViewDelegate>
@property (weak, nonatomic) IBOutlet UITableView *tableView;

@property (nonatomic,strong) NSMutableArray *dataArr;


@end

@implementation YYSingerController

- (NSMutableArray *)dataArr
{
    if (_dataArr == nil) {
        _dataArr = [NSMutableArray array];
    }
    return _dataArr;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    self.navigationItem.title = self.navTitle;
    
    self.tableView.delegate   = self;
    self.tableView.dataSource = self;
    
    [self readData];
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
    YYSingerCell *cell = [tableView dequeueReusableCellWithIdentifier:@"singerCell" forIndexPath:indexPath];
    
    cell.model = self.dataArr[indexPath.row];
    
    return cell;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    YYSingerModel *model      = self.dataArr[indexPath.row];

    YYMusicListController *vc = [self.storyboard instantiateViewControllerWithIdentifier:@"sbList"];

    vc.from                   = @"singerMusic";
    vc.navigation             = self.navigation;
    vc.navTitile              = model.singer_name;
    vc.pic_url                = model.pic_url;
    vc.msg_id                 = [NSString stringWithFormat:@"%@",model.singer_id];
    
    [self.navigation pushViewController:vc animated:YES];
    
}

//数据请求
- (void)readData
{
    [[AFHTTPSessionManager manager] GET:[NSString stringWithFormat:@"http://v1.ard.tj.itlily.com/ttpod?a=getnewttpod&id=%@&size=1000&page=1", self.singerTypeID] parameters:nil success:^(NSURLSessionDataTask *task, id responseObject) {
        
        self.dataArr = [YYSingerModel mj_objectArrayWithKeyValuesArray:responseObject[@"data"]];
        
        [self.tableView reloadData];
        
    } failure:^(NSURLSessionDataTask *task, NSError *error) {
        
    }];
}

@end
