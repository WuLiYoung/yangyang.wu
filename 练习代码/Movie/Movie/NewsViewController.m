//
//  NewsViewController.m
//  Movie
//
//  Created by apple on 15/6/3.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "NewsViewController.h"
#import "DataService.h"
#import "News.h"
#import "Common.h"
#import "NewsCell.h"
#import "UIImageView+WebCache.h"
#import "UIViewExt.h"
#import "ImageListController.h"
#import "NewDetailController.h"
@interface NewsViewController ()

@end

@implementation NewsViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    
    if (self) {
        self.title = @"新闻";
    }
    return self;

}

//loadView -->  view = nil   view是否被访问
- (void)viewDidLoad {
    [super viewDidLoad];
    
    // M - C -V  MVC  控制器瘦身
    //1.加载数据
    [self _loadNewsData];
    
    //2.创建视图
    [self _creatNewsListView];
    
    //3.创建头视图
    [self _createHeaderView];

  }

- (void)_creatNewsListView{

    _tableView = [[UITableView alloc] initWithFrame:CGRectMake(0, 0, kScreenWidth, kScreenHeight) style:UITableViewStylePlain];
    [self.view addSubview:_tableView];
    _tableView.backgroundColor = [UIColor clearColor];
    _tableView.dataSource = self;
    _tableView.delegate = self;
    
    //注册单元格的方式
    /*
     1.注册类
    [_tableView registerClass:<#(__unsafe_unretained Class)#> forCellReuseIdentifier:<#(NSString *)#>];
     2.注册nib(当单元格携带xib文件时,使用此种方式)
     [_tableView registerNib:<#(UINib *)#> forCellReuseIdentifier:<#(NSString *)#>];
     
     以上两种方式配合
     [tableView dequeueReusableCellWithIdentifier:<#(NSString *)#> forIndexPath:<#(NSIndexPath *)#>]方法可以简化单元格的创建,不需要判断单元格是否为空
     */
    
    //1.创建nib对象
    UINib *nib = [UINib nibWithNibName:@"NewsCell" bundle:[NSBundle mainBundle]];
    //2.注册nib
    [_tableView registerNib:nib forCellReuseIdentifier:@"cell"];
    
    //UITableView  -> 注册单元格 <- UICollectionView
}

- (void)_createHeaderView{

    //创建头视图
    UIView *headerView = [[UIView alloc] initWithFrame:CGRectMake(0, 0, 0, 200)];
    //背景设置为透明
    headerView.backgroundColor = [UIColor clearColor];
    [_tableView setTableHeaderView:headerView];
    
    imageView = [[UIImageView alloc] initWithFrame:CGRectMake(0, 64, kScreenWidth, 200)];
    //取出第一个新闻model
    News *news = [newsList firstObject];
    //显示第一张图片
    [imageView sd_setImageWithURL:[NSURL URLWithString:news.image]];
    
    [self.view addSubview:imageView];
    //删除第一条数据,防止重复
    if (newsList.count > 0) {
        
        [newsList removeObjectAtIndex:0];
    }
    

}
- (void)_loadNewsData{

    NSArray *array = [DataService loadJsonDataWithName:@"news_list.json"];
    
    newsList = [NSMutableArray array];
    for (NSDictionary *dic in array) {
        News *news = [[News alloc] init];
        /*
        NSString *title = dic[@"title"];
        NSString *summary = dic[@"summary"];
        NSString *image = dic[@"image"];
        NSInteger type = [dic[@"type"] integerValue];
        
        news.title = title;
        news.image = image;
        news.summary = summary;
        news.type = type;
        */
        
        //iOS实战编程  iOS7
        //通过KVC的方式赋值
        [news setValuesForKeysWithDictionary:dic];
        [newsList addObject:news];
        /*
            {
                    name : zhangsan
                    age  : 13
                    height : 1.7
         
            }
         
         Person类:  name  age   height
         
         
         */
    }
    [_tableView reloadData]; //加载网络数据时,必须要刷新,有数据重新刷新表视图

}

- (UIStatusBarStyle)preferredStatusBarStyle{
    
    return UIStatusBarStyleLightContent;

}

#pragma mark UITableViewDelegate
- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    return newsList.count;

}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath{
    /*
    static NSString *identy = @"Cell";
    //从复用池中寻找单元格
    NewsCell *cell = [tableView dequeueReusableCellWithIdentifier:identy];
    
    //单元格为空
    if (cell == nil) {
        
        //创建单元格(alloc,xib)
        cell = [[[NSBundle mainBundle] loadNibNamed:@"NewsCell" owner:nil options:nil] lastObject];
    }
    */
    
    //dequeueReusableCellWithIdentifier:先从复用池中寻找单元格,如果没有,就创建,根据注册的方式创建单元格,如果注册的是nib,则去加载xib,如果注册的是类,则alloc方式创建
    NewsCell *cell = [tableView dequeueReusableCellWithIdentifier:@"cell" forIndexPath:indexPath];
    
    //取出对应的新闻model
    News *news = [newsList objectAtIndex:indexPath.row];
    //将新闻数据交给视图
    cell.news = news;

    return cell;
}
- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath{

    return 90;

}

//单元格被点击
- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath{
    
    //取到对应的model
    News *news = [newsList objectAtIndex:indexPath.row];
    //判断新闻类型
    if (news.type == kWordType) {
        
        NewDetailController *news = [[NewDetailController alloc] init];
//        news.hidesBottomBarWhenPushed = YES;
        
        [self.navigationController pushViewController:news animated:YES];
        
    }else if(news.type == kImageType){
    
        ImageListController *ctrl = [[ImageListController alloc] init];
        [self.navigationController pushViewController:ctrl animated:YES];
    }else if(news.type == kVideoType){
    
        NSLog(@"视频新闻");
    
    }

}

#pragma mark UIScrollViewDelegate
- (void)scrollViewDidScroll:(UIScrollView *)scrollView{
    
//    NSLog(@"%lf",scrollView.contentOffset.y);

    //偏移量
    CGFloat offset = scrollView.contentOffset.y;
    
    if (offset > -64) { //向上滑
        
        imageView.top = -offset;
        
    }else{ //向下滑
    
    //1. 增大后的高度
    CGFloat newHeight = ABS(offset) - 64 + 200;
    //width / height = newWidth / newHeight  等比例缩放
    
    //2. 增大后的宽度
    CGFloat newWidth = kScreenWidth / 200 * newHeight;
    
    //3. 左移图片变宽的距离的一半你
    imageView.frame = CGRectMake(-(newWidth - kScreenWidth) / 2, 64, newWidth, newHeight);
    
    }

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
