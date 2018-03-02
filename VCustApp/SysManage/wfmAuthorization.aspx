<%@ Page language="c#" Codebehind="wfmAuthorization.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.SysManage.wfmAuthorization" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmAuthorization</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="../css/style.css" type="text/css" rel="stylesheet">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body scroll="yes">
		<form id="Form1" method="post" runat="server">
			<table height="100%" width="95%">
				<tr>
					<td align="center" style="FONT-WEIGHT: bold; FONT-SIZE: 12pt">权限修改</td>
				</tr>
				<tr>
					<td vAlign="top" align="center">
						<table cellSpacing="0" cellPadding="0" width="60%" align="center" border="1" bordercolor="#00ccff">
							<tr>
								<td>功能列表
									<asp:TextBox id="txtOperID" runat="server" Visible="False"></asp:TextBox></td>
							</tr>
							<tr>
								<td><asp:checkboxlist id="cblFunctionList" runat="server"></asp:checkboxlist></td>
							</tr>
							<tr>
								<td align="center"><asp:imagebutton id="btnOK" runat="server" ImageUrl="../Image/btnOk.gif"></asp:imagebutton><asp:imagebutton id="btnCancel" runat="server" ImageUrl="../Image/btnCancel.gif"></asp:imagebutton></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
