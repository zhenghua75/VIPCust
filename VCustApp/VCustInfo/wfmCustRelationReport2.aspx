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
					<TD align="center" style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033">�ͻ���ϵ����Ϣ</TD>
				</TR>
			</TABLE>
			<table cellspacing="0" cellpadding="0" width="95%" border="1" align="center">
				<tr>
					<td>
						<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 160px" align="right"></TD>
								<TD style="WIDTH: 124px" align="right">
									<asp:label id="Label2" runat="server" Width="59px" Font-Size="10pt">�ͻ�����</asp:label></TD>
								<TD style="WIDTH: 97px" align="right">
									<asp:TextBox id="txtCustID" runat="server" Width="176px"></asp:TextBox></TD>
								<TD style="WIDTH: 159px" align="right"><asp:label id="Label1" runat="server" Width="59px" Font-Size="10pt">�ͻ�����</asp:label></TD>
								<td style="WIDTH: 83px" align="right">
									<asp:TextBox id="txtCustName" runat="server" Width="176px"></asp:TextBox></td>
								<TD style="WIDTH: 78px"><FONT face="����"></FONT></TD>
								<TD>
									<asp:button id="btnQuery" runat="server" Width="64px" Text="��ѯ"></asp:button></TD>
							</TR>
							<TR height="20">
								<TD style="WIDTH: 160px" align="right"></TD>
								<TD style="WIDTH: 124px"></TD>
								<TD style="WIDTH: 97px" align="right"></TD>
								<TD style="WIDTH: 159px"><FONT face="����"></FONT></TD>
								<td style="WIDTH: 83px" align="right"></td>
								<TD style="WIDTH: 78px"></TD>
								<TD>
<asp:button id=btnExcel runat="server" Width="64px" Text="����"></asp:button></TD>
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
								<asp:BoundColumn DataField="cnnCustID" ReadOnly="True" HeaderText="�ͻ�����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcName" ReadOnly="True" HeaderText="�ͻ�����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcTradeTypeComments" ReadOnly="True" HeaderText="��ҵ����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcLevelComments" ReadOnly="True" HeaderText="�ͻ��ȼ�"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcLinkName" ReadOnly="True" HeaderText="����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcSexComments" ReadOnly="True" HeaderText="�Ա�"></asp:BoundColumn>
								<asp:BoundColumn DataField="cndBirthday" ReadOnly="True" HeaderText="����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcEducationComments" ReadOnly="True" HeaderText="ѧ��"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcLinkTypeComments" ReadOnly="True" HeaderText="��ϵ������"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcDeptName" ReadOnly="True" HeaderText="��������"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcRelativeDeptTypeComments" ReadOnly="True" HeaderText="��������"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcDuty" ReadOnly="True" HeaderText="ְ��"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcJob" ReadOnly="True" HeaderText="������"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcPhone" ReadOnly="True" HeaderText="����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcMobilePhone" ReadOnly="True" HeaderText="�ֻ�"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcEmail" ReadOnly="True" HeaderText="�����ʼ�"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcLike" ReadOnly="True" HeaderText="�����Ը�"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcAddress" ReadOnly="True" HeaderText="ͨ�ŵ�ַ"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</FORM>
	</body>
</HTML>
