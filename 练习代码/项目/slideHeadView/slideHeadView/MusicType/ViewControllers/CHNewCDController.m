//
//  CHNewCDController.m
//  slideHeadView
//
//  Created by 吴洋洋 on 16/5/1.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHNewCDController.h"

@interface CHNewCDController () 
@property (weak, nonatomic) IBOutlet UICollectionView *collectionView;
@property (weak, nonatomic) IBOutlet UICollectionViewFlowLayout *flow;

@end

@implementation CHNewCDController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    
}

//设置返回按钮
- (void)setBackBtn
{
    UIBarButtonItem *btn = [[UIBarButtonItem alloc] initWithImage:[UIImage imageNamed:@"btn_back"] style:UIBarButtonItemStylePlain target:self action:@selector(back:)];
    
    self.navigationItem.leftBarButtonItem = btn;
    self.navigation.title = self.navTitle;
    
}

- (void)back: (UIBarButtonItem *)item
{
    [self.navigation popToRootViewControllerAnimated:YES];
}


@end
