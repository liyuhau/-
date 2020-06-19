#include<stdio.h>
#include<stdlib.h>
#include<malloc.h>
typedef char TElemtp;
typedef struct BiTNode
{
	TElemtp data;
	struct BiTNode *lchild,*rchild;
}BiTtree;

BiTtree *CreateBiTree()
{
	BiTtree *T;
	TElemtp ch;
	scanf("%c",&ch);
	if(ch==' ')
	{
		T=NULL;
	}	
	else
	{
		T=(BiTtree *)malloc(sizeof(BiTtree)); // ���ɸ����
		T->data=ch;
		T->lchild=CreateBiTree(); // ����������
		T->rchild=CreateBiTree(); // ����������
	}
	return T;
}

typedef struct 
{
	BiTtree *base; // ��ջ����֮ǰ������֮��base��ֵΪNULL
	BiTtree *top; // ջ��ָ��
	int stacksize; // ��ǰ�ѷ���Ĵ洢�ռ䣬��Ԫ��Ϊ��λ
}Sqstack; 

void push(Sqstack *S,BiTtree e)//��ջ 
{ 
	S->base=(BiTtree *)realloc(S->base,(S->stacksize+1)*sizeof(BiTtree));
	S->stacksize++;
	*S->top=e;
	S->top++; 
}

void CreatStack(Sqstack *S)//�½�˳��ջ 
{ 
	S->base=(BiTtree *)malloc(sizeof(BiTtree));
	S->top=S->base;
	S->stacksize=0;
}

bool pop(Sqstack *S,BiTtree *e)//��ջ 
{ 
	if(S->top==S->base)
		return false;
	*e=*--(S->top);
	S->stacksize--;
	return true;
}

int StackEmpty(Sqstack S)
{
	if (S.base == S.top)
		return 1;
	else
		return 0;
}

int Visit(BiTtree *e)
{
	if (e == NULL)
		return 0;
	else
	{
		printf("%c ", e->data);
		return 1;
	}
}

int DestroyStack(Sqstack *S)
{
	if (S->base)
	{
		free(S->base);
		return 1;
	}
	return 0;
}
int InOrderTraverse(BiTtree *T)
{
	Sqstack S;
	CreatStack(&S);
	BiTtree *p;
	p=T;
	while(p||!StackEmpty(S))
	{
		if(p)
		{
			push(&S,*p);
			p=p->lchild;
		}
		else
		{
			pop(&S,p);
			if (!Visit(p)) 
				return 0;
			p = p->rchild;
		}
	}
	DestroyStack(&S);	
}

int main()
{
	BiTtree *T;
	T=CreateBiTree();
	InOrderTraverse(T);	
} 
