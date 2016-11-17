//
//  PhotoViewController.h
//  Movie
//
//  Created by apple on 15/6/10.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface PhotoViewController : UIViewController{

    BOOL isHide;

}

@property(nonatomic,retain)NSArray *images;//图片的url
@property(nonatomic,retain)NSIndexPath *indexPath; //单元格wei'zhi
@end
