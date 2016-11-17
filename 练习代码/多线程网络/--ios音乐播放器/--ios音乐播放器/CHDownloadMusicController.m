//
//  CHDownloadMusicController.m
//  --ios音乐播放器
//
//  Created by 吴洋洋 on 16/3/4.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHDownloadMusicController.h"
#import "CHDownloadMusic.h"
#import "DMCell.h"
#import "MJExtension.h"
#import "CHDownloadTool.h"
#import "MBProgressHUD+MJ.h"

@interface CHDownloadMusicController ()

@property (nonatomic,strong) NSArray *array;


@end

@implementation CHDownloadMusicController

- (NSArray *)array
{
    if (_array == nil) {
        
        _array = [CHDownloadMusic objectArrayWithFilename:@"URL.plist"];
        
    }
    return _array;
}



- (void)viewDidLoad {
    [super viewDidLoad];
    
    //自动计算行高
    //self.tableView.rowHeight = UITableViewAutomaticDimension;
    
    self.tableView.backgroundView = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"backgroundImage"]];
    
    self.tableView.backgroundView.alpha = 0.8;
}



#pragma mark - Table view data source

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    return self.array.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
//    static NSString *reuseID = @"cell";
    
    DMCell *cell = [DMCell musicDownCellWithTableView:tableView];
    
    cell.btn.tag = indexPath.row + 100;
    
    [cell.btn addTarget:self action:@selector(download:) forControlEvents:UIControlEventTouchUpInside];
    
    CHDownloadMusic *d = self.array[indexPath.row];
    
    cell.dm = d;
    

    return cell;
}

- (void)download: (UIButton *)btn
{
    [MBProgressHUD showMessage:@"正在下载..."];
    
    //下载音乐
    [[CHDownloadTool sharedCHDownloadTool] downloadMusicWithUrl:self.array[btn.tag - 100]];
    
    
    if (_myBlock) {
        _myBlock(self.array[btn.tag - 100]);
      
    }
    
    //延时
    [NSTimer scheduledTimerWithTimeInterval:4.5 target:self selector:@selector(finish) userInfo:nil repeats:YES];
}

- (void)finish
{
    [MBProgressHUD hideHUD];
}


@end
