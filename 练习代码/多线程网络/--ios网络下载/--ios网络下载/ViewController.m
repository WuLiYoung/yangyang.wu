//
//  ViewController.m
//  --ios网络下载
//
//  Created by 吴洋洋 on 16/2/4.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "ViewController.h"

@interface ViewController ()

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];

    //1.url
    NSURL *url = [NSURL URLWithString:@"http://127.0.0.1/demo.json"];
    
    //2.建立请求
    NSURLRequest *request = [NSURLRequest requestWithURL:url cachePolicy:0 timeoutInterval:3];
    
    //3.建立连接
    [NSURLConnection sendAsynchronousRequest:request queue:[[NSOperationQueue alloc] init] completionHandler:^(NSURLResponse * _Nullable response, NSData * _Nullable data, NSError * _Nullable connectionError) {
        NSLog(@"解压缩---%@",[NSThread currentThread]);
        dispatch_async(dispatch_get_main_queue(), ^{
            NSLog(@"%@----%@",[[NSString alloc] initWithData:data encoding:NSUTF8StringEncoding],[NSThread currentThread]);

        });
    }];
}


@end
