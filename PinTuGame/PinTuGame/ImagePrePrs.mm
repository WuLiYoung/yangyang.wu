//
//  ImagePrePrs.m
//  puzzle
//
//  Created by FoLeakey on 7/12/16.
//  Copyright (c) 2016 IntelligentGroup. All rights reserved.
//

#import "ImagePrePrs.h"

NSImage *convertFromCGImageRef(CGImageRef Img){
    NSRect  imageRect = NSMakeRect(0, 0, 0, 0);
    CGContextRef imageContext = nil;
    NSImage *newImage = nil;
    try {
        imageRect.size.height = CGImageGetHeight(Img);
        imageRect.size.width = CGImageGetWidth(Img);
        newImage = [[NSImage alloc] initWithSize:imageRect.size];
        [newImage lockFocus];
        imageContext = (CGContextRef)[[NSGraphicsContext currentContext] graphicsPort];
        CGContextDrawImage(imageContext, *(CGRect*)&imageRect, Img);
        [newImage unlockFocus];
    }
    catch (...) {
    }
    return newImage;
}

NSImage *convertFromIplimage(IplImage *Img){
    CGColorSpaceRef colorSpace=CGColorSpaceCreateDeviceRGB();
    NSData *data=[NSData dataWithBytes:Img->imageData length:Img->imageSize];
    CGDataProviderRef provider=CGDataProviderCreateWithCFData((__bridge CFDataRef)data);
    CGImageRef imageRef = CGImageCreate(Img->width, Img->height,Img->depth, Img->depth*Img->nChannels, Img->widthStep,colorSpace, kCGImageAlphaNone|kCGBitmapByteOrderDefault,provider, NULL, false, kCGRenderingIntentDefault);
    NSImage *nsImg=convertFromCGImageRef(imageRef);
    CGImageRelease(imageRef);
    CGDataProviderRelease(provider);
    CGColorSpaceRelease(colorSpace);
    return nsImg;
}
IplImage *resizeImg(IplImage *RawImg,int *size){
    RawImg->width>RawImg->height?*size=RawImg->height:*size=RawImg->width;
    IplImage *PrsImg=cvCreateImage(cvSize(*size, *size),RawImg->depth,RawImg->nChannels);
    cvResize(RawImg,PrsImg);
    return PrsImg;
}
void spiltPicFromFile(const char *pFilePath,const char *pSavePath){
    int pSize=0;
    IplImage *fullImg=resizeImg(cvLoadImage(pFilePath),&pSize);
    pSize=pSize/3;
    IplImage *subImg=cvCreateImage(cvSize(pSize, pSize), fullImg->depth, fullImg->nChannels);
    for (int i=0; i<9; i++) {
        cvSetImageROI(fullImg, cvRect((i%3)*pSize, ((int)(i-i%3)/3)*pSize, pSize, pSize));
        cvCopyImage(fullImg, subImg);
        cvSaveImage([[NSString stringWithFormat:@"%s/%d.jpg",pSavePath,i+1]UTF8String], subImg);
    }
}
