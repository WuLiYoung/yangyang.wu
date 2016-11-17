//
//  ImageListController.m
//  Movie
//
//  Created by apple on 15/6/9.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "ImageListController.h"
#import "DataService.h"
#import "Image.h"
#import "ImageCell.h"
#import "PhotoViewController.h"
#import "NavViewController.h"

@interface ImageListController ()

@end



@implementation ImageListController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil{

    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    
    if (self) {
        //当前控制器视图显示时,隐藏系统tababr
        self.hidesBottomBarWhenPushed = YES;
        
    }
    return self;
}
- (void)viewDidLoad {
    [super viewDidLoad];
    self.view.backgroundColor = [UIColor colorWithPatternImage:[UIImage imageNamed:@"bg_main@2x.png"]];
    
    //1.加载数据
    [self _loadImageListData];
    //2.创建视图
    [self _createImageListView];
}

- (void)_createImageListView{

    //创建布局对象
    UICollectionViewFlowLayout *layout = [[UICollectionViewFlowLayout alloc] init];
    //设置单元格大小 分四列
    layout.itemSize = CGSizeMake((kScreenWidth - 10 * 5) / 4, (kScreenWidth - 10 * 5) / 4);
    
    //创建图片列表视图
    _collectionView = [[UICollectionView alloc] initWithFrame:CGRectMake(0, 0, kScreenWidth, kScreenHeight) collectionViewLayout:layout];
    _collectionView.dataSource = self;
    _collectionView.delegate = self;
    [self.view addSubview:_collectionView];
    
    //注册单元格
    [_collectionView registerClass:[ImageCell class] forCellWithReuseIdentifier:@"cell"];
    

}
- (void)_loadImageListData{

    NSArray *arr = [DataService loadJsonDataWithName:@"image_list.json"];
    
    _imageList = [NSMutableArray array];
    for (NSDictionary *dic in arr) {
        
        Image *image = [[Image alloc] init];
        [image setValuesForKeysWithDictionary:dic];
        
        //将图片model加入到数组中
        [_imageList addObject:image];
    }
    
    //刷新视图
    [_collectionView reloadData];

}

- (NSInteger)collectionView:(UICollectionView *)collectionView numberOfItemsInSection:(NSInteger)section {
    return _imageList.count;

}

// The cell that is returned must be retrieved from a call to -dequeueReusableCellWithReuseIdentifier:forIndexPath:
- (UICollectionViewCell *)collectionView:(UICollectionView *)collectionView cellForItemAtIndexPath:(NSIndexPath *)indexPath {

    ImageCell *cell = [collectionView dequeueReusableCellWithReuseIdentifier:@"cell" forIndexPath:indexPath];
    //去到对应的图片model
    Image *image = [_imageList objectAtIndex:indexPath.row];
    
//    UIImageView *imageview
    cell.image = image;
    
    return cell;
}

//调整单元格与父视图边缘的间隙
- (UIEdgeInsets)collectionView:(UICollectionView *)collectionView layout:(UICollectionViewLayout *)collectionViewLayout insetForSectionAtIndex:(NSInteger)section{
    
    return UIEdgeInsetsMake(10, 10, 10, 10);

}

//单元格点击
- (void)collectionView:(UICollectionView *)collectionView didSelectItemAtIndexPath:(NSIndexPath *)indexPath{
    
    NSMutableArray *images = [NSMutableArray array];
    //将图片的的URL抽取出来
    for (Image *imageModel in _imageList) {
        
        NSString *imageUrl = imageModel.image;
        //将图片的url加入到数组中
        [images addObject:imageUrl];
    }


    //1.跳转到大图浏览页面
    PhotoViewController *ctrl = [[PhotoViewController alloc] init];
    //2.将所有图片的url交给大图浏览控制器
    ctrl.images = images;
    //3.将点击的单元格的位置传递给大图浏览控制器
    
    ctrl.indexPath = indexPath;
    //3.创建一个导航控制器
    NavViewController *nav = [[NavViewController alloc] initWithRootViewController:ctrl];
    [self presentViewController:nav animated:YES completion:NULL];

}




@end
