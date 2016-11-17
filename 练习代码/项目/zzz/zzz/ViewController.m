//
//  ViewController.m
//  zzz
//
//  Created by 吴洋洋 on 16/4/14.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "ViewController.h"
#import "AFNetworking.h"

@interface ViewController ()

@property (weak, nonatomic) IBOutlet UIImageView *myImageView;


@end

@implementation ViewController


- (void)viewDidLoad {
    
    [super viewDidLoad];
    
    NSURL *url = [NSURL URLWithString:@"http://b.hiphotos.baidu.com/image/pic/item/faedab64034f78f0164cbc747b310a55b2191cf5.jpg"];
    NSData *data = [NSData dataWithContentsOfURL:url];
    
    UIImage *image = [UIImage imageWithData:data];
    
    self.myImageView.image = image;
    
    

}

- (void)touchesBegan:(NSSet<UITouch *> *)touches withEvent:(UIEvent *)event
{
    NSMutableDictionary *parames = [NSMutableDictionary dictionary];
    
    //parames[@"apikey"] = @"9abce45de84f7565f52cf27864fac644";
//    parames[@"name"]
    parames[@"hash"]   = @"c23d025ee9ece593abd96d7b97db97b4";
//    parames[@"time"]


    
    AFHTTPSessionManager *manage = [AFHTTPSessionManager manager];
    [manage.requestSerializer setValue:@"9abce45de84f7565f52cf27864fac644" forHTTPHeaderField:@"apikey"];
    manage.responseSerializer.acceptableContentTypes = [NSSet setWithObjects:@"application/json", @"text/json", @"text/javascript", @"text/html",nil];

    [manage GET:@"http://apis.baidu.com/geekery/music/playinfo?hash=c23d025ee9ece593abd96d7b97db97b4" parameters:@[] success:^(NSURLSessionDataTask *task, id responseObject) {
        

        NSLog(@"%@",responseObject);
        
    } failure:^(NSURLSessionDataTask *task, NSError *error) {
        
    }];
    
    
//    NSString *httpUrl = @"http://apis.baidu.com/geekery/music/playinfo";
//    NSString *httpArg = @"hash=c23d025ee9ece593abd96d7b97db97b4";
//    [self request: httpUrl withHttpArg: httpArg];
    
}




-(void)request: (NSString*)httpUrl withHttpArg: (NSString*)HttpArg  {
    NSString *urlStr = [[NSString alloc]initWithFormat: @"%@?%@", httpUrl, HttpArg];
    NSURL *url = [NSURL URLWithString: urlStr];
    NSMutableURLRequest *request = [[NSMutableURLRequest alloc]initWithURL: url cachePolicy: NSURLRequestUseProtocolCachePolicy timeoutInterval: 10];
    [request setHTTPMethod: @"GET"];
    [request addValue: @"9abce45de84f7565f52cf27864fac644" forHTTPHeaderField: @"apikey"];
    [NSURLConnection sendAsynchronousRequest: request
                                       queue: [NSOperationQueue mainQueue]
                           completionHandler: ^(NSURLResponse *response, NSData *data, NSError *error){
                               if (error) {
                                   NSLog(@"Httperror: %@%ld", error.localizedDescription, error.code);
                               } else {
                                   NSInteger responseCode = [(NSHTTPURLResponse *)response statusCode];
                                   NSString *responseString = [[NSString alloc] initWithData:data encoding:NSUTF8StringEncoding];
                                   NSLog(@"HttpResponseCode:%ld", responseCode);
                                   NSLog(@"HttpResponseBody %@",responseString);
                               }
                           }];
}

@end
