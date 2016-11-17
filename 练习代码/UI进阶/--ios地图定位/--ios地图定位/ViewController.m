//
//  ViewController.m
//  --ios地图定位
//
//  Created by 吴洋洋 on 16/2/9.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "ViewController.h"
#import <CoreLocation/CoreLocation.h>

@interface ViewController () <CLLocationManagerDelegate>

@property (nonatomic,strong) CLLocationManager *mgr;


@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    [self.mgr startUpdatingLocation];
}

#pragma mark - 代理方法
- (void)locationManager:(CLLocationManager *)manager didUpdateLocations:(NSArray<CLLocation *> *)locations
{
    //获取用户的位置坐标
    CLLocation *location = [locations lastObject];
    CLLocationCoordinate2D coordinate = location.coordinate;
    
    NSLog(@"经度——%f,纬度——%f",coordinate.latitude,coordinate.longitude);
    
    [manager stopUpdatingLocation];
}

//懒加载
- (CLLocationManager *)mgr
{
    if (_mgr == nil) {
        //1.创建定位管理者
        _mgr = [[CLLocationManager alloc] init];
        
        //2.设置代理
        _mgr.delegate = self;
        
        //3.位置间隔之后重新定位
        _mgr.distanceFilter = 10;
        
        //4.定位精确
        _mgr.desiredAccuracy = kCLLocationAccuracyBest;
    }
    return _mgr;
}



@end
