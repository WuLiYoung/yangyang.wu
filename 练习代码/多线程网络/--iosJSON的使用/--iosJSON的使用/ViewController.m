//
//  ViewController.m
//  --iosJSON的使用
//
//  Created by 吴洋洋 on 16/2/4.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "ViewController.h"
#import "JSONKit.h"

@interface ViewController ()

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];

    NSURL *url = [NSURL URLWithString:@"http://127.0.0.1/videos.json"];
    
    NSURLRequest *request = [NSURLRequest requestWithURL:url cachePolicy:0 timeoutInterval:2.0];
    
    [NSURLConnection sendAsynchronousRequest:request queue:[[NSOperationQueue alloc] init] completionHandler:^(NSURLResponse * _Nullable response, NSData * _Nullable data, NSError * _Nullable connectionError) {
        
        id result = [[JSONDecoder decoder] objectWithData:data];
        
        NSLog(@"result = %@",result);
    }];
}


@end
