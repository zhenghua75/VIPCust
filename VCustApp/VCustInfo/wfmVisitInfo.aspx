<%@ Page language="c#" Codebehind="wfmVisitInfo.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.VCustInfo.wfmVisitInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmVisitInfo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgcolor="#f2f8fb">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="5" width="95%" border="0" align="center">
				<TR>
					<TD align="center" style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033">�ݷø���</TD>
				</TR>
			</TABLE>
			<table cellspacing="0" cellpadding="0" width="95%" border="1" align="center">
				<tr>
					<td>
						<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 160px; HEIGHT: 25px" align="right"><asp:label id="Label1" runat="server" Width="59px" Font-Size="10pt">�ͻ����</asp:label></TD>
								<TD style="WIDTH: 124px; HEIGHT: 25px">
									<asp:TextBox id="txtCustID" runat="server" Width="176px"></asp:TextBox></TD>
								<TD style="WIDTH: 97px; HEIGHT: 25px" align="right">
									<asp:label id="Label2" runat="server" Font-Size="10pt" Width="59px">�ͻ�����</asp:label></TD>
								<TD style="WIDTH: 159px; HEIGHT: 25px"><FONT face="����">
										<asp:TextBox id="txtCustName" runat="server" Width="176px"></asp:TextBox></FONT></TD>
								<td style="WIDTH: 83px; HEIGHT: 25px" align="right"></td>
								<TD style="WIDTH: 78px; HEIGHT: 25px"><FONT face="����"></FONT></TD>
								<TD style="HEIGHT: 25px">
									<asp:button id="btnQuery" runat="server" Width="64px" Text="��ѯ"></asp:button></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 160px" align="right">
									<asp:label id="Label3" runat="server" Font-Size="10pt" Width="70px">��Ŀ����</asp:label></TD>
								<TD style="WIDTH: 124px">
									<asp:TextBox id="txtProjectName" runat="server" Width="176px"></asp:TextBox></TD>
								<TD style="WIDTH: 97px" align="right"></TD>
								<TD style="WIDTH: 159px"><FONT face="����"></FONT></TD>
								<td style="WIDTH: 83px"></td>
								<TD style="WIDTH: 78px"></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="95%" border="0" align="center">
				<TR>
					<TD align="center"><asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" Font-Names="Verdana" Width="100%"
							AlternatingItemStyle-BackColor="#660033" HeaderStyle-BackColor="SteelBlue" Font-Size="X-Small" Font-Name="Verdana"
							CellPadding="3" BorderWidth="1px" BorderColor="Black" PagerStyle-HorizontalAlign="Right">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle Wrap="False"></SelectedItemStyle>
							<EditItemStyle Wrap="False"></EditItemStyle>
							<AlternatingItemStyle Wrap="False" ForeColor="Black" BackColor="#E6E6E6"></AlternatingItemStyle>
							<ItemStyle Wrap="False" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="Small" Font-Bold="True" Wrap="False" ForeColor="White" BackColor="#880028"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cnnCustID" ReadOnly="True" HeaderText="�ͻ�����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcName" ReadOnly="True" HeaderText="�ͻ�����"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="cnnProjectID" ReadOnly="True" HeaderText="��Ŀ���"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcProjectName" ReadOnly="True" HeaderText="��Ŀ����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcMgr" ReadOnly="True" HeaderText="�ͻ�����/��ҵ����"></asp:BoundColumn>
								<asp:ButtonColumn Text="�ݷü�¼" HeaderText="�鿴" CommandName="Select"></asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Right"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</FORM>
	</body>
</HTML>
