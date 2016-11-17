//
//  YYSongTypeController.m
//  slide
//
//  Created by 吴洋洋 on 16/5/11.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYSongTypeController.h"
#import "YYSongTypeModel.h"
#import "YYSongTypeCell.h"
#import "YYMusicListController.h"
#import "YYCollectionReusableView.h"

#import "MJExtension.h"
#import "AFNetworking.h"

@interface YYSongTypeController ()<UICollectionViewDataSource,UICollectionViewDelegate>
@property (nonatomic,strong) UIImageView *imageBgk;

@property (nonatomic, strong) NSMutableArray *dataSourceArr;
@property (nonatomic, strong) NSMutableArray *dataSection;
@property (nonatomic, strong) NSString *preTypeName; //记录上一条信息的类别
@property (weak, nonatomic) IBOutlet UICollectionView *collectionView;
@property (weak, nonatomic) IBOutlet UICollectionViewFlowLayout *flow;

@end

@implementation YYSongTypeController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    self.navigationItem.title = self.navTitle;
    self.dataSourceArr = [NSMutableArray array];
    self.dataSection = [NSMutableArray array];
    self.flow.itemSize = CGSizeMake(([UIScreen mainScreen].bounds.size.width - 40) / 3, ([UIScreen mainScreen].bounds.size.width - 40) / 3 + 28);
    self.flow.sectionInset = UIEdgeInsetsMake(8, 8, 0, 8);
    
    _collectionView.dataSource = self;
    _collectionView.delegate = self;
    
    UIBarButtonItem *leftBack = [[UIBarButtonItem alloc] initWithImage:[UIImage imageNamed:@"btn_back"] style:UIBarButtonItemStylePlain target:self action:@selector(handleBack:)];
    
    self.navigationItem.leftBarButtonItem = leftBack;
    
    self.preTypeName = @"热门";
    
    [self.collectionView registerClass:[YYCollectionReusableView class] forSupplementaryViewOfKind:UICollectionElementKindSectionHeader withReuseIdentifier:@"header"];
    self.imageBgk = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"network-disabled"]];
    self.imageBgk.center = CGPointMake(self.view.center.x, self.view.center.y - 50);
    [self.collectionView addSubview:_imageBgk];
    
    [self readData];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (NSInteger)numberOfSectionsInCollectionView:(UICollectionView *)collectionView
{
    return self.dataSection.count;
}

- (NSInteger)collectionView:(UICollectionView *)collectionView numberOfItemsInSection:(NSInteger)section
{
    return [self.dataSourceArr[section] count];
}

- (UICollectionViewCell *)collectionView:(UICollectionView *)collectionView cellForItemAtIndexPath:(NSIndexPath *)indexPath
{
    YYSongTypeCell *cell = [collectionView dequeueReusableCellWithReuseIdentifier:@"songTypeCell" forIndexPath:indexPath];
    
    cell.model = self.dataSourceArr[indexPath.section][indexPath.row];
    
    return cell;
}

- (UICollectionReusableView *) collectionView:(UICollectionView *)collectionView viewForSupplementaryElementOfKind:(NSString *)kind atIndexPath:(NSIndexPath *)indexPath{
    UICollectionReusableView *reusableview = nil;
    
    if (kind == UICollectionElementKindSectionHeader)
    {
        YYCollectionReusableView *headerView = [collectionView dequeueReusableSupplementaryViewOfKind:UICollectionElementKindSectionHeader withReuseIdentifier:@"header" forIndexPath:indexPath];
        headerView.lblTitle.text = _dataSection[indexPath.section];
        reusableview = headerView;
    }
    
    return reusableview;
}

- (void)collectionView:(UICollectionView *)collectionView didSelectItemAtIndexPath:(NSIndexPath *)indexPath
{
    YYSongTypeModel *model = self.dataSourceArr[indexPath.section][indexPath.row];
    
    YYMusicListController *vc = [self.storyboard instantiateViewControllerWithIdentifier:@"sbList"];
    
    vc.from = @"songType";
    vc.navigation = self.navigation;
    vc.navTitile = model.songlist_name;
    vc.pic_url = model.pic_url_240_200;
    vc.msg_id = [NSString stringWithFormat:@"%@", model.songlist_id];
    [self.navigation pushViewController:vc animated:YES];
}

//数据请求
- (void)readData
{
    [[AFHTTPSessionManager manager] GET:@"http://fm.api.ttpod.com/channellist?image_type=240_200" parameters:nil success:^(NSURLSessionDataTask *task, id responseObject) {
        
        NSMutableArray *tempArr = [NSMutableArray array];
        
//        tempArr = [YYSongTypeModel mj_objectArrayWithKeyValuesArray:responseObject[@"data"]];
//        [self.dataSourceArr addObject:tempArr];
        
        for (NSDictionary *dict in responseObject[@"data"]) {
            YYSongTypeModel *model = [YYSongTypeModel new];
            [model setValuesForKeysWithDictionary:dict];
            if (![_preTypeName isEqualToString:model.parentname]) {
                [_dataSection addObject:model.parentname];
                [_dataSourceArr addObject:tempArr];
//                tempArr = [NSMutableArray array];
            }
            [tempArr addObject:model];
            _preTypeName = model.parentname;
        }
        [self.collectionView reloadData];
        
        [self.imageBgk removeFromSuperview];
        self.imageBgk = nil;
        
    } failure:^(NSURLSessionDataTask *task, NSError *error) {
        
    }];
}

- (void)handleBack: (UIBarButtonItem *)item
{
    [self.navigation popViewControllerAnimated:YES];
}

@end
