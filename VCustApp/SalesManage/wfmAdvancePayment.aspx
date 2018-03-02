<%@ Page language="c#" Codebehind="wfmAdvancePayment.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.SalesManage.wfmAdvancePayment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmAdvancePayment</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../css/style.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../script/calendar.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table align="center">
				<tr>
					<td colspan="2">
						<asp:Label id="Label1" runat="server" style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033">预收账款管理</asp:Label></td>
				</tr>
			</table>
			<table align="center">
				<tr>
					<td>
						<asp:Label id="Label4" runat="server" CssClass="lable">客户名称：</asp:Label></td>
					<td>
						<asp:TextBox id="txtCustName" runat="server"></asp:TextBox></td>
					<td>
						<asp:Label id="Label2" runat="server" CssClass="lable">项目名称：</asp:Label></td>
					<td>
						<asp:TextBox id="txtProjectName" runat="server"></asp:TextBox></td>
					<td>
						<asp:Label id="Label3" runat="server" CssClass="lable">账户名称：</asp:Label></td>
					<td>
						<asp:TextBox id="txtAcctName" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label9" runat="server" CssClass="lable">客户经理：</asp:Label></td>
					<TD>
						<asp:TextBox id="txtMgr" runat="server"></asp:TextBox></TD>
					<TD>
						<asp:Label id="Label5" runat="server" CssClass="lable">交款时间：</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtPayDate" runat="server" onfocus="calendar()"></asp:TextBox></TD>
					<td>
						<asp:Label id="Label6" runat="server" CssClass="lable">费用类型：</asp:Label></td>
					<td>
						<asp:TextBox id="txtFeeName" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label8" runat="server" CssClass="lable">费用计收时间：</asp:Label></td>
					<td>
						<asp:TextBox id="txtFeeDate" runat="server" onfocus="calendar()"></asp:TextBox></td>
					<td>
						<asp:Label id="Label12" runat="server" CssClass="lable">交款金额：</asp:Label></td>
					<td>
						<asp:TextBox id="txtPayFee" runat="server"></asp:TextBox></td>
					<td>
						<asp:Label id="Label13" runat="server" CssClass="lable">缴预存款金额：</asp:Label></td>
					<td>
						<asp:TextBox id="txtPrepayFee" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="6" align="center">
						<asp:Button id="btnQuery" runat="server" Text="查询"></asp:Button>
						<asp:Button id="btnCancel" runat="server" Text="取消"></asp:Button>
						<asp:Button id="btnAdd" runat="server" Text="添加"></asp:Button>
						<asp:Button id="btnExcel" runat="server" Text="导出EXCEL"></asp:Button>
						<asp:Button id="btnLoadAdvancePayment" runat="server" Text="导入"></asp:Button></td>
				</tr>
			</table>
			<table width="100%" align="center">
				<tr>
					<td align="center">
						<asp:DataGrid id="DataGrid1" runat="server" Font-Size="X-Small" Width="100%" PageSize="15" AllowPaging="True"
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
								<asp:BoundColumn Visible="False" DataField="cnnCustID" HeaderText="客户ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcCustName" HeaderText="客户名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcProjectName" HeaderText="项目名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcAcctName" HeaderText="账户名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcMgr" HeaderText="客户经理"></asp:BoundColumn>
								<asp:BoundColumn DataField="cndPayDate" HeaderText="交款时间"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcFeeName" HeaderText="费用类型"></asp:BoundColumn>
								<asp:BoundColumn DataField="cndFeeDate" HeaderText="费用计收时间"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnPayFee" HeaderText="交款金额"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnPrepayFee" HeaderText="缴预存款金额"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcComments" HeaderText="备注"></asp:BoundColumn>
								<asp:HyperLinkColumn Text="修改" DataNavigateUrlField="cnnCustID" DataNavigateUrlFormatString="wfmModifyAdvancepayment.aspx?cnnCustID={0}"
									HeaderText="修改"></asp:HyperLinkColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
