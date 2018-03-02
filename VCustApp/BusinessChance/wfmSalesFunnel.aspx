<%@ Register TagPrefix="dcwc" Namespace="Dundas.Charting.WebControl" Assembly="DundasWebChart" %>
<%@ Page language="c#" Codebehind="wfmSalesFunnel.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.BusinessChance.wfmSalesFunnel" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmSalesFunnel</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/style.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../script/calendar.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table align="center">
				<tr>
					<td colSpan="2"><asp:label id="Label1" style="COLOR: #330033; FONT-SIZE: 15pt; FONT-WEIGHT: bold" runat="server">销售漏斗</asp:label></td>
				</tr>
			</table>
			<asp:TextBox id="txtChanceSpeed" style="Z-INDEX: 101; POSITION: absolute; TOP: 0px; LEFT: 464px"
				runat="server" Visible="False"></asp:TextBox>
			<table align="center">
				<tr>
					<td><asp:label id="Label2" runat="server" CssClass="lable">分公司：</asp:label></td>
					<td><asp:dropdownlist id="ddlDept" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
					<td><asp:label id="Label12" runat="server" CssClass="lable">行业经理：</asp:label></td>
					<td><asp:dropdownlist id="ddlTradeMgr" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
					<td><asp:label id="Label9" runat="server" CssClass="lable">客户经理：</asp:label></td>
					<td><asp:dropdownlist id="ddlMgr" runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td><asp:label id="Label3" runat="server" CssClass="lable">开始时间：</asp:label></td>
					<td><asp:textbox id="txtBeginDate" onfocus="calendar()" runat="server"></asp:textbox></td>
					<td><asp:label id="Label4" runat="server" CssClass="lable">结束时间：</asp:label></td>
					<td><asp:textbox id="txtEndDate" onfocus="calendar()" runat="server"></asp:textbox></td>
					<td align="center" colspan="2"><asp:imagebutton id="btnOK" runat="server" ImageUrl="../image/btnOk.gif"></asp:imagebutton><asp:imagebutton id="btnCancel" runat="server" ImageUrl="../image/btnCancel.gif"></asp:imagebutton></td>
				</tr>
			</table>
			<table width="100%">
				<tr>
					<td align="center">
						<DCWC:Chart id="Chart1" runat="server" Palette="Pastel">
							<Titles>
								<dcwc:Title Text="商机比例销售漏斗" Name="Title1"></dcwc:Title>
							</Titles>
							<Legends>
								<dcwc:Legend Docking="Bottom" Name="Default"></dcwc:Legend>
							</Legends>
							<Series>
								<dcwc:Series ShowLabelAsValue="True" Name="Series1" ChartType="Funnel" CustomAttributes="FunnelOutsideLabelPlacement=Right, FunnelLabelStyle=OutsideInColumn"
									ShadowOffset="1"></dcwc:Series>
								<dcwc:Series ShowLabelAsValue="True" Name="Series2" ChartType="Funnel" CustomAttributes="FunnelOutsideLabelPlacement=Right, FunnelLabelStyle=OutsideInColumn"
									ShadowOffset="1"></dcwc:Series>
							</Series>
							<ChartAreas>
								<dcwc:ChartArea Name="Default" BorderColor="">
									<Area3DStyle Enable3D="True"></Area3DStyle>
								</dcwc:ChartArea>
							</ChartAreas>
						</DCWC:Chart>
						<dcwc:Chart id="Chart2" runat="server" Palette="Pastel">
							<Titles>
								<dcwc:Title Text="金额比例销售漏斗" Name="Title1"></dcwc:Title>
							</Titles>
							<Legends>
								<dcwc:Legend Docking="Bottom" Name="Default"></dcwc:Legend>
							</Legends>
							<Series>
								<dcwc:Series ShowLabelAsValue="True" Name="Series1" ChartType="Funnel" CustomAttributes="FunnelOutsideLabelPlacement=Right, FunnelLabelStyle=OutsideInColumn"
									ShadowOffset="1"></dcwc:Series>
								<dcwc:Series ShowLabelAsValue="True" Name="Series2" ChartType="Funnel" CustomAttributes="FunnelOutsideLabelPlacement=Right, FunnelLabelStyle=OutsideInColumn"
									ShadowOffset="1"></dcwc:Series>
							</Series>
							<ChartAreas>
								<dcwc:ChartArea Name="Default" BorderColor="">
									<Area3DStyle Enable3D="True"></Area3DStyle>
								</dcwc:ChartArea>
							</ChartAreas>
						</dcwc:Chart></td>
				</tr>
			</table>
			<table width="100%">
				<tr>
					<td align="center">
						<asp:datagrid id="DataGrid1" runat="server" Font-Size="X-Small" Width="100%" PageSize="15" AllowPaging="True"
							PagerStyle-HorizontalAlign="Right" BorderColor="Black" BorderWidth="1px" CellPadding="3" Font-Name="Verdana"
							HeaderStyle-BackColor="SteelBlue" AlternatingItemStyle-BackColor="#660033" Font-Names="Verdana"
							AutoGenerateColumns="False">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle Wrap="False"></SelectedItemStyle>
							<EditItemStyle Wrap="False"></EditItemStyle>
							<AlternatingItemStyle Wrap="False" ForeColor="Black" BackColor="#E6E6E6"></AlternatingItemStyle>
							<ItemStyle Wrap="False" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="Small" Font-Bold="True" Wrap="False" ForeColor="White" BackColor="#880028"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cnvcDeptIDComments" HeaderText="分公司">
									<ItemStyle Width="55px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="cnnProjectID" HeaderText="项目ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcChanceName" HeaderText="商机名称">
									<ItemStyle Width="55px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcCustName" HeaderText="客户名称">
									<ItemStyle Width="55px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcCustomTradeMgr" HeaderText="客户经理/行业经理">
									<ItemStyle Width="55px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcChanceSpeedComments" HeaderText="商机进展">
									<ItemStyle Width="55px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcChanceTypeComments" HeaderText="商机类型">
									<ItemStyle Width="55px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnnForecastIncome" HeaderText="预测收入（万元）">
									<ItemStyle Width="55px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cndChanceDate" HeaderText="商机时间" DataFormatString="{0:yyyy年MM月dd日}">
									<ItemStyle Width="55px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcIsSucessComments" HeaderText="已转化">
									<ItemStyle Width="55px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnnSucessIncome" HeaderText="转化收入（万元）">
									<ItemStyle Width="55px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cndSucessDate" HeaderText="转化时间" DataFormatString="{0:yyyy年MM月dd日}">
									<ItemStyle Width="55px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcProjectStateComments" HeaderText="商机状态">
									<ItemStyle Width="55px"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
