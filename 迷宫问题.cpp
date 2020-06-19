#include<stdio.h>
#include<stdlib.h>
#include<malloc.h>
#include<iostream>
#include<windows.h> 
#include <process.h>
#include<conio.h>
#include<time.h>
using namespace std;
#define STACK_INIT_SIZE 10000
#define N 10

typedef struct Pos
{
	int x;
	int y;
}PosType;

typedef struct SElemtp
{
	PosType seat;
	int di;
}SElemtp;

typedef struct 
{
	SElemtp *base; 
	SElemtp *top; 
	int stacksize;
}SqStack; 

typedef int MazeType[N][N];
MazeType mz;
PosType begin,end;
int key,kk=4; 
int k;
PosType curpos;
int curstep=0;
int mm[N][N]={
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
				{ 0, 1, 1, 0, 1, 1, 1, 0, 1, 0},
				{ 0, 1, 0, 0, 1, 1, 1, 0, 1, 0},
				{ 0, 1, 1, 0, 1, 0, 0, 1, 1, 0},
				{ 0, 1, 0, 0, 0, 1, 0, 1, 0, 0},
				{ 0, 1, 1, 1, 0, 1, 1, 0, 1, 0},
				{ 0, 1, 0, 1, 1, 1, 0, 0, 1, 0},
				{ 0, 1, 0, 0, 0, 1, 0, 0, 1, 0},
				{ 0, 0, 1, 1, 1, 1, 1, 1, 1, 0},
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
			};

typedef struct 
{
	int freq; //赫兹
	int duration;//持续时间
	char text[32];//文本内容
}STU;

