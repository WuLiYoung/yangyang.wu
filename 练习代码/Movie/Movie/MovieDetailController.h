//
//  MovieDetailController.h
//  Movie
//
//  Created by apple on 15/6/16.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "BaseViewController.h"

@interface MovieDetailController : BaseViewController<UITableViewDataSource,UITableViewDelegate>{


    NSMutableArray *commentArr;
    
    NSIndexPath *_indexPath;
}

@end
