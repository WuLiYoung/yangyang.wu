//
//  NewsViewController.h
//  Movie
//
//  Created by apple on 15/6/3.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "BaseViewController.h"
@interface NewsViewController : BaseViewController<UITableViewDataSource,UITableViewDelegate>{

    NSMutableArray *newsList;
    UITableView *_tableView;
    UIImageView *imageView;

}



@end
