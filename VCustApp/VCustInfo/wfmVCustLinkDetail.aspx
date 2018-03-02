<%@ Page language="c#" Codebehind="wfmVCustLinkDetail.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.VCustInfo.wfmVCustLinkDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>wfmVCustLinkDetail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="../script/calendar.js"></script>
</HEAD>
	<body bgColor="#f2f8fb" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="5" width="95%" border="0" align="center">
				<TR>
					<TD style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033" align="center">客户联系人信息</TD>
				</TR>
			</TABLE>
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="95%" border="1" align="center">
				<TR>
					<TD align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 232px" align="right"><asp:label id="Label1" runat="server" Width="83px" Font-Size="10pt">客户编码：</asp:label></TD>
								<TD style="WIDTH: 124px"><asp:textbox id="txtCustID" runat="server" Width="176px"></asp:textbox></TD>
								<TD style="WIDTH: 128px" align="right"><asp:label id="Label2" runat="server" Font-Size="10pt" Width="83px">联系人ID：</asp:label></TD>
								<TD style="WIDTH: 187px"><asp:textbox id="txtLinkID" runat="server" Width="176px"></asp:textbox></TD>
								<TD style="WIDTH: 122px" align="right"></TD>
								<TD><FONT face="宋体"></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 232px" align="right"><asp:label id="Label20" runat="server" Width="60px" Font-Size="10pt">姓名：</asp:label></TD>
								<TD style="WIDTH: 124px"><asp:textbox id="txtLinkName" runat="server" Width="176px"></asp:textbox></TD>
								<TD style="WIDTH: 128px" align="right"><asp:label id="Label21" runat="server" Width="66px" Font-Size="10pt">性别：</asp:label></TD>
								<TD style="WIDTH: 187px"><asp:dropdownlist id="ddlLinkSex" runat="server" Width="176px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 122px" align="right"><asp:label id="Label12" runat="server" Width="59px" Font-Size="10pt">生日：</asp:label></TD>
								<TD><asp:textbox id="txtBirthday" runat="server" Width="176px" onfocus="calendar()"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 232px; HEIGHT: 15px" align="right"><asp:label id="Label19" runat="server" Width="60px" Font-Size="10pt">学历：</asp:label></TD>
								<TD style="WIDTH: 124px; HEIGHT: 15px"><asp:dropdownlist id="ddlLinkDegree" runat="server" Width="176px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 128px; HEIGHT: 15px" align="right"><asp:label id="Label22" runat="server" Width="80px" Font-Size="10pt">联系人属性：</asp:label></TD>
								<TD style="WIDTH: 187px; HEIGHT: 15px"><asp:dropdownlist id="ddlLinkType" runat="server" Width="176px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 122px; HEIGHT: 15px" align="right"></TD>
								<TD style="HEIGHT: 15px"><FONT face="宋体"></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 232px" align="right"><asp:label id="Label23" runat="server" Width="78px" Font-Size="10pt">部门名称：</asp:label></TD>
								<TD style="WIDTH: 124px">
									<asp:dropdownlist id="ddlDept" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 128px" align="right"><asp:label id="Label24" runat="server" Width="72px" Font-Size="10pt">部门属性：</asp:label></TD>
								<TD style="WIDTH: 187px"><asp:dropdownlist id="ddlLinkDeptType" runat="server" Width="176px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 122px" align="left"></TD>
								<TD><FONT face="宋体"></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 232px" align="right"><asp:label id="Label25" runat="server" Width="66px" Font-Size="10pt">职务：</asp:label></TD>
								<TD style="WIDTH: 124px"><asp:textbox id="txtLinkOfficer" runat="server" Width="176px"></asp:textbox></TD>
								<TD style="WIDTH: 128px" align="right"><asp:label id="Label26" runat="server" Width="70px" Font-Size="10pt">负责工作：</asp:label></TD>
								<TD style="WIDTH: 187px"><asp:textbox id="txtLinkWorkRange" runat="server" Width="176px"></asp:textbox></TD>
								<TD style="WIDTH: 122px" align="right"></TD>
								<TD><FONT face="宋体"></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 232px" align="right"><asp:label id="Label27" runat="server" Width="107px" Font-Size="10pt">联系电话(座机)：</asp:label></TD>
								<TD style="WIDTH: 124px"><asp:textbox id="txtLinkDeskPhone" runat="server" Width="176px"></asp:textbox></TD>
								<TD style="WIDTH: 128px" align="right"><asp:label id="Label28" runat="server" Width="116px" Font-Size="10pt">联系电话(手机)：</asp:label></TD>
								<TD style="WIDTH: 187px"><asp:textbox id="txtLinkMobilePhone" runat="server" Width="176px"></asp:textbox></TD>
								<TD style="WIDTH: 122px" align="right"><asp:label id="Label29" runat="server" Width="70px" Font-Size="10pt">Email：</asp:label></TD>
								<TD><FONT face="宋体"><asp:textbox id="txtEmail" runat="server" Width="176px"></asp:textbox></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 232px" align="right"><asp:label id="Label30" runat="server" Width="107px" Font-Size="10pt">爱好及性格：</asp:label></TD>
								<TD style="WIDTH: 308px" colSpan="2"><asp:textbox id="txtLove" runat="server" Width="304px"></asp:textbox></TD>
								<TD style="WIDTH: 187px" align="right"><asp:label id="Label32" runat="server" Width="82px" Font-Size="10pt">通讯地址：</asp:label></TD>
								<TD style="WIDTH: 122px" align="right" colSpan="2"><asp:textbox id="txtLinkAddress" runat="server" Width="294px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 200px" align="right"></TD>
								<TD style="WIDTH: 182px" align="center"></TD>
								<TD style="WIDTH: 128px" align="center"></TD>
								<TD style="WIDTH: 179px" align="center"></TD>
								<TD style="WIDTH: 132px" align="center"></TD>
								<TD style="WIDTH: 132px" align="center"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 200px" align="right"></TD>
								<TD style="WIDTH: 182px" align="center"></TD>
								<TD style="WIDTH: 128px" align="center"><asp:button id="btnMod" runat="server" Width="64px" Text="保存"></asp:button></TD>
								<TD style="WIDTH: 179px" align="center"><asp:button id="btnAdd" runat="server" Width="64px" Text="新增"></asp:button></TD>
								<TD style="WIDTH: 132px" align="center"><asp:button id="btnReturn" runat="server" Width="64px" Text="返回"></asp:button></TD>
								<TD style="WIDTH: 132px" align="center"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</FORM>
	</body>
</HTML>
