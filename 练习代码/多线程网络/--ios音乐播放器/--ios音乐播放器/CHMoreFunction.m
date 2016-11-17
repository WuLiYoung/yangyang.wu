//
//  CHMoreFunction.m
//  --ios音乐播放器
//
//  Created by 吴洋洋 on 16/4/14.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHMoreFunction.h"
#import "CHLeftCell.h"
#import "CHRightCell.h"
#import "CHMF.h"
#import "MJExtension.h"

@interface CHMoreFunction () <UITableViewDataSource,UITableViewDelegate>
@property (weak, nonatomic) IBOutlet UITableView *leftTableView;
@property (weak, nonatomic) IBOutlet UITableView *rightTableView;
@property (nonatomic,strong) NSArray *leftArray;


@end

@implementation CHMoreFunction
 NSString * const leftCell  = @"leftCell";
 NSString * const rightCell = @"rightCell";

- (NSArray *)leftArray
{
    if (_leftArray == nil) {
        _leftArray = [CHMF objectArrayWithFilename:@"MORE.plist"].mutableCopy;
    }
    return _leftArray;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    [UIImage imageNamed:@"backgroundImage"];
    
    [self.leftTableView registerNib:[UINib nibWithNibName:NSStringFromClass([CHLeftCell class]) bundle:nil] forCellReuseIdentifier:leftCell];
    [self.rightTableView registerNib:[UINib nibWithNibName:NSStringFromClass([CHRightCell class]) bundle:nil] forCellReuseIdentifier:rightCell];

}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    if (tableView == self.leftTableView) {
        return self.leftArray.count;
    }else{
    
        return 0;
    }
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    
    
    if (tableView == self.leftTableView) {
        CHLeftCell *cell = [tableView dequeueReusableCellWithIdentifier:leftCell];
        
        cell.MF = self.leftArray[indexPath.row];
        
        return cell;

    }else{
        
        CHRightCell *cell = [tableView dequeueReusableCellWithIdentifier:rightCell];
        
        return cell;
        
        }
    
    
}

@end
