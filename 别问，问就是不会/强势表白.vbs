text()
function text()
dim a
a=InputBox("�����˵����ϲ���㣡")
if a="��ϲ����" then
msgbox"��������Ҳϲ����",0,"��ϲ"
msgbox"�����߰�",0,"��ϲ"
msgbox"����ȥ�����ֵǼǣ�",0,"��ϲ"
else
msgbox"���У���Ҫ˵��ϲ���㣡",0,"����һ��"
text()
end if
end function