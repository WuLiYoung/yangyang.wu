//
//  NewDetailController.m
//  Movie
//
//  Created by apple on 15/6/15.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "NewDetailController.h"
#import "DataService.h"

@interface NewDetailController ()

@end

@implementation NewDetailController{


    UIActivityIndicatorView *activityView;

}
- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil{

    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        
        self.hidesBottomBarWhenPushed = YES;
    }

    return self;

}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    //ios:图文混排
    /*
     
        1.CoreText,C语言框架,难用,性能好(设置文字的大小.行间距)
        2.UIWebView(显示网页),易用,性能差(主流,HTML5)
     
     
     */
    /*
    //webView网页视图
    UIWebView *webView = [[UIWebView alloc] initWithFrame:CGRectMake(0, 0, kScreenWidth, kScreenHeight)];
    [self.view addSubview:webView];
    */
    /*
    //1.加载网页的方式(加载链接) //<#(NSURLRequest *)#>网络请求
    
    NSURL *url = [NSURL URLWithString:@"http://www.hao123.com"];
    //构造网络请求
    NSURLRequest *request = [NSURLRequest requestWithURL:url];
    //请求url对应的网页
    [webView loadRequest:request];
     */
    
    /*
    //2.加载网页的方式(加载html)  //HTML,解释型语言
    //读取html代码
    NSString *htmlStr = [NSString stringWithContentsOfFile:[[NSBundle mainBundle] pathForResource:@"百度一下，你就知道.html" ofType:nil] encoding:NSUTF8StringEncoding error:nil];
    //适应屏幕
//    [webView sizeToFit];
    
    //加载html代码
    [webView loadHTMLString:htmlStr baseURL:nil];
    
    */
    
    [self _loadNewsData];
    
}
- (void)_loadNewsData{

    //加载json数据
    NSDictionary *dic = [DataService loadJsonDataWithName:@"news_detail.json"];
    //新闻标题
    NSString *tilte = [dic objectForKey:@"title"];
    //新闻正文
    NSString *content = [dic objectForKey:@"content"];
    //来源
    NSString *source = [dic objectForKey:@"source"];
    //作者
    NSString *author = [dic objectForKey:@"author"];
    //时间
    NSString *time = [dic objectForKey:@"time"];
    
    //读取html模板,包含占位符
    NSString *html = [NSString stringWithContentsOfFile:[[NSBundle mainBundle] pathForResource:@"news.html" ofType:nil] encoding:NSUTF8StringEncoding error:nil];
    
    //拼接来源与时间
    NSString *sourceTime = [NSString stringWithFormat:@"来源 :%@ ,时间 :%@",source,time];
    
    //拼接为完整的html
    NSString *htmlStr = [NSString stringWithFormat:html,tilte,sourceTime,content,author];
    
    UIWebView *webView = [[UIWebView alloc] initWithFrame:CGRectMake(0, 0, kScreenWidth, kScreenHeight)];
    [self.view addSubview:webView];
    
    //加载html
    [webView loadHTMLString:htmlStr baseURL:nil];
    
    //适应页面   JS:网页交互
    webView.scalesPageToFit = YES;
    
    //设置代理,监听加载的事件
    webView.delegate = self;
    
    
    //活动视图
    activityView = [[UIActivityIndicatorView alloc] initWithActivityIndicatorStyle:UIActivityIndicatorViewStyleWhite];
    
    UIBarButtonItem *rightItem = [[UIBarButtonItem alloc] initWithCustomView:activityView];
    
    self.navigationItem.rightBarButtonItem = rightItem;


}

#pragma mark UIWebViewDelegate
//webView开始加载网页

- (BOOL)webView:(UIWebView *)webView shouldStartLoadWithRequest:(NSURLRequest *)request navigationType:(UIWebViewNavigationType)navigationType {
    
    //开始转动
    [activityView startAnimating];

    return YES;

}

//加载完毕后,调用此方法
- (void)webViewDidFinishLoad:(UIWebView *)webView {

    [activityView stopAnimating]; //会自动隐藏
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
