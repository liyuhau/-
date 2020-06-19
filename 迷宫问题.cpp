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
	int freq; //����
	int duration;//����ʱ��
	char text[32];//�ı�����
}STU;

STU t[] = {{1318, 250, ""}, {1318, 500, ""}, {1318, 500, ""}, {1318, 250, ""}, {1175, 250, ""}, {1175, 500, ""}, 
{1046, 250, ""}, {1046, 500, ""}, {1046, 250, ""}, {1175, 250, ""}, {1046, 250, ""}, 
{880, 250, ""}, {784, 250, ""}, {784, 250, ""}, {784, 500, ""}, {784, 250, ""}, 
{880, 250, ""}, {784, 250, ""}, {1175, 250, ""}, {1318, 250, ""}, {1046, 500, ""}, 
{1046, 500, "\n"}, {659, 250, "��"}, {784, 250, "��"}, {784, 500, "��"}, {784, 250, ""}, 
{659, 250, "��"}, {880, 250, "��"}, {880, 250, "��"}, {988, 250, "��"}, {880, 250, ""}, 
{0, 250, ""}, {880, 250, "ֻ"}, {880, 250, "��"}, {784, 250, "��"}, {1046, 500, "��"}, 
{1046, 250, "��"}, {1046, 250, "��"}, {1046, 250, "��"}, {880, 250, ""}, {1046, 250, "��"}, 
{880, 250, "��"}, {784, 500, "��"}, {784, 500, "��"}, {659, 250, "��"}, {784, 250, "��"}, 
{784, 500, "��"}, {784, 250, ""}, {659, 250, "��"}, {880, 250, "��"}, {880, 250, "ǧ"}, 
{988, 250, "��"}, {880, 250, "��"}, {0, 250, ""}, {880, 250, "ֻ"}, {880, 250, "��"}, 
{784, 250, ""}, {1046, 500, "��"}, {1046, 375, "��"}, {1046, 125, ""}, {1046, 250, "ͣ"}, 
{880, 250, "��"}, {880, 250, "��"}, {1046, 250, ""}, {1175, 500, "��"}, {1175, 500, "��"}, 
{1568, 250, "��"}, {1568, 500, "��"}, {1568, 125, "��"}, {1568, 125, ""}, {1568, 250, ""}, 
{1568, 250, "��"}, {1318, 250, "ʦ"}, {1175, 250, "��"}, {1046, 250, "��"}, {1046, 500, "��"}, 
{880, 250, "��"}, {880, 250, ""}, {880, 250, ""}, {1046, 250, "��"}, {880, 250, "ƴ"}, 
{1046, 250, "��"}, {1175, 250, "ߴ"}, {1175, 250, "ߴ"}, {1175, 250, "��"}, {1046, 250, "��"}, 
{1175, 250, "д"}, {1046, 250, "��"}, {1318, 250, "��"}, {1175, 250, ""}, {1175, 500, "ͣ"}, 
{1175, 500, "��"}, {1318, 250, "��"}, {1318, 500, "��"}, {1318, 250, "��"}, {1318, 250, "��"}, 
{1175, 250, ""}, {1175, 500, "��"}, {1046, 250, "��"}, {1046, 500, "��"}, {1046, 250, "��"}, 
{1175, 250, "��"}, {1046, 250, ""}, {880, 250, "ѧ"}, {784, 250, "��"}, {784, 250, "��"}, 
{784, 250, "��"}, {0, 250, ""}, {784, 250, "��"}, {880, 250, "Ȥ"}, {784, 250, "��"}, 
{1175, 250, "ͯ"}, {1318, 250, ""}, {1046, 500, "��"}, {1046, 500, "��"}, {1046, 500, "\n"}, 
{659, 250, "��"}, {784, 250, "��"}, {784, 500, "Ҫ"}, {784, 250, "��"}, {659, 250, "��"}, 
{880, 250, "˯"}, {880, 250, "��"}, {988, 250, "ǰ"}, {880, 250, ""}, {0, 250, ""}, 
{880, 250, "��"}, {880, 250, "֪"}, {784, 250, "��"}, {1046, 500, "��"}, {1046, 250, "��"}, 
{1046, 250, "ֻ"}, {1046, 250, "��"}, {880, 250, "��"}, {1046, 250, "һ"}, {880, 250, "��"}, 
{784, 500, "��"}, {784, 500, "��"}, {659, 250, "��"}, {784, 250, "��"}, {784, 500, "Ҫ"}, 
{784, 250, "��"}, {659, 250, "��"}, {880, 250, "��"}, {880, 250, "��"}, {988, 250, "��"}, 
{880, 250, "��"}, {0, 250, ""}, {880, 250, "��"}, {880, 250, "֪"}, {784, 250, "��"}, 
{1046, 500, "��"}, {1046, 375, "��"}, {1046, 125, "��"}, {1046, 250, "��"}, {880, 250, "��"}, 
{880, 250, "û"}, {1046, 250, "��"}, {1175, 500, "��"}, {1175, 500, "��"}, {1568, 250, "һ"}, 
{1568, 500, "��"}, {1568, 125, "��"}, {1568, 125, ""}, {1568, 250, ""}, {1568, 250, "��"}, 
{1318, 250, "һ"}, {1175, 250, "��"}, {1046, 250, "��"}, {1046, 500, ""}, {880, 250, "��"}, 
{880, 250, "ʦ"}, {880, 250, "˵"}, {1046, 250, "��"}, {880, 250, "��"}, {1046, 250, "��"}, 
{1175, 250, "��"}, {1175, 250, ""}, {1175, 250, "��"}, {1046, 250, ""}, {1175, 250, "��"}, 
{1046, 250, ""}, {1318, 250, "��"}, {1175, 250, ""}, {1175, 500, "��"}, {1175, 500, "��"}, 
{1318, 250, "һ"}, {1318, 500, "��"}, {1318, 250, "��"}, {1318, 250, "һ"}, {1175, 250, ""}, 
{1175, 500, "��"}, {1046, 250, "һ"}, {1046, 500, "��"}, {1046, 250, "��"}, {1175, 250, "һ"}, 
{1046, 250, ""}, {880, 250, "��"}, {784, 250, "��"}, {784, 250, "��"}, {784, 250, "��"}, 
{0, 250, ""}, {784, 250, "��"}, {880, 250, "��"}, {784, 250, "��"}, {1175, 250, "ͯ"}, 
{1318, 250, ""}, {1046, 500, "��"}, {1046, 500, "��"}, {1046, 500, "\n"}, {1318, 500, "��"}, 
{1318, 250, "һ"}, {1318, 500, "��"}, {1318, 250, "��"}, {1318, 250, "һ"}, {1175, 250, ""}, 
{1175, 500, "��"}, {1046, 250, "һ"}, {1046, 500, "��"}, {1046, 250, "��"}, {1175, 250, "һ"}, 
{1046, 250, ""}, {880, 250, "��"}, {784, 250, "��"}, {784, 250, "��"}, {784, 250, "��"}, 
{0, 250, ""}, {784, 250, "��"}, {880, 250, "��"}, {784, 250, "��"}, {1175, 250, "ͯ"}, 
{1318, 250, ""}, {1046, 500, "��"}, {1046, 500, "��"}, {0, 500, ""}, };int a = 0; //ȫ�ֱ���

