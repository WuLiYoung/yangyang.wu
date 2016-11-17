//
//  ViewController.m
//  --ios同步下载图片
//
//  Created by 吴洋洋 on 16/1/6.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "ViewController.h"
#import "AppModel.h"

@interface ViewController ()
@property (nonatomic,strong) NSArray *appList;

@end

@implementation ViewController

- (NSArray *)appList
{
    if (_appList == nil) {
        _appList = [AppModel apps];
    }
    return _appList;
}



#pragma mark - 数据源方法
- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return self.appList.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *reuseID = @"appCell";
    
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:reuseID];
    
    //给cell设置数据
    AppModel *app = self.appList[indexPath.row];
    
    cell.textLabel.text = app.name;
    cell.detailTextLabel.text = app.download;
    
    //下载显示图片
    NSData *data = [NSData dataWithContentsOfURL:[NSURL URLWithString:app.icon]];
    UIImage *image = [UIImage imageWithData:data];
    cell.imageView.image = image;
    
    return cell;
}

@end
