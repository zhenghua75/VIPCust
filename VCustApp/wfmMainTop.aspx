<%@ Page language="c#" Codebehind="wfmMainTop.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.wfmMainTop" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmMainTop</title>
		<meta content="True" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">		
			var Condition = false;
			function window_onunload(url)
			{
			  if(Condition==false)
			  {				
			     window.open(url+'?xclose=yes' );
			  }			  
			}
			var   oPopup   =   window.createPopup();  
			function   richContext(obj1,obj2)
			{  
					var   lefter2   =   event.offsetY+0;  
					var   topper2   =   event.offsetX+15;  
					var oPopBody = oPopup.document.body;
					oPopBody.style.backgroundColor   =   "lightyellow";  
					oPopBody.style.border   =   "solid   black   1px"; 
					oPopup.document.body.innerHTML   =   obj1.innerHTML;    
					oPopup.show(topper2,   lefter2,   100,   300,   obj2);  
			}  
			//popup标准操作
			var v_popup=window.createPopup(); 
			var srcDocID=null;
			var srcResourceName=null;
			function fn_showMenuPopup(vDocID,vMenuID){
				var vSrc=event.srcElement;
				srcDocID=vDocID;
				srcResourceName=vSrc.parentElement.innerText;
				var v_popupBody=v_popup.document.body;      
				v_popupBody.style.border="2px outset #ffffff";  
				//menuid = document.getElementById(vMenuID);
				v_popupBody.innerHTML=vMenuID.innerHTML;
				var vTags=v_popupBody.all.tags("TD");
				for (i=0;i<vTags.length;i++)
				{      
					//vTags[i].onclick=popup_click;
					vTags[i].onmouseover=popup_mouseover;
					vTags[i].onmouseout=popup_mouseout;
					vTags[i].style.cssText="height:20;border-bottom:1 solid #CDCDCD;padding-top:3px;cursor:default;TEXT-DECORATION: none;";
				}
				var vHeight=vTags.length*23+12;
				v_popup.show(0,vSrc.offsetHeight,120,vHeight,vSrc);
			}
			function popup_mouseover(){
			var vSrc =v_popup.document.parentWindow.event.srcElement;			
			vSrc.style.color="#cc0000";
			vSrc.style.fontWeight="bold";
			//vSrc.style.background="#ff0000";
			}
			function popup_mouseout(){
			var vSrc =v_popup.document.parentWindow.event.srcElement;			
			vSrc.style.color="#000000";
			vSrc.style.fontWeight="normal";
			//vSrc.style.background="";
			}
			function winOpen(url)
			{
				window.open(url,'right','','false');
				v_popup.hide();
			}
		</script>
	</HEAD>
	<body bgColor="#000000" leftMargin="0" topMargin="0" onunload="window_onunload('Exit.aspx')"
		ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" height="112" border="0" style="BACKGROUND-IMAGE: url(image/banner.jpg); BACKGROUND-REPEAT: no-repeat">
				<tr>
					<TD width="80%" vAlign="bottom" align="right" style="HEIGHT: 36px"><asp:label id="lblDept" Width="200px" Font-Size="11pt" ForeColor="#ff0000" runat="server" Visible="true">test</asp:label></TD>
					<td width="20%"></td>
				</tr>
				<TR>
					<td width="80%" vAlign="bottom" align="right" style="HEIGHT: 24px"><asp:label id="lbloper" Width="200px" Font-Size="11pt" ForeColor="#ff0000" runat="server" Visible="true">test</asp:label></td>
					<td width="20%"></td>
				</TR>
				<TR>
					<td width="100%" vAlign="bottom" align="right" style="HEIGHT: 12px"></td>
					<td width="20%"></td>
				</TR>
				<TR>
					<TD height="51" noWrap width="100%" style="HEIGHT: 51px" colspan="2">
						<table align="center" width="1195" style="WIDTH: 1195px; HEIGHT: 24px">
							<tr>
								<td width="15%"></td>
								<td>
									<table>
										<tr>
											<td id="td1" onmouseover="fn_showMenuPopup(td1,menu1);" style="FONT-WEIGHT: bold; FONT-SIZE: 13pt; WIDTH: 108px; CURSOR: hand; COLOR: #ffffff">客户基础信息</td>
											<td width="10"><IMG src="image/tiao.jpg"></td>
											<td id="td2" onmouseover="fn_showMenuPopup(td2,menu2);" style="FONT-WEIGHT: bold; FONT-SIZE: 13pt; WIDTH: 72px; CURSOR: hand; COLOR: #ffffff">商机管理</td>
											<td width="10"><IMG src="image/tiao.jpg"></td>
											<td id="td3" onmouseover="fn_showMenuPopup(td3,menu3);" style="FONT-WEIGHT: bold; FONT-SIZE: 13pt; WIDTH: 108px; CURSOR: hand; COLOR: #ffffff">销售进度管理</td>
											<td width="10"><IMG src="image/tiao.jpg"></td>
											<td id="td4" onmouseover="fn_showMenuPopup(td4,menu4);" style="FONT-WEIGHT: bold; FONT-SIZE: 13pt; WIDTH: 72px; CURSOR: hand; COLOR: #ffffff">收入管理</td>
											<td width="10"><IMG src="image/tiao.jpg"></td>
											<td id="td5" style="FONT-WEIGHT: bold; FONT-SIZE: 13pt; WIDTH: 72px; COLOR: #ffffff">项目管理</td>
											<td width="10"><IMG src="image/tiao.jpg"></td>
											<td id="td6" style="FONT-WEIGHT: bold; FONT-SIZE: 13pt; WIDTH: 108px; COLOR: #ffffff">网络资源管理</td>
											<td width="10"><IMG src="image/tiao.jpg"></td>
											<td id="td7" onmouseover="fn_showMenuPopup(td7,menu7);" style="FONT-WEIGHT: bold; FONT-SIZE: 13pt; WIDTH: 72px; CURSOR: hand; COLOR: #ffffff">系统管理</td>
											<td width="10"><IMG src="image/tiao.jpg"></td>
											<td><A style="FONT-WEIGHT: bold; FONT-SIZE: 13pt; COLOR: #ffffff; TEXT-DECORATION: none"
													href="javascript:Condition=true;check('您是否确认退出系统？','Exit.aspx');" target="_parent">注销退出</A></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
			<div style="DISPLAY:none;BACKGROUND:#efefef" id="menu1">
				<table style="FONT-SIZE:12px" align="center" cellpadding="2" width="96%" border="0" cellspacing="0">
					<tr valign="top" id="trVCustInfo" runat="server">
						<td width="100%" valign="middle">
							<A onclick="parent.winOpen('VCustInfo/wfmVCustInfo.aspx');" href="#" style="FONT-SIZE: 10pt;CURSOR: hand;COLOR: #000000;TEXT-DECORATION: none">
								档案管理</A></td>
					</tr>
					<tr valign="top" id="trVCustLink" runat="server">
						<td width="100%" valign="middle">
							<A onclick="parent.winOpen('VCustInfo/wfmVCustLink.aspx');" href="#" style="FONT-SIZE: 10pt;CURSOR: hand;COLOR: #000000;TEXT-DECORATION: none">
								客户联系人</A></td>
					</tr>
				</table>
			</div>
			<div style="DISPLAY:none;BACKGROUND:#efefef" id="menu2">
				<table style="FONT-SIZE:12px" align="center" cellpadding="2" width="96%" border="0" cellspacing="0">
					<tr valign="top" id="trChanceQuery" runat="server">
						<td width="100%" valign="middle">
							<A onclick="parent.winOpen('./BusinessChance/wfmChanceQuery.aspx');" href="#" style="FONT-SIZE: 10pt;CURSOR: hand;COLOR: #000000;TEXT-DECORATION: none">
								商机维护</A></td>
					</tr>
					<tr valign="top" id="trChanceReport" runat="server">
						<td width="100%" valign="middle">
							<a onclick="parent.winOpen('./BusinessChance/wfmChanceReport.aspx');" href="#" style="FONT-SIZE: 10pt;CURSOR: hand;COLOR: #000000;TEXT-DECORATION: none">
								商机统计</a></td>
					</tr>
					<tr valign="top" id="trSalesFunnel" runat="server">
						<td width="100%" valign="middle">
							<a onclick="parent.winOpen('./BusinessChance/wfmSalesFunnel.aspx');" href="#" style="FONT-SIZE: 10pt;CURSOR: hand;COLOR: #000000;TEXT-DECORATION: none">
								销售漏斗</a></td>
					</tr>
				</table>
			</div>
			<div style="DISPLAY:none;BACKGROUND:#efefef" id="menu3">
				<table style="FONT-SIZE:12px" align="center" cellpadding="2" width="96%" border="0" cellspacing="0">
					<tr valign="top" id="trCustRelationReport1" runat="server">
						<td width="100%" valign="middle">
							<A onclick="parent.winOpen('VCustInfo/wfmCustRelationReport1.aspx');" href="#" style="FONT-SIZE: 10pt;CURSOR: hand;COLOR: #000000;TEXT-DECORATION: none">
								客户基础信息</A></td>
					</tr>
					<tr valign="top" id="trCustRelationReport2" runat="server">
						<td width="100%" valign="middle">
							<A onclick="parent.winOpen('VCustInfo/wfmCustRelationReport2.aspx');" href="#" style="FONT-SIZE: 10pt;CURSOR: hand;COLOR: #000000;TEXT-DECORATION: none">
								客户联系人信息</A></td>
					</tr>
					<tr valign="top" id="trCustRelationDeepReport" runat="server">
						<td width="100%" valign="middle">
							<A onclick="parent.winOpen('VCustInfo/wfmCustRelationDeepReport.aspx');" href="#" style="FONT-SIZE: 10pt;CURSOR: hand;COLOR: #000000;TEXT-DECORATION: none">
								客户销售进度</A></td>
					</tr>
					<tr valign="top" id="trFourChanceQuery" runat="server">
						<td width="100%" valign="middle">
							<A onclick="parent.winOpen('./BusinessChance/wfmFourChanceQuery.aspx');" href="#" style="FONT-SIZE: 10pt;CURSOR: hand;COLOR: #000000;TEXT-DECORATION: none">
								销售影响因素表</A></td>
					</tr>
				</table>
			</div>
			<div style="DISPLAY:none;BACKGROUND:#efefef" id="menu4">
				<table style="FONT-SIZE:12px" align="center" cellpadding="2" width="96%" border="0" cellspacing="0">
					<tr valign="top" id="trSaleCost" runat="server">
						<td width="100%" valign="middle">
							<A onclick="parent.winOpen('./SalesManage/wfmSaleCost.aspx');" href="#" style="FONT-SIZE: 10pt;CURSOR: hand;COLOR: #000000;TEXT-DECORATION: none">
								销售成本管理</A></td>
					</tr>
					<tr valign="top" id="trAdvancePayment" runat="server">
						<td width="100%" valign="middle">
							<A onclick="parent.winOpen('./SalesManage/wfmAdvancePayment.aspx');" href="#" style="FONT-SIZE: 10pt;CURSOR: hand;COLOR: #000000;TEXT-DECORATION: none">
								预收帐款</A></td>
					</tr>
					<tr valign="top" id="trAccountReceivable" runat="server">
						<td width="100%" valign="middle">
							<A onclick="parent.winOpen('./SalesManage/wfmAccountReceivable.aspx');" href="#" style="FONT-SIZE: 10pt;CURSOR: hand;COLOR: #000000;TEXT-DECORATION: none">
								应收管理</A></td>
					</tr>
				</table>
			</div>
			<div style="DISPLAY:none;BACKGROUND:#efefef" id="menu5">
				<table style="FONT-SIZE:12px" align="center" cellpadding="2" width="96%" border="0" cellspacing="0">
					<tr valign="top">
						<td width="100%" valign="middle"></td>
					</tr>
				</table>
			</div>
			<div style="DISPLAY:none;BACKGROUND:#efefef" id="menu6">
				<table style="FONT-SIZE:12px" align="center" cellpadding="2" width="96%" border="0" cellspacing="0">
					<tr valign="top">
						<td width="100%" valign="middle"></td>
					</tr>
				</table>
			</div>
			<div style="DISPLAY:none;BACKGROUND:#efefef" id="menu7">
				<table style="FONT-SIZE:12px" align="center" cellpadding="2" width="96%" border="0" cellspacing="0">
					<tr valign="top" id="trDeptQuery" runat="server">
						<td width="100%" valign="middle">
							<A onclick="parent.winOpen('./SysManage/wfmDeptQuery.aspx');" href="#" style="FONT-SIZE: 10pt;CURSOR: hand;COLOR: #000000;TEXT-DECORATION: none">
								部门维护</A></td>
					</tr>
					<tr valign="top" id="trOperQuery" runat="server">
						<td width="100%" valign="middle">
							<A onclick="parent.winOpen('./SysManage/wfmOperQuery.aspx');" href="#" style="FONT-SIZE: 10pt;CURSOR: hand;COLOR: #000000;TEXT-DECORATION: none">
								操作员维护</A></td>
					</tr>
					<tr valign="top" id="trChangePassword" runat="server">
						<td width="100%" valign="middle">
							<A onclick="parent.winOpen('./SysManage/ChangePassword.aspx');" href="#" style="FONT-SIZE: 10pt;CURSOR: hand;COLOR: #000000;TEXT-DECORATION: none">
								修改密码</A></td>
					</tr>
					<tr valign="top" id="trParaFlash" runat="server">
						<td width="100%" valign="middle">
							<A onclick="parent.winOpen('./SysManage/wfmParaFlash.aspx');" href="#" style="FONT-SIZE: 10pt;CURSOR: hand;COLOR: #000000;TEXT-DECORATION: none">
								参数刷新</A></td>
					</tr>
					<tr valign="top" id="trHelp" runat="server">
						<td width="100%" valign="middle">
							<A onclick="parent.winOpen('./大客户战略销售工具帮助.mht');" href="#" style="FONT-SIZE: 10pt;CURSOR: hand;COLOR: #000000;TEXT-DECORATION: none">
								帮助</A></td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
