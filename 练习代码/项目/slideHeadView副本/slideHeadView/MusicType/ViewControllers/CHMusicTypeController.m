//
//  CHMusicTypeController.m
//  slideHeadView
//
//  Created by 吴洋洋 on 16/4/26.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHMusicTypeController.h"
#import "CHMusicTypeCell.h"
#import "CHMusicTypeModel.h"
#import "MJExtension.h"

@interface CHMusicTypeController ()

@property (nonatomic,strong) NSArray *musicTypes;


@end

@implementation CHMusicTypeController

- (NSArray *)musicTypes
{
    if (_musicTypes == nil) {
        _musicTypes = [CHMusicTypeModel mj_objectArrayWithFilename:@"musicType.plist"];
    }
    return _musicTypes;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    
    [self.tableView registerNib:[UINib nibWithNibName:NSStringFromClass([CHMusicTypeCell class]) bundle:nil] forCellReuseIdentifier:@"cell"];
    
    self.tableView.rowHeight = 192;
    
    self.tableView.separatorStyle = UITableViewCellSeparatorStyleNone;
    
    
}

#pragma mark - UITableView数据源
- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return self.musicTypes.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    CHMusicTypeCell *cell = [tableView dequeueReusableCellWithIdentifier:@"cell" forIndexPath:indexPath];
    cell.model = self.musicTypes[indexPath.row];
    
    cell.selectionStyle = UITableViewCellSelectionStyleNone;
    
    return cell;
}

@end
