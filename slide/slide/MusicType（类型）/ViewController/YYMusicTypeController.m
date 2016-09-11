//
//  YYMusicTypeController.m
//  slide
//
//  Created by 吴洋洋 on 16/5/3.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYMusicTypeController.h"
#import "YYMusicTypeCell.h"
#import "YYMusicTypeModel.h"
#import "MJExtension.h"
#import "ABViewController.h"
#import "YYNewSongController.h"
#import "YYSingerController.h"

@interface YYMusicTypeController () <UITableViewDataSource,UITableViewDelegate>

@property (nonatomic,strong) NSArray *dataArr;


@end

@implementation YYMusicTypeController
static NSString *reuseID = @"cell";
- (NSArray *)dataArr
{
    if (_dataArr == 0) {
        _dataArr = [YYMusicTypeModel mj_objectArrayWithFilename:@"musicType.plist"];
    }
    return _dataArr;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    
    [self.tableView registerNib:[UINib nibWithNibName:NSStringFromClass([YYMusicTypeCell class]) bundle:nil] forCellReuseIdentifier:reuseID];
    
    self.tableView.separatorStyle = UITableViewCellSeparatorStyleNone;
    
    self.tableView.rowHeight = 192;
  
}



- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return self.dataArr.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    YYMusicTypeCell *cell = [tableView dequeueReusableCellWithIdentifier:reuseID forIndexPath:indexPath];
    
    cell.model = self.dataArr[indexPath.row];
    
    cell.selectionStyle = UITableViewCellSelectionStyleNone;
    
    return cell;
} 

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    if (indexPath.row == 0) {
        
        UIStoryboard *sb = [UIStoryboard storyboardWithName:@"Main" bundle:nil];
        
        YYNewSongController *vc = [sb instantiateViewControllerWithIdentifier:@"sbCollection"];
        
        vc.navigation = self.navigation;
        
        [self.navigation pushViewController:vc animated:YES];
        
    }
    else if (indexPath.row == 1)
    {
        
        UIStoryboard *sb = [UIStoryboard storyboardWithName:@"Main" bundle:nil];
        
        YYNewSongController *vc = [sb instantiateViewControllerWithIdentifier:@"sbSongType"];
        
        vc.navigation = self.navigation;
        
        [self.navigation pushViewController:vc animated:YES];

    }
    
    else if (indexPath.row == 2)
    {
        
        UIStoryboard *sb = [UIStoryboard storyboardWithName:@"Main" bundle:nil];
        
        YYSingerController *vc = [sb instantiateViewControllerWithIdentifier:@"sbSingerType"];
        
        vc.navigation = self.navigation;
        
        [self.navigation pushViewController:vc animated:YES];

    }
}

@end
