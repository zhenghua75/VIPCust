<%@ Page language="c#" Codebehind="wfmVisitDetail.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.VCustInfo.wfmVisitDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmVisitDetail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#f2f8fb" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="5" width="95%" align="center" border="0" align="center">
				<TR>
					<TD style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033" align="center">�ݷü�¼��ϸ</TD>
				</TR>
			</TABLE>
			<table cellSpacing="0" cellPadding="0" width="95%" align="center" border="1" align="center">
				<tr>
					<td>
						<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 115px" align="right"><asp:label id="Label3" runat="server" Font-Size="10pt" Width="73px">�ͻ���ţ�</asp:label></TD>
								<TD style="WIDTH: 124px"><FONT face="����"><asp:textbox id="txtCustID" runat="server" Width="176px"></asp:textbox></FONT></TD>
								<TD style="WIDTH: 199px" align="right"><FONT face="����"><asp:label id="Label1" runat="server" Font-Size="10pt" Width="72px">�ͻ����ƣ�</asp:label></FONT></TD>
								<TD style="WIDTH: 90px" align="right"><FONT face="����"><asp:textbox id="txtCustName" runat="server" Width="176px"></asp:textbox></FONT></TD>
								<TD style="WIDTH: 126px" align="right"></TD>
								<TD style="WIDTH: 126px" align="right"></TD>
								<TD style="WIDTH: 78px"><FONT face="����"><asp:button id="btnAdd" runat="server" Width="64px" Text="����"></asp:button></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 115px" align="right">
									<asp:label id="Label5" runat="server" Width="73px" Font-Size="10pt">��Ŀ��ţ�</asp:label></TD>
								<TD style="WIDTH: 124px"><FONT face="����">
										<asp:textbox id="txtProjectID" runat="server" Width="176px"></asp:textbox></FONT></TD>
								<TD style="WIDTH: 199px" align="right"><FONT face="����"><asp:label id="Label2" runat="server" Font-Size="10pt" Width="73px">��Ŀ���ƣ�</asp:label></FONT></TD>
								<TD style="WIDTH: 90px" align="right"><FONT face="����"><asp:textbox id="txtProjectName" runat="server" Width="176px"></asp:textbox></FONT></TD>
								<TD style="WIDTH: 126px" align="right"><asp:label id="Label4" runat="server" Font-Size="10pt" Width="72px">�ͻ�����</asp:label></TD>
								<TD style="WIDTH: 126px" align="right"><asp:textbox id="txtMgr" runat="server" Width="176px"></asp:textbox></TD>
								<TD style="WIDTH: 78px"><FONT face="����"><asp:button id="Button1" runat="server" Width="64px" Text="����"></asp:button></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 115px" align="right"></TD>
								<TD style="WIDTH: 124px" align="center"></TD>
								<TD style="WIDTH: 199px" align="right"></TD>
								<TD style="WIDTH: 90px" align="center"></TD>
								<TD style="WIDTH: 126px" align="center"></TD>
								<TD style="WIDTH: 78px"></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="95%" align="center" border="0" align="center">
				<TR>
					<TD align="center"><asp:datagrid id="DataGrid1" runat="server" Font-Size="X-Small" Width="100%" AutoGenerateColumns="False"
							Font-Names="Verdana" AlternatingItemStyle-BackColor="#660033" HeaderStyle-BackColor="SteelBlue" Font-Name="Verdana"
							CellPadding="3" BorderWidth="1px" BorderColor="Black" PagerStyle-HorizontalAlign="Right">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle Wrap="False"></SelectedItemStyle>
							<EditItemStyle Wrap="False"></EditItemStyle>
							<AlternatingItemStyle Wrap="False" ForeColor="Black" BackColor="#E6E6E6"></AlternatingItemStyle>
							<ItemStyle Wrap="False" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="Small" Font-Bold="True" Wrap="False" ForeColor="White" BackColor="#880028"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cnnVisitSerialNo" ReadOnly="True" HeaderText="�ݷ���ˮ"></asp:BoundColumn>
								<asp:BoundColumn DataField="cndVisitDate" ReadOnly="True" HeaderText="�ݷ�����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcVisitContent" ReadOnly="True" HeaderText="�ݷ�����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcVisitDept" ReadOnly="True" HeaderText="�ݷò���"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcVisitMan" ReadOnly="True" HeaderText="������"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcWellType" ReadOnly="True" HeaderText="�ͻ�̬��"></asp:BoundColumn>
								<asp:HyperLinkColumn Text="��ϸ��Ϣ" Target="_self" DataNavigateUrlField="cnnVisitSerialNo" HeaderText="�鿴"
									DataNavigateUrlFormatString="wfmVisitAddMod.aspx?type=mod&&vid={0}"></asp:HyperLinkColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Right"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</FORM>
	</body>
</HTML>
