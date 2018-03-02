<%@ Page language="c#" Codebehind="wfmVCustInfo.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.VCustInfo.wfmVCustInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmVCustInfo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#f2f8fb">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="5" width="95%" border="0" align="center">
				<TR>
					<TD align="center" style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033">客户档案管理</TD>
				</TR>
			</TABLE>
			<table cellspacing="0" cellpadding="0" width="95%" border="1" align="center">
				<tr>
					<td>
						<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%" border="0" align="center">
							<TR>
								<TD style="WIDTH: 123px" align="right"><asp:label id="Label1" runat="server" Width="59px" Font-Size="10pt">客户名称</asp:label></TD>
								<TD style="WIDTH: 166px">
									<asp:TextBox id="txtCustName" runat="server" Width="176px"></asp:TextBox></TD>
								<TD style="WIDTH: 97px" align="right">
									<asp:label id="Label4" runat="server" Font-Size="10pt" Width="59px">客户等级</asp:label></TD>
								<TD style="WIDTH: 159px"><FONT face="宋体">
										<asp:DropDownList id="ddlCustLevel" runat="server" Width="176px"></asp:DropDownList></FONT></TD>
								<td style="WIDTH: 83px" align="right"></td>
								<TD style="WIDTH: 191px"><FONT face="宋体"></FONT></TD>
								<TD style="WIDTH: 90px">
									<asp:button id="btnQuery" runat="server" Width="64px" Text="查询"></asp:button></TD>
								<td></td>
							</TR>
							<TR>
								<TD style="WIDTH: 123px" align="right">
									<asp:label id="Label5" runat="server" Font-Size="10pt" Width="55px">一级行业</asp:label></TD>
								<TD style="WIDTH: 166px">
									<asp:DropDownList id="ddlTrade1" runat="server" Width="176px" AutoPostBack="true"></asp:DropDownList></TD>
								<TD style="WIDTH: 97px" align="right">
									<asp:label id="Label2" runat="server" Font-Size="10pt" Width="55px">二级行业</asp:label></TD>
								<TD style="WIDTH: 159px"><FONT face="宋体">
										<asp:DropDownList id="ddlTrade2" runat="server" Width="176px" AutoPostBack="true"></asp:DropDownList></FONT></TD>
								<td style="WIDTH: 83px" align="right">
									<asp:label id="Label6" runat="server" Font-Size="10pt" Width="55px">三级行业</asp:label></td>
								<TD style="WIDTH: 191px">
									<asp:DropDownList id="ddlTrade3" runat="server" Width="176px" AutoPostBack="False"></asp:DropDownList></TD>
								<TD style="WIDTH: 90px">
									<asp:button id="btnAdd" runat="server" Width="64px" Text="新增"></asp:button></TD>
								<td>
									<asp:button id="btnExportIn" runat="server" Width="64px" Text="导入"></asp:button></td>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="95%" border="0" align="center">
				<TR>
					<TD align="center"><asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" Font-Names="Verdana" Width="100%"
							AlternatingItemStyle-BackColor="#660033" HeaderStyle-BackColor="SteelBlue" Font-Size="X-Small" Font-Name="Verdana"
							CellPadding="3" BorderWidth="1px" BorderColor="Black" PagerStyle-HorizontalAlign="Right" AllowPaging="True"
							PageSize="15">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle Wrap="False"></SelectedItemStyle>
							<EditItemStyle Wrap="False"></EditItemStyle>
							<AlternatingItemStyle Wrap="False" ForeColor="Black" BackColor="#E6E6E6"></AlternatingItemStyle>
							<ItemStyle Wrap="False" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="Small" Font-Bold="True" Wrap="False" ForeColor="White" BackColor="#880028"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cnnCustID" ReadOnly="True" HeaderText="客户编码"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcName" ReadOnly="True" HeaderText="客户名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcLevelComments" ReadOnly="True" HeaderText="客户等级"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcAddress" ReadOnly="True" HeaderText="地址"></asp:BoundColumn>
								<asp:HyperLinkColumn Text="详细资料" Target="_self" DataNavigateUrlField="cnnCustID" DataNavigateUrlFormatString="wfmVCustDetail.aspx?type=mod&amp;&amp;id={0}"
									HeaderText="查看"></asp:HyperLinkColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</FORM>
	</body>
</HTML>
