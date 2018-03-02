<%@ Page language="c#" Codebehind="wfmModifyAdvancePayment.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.SalesManage.wfmModifyAdvancePayment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmModifyAdvancePayment</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../css/style.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../script/calendar.js"></script>
		<script language="JScript">
<!--
//可以打包为js文件;
var x0=0,y0=0,x1=0,y1=0;
var offx=6,offy=6;
var moveable=false;
var hover='orange',normal='#336699';//color;
var index=10000;//z-index;
//开始拖动;
function startDrag(obj)
{
 if(event.button==1)
 {
  //锁定标题栏;
  obj.setCapture();
  //定义对象;
  var win = obj.parentNode;
  var sha = win.nextSibling;
  //记录鼠标和层位置;
  x0 = event.clientX;
  y0 = event.clientY;
  x1 = parseInt(win.style.left);
  y1 = parseInt(win.style.top);
  //记录颜色;
  normal = obj.style.backgroundColor;
  //改变风格;
  obj.style.backgroundColor = hover;
  win.style.borderColor = hover;
  obj.nextSibling.style.color = hover;
  sha.style.left = x1 + offx;
  sha.style.top  = y1 + offy;
  moveable = true;
 }
}
//拖动;
function drag(obj)
{
 if(moveable)
 {
  var win = obj.parentNode;
  var sha = win.nextSibling;
  win.style.left = x1 + event.clientX - x0;
  win.style.top  = y1 + event.clientY - y0;
  sha.style.left = parseInt(win.style.left) + offx;
  sha.style.top  = parseInt(win.style.top) + offy;
 }
}
//停止拖动;
function stopDrag(obj)
{
 if(moveable)
 {
  var win = obj.parentNode;
  var sha = win.nextSibling;
  var msg = obj.nextSibling;
  win.style.borderColor     = normal;
  obj.style.backgroundColor = normal;
  msg.style.color           = normal;
  sha.style.left = obj.parentNode.style.left;
  sha.style.top  = obj.parentNode.style.top;
  obj.releaseCapture();
  moveable = false;
 }
}
//获得焦点;
function getFocus(obj)
{
 if(obj.style.zIndex!=index)
 {
  index = index + 2;
  var idx = index;
  obj.style.zIndex=idx;
  obj.nextSibling.style.zIndex=idx-1;
 }
}
//最小化;
function min(obj)
{
 var win = obj.parentNode.parentNode;
 var sha = win.nextSibling;
 var tit = obj.parentNode;
 var msg = tit.nextSibling;
 var flg = msg.style.display=="none";
 if(flg)
 {
  win.style.height  = parseInt(msg.style.height) + parseInt(tit.style.height) + 2*2;
  sha.style.height  = win.style.height;
  msg.style.display = "block";
  obj.innerHTML = "0";
 }
 else
 {
  win.style.height  = parseInt(tit.style.height) + 2*2;
  sha.style.height  = win.style.height;
  obj.innerHTML = "2";
  msg.style.display = "none";
 }
}
//创建一个对象;
function xWin(id,w,h,l,t)
{
 index = index+2;
 this.id      = id;
 this.width   = w;
 this.height  = h;
 this.left    = l;
 this.top     = t;
 this.zIndex  = index;
 this.obj     = null;
}

//显示隐藏窗口
function ShowHide(id,dis){
 var bdisplay = (dis==null)?((document.getElementById("xMsg1"+id).style.display=="")?"none":""):dis
 document.getElementById("xMsg1"+id).style.display = bdisplay;
 document.getElementById("xMsg4"+id).style.display = bdisplay;
}

//-->
		</script>
		<script language='JScript'>
<!--
function CPos(x, y)
{
    this.x = x;
    this.y = y;
}
//获取控件的位置
function GetObjPos(ATarget)
{
    var target = ATarget;
    var pos = new CPos(target.offsetLeft, target.offsetTop);
    
    var target = target.offsetParent;
    while (target)
    {
        pos.x += target.offsetLeft;
        pos.y += target.offsetTop;
        
        target = target.offsetParent
    }
    
    return pos;
}

