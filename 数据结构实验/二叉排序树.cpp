#include<stdio.h>
#include<malloc.h>
typedef int KeyType;
struct TElemtp
{
	KeyType key;
};

typedef struct BiTNode
{
	TElemtp data;
	struct BiTNode *lchild,*rchild;
}BiTNode, *BiTree; 

void InitBiTree(BiTree &T)
{ 
    T=NULL;
}

bool SearchBST(BiTree &T,KeyType key,BiTree f,BiTree &p)
{
	if(!T)
	{
		p=f;
		return false;
	}
	else if(key==T->data.key)
	{
		p=T;
		return true;
	}
	else if(key<T->data.key)
	{
		return SearchBST(T->lchild,key,T,p);
	}
	else
	{
		return SearchBST(T->rchild,key,T,p);
	}
}

bool InsertBST(BiTree &T,TElemtp e)
{
	BiTree p,s;
	if(!SearchBST(T,e.key,NULL,p))
	{
		s=(BiTree)malloc(sizeof(BiTNode));
		s->data=e;
		s->lchild=s->rchild=NULL;
		if(!p) 
			T=s;
		else if(e.key<p->data.key)
			p->lchild=s;
		else
			p->rchild=s;
		return true;
	}
	else
		return false;
}

void Delete(BiTree &p)
{
	BiTree q,s;
	if(!p->lchild)
	{
		q=p;
		p=p->rchild;
		free(q);
	}
	else if(!p->rchild)
	{
		q=p;
		p=p->lchild;
		free(q);
	}
	else
	{
		q=p;
		s=p->lchild;
		while(s->rchild)
		{
			q=s;
			s=s->rchild;
		}
		p->data=s->data;
		if(q!=p)
			q->rchild=s->lchild;
		else
			q->lchild=s->lchild;
		free(s);
	}
}

bool DeleteBST(BiTree &T,KeyType key)
{
	if(!T) 
		return false;
	else
	{
		if(key==T->data.key)
			Delete(T);
		else if(key<T->data.key)
			DeleteBST(T->lchild,key);
		else
			DeleteBST(T->rchild,key);
		return true; 
	}
} 

void IntraverseBiTree(BiTree T)
{
 	if(T!=NULL)
 	{
  		if(T->lchild!=NULL)
   			IntraverseBiTree(T->lchild);
		printf("%d ",T->data.key);
		if(T->rchild!=NULL)
   			IntraverseBiTree(T->rchild);
 	}
}

int main()
{
	BiTree T,p;
	TElemtp tp;
	KeyType key;
	int i,n;
	printf("�����������������Ԫ�ظ�����");
	scanf("%d",&n); 
	InitBiTree(T); // ����ձ�
	printf("\n������Ԫ�����ݣ�"); 
	for(i=0;i<n;i++)
	{
		scanf("%d",&tp.key);
		InsertBST(T,tp); // ���β�������Ԫ��
	}
	printf("\n�������������������"); 
	IntraverseBiTree(T);
	printf("\n\n");
	printf("��������Ҫɾ����Ԫ��key:");
	scanf("%d",&key);
	printf("\n");
	SearchBST(T,key,NULL,p);
	if(p)
	{
		printf("���ҵ������Ԫ��!\n\n");
		DeleteBST(T,key); 
		printf("ɾ��Ԫ�غ����������������");
		IntraverseBiTree(T);
	}
	else
	{
		printf("û�ҵ���Ҫɾ����Ԫ��!\n\n");
	} 
	
}
