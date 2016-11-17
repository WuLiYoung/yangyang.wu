//
//  MovieViewController.m
//  Movie
//
//  Created by apple on 15/6/3.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "MovieViewController.h"
#import "Common.h"
#import "Movie.h"
#import "MovieCell.h"
@interface MovieViewController ()

@end
@implementation MovieViewController
#pragma mark -viewCtrl life
- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    
    if (self) {
        self.title = @"首页";
        
    }
    return self;
    
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    //1.设置导航栏按钮
    [self _creatNavItems];
    
    //3.创建电影列表视图
    [self _createMovieListView];
    
    //2.创建大海报页面
    [self _creatPosterView];
    
    // 文本数据的格式: JSON 无关于语言
    
    //解析JSON  iOS5以前 有一些开源类可以解析JSON  TouchJSON  SBJSON  JSONKit
    //         iOS5以后苹果提供了 NSJSONSerialization类可以解析JSON数据
    
    /*
        {} : OC中的字典   java  Map
        [] : OC中的数组   java  List
     */
    /*
    //1.读取JSON文件   data  data1
    NSString *filePath = [[NSBundle mainBundle] pathForResource:@"movieList.json" ofType:nil];
    //2. NSData存储数据,将JSON文件中的文本数据存入到data中
    NSData *JsonData = [NSData dataWithContentsOfFile:filePath];
    
    //3.解析JsonData中的文本数据  返回对应的数组或字典
    id moviearr = [NSJSONSerialization JSONObjectWithData:JsonData options:NSJSONReadingMutableContainers error:nil];
    NSLog(@"%@",moviearr);
     */
    
   // 1.加载数据
    //读取JSON文件的路径
    NSString *filePath = [[NSBundle mainBundle] pathForResource:@"us_box_old.json" ofType:nil];
    //NSData读取文件内容
    NSData *movieListData = [NSData dataWithContentsOfFile:filePath];
    
    //解析JSON
    NSDictionary *movieListDic = [NSJSONSerialization JSONObjectWithData:movieListData options:NSJSONReadingMutableContainers error:nil];
    
    //1. 取出电影数组
    NSArray *movieListArr = [movieListDic objectForKey:@"subjects"];
    
    //2. 创建可变数组,用于存储model
    movieList = [NSMutableArray array];
    
    //3. 将数据存储到model中  电影Model对象 -->存储一个电影的信息
    //遍历 movieListDic中的字典,将字典中的数据取出存储到model对应的属性中
    for (NSDictionary *movieDic in movieListArr) {
        
        //创建电影model对象
        Movie *movie = [[Movie alloc] init];
        
        NSDictionary *subject = [movieDic objectForKey:@"subject"];
        //电影标题
        NSString *title = [subject objectForKey:@"title"];
        //电影分数
        NSNumber *number = [[subject objectForKey:@"rating"] objectForKey:@"average"];
        //取出电影图片
        NSDictionary *imageDic = [subject objectForKey:@"images"];
        //电影时间
        NSString *year = [subject objectForKey:@"year"];
        NSString *original_title = [subject objectForKey:@"original_title"];
        
        //给model对象填充数据
        movie.title = title;
        movie.average = [number floatValue];
        movie.images = imageDic;
        movie.year = year;
        movie.original_title = original_title;
        
        //将model添加到数组中
        [movieList addObject:movie];
        
//      [movie setValuesForKeysWithDictionary:<#(NSDictionary *)#>];
        
        
    }
    //刷新表视图
    [_tableView reloadData];
    
    //将数据交给海报页面
    _posterView.movieList = movieList;
 }


/*
    iOS7以后,表视图高度为屏幕高度时:
    表视图高度为屏幕高时:内容会自动偏移
    1. 导航栏和标签栏要半透明
    2. 表示图要是第一个被添加到控制器上的视图
 
 */

- (void)viewDidAppear:(BOOL)animated{

    [super viewDidAppear:animated];
    
    UIEdgeInsets edge = _tableView.contentInset;
    NSLog(@"%@",NSStringFromUIEdgeInsets(edge));

}

#pragma mark -movie list
- (void)_createMovieListView{
    

    _tableView = [[UITableView alloc] initWithFrame:CGRectMake(0, 0, kScreenWidth, kScreenHeight) style:UITableViewStylePlain];
    _tableView.backgroundColor = [UIColor clearColor];
    _tableView.dataSource = self;
    _tableView.delegate = self;
    _tableView.hidden = YES;
    
    //分割线颜色
    _tableView.separatorColor = [UIColor darkGrayColor];
    [self.view addSubview:_tableView];

}