function initialize()
{

  var pos=GetObjPos(document.getElementById("btnSelected"));
  var xMsg = new xWin("1",300,200,pos.x,pos.y+document.getElementById("btnSelected").offsetHeight);
  document.getElementById("xMsg1"+xMsg.id).style.zIndex=xMsg.zIndex;
  document.getElementById("xMsg1"+xMsg.id).style.width=xMsg.width;
  document.getElementById("xMsg1"+xMsg.id).style.height=xMsg.height;
  document.getElementById("xMsg1"+xMsg.id).style.left=xMsg.left;
  document.getElementById("xMsg1"+xMsg.id).style.top=xMsg.top;
  document.getElementById("xMsg1"+xMsg.id).style.position="absolute";
  
  document.getElementById("xMsg1"+xMsg.id).style.backgroundColor=normal;
  document.getElementById("xMsg1"+xMsg.id).style.color=normal;
  document.getElementById("xMsg1"+xMsg.id).style.fontSize="8pt";
  document.getElementById("xMsg1"+xMsg.id).style.fontFamily="Tahoma";
  document.getElementById("xMsg1"+xMsg.id).style.cursor="default";
  document.getElementById("xMsg1"+xMsg.id).style.border="2px solid " + normal;

  document.getElementById("xMsg2"+xMsg.id).style.backgroundColor=normal;
  document.getElementById("xMsg2"+xMsg.id).style.width=xMsg.width-2*2;
  document.getElementById("xMsg2"+xMsg.id).style.height=20;
  document.getElementById("xMsg2"+xMsg.id).style.color="white";

 document.getElementById("xMsgs1"+xMsg.id).style.width =xMsg.width-2*12-20;
 document.getElementById("xMsgs1"+xMsg.id).style.paddingLeft="3px";
 
 document.getElementById("xMsg3"+xMsg.id).style.width="100%";
 document.getElementById("xMsg3"+xMsg.id).style.height=xMsg.height-20-4;
 document.getElementById("xMsg3"+xMsg.id).style.backgroundColor="white";
 document.getElementById("xMsg3"+xMsg.id).style.lineHeight="14px";
 document.getElementById("xMsg3"+xMsg.id).style.padding="3px";
    
document.getElementById("xMsg4"+xMsg.id).style.zIndex=xMsg.zIndex-1;
document.getElementById("xMsg4"+xMsg.id).style.width=xMsg.width;
document.getElementById("xMsg4"+xMsg.id).style.height=xMsg.height;
document.getElementById("xMsg4"+xMsg.id).style.left=xMsg.left;
document.getElementById("xMsg4"+xMsg.id).style.top=xMsg.top;
document.getElementById("xMsg4"+xMsg.id).style.position="absolute";

document.getElementById("xMsg4"+xMsg.id).style.backgroundColor="black";
document.getElementById("xMsg4"+xMsg.id).style.filter="alpha(opacity=40)";

 //ShowHide("1","none");//隐藏窗口1
}
window.onload = initialize;
//-->
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table align="center">
				<tr>
					<td colspan="2">
						<asp:Label id="Label1" runat="server" style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033">修改预收账款</asp:Label></td>
				</tr>
			</table>
			<table align="center">
				<tr>
					<td>
						<asp:Label id="Label4" runat="server">客户名称：</asp:Label></td>
					<td>
						<asp:TextBox id="txtCustName" runat="server"></asp:TextBox>
						<asp:TextBox id="txtCustID" runat="server" Visible="False"></asp:TextBox><INPUT id="btnSelected" onclick="ShowHide('1',null);return false;" type="button" value="关联客户"
							style="DISPLAY:none"></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label2" runat="server">项目名称：</asp:Label></td>
					<td>
						<asp:TextBox id="txtProjectName" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label3" runat="server">账户名称：</asp:Label></td>
					<td>
						<asp:TextBox id="txtAcctName" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label9" runat="server">客户经理：</asp:Label></td>
					<TD>
						<asp:TextBox id="txtMgr" runat="server"></asp:TextBox></TD>
				<TR>
					<TD>
						<asp:Label id="Label5" runat="server">交款时间：</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtPayDate" runat="server" onfocus="calendar()"></asp:TextBox></TD>
				</TR>
				<tr>
					<td>
						<asp:Label id="Label6" runat="server">费用类型：</asp:Label></td>
					<td>
						<asp:TextBox id="txtFeeName" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label8" runat="server">费用计收时间：</asp:Label></td>
					<td>
						<asp:TextBox id="txtFeeDate" runat="server" onfocus="calendar()"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label12" runat="server">交款金额：</asp:Label></td>
					<td>
						<asp:TextBox id="txtPayFee" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label13" runat="server">缴预存款金额：</asp:Label></td>
					<td>
						<asp:TextBox id="txtPrepayFee" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label10" runat="server">备注：</asp:Label></td>
					<td>
						<asp:TextBox id="txtComments" runat="server" TextMode="MultiLine" Width="240px" Height="128px"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="2" align="center">
						<asp:Button id="btnOK" runat="server" Text="保存"></asp:Button>
						<asp:Button id="btnCancel" runat="server" Text="取消"></asp:Button>
						<asp:Button id="btnReturn" runat="server" Text="返回"></asp:Button></td>
				</tr>
			</table>
			<div id="xMsg11" onmousedown="getFocus(this)">
				<div id="xMsg21" onmousedown="startDrag(this)" onmouseup="stopDrag(this)" onmousemove="drag(this)">
					<span id="xMsgs11">查询客户</span> <span style="BORDER-TOP-WIDTH:0px;BORDER-LEFT-WIDTH:0px;BORDER-BOTTOM-WIDTH:0px;WIDTH:12px;COLOR:white;FONT-FAMILY:webdings;BORDER-RIGHT-WIDTH:0px"
						onclick="min(this)">0</span> <span style="BORDER-TOP-WIDTH:0px;BORDER-LEFT-WIDTH:0px;BORDER-BOTTOM-WIDTH:0px;WIDTH:12px;COLOR:white;FONT-FAMILY:webdings;BORDER-RIGHT-WIDTH:0px"
						onclick="ShowHide(1,null)">r</span>
				</div>
				<div id="xMsg31">
					<table align="center">
						<tr>
							<td><asp:Label id="Label7" runat="server">客户ID：</asp:Label></td>
							<td><asp:TextBox id="txtQueryCustID" runat="server"></asp:TextBox>
							</td>
							<td></td>
						</tr>
						<tr>
							<td>
								<asp:Label id="Label11" runat="server">客户名称：</asp:Label></td>
							<td>
								<asp:TextBox id="txtQueryCustName" runat="server"></asp:TextBox></td>
							<td><asp:Button id="btnQuery" runat="server" Text="查询"></asp:Button></td>
						</tr>
					</table>
					<table width="100%" align="center">
						<tr>
							<td>
								<asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False" BorderColor="#3366CC"
									BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" Width="100%">
									<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
									<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
									<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
									<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
									<Columns>
										<asp:BoundColumn DataField="cnnCustID" HeaderText="客户ID"></asp:BoundColumn>
										<asp:BoundColumn DataField="cnvcName" HeaderText="客户名称"></asp:BoundColumn>
										<asp:BoundColumn DataField="cnvcTradeTypeComments" HeaderText="行业"></asp:BoundColumn>
										<asp:ButtonColumn Text="选择" CommandName="Select"></asp:ButtonColumn>
									</Columns>
									<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
								</asp:DataGrid></td>
						</tr>
					</table>
				</div>
			</div>
			<div id="xMsg41"></div>
		</form>
	</body>
</HTML>
