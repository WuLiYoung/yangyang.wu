//
//  ViewController.m
//  --iosNSCoding
//
//  Created by 吴洋洋 on 15/12/3.
//  Copyright © 2015年 吴洋洋. All rights reserved.
//

#import "ViewController.h"
#import "Contact.h"
#import "Person.h"

@interface ViewController ()
- (IBAction)saveData;
- (IBAction)readData;

@property (nonatomic,copy) NSString *plistPath;

@end

@implementation ViewController

- (NSString *)plistPath
{
    if (!_plistPath) {
        
        //获取document
        NSString *doc = [NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES) lastObject];
        NSLog(@"%@",doc);
        
        _plistPath = [doc stringByAppendingPathComponent:@"data.plist"];
    }
    return _plistPath;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    [self testData];
    
    NSDictionary *dic = [NSKeyedUnarchiver unarchiveObjectWithFile:self.plistPath];
    
    NSLog(@"%@",dic);

}

- (void)readData
{
    //读取数据
    id obj = [NSKeyedUnarchiver unarchiveObjectWithFile:self.plistPath];
    NSLog(@"%@",obj);
}

- (IBAction)saveData {
    //使用归档的方法保存数据
    
    //NSArray *data = @[@"da",@"ta"];
    Contact *cot = [[Contact alloc] init];
    cot.name = @"zhangsan";
    cot.age = 20;
    cot.height = 60;
    
    //直接把一个对象保存到沙盒中
    [NSKeyedArchiver archiveRootObject:cot toFile:self.plistPath];
    
}

- (void)testData
{
    NSDictionary *dic = @{@"sd" : @"zhangsan",@"sb" : @"lisi"};
    
    [NSKeyedArchiver archiveRootObject:dic toFile:self.plistPath];

}

@end
