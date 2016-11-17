//
//  PosterView.m
//  Movie
//
//  Created by apple on 15/6/14.
//  Copyright (c) 2015年 huiwen. All rights reserved.
//

#import "PosterView.h"
#import "PosterCollectionView.h"
#import "IndexCollectionView.h"
#import "Movie.h"
#define kHeaderViewHeight 100 //头部视图实际显示高度
#define kheaderViewOffset 30 // 头部视图向上偏移的距离
#define kBottomViewHeight 35 //底部视图的高度

@implementation PosterView{

    UIImageView *headerView; //头部视图
    UIControl *maskView; //黑色笼罩视图
    PosterCollectionView *largeCollectionView;//打海报
    IndexCollectionView *indexCollectionView;//小海报
    UILabel *titlelable;//尾部视图

}
- (id)initWithFrame:(CGRect)frame{

    self = [super initWithFrame:frame];
    if (self) {
        
        //创建子视图
        //1.创建头部视图
        [self _createHeaderView];
        
        //2.创建大海报视图
        [self _createLargerPosterView];
        
        //3.创建索引海报视图
        [self _createIndexPosterView];
        
        //4.通过KVO监听大海报与小海报的滚动
        [largeCollectionView addObserver:self forKeyPath:@"currentIndex" options:NSKeyValueObservingOptionNew context:nil];
        [indexCollectionView addObserver:self forKeyPath:@"currentIndex" options:NSKeyValueObservingOptionNew context:nil];
        
        //5.创建尾部视图
        [self _createBottomView];
    }

    return self;

}
/*
    1.如果被观察的对象属性发生了变化,此方法会被调用
    2.keyPath:被观察的属性
    3.object :被观察的对象
    4.change :变化后的值
    5.context:上下文
 */
- (void)observeValueForKeyPath:(NSString *)keyPath ofObject:(id)object change:(NSDictionary *)change context:(void *)context{
    
    //取得变化后的值
    NSNumber *number = change[@"new"];
    NSInteger index = [number integerValue];
    NSIndexPath *indexPath = [NSIndexPath indexPathForItem:index inSection:0];
    
    //如果被观察的对象是大海报(大海报被拖动)
    if ([object isKindOfClass:[largeCollectionView class]] && indexCollectionView.currentIndex != index) {
        
        //滚动小海报
        [indexCollectionView scrollToItemAtIndexPath:indexPath atScrollPosition:UICollectionViewScrollPositionCenteredHorizontally animated:YES];
        
        //更新当前页(触发KVO)
        indexCollectionView.currentIndex = index;
        
        //如果被观察的对象是小海报(小海报被拖动)
    }else if([object isKindOfClass:[indexCollectionView class]] && largeCollectionView.currentIndex != index){
    
        //滚动大海报
        [largeCollectionView scrollToItemAtIndexPath:indexPath atScrollPosition:UICollectionViewScrollPositionCenteredHorizontally animated:YES];
        
        //更新当前页(触发KVO)
        largeCollectionView.currentIndex = index;
    }
    
    //取得对应的电影model
    Movie *movie = _movieList[index];
    titlelable.text = movie.title;


}
//重写set方法
- (void)setMovieList:(NSArray *)movieList{
    
    _movieList = movieList;
    
    //将数据传给大海报
    largeCollectionView.movieList = _movieList;
    //刷新视图
    [largeCollectionView reloadData];
    
    //将数据交给小海豹
    indexCollectionView.movieList = _movieList;
    [indexCollectionView reloadData];
    
    //取出第一个电影标题
    Movie *movie = [_movieList firstObject];
    titlelable.text = movie.title;
}

- (void)_createBottomView{
    
    titlelable = [[UILabel alloc] initWithFrame:CGRectMake(0, largeCollectionView.bottom, kScreenWidth, kBottomViewHeight)];
    titlelable.font = [UIFont boldSystemFontOfSize:17];
    titlelable.textColor = [UIColor whiteColor];
    titlelable.textAlignment = NSTextAlignmentCenter;
    titlelable.backgroundColor = [UIColor colorWithPatternImage:[UIImage imageNamed:@"poster_title_home.png"]];
    [self addSubview:titlelable];



}

- (void)_createIndexPosterView{
    
    UICollectionViewFlowLayout *layout = [[UICollectionViewFlowLayout alloc] init];
    layout.scrollDirection = UICollectionViewScrollDirectionHorizontal;
    layout.minimumInteritemSpacing = 0;
    layout.minimumLineSpacing = 0;
    indexCollectionView = [[IndexCollectionView alloc] initWithFrame:CGRectMake(0, 0, kScreenWidth, 90) collectionViewLayout:layout];
    
    //单元格宽度
    indexCollectionView.width = 70;
    [headerView addSubview:indexCollectionView];


}

