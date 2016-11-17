//
//  CHMusicPlayerViewController.m
//  --ios音乐播放器
//
//  Created by 吴洋洋 on 15/12/22.
//  Copyright © 2015年 吴洋洋. All rights reserved.
//

#import "CHMusicPlayerViewController.h"
#import "CHPlayerToolbar.h"
#import "MJExtension.h"
#import "CHMusic.h"
#import "CHMusicCell.h"
#import "CHMusicTool.h"
#import "AppDelegate.h"
#import "MJRefresh.h"

#import "CHDownloadMusicController.h"
#import "CHMoreFunction.h"

@interface CHMusicPlayerViewController () <UITableViewDataSource,UITableViewDelegate,CHPlayerToolbarDelegate,AVAudioPlayerDelegate,UINavigationControllerDelegate>
@property (weak, nonatomic) IBOutlet UIView *bottomView;
@property (weak, nonatomic) IBOutlet UITableView *tableView;

@property (nonatomic,weak) CHPlayerToolbar *playerToolBar;

@property (nonatomic,strong) NSDictionary *dict;



//当前音乐播放的索引
@property (nonatomic,assign) NSInteger musicIndex;


@property (nonatomic,strong) NSMutableArray *musics;

@end

@implementation CHMusicPlayerViewController

#pragma mark - 懒加载音乐数据
- (NSMutableArray *)musics
{
    if (!_musics) {
        _musics = [CHMusic objectArrayWithFilename:@"songs.plist"].mutableCopy;
    }
    return _musics;
}


- (void)viewDidLoad {
    [super viewDidLoad];
    
    UIBarButtonItem *bit = [[UIBarButtonItem alloc] init];
    
    bit.title = @"返回";
    
    self.navigationItem.backBarButtonItem = bit;
    
        //    UIStoryboard *storyboard = [UIStoryboard storyboardWithName:@"Main" bundle:[NSBundle mainBundle]];
//    CHDownloadMusicController *DMVC = [storyboard instantiateViewControllerWithIdentifier:@"download"];
    [self setUpLeftItemBtn];

  
    [self.tableView addHeaderWithTarget:self action:@selector(newData)];
    
    [NSTimer scheduledTimerWithTimeInterval:1.0 target:self selector:@selector(endRefresh) userInfo:nil repeats:YES];
    
    
    // Do any additional setup after loading the view.
    //添加底部
    CHPlayerToolbar *toolbar = [CHPlayerToolbar playerToolBar];

    self.playerToolBar       = toolbar;

    [self.bottomView addSubview:toolbar];

    toolbar.delegate         = self;

//    //初始化 “音乐工具类”
//    [[CHMusicTool sharedCHMusicTool] prepareToPlayerWithMusic:self.musics[self.musicIndex]];
//    
//    //初始化播放的音乐
//    toolbar.playingMusic = self.musics[self.musicIndex];
//    
    [self playMusicNP];
    
    
    
}

- (void)setUpLeftItemBtn
{
    UIButton *btn = [UIButton buttonWithType:UIButtonTypeCustom];
    
    [btn setBackgroundImage:[UIImage imageNamed:@"MainTagSubIcon"] forState:UIControlStateNormal];
    [btn setBackgroundImage:[UIImage imageNamed:@"MainTagSubIconClick"] forState:UIControlStateHighlighted];
    [btn addTarget:self action:@selector(leftItemBtn) forControlEvents:UIControlEventTouchUpInside];
    
    [btn sizeToFit];
    
    UIBarButtonItem *BIT = [[UIBarButtonItem alloc] initWithCustomView:btn];
    
    self.navigationItem.leftBarButtonItem = BIT;
}

- (void)leftItemBtn
{
    CHMoreFunction *MF = [[CHMoreFunction alloc] init];
    
    [self.navigationController pushViewController:MF animated:YES];
}

- (void)newData
{
        
    [self.tableView reloadData];
        
}
    
    


- (void)setDict:(NSDictionary *)dict
{
    _dict = dict;
    
    [self.musics insertObject:dict atIndex:self.musics.count];
    
    
}

- (void)endRefresh
{
    [self.tableView headerEndRefreshing];
}


#pragma mark - 表格的数据源
- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)
section
{
    return self.musics.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    CHMusicCell *cell = [CHMusicCell musicCellWithTableView:tableView];
//    static NSString *reuseID  = @"musicCell";
//    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:reuseID];
   
    CHMusic *music = self.musics[indexPath.row];
    
//    cell.textLabel.text = music.name;
//    cell.detailTextLabel.text = music.singer;
    
    cell.musicScr = music;
   
    return cell;
    
}

#pragma mark - 播放工具条的代理方法
- (void)playerToolBar:(CHPlayerToolbar *)toolBar btnClickWithType:(BtnType)btntype
{
    //实现播放，把一个播放的操作放在一个工具类中
    switch (btntype) {
        case BtnTypePaly:
            [[CHMusicTool sharedCHMusicTool] play];
            break;
        case BtnTypePause:
            [[CHMusicTool sharedCHMusicTool] pause];
            break;
        case BtnTypePrevious:
            NSLog(@"上一首");
            [self previous];
            break;
        case BtnTypeNext:
            NSLog(@"下一首");
            [self next];
            break;
            
        default:
            break;
    }
}

#pragma mark - 下一首
- (void)next
{
    //更改播放的索引
    if (self.musicIndex == self.musics.count - 1) {
        self.musicIndex = 0;
    }
    else{
        self.musicIndex++;
    }
    
    NSLog(@"%ld",self.musicIndex);
    
    [self playMusicNP];
}

#pragma mark - 上一首
- (void)previous
{
    //更改播放的索引
    if (self.musicIndex == 0) {
        self.musicIndex = self.musics.count - 1;
    }
    else{
        self.musicIndex--;
    }
    
    NSLog(@"%ld",self.musicIndex);
    
    [self playMusicNP];
} 

- (void)playMusicNP
{
    // 重新初始化一个播放器
    [[CHMusicTool sharedCHMusicTool] prepareToPlayerWithMusic:self.musics[self.musicIndex]];
    
    //设置player的代理
    [CHMusicTool sharedCHMusicTool].player.delegate = self;
    
    // 更改 “音乐播放工具条”数据
    self.playerToolBar.playingMusic = self.musics[self.musicIndex];
  
    // 播放
    if (self.playerToolBar.playing) {
        [[CHMusicTool sharedCHMusicTool] play];
        
    }
    
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath
{
    return 45;
}

#pragma mark - 表格的选中
- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    self.musicIndex = indexPath.row;
    
    [self playMusicNP];
}

#pragma mark - player的代理方法

- (void)audioPlayerDidFinishPlaying:(AVAudioPlayer *)player successfully:(BOOL)flag
{
    [self next];
}

- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
//    __weak typeof(self) weakSelf = self;
    
    CHDownloadMusicController *vc = [segue destinationViewController];
    
    vc.myBlock = ^(NSDictionary *dic){
        
        self.dict = dic;
        
        
    };
}

@end
