//
//  MovieDetailController.m
//  Movie
//
//  Created by apple on 15/6/16.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "MovieDetailController.h"
#import "DataService.h"
#import "Comment.h"
#import "MovieDetaiModel.h"
#import "MovieHeaderView.h"
#import "CommentCell.h"
#import <MediaPlayer/MediaPlayer.h>

static NSString *identy = @"CommentCell";

@interface MovieDetailController ()

@end

@implementation MovieDetailController{

    MovieHeaderView *headerView;

}
/*
//如果控制器在故事版中,此方法会被调用
- (id)initWithCoder:(NSCoder *)aDecoder{
    
    self = [super initWithCoder:aDecoder];


}
*/
// alloc方式创建
- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil{

    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        
        self.hidesBottomBarWhenPushed = YES;
    }

    
    return self;
}
- (void)viewDidLoad {
    [super viewDidLoad];
    //评论视图
    [self _createCommentView];
    
    //1.加载评论数据
    [self _loadCommentData];
    
    //2.加载电影详情数据
    [self _loadMovieDetailData];
    
    
    //接受播放电影的通知
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(palyMovie) name:@"playMovieNotification" object:nil];
    

}

//播放电影
- (void)palyMovie{
    
// MPMoviePlayerViewController:视频播放控制器,需要导入<MediaPlayer/MediaPlayer.h>框架
    MPMoviePlayerViewController *ctrl = [[MPMoviePlayerViewController alloc] initWithContentURL:[NSURL URLWithString:@"http://vf1.mtime.cn/Video/2012/06/21/mp4/120621104820876931.mp4"]];
    
    //将视频播放器弹出
//  [self presentViewController:ctrl animated:YES completion:NULL];
    
    [self presentMoviePlayerViewControllerAnimated:ctrl];
    
}

- (void)_createCommentView{

    UITableView *tableView = [[UITableView alloc] initWithFrame:CGRectMake(0, 0, kScreenWidth, kScreenHeight) style:UITableViewStylePlain];
    tableView.backgroundColor = [UIColor clearColor];
    tableView.dataSource = self;
    tableView.delegate = self;
    [self.view addSubview:tableView];
    
    //加载头部视图
    headerView = [[[NSBundle mainBundle] loadNibNamed:@"MovieHeaderView" owner:nil options:nil] lastObject];
    headerView.height = 230;
    
    tableView.tableHeaderView = headerView;
    
    //注册单元格
    [tableView registerNib:[UINib nibWithNibName:@"CommentCell" bundle:nil] forCellReuseIdentifier:identy];


}

- (void)_loadMovieDetailData{

    NSDictionary *dic = [DataService loadJsonDataWithName:@"movie_detail.json"];
    
    MovieDetaiModel *movieDetailModel = [[MovieDetaiModel alloc] init];
    
    //KVC赋值
    [movieDetailModel setValuesForKeysWithDictionary:dic];
    
    //将数据交给头视图
    headerView.model = movieDetailModel;


}
- (void)_loadCommentData{
    
    NSDictionary *dic = [DataService loadJsonDataWithName:@"movie_comment.json"];
    NSArray *list = [dic objectForKey:@"list"];
    
    commentArr = [NSMutableArray array];
    for (NSDictionary *CommentDic in list) {

        Comment *comment = [[Comment alloc] init];
        
        //KVC赋值
        [comment setValuesForKeysWithDictionary:CommentDic];
        
        [commentArr addObject:comment];
    }

}

#pragma mark UITableViewDelegate
- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    
    return commentArr.count;

}

// Row display. Implementers should *always* try to reuse cells by setting each cell's reuseIdentifier and querying for available reusable cells with dequeueReusableCellWithIdentifier:
// Cell gets various attributes set automatically based on table (separators) and data source (accessory views, editing controls)

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {


    CommentCell *cell = [tableView dequeueReusableCellWithIdentifier:identy forIndexPath:indexPath];
    
    cell.comment = [commentArr objectAtIndex:indexPath.row];
    
    return cell;


}

//单元格高度
- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath{
    
    
    //获取到对应的model
    Comment *coment = commentArr[indexPath.row];
    
    NSString *content = coment.content;
    
    //根据文本计算高度,需要指定宽度,和字的大小  CoreText
    //此方法有警告,是因为7.0以后系统不建议使用此方法
    CGSize size =  [content sizeWithFont:[UIFont systemFontOfSize:14] constrainedToSize:CGSizeMake(225, 9999) lineBreakMode:NSLineBreakByWordWrapping];
    
    if (_indexPath.row == indexPath.row && _indexPath) {
        
        if ((size.height + 50) < 70) {
            
            return 70;
        }
        
        return size.height + 50;
    }
    
    return 70;
}

//点击单元格
- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath{

    //记录被点击的单元格的位置
    _indexPath = indexPath;
    
    //刷新单元格
    [tableView reloadData];


}

@end
