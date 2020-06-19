text()
function text()
dim a
a=InputBox("请大声说出我喜欢你！")
if a="我喜欢你" then
msgbox"哈哈，我也喜欢你",0,"恭喜"
msgbox"跟我走吧",0,"恭喜"
msgbox"我们去民政局登记！",0,"恭喜"
else
msgbox"不行，你要说我喜欢你！",0,"再来一次"
text()
end if
end function