<%@ Page language="c#" Codebehind="wfmCustRelationDeepReport.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.VCustInfo.wfmCustRelationDeepReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmCustRelationDeepReport</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="../script/calendar.js"></script>
		<script language="javascript" src="../script/scrol.js"></script>
	</HEAD>
	<body bgcolor="#f2f8fb" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="5" width="95%" border="0" align="center">
				<TR>
					<TD align="center" style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033">�ͻ����۽���</TD>
				</TR>
			</TABLE>
			<table cellspacing="0" cellpadding="0" width="95%" border="1" align="center">
				<tr>
					<td>
						<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 146px; HEIGHT: 29px" align="right">
									<asp:label id="Label2" runat="server" Font-Size="10pt" Width="70px">�ͻ�����</asp:label></TD>
								<TD style="WIDTH: 206px; HEIGHT: 29px" align="right">
									<asp:TextBox id="txtCustID" runat="server" Width="176px"></asp:TextBox></TD>
								<TD style="WIDTH: 163px; HEIGHT: 29px" align="right">
									<asp:label id="Label1" runat="server" Font-Size="10pt" Width="104px">�ͻ�����</asp:label></TD>
								<TD style="WIDTH: 193px; HEIGHT: 29px" align="right"><FONT face="����">
										<asp:TextBox id="txtCustName" runat="server" Width="207px"></asp:TextBox></FONT></TD>
								<TD style="WIDTH: 231px; HEIGHT: 29px" align="right">
									<asp:label id="Label6" runat="server" Width="104px" Font-Size="10pt">��Ŀ����</asp:label></TD>
								<TD style="WIDTH: 197px; HEIGHT: 29px"><FONT face="����">
										<asp:TextBox id="txtChanceName" runat="server" Width="207px"></asp:TextBox></FONT></TD>
								<TD style="HEIGHT: 29px">
									<asp:button id="btnQuery" runat="server" Width="64px" Text="��ѯ"></asp:button></TD>
							</TR>
							<TR height="20">
								<TD style="WIDTH: 146px" align="right">
									<asp:label id="Label3" runat="server" Font-Size="10pt" Width="88px">��ʼʱ��</asp:label></TD>
								<TD style="WIDTH: 206px" align="right">
									<asp:TextBox id="txtBeginDate" runat="server" Width="176px" onfocus="calendar()"></asp:TextBox></TD>
								<TD style="WIDTH: 163px" align="right">
									<asp:label id="Label5" runat="server" Font-Size="10pt" Width="72px">����ʱ��</asp:label></TD>
								<TD style="WIDTH: 193px" align="right">
									<asp:TextBox id="txtEndDate" runat="server" Width="206px" onfocus="calendar()"></asp:TextBox></TD>
								<td style="WIDTH: 231px" align="left"></td>
								<TD style="WIDTH: 197px"></TD>
								<TD>
									<asp:button id="btnExcel" runat="server" Width="64px" Text="����"></asp:button></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 146px" align="right"></TD>
								<TD style="WIDTH: 206px" align="right"></TD>
								<TD style="WIDTH: 163px" align="center"></TD>
								<TD style="WIDTH: 193px" align="right"></TD>
								<td style="WIDTH: 231px" align="right">
									<asp:label id="Label4" runat="server" Width="111px" Font-Size="10pt">��ǰ�ͻ����룺</asp:label></td>
								<TD style="WIDTH: 197px" align="center">
									<asp:label id="lblCustID" runat="server" Font-Size="10pt" Width="168px"></asp:label></TD>
								<TD>
									<asp:button id="btnAdd" runat="server" Width="72px" Text="����άϵ"></asp:button></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="1600" border="0" align="left">
				<TR>
					<TD align="left"><asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" Font-Names="Verdana" Width="100%"
							AlternatingItemStyle-BackColor="#660033" HeaderStyle-BackColor="SteelBlue" Font-Size="X-Small" Font-Name="Verdana"
							CellPadding="3" BorderWidth="1px" BorderColor="Black" PagerStyle-HorizontalAlign="Right" AllowPaging="True">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle Wrap="False"></SelectedItemStyle>
							<EditItemStyle Wrap="False"></EditItemStyle>
							<AlternatingItemStyle Wrap="False" ForeColor="Black" BackColor="#E6E6E6"></AlternatingItemStyle>
							<ItemStyle Wrap="False" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="Small" Font-Bold="True" Wrap="False" ForeColor="White" BackColor="#880028"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="cnnVisitSerialNo" ReadOnly="True" HeaderText="άϵ��ˮ"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnCustID" ReadOnly="True" HeaderText="�ͻ�����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcName" ReadOnly="True" HeaderText="�ͻ�����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcChanceName" ReadOnly="True" HeaderText="��Ŀ����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcMgr" ReadOnly="True" HeaderText="��ҵ����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cndVisitDate" ReadOnly="True" HeaderText="�ݷ�����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcVisitContentComments" ReadOnly="True" HeaderText="�ݷ�����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcVisitDept" ReadOnly="True" HeaderText="�ݷò���"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcDeptTypeComments" ReadOnly="True" HeaderText="��������"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcFour" ReadOnly="True" HeaderText="�����˹���"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcVisitMan" ReadOnly="True" HeaderText="������"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcManTypeComments" ReadOnly="True" HeaderText="����������"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcAffectComments" ReadOnly="True" HeaderText="Ӱ����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcCustTypeComments" ReadOnly="True" HeaderText="�ͻ���Ӧ����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcWellTypeComments" ReadOnly="True" HeaderText="�����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcCorpRelationComments" ReadOnly="True" HeaderText="��ҵ��ϵ�"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcPrivateRelationComments" ReadOnly="True" HeaderText="˽�˹�ϵ�"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcProjectSpeedComments" ReadOnly="True" HeaderText="��Ŀ��չ�׶�"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcDemandTypeComments" ReadOnly="True" HeaderText="�ͻ��������"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcComments" ReadOnly="True" HeaderText="��ע"></asp:BoundColumn>
								<asp:HyperLinkColumn Text="��ϸ��Ϣ" DataNavigateUrlField="cnnVisitSerialNo" DataNavigateUrlFormatString="wfmVisitAddMod.aspx?type=mod&amp;&amp;vid={0}"
									HeaderText="�鿴"></asp:HyperLinkColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<tr>
					<td>
						<p style="MARGIN-LEFT: 150px">
							<iframe src="../script/����Ӱ�����ر�ע������.htm" id="the_frame" width="800" height="100%" style="WIDTH: 750px; HEIGHT: 280px">
							</iframe>
						</p>
					</td>
				</tr>
			</TABLE>
		</FORM>
	</body>
</HTML>
