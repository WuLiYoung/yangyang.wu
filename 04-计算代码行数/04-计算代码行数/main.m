//
//  main.m
//  04-计算代码行数
//
//  Created by apple on 13-8-12.
//  Copyright (c) 2013年 itcast. All rights reserved.
//

/*
 * 考察NSString、NSArray的使用
 * NSFileManager
 */

#import <Foundation/Foundation.h>


// 计算文件的代码行数
/*
 path : 文件的全路径(可能是文件夹、也可能是文件)
 返回值 int ：代码行数
 */
NSUInteger codeLineCount(NSString *path)
{
    // 1.获得文件管理者
    NSFileManager *mgr = [NSFileManager defaultManager];
    
    // 2.标记是否为文件夹
    BOOL dir = NO; // 标记是否为文件夹
    // 标记这个路径是否存在
    BOOL exist = [mgr fileExistsAtPath:path isDirectory:&dir];
    
    // 3.如果不存在，直接返回0
    if(!exist)
    {
        NSLog(@"文件路径不存在!!!!!!");
        return 0;
    }
    
    // 代码能来到着，说明路径存在
    
    
    if (dir)
    { // 文件夹
        // 获得当前文件夹path下面的所有内容（文件夹、文件）
        NSArray *array = [mgr contentsOfDirectoryAtPath:path error:nil];
        
        // 定义一个变量保存path中所有文件的总行数
        int count = 0;
        
        // 遍历数组中的所有子文件（夹）名
        for (NSString *filename in array)
        {
            // 获得子文件（夹）的全路径
            NSString *fullPath = [NSString stringWithFormat:@"%@/%@", path, filename];
            
            // 累加每个子路径的总行数
            count += codeLineCount(fullPath);
        }
        
        return count;
    }
    else
    { // 文件
        // 判断文件的拓展名(忽略大小写)
        NSString *extension = [[path pathExtension] lowercaseString];
        if (![extension isEqualToString:@"h"]
            && ![extension isEqualToString:@"m"]
            && ![extension isEqualToString:@"c"])
        {
            // 文件拓展名不是h，而且也不是m，而且也不是c
            return 0;
        }
        
        // 加载文件内容
        NSString *content = [NSString stringWithContentsOfFile:path encoding:NSUTF8StringEncoding error:nil];
        
        // 将文件内容切割为每一行
        NSArray *array = [content componentsSeparatedByString:@"\n"];
        
        // 删掉文件路径前面的/Users/apple/Desktop/iOS课堂共享/0722课堂共享/
        NSRange range = [path rangeOfString:@"/Users/wuyangyang/Desktop/练习代码"];
        NSString *str = [path stringByReplacingCharactersInRange:range withString:@""];
        
        // 打印文件路径和行数
        NSLog(@"%@ - %ld", str, array.count);
        
        return array.count;
    }
}

int main()
{
    
    NSUInteger count = codeLineCount(@"/Users/wuyangyang/Desktop/练习代码");
    
    NSLog(@"%ld", count);
    return 0;
}

void test()
{
    NSString *str = @"jack\nrose\njim\njake";
    
    [str writeToFile:@"/Users/apple/Desktop/abc.txt" atomically:YES encoding:NSUTF8StringEncoding error:nil];
    
    
    NSArray *array = [str componentsSeparatedByString:@"\n"];
    
    for (NSString *line in array)
    {
        NSLog(@"%@", line);
    }
    
    
    //int count = codeLineCount(@"/Users/apple/Desktop/iOS课堂共享/0722课堂共享/0811/代码/04-block/04-block/main.m");
    
    //NSLog(@"count=%d", count);
}