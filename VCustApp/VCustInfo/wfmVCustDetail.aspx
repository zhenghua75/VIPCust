<%@ Page language="c#" Codebehind="wfmVCustDetail.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.VCustInfo.wfmVCustDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmVCustDetail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#f2f8fb" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="5" width="95%" align="center" border="0">
				<TR>
					<TD style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033" align="center">�ͻ�������ϸ��Ϣ</TD>
				</TR>
			</TABLE>
			<table cellSpacing="0" cellPadding="0" width="95%" align="center" border="1">
				<tr>
					<td align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label3" runat="server" Font-Size="10pt" Width="73px">�ͻ���ţ�</asp:label></TD>
								<TD style="WIDTH: 33px"><FONT face="����"><asp:textbox id="txtCustID" runat="server" Width="176px"></asp:textbox></FONT></TD>
								<TD style="WIDTH: 166px" align="right"><FONT face="����"><asp:label id="Label1" runat="server" Font-Size="10pt" Width="72px">�ͻ����ƣ�</asp:label></FONT></TD>
								<TD style="WIDTH: 195px"><FONT face="����"><asp:textbox id="txtCustName" runat="server" Width="176px"></asp:textbox></FONT></TD>
								<TD style="WIDTH: 167px" align="right"><asp:label id="Label6" runat="server" Font-Size="10pt" Width="71px" Visible="False" Enabled="False">�ͻ����ͣ�</asp:label></TD>
								<TD style="WIDTH: 215px"><FONT face="����"><asp:dropdownlist id="ddlCustType" runat="server" Width="176px" Visible="False" Enabled="False" AutoPostBack="False"></asp:dropdownlist></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label19" runat="server" Font-Size="10pt" Width="73px">�ͻ��绰��</asp:label></TD>
								<TD style="WIDTH: 33px"><FONT face="����"><asp:textbox id="txtPhone" runat="server" Width="176px"></asp:textbox></FONT></TD>
								<TD style="WIDTH: 166px" align="right"><FONT face="����"><asp:label id="Label20" runat="server" Font-Size="10pt" Width="85px">�ͻ�E���䣺</asp:label></FONT></TD>
								<TD style="WIDTH: 195px"><FONT face="����"><asp:textbox id="txtEmail" runat="server" Width="176px"></asp:textbox></FONT></TD>
								<TD style="WIDTH: 167px" align="right"><asp:label id="Label21" runat="server" Font-Size="10pt" Width="71px">�ͻ����棺</asp:label></TD>
								<TD style="WIDTH: 215px"><FONT face="����"><asp:textbox id="txtFax" runat="server" Width="176px"></asp:textbox></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label7" runat="server" Font-Size="10pt" Width="69px">�ͻ���ַ��</asp:label></TD>
								<TD style="WIDTH: 576px" colSpan="3"><asp:textbox id="txtAddress" runat="server" Width="490px"></asp:textbox></TD>
								<TD style="WIDTH: 167px" align="right"><asp:label id="Label22" runat="server" Font-Size="10pt" Width="72px">�ͻ��ʱࣺ</asp:label></TD>
								<TD style="WIDTH: 215px"><asp:textbox id="txtPost" runat="server" Width="176px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px; HEIGHT: 23px" align="right"><asp:label id="Label5" runat="server" Font-Size="10pt" Width="69px">һ����ҵ��</asp:label></TD>
								<TD style="WIDTH: 33px; HEIGHT: 23px"><asp:dropdownlist id="ddlTrade1" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 166px; HEIGHT: 23px" align="right"><asp:label id="Label2" runat="server" Font-Size="10pt" Width="77px">������ҵ��</asp:label></TD>
								<TD style="WIDTH: 195px; HEIGHT: 23px"><FONT face="����"><asp:dropdownlist id="ddlTrade2" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></FONT></TD>
								<td style="WIDTH: 167px; HEIGHT: 23px" align="right"><asp:label id="Label12" runat="server" Font-Size="10pt" Width="77px">������ҵ��</asp:label></td>
								<TD style="WIDTH: 215px; HEIGHT: 23px"><asp:dropdownlist id="ddlTrade3" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label11" runat="server" Font-Size="10pt" Width="71px">��˾���ƣ�</asp:label></TD>
								<TD style="WIDTH: 33px"><asp:dropdownlist id="ddlAreaCode" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 166px" align="right"><asp:label id="Label25" runat="server" Font-Size="10pt" Width="71px">�ͻ��ȼ���</asp:label></TD>
								<TD style="WIDTH: 195px"><FONT face="����"><asp:dropdownlist id="ddlCustLevel" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></FONT></TD>
								<TD style="WIDTH: 167px" align="right"></TD>
								<TD style="WIDTH: 215px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label27" runat="server" Font-Size="10pt" Width="98px">֧��������</asp:label></TD>
								<TD style="WIDTH: 33px"><asp:dropdownlist id="ddlPayAbility" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></TD>
								<td style="WIDTH: 166px" align="right"><asp:label id="Label28" runat="server" Font-Size="10pt" Width="93px">��ͨ��ʹ�÷ѣ�</asp:label></td>
								<TD style="WIDTH: 195px"><asp:textbox id="txtMonthCons" runat="server" Width="120px"></asp:textbox><asp:label id="Label4" runat="server" Font-Size="10pt" Width="41px">��Ԫ</asp:label></TD>
								<td style="WIDTH: 167px" align="right"><asp:label id="Label29" runat="server" Font-Size="10pt" Width="104px">Э�������</asp:label></td>
								<td style="WIDTH: 215px"><asp:dropdownlist id="ddlConferState" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></td>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label9" runat="server" Font-Size="10pt" Width="83px">��ز���1��</asp:label></TD>
								<TD style="WIDTH: 33px"><asp:textbox id="txtDept" runat="server" Width="176px"></asp:textbox></TD>
								<td style="WIDTH: 166px" align="right"><asp:label id="Label10" runat="server" Font-Size="10pt" Width="89px">��������1��</asp:label></td>
								<TD style="WIDTH: 195px"><asp:dropdownlist id="ddlDeptType" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></TD>
								<TD style="WIDTH: 167px" align="left"><FONT face="����"></FONT></TD>
								<TD style="WIDTH: 215px"><FONT face="����"></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label16" runat="server" Font-Size="10pt" Width="89px">��ز���2��</asp:label></TD>
								<TD style="WIDTH: 33px"><asp:textbox id="txtDept2" runat="server" Width="176px"></asp:textbox></TD>
								<td style="WIDTH: 166px" align="right"><asp:label id="Label17" runat="server" Font-Size="10pt" Width="88px">��������2��</asp:label></td>
								<TD style="WIDTH: 195px"><asp:dropdownlist id="ddlDeptType2" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></TD>
								<TD style="WIDTH: 167px" align="left"><FONT face="����"></FONT></TD>
								<TD style="WIDTH: 215px"><FONT face="����"></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label23" runat="server" Font-Size="10pt" Width="81px">��ز���3��</asp:label></TD>
								<TD style="WIDTH: 33px"><asp:textbox id="txtDept3" runat="server" Width="176px"></asp:textbox></TD>
								<td style="WIDTH: 166px" align="right"><asp:label id="Label24" runat="server" Font-Size="10pt" Width="88px">��������3��</asp:label></td>
								<TD style="WIDTH: 195px"><asp:dropdownlist id="ddlDeptType3" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></TD>
								<TD style="WIDTH: 167px" align="left"><FONT face="����"></FONT></TD>
								<TD style="WIDTH: 215px"><FONT face="����"></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label26" runat="server" Font-Size="10pt" Width="81px">��ز���4��</asp:label></TD>
								<TD style="WIDTH: 33px"><asp:textbox id="txtDept4" runat="server" Width="176px"></asp:textbox></TD>
								<td style="WIDTH: 166px" align="right"><asp:label id="Label30" runat="server" Font-Size="10pt" Width="88px">��������4��</asp:label></td>
								<TD style="WIDTH: 195px"><asp:dropdownlist id="ddlDeptType4" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></TD>
								<TD style="WIDTH: 167px" align="right">
									<asp:label id="Label18" runat="server" Width="79px" Font-Size="10pt">�ͻ�����</asp:label></TD>
								<TD style="WIDTH: 215px">
									<asp:dropdownlist id="ddlCustMana" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label31" runat="server" Font-Size="10pt" Width="89px">��ز���5��</asp:label></TD>
								<TD style="WIDTH: 33px"><asp:textbox id="txtDept5" runat="server" Width="176px"></asp:textbox></TD>
								<td style="WIDTH: 166px" align="right"><asp:label id="Label32" runat="server" Font-Size="10pt" Width="88px">��������5��</asp:label></td>
								<TD style="WIDTH: 195px"><asp:dropdownlist id="ddlDeptType5" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></TD>
								<TD style="WIDTH: 167px" align="right">
									<asp:label id="Label33" runat="server" Width="79px" Font-Size="10pt">��ҵ����</asp:label></TD>
								<TD style="WIDTH: 215px">
									<asp:dropdownlist id="ddlCustTradeMana" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label8" runat="server" Font-Size="10pt" Width="69px">��λ���ܣ�</asp:label></TD>
								<TD style="WIDTH: 975px" colSpan="5"><asp:textbox id="txtCompanyInstruction" runat="server" Width="800px" Height="56px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label13" runat="server" Font-Size="10pt" Width="105px">��Ϣ��ʵʩ�����</asp:label></TD>
								<TD style="WIDTH: 975px" colSpan="5"><asp:textbox id="txtInfoDoneState" runat="server" Width="800px" Height="56px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label14" runat="server" Font-Size="10pt" Width="85px">ʹ�þ������ֲ�Ʒ�����</asp:label></TD>
								<TD style="WIDTH: 975px" colSpan="5"><asp:textbox id="txtCompetitorState" runat="server" Width="800px" Height="56px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label15" runat="server" Font-Size="10pt" Width="107px">��Ϣ������ƻ���</asp:label></TD>
								<TD style="WIDTH: 975px" colSpan="5"><asp:textbox id="txtInfoPlan" runat="server" Width="800px" Height="56px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"></TD>
								<TD style="WIDTH: 33px"></TD>
								<TD style="WIDTH: 166px" align="right"></TD>
								<TD style="WIDTH: 195px"><FONT face="����"></FONT></TD>
								<TD style="WIDTH: 167px"></TD>
								<TD style="WIDTH: 215px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"></TD>
								<TD style="WIDTH: 33px" align="center"><asp:button id="btnMod" runat="server" Width="64px" Text="����"></asp:button></TD>
								<TD style="WIDTH: 166px" align="center"><asp:button id="btnAdd" runat="server" Width="64px" Text="����"></asp:button></TD>
								<TD style="WIDTH: 195px" align="center">
									<asp:button id="btnAddNewLink" runat="server" Width="85px" Text="�����ϵ��"></asp:button></TD>
								<TD style="WIDTH: 167px" align="center"><asp:button id="Button1" runat="server" Width="64px" Text="����"></asp:button></TD>
								<TD style="WIDTH: 215px" align="center"></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
		</FORM>
	</body>
</HTML>