#pragma mark -poster view
- (void)_creatPosterView{

    _posterView = [[PosterView alloc] initWithFrame:CGRectMake(0, 0, kScreenWidth, kScreenHeight)];
    [self.view addSubview:_posterView];
    
    //

}

#pragma mark -nav items
- (void)_creatNavItems{

    //PCH
    //1. 设置导航栏上的标题
    UILabel *titleLable = [[UILabel alloc] initWithFrame:CGRectZero];
    titleLable.text = @"首页";
    titleLable.textColor = [UIColor whiteColor];
    [titleLable sizeToFit];
    self.navigationItem.titleView = titleLable;
    
    // 2.创建右侧按钮
    // 创建翻转父视图
    UIView *flipView = [[UIView alloc] initWithFrame:CGRectMake(0, 0, 50, 30)];
    
    UIButton *btn1 = [UIButton buttonWithType:UIButtonTypeCustom];
    [btn1 setBackgroundImage:[UIImage imageNamed:@"exchange_bg_home.png"] forState:UIControlStateNormal];
    btn1.tag = 1;
    [btn1 setImage:[UIImage imageNamed:@"list_home.png"] forState:UIControlStateNormal];
    [btn1 sizeToFit]; //poster_home.png
    [btn1 addTarget:self action:@selector(clickAction:) forControlEvents:UIControlEventTouchUpInside];
    btn1.hidden = YES;
    [flipView addSubview:btn1];
    
    UIButton *btn2 = [UIButton buttonWithType:UIButtonTypeCustom];
    [btn2 setBackgroundImage:[UIImage imageNamed:@"exchange_bg_home.png"] forState:UIControlStateNormal];
    btn2.tag = 2;
    [btn2 setImage:[UIImage imageNamed:@"poster_home.png"] forState:UIControlStateNormal];
    [btn2 addTarget:self action:@selector(clickAction:) forControlEvents:UIControlEventTouchUpInside];
    [btn2 sizeToFit];
    [flipView addSubview:btn2];
    
    UIBarButtonItem *rightItem = [[UIBarButtonItem alloc] initWithCustomView:flipView];
    self.navigationItem.rightBarButtonItem = rightItem;
  }

#pragma mark -actions
- (void)clickAction:(UIButton *)btn{
    //获取到flipView
    UIView *flipView = self.navigationItem.rightBarButtonItem.customView;
    
    //取得需要翻转的按钮
    UIView *btn1 = [flipView viewWithTag:1];
    UIView *btn2 = [flipView viewWithTag:2];
    
    //是否从左侧翻转
    BOOL isLeft = btn1.hidden;
    
    //翻转视图
    [self _flipWithView:flipView isLeft:isLeft];
    [self _flipWithView:self.view isLeft:isLeft];
    
    //改变按钮显示状态
    btn1.hidden = !btn1.hidden;
    btn2.hidden = !btn2.hidden;
    
    //切换海报视图与电影列表视图
    _posterView.hidden = !_posterView.hidden;
    _tableView.hidden = !_tableView.hidden;
    
}

#pragma mark -flip animation
/*
    view:需要翻转的视图
    isLeft :是否从左侧翻转
 */
- (void)_flipWithView:(UIView *)view isLeft:(BOOL)isLeft{
    
    //翻转的效果 枚举
    UIViewAnimationOptions option = isLeft ? UIViewAnimationOptionTransitionFlipFromLeft : UIViewAnimationOptionTransitionFlipFromRight;
    
    [UIView transitionWithView:view duration:.3 options:option animations:NULL completion:NULL];
}

#pragma mark -UITableViewDelegate
- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    
    return movieList.count;

}
- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {

    static NSString *identy = @"cell";
    
    MovieCell *cell = [tableView dequeueReusableCellWithIdentifier:identy];
    if (cell == nil) {
        //如果单元格绑定了一个xib,那么就不要用alloc方式创建单元格
//        cell = [[MovieCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:identy];
        cell = [[[NSBundle mainBundle] loadNibNamed:@"MovieCell" owner:nil options:nil] lastObject];
        
    }
    
    //去到对应的model对象
    Movie *movie = [movieList objectAtIndex:indexPath.row];
    
    //讲数据交给view显示
    cell.movie = movie;
    
    return cell; // cell加到tableView上, [tableView addsubview: cell]; -->  cell(layoutSubView)
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath{

    return 90;

}

@end
