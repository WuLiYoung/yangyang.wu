//
//  GuideViewController.h
//  WXMovie
//
//  Created by mac on 15/3/11.
//  Copyright (c) 2015年 mac. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface GuideViewController : UIViewController<UIScrollViewDelegate>{


    IBOutlet UIScrollView *_scrollView;
    
    IBOutlet UIButton *_btn;

}

- (IBAction)btnAction:(id)sender;
@end
