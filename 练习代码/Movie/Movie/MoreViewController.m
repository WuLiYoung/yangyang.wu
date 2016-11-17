//
//  MoreViewController.m
//  Movie
//
//  Created by apple on 15/6/3.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "MoreViewController.h"
#import "SDImageCache.h"

@interface MoreViewController ()

@end

@implementation MoreViewController
- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    
    if (self) {
        self.title = @"更多";
    
        
    }
    return self;
    
}
- (void)viewDidLoad {
    [super viewDidLoad];
    
    //创建视图
    [self _createTableView];
    
    //加载数据
    [self _loadData];
        
}

- (void)viewWillAppear:(BOOL)animated{

    [super viewWillAppear:animated];
    [_tableView reloadData];

}

- (void)_loadData{


    titles = @[@"清除缓存",@"给个评价",@"检查新版本",@"商务合作",@"欢迎页",@"关于"];
    imageNames = @[@"moreClear@2x.png",@"moreScore@2x.png",@"moreVersion@2x.png",@"moreBusiness@2x.png",@"moreWelcome@2x.png",@"moreAbout@2x.png"];

}
- (void)_createTableView{


    _tableView = [[UITableView alloc] initWithFrame:CGRectMake(0, 0, kScreenWidth, kScreenHeight) style:UITableViewStyleGrouped];
    _tableView.dataSource = self;
    
    _tableView.delegate = self;
    _tableView.backgroundColor = [UIColor clearColor];
    [self.view addSubview:_tableView];

}
- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {

    return titles.count;
}

// Row display. Implementers should *always* try to reuse cells by setting each cell's reuseIdentifier and querying for available reusable cells with dequeueReusableCellWithIdentifier:
// Cell gets various attributes set automatically based on table (separators) and data source (accessory views, editing controls)

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    
    static NSString *indenty = @"cell";
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:indenty];
    
    if (cell == nil) {
        
        
        cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:indenty];
        cell.backgroundColor = [UIColor clearColor];
        
        //1.创建图片视图
        UIImageView *imageView = [[UIImageView alloc] initWithFrame:CGRectMake(10, 10, 40, 40)];
        imageView.tag = 1;
        [cell.contentView addSubview:imageView];
        //2.标题视图
        UILabel *titlelable = [[UILabel alloc] initWithFrame:CGRectMake(imageView.right + 30, 15, 200, 30)];
        titlelable.tag = 2;
        titlelable.font = [UIFont boldSystemFontOfSize:18];
        titlelable.textColor = [UIColor whiteColor];
        [cell.contentView addSubview:titlelable];
        
        //单元格选中效果
        cell.selectionStyle = UITableViewCellSelectionStyleNone;
        
        if (indexPath.row == 0) {
            
            UILabel *cacheLable = [[UILabel alloc] initWithFrame:CGRectMake(kScreenWidth - 70, 15, 60, 30)];
            cacheLable.textAlignment = NSTextAlignmentCenter;
            cacheLable.tag = 3;
            cacheLable.font = [UIFont boldSystemFontOfSize:18];
            cacheLable.textColor = [UIColor whiteColor];
            [cell.contentView addSubview:cacheLable];
        }
        
    }
    
    //2.填充信息
    UIImageView *imageView = (UIImageView *)[cell.contentView viewWithTag:1];
    UILabel *lable = (UILabel *)[cell.contentView viewWithTag:2];
    
    imageView.image = [UIImage imageNamed:imageNames[indexPath.row]];
    lable.text = titles[indexPath.row];
    
    UILabel *cacheLable = (UILabel *)[cell.contentView viewWithTag:3];
    
    //SD计算缓存数量
    NSUInteger count = [[SDImageCache sharedImageCache] getSize];
    cacheLable.text = [NSString stringWithFormat:@"%.1lfM",count / 1024 / 1024.0];
    
    return cell;
}
- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath{

    return 60;

}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath{

    if (indexPath.row == 0) {
        
        //弹出视图
        UIAlertView *alertView = [[UIAlertView alloc] initWithTitle:@"提示" message:@"是否清除缓存" delegate:self cancelButtonTitle:@"取消" otherButtonTitles:@"确定", nil];
        [alertView show];
    }


}
- (void)alertView:(UIAlertView *)alertView clickedButtonAtIndex:(NSInteger)buttonIndex {

    //确定按钮被点击
    
    if (buttonIndex == 1) {
        
        //清理缓存
         [[SDImageCache sharedImageCache] clearDisk];
        //刷新表视图
        [_tableView reloadData];
    }

}
@end
