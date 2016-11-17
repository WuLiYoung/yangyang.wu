//
//  YYMusicListController.m
//  slide
//
//  Created by 吴洋洋 on 16/5/3.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "YYMusicListController.h"
#import "YYBodyCell.h"
#import "YYTheaderCell.h"
#import "AFNetworking.h"
#import "MJExtension.h"
#import "MusicModel.h"
#import "NetworkHelper.h"

#import "BottomPlayView.h"
#import "YYPlayMusicController.h"
#import "YYModaController.h"
#import "MBProgressHUD.h"
#import "YYPlayToolOL.h"

@interface YYMusicListController ()<UITableViewDataSource,UITableViewDelegate,AVAudioPlayerDelegate>
{
    NSInteger pIndex; //上次播放的索引
}

//@property (nonatomic,strong) UIImageView *playingStateView;


@property (nonatomic,strong) NSMutableArray *dataArr;

@property (nonatomic, strong) NSMutableDictionary *userDict;

@property (nonatomic,strong) YYModaController *modaVC;



@end

@implementation YYMusicListController
- (NSMutableDictionary *)userDict
{
    if (_userDict == nil) {
        _userDict = [NSMutableDictionary dictionary];
    }
    return _userDict;
}
- (NSMutableArray *)dataArr
{
    if (_dataArr == nil) {
        _dataArr = [NSMutableArray array];
    }
    return _dataArr;
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    self.navigation.navigationBar.hidden = NO;

}

- (void)viewDidLoad {
    [super viewDidLoad];

//     self.playingStateView.image = [UIImage imageNamed:@"playLine"];
//    
//    self.playingStateView.animationImages = [NSArray arrayWithObjects:[UIImage imageNamed:@"line1"],[UIImage imageNamed:@"line2"],[UIImage imageNamed:@"line3"],[UIImage imageNamed:@"line4"], nil];
//    
//    self.playingStateView.animationDuration = 1.0;
//    
//    [self.playingStateView sizeToFit];
//    
//    self.navigationItem.rightBarButtonItem = [[UIBarButtonItem alloc] initWithCustomView:self.playingStateView];
    
    self.tableView.separatorStyle = UITableViewCellSeparatorStyleNone;
    
    self.navigationItem.title = self.navTitile;
   
    [self back];
 
    [self readData];
}

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView
{
    return 2;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return section == 0 ? 1 : self.dataArr.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    if (indexPath.section == 0) {
        YYTheaderCell *cell = [tableView dequeueReusableCellWithIdentifier:@"headCell" forIndexPath:indexPath];
        cell.listBgkImage.layer.cornerRadius = cell.frame.size.width / 5;
        
        cell.listBgkImage.layer.masksToBounds = YES;
        
        cell.userDict = self.userDict;
        
        cell.selectionStyle = UITableViewCellSelectionStyleNone;
        return cell;
    }else{
    
        MusicModel *model = self.dataArr[indexPath.row];
        
        YYBodyCell *cell = [tableView dequeueReusableCellWithIdentifier:@"bodyCell" forIndexPath:indexPath];
        
        cell.songName.text = [NSString stringWithFormat:@"%ld. %@",indexPath.row + 1,model.song_name];
        
        cell.model = model;
        
        cell.selectionStyle = UITableViewCellSelectionStyleNone;
        
        return cell;

    }
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{

    if (indexPath.section == 1) {
        
        YYBodyCell *cell = [tableView cellForRowAtIndexPath:indexPath];
        
        if (_modaVC == nil) {
        
            UIStoryboard *sb = [UIStoryboard storyboardWithName:@"Main" bundle:nil];
            
            _modaVC = [sb instantiateViewControllerWithIdentifier:@"sbModa"];
            
        }
        
        _modaVC.navigation = self.navigation;
        
    
        [self presentViewController:_modaVC animated:YES completion:^{
            
            _modaVC.musicIndex = indexPath.row;
            
            //歌曲名字
            _modaVC.songName.text = [cell.model.song_name isEqualToString:@" "] || cell.model.song_name == nil ? @" " : cell.model.song_name;
            //歌手名字
            _modaVC.singerName.text = [cell.model.singer_name isEqualToString:@" "] || cell.model.singer_name == nil ? @" " : cell.model.singer_name;
            
            [[YYPlayToolOL sharedYYPlayToolOL] prepareToPlayWithMusic:cell.model];
            
        }];
        
    }
}

- (IBAction)showPlay:(id)sender {
    
    if (_modaVC == nil)return;

    [self.navigation presentViewController:_modaVC animated:YES completion:^{
        
    }];
    
}



- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath
{
    if (indexPath.section == 0) {
        return 180;
    }else{
    
        return 71;
    }
}


//数据请求
- (void)readData
{
    if ([self.from isEqualToString:@"weekMusic"]) {
        [self readDataByFrom:[NSString stringWithFormat:@"http://api.dongting.com/channel/ranklist/%@/songs?page=1", self.msg_id]];
    } else if ([self.from isEqualToString:@"singerMusic"]) {
        [self readDataByFrom:[NSString stringWithFormat:@"http://api.dongting.com/song/singer/%@/songs?page=1&size=50",self.msg_id]];
    } else if ([self.from isEqualToString:@"songType"]) {
        [self readDataByFrom:[NSString stringWithFormat:@"http://api.dongting.com/channel/channel/%@/songs?size=50&page=1", self.msg_id]];
    } else {
        
        [[AFHTTPSessionManager manager] GET:[NSString stringWithFormat:@"http://api.songlist.ttpod.com/songlists/%@", self.msg_id] parameters:nil success:^(NSURLSessionDataTask *task, id responseObject) {
            
            NSMutableArray *tempArr = [NSMutableArray array];
            for (NSDictionary *dict in responseObject[@"songs"]) {
                //存放用户信息
                self.userDict = [NSMutableDictionary dictionaryWithDictionary:dict[@"user"]];
                [_userDict setValue:dict[@"pics"] forKey:@"pics"];
                for (NSDictionary *dict1 in dict[@"songlist"]) {
                    [tempArr addObject:dict1[@"_id"]];
                }
                MusicModel *model = [MusicModel new];
                [model setValuesForKeysWithDictionary:dict];
                [self.dataArr addObject:model];
            }
        
        [self.tableView reloadData];
        
    } failure:^(NSURLSessionDataTask *task, NSError *error) {
        
    }];
    }
}


- (void)readDataByFrom:(NSString *)fromUrl {
    [NetworkHelper JsonDataWithUrl:fromUrl success:^(id data) {
        for (NSDictionary *dict in data[@"data"]) {
            MusicModel *model = [MusicModel new];
            [model setValuesForKeysWithDictionary:dict];
            [self.dataArr addObject:model];
        }
        self.userDict = [NSMutableDictionary dictionaryWithObjects:@[@[self.pic_url], self.navTitile, [NSString stringWithFormat:@"共%ld首歌", (unsigned long)self.dataArr.count]] forKeys:@[@"pics", @"nick_name", @"label"]];
        
        [self.tableView reloadData];
    } fail:^{
        
    } view:self.view parameters:nil];
    
}


//设置返回
- (void)back
{
    UIBarButtonItem *leftBack = [[UIBarButtonItem alloc] initWithImage:[UIImage imageNamed:@"btn_back"] style:UIBarButtonItemStylePlain target:self action:@selector(back:)];
    self.navigationItem.leftBarButtonItem = leftBack;
}

- (void)back: (UIBarButtonItem *)item
{
    [self.navigation popViewControllerAnimated:YES];
}
@end
