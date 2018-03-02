<%@ Page language="c#" Codebehind="wfmChanceReport.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.BusinessChance.wfmChanceReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmChanceReport</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../css/style.css">
		<script language="javascript" src="../script/calendar.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table align="center">
				<tr>
					<td colspan="2">
						<asp:Label id="Label1" runat="server" style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033">商机管理统计表</asp:Label></td>
				</tr>
			</table>
			<table align="center">
				<tr>
					<td>
						<asp:Label id="Label2" runat="server" CssClass="lable">分公司：</asp:Label></td>
					<td>
						<asp:DropDownList id="ddlDept" runat="server"></asp:DropDownList></td>
					<td>
						<asp:Label id="Label3" runat="server" CssClass="lable">本月开始时间：</asp:Label></td>
					<td>
						<asp:TextBox id="txtBeginDate" runat="server" onfocus="calendar()"></asp:TextBox></td>
					<td>
						<asp:Label id="Label4" runat="server" CssClass="lable">本月结束时间：</asp:Label></td>
					<td>
						<asp:TextBox id="txtEndDate" runat="server" onfocus="calendar()"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="6" align="center">
						<asp:Button id="btnQuery" runat="server" Text="查询" Width="61px"></asp:Button>
						<asp:Button id="btnCancel" runat="server" Text="取消" Width="60px"></asp:Button>
						<asp:Button id="btnExcel" runat="server" Text="导出EXCEL"></asp:Button></td>
				</tr>
			</table>
			<table align="center" width="1600">
				<tr>
					<td align="left">
						<asp:DataGrid id="DataGrid1" runat="server" Font-Size="X-Small" PageSize="15" AllowPaging="True"
							PagerStyle-HorizontalAlign="Right" BorderColor="Black" BorderWidth="1px" CellPadding="3" Font-Name="Verdana"
							HeaderStyle-BackColor="SteelBlue" AlternatingItemStyle-BackColor="#660033" Font-Names="Verdana" AutoGenerateColumns="False">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle Wrap="False"></SelectedItemStyle>
							<EditItemStyle Wrap="False"></EditItemStyle>
							<AlternatingItemStyle Wrap="False" ForeColor="Black" BackColor="#E6E6E6"></AlternatingItemStyle>
							<ItemStyle Wrap="False" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="Small" Font-Bold="True" Wrap="False" ForeColor="White" BackColor="#880028"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cnvcDeptName" HeaderText="分公司">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnnChanceCount" HeaderText="累计商机数">
								<ItemStyle Width="90px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnnAddCount" HeaderText="本月新增商机数">
								<ItemStyle Width="120px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnnEndCount" HeaderText="累计成功转换商机">
								<ItemStyle Width="140px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnnSum" HeaderText="商机累计预测收入（万元）">
								<ItemStyle Width="140px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnnMonthSum" HeaderText="本月新增商机预测收入（万元）">
								<ItemStyle Width="170px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnnRate" HeaderText="商家覆盖率（%）">
								<ItemStyle Width="90px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnnEndSum" HeaderText="累计成功转换商机收入（万元）">
								<ItemStyle Width="170px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnnAverageSum" HeaderText="单条商机平均预测收入（万元）">
								<ItemStyle Width="170px"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
