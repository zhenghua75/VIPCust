<%@ Page language="c#" Codebehind="wfmCustRelationReport1.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.VCustInfo.wfmCustRelationReport1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmCustRelationReport1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#f2f8fb" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="5" width="95%" align="center" border="0">
				<TR>
					<TD style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033" align="center">�ͻ�������Ϣ</TD>
				</TR>
			</TABLE>
			<table cellSpacing="0" cellPadding="0" width="95%" align="center" border="1">
				<tr>
					<td>
						<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 160px" align="right"></TD>
								<TD style="WIDTH: 124px" align="right"><asp:label id="Label2" runat="server" Font-Size="10pt" Width="59px">�ͻ�����</asp:label></TD>
								<TD style="WIDTH: 97px" align="right"><asp:textbox id="txtCustID" runat="server" Width="176px"></asp:textbox></TD>
								<TD style="WIDTH: 159px" align="right"><asp:label id="Label1" runat="server" Font-Size="10pt" Width="59px">�ͻ�����</asp:label></TD>
								<td style="WIDTH: 83px" align="right"><asp:textbox id="txtCustName" runat="server" Width="176px"></asp:textbox></td>
								<TD style="WIDTH: 78px"><FONT face="����"></FONT></TD>
								<TD><asp:button id="btnQuery" runat="server" Width="64px" Text="��ѯ"></asp:button></TD>
							</TR>
							<TR height="20">
								<TD style="WIDTH: 160px" align="right"></TD>
								<TD style="WIDTH: 124px"></TD>
								<TD style="WIDTH: 97px" align="right"></TD>
								<TD style="WIDTH: 159px"><FONT face="����"></FONT></TD>
								<td style="WIDTH: 83px" align="right"><FONT face="����"></FONT></td>
								<TD style="WIDTH: 78px"></TD>
								<TD><asp:button id="btnExcel" runat="server" Width="64px" Text="����"></asp:button></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="1600" align="left" border="0">
				<TR>
					<TD align="left">
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
								<asp:BoundColumn DataField="cnnCustID" ReadOnly="True" HeaderText="�ͻ�����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcName" ReadOnly="True" HeaderText="�ͻ�����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcTradeTypeComments" ReadOnly="True" HeaderText="��ҵ����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcLevelComments" ReadOnly="True" HeaderText="�ͻ��ȼ�"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcIntro" ReadOnly="True" HeaderText="��λ����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcAddress" ReadOnly="True" HeaderText="��ַ"></asp:BoundColumn>
								<asp:BoundColumn DataField="cndCreateDate" ReadOnly="True" HeaderText="��ϵ����ʱ��"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcIT" ReadOnly="True" HeaderText="��Ϣ�����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcCompetitor" ReadOnly="True" HeaderText="��������"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnMonthFee" ReadOnly="True" HeaderText="��ͨ�ŷ�(��Ԫ)"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcITPlan" ReadOnly="True" HeaderText="��Ϣ���ƻ�"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcRelativeDept" ReadOnly="True" HeaderText="��ز���"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcRelativeDeptTypeComments" ReadOnly="True" HeaderText="��������"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcPayAbilityComments" ReadOnly="True" HeaderText="֧������"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcContractTypeComments" ReadOnly="True" HeaderText="Э�����"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
