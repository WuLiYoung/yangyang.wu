//
//  PhotoViewController.m
//  Movie
//
//  Created by apple on 15/6/10.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "PhotoViewController.h"
#import "PhotoCollectionView.h"
@interface PhotoViewController ()

@end

@implementation PhotoViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    //创建导航栏左侧按钮
    [self _createNavLeftItem];
    
    //创建图片浏览视图
    [self _createPhotoListView];
    
    //接受隐藏导航栏的通知
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(hideNavgationBar) name:@"HideNavgationBarNotification" object:nil];

  }

//隐藏导航栏
- (void)hideNavgationBar{

    isHide = !isHide;
    [self.navigationController setNavigationBarHidden:isHide animated:YES];


}
- (void)_createPhotoListView{
    
    //1.创建布局对象
    UICollectionViewFlowLayout *layout = [[UICollectionViewFlowLayout alloc] init];
    //单元格大小
    layout.itemSize = CGSizeMake(kScreenWidth, kScreenHeight - 64);
    //单元格之间的最小间隙
    layout.minimumInteritemSpacing = 0;
    layout.minimumLineSpacing = 30;
    
    //滑动方向
    layout.scrollDirection = UICollectionViewScrollDirectionHorizontal;
    //2.子类化UICollectionView,将相关代码封装到PhotoCollectionView中
    PhotoCollectionView *collectionView =[[PhotoCollectionView alloc] initWithFrame:CGRectMake(0, 0, kScreenWidth + 30,kScreenHeight) collectionViewLayout:layout];
    collectionView.images = _images;
    //刷新视图
    [collectionView reloadData];
    [self.view addSubview:collectionView];
    
    //滚动到指定的单元格
    [collectionView scrollToItemAtIndexPath:_indexPath atScrollPosition:UICollectionViewScrollPositionLeft animated:NO];

}
- (void)_createNavLeftItem{

    UIButton *btn = [UIButton buttonWithType:UIButtonTypeSystem];
    [btn setTitle:@"取消" forState:UIControlStateNormal];
    btn.titleLabel.font = [UIFont systemFontOfSize:17];

    [btn sizeToFit];
    [btn addTarget:self action:@selector(clickAction) forControlEvents:UIControlEventTouchUpInside];
    
    UIBarButtonItem *item = [[UIBarButtonItem alloc] initWithCustomView:btn];
    self.navigationItem.leftBarButtonItem = item;

}

- (void)clickAction{

    [self dismissViewControllerAnimated:YES completion:NULL];


}
/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

@end
