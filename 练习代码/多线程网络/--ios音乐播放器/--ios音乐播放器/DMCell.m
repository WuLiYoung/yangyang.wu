//
//  DMCell.m
//  --ios音乐播放器
//
//  Created by 吴洋洋 on 16/3/4.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "DMCell.h"
#import "CHDownloadMusic.h"
#import "CHDownloadTool.h"




@interface DMCell ()
@property (weak, nonatomic) IBOutlet UILabel *songName;
@property (weak, nonatomic) IBOutlet UILabel *singer;


@property (nonatomic,strong) MDRadialProgressView *indeterminateRadialView;

//@property (nonatomic,assign,getter=isDownloading) BOOL downloading;


@end

@implementation DMCell

- (instancetype)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier
{
    if (self = [super initWithStyle:style reuseIdentifier:reuseIdentifier]) {

        
    }
    return self;
}

+ (instancetype)musicDownCellWithTableView:(UITableView *)tableView
{
    static NSString *reuseID  = @"cell";
    
    id cell = [tableView dequeueReusableCellWithIdentifier:reuseID];
    
    return cell;
}

- (void)setDm:(CHDownloadMusic *)dm
{
    _dm = dm;

    self.songName.text = _dm.name;

    self.singer.text   = _dm.singer;
    
}

//- (void)setIsIndeterminateProgress:(BOOL)YN
//{
//    if (self.indeterminateRadialView == nil) {
//        
//        self.indeterminateRadialView = [[MDRadialProgressView alloc] initWithFrame:CGRectMake(320,1, 50,50)];
//        self.indeterminateRadialView.progressTotal = 7;
//        self.indeterminateRadialView.progressCounter = 4;
//        //self.indeterminateRadialView.theme.sliceDividerHidden = NO;
//        //[self.indeterminateRadialView setIsIndeterminateProgress:YN];
//        //[self.indeterminateRadialView setIsIndeterminateProgress:NO];
//        
//        [self insertSubview:self.indeterminateRadialView atIndex:0];
//        
//        self.indeterminateRadialView.userInteractionEnabled = YES;
//    }
//    [self.indeterminateRadialView setIsIndeterminateProgress:YN];
//    self.indeterminateRadialView.theme.sliceDividerHidden = !YN;
//    
//    
//}



@end
