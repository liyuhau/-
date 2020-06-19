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

void IntraverseBiTree(BiTtree *T)
{
 	if(T!=NULL)
 	{
  		if(T->lchild!=NULL)
   			IntraverseBiTree(T->lchild);
		printf("%c ",T->data);
		if(T->rchild!=NULL)
   			IntraverseBiTree(T->rchild);
 	}
}

int main()
{
	BiTtree *T;
	T=CreateBiTree();
	IntraverseBiTree(T);
}
