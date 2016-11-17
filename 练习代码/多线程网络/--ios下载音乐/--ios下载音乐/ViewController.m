//
//  ViewController.m
//  --ios下载音乐
//
//  Created by 吴洋洋 on 16/2/28.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "ViewController.h"

@interface ViewController ()

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];

    
}

- (void)touchesBegan:(NSSet<UITouch *> *)touches withEvent:(UIEvent *)event
{
    NSString *urlStr = @"http://127.0.0.1/musics/Reset.mp3";
    urlStr = [urlStr stringByRemovingPercentEncoding];
    
    NSURL *url = [NSURL URLWithString:urlStr];
    
    NSURLSession *session = [NSURLSession sharedSession];
    
    [[session downloadTaskWithURL:url completionHandler:^(NSURL * _Nullable location, NSURLResponse * _Nullable response, NSError * _Nullable error) {
        
        NSLog(@"%@",location);
        
        //location是下载的临时文件目录
        //如果要保存文件，需要将文件保存至沙盒中或者指定文件夹
        
        //1.根据url获取到文件名
        NSString *fileName = [urlStr lastPathComponent];
        
        //2.获取沙盒路径
        //NSString *doc = [NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES) lastObject];
        
        //指定路径
        NSString *mp3 = @"/Users/wuyangyang/Desktop/临时下载测试";
        
        NSString *path = [mp3 stringByAppendingPathComponent:fileName];
        
        
        NSURL *toURL = [NSURL fileURLWithPath:path];
        
        //3.将临时文件夹移动到沙盒中
        [[NSFileManager defaultManager] moveItemAtURL:location toURL:toURL error:nil];
        
        
        
        
    }] resume];
    
}

@end
