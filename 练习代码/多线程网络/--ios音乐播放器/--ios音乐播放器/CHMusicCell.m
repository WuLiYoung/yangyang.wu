//
//  CHMusicCellTableViewCell.m
//  --ios音乐播放器
//
//  Created by 吴洋洋 on 15/12/22.
//  Copyright © 2015年 吴洋洋. All rights reserved.
//

#import "CHMusicCell.h"
#import "CHMusic.h"

@implementation CHMusicCell

- (instancetype)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier
{
    if (self = [super initWithStyle:style reuseIdentifier:reuseIdentifier]) {
        
    }
    return self;
}

+ (instancetype)musicCellWithTableView:(UITableView *)tableView
{
    static NSString *reuseID  = @"musicCell";
    id cell = [tableView dequeueReusableCellWithIdentifier:reuseID];
    
    if (cell == nil) {
        cell = [[self alloc] initWithStyle:UITableViewCellStyleSubtitle reuseIdentifier:reuseID];
    }
    
    return cell;
}

- (void)setMusicScr:(CHMusic *)musicScr
{
    _musicScr                 = musicScr;
    self.textLabel.text       = musicScr.name;
    self.detailTextLabel.text = musicScr.singer;
    
}

@end
