//
//  CZFeatureController.m
//  微博
//
//  Created by 吴洋洋 on 16/2/19.
//  Copyright © 2016年 apple. All rights reserved.
//



#import "CZFeatureController.h"
#import "CZFeatureCell.h"

@interface CZFeatureController ()

@property (nonatomic, weak) UIPageControl *control;

@end

@implementation CZFeatureController

static NSString * const reuseID = @"Cell";

- (instancetype)init
{
    UICollectionViewFlowLayout *FL = [[UICollectionViewFlowLayout alloc] init];
    
    //设置cell
    FL.itemSize = [UIScreen mainScreen].bounds.size;
    
    //清空行距
    FL.minimumLineSpacing = 0;
    
    //设置横向滑动
    FL.scrollDirection = UICollectionViewScrollDirectionHorizontal;
    
    return [super initWithCollectionViewLayout:FL];
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    self.collectionView.backgroundColor = [UIColor greenColor];
    
    //注册自己的cell
    [self.collectionView registerClass:[CZFeatureCell class] forCellWithReuseIdentifier:reuseID];
    
    //分页
    self.collectionView.pagingEnabled = YES;
    //底部条
    self.collectionView.showsHorizontalScrollIndicator = NO;
    //弹性
    self.collectionView.bounces = NO;
    
    [self setUpPageControl];
}

// 添加pageController
- (void)setUpPageControl
{
    // 添加pageController,只需要设置位置，不需要管理尺寸
    UIPageControl *control = [[UIPageControl alloc] init];
    
    control.numberOfPages = 4;
    control.pageIndicatorTintColor = [UIColor blackColor];
    control.currentPageIndicatorTintColor = [UIColor redColor];
    
    // 设置center
    control.center = CGPointMake(self.view.width * 0.5, self.view.height * 0.95);
    _control = control;
    [self.view addSubview:control];
}

- (void)scrollViewDidScroll:(UIScrollView *)scrollView
{
    // 获取当前的偏移量，计算当前第几页
    int page = scrollView.contentOffset.x / scrollView.bounds.size.width + 0.5;
    
    // 设置页数
    _control.currentPage = page;
}

//返回多少组
- (NSInteger)numberOfSectionsInCollectionView:(UICollectionView *)collectionView
{
    return 1;
}

//返回多少cell
- (NSInteger)collectionView:(UICollectionView *)collectionView numberOfItemsInSection:(NSInteger)section
{
    return 4;
}

//返回cell
- (UICollectionViewCell *)collectionView:(UICollectionView *)collectionView cellForItemAtIndexPath:(NSIndexPath *)indexPath
{
    CZFeatureCell *cell = [collectionView dequeueReusableCellWithReuseIdentifier:reuseID forIndexPath:indexPath];
    
//    float screenH = [UIScreen mainScreen].bounds.size.height;
    
    NSString *imageName = [NSString stringWithFormat:@"new_feature_%ld",indexPath.row + 1];
    
    cell.image = [UIImage imageNamed:imageName];
    
    [cell setIndexPath:indexPath count:4];
    
    return cell;
}

@end
