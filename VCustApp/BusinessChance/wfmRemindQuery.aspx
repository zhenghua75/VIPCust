<%@ Page language="c#" Codebehind="wfmRemindQuery.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.BusinessChance.wfmRemindQuery" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmRemindQuery</title>
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
						<asp:Label id="Label1" runat="server" CssClass="title">销售提醒维护</asp:Label></td>
				</tr>
			</table>
			<table align="center">
				<tr>
					<td>
						<asp:Label style="Z-INDEX: 0" id="Label2" runat="server">客户名称：</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox1" runat="server"></asp:TextBox></td>
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
						<asp:Button id="Button2" runat="server" Text="查询" Width="69px"></asp:Button>
						<asp:Button id="Button3" runat="server" Text="取消" Width="57px"></asp:Button>
						<asp:Button id="btnAddRemind" runat="server" Text="添加" Width="58px"></asp:Button></td>
				</tr>
			</table>
			<table align="center" width="100%">
				<tr>
					<td align="center">
						<asp:DataGrid id="DataGrid1" runat="server" Font-Size="X-Small" Width="100%" PageSize="15" AllowPaging="True"
							PagerStyle-HorizontalAlign="Right" BorderColor="Black" BorderWidth="1px" CellPadding="3" Font-Name="Verdana"
							HeaderStyle-BackColor="SteelBlue" AlternatingItemStyle-BackColor="#660033" Font-Names="Verdana" AutoGenerateColumns="False">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle Wrap="False"></SelectedItemStyle>
							<EditItemStyle Wrap="False"></EditItemStyle>
							<AlternatingItemStyle Wrap="False" ForeColor="Black" BackColor="#E6E6E6"></AlternatingItemStyle>
							<ItemStyle Wrap="False" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="Small" Font-Bold="True" Wrap="False" ForeColor="White" BackColor="#880028"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cnvcCustomName" HeaderText="客户名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcRemind" HeaderText="提醒信息"></asp:BoundColumn>
								<asp:BoundColumn DataField="cndBeginDate" HeaderText="提醒日期"></asp:BoundColumn>
								<asp:BoundColumn DataField="cndEndDate" HeaderText="结束日期"></asp:BoundColumn>
								<asp:HyperLinkColumn Text="修改" DataNavigateUrlField="cnvcRemind" DataNavigateUrlFormatString="wfmModifyRemind.aspx"
									HeaderText="修改"></asp:HyperLinkColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
