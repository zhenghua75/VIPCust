<%@ Page language="c#" Codebehind="ChangePassword.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.SysManage.ChangePassword" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ChangePassword</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<LINK href="../css/style.css" type="text/css" rel="stylesheet">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%" height="100%">
				<tr>
					<td valign="top" align="center">
						<table>
							<tr>
								<td colspan="2" align="center" style="FONT-WEIGHT: bold; FONT-SIZE: 12pt">修改登录密码</td>
							</tr>
							<tr>
								<td><asp:Label id="lblOldPwd" runat="server">旧密码：</asp:Label></td>
								<td><asp:TextBox id="txtOldPwd" runat="server" TextMode="Password"></asp:TextBox></td>
							</tr>
							<tr>
								<td>
									<asp:Label id="lblNewPwd" runat="server">新密码：</asp:Label></td>
								<td>
									<asp:TextBox id="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox></td>
							</tr>
							<tr>
								<td>
									<asp:Label id="lblConfirmPwd" runat="server">确认密码：</asp:Label></td>
								<td>
									<asp:TextBox id="txtConfirmPwd" runat="server" TextMode="Password"></asp:TextBox></td>
							</tr>
							<tr>
								<td colspan="2" align="center">
									<asp:ImageButton id="btnOK" runat="server" ImageUrl="../Image/btnOk.gif"></asp:ImageButton>
									<asp:ImageButton id="btnCancel" runat="server" ImageUrl="../Image/btnCancel.gif"></asp:ImageButton></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