void yingyue(void *)
{
	int i;
	//�ṹ������ĳ���sizeof(t)/sizeof(STU)�õ����ܽṹ�������С / �����ṹ���С
	for (i=0; i<sizeof(t)/sizeof(STU); i++)
	{
//		printf("%s",t[i].text);
		Beep(t[i].freq,t[i].duration);
	}
	_endthread();
}
/* 0-��ɫ, 1-��ɫ,   2-��ɫ,      3-ǳ��ɫ,     4-��ɫ,   5-��ɫ,   6-��ɫ,   7-��ɫ,
  8-��ɫ, 9-����ɫ, 10-����ɫ,   11-��ǳ��ɫ   12-����ɫ 13-����ɫ 14-����ɫ 15-����ɫ*/
void tip()
{
	system("cls"); 
  system("color a"); 
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);

		printf("\n�����Թ������\n");
		for(int i=0;i<N;i++)
		{
			for(int j=0;j<N;j++)
			{
				if(mz[i][j]==0)
					cout<<"��";
				
				else if(i==1&&j==1)
					cout<<"��";
				else 
					cout<<"  ";
			} 
			printf("\n");
		}
	printf("                  --------------------------------------------------------------------------------------            \n"); 
	printf("                  		�����ע�⣺                                                                                \n");
	printf("                            1.������Թ������в�Ҫ��ͼײǽŶ��ǽ�߲��˵�����                                        \n");
	printf("                            2.������ǽ����������������λ��Ŷ                                                      \n");
	printf("                            3.���������Ҫ�Ĺ��ܺ��Ե�һ��Ŷ����Ҫ����������Ŷ������������׳��ִ���              \n");
	printf("                            4.��Ҫ���뿴·�������Լ������Թ��ſ���(*^��^*)                                          \n");
	printf("                            5.ϣ�������ÿ���!                                                                     \n");	
	printf("�����Թ��ĳ���\n"); 			
	for(int i=0;i<N;i++)
	{
		for(int j=0;j<N;j++)
		{
			if(mz[i][j]==0)
				cout<<"��";
			else if(i==8&&j==8)
				cout<<"��";
				else
				cout<<"  ";
			 
		} 
		printf("\n");
	} 
  system("color a"); 
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);
  printf("��");Sleep(30);

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
				cout<<"��";
			else if(mz[i][j]==5)
				cout<<"��";
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
			case 75:kk=0;break; //�� 
			case 77:kk=1;break; //�� 
			case 72:kk=2;break; //�� 
			case 80:kk=3;break; //�� 
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
		Sleep(500);//��Ϣ1�� 
		Button();//ʶ�𰴼� 
		Move();
		finish = clock();
		time = time-(double)(finish - start) / CLOCKS_PER_SEC;
		system("cls");//ʵ���������� 
		MazePrint();//�Թ���ӡ 
		printf("ʣ�ࣺ%.1lf��",time);
		if(curpos.x==end.x&&curpos.y==end.y)
		{
			printf("���߳��Թ���"); 
			printf("��Ϸ����ʱ�䣺%.1lf��",15-time);
			break; 
		}
		if(time<=0) 
		{
			system("cls");
			MazePrint();
			printf("��Ϸʱ�䳬ʱ!"); break;
		}
	}
	
}

