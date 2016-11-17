//
//  ViewController.m
//  --iosRULSession解压缩
//
//  Created by 吴洋洋 on 16/2/14.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "ViewController.h"
#import "SSZipArchive.h"

@interface ViewController ()

@end

@implementation ViewController

- (void)touchesBegan:(NSSet<UITouch *> *)touches withEvent:(UIEvent *)event
{
    NSString *urlStr       = @"http://127.0.0.1/itcast/images.zip";

    urlStr                 = [urlStr stringByAddingPercentEscapesUsingEncoding:NSUTF8StringEncoding];

    NSURL *url             = [NSURL URLWithString:urlStr];

    NSURLSession *session  = [NSURLSession sharedSession];

    //下载
    NSURLSessionTask *task = [session downloadTaskWithURL:url completionHandler:^(NSURL * _Nullable location, NSURLResponse * _Nullable response, NSError * _Nullable error) {
        
        NSLog(@"文件路径%@",location.path);
        
        NSString *cacheDir = [NSSearchPathForDirectoriesInDomains(NSCachesDirectory, NSUserDomainMask, YES) lastObject];
        
        [SSZipArchive unzipFileAtPath:location.path toDestination:cacheDir];
    }];
    
    [task resume];
    
}

@end
