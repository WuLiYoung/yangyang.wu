//
//  ViewController.m
//  --iosURLSession进度跟进
//
//  Created by 吴洋洋 on 16/2/15.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "ViewController.h"

@interface ViewController () <NSURLSessionDownloadDelegate>

//下载任务
@property (nonatomic,strong) NSURLSessionDownloadTask *task;

//全局的会话
@property (nonatomic,strong) NSURLSession *session;

//续传的数据
@property (nonatomic,strong) NSData *resumeData;



@end

@implementation ViewController

//初始化 会话
- (NSURLSession *)session
{
    if (_session == nil) {
        NSURLSessionConfiguration *config = [NSURLSessionConfiguration defaultSessionConfiguration];
        _session = [NSURLSession sessionWithConfiguration:config delegate:self delegateQueue:nil];
    }
    return _session;
}

- (IBAction)start
{
    //1.URL
    NSString *urlStr = @"http://127.0.0.1/09-NSURLSession的断点续传.mp4";
    
    urlStr = [urlStr stringByAddingPercentEscapesUsingEncoding:NSUTF8StringEncoding];
    
    NSURL *url = [NSURL URLWithString:urlStr];
    
    //2.通过session对象，开始任务
    self.task = [ self.session downloadTaskWithURL:url];
    
    [self.task resume];
    
}
//暂停
- (IBAction)pause {
    [self.task cancelByProducingResumeData:^(NSData * _Nullable resumeData) {
        
        NSLog(@"=-----%tu",resumeData.length);
        
        self.resumeData = resumeData;
    }];
    
    //释放下载任务
    self.task = nil;
}

//继续
- (IBAction)resume {
    if (self.resumeData == nil) {
        NSLog(@"没有续传数据");
        return;
    }
    
    //使用上一次的记录，新建一个下载任务
    self.task = [self.session downloadTaskWithResumeData:self.resumeData];
    
    //释放续传数据
    self.resumeData = nil;
    
    [self.task resume];
    
}

/**
 *   解决代理强引用
 *   视图消失时，会调用的方法
 */
- (void)viewWillDisappear:(BOOL)animated
{
    [super viewWillDisappear:animated];
    
    //任务完成时，取消session
    [self.session invalidateAndCancel];
    
    //释放会话
    self.session = nil;
}

#pragma mark - NSURLSessionDownloadDelegate代理方法
//下载完成时被调用
- (void)URLSession:(NSURLSession *)session downloadTask:(NSURLSessionDownloadTask *)downloadTask didFinishDownloadingToURL:(NSURL *)location
{
    NSLog(@"下载完成。。");
    
    [self.session invalidateAndCancel];
    
    self.session = nil;
}

//下载进度变化时调用
/**
 *
 *
 *  @param bytesWritten              本次写入的字节数
 *  @param totalBytesWritten         已经写入的字节数
 *  @param totalBytesExpectedToWrite 总的字节数
 */
- (void)URLSession:(NSURLSession *)session downloadTask:(NSURLSessionDownloadTask *)downloadTask didWriteData:(int64_t)bytesWritten totalBytesWritten:(int64_t)totalBytesWritten totalBytesExpectedToWrite:(int64_t)totalBytesExpectedToWrite
{
    float progress = (float)totalBytesWritten / totalBytesExpectedToWrite;
    NSLog(@"%f",progress);
}

//断点续传时被调用，一般什么都不写
- (void)URLSession:(NSURLSession *)session downloadTask:(NSURLSessionDownloadTask *)downloadTask didResumeAtOffset:(int64_t)fileOffset expectedTotalBytes:(int64_t)expectedTotalBytes
{
    
}

@end