STU t[] = {{1318, 250, ""}, {1318, 500, ""}, {1318, 500, ""}, {1318, 250, ""}, {1175, 250, ""}, {1175, 500, ""}, 
{1046, 250, ""}, {1046, 500, ""}, {1046, 250, ""}, {1175, 250, ""}, {1046, 250, ""}, 
{880, 250, ""}, {784, 250, ""}, {784, 250, ""}, {784, 500, ""}, {784, 250, ""}, 
{880, 250, ""}, {784, 250, ""}, {1175, 250, ""}, {1318, 250, ""}, {1046, 500, ""}, 
{1046, 500, "\n"}, {659, 250, "池"}, {784, 250, "塘"}, {784, 500, "边"}, {784, 250, ""}, 
{659, 250, "的"}, {880, 250, "榕"}, {880, 250, "树"}, {988, 250, "上"}, {880, 250, ""}, 
{0, 250, ""}, {880, 250, "只"}, {880, 250, "了"}, {784, 250, "在"}, {1046, 500, "声"}, 
{1046, 250, "声"}, {1046, 250, "的"}, {1046, 250, "叫"}, {880, 250, ""}, {1046, 250, "着"}, 
{880, 250, "夏"}, {784, 500, "天"}, {784, 500, "，"}, {659, 250, "操"}, {784, 250, "场"}, 
{784, 500, "边"}, {784, 250, ""}, {659, 250, "的"}, {880, 250, "秋"}, {880, 250, "千"}, 
{988, 250, "上"}, {880, 250, "，"}, {0, 250, ""}, {880, 250, "只"}, {880, 250, "有"}, 
{784, 250, ""}, {1046, 500, "蝴"}, {1046, 375, "蝶"}, {1046, 125, ""}, {1046, 250, "停"}, 
{880, 250, "在"}, {880, 250, "上"}, {1046, 250, ""}, {1175, 500, "面"}, {1175, 500, "。"}, 
{1568, 250, "黑"}, {1568, 500, "板"}, {1568, 125, "上"}, {1568, 125, ""}, {1568, 250, ""}, 
{1568, 250, "老"}, {1318, 250, "师"}, {1175, 250, "的"}, {1046, 250, "粉"}, {1046, 500, "笔"}, 
{880, 250, "还"}, {880, 250, ""}, {880, 250, ""}, {1046, 250, "在"}, {880, 250, "拼"}, 
{1046, 250, "命"}, {1175, 250, "叽"}, {1175, 250, "叽"}, {1175, 250, "喳"}, {1046, 250, "喳"}, 
{1175, 250, "写"}, {1046, 250, "个"}, {1318, 250, "不"}, {1175, 250, ""}, {1175, 500, "停"}, 
{1175, 500, "，"}, {1318, 250, "等"}, {1318, 500, "待"}, {1318, 250, "着"}, {1318, 250, "下"}, 
{1175, 250, ""}, {1175, 500, "课"}, {1046, 250, "等"}, {1046, 500, "待"}, {1046, 250, "着"}, 
{1175, 250, "放"}, {1046, 250, ""}, {880, 250, "学"}, {784, 250, "，"}, {784, 250, "等"}, 
{784, 250, "待"}, {0, 250, ""}, {784, 250, "有"}, {880, 250, "趣"}, {784, 250, "的"}, 
{1175, 250, "童"}, {1318, 250, ""}, {1046, 500, "年"}, {1046, 500, "。"}, {1046, 500, "\n"}, 
{659, 250, "总"}, {784, 250, "是"}, {784, 500, "要"}, {784, 250, "等"}, {659, 250, "到"}, 
{880, 250, "睡"}, {880, 250, "觉"}, {988, 250, "前"}, {880, 250, ""}, {0, 250, ""}, 
{880, 250, "才"}, {880, 250, "知"}, {784, 250, "道"}, {1046, 500, "功"}, {1046, 250, "课"}, 
{1046, 250, "只"}, {1046, 250, "做"}, {880, 250, "了"}, {1046, 250, "一"}, {880, 250, "点"}, 
{784, 500, "点"}, {784, 500, "，"}, {659, 250, "总"}, {784, 250, "是"}, {784, 500, "要"}, 
{784, 250, "等"}, {659, 250, "到"}, {880, 250, "考"}, {880, 250, "试"}, {988, 250, "以"}, 
{880, 250, "后"}, {0, 250, ""}, {880, 250, "才"}, {880, 250, "知"}, {784, 250, "道"}, 
{1046, 500, "该"}, {1046, 375, "念"}, {1046, 125, "的"}, {1046, 250, "书"}, {880, 250, "都"}, 
{880, 250, "没"}, {1046, 250, "有"}, {1175, 500, "念"}, {1175, 500, "。"}, {1568, 250, "一"}, 
{1568, 500, "寸"}, {1568, 125, "光"}, {1568, 125, ""}, {1568, 250, ""}, {1568, 250, "阴"}, 
{1318, 250, "一"}, {1175, 250, "寸"}, {1046, 250, "金"}, {1046, 500, ""}, {880, 250, "老"}, 
{880, 250, "师"}, {880, 250, "说"}, {1046, 250, "过"}, {880, 250, "寸"}, {1046, 250, "金"}, 
{1175, 250, "难"}, {1175, 250, ""}, {1175, 250, "买"}, {1046, 250, ""}, {1175, 250, "寸"}, 
{1046, 250, ""}, {1318, 250, "光"}, {1175, 250, ""}, {1175, 500, "阴"}, {1175, 500, "，"}, 
{1318, 250, "一"}, {1318, 500, "天"}, {1318, 250, "又"}, {1318, 250, "一"}, {1175, 250, ""}, 
{1175, 500, "天"}, {1046, 250, "一"}, {1046, 500, "年"}, {1046, 250, "又"}, {1175, 250, "一"}, 
{1046, 250, ""}, {880, 250, "年"}, {784, 250, "，"}, {784, 250, "迷"}, {784, 250, "迷"}, 
{0, 250, ""}, {784, 250, "糊"}, {880, 250, "糊"}, {784, 250, "的"}, {1175, 250, "童"}, 
{1318, 250, ""}, {1046, 500, "年"}, {1046, 500, "。"}, {1046, 500, "\n"}, {1318, 500, "噢"}, 
{1318, 250, "一"}, {1318, 500, "天"}, {1318, 250, "又"}, {1318, 250, "一"}, {1175, 250, ""}, 
{1175, 500, "天"}, {1046, 250, "一"}, {1046, 500, "年"}, {1046, 250, "又"}, {1175, 250, "一"}, 
{1046, 250, ""}, {880, 250, "年"}, {784, 250, "，"}, {784, 250, "盼"}, {784, 250, "望"}, 
{0, 250, ""}, {784, 250, "长"}, {880, 250, "大"}, {784, 250, "的"}, {1175, 250, "童"}, 
{1318, 250, ""}, {1046, 500, "年"}, {1046, 500, "。"}, {0, 500, ""}, };int a = 0; //全局变量

