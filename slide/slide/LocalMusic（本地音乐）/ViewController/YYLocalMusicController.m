//
//  YYLocalMusicController.m
//  slide
//
//  Created by 吴洋洋 on 16/5/8.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYLocalMusicController.h"
#import "MJExtension.h"
#import "YYLocalMusicCell.h"
#import "YYLocalMusicModel.h"

#import "YYPlayMusicController.h"
#import "YYPlayTool.h"

@interface YYLocalMusicController () <AVAudioPlayerDelegate>

@property (nonatomic,strong) NSMutableArray *dataArr;

@property (nonatomic, strong) YYPlayMusicController *musicVC;

@end

@implementation YYLocalMusicController

- (NSMutableArray *)dataArr
{
    if (_dataArr == nil) {
        _dataArr = [YYLocalMusicModel mj_objectArrayWithFilename:@"songs.plist"];
    }
    return _dataArr;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    self.tableView.backgroundView = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"cm2_runfm_bg-ip6"]];
    
//    self.tableView.separatorStyle = UITableViewCellSeparatorStyleNone;

}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

#pragma mark - Table view data source

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {

    return self.dataArr.count;
}


- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    
    YYLocalMusicModel *model = self.dataArr[indexPath.row];
    
    YYLocalMusicCell *cell = [tableView dequeueReusableCellWithIdentifier:@"localMusicCell" forIndexPath:indexPath];
    
//    cell.selectionStyle = UITableViewCellSelectionStyleNone;
    
    cell.model = model;
    
    return cell;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    UIStoryboard *sb = [UIStoryboard storyboardWithName:@"Main" bundle:nil];
    
    YYLocalMusicCell *cell = [tableView cellForRowAtIndexPath:indexPath];
    
    if (_musicVC == nil) {
        _musicVC = [sb instantiateViewControllerWithIdentifier:@"sbPlayMusic"];
    }
    
    _musicVC.navigation = self.navigation;
    
    //歌曲名字
    _musicVC.navigationItem.title = [cell.model.songName isEqualToString:@" "] || cell.model.songName == nil ? @" " : cell.model.songName;
    //歌手名字
    _musicVC.singerName.text = [cell.model.singer isEqualToString:@" "] || cell.model.singer == nil ? @" " : cell.model.singer;
    //索引
    _musicVC.musicIndex = indexPath.row;
    
    [self.navigation pushViewController:_musicVC animated:YES];
    
//    [[YYPlayTool sharedYYPlayTool] preparePlayMusic:cell.model];
//    
//    [YYPlayTool sharedYYPlayTool].player.delegate = self;
//    
//    [[YYPlayTool sharedYYPlayTool] play];
    
}


@end
