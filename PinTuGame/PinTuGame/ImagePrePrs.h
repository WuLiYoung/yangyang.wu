//
//  ImagePrePrs.h
//  puzzle
//
//  Created by FoLeakey on 7/12/16.
//  Copyright (c) 2016 IntelligentGroup. All rights reserved.
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

NSImage *convertFromCGImageRef(CGImageRef Img);
NSImage *convertFromIplimage(IplImage *Img);
void spiltPicFromFile(const char *pFilePath,const char *pSavePath);
