<%@ Page language="c#" Codebehind="wfmFileUp.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.wfmFileUp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmFileUp</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="css/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table align="center">
				<tr>
					<td>
						<asp:Label id="lblFileUp" runat="server" style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033">文件导入</asp:Label>
						<asp:TextBox id="txtXlsType" runat="server" Visible="False"></asp:TextBox>
						<asp:TextBox id="txtSheet" runat="server" Visible="False"></asp:TextBox>
						<asp:TextBox id="txtError" runat="server" Visible="False"></asp:TextBox></td>
				</tr>
			</table>
			<table align="center">
				<tr>
					<td>
						<asp:Label id="Label1" runat="server">选择EXCEL文件：</asp:Label></td>
					<td><INPUT type="file" runat="server" id="fileUpLoad">
						<asp:Button id="btnReadFile" runat="server" Text="读取文件"></asp:Button></td>
				</tr>
				<tr>
					<td colspan="2" align="center">
						<asp:Label id="lblFileName" runat="server"></asp:Label></td>
				</tr>
				<tr>
					<td colspan="2" align="center">
						<asp:Button id="btnWriteFile" runat="server" Text="导入文件"></asp:Button>
						<asp:Button id="btnReturn" runat="server" Text="返回" Width="98px"></asp:Button></td>
				</tr>
			</table>
			<table align="left" width="4000">
				<tr>
					<td>
						<asp:DataGrid id="DataGrid1" runat="server" Font-Size="X-Small" PagerStyle-HorizontalAlign="Right"
							BorderColor="Black" BorderWidth="1px" CellPadding="3" Font-Name="Verdana" HeaderStyle-BackColor="SteelBlue"
							AlternatingItemStyle-BackColor="#660033" Font-Names="Verdana">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle Wrap="False"></SelectedItemStyle>
							<EditItemStyle Wrap="False"></EditItemStyle>
							<AlternatingItemStyle Wrap="False" ForeColor="Black" BackColor="#E6E6E6"></AlternatingItemStyle>
							<ItemStyle Wrap="False" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="Small" Font-Bold="True" Wrap="False" ForeColor="White" BackColor="#880028"></HeaderStyle>
						</asp:DataGrid>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
