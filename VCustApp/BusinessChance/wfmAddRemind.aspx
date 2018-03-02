<%@ Page language="c#" Codebehind="wfmAddRemind.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.BusinessChance.wfmAddRemind" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmAddRemind</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../css/DataGrid.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table align="center">
				<tr>
					<td colspan="2">
						<asp:Label id="Label1" runat="server" CssClass="title">添加提醒</asp:Label></td>
				</tr>
			</table>
			<table align="center">
				<tr>
					<td>
						<asp:Label style="Z-INDEX: 0" id="Label2" runat="server">客户名称：</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox1" runat="server"></asp:TextBox>
						<asp:Button id="Button1" runat="server" Text="选择客户"></asp:Button></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label3" runat="server">提醒信息：</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox2" runat="server" TextMode="MultiLine" Width="224px" Height="120px"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label4" runat="server">提醒日期：</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox3" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label5" runat="server">结束日期：</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox4" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="2" align="center">
						<asp:Button id="Button2" runat="server" Text="确定" Width="69px"></asp:Button>
						<asp:Button id="Button3" runat="server" Text="取消" Width="57px"></asp:Button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
