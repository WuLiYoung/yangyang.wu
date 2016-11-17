//
//  CHDownloadTool.m
//  --ios音乐播放器
//
//  Created by 吴洋洋 on 16/3/10.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "CHDownloadTool.h"
#import "CHDownloadMusic.h"


@interface CHDownloadTool () <NSURLSessionDownloadDelegate>

@end

@implementation CHDownloadTool
singleton_implementation(CHDownloadTool)

- (void)downloadMusicWithUrl:(CHDownloadMusic *)DLMusic
{
    NSURL *url = [NSURL URLWithString:DLMusic.url];
    
    NSURLSessionConfiguration *cgr = [NSURLSessionConfiguration defaultSessionConfiguration];
    
    NSURLSession *session = [NSURLSession sessionWithConfiguration:cgr delegate:self delegateQueue:nil];
    
    [[session downloadTaskWithURL:url completionHandler:^(NSURL * _Nullable location, NSURLResponse * _Nullable response, NSError * _Nullable error) {
        
    //1.根据url获取到文件名
    NSString *fileName = [DLMusic.url lastPathComponent];
        
    //2.获取沙盒路径
//      NSString *doc = [NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES) lastObject];
        
        
    //指定路径
    NSString *mp3 = @"/Users/wuyangyang/Desktop/练习代码/多线程网络/--ios音乐播放器/--ios音乐播放器/MP3";
    
   NSString *path = [mp3 stringByAppendingPathComponent:fileName];
    
    
   NSURL *toURL = [NSURL fileURLWithPath:path];
   
    //3.将临时文件夹移动到沙盒中或者指定的路径
    [[NSFileManager defaultManager] moveItemAtURL:location toURL:toURL error:nil];
    
        
    }] resume];
}

- (void)URLSession:(NSURLSession *)session downloadTask:(NSURLSessionDownloadTask *)downloadTask didFinishDownloadingToURL:(NSURL *)location
{
    
}

@end
