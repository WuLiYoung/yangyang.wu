//
//  CHRecommendTagsController.m
//  --ios百思不得其姐
//
//  Created by 吴洋洋 on 16/4/5.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHRecommendTagsController.h"
#import "CHRecommendTags.h"
#import "AFNetworking.h"
#import "MJExtension.h"
#import "MJRefresh.h"
#import "CHTagCell.h"

@interface CHRecommendTagsController ()

@property (nonatomic,strong) NSArray *tags;



@end

@implementation CHRecommendTagsController

- (NSArray *)tags
{
    if (_tags ==nil) {
        _tags = [NSArray array];
        
    }
    return _tags;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    [self setUpTableView];
    
    [self loadTagsData];
    
    
}

- (void)setUpTableView
{
    self.title = @"推荐标签";
    
    self.tableView.rowHeight = 80;
    
    self.view.backgroundColor = CHRGBColor(224,224,224);
    
    //注册cell
    [self.tableView registerNib:[UINib nibWithNibName:NSStringFromClass([CHTagCell class]) bundle:nil] forCellReuseIdentifier:@"cell"];
}

- (void)loadTagsData
{
    NSMutableDictionary *parames = [NSMutableDictionary dictionary];
    parames[@"a"] = @"tag_recommend";
    parames[@"action"] = @"sub";
    parames[@"c"] = @"topic";
    
    
    [[AFHTTPSessionManager manager] GET:@"http://api.budejie.com/api/api_open.php" parameters:parames success:^(NSURLSessionDataTask *task, id responseObject) {
        
        CHLog(@"%@",responseObject);
        
        self.tags = [CHRecommendTags mj_objectArrayWithKeyValuesArray:responseObject];
        
        [self.tableView reloadData];
        
    } failure:^(NSURLSessionDataTask *task, NSError *error) {
        
    }];
    

}

#pragma mark - Table view data source



- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {

    return self.tags.count;
}


- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    
    static NSString *const reuseID = @"cell";
    
    CHTagCell *cell = [tableView dequeueReusableCellWithIdentifier:reuseID];
    
    cell.recommendTag = self.tags[indexPath.row];
    
    return cell;
}



@end
