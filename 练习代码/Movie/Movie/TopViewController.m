//
//  TopViewController.m
//  Movie
//
//  Created by apple on 15/6/3.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "TopViewController.h"
#import "DataService.h"
#import "Movie.h"
#import "TopCell.h"
#import "MovieDetailController.h"
static NSString *identy = @"TopCell";
@interface TopViewController ()

@end

@implementation TopViewController
- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    
    if (self) {
        self.title = @"TOP250";
        
    }
    return self;
    
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    
    //1.创建视图
    [self createTopListview];
    //2.加载数据
    [self loadTopListData];
}

- (void)loadTopListData{
    
    NSDictionary *dic = [DataService loadJsonDataWithName:Top250];
    
    topList = [NSMutableArray array];
    NSArray *subjects =  dic[@"subjects"];
    
    for (NSDictionary *topDic in subjects) {
        
        Movie *movie = [[Movie alloc] init];
        
        [movie setValuesForKeysWithDictionary:topDic];
        [topList addObject:movie];
    }
    
    //刷新视图
    [_collectionView reloadData];
}

- (void)createTopListview{

    UICollectionViewFlowLayout *layout = [[UICollectionViewFlowLayout alloc] init];
    
    //单元格大小
    CGFloat width = (kScreenWidth - 40) / 3;
    layout.itemSize = CGSizeMake(width, width / 3 * 5);
    _collectionView = [[UICollectionView alloc] initWithFrame:CGRectMake(0, 0, kScreenWidth, kScreenHeight) collectionViewLayout:layout];
    
    _collectionView.dataSource = self;
    _collectionView.delegate = self;
    [self.view addSubview:_collectionView];
    
    //注册单元格
    [_collectionView registerNib:[UINib nibWithNibName:@"TopCell" bundle:nil] forCellWithReuseIdentifier:identy];


}

#pragma mark UICollectionViewDelegate
- (NSInteger)collectionView:(UICollectionView *)collectionView numberOfItemsInSection:(NSInteger)section {

    return topList.count;

}

// The cell that is returned must be retrieved from a call to -dequeueReusableCellWithReuseIdentifier:forIndexPath:
- (UICollectionViewCell *)collectionView:(UICollectionView *)collectionView cellForItemAtIndexPath:(NSIndexPath *)indexPath {

    TopCell *cell = [collectionView dequeueReusableCellWithReuseIdentifier:identy forIndexPath:indexPath];
    
    cell.movie = topList[indexPath.row];

    return cell;
}
- (UIEdgeInsets)collectionView:(UICollectionView *)collectionView layout:(UICollectionViewLayout *)collectionViewLayout insetForSectionAtIndex:(NSInteger)section{

    return UIEdgeInsetsMake(10, 10, 10, 10);

}

//单元格点击
- (void)collectionView:(UICollectionView *)collectionView didSelectItemAtIndexPath:(NSIndexPath *)indexPath{
    
    [self.navigationController pushViewController:[[MovieDetailController alloc] init] animated:YES];
    

}





@end
