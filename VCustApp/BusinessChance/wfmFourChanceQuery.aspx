<%@ Page language="c#" Codebehind="wfmFourChanceQuery.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.BusinessChance.wfmFourChanceQuery" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmChanceQuery</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table align="center">
				<tr>
					<td colSpan="2"><asp:label id="Label1" style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033" runat="server"
							Height="52">销售影响因素表</asp:label></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="1">
				<tr>
					<td><asp:label id="Label5" runat="server" CssClass="lable">分公司：</asp:label></td>
					<td><asp:dropdownlist id="ddlDept" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
					<td><asp:label id="Label2" runat="server" CssClass="lable">商机名称：</asp:label></td>
					<td><asp:textbox id="txtProjectName" runat="server" CssClass="textbox"></asp:textbox></td>
					<td><asp:label id="Label3" runat="server" CssClass="lable">商机类型：</asp:label></td>
					<td><asp:dropdownlist id="ddlChanceType" runat="server" AutoPostBack="True"></asp:dropdownlist><br>
						<asp:dropdownlist id="ddlChanceType2" runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td><asp:label id="Label4" runat="server" CssClass="lable">客户名称：</asp:label></td>
					<td><asp:textbox id="txtCustName" runat="server" CssClass="textbox"></asp:textbox></td>
					<td><asp:label id="Label6" runat="server" CssClass="lable">商机预测收入（万元）：</asp:label></td>
					<td><asp:textbox id="txtForecaseIncome" runat="server" CssClass="textbox"></asp:textbox></td>
					<td><asp:label id="Label9" runat="server" CssClass="lable">客户经理：</asp:label></td>
					<td><asp:dropdownlist id="ddlMgr" runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td><asp:label id="Label7" runat="server" CssClass="lable">行业经理：</asp:label></td>
					<td><asp:dropdownlist id="ddlTradeMgr" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
					<td><asp:label id="Label8" runat="server" CssClass="lable">商机进展：</asp:label></td>
					<td><asp:dropdownlist id="ddlChanceSpeed" runat="server"></asp:dropdownlist></td>
					<td align="center" colSpan="2"><asp:imagebutton id="btnOK" runat="server" ImageUrl="../image/btnOk.gif"></asp:imagebutton><asp:imagebutton id="btnCancel" runat="server" ImageUrl="../image/btnCancel.gif"></asp:imagebutton></td>
				</tr>
			</table>
			<table align="left" width="1600">
				<tr>
					<td align="left"><asp:datagrid id="DataGrid1" runat="server" Font-Size="X-Small" PageSize="15" AllowPaging="True"
							PagerStyle-HorizontalAlign="Right" BorderColor="Black" BorderWidth="1px" CellPadding="3" Font-Name="Verdana"
							HeaderStyle-BackColor="SteelBlue" AlternatingItemStyle-BackColor="#660033" Font-Names="Verdana" AutoGenerateColumns="False">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle Wrap="False"></SelectedItemStyle>
							<EditItemStyle Wrap="False"></EditItemStyle>
							<AlternatingItemStyle Wrap="False" ForeColor="Black" BackColor="#E6E6E6"></AlternatingItemStyle>
							<ItemStyle Wrap="False" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="Small" Font-Bold="True" Wrap="False" ForeColor="White" BackColor="#880028"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cnvcDeptIDComments" HeaderText="分公司">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="cnnProjectID" HeaderText="项目ID">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcChanceName" HeaderText="商机名称">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcCustName" HeaderText="客户名称">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcCustomTradeMgr" HeaderText="客户经理/行业经理">
								<ItemStyle Width="90px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcChanceSpeedComments" HeaderText="商机进展">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcChanceTypeComments" HeaderText="商机类型">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnnForecastIncome" HeaderText="预测收入">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cndChanceDate" HeaderText="商机时间" DataFormatString="{0:yyyy年MM月dd日}">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:HyperLinkColumn Text="销售影响因素表" DataNavigateUrlField="cnnProjectID" DataNavigateUrlFormatString="wfmFour.aspx?cnnProjectID={0}"
									HeaderText="销售影响因素表">
									<ItemStyle Width="70px"></ItemStyle>
									</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="cnvcIsSucessComments" HeaderText="已转化">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnnSucessIncome" HeaderText="转化收入">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cndSucessDate" HeaderText="转化时间" DataFormatString="{0:yyyy年MM月dd日}">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcProjectStateComments" HeaderText="商机状态">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