void yingyue(void *)
{
	int i;
	//结构体数组的长度sizeof(t)/sizeof(STU)得到，总结构体数组大小 / 单个结构体大小
	for (i=0; i<sizeof(t)/sizeof(STU); i++)
	{
//		printf("%s",t[i].text);
		Beep(t[i].freq,t[i].duration);
	}
	_endthread();
}
/* 0-黑色, 1-蓝色,   2-绿色,      3-浅绿色,     4-红色,   5-紫色,   6-黄色,   7-白色,
  8-灰色, 9-淡蓝色, 10-淡绿色,   11-淡浅绿色   12-淡红色 13-淡紫色 14-淡黄色 15-亮白色*/
void tip()
{
	system("cls"); 
  system("color a"); 
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);

		printf("\n这是迷宫的入口\n");
		for(int i=0;i<N;i++)
		{
			for(int j=0;j<N;j++)
			{
				if(mz[i][j]==0)
					cout<<"■";
				
				else if(i==1&&j==1)
					cout<<"★";
				else 
					cout<<"  ";
			} 
			printf("\n");
		}
	printf("                  --------------------------------------------------------------------------------------            \n"); 
	printf("                  		玩家请注意：                                                                                \n");
	printf("                            1.玩家走迷宫过程中不要试图撞墙哦，墙走不了的嘻嘻                                        \n");
	printf("                            2.方块是墙，五角星是玩家所在位置哦                                                      \n");
	printf("                            3.玩家输入想要的功能后稍等一会哦，不要输入其他的哦，否则程序容易出现错误！              \n");
	printf("                            4.不要总想看路径啊，自己走完迷宫才快乐(*^▽^*)                                          \n");
	printf("                            5.希望玩家玩得开心!                                                                     \n");	
	printf("这是迷宫的出口\n"); 			
	for(int i=0;i<N;i++)
	{
		for(int j=0;j<N;j++)
		{
			if(mz[i][j]==0)
				cout<<"■";
			else if(i==8&&j==8)
				cout<<"★";
				else
				cout<<"  ";
			 
		} 
		printf("\n");
	} 
  system("color a"); 
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);
  printf("☆");Sleep(30);
  printf("★");Sleep(30);

}

void Mazeinit()
{
	for(int i=0;i<N;i++)
	{
		for(int j=0;j<N;j++)
		{
			mz[i][j]=mm[i][j];
		}
	}
	begin.x=1;
	begin.y=1;
	end.x=8;
	end.y=8;
}

void MazePrint()
{
	for(int i=0;i<N;i++)
	{
		for(int j=0;j<N;j++)
		{
			if(mz[i][j]==0)
				cout<<"■";
			else if(mz[i][j]==5)
				cout<<"★";
			else 
				cout<<"  ";
		}
		printf("\n");
	}
}

void Button()
{
	if(kbhit())
	{
		while(kbhit())
			key=getch();
		switch(key)
		{
			case 75:kk=0;break; //下 
			case 77:kk=1;break; //上 
			case 72:kk=2;break; //左 
			case 80:kk=3;break; //右 
		}
	}
}

void NextPos(PosType &c,int di)
{ 
	PosType direc[5]={{0,-1},{0,1},{-1,0},{1,0},{0,0}};
	c.x+=direc[di].x;
	c.y+=direc[di].y;
}

void LastPos(PosType &c,int di)
{ 
	PosType direc[5]={{0,1},{0,-1},{1,0},{-1,0},{0,0}};
	c.x+=direc[di].x;
	c.y+=direc[di].y;
}

void Move()
{
	mz[curpos.x][curpos.y]=-1;
	NextPos(curpos,kk);
	if(mz[curpos.x][curpos.y]==0)
	{
		LastPos(curpos,kk);
	} 
	mz[curpos.x][curpos.y]=5;
	kk=4; 
}

