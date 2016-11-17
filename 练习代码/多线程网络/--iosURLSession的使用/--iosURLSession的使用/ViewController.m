//
//  ViewController.m
//  --iosURLSession的使用
//
//  Created by 吴洋洋 on 16/2/14.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "ViewController.h"

@interface ViewController ()

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    //1.url
    NSURL *url = [NSURL URLWithString:@"http://127.0.0.1/videos.json"];
    
    //2.session
    //苹果自带全局session
    NSURLSession *session = [NSURLSession sharedSession];
    
    //3.任务挂起,由session发起任务
    NSURLSessionTask *task = [session dataTaskWithURL:url completionHandler:^(NSData * _Nullable data, NSURLResponse * _Nullable response, NSError * _Nullable error) {
        id result = [NSJSONSerialization JSONObjectWithData:data options:0 error:NULL];
        
        NSLog(@"%@",result);
        
        //更新UI
        dispatch_async(dispatch_get_main_queue(), ^{
            NSLog(@"update UI");
        });
        
    }];
    
    //4.开始任务
    [task resume];
}

@end
