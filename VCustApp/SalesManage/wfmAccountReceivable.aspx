<%@ Page language="c#" Codebehind="wfmAccountReceivable.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.SalesManage.wfmAccountReceivable" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmAccountReceivable</title>
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
						<asp:Label id="Label1" runat="server" style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033">应收管理</asp:Label></td>
				</tr>
			</table>
			<table align="center">
				<tr>
					<td>
						<asp:Label id="Label5" runat="server" CssClass="lable">客户ID</asp:Label></td>
					<td>
						<asp:TextBox id="txtCustID" runat="server"></asp:TextBox></td>
					<td>
						<asp:Label id="Label4" runat="server" CssClass="lable">客户名称：</asp:Label></td>
					<td>
						<asp:TextBox id="txtCustName" runat="server"></asp:TextBox></td>
					<td>
						<asp:Label id="Label14" runat="server" CssClass="lable">一级行业属性：</asp:Label></td>
					<td>
						<asp:DropDownList id="ddlTradeType1" runat="server"></asp:DropDownList></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label15" runat="server" CssClass="lable">二级行业属性：</asp:Label></td>
					<td>
						<asp:DropDownList id="ddlTradeType2" runat="server"></asp:DropDownList></td>
					<td>
						<asp:Label id="Label16" runat="server" CssClass="lable">客户等级：</asp:Label></td>
					<td>
						<asp:DropDownList id="ddlCustLevel" runat="server"></asp:DropDownList></td>
					<td>
						<asp:Label id="Label9" runat="server" CssClass="lable">合同编号：</asp:Label></td>
					<td>
						<asp:TextBox id="txtContractNo" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label2" runat="server" CssClass="lable">项目名称：</asp:Label></td>
					<td>
						<asp:TextBox id="txtProjectName" runat="server"></asp:TextBox></td>
					<TD>
						<asp:Label id="Label6" runat="server" CssClass="lable">客户卡号：</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtAcctID" runat="server"></asp:TextBox></TD>
					<td>
						<asp:Label id="Label3" runat="server" CssClass="lable">账户名称：</asp:Label></td>
					<td>
						<asp:TextBox id="txtAcctName" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="6" align="center">
						<asp:Button id="btnQuery" runat="server" Text="查询"></asp:Button>
						<asp:Button id="btnCancel" runat="server" Text="取消"></asp:Button>
						<asp:Button id="btnAdd" runat="server" Text="添加"></asp:Button>
						<asp:Button id="btnExcel" runat="server" Text="导出EXCEL"></asp:Button>
						<asp:Button id="btnLoadAccountReceivable" runat="server" Text="导入"></asp:Button></td>
				</tr>
			</table>
			<table align="center" width="100%">
				<tr>
					<td>
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
								<asp:BoundColumn DataField="cnnCustID" HeaderText="客户ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcCustName" HeaderText="客户名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcTradeType1Comments" HeaderText="一级行业属性"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcTradeType2Comments" HeaderText="二级行业属性"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcCustLevelComments" HeaderText="客户等级"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcContractNo" HeaderText="合同编号"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcProjectName" HeaderText="项目名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnAcctID" HeaderText="客户卡号"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcAcctName" HeaderText="账户名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcSvcTypeName" HeaderText="业务种类"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnFee" HeaderText="收入（万元）"></asp:BoundColumn>
								<asp:HyperLinkColumn Text="修改" DataNavigateUrlField="cnnCustID" DataNavigateUrlFormatString="wfmModifyAccountReceivable.aspx?cnnCustID={0}"
									HeaderText="修改"></asp:HyperLinkColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