void Show()
{
	int i;
	clock_t start, finish;
    double  duration;
    double time=15.0;
	while(1)
	{
		start = clock();
		Sleep(500);//休息1秒 
		Button();//识别按键 
		Move();
		finish = clock();
		time = time-(double)(finish - start) / CLOCKS_PER_SEC;
		system("cls");//实现清屏功能 
		MazePrint();//迷宫打印 
		printf("剩余：%.1lf秒",time);
		if(curpos.x==end.x&&curpos.y==end.y)
		{
			printf("你走出迷宫啦"); 
			printf("游戏所用时间：%.1lf秒",15-time);
			break; 
		}
		if(time<=0) 
		{
			system("cls");
			MazePrint();
			printf("游戏时间超时!"); break;
		}
	}
	
}

void InitStack(SqStack &S)
{ 
  	S.base=(SElemtp *)malloc(STACK_INIT_SIZE*sizeof(SElemtp));
   	S.top=S.base;
   	S.stacksize=STACK_INIT_SIZE;
}

void Push(SqStack &S,SElemtp e)//入栈 
{ 
	S.base=(SElemtp *)realloc(S.base,(S.stacksize+2)*sizeof(SElemtp));
	S.stacksize++;
	*S.top=e;
	S.top++; 
}

bool Pop(SqStack &S,SElemtp &e)//出栈 
{ 
	if(S.top==S.base)
		return false;
	e=*--(S.top);
	S.stacksize--;
	return true;
}

int StackEmpty(SqStack S)
{ 
	if(S.top==S.base)
     	return 1;
   	else
    	return 0;
}

void ShowShow(SqStack S) 
{
	while(S.top>S.base)
	{
		Sleep(200);
		mz[S.base->seat.x][S.base->seat.y]=5;
		++S.base;
		system("cls");
		printf("此迷宫从入口到出口的一条路径如下:\n");
		MazePrint();
	}
	printf("\n");
}

void ClearStack(SqStack &S)
 { // 把S置为空栈
   S.top=S.base;
 }
 
int MazePath(SqStack &S,PosType start,PosType end)
{ 
    PosType curposs; 
    SElemtp e;
    InitStack(S); 
    curposs=start;
    do
    {
      	if(mz[curposs.x][curposs.y]==1)
     	{ 
	        mz[curposs.x][curposs.y]=-1; 
	        e.seat=curposs;
	        e.di=0;
	        Push(S,e);
			curstep++; 
	        if(curposs.x==end.x&&curposs.y==end.y) 
	         	return 1;
	        NextPos(curposs,e.di); 
     	}
     	else
     	{ 
       		if(!StackEmpty(S)) 
       		{
         		Pop(S,e);  
         		curstep--;
         		while(e.di==3&&!StackEmpty(S)) 
         		{
           			mz[e.seat.x][e.seat.y]=-1; 
           			Pop(S,e);
           			curstep--;
         		}
         		if(e.di<3)
         		{
		           	e.di++; 
		           	Push(S,e);
		           	curstep++;
		           	curposs=e.seat; 
		           	NextPos(curposs,e.di); 
         		}
       		}
     	}
   	}while(!StackEmpty(S));
   	return 0;
}

void Print()// 输出迷宫的解(m数组)
{ 
	int i,j;
	for(i=0;i<N;i++)
	{
		for(j=0;j<N;j++)
		printf("%3d",mz[i][j]);
		printf("\n");
	}
}

