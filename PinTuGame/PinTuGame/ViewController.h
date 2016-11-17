//
//  ViewController.h
//  PinTuGame
//
//  Created by DWL on 7/9/2016.
//  Copyright © 2016 DWL. All rights reserved.
//

#import <stdio.h>
#import <stdlib.h>
#import <fstream>
#import <iostream>
#import <cv.h>
#import <ml.h>
#import <math.h>
#import <highgui.h>
#import <opencv2/highgui/highgui.hpp>
#import <opencv2/opencv.hpp>
#import <Cocoa/Cocoa.h>

@interface ViewController : NSViewController{
    
    NSString *FilePath;
    NSArray *btnArr;
    NSArray *arr;
}

@property (weak) IBOutlet NSImageView *imageView1;

@property (weak) IBOutlet NSButton *btn1;
@property (weak) IBOutlet NSButton *btn2;
@property (weak) IBOutlet NSButton *btn3;
@property (weak) IBOutlet NSButton *btn4;
@property (weak) IBOutlet NSButton *btn5;
@property (weak) IBOutlet NSButton *btn6;
@property (weak) IBOutlet NSButton *btn7;
@property (weak) IBOutlet NSButton *btn8;
@property (weak) IBOutlet NSButton *btn9;





@end

