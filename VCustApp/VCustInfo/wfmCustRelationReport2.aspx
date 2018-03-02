<%@ Page language="c#" Codebehind="wfmCustRelationReport2.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.VCustInfo.wfmCustRelationReport2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>wfmCustRelationReport2</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
	<body MS_POSITIONING="GridLayout" bgcolor="#f2f8fb">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="5" width="95%" border="0" align="center">
				<TR>
					<TD align="center" style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033">客户联系人信息</TD>
				</TR>
			</TABLE>
			<table cellspacing="0" cellpadding="0" width="95%" border="1" align="center">
				<tr>
					<td>
						<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 160px" align="right"></TD>
								<TD style="WIDTH: 124px" align="right">
									<asp:label id="Label2" runat="server" Width="59px" Font-Size="10pt">客户编码</asp:label></TD>
								<TD style="WIDTH: 97px" align="right">
									<asp:TextBox id="txtCustID" runat="server" Width="176px"></asp:TextBox></TD>
								<TD style="WIDTH: 159px" align="right"><asp:label id="Label1" runat="server" Width="59px" Font-Size="10pt">客户名称</asp:label></TD>
								<td style="WIDTH: 83px" align="right">
									<asp:TextBox id="txtCustName" runat="server" Width="176px"></asp:TextBox></td>
								<TD style="WIDTH: 78px"><FONT face="宋体"></FONT></TD>
								<TD>
									<asp:button id="btnQuery" runat="server" Width="64px" Text="查询"></asp:button></TD>
							</TR>
							<TR height="20">
								<TD style="WIDTH: 160px" align="right"></TD>
								<TD style="WIDTH: 124px"></TD>
								<TD style="WIDTH: 97px" align="right"></TD>
								<TD style="WIDTH: 159px"><FONT face="宋体"></FONT></TD>
								<td style="WIDTH: 83px" align="right"></td>
								<TD style="WIDTH: 78px"></TD>
								<TD>
<asp:button id=btnExcel runat="server" Width="64px" Text="导出"></asp:button></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
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
								<asp:BoundColumn DataField="cnnCustID" ReadOnly="True" HeaderText="客户编码"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcName" ReadOnly="True" HeaderText="客户名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcTradeTypeComments" ReadOnly="True" HeaderText="行业属性"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcLevelComments" ReadOnly="True" HeaderText="客户等级"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcLinkName" ReadOnly="True" HeaderText="姓名"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcSexComments" ReadOnly="True" HeaderText="性别"></asp:BoundColumn>
								<asp:BoundColumn DataField="cndBirthday" ReadOnly="True" HeaderText="生日"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcEducationComments" ReadOnly="True" HeaderText="学历"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcLinkTypeComments" ReadOnly="True" HeaderText="联系人属性"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcDeptName" ReadOnly="True" HeaderText="部门名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcRelativeDeptTypeComments" ReadOnly="True" HeaderText="部门属性"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcDuty" ReadOnly="True" HeaderText="职务"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcJob" ReadOnly="True" HeaderText="负责工作"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcPhone" ReadOnly="True" HeaderText="座机"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcMobilePhone" ReadOnly="True" HeaderText="手机"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcEmail" ReadOnly="True" HeaderText="电子邮件"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcLike" ReadOnly="True" HeaderText="爱好性格"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcAddress" ReadOnly="True" HeaderText="通信地址"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</FORM>
	</body>
</HTML>