- (void)_createLargerPosterView{
    
    UICollectionViewFlowLayout *layout = [[UICollectionViewFlowLayout alloc] init];
    //单元格间隙
    layout.minimumInteritemSpacing = 0;
    layout.minimumLineSpacing = 0;
    //滑动方向
    layout.scrollDirection = UICollectionViewScrollDirectionHorizontal;
    //子类化UICollectionView
    largeCollectionView = [[PosterCollectionView alloc] initWithFrame:CGRectMake(0, kHeaderViewHeight, kScreenWidth, kScreenHeight - kHeaderViewHeight - kTabbarHeight - kBottomViewHeight) collectionViewLayout:layout];
    
    //单元格宽度
    largeCollectionView.width = kScreenWidth / 4 * 3;
    [self insertSubview:largeCollectionView belowSubview:maskView];
    
    

}
- (void)_createHeaderView{
    
    //1.头部背景视图
    headerView = [[UIImageView alloc] initWithFrame:CGRectMake(0,-kheaderViewOffset, kScreenWidth, kheaderViewOffset + kHeaderViewHeight)];
    headerView.userInteractionEnabled = YES;
    UIImage *image = [UIImage imageNamed:@"indexBG_home.png"];
    //拉伸图片  LeftCap左顶盖  topCap上顶盖
    /*
        系统会根据传入的左顶盖与上顶盖计算出下顶盖与右顶盖,最终将图片分为4个部分,保留出中间的一个像素
        参考博客: http://blog.csdn.net/q199109106q/article/details/8615661
     
     */
    image = [image stretchableImageWithLeftCapWidth:0 topCapHeight:1];
    headerView.image = image;
    [self addSubview:headerView];
    
    //2.下拉按钮
    UIButton *pullBtn = [UIButton buttonWithType:UIButtonTypeCustom];
    pullBtn.frame = CGRectMake((kScreenWidth - 15) / 2,130 - 20, 20, 20);
    pullBtn.tag = 2015;
    [pullBtn setImage:[UIImage imageNamed:@"down_home.png"] forState:UIControlStateNormal];
    //选择状态下的图片
    [pullBtn setImage:[UIImage imageNamed:@"up_home.png"] forState:UIControlStateSelected];
    [pullBtn addTarget:self action:@selector(pullAction:) forControlEvents:UIControlEventTouchUpInside];
    [headerView addSubview:pullBtn];
    
    //3.轻扫手势
    UISwipeGestureRecognizer *swipe = [[UISwipeGestureRecognizer alloc] initWithTarget:self action:@selector(swipeAction:)];
    
    //设置清扫的方向
    swipe.direction = UISwipeGestureRecognizerDirectionDown;
    [self addGestureRecognizer:swipe];
    
    //4.黑色笼罩视图
    maskView = [[UIControl alloc] initWithFrame:CGRectMake(0, 0, kScreenWidth, kScreenHeight)];
    maskView.hidden = YES;
    //点击黑色笼罩视图时,隐藏头部视图
    [maskView addTarget:self action:@selector(hideHeaderView) forControlEvents:UIControlEventTouchUpInside];
    maskView.backgroundColor = [UIColor colorWithWhite:0 alpha:.4];
    //将黑色笼罩视图添加到头部视图的下方
    [self insertSubview:maskView belowSubview:headerView];

}

//清扫手势
//显示头部视图
#pragma mark -轻扫手势
- (void)swipeAction:(UISwipeGestureRecognizer *)swipe{
    
    //如果笼罩视图没有显示
    if (maskView.hidden) { //NULL 0  nil 0

        
        [self showHeaderView];
    }

}
#pragma mark -下拉按钮
- (void)pullAction:(UIButton *)btn{
    
    [UIView beginAnimations:nil context:nil];
    [UIView setAnimationDuration:.3];
    if (!btn.selected) {
        
        [self showHeaderView];
    }else{
    
        [self hideHeaderView];
    }
    [UIView commitAnimations];
}

//显示头部视图
- (void)showHeaderView{
    
    UIButton *btn = (UIButton *)[headerView viewWithTag:2015];
        //切换按钮状态
    btn.selected = !btn.selected;
    
    //执行动画
    [UIView animateWithDuration:.3 animations:^{
        
        headerView.transform = CGAffineTransformMakeTranslation(0, kheaderViewOffset + kNavHeight);
    }];
    //显示笼罩视图
    maskView.hidden = NO;

}
//隐藏头部视图
- (void)hideHeaderView{
    
    UIButton *btn = (UIButton *)[headerView viewWithTag:2015];
    //切换按钮状态
    btn.selected = !btn.selected;
    
    [UIView animateWithDuration:.3 animations:^{
        
        headerView.transform = CGAffineTransformIdentity;
    }];
    //隐藏笼罩视图
    maskView.hidden = YES;

}
@end
