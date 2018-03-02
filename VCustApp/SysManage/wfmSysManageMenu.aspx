<%@ Page language="c#" Codebehind="wfmSysManageMenu.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.SysManage.wfmSysManageMenu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<html>
  <head>
    <title>wfmSysManageMenu</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body MS_POSITIONING="GridLayout">
	
    <form id="Form1" method="post" runat="server">
					<TABLE cellSpacing="1" cellPadding="1" width="146" border="0" align="left">
				
				<TR id="trDeptQuery" runat="server">
					<TD align="center" style="HEIGHT: 38px" background="../image/anniu.jpg"><A style="COLOR: #ffffff; FONT-SIZE: 12pt; TEXT-DECORATION: none" onclick="parent.right.location='wfmDeptQuery.aspx'"
							href="javascript:">部门维护</A></TD>
				</TR>
				<TR id="trOperQuery" runat="server">
					<TD align="center" style="HEIGHT: 38px" background="../image/anniu.jpg"><A style="COLOR: #ffffff; FONT-SIZE: 12pt; TEXT-DECORATION: none" onclick="parent.right.location='wfmOperQuery.aspx'"
							href="javascript:">操作员维护</A></TD>
				</TR>
				<TR id="trChangePassword" runat="server">
					<TD align="center" style="HEIGHT: 38px" background="../image/anniu.jpg"><A style="COLOR: #ffffff; FONT-SIZE: 12pt; TEXT-DECORATION: none" onclick="parent.right.location='ChangePassword.aspx'"
							href="javascript:">修改密码</A></TD>
				</TR>
				
				<TR id="trParaFlash" runat="server">
					<TD align="center" style="HEIGHT: 38px" background="../image/anniu.jpg"><A style="COLOR: #ffffff; FONT-SIZE: 12pt; TEXT-DECORATION: none" onclick="parent.right.location='wfmParaFlash.aspx'"
							href="javascript:">参数刷新</A></TD>
				</TR>
			</TABLE>

     </form>
	
  </body>
</html>
