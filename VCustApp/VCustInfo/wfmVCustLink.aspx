<%@ Page language="c#" Codebehind="wfmVCustLink.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.VCustInfo.wfmVCustLink" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmVCustLink</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#f2f8fb">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="5" border="0" align="center" width="95%">
				<TR>
					<TD align="center" style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033">客户联系人</TD>
				</TR>
			</TABLE>
			<table cellspacing="0" cellpadding="0" border="1" align="center" width="95%">
				<tr>
					<td>
						<TABLE id="Table2" cellSpacing="0" cellPadding="1" border="0" align="center" width="100%">
							<TR>
								<TD style="WIDTH: 93px" align="right"></TD>
								<TD style="WIDTH: 166px" align="right">
									<asp:label id="Label2" runat="server" Width="59px" Font-Size="10pt">客户编号</asp:label></TD>
								<TD style="WIDTH: 97px" align="right">
									<asp:TextBox id="txtCustID" runat="server" Width="176px"></asp:TextBox></TD>
								<TD style="WIDTH: 159px" align="right"><FONT face="宋体"><asp:label id="Label1" runat="server" Width="59px" Font-Size="10pt">客户名称</asp:label></FONT></TD>
								<td style="WIDTH: 83px" align="right">
									<asp:TextBox id="txtCustName" runat="server" Width="176px"></asp:TextBox></td>
								<TD style="WIDTH: 78px"><FONT face="宋体"></FONT></TD>
								<TD>
									<asp:button id="btnQuery" runat="server" Width="64px" Text="查询"></asp:button></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 93px" align="right"></TD>
								<TD style="WIDTH: 166px"></TD>
								<TD style="WIDTH: 97px" align="right"></TD>
								<TD style="WIDTH: 159px"><FONT face="宋体"></FONT></TD>
								<td style="WIDTH: 83px" align="right"></td>
								<TD style="WIDTH: 78px"></TD>
								<TD>
									<asp:button id="btnAdd" runat="server" Width="64px" Text="新增"></asp:button></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 93px" align="right"></TD>
								<TD style="WIDTH: 166px" align="right">
									<asp:label id="Label3" runat="server" Font-Size="10pt" Width="109px">当前客户编号：</asp:label></TD>
								<TD style="WIDTH: 97px" align="center">
									<asp:label id="lblCustID" runat="server" Font-Size="10pt" Width="168px"></asp:label></TD>
								<TD style="WIDTH: 159px" align="right"><FONT face="宋体">
										<asp:label id="Label4" runat="server" Font-Size="10pt" Width="109px">当前客户名称：</asp:label></FONT></TD>
								<td style="WIDTH: 83px" align="center">
									<asp:label id="lblCustName" runat="server" Font-Size="10pt" Width="216px"></asp:label></td>
								<TD style="WIDTH: 78px"></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<TABLE id="Table4" cellSpacing="1" cellPadding="1" border="0" align="left" width="1600">
				<TR>
					<TD align="left"><asp:datagrid id="DataGrid1" runat="server" Font-Size="X-Small" AllowPaging="True" PagerStyle-HorizontalAlign="Right"
							BorderColor="Black" BorderWidth="1px" CellPadding="3" Font-Name="Verdana" HeaderStyle-BackColor="SteelBlue"
							AlternatingItemStyle-BackColor="#660033" Font-Names="Verdana" AutoGenerateColumns="False" PageSize="15">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle Wrap="False"></SelectedItemStyle>
							<EditItemStyle Wrap="False"></EditItemStyle>
							<AlternatingItemStyle Wrap="False" ForeColor="Black" BackColor="#E6E6E6"></AlternatingItemStyle>
							<ItemStyle Wrap="False" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="Small" Font-Bold="True" Wrap="False" ForeColor="White" BackColor="#880028"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cnnLinkID" ReadOnly="True" HeaderText="联系人ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcName" ReadOnly="True" HeaderText="姓名"></asp:BoundColumn>
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
								<asp:BoundColumn DataField="cnvcEmail" ReadOnly="True" HeaderText="Email"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcLike" ReadOnly="True" HeaderText="爱好及性格"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcAddress" ReadOnly="True" HeaderText="通讯地址"></asp:BoundColumn>
								<asp:HyperLinkColumn Text="详细资料" Target="_self" DataNavigateUrlField="cnnLinkID" DataNavigateUrlFormatString="wfmVCustLinkDetail.aspx?type=mod&amp;&amp;lid={0}"
									HeaderText="查看"></asp:HyperLinkColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</FORM>
	</body>
</HTML>