void Editor()
{
	int x,y,sign,ch;
	printf("初始地图：\n"); 
	MazePrint();
	printf("开始修改吗宝贝(#^.^#)~(修改输入666):"); 
	scanf("%d",&ch);
	while(ch==666) 
	{
		system("cls");
		MazePrint();
		printf("请输入想要修改的第几行第几列：");
		scanf("%d%d",&x,&y);
		printf("墙变路输入1，路边墙输入0:");
		scanf("%d",&sign);
		switch(sign)
		{
			case 1:mz[x-1][y-1]=1;break;
			case 0:mz[x-1][y-1]=0;break;
		}
		printf("修改过后地图为：\n"); 
		MazePrint();
		printf("继续吗？(*^▽^*)(继续输入666，不想继续请按88):");
		scanf("%d",&ch);
		if(ch==88)
		{
			printf("不修改了吗？o(╥﹏╥)o小主，相信现在修改出的迷宫一定更棒啦(＾－＾)V");	
		} 
		for(int i=0;i<N;i++)
		{
			for(int j=0;j<N;j++)
			{
				mm[i][j]=mz[i][j];
			}
		} 
	} 
	
}
void color()
{
int time;

	system("color a");
	for(time=0;time<20;time++); 
	system("color b");
	for(time=0;time<10;time++);
	system("color c");
	for(time=0;time<20;time++);
	system("color b");
	for(time=0;time<20;time++);
	system("color c");
	for(time=0;time<10;time++);
	system("color e");
	for(time=0;time<10;time++);
	system("color e");
	for(time=0;time<10;time++);
	system("color c");
	for(time=0;time<20;time++);
	system("color f");
	for(time=0;time<10;time++);
	system("color 0");
	for(time=0;time<10;time++);
	system("color 1");
	for(time=0;time<10;time++);
	system("color 2");
	for(time=0;time<5;time++);
	system("color 3");
	for(time=0;time<10;time++);
	system("color 4");
	for(time=0;time<10;time++);
	system("color 5");
	for(time=0;time<15;time++);
	system("color 6");
	for(time=0;time<10;time++);
	system("color 5");
	for(time=0;time<10;time++);
	system("color 7");
	for(time=0;time<10;time++);
	system("color 8");
	for(time=0;time<10;time++);
	system("color 8");
	for(time=0;time<10;time++);
	system("color 5");
	for(time=0;time<10;time++);
	system("color 5");
	for(time=0;time<10;time++);
	system("color 8");
	for(time=0;time<10;time++);
	system("color 8");
	for(time=0;time<10;time++);
	system("color 7");
	for(time=0;time<20;time++);
	system("color c");
	for(time=0;time<10;time++);
	system("color e");
	
	for(time=0;time<10;time++);
	system("color c");
	for(time=0;time<20;time++);
	system("color f");
	for(time=0;time<10;time++);
	system("color e");
	for(time=0;time<10;time++);
	system("color 0");
	for(time=0;time<10;time++);
	system("color 1");
	for(time=0;time<10;time++);
	system("color 9");
	for(time=0;time<5;time++);
	system("color 3");
	for(time=0;time<10;time++);
	system("color 2");
	for(time=0;time<10;time++);
	system("color 7");
	for(time=0;time<10;time++);
	system("color 8");
	for(time=0;time<10;time++);
	system("color 7");

}
int main()
{
	int choose;
	SqStack S;
	_beginthread(yingyue,0,NULL);
	printf("游戏小提示：\n");
	Mazeinit();
	tip();
	color();
	system("cls");
	while(1)
	{
		Mazeinit();
		system("cls");
		printf("╔════════════════════════════════════════════════════════════════════╗\n");
		printf("║                    欢迎进入走迷宫游戏演示系统                      ║\n");
		printf("║           ---------------------------------------------            ║\n");
		printf("║                  1.开始游戏                                        ║\n"); 
		printf("║                  2.查看能到达终点的路径                            ║\n");
		printf("║                  3.修改地图                                        ║\n");
		printf("║                  4.游戏提示                                        ║\n");
		printf("║                  5.退出系统                                        ║\n");
		printf("╚════════════════════════════════════════════════════════════════════╝\n");
		printf(">>>>>>>>>>>>\n");
		printf("迷宫地图是这样子的哦\n");
		MazePrint();
		printf("请选择你的操作:[ ]\b\b");
		scanf("%d",&choose);
		switch(choose)
		{
			case 1:
				{
					curpos=begin;	
					Show();
				}
				break;
			case 2:curstep=0;
			    if(MazePath(S,begin,end))
			    {
			    	printf(">>>>>>>>>运动路径马上来了，不要走哦！<<<<<<<<<<<"); 
			    	ShowShow(S);
			    	printf("一共走了%d步，就到达终点了！",curstep);
			    	ClearStack(S);
				}
				else
					printf("此迷宫没有从入口到出口的路径\n");
				break; 
			case 3:
				{
					system("cls");
					Editor();
				}
				break;
			case 4: 
			tip();
			color();
			break;
			case 5:exit(0);break; 
		}	
		Sleep(1000);
	}
}

