//
//  CZOneViewController.m
//  传智微博
//
//  Created by apple on 15-3-4.
//  Copyright (c) 2015年 apple. All rights reserved.
//

#import "CZOneViewController.h"

@interface CZOneViewController ()

@end


@implementation CZOneViewController
//底层会调用initWithNibName
- (instancetype)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    return [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
//    self.tableView.separatorStyle = UITableViewCellSeparatorStyleNone;
    
}



//- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
//{
//    return 3;
//}
//
//- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
//{
//    static NSString *ID = @"cell";
//    
//    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:ID];
//    
//    if (cell == nil) {
//        cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:ID];
//        cell.backgroundColor = [UIColor clearColor];
//    }
//    
//    cell.textLabel.text = [NSString stringWithFormat:@"%ld",indexPath.row];
//    return cell;
//    
//}
@end
