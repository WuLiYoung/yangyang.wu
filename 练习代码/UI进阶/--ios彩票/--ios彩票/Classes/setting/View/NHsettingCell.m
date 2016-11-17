//
//  NHsettingCell.m
//  --ios彩票
//
//  Created by 吴洋洋 on 16/1/2.
//  Copyright © 2016年 吴洋洋. All rights reserved.
//

#import "NHsettingCell.h"
#import "NHSettingItem.h"
#import "NHArrow.h"
#import "NHSwitch.h"
#import "NHLable.h"

@interface NHsettingCell ()

@property (nonatomic,strong) UIImageView *mArrow;

@property (nonatomic,strong) UISwitch *mSwitch;

@property (nonatomic,strong) UILabel *mLabel;



@end

@implementation NHsettingCell


- (UIImageView *)mArrow
{
    if (!_mArrow) {
        _mArrow = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"CellArrow"]];
    }
    return _mArrow;
}

- (UISwitch *)mSwitch
{
    if (!_mSwitch) {
        _mSwitch = [[UISwitch alloc] init];
        
        //监听事件
        [_mSwitch addTarget:self action:@selector(valueChange:) forControlEvents:UIControlEventValueChanged];
    }
    return _mSwitch;
}

- (void)valueChange: (UISwitch *)mSwitch
{
    //把开关状态保存到用户偏好设置中
    NSUserDefaults *defaults = [NSUserDefaults standardUserDefaults];
    
    [defaults setBool:mSwitch.isOn forKey:self.item.title];
    
    //保存同步
    [defaults synchronize];
}


- (UILabel *)mLabel
{
    if (!_mLabel) {
        UILabel *label = [[UILabel alloc] init];
       label.bounds = CGRectMake(0, 0, 60, 44);
       label.text   = @"00:00";
        _mLabel = label;
    }
    return _mLabel;
}

+(instancetype)tableView:(UITableView *)tableView
{
    static NSString *reuseID = @"settingCell";
    NHsettingCell *cell = [tableView dequeueReusableCellWithIdentifier:reuseID];
    
    //代码创建cell，判断是否有cell
    if (!cell) {
        cell = [[NHsettingCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:reuseID];
    }
    return cell;

}

- (void)setItem:(NHSettingItem *)item
{
    _item = item;
    
    
    self.textLabel.text = item.title;
    if (item.icon) {
        self.imageView.image = [UIImage imageNamed:item.icon];

    }
    
    //设置箭头
    if ([item isKindOfClass:[NHArrow class]]) {
        self.accessoryView = self.mArrow;
        //箭头可以选中
        self.selectionStyle = UITableViewCellSelectionStyleDefault;
    }
    else if ([item isKindOfClass:[NHSwitch class]]) {
        self.accessoryView = self.mSwitch;
        
        //设置开关的状态
        self.mSwitch.on = [[NSUserDefaults standardUserDefaults] boolForKey:self.item.title];
        //开关不可以选中
        self.selectionStyle = UITableViewCellSelectionStyleNone;
    }

    else if ([item isKindOfClass:[NHLable class]])
    {
        self.accessoryView = self.mLabel;
        self.selectionStyle = UITableViewCellSelectionStyleDefault;
    }
}
@end
