<%@ Page language="c#" Codebehind="wfmVisitAddMod.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.VCustInfo.wfmVisitAddMod" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmVisitAddMod</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="../script/calendar.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#f2f8fb">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="5" width="95%" border="0" align="center">
				<TR>
					<TD style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033" align="center">�ͻ���ϵάϵ��¼��ϸ��Ϣ</TD>
				</TR>
			</TABLE>
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="95%" border="1" align="center">
				<TR>
					<TD align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 237px" align="right"><asp:label id="Label1" runat="server" Width="83px" Font-Size="10pt">�ͻ����룺</asp:label></TD>
								<TD style="WIDTH: 158px"><asp:textbox id="txtCustID" runat="server" Width="176px"></asp:textbox></TD>
								<TD style="WIDTH: 302px" align="right">
									<asp:label id="Label10" runat="server" Font-Size="10pt" Width="83px">�ݷ���ˮ��</asp:label></TD>
								<TD style="WIDTH: 187px">
									<asp:textbox id="txtVisitID" runat="server" Width="176px"></asp:textbox></TD>
								<TD style="WIDTH: 155px" align="right"></TD>
								<TD style="WIDTH: 297px"><FONT face="����"></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 237px" align="right">
									<asp:label id="Label2" runat="server" Width="83px" Font-Size="10pt">��Ŀ���ƣ�</asp:label></TD>
								<TD style="WIDTH: 158px">
									<asp:dropdownlist id="ddlProject" runat="server" Width="176px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 302px" align="right">
									<asp:label id="Label20" runat="server" Font-Size="10pt" Width="135px">��ҵ����/ҵ����</asp:label></TD>
								<TD style="WIDTH: 187px">
									<asp:textbox id="txtMgr" runat="server" Width="176px"></asp:textbox></TD>
								<TD style="WIDTH: 155px" align="right">
									<asp:label id="Label12" runat="server" Font-Size="10pt" Width="88px" Visible="False">�ݷ����ڣ�</asp:label></TD>
								<TD style="WIDTH: 297px">
									<asp:label id="lblVisitDate" runat="server" Font-Size="12pt" Width="176px" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 237px" align="right">
									<asp:label id="Label19" runat="server" Font-Size="10pt" Width="94px">�ݷ����ݷ��ࣺ</asp:label></TD>
								<TD style="WIDTH: 158px">
									<asp:dropdownlist id="ddlConType" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 302px" align="right">
									<asp:label id="Label22" runat="server" Font-Size="10pt" Width="80px">�ݷ����ݣ�</asp:label></TD>
								<TD style="WIDTH: 187px">
									<asp:dropdownlist id="ddlVisitContent" runat="server" Width="176px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 155px" align="right"><asp:label id="Label29" runat="server" Width="70px" Font-Size="10pt">����ȣ�</asp:label></TD>
								<TD style="WIDTH: 297px"><FONT face="����">
										<asp:dropdownlist id="ddlWellType" runat="server" Width="208px"></asp:dropdownlist></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 237px; HEIGHT: 25px" align="right">
									<asp:label id="Label3" runat="server" Font-Size="10pt" Width="78px">�����ˣ�</asp:label></TD>
								<TD style="WIDTH: 158px; HEIGHT: 25px">
									<asp:dropdownlist id="ddlVisitMan" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 302px; HEIGHT: 25px" align="right"><asp:label id="Label4" runat="server" Font-Size="10pt" Width="97px">���������ԣ�</asp:label></TD>
								<TD style="WIDTH: 187px; HEIGHT: 25px">
									<asp:dropdownlist id="ddlManType" runat="server" Width="176px"></asp:dropdownlist>
								<TD style="WIDTH: 155px; HEIGHT: 25px" align="right" rowspan="5">
									<asp:label id="Label8" runat="server" Font-Size="10pt" Width="64px">��ע��</asp:label></TD>
								<TD style="WIDTH: 297px; HEIGHT: 25px" rowspan="5">
									<asp:textbox id="txtComments" runat="server" Width="212px" TextMode="MultiLine" Height="117px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 237px; HEIGHT: 25px" align="right">
									<asp:label id="Label23" runat="server" Font-Size="10pt" Width="78px">�ݷò��ţ�</asp:label></TD>
								<TD style="WIDTH: 158px; HEIGHT: 25px">
									<asp:textbox id="txtVisitDept" runat="server" Width="176px"></asp:textbox></TD>
								<TD style="WIDTH: 302px; HEIGHT: 25px" align="right">
									<asp:label id="Label24" runat="server" Font-Size="10pt" Width="103px">�����˹�����</asp:label></TD>
								<TD style="WIDTH: 187px; HEIGHT: 25px">
									<asp:dropdownlist id="ddlDeptType" runat="server" Width="176px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 237px; HEIGHT: 25px" align="right"><asp:label id="Label27" runat="server" Width="107px" Font-Size="10pt">Ӱ������</asp:label></TD>
								<TD style="WIDTH: 158px; HEIGHT: 25px">
									<asp:dropdownlist id="ddlAffect" runat="server" Width="176px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 302px; HEIGHT: 25px" align="right"><asp:label id="Label28" runat="server" Width="104px" Font-Size="10pt">�ͻ���Ӧ���ͣ�</asp:label></TD>
								<TD style="WIDTH: 187px; HEIGHT: 25px">
									<asp:dropdownlist id="ddlCustType" runat="server" Width="176px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 237px" align="right"><asp:label id="Label5" runat="server" Width="107px" Font-Size="10pt">��ҵ��ϵ���</asp:label></TD>
								<TD style="WIDTH: 158px">
									<asp:dropdownlist id="ddlCorpRelation" runat="server" Width="176px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 302px" align="right"><asp:label id="Label6" runat="server" Width="93px" Font-Size="10pt">˽�˹�ϵ���</asp:label></TD>
								<TD style="WIDTH: 187px">
									<asp:dropdownlist id="ddlPrivateRelation" runat="server" Width="176px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 237px" align="right">
									<asp:label id="Label7" runat="server" Font-Size="10pt" Width="97px">��Ŀ��չ�׶Σ�</asp:label></TD>
								<TD style="WIDTH: 158px">
									<asp:dropdownlist id="ddlProjectSpeed" runat="server" Width="176px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 302px" align="right">
									<asp:label id="Label9" runat="server" Font-Size="10pt" Width="93px">�ͻ����������</asp:label></TD>
								<TD style="WIDTH: 187px">
									<asp:dropdownlist id="ddlDemandType" runat="server" Width="176px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 237px" align="right"></TD>
								<TD style="WIDTH: 158px" align="center"></TD>
								<TD style="WIDTH: 302px" align="center"></TD>
								<TD style="WIDTH: 179px" align="center"></TD>
								<TD style="WIDTH: 155px" align="center"></TD>
								<TD style="WIDTH: 297px" align="center"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 237px" align="right"></TD>
								<TD style="WIDTH: 158px" align="center"></TD>
								<TD style="WIDTH: 302px" align="center"><asp:button id="btnMod" runat="server" Width="64px" Text="����"></asp:button></TD>
								<TD style="WIDTH: 179px" align="center"><asp:button id="btnAdd" runat="server" Width="64px" Text="����"></asp:button></TD>
								<TD style="WIDTH: 155px" align="center"><asp:button id="btnReturn" runat="server" Width="64px" Text="����"></asp:button></TD>
								<TD style="WIDTH: 296px" align="center"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</FORM>
	</body>
</HTML>
