<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="VCustApp._default" EnableSessionState="True" debug="False" enableViewState="True" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>大客户管理系统登录</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" style="BACKGROUND-IMAGE: url(image/back.jpg)">
		<table align="center" width="655" height="100%" border="0">
			<tr height="40%">
				<td></td>
			</tr>
			<tr height="350">
				<td background="image/login.jpg">
					<form id="Form1" method="post" runat="server">
						<table width="100%" height="100%" border="0">
							<tr height="30%">
								<td></td>
								<td></td>
							</tr>
							<tr height="30%">
								<td style="HEIGHT: 46.78%"></td>
								<td style="HEIGHT: 46.78%"></td>
							</tr>
							<tr valign="middle">
								<td width="240"></td>
								<td>&nbsp;&nbsp;&nbsp;&nbsp;
									<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="384" border="0" style="WIDTH: 384px; HEIGHT: 32px">
										<TR>
											<TD style="WIDTH: 62px"><STRONG><FONT color="white">用户名:</FONT></STRONG></TD>
											<TD style="WIDTH: 92px">
												<asp:TextBox id="txtLoginID" runat="server" Width="88px" Font-Size="10pt"></asp:TextBox></TD>
											<TD style="WIDTH: 52px"><STRONG><FONT color="white">密 码:</FONT></STRONG></TD>
											<TD>
												<asp:TextBox id="txtPwd" runat="server" Width="88px" TextMode="Password" Font-Size="10pt"></asp:TextBox></TD>
											<TD><FONT face="宋体">
													<asp:Button id="Button1" runat="server" Text="进 入" BackColor="Orange" BorderStyle="Dotted" ForeColor="White"
														BorderColor="Gray" Font-Bold="True" Font-Names="YouYuan" Font-Size="10pt"></asp:Button></FONT></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
					</form>
				</td>
			</tr>
			<tr height="40%">
				<td></td>
			</tr>
		</table>
	</body>
</HTML>
