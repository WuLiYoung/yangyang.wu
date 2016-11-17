//
//  CZOAuthViewController.m
//  微博
//
//  Created by 吴洋洋 on 16/2/20.
//  Copyright © 2016年 apple. All rights reserved.
//

#define CZAuthorizeBaseUrl @"https://api.weibo.com/oauth2/authorize"
#define CZClient_id        @"116333684"
#define CZRedirect_uri     @"http://www.baidu.com"
#define CZClient_id        @"116333684"
#define CZClient_secret    @"2e62ce87707ddc91018e26efba767810"

#import "CZOAuthViewController.h"
#import "MBProgressHUD+MJ.h"
#import "AFNetworking.h"
#import "CZAccount.h"
#import "CZAccountTool.h"
#import "CZRootTool.h"

#import "CZAccountParam.h"


@interface CZOAuthViewController () <UIWebViewDelegate>

@end

@implementation CZOAuthViewController

- (void)viewDidLoad {
    [super viewDidLoad];

    //展示登陆的网页
    UIWebView *webView = [[UIWebView alloc] initWithFrame:self.view.bounds];
    //显示webView
    [self.view addSubview:webView];
    
    //一个完整的url：基本的url + 参数
    //https://api.weibo.com/oauth2/authorize?client_id=116333684&redirect_uri=http://www.baidu.com
    //拼接url字符串
    NSString *baseUrl = @"https://api.weibo.com/oauth2/authorize";
    NSString *client_id = @"116333684";
    NSString *redirect_uri = @"http://www.baidu.com";
    
    NSString *urlStr = [NSString stringWithFormat:@"%@?client_id=%@&redirect_uri=%@",baseUrl,client_id,redirect_uri];
    
    //url
    NSURL *url = [NSURL URLWithString:urlStr];
    
    //创建请求
    NSURLRequest *urlRequest = [NSURLRequest requestWithURL:url];
    
    //加载
    [webView loadRequest:urlRequest];
    
    webView.delegate = self;
}

#pragma mark - UIwebView代理
- (void)webViewDidStartLoad:(UIWebView *)webView
{
    //提示用户正在加载..
    [MBProgressHUD showMessage:@"正在加载..."];
}

//加载完成时调用
- (void)webViewDidFinishLoad:(UIWebView *)webView
{
    [MBProgressHUD hideHUD];
}

//加载失败时调用
- (void)webView:(UIWebView *)webView didFailLoadWithError:(NSError *)error
{
    [MBProgressHUD hideHUD];
}

//拦截webView的请求
- (BOOL)webView:(UIWebView *)webView shouldStartLoadWithRequest:(NSURLRequest *)request navigationType:(UIWebViewNavigationType)navigationType
{
    NSString *urlStr = request.URL.absoluteString;
    
    //获取code（requesttoken）
    NSRange rang = [urlStr rangeOfString:@"code="];
    
    if (rang.length) {
        NSString *code = [urlStr substringFromIndex:rang.location + rang.length];
        
        [self accessTOkenWithCode:code];
        
        return NO;
    }
    
    //不加载页面
    return YES;
}

/**
 *
 必选	类型及范围	说明
 client_id	true	string	申请应用时分配的AppKey。
 client_secret	true	string	申请应用时分配的AppSecret。
 grant_type	true	string	请求的类型，填写authorization_code
 
 grant_type为authorization_code时
 必选	类型及范围	说明
 code	true	string	调用authorize获得的code值。
 redirect_uri	true	string	回调地址，需需与注册应用里的回调地址一致。
 *
 *
 */
//换取code
- (void)accessTOkenWithCode: (NSString *)code
{
    //使用AFNetworking框架
    //发送post请求
    //先创建管理者:请求和解析
    
    //创建CZAccountParam
    CZAccountParam *param = [[CZAccountParam alloc] init];
    
    AFHTTPRequestOperationManager *mgr = [AFHTTPRequestOperationManager manager];
    
    NSMutableDictionary *params = [NSMutableDictionary dictionary];
    
    params[@"client_id"] = CZClient_id;
    params[@"client_secret"] = CZClient_secret;
    params[@"grant_type"] = @"authorization_code";
    params[@"code"] = code;
    params[@"redirect_uri"] = CZRedirect_uri;
    
    //发送请求
    [mgr POST:@"https://api.weibo.com/oauth2/access_token" parameters:params success:^(AFHTTPRequestOperation *operation, id responseObject) {//请求成功时调用    
        //字典转模型
        CZAccount *account = [CZAccount accountWithDic:responseObject];
        
        //保存信息
        [CZAccountTool saveAccount:account];
        
        //进入控制器，选择窗口的根控制器
        [CZRootTool chooseRootVC:CZKeyWindow];
        
    } failure:^(AFHTTPRequestOperation *operation, NSError *error) {//请求失败时调用
        
    }];
    
}

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

@end
