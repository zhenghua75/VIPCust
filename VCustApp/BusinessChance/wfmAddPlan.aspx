<%@ Page language="c#" Codebehind="wfmAddPlan.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.BusinessChance.wfmAddPlan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmAddPlan</title>
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
						<asp:Label id="Label1" runat="server" CssClass="title">������ۼƻ�</asp:Label></td>
				</tr>
			</table>
			<table align="center">
				<tr>
					<td>
						<asp:Label id="Label2" runat="server">���⣺</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox1" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label3" runat="server">�������ڣ�</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox2" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label4" runat="server">�������ڣ�</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox3" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label5" runat="server">�ƻ�Ҫ��</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox4" runat="server" TextMode="MultiLine" Width="162px" Height="80px"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label6" runat="server">��ע��</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox5" runat="server" TextMode="MultiLine" Width="162px" Height="88px"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="2" align="center">
						<asp:Button id="Button1" runat="server" Width="63px" Text="ȷ��"></asp:Button>
						<asp:Button id="Button2" runat="server" Width="61px" Text="ȡ��"></asp:Button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
