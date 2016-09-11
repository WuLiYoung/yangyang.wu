//
//  YYSingerTypeController.m
//  slide
//
//  Created by 吴洋洋 on 16/5/12.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYSingerTypeController.h"
#import "YYSingerTypeModel.h"
#import "YYSingerTypeCell.h"
#import "MJExtension.h"
#import "AFNetworking.h"
#import "YYSingerController.h"
#import "YYSingerController.h"

@interface YYSingerTypeController () <UITableViewDataSource,UITableViewDelegate>
@property (weak, nonatomic) IBOutlet UITableView *tableView;

@property (nonatomic,strong) NSMutableArray *dataArr;


@end

@implementation YYSingerTypeController

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
    
    UIBarButtonItem *leftBack = [[UIBarButtonItem alloc] initWithImage:[UIImage imageNamed:@"btn_back"] style:UIBarButtonItemStylePlain target:self action:@selector(handleBack:)];
    
    self.navigationItem.leftBarButtonItem = leftBack;
    
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
    YYSingerTypeCell *cell = [tableView dequeueReusableCellWithIdentifier:@"singerTypeCell" forIndexPath:indexPath];
    
    cell.model = self.dataArr[indexPath.row];
    
    cell.selectionStyle = UITableViewCellSelectionStyleNone;
    
    return cell;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    YYSingerTypeModel *model  = self.dataArr[indexPath.row];
    
    YYSingerController *vc = [self.storyboard instantiateViewControllerWithIdentifier:@"sbSinger"];
    
    vc.navigation             = self.navigation;
    vc.singerTypeID           = model.id;
    vc.navTitle               = model.title;
    
    [self.navigation pushViewController:vc animated:YES];
    
}

//数据请求
- (void)readData
{
    [[AFHTTPSessionManager manager] GET:@"http://v1.ard.tj.itlily.com/ttpod?a=getnewttpod&id=46" parameters:nil success:^(NSURLSessionDataTask *task, id responseObject) {
        
        self.dataArr = [YYSingerTypeModel mj_objectArrayWithKeyValuesArray:responseObject[@"data"]];
        
        [self.tableView reloadData];
        
    } failure:^(NSURLSessionDataTask *task, NSError *error) {
        
    }];
}

- (void)handleBack: (UIBarButtonItem *)item
{
    [self.navigation popViewControllerAnimated:YES];
}

@end
