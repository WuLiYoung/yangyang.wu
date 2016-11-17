//
//  MovieViewController.h
//  Movie
//
//  Created by apple on 15/6/3.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "PosterView.h"
#import "BaseViewController.h"
@interface MovieViewController : BaseViewController<UITableViewDataSource,UITableViewDelegate>{

    UITableView *_tableView;
    PosterView *_posterView;
    
    NSMutableArray *movieList; //model数组
}

@end