void InitStack(SqStack &S)
{ 
  	S.base=(SElemtp *)malloc(STACK_INIT_SIZE*sizeof(SElemtp));
   	S.top=S.base;
   	S.stacksize=STACK_INIT_SIZE;
}

void Push(SqStack &S,SElemtp e)//��ջ 
{ 
	S.base=(SElemtp *)realloc(S.base,(S.stacksize+2)*sizeof(SElemtp));
	S.stacksize++;
	*S.top=e;
	S.top++; 
}

bool Pop(SqStack &S,SElemtp &e)//��ջ 
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
		printf("���Թ�����ڵ����ڵ�һ��·������:\n");
		MazePrint();
	}
	printf("\n");
}

void ClearStack(SqStack &S)
 { // ��S��Ϊ��ջ
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

void Print()// ����Թ��Ľ�(m����)
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
	printf("��ʼ��ͼ��\n"); 
	MazePrint();
	printf("��ʼ�޸��𱦱�(#^.^#)~(�޸�����666):"); 
	scanf("%d",&ch);
	while(ch==666) 
	{
		system("cls");
		MazePrint();
		printf("��������Ҫ�޸ĵĵڼ��еڼ��У�");
		scanf("%d%d",&x,&y);
		printf("ǽ��·����1��·��ǽ����0:");
		scanf("%d",&sign);
		switch(sign)
		{
			case 1:mz[x-1][y-1]=1;break;
			case 0:mz[x-1][y-1]=0;break;
		}
		printf("�޸Ĺ����ͼΪ��\n"); 
		MazePrint();
		printf("������(*^��^*)(��������666����������밴88):");
		scanf("%d",&ch);
		if(ch==88)
		{
			printf("���޸�����o(�i�n�i)oС�������������޸ĳ����Թ�һ��������(�ޣ���)V");	
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
	printf("��ϷС��ʾ��\n");
	Mazeinit();
	tip();
	color();
	system("cls");
	while(1)
	{
		Mazeinit();
		system("cls");
		printf("�X�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�[\n");
		printf("�U                    ��ӭ�������Թ���Ϸ��ʾϵͳ                      �U\n");
		printf("�U           ---------------------------------------------            �U\n");
		printf("�U                  1.��ʼ��Ϸ                                        �U\n"); 
		printf("�U                  2.�鿴�ܵ����յ��·��                            �U\n");
		printf("�U                  3.�޸ĵ�ͼ                                        �U\n");
		printf("�U                  4.��Ϸ��ʾ                                        �U\n");
		printf("�U                  5.�˳�ϵͳ                                        �U\n");
		printf("�^�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�T�a\n");
		printf(">>>>>>>>>>>>\n");
		printf("�Թ���ͼ�������ӵ�Ŷ\n");
		MazePrint();
		printf("��ѡ����Ĳ���:[ ]\b\b");
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
			    	printf(">>>>>>>>>�˶�·���������ˣ���Ҫ��Ŷ��<<<<<<<<<<<"); 
			    	ShowShow(S);
			    	printf("һ������%d�����͵����յ��ˣ�",curstep);
			    	ClearStack(S);
				}
				else
					printf("���Թ�û�д���ڵ����ڵ�·��\n");
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

