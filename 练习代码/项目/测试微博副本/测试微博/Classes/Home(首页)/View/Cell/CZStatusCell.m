//
//  CZStatusCell.m
//  微博
//
//  Created by 吴洋洋 on 16/2/23.
//  Copyright © 2016年 apple. All rights reserved.
//

#import "CZStatusCell.h"
#import "CZOriginalView.h"
#import "CZRetWeetView.h"
#import "CZToolBar.h"
#import "CZStatusFrame.h"
#import "CZPhotosView.h"
#import "CZStatus.h"

@interface CZStatusCell ()

@property (nonatomic,weak)  CZOriginalView *originalView;
@property (nonatomic,weak)  CZRetWeetView *retWeetView;
@property (nonatomic,weak)  CZToolBar *toolBar;
@property (nonatomic,weak)  CZPhotosView *photoView;



@end

@implementation CZStatusCell

#warning 初始化cell，用initWithStyle
- (instancetype)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier
{
    if (self = [super initWithStyle:style reuseIdentifier:reuseIdentifier]) {
        
        [self setUpAllChildView];
        
        self.backgroundColor = [UIColor clearColor];
    }
    return self;
}

//添加所有子控件
- (void)setUpAllChildView
{
    CZOriginalView *originalView = [[CZOriginalView alloc] init];
    
    [self addSubview:originalView];
    _originalView = originalView;
    
    CZRetWeetView *retWeetView = [[CZRetWeetView alloc] init];
    
    [self addSubview:retWeetView];
    _retWeetView = retWeetView;
    
    CZToolBar *toolBar = [[CZToolBar alloc] init];
    
    [self addSubview:toolBar];
    _toolBar =toolBar;
    
//    CZphotoView *photoView = [[CZphotoView alloc] init];
//    
//    [self addSubview:photoView];
//    _photoView = photoView;
}

+ (instancetype)cellWithTableView:(UITableView *)tableView
{
    static NSString *reuseID = @"Cell";
    id cell = [tableView dequeueReusableCellWithIdentifier:reuseID];
    
    if (cell == nil) {
        cell = [[self alloc] initWithStyle:UITableViewCellStyleSubtitle reuseIdentifier:reuseID];
    }
    return cell;
}

//重写
-(void)setStatusF:(CZStatusFrame *)statusF
{
    _statusF = statusF;
    
    //设置原创微博的frame
    _originalView.frame = statusF.oringinalViewFrame;
    _originalView.statusF = statusF;
    
    if (statusF.status.retweeted_status) {
         //设置转发微博的frame
        _retWeetView.frame = statusF.retweetViewFrame;
        _retWeetView.statusF = statusF;
        _retWeetView.hidden = NO;
        
    }else{
    
        _retWeetView.hidden = YES;
    }
   
    
    //设置toolbar的frame
    _toolBar.frame = statusF.toolBarFrame;
    
    
}

@end
