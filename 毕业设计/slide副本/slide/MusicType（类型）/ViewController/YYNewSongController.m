//
//  YYNewSongController.m
//  slide
//
//  Created by 吴洋洋 on 16/5/3.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYNewSongController.h"
#import "YYNewSongCell.h"
#import "YYNewSongModel.h"
#import "MJExtension.h"
#import "AFNetworking.h"
#import "YYMusicListController.h"



@interface YYNewSongController () <UICollectionViewDataSource,UICollectionViewDelegate>
{
    UIImageView *imageBgk;
}

@property (weak, nonatomic) IBOutlet UICollectionViewFlowLayout *flow;
@property (nonatomic,strong) NSMutableArray *dataArr;


@end

@implementation YYNewSongController

-(NSMutableArray *)dataArr{

    if (_dataArr == nil) {
        _dataArr = [NSMutableArray array];
    }
    return _dataArr;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    UIBarButtonItem *leftBack = [[UIBarButtonItem alloc] initWithImage:[UIImage imageNamed:@"btn_back"] style:UIBarButtonItemStylePlain target:self action:@selector(handleBack:)];
    self.navigationItem.leftBarButtonItem = leftBack;
    self.navigationItem.title = self.navTitle;
    
    self.flow.itemSize = CGSizeMake(([UIScreen mainScreen].bounds.size.width - 24) / 2, ([UIScreen mainScreen].bounds.size.width - 24) / 2 + 45);
    self.flow.sectionInset = UIEdgeInsetsMake(5, 8, 0, 8);
    self.flow.minimumInteritemSpacing = 8;
    self.collectionView.dataSource = self;
    self.collectionView.delegate = self;
    
    imageBgk = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"network-disabled"]];
    imageBgk.center = CGPointMake(self.view.center.x, self.view.center.y - 50);
    
    [self.collectionView addSubview:imageBgk];
    
    [self readData];

}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];

}

//返回多少个Item
- (NSInteger)collectionView:(UICollectionView *)collectionView numberOfItemsInSection:(NSInteger)section
{
    return self.dataArr.count;
}

//创建Cell
- (UICollectionViewCell *)collectionView:(UICollectionView *)collectionView cellForItemAtIndexPath:(NSIndexPath *)indexPath
{
    YYNewSongCell *cell = [collectionView dequeueReusableCellWithReuseIdentifier:@"collectionCell" forIndexPath:indexPath];
    cell.model = self.dataArr[indexPath.row];
    
    return cell;
}

- (void)collectionView:(UICollectionView *)collectionView didSelectItemAtIndexPath:(NSIndexPath *)indexPath
{
    YYNewSongModel *model = self.dataArr[indexPath.row];
    
    UIStoryboard *sb = [UIStoryboard storyboardWithName:@"Main" bundle:nil];
    
    YYMusicListController *listVC = [sb instantiateViewControllerWithIdentifier:@"sbList"];
    
    listVC.navigation = self.navigation;
    listVC.msg_id = model.msg_id;
    listVC.navTitile = model.desc;
    
    [self.navigation pushViewController:listVC animated:YES];
    
}

#pragma mark - 数据请求
- (void)readData
{
    [[AFHTTPSessionManager manager] GET:@"http://online.dongting.com/recomm/new_albums?page=1&size=30" parameters:nil success:^(NSURLSessionDataTask *task, id responseObject) {
       
        self.dataArr = [YYNewSongModel mj_objectArrayWithKeyValuesArray:responseObject[@"data"]];
        [self.collectionView reloadData];
        
        [imageBgk removeFromSuperview];
        imageBgk = nil;
        
    } failure:^(NSURLSessionDataTask *task, NSError *error) {
        
    }];
}

- (void)handleBack:(UIBarButtonItem *)item
{
    [self.navigation popViewControllerAnimated:YES];
}

@end
