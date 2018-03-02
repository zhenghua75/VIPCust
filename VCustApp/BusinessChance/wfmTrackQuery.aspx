<%@ Page language="c#" Codebehind="wfmTrackQuery.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.BusinessChance.wfmTrackQuery" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmTrackQuery</title>
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
						<asp:Label id="Label1" runat="server" CssClass="title">跟踪记录维护</asp:Label></td>
				</tr>
			</table>
			<table align="center">
				<tr>
					<td>
						<asp:Label id="Label2" runat="server">项目名称：</asp:Label></td>
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
						<asp:Label id="Label4" runat="server">开始日期：</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox2" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label5" runat="server">结束日期：</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox3" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="2" align="center">
						<asp:Button id="Button1" runat="server" Text="查询" Width="60px"></asp:Button>
						<asp:Button id="Button2" runat="server" Text="取消" Width="66px"></asp:Button>
						<asp:Button id="btnAddTrack" runat="server" Text="添加跟踪记录"></asp:Button></td>
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
								<asp:BoundColumn DataField="cndTrackDate" HeaderText="跟踪日期"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcTrackMan" HeaderText="实施人"></asp:BoundColumn>
								<asp:HyperLinkColumn Text="修改" DataNavigateUrlField="cnvcTrackMan" DataNavigateUrlFormatString="wfmModifyTrack.aspx"
									HeaderText="修改"></asp:HyperLinkColumn>
								<asp:ButtonColumn Text="删除" HeaderText="删除" CommandName="Delete"></asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
