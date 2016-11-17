//
//  CHOneSearchController.m
//  slideHeadView
//
//  Created by 吴洋洋 on 16/4/28.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHOpenSearchController.h"
#import "AFNetworking.h"
#import "CHSearchController.h"

@interface CHOpenSearchController () <UISearchBarDelegate>

@property (nonatomic,strong) NSMutableArray *dataArr;
@property (weak, nonatomic) IBOutlet UISearchBar *searchBar;
@property (weak, nonatomic) IBOutlet UIButton *one;
@property (weak, nonatomic) IBOutlet UIButton *two;
@property (weak, nonatomic) IBOutlet UIButton *three;
@property (weak, nonatomic) IBOutlet UIButton *four;
@property (weak, nonatomic) IBOutlet UIButton *five;
@property (weak, nonatomic) IBOutlet UIButton *six;

@end

@implementation CHOpenSearchController

- (NSMutableArray *)dataArr
{
    if (_dataArr == nil) {
        _dataArr = [NSMutableArray array];
    }
    return _dataArr;
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    if (self.dataArr.count > 0) {
        return;
    }
    [self readSearchData];
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    self.searchBar.delegate = self;
}

//searchBar禁止编辑
- (BOOL)searchBarShouldBeginEditing:(UISearchBar *)searchBar
{
    return NO;
}

- (void)readSearchData
{
    [[AFHTTPSessionManager manager] GET:@"http://so.ard.iyyin.com/sug/billboard" parameters:nil success:^(NSURLSessionDataTask *task, id responseObject) {
        
        NSLog(@"%@",responseObject);
        
        for (NSDictionary *dict in responseObject[@"data"]) {
            [_dataArr addObject:dict[@"val"]];
        }
        [self.one setTitle:_dataArr[0] forState:UIControlStateNormal];
        [self.two setTitle:_dataArr[1] forState:UIControlStateNormal];
        [self.three setTitle:_dataArr[2] forState:UIControlStateNormal];
        [self.four setTitle:_dataArr[3] forState:UIControlStateNormal];
        [self.five setTitle:_dataArr[4] forState:UIControlStateNormal];
        [self.six  setTitle:_dataArr[5] forState:UIControlStateNormal];

        
    } failure:^(NSURLSessionDataTask *task, NSError *error) {
    
    }];
}

//搜索按钮
- (IBAction)openSearchBtn:(id)sender {
    
    CHSearchController *vc = [self.storyboard instantiateViewControllerWithIdentifier:@"chSearch"];
    
    vc.navigation = self.navigation;
    vc.keyWord = @" ";
    
    [self.navigation pushViewController:vc animated:YES];
    
}

//大家在搜，推荐
- (IBAction)recommendBtn:(UIButton *)btn {
    
    UIStoryboard *sb = [UIStoryboard storyboardWithName:@"Main" bundle:nil];
    
    CHSearchController *vc = [sb instantiateViewControllerWithIdentifier:@"chSearch"];
    
    vc.navigation = self.navigation;
    vc.keyWord = [btn.currentTitle isEqualToString:@" "] || btn.currentTitle == nil ? @" " : btn.currentTitle;
    
    [self.navigation pushViewController:vc animated:YES];
    
}

@end
