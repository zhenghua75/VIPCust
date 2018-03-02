<%@ Page language="c#" Codebehind="wfmSaleCost.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.SalesManage.wfmSaleCost" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmSaleCost</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#f2f8fb">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="5" width="95%" border="0" align="center">
				<TR>
					<TD align="center" style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033">销售成本管理</TD>
				</TR>
			</TABLE>
			<table cellspacing="0" cellpadding="0" width="95%" border="1" align="center">
				<tr>
					<td>
						<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%" border="0" align="center">
							<TBODY>
								<TR>
									<TD style="WIDTH: 98px" align="right"><asp:label id="Label1" runat="server" Width="59px" Font-Size="10pt">客户编号</asp:label></TD>
									<TD style="WIDTH: 166px">
										<asp:TextBox id="txtCustID" runat="server" Width="176px"></asp:TextBox></TD>
									<TD style="WIDTH: 85px" align="right">
										<asp:label id="Label3" runat="server" Font-Size="10pt" Width="59px">客户名称</asp:label></TD>
									<TD style="WIDTH: 159px"><FONT face="宋体">
											<asp:TextBox id="txtCustName" runat="server" Width="176px"></asp:TextBox></FONT></TD>
									<td style="WIDTH: 79px" align="right">
										<asp:label id="Label4" runat="server" Font-Size="10pt" Width="59px">年份</asp:label></td>
									<TD style="WIDTH: 78px"><FONT face="宋体">
											<asp:DropDownList id="ddlYear" runat="server" Width="176px"></asp:DropDownList></FONT></TD>
									<TD align="center" style="WIDTH: 127px">
										<asp:button id="btnQuery" runat="server" Width="64px" Text="查询"></asp:button></TD>
									<td>
										<asp:button id="btnExcel" runat="server" Width="64px" Text="导出"></asp:button></td>
								</TR>
								<TR>
									<TD style="WIDTH: 98px" align="right"></TD>
									<TD style="WIDTH: 166px"></TD>
									<TD style="WIDTH: 85px" align="right"></TD>
									<TD style="WIDTH: 159px"><FONT face="宋体"></FONT></TD>
									<td style="WIDTH: 79px" align="right"></td>
									<TD style="WIDTH: 78px"><FONT face="宋体"></FONT></TD>
									<TD align="center" style="WIDTH: 127px">
										<asp:button id="btnAdd" runat="server" Width="64px" Text="新增"></asp:button></TD>
									<td>
										<asp:button id="btnExportIn" runat="server" Width="64px" Text="导入"></asp:button></td>
					</td>
				</tr>
			</table>
			</TD></TR></TBODY></TABLE>
			<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="1600" border="0" align="left">
				<TR>
					<TD align="left"><asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" Font-Names="Verdana" Width="100%"
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
								<asp:BoundColumn DataField="cnnCustID" ReadOnly="True" HeaderText="客户ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcCustName" ReadOnly="True" HeaderText="客户名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcYear" ReadOnly="True" HeaderText="年份"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnBudgetCost" ReadOnly="True" HeaderText="预算销售成本（万元）"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnRealSaleCost" ReadOnly="True" HeaderText="实际销售成本合计（万元）"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnCostUsed" ReadOnly="True" HeaderText="成本费用使用进度情况"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnUsed1" HeaderText="1月"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnUsed2" HeaderText="2月"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnUsed3" HeaderText="3月"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnUsed4" HeaderText="4月"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnUsed5" HeaderText="5月"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnUsed6" HeaderText="6月"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnUsed7" HeaderText="7月"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnUsed8" HeaderText="8月"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnUsed9" HeaderText="9月"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnUsed10" HeaderText="10月"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnUsed11" HeaderText="11月"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnUsed12" HeaderText="12月"></asp:BoundColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" HeaderText="修改" CancelText="取消" EditText="编辑"></asp:EditCommandColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</FORM>
	</body>
</HTML>
