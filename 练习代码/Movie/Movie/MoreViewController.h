//
//  MoreViewController.h
//  Movie
//
//  Created by apple on 15/6/3.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "BaseViewController.h"
@interface MoreViewController : BaseViewController<UITableViewDataSource,UITableViewDelegate>{

    NSArray *titles;
    NSArray *imageNames;
    UITableView *_tableView;

}

@end
