<%@ Page language="c#" Codebehind="wfmPlanQuery.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.BusinessChance.wfmPlanQuery" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmPlanQuery</title>
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
						<asp:Label id="Label1" runat="server" CssClass="title">销售计划维护</asp:Label></td>
				</tr>
			</table>
			<table align="center">
				<tr>
					<td>
						<asp:Label id="Label2" runat="server">销售计划名称：</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox1" runat="server"></asp:TextBox></td>				
					<td>
						<asp:Label id="Label3" runat="server">启动日期：</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox2" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label4" runat="server">结束日期：</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox3" runat="server"></asp:TextBox></td>			
					<td>
						<asp:Label id="Label7" runat="server">发布状态：</asp:Label></td>
					<td>
						<asp:DropDownList id="DropDownList3" runat="server">
							<asp:ListItem Value="已发布">已发布</asp:ListItem>
							<asp:ListItem Value="未发布">未发布</asp:ListItem>
						</asp:DropDownList></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label5" runat="server">读取状态：</asp:Label></td>
					<td>
						<asp:DropDownList id="DropDownList1" runat="server">
							<asp:ListItem Value="已收阅">已收阅</asp:ListItem>
							<asp:ListItem Value="未收阅">未收阅</asp:ListItem>
						</asp:DropDownList></td>				
					<td>
						<asp:Label id="Label6" runat="server">完成情况：</asp:Label></td>
					<td>
						<asp:DropDownList id="DropDownList2" runat="server">
							<asp:ListItem Value="已完成">已完成</asp:ListItem>
							<asp:ListItem Value="未完成">未完成</asp:ListItem>
						</asp:DropDownList></td>
				</tr>
				<tr>
					<td colspan="4" align="center">
						<asp:Button id="Button1" runat="server" Width="63px" Text="查询"></asp:Button>
						<asp:Button id="Button2" runat="server" Width="61px" Text="取消"></asp:Button>
						<asp:Button id="btnAddPlan" runat="server" Width="54px" Text="添加"></asp:Button></td>
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
								<asp:BoundColumn DataField="cnvcPlanName" HeaderText="计划名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="cndBeginDate" HeaderText="启动日期"></asp:BoundColumn>
								<asp:BoundColumn DataField="cndEndDate" HeaderText="终止日期"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcPlanNeed" HeaderText="计划要求"></asp:BoundColumn>
								<asp:HyperLinkColumn Text="修改" DataNavigateUrlField="cnvcPlanName" DataNavigateUrlFormatString="wfmModifyPlan.aspx"
									HeaderText="修改"></asp:HyperLinkColumn>
								<asp:HyperLinkColumn Text="安排人员" DataNavigateUrlField="cnvcPlanName" DataNavigateUrlFormatString="wfmPlanMan.aspx"
									HeaderText="安排人员"></asp:HyperLinkColumn>
								<asp:ButtonColumn Text="发布" HeaderText="发布" CommandName="Select"></asp:ButtonColumn>
								<asp:ButtonColumn Text="收阅" HeaderText="读取计划" CommandName="Select"></asp:ButtonColumn>
								<asp:ButtonColumn Text="完成" HeaderText="进展状态" CommandName="Select"></asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
