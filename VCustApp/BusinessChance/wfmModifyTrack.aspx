<%@ Page language="c#" Codebehind="wfmModifyTrack.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.BusinessChance.wfmModifyTrack" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmModifyTrack</title>
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
						<asp:Label id="Label1" runat="server" CssClass="title">修改跟踪记录</asp:Label></td>
				</tr>
			</table>
			<table align="center">
				<tr>
					<td>
						<asp:Label style="Z-INDEX: 0" id="Label2" runat="server">跟踪日期：</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox1" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label3" runat="server">实施人：</asp:Label></td>
					<td>
						<asp:DropDownList style="Z-INDEX: 0" id="DropDownList6" runat="server">
							<asp:ListItem Value="张三">张三</asp:ListItem>
							<asp:ListItem Value="李四">李四</asp:ListItem>
							<asp:ListItem Value="王五">王五</asp:ListItem>
						</asp:DropDownList></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label4" runat="server">实施成本：</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox2" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label5" runat="server">跟踪摘要：</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox3" runat="server" TextMode="MultiLine" Height="136px" Width="200px"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="2" align="center">
						<asp:Button id="Button1" runat="server" Text="确定"></asp:Button>
						<asp:Button id="Button2" runat="server" Text="取消"></asp:Button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
