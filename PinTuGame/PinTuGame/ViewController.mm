//
//  ViewController.m
//  PinTuGame
//
//  Created by DWL on 7/9/2016.
//  Copyright © 2016 DWL. All rights reserved.
//

#import "ViewController.h"
#import "ImagePrePrs.h"



@implementation ViewController


- (void)viewDidLoad {
    [super viewDidLoad];
    
    FilePath = [[NSBundle mainBundle] resourcePath];
    
    self->btnArr =  [NSArray arrayWithObjects:self.btn1, self.btn2, self.btn3, self.btn4, self.btn5, self.btn6, self.btn7, self.btn8, self.btn9, nil];
    
    
    self.imageView1.image = [NSImage imageNamed:@"test"];
    
    //图片分割
    spiltPicFromFile([[NSString stringWithFormat:@"%@/test.jpg",FilePath] UTF8String],[FilePath UTF8String]);
    
    
    
    [self setBtnImage];
    
}

//不重复的随机数
-(NSArray*)randArray{
    //随机数从这里边产生
    NSMutableArray *startArray=[[NSMutableArray alloc] initWithObjects:@0,@1,@2,@3,@4,@5,@6,@7,@8 ,nil];
    //随机数产生结果
    NSMutableArray *randArray=[[NSMutableArray alloc] initWithCapacity:0];
    //随机数个数
    NSInteger m=9;
    for (int i=0; i<m; i++) {
        int t=arc4random()%startArray.count;
        randArray[i]=startArray[t];
        startArray[t]=[startArray lastObject];
        [startArray removeLastObject];
    }
    return randArray;
}

//
- (void)setBtnImage{
    for (int i = 0; i < 9; i++) {
        
//        NSString *str = [NSString stringWithFormat:@"%d",i + 1];
        NSButton *btn = btnArr[i];
        btn.image = [[NSImage alloc] initWithContentsOfFile:[FilePath stringByAppendingFormat:@"/%d.jpg",i + 1]];
        
        if (i == 8) {
            btn.image = nil;
        }
    }
}

- (IBAction)btn1:(NSButton *)sender {
    if (self.btn4.image == nil) {
        self.btn4.image = sender.image;
        sender.image = nil;
    }
    else if (self.btn2.image == nil){
    
        self.btn2.image = sender.image;
        sender.image = nil;
    }
    
}
- (IBAction)btn2:(NSButton *)sender {
    
    if (self.btn1.image == nil) {
        self.btn1.image = sender.image;
        sender.image = nil;
    }
    else if (self.btn3.image == nil){
        
        self.btn3.image = sender.image;
        sender.image = nil;
    }
    else if (self.btn5.image == nil){
        
        self.btn5.image = sender.image;
        sender.image = nil;
    }
}
- (IBAction)btn3:(NSButton *)sender {
    if (self.btn2.image == nil) {
        self.btn2.image = sender.image;
        sender.image = nil;
    }
    else if (self.btn6.image == nil){
        
        self.btn6.image = sender.image;
        sender.image = nil;
    }
}
- (IBAction)btn4:(NSButton *)sender {
    if (self.btn1.image == nil) {
        self.btn1.image = sender.image;
        sender.image = nil;
    }
    else if (self.btn5.image == nil){
        
        self.btn5.image = sender.image;
        sender.image = nil;
    }
    else if (self.btn7.image == nil){
        
        self.btn7.image = sender.image;
        sender.image = nil;
    }
}
- (IBAction)btn5:(NSButton *)sender {
    if (self.btn2.image == nil) {
        self.btn2.image = sender.image;
        sender.image = nil;
    }
    else if (self.btn4.image == nil){
        
        self.btn4.image = sender.image;
        sender.image = nil;
    }
    else if (self.btn6.image == nil){
        
        self.btn6.image = sender.image;
        sender.image = nil;
    }
    else if (self.btn8.image == nil){
    
        self.btn8.image = sender.image;
        sender.image = nil;
    }
}
- (IBAction)btn6:(NSButton *)sender {
    if (self.btn3.image == nil) {
        self.btn3.image = sender.image;
        sender.image = nil;
    }
    else if (self.btn5.image == nil){
        
        self.btn5.image = sender.image;
        sender.image = nil;
    }
    else if (self.btn9.image == nil){
        
        self.btn9.image = sender.image;
        sender.image = nil;
    }
}
- (IBAction)btn7:(NSButton *)sender {
    if (self.btn4.image == nil) {
        self.btn4.image = sender.image;
        sender.image = nil;
    }
    else if (self.btn8.image == nil){
        
        self.btn8.image = sender.image;
        sender.image = nil;
    }

}
- (IBAction)btn8:(NSButton *)sender {
    if (self.btn5.image == nil) {
        self.btn5.image = sender.image;
        sender.image = nil;
    }
    else if (self.btn7.image == nil){
        
        self.btn7.image = sender.image;
        sender.image = nil;
    }
    else if (self.btn9.image == nil){
        
        self.btn9.image = sender.image;
        sender.image = nil;
    }
}
- (IBAction)btn9:(NSButton *)sender {
    if (self.btn6.image == nil) {
        self.btn6.image = sender.image;
        sender.image = nil;
    }
    else if (self.btn8.image == nil){
        
        self.btn8.image = sender.image;
        sender.image = nil;
    }

}

- (IBAction)open:(id)sender {
        NSOpenPanel *openPanel = [NSOpenPanel openPanel];
        [openPanel setCanChooseFiles:YES];
        [openPanel setCanChooseDirectories:NO];
        [openPanel setAllowedFileTypes:[NSImage imageTypes]];
        [openPanel setMessage:@"Select a image."];
        [openPanel beginSheetModalForWindow:[NSApp mainWindow] completionHandler:^(NSInteger result) {
            
        spiltPicFromFile([[openPanel filename] UTF8String],[FilePath UTF8String]);
            
        self.imageView1.image = [[NSImage alloc] initWithContentsOfFile:[openPanel filename]];

        [self setBtnImage];
            
    }];
}
- (IBAction)start:(id)sender {
    
    arr = [self randArray];
    
    int t = NULL;
    
    for (int i = 0; i < arr.count ; i++) {
        
        int n = [arr[i] intValue];
        
        if (n == 0) {
            t = i;
        }
        
        NSButton *btntemp = btnArr[n];
       
        NSButton *btn = btnArr[i];
        
        id temp = btntemp.image;
        
        btntemp.image = btn.image;
        
        btn.image =  temp;
        
        
    }
    
    //逆序数
    int count;
    
    for (int m = 0; m < arr.count - 1; m++) {
        
        for (int n = m +1; n < arr.count; n++) {
            
            if (arr[m] > arr[n]) {
                count++;
            }
            
        }
    }
    
    if ((count + t) % 2 == 1) {
        
        NSAlert *alert = [[NSAlert alloc] init];
        
        [alert setMessageText:@"This puzzle can't be completed. Please reset it!!!"];
        
        [alert runModal];
    }
    
}


@end

