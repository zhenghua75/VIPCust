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
					<TD style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033" align="center">客户档案详细信息</TD>
				</TR>
			</TABLE>
			<table cellSpacing="0" cellPadding="0" width="95%" align="center" border="1">
				<tr>
					<td align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label3" runat="server" Font-Size="10pt" Width="73px">客户编号：</asp:label></TD>
								<TD style="WIDTH: 33px"><FONT face="宋体"><asp:textbox id="txtCustID" runat="server" Width="176px"></asp:textbox></FONT></TD>
								<TD style="WIDTH: 166px" align="right"><FONT face="宋体"><asp:label id="Label1" runat="server" Font-Size="10pt" Width="72px">客户名称：</asp:label></FONT></TD>
								<TD style="WIDTH: 195px"><FONT face="宋体"><asp:textbox id="txtCustName" runat="server" Width="176px"></asp:textbox></FONT></TD>
								<TD style="WIDTH: 167px" align="right"><asp:label id="Label6" runat="server" Font-Size="10pt" Width="71px" Visible="False" Enabled="False">客户类型：</asp:label></TD>
								<TD style="WIDTH: 215px"><FONT face="宋体"><asp:dropdownlist id="ddlCustType" runat="server" Width="176px" Visible="False" Enabled="False" AutoPostBack="False"></asp:dropdownlist></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label19" runat="server" Font-Size="10pt" Width="73px">客户电话：</asp:label></TD>
								<TD style="WIDTH: 33px"><FONT face="宋体"><asp:textbox id="txtPhone" runat="server" Width="176px"></asp:textbox></FONT></TD>
								<TD style="WIDTH: 166px" align="right"><FONT face="宋体"><asp:label id="Label20" runat="server" Font-Size="10pt" Width="85px">客户E邮箱：</asp:label></FONT></TD>
								<TD style="WIDTH: 195px"><FONT face="宋体"><asp:textbox id="txtEmail" runat="server" Width="176px"></asp:textbox></FONT></TD>
								<TD style="WIDTH: 167px" align="right"><asp:label id="Label21" runat="server" Font-Size="10pt" Width="71px">客户传真：</asp:label></TD>
								<TD style="WIDTH: 215px"><FONT face="宋体"><asp:textbox id="txtFax" runat="server" Width="176px"></asp:textbox></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label7" runat="server" Font-Size="10pt" Width="69px">客户地址：</asp:label></TD>
								<TD style="WIDTH: 576px" colSpan="3"><asp:textbox id="txtAddress" runat="server" Width="490px"></asp:textbox></TD>
								<TD style="WIDTH: 167px" align="right"><asp:label id="Label22" runat="server" Font-Size="10pt" Width="72px">客户邮编：</asp:label></TD>
								<TD style="WIDTH: 215px"><asp:textbox id="txtPost" runat="server" Width="176px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px; HEIGHT: 23px" align="right"><asp:label id="Label5" runat="server" Font-Size="10pt" Width="69px">一级行业：</asp:label></TD>
								<TD style="WIDTH: 33px; HEIGHT: 23px"><asp:dropdownlist id="ddlTrade1" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 166px; HEIGHT: 23px" align="right"><asp:label id="Label2" runat="server" Font-Size="10pt" Width="77px">二级行业：</asp:label></TD>
								<TD style="WIDTH: 195px; HEIGHT: 23px"><FONT face="宋体"><asp:dropdownlist id="ddlTrade2" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></FONT></TD>
								<td style="WIDTH: 167px; HEIGHT: 23px" align="right"><asp:label id="Label12" runat="server" Font-Size="10pt" Width="77px">三级行业：</asp:label></td>
								<TD style="WIDTH: 215px; HEIGHT: 23px"><asp:dropdownlist id="ddlTrade3" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label11" runat="server" Font-Size="10pt" Width="71px">公司名称：</asp:label></TD>
								<TD style="WIDTH: 33px"><asp:dropdownlist id="ddlAreaCode" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 166px" align="right"><asp:label id="Label25" runat="server" Font-Size="10pt" Width="71px">客户等级：</asp:label></TD>
								<TD style="WIDTH: 195px"><FONT face="宋体"><asp:dropdownlist id="ddlCustLevel" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></FONT></TD>
								<TD style="WIDTH: 167px" align="right"></TD>
								<TD style="WIDTH: 215px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label27" runat="server" Font-Size="10pt" Width="98px">支付能力：</asp:label></TD>
								<TD style="WIDTH: 33px"><asp:dropdownlist id="ddlPayAbility" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></TD>
								<td style="WIDTH: 166px" align="right"><asp:label id="Label28" runat="server" Font-Size="10pt" Width="93px">月通信使用费：</asp:label></td>
								<TD style="WIDTH: 195px"><asp:textbox id="txtMonthCons" runat="server" Width="120px"></asp:textbox><asp:label id="Label4" runat="server" Font-Size="10pt" Width="41px">万元</asp:label></TD>
								<td style="WIDTH: 167px" align="right"><asp:label id="Label29" runat="server" Font-Size="10pt" Width="104px">协议情况：</asp:label></td>
								<td style="WIDTH: 215px"><asp:dropdownlist id="ddlConferState" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></td>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label9" runat="server" Font-Size="10pt" Width="83px">相关部门1：</asp:label></TD>
								<TD style="WIDTH: 33px"><asp:textbox id="txtDept" runat="server" Width="176px"></asp:textbox></TD>
								<td style="WIDTH: 166px" align="right"><asp:label id="Label10" runat="server" Font-Size="10pt" Width="89px">部门属性1：</asp:label></td>
								<TD style="WIDTH: 195px"><asp:dropdownlist id="ddlDeptType" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></TD>
								<TD style="WIDTH: 167px" align="left"><FONT face="宋体"></FONT></TD>
								<TD style="WIDTH: 215px"><FONT face="宋体"></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label16" runat="server" Font-Size="10pt" Width="89px">相关部门2：</asp:label></TD>
								<TD style="WIDTH: 33px"><asp:textbox id="txtDept2" runat="server" Width="176px"></asp:textbox></TD>
								<td style="WIDTH: 166px" align="right"><asp:label id="Label17" runat="server" Font-Size="10pt" Width="88px">部门属性2：</asp:label></td>
								<TD style="WIDTH: 195px"><asp:dropdownlist id="ddlDeptType2" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></TD>
								<TD style="WIDTH: 167px" align="left"><FONT face="宋体"></FONT></TD>
								<TD style="WIDTH: 215px"><FONT face="宋体"></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label23" runat="server" Font-Size="10pt" Width="81px">相关部门3：</asp:label></TD>
								<TD style="WIDTH: 33px"><asp:textbox id="txtDept3" runat="server" Width="176px"></asp:textbox></TD>
								<td style="WIDTH: 166px" align="right"><asp:label id="Label24" runat="server" Font-Size="10pt" Width="88px">部门属性3：</asp:label></td>
								<TD style="WIDTH: 195px"><asp:dropdownlist id="ddlDeptType3" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></TD>
								<TD style="WIDTH: 167px" align="left"><FONT face="宋体"></FONT></TD>
								<TD style="WIDTH: 215px"><FONT face="宋体"></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label26" runat="server" Font-Size="10pt" Width="81px">相关部门4：</asp:label></TD>
								<TD style="WIDTH: 33px"><asp:textbox id="txtDept4" runat="server" Width="176px"></asp:textbox></TD>
								<td style="WIDTH: 166px" align="right"><asp:label id="Label30" runat="server" Font-Size="10pt" Width="88px">部门属性4：</asp:label></td>
								<TD style="WIDTH: 195px"><asp:dropdownlist id="ddlDeptType4" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></TD>
								<TD style="WIDTH: 167px" align="right">
									<asp:label id="Label18" runat="server" Width="79px" Font-Size="10pt">客户经理：</asp:label></TD>
								<TD style="WIDTH: 215px">
									<asp:dropdownlist id="ddlCustMana" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label31" runat="server" Font-Size="10pt" Width="89px">相关部门5：</asp:label></TD>
								<TD style="WIDTH: 33px"><asp:textbox id="txtDept5" runat="server" Width="176px"></asp:textbox></TD>
								<td style="WIDTH: 166px" align="right"><asp:label id="Label32" runat="server" Font-Size="10pt" Width="88px">部门属性5：</asp:label></td>
								<TD style="WIDTH: 195px"><asp:dropdownlist id="ddlDeptType5" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></TD>
								<TD style="WIDTH: 167px" align="right">
									<asp:label id="Label33" runat="server" Width="79px" Font-Size="10pt">行业经理：</asp:label></TD>
								<TD style="WIDTH: 215px">
									<asp:dropdownlist id="ddlCustTradeMana" runat="server" Width="176px" AutoPostBack="False"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label8" runat="server" Font-Size="10pt" Width="69px">单位介绍：</asp:label></TD>
								<TD style="WIDTH: 975px" colSpan="5"><asp:textbox id="txtCompanyInstruction" runat="server" Width="800px" Height="56px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label13" runat="server" Font-Size="10pt" Width="105px">信息化实施情况：</asp:label></TD>
								<TD style="WIDTH: 975px" colSpan="5"><asp:textbox id="txtInfoDoneState" runat="server" Width="800px" Height="56px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label14" runat="server" Font-Size="10pt" Width="85px">使用竞争对手产品情况：</asp:label></TD>
								<TD style="WIDTH: 975px" colSpan="5"><asp:textbox id="txtCompetitorState" runat="server" Width="800px" Height="56px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"><asp:label id="Label15" runat="server" Font-Size="10pt" Width="107px">信息化建设计划：</asp:label></TD>
								<TD style="WIDTH: 975px" colSpan="5"><asp:textbox id="txtInfoPlan" runat="server" Width="800px" Height="56px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"></TD>
								<TD style="WIDTH: 33px"></TD>
								<TD style="WIDTH: 166px" align="right"></TD>
								<TD style="WIDTH: 195px"><FONT face="宋体"></FONT></TD>
								<TD style="WIDTH: 167px"></TD>
								<TD style="WIDTH: 215px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px" align="right"></TD>
								<TD style="WIDTH: 33px" align="center"><asp:button id="btnMod" runat="server" Width="64px" Text="保存"></asp:button></TD>
								<TD style="WIDTH: 166px" align="center"><asp:button id="btnAdd" runat="server" Width="64px" Text="新增"></asp:button></TD>
								<TD style="WIDTH: 195px" align="center">
									<asp:button id="btnAddNewLink" runat="server" Width="85px" Text="添加联系人"></asp:button></TD>
								<TD style="WIDTH: 167px" align="center"><asp:button id="Button1" runat="server" Width="64px" Text="返回"></asp:button></TD>
								<TD style="WIDTH: 215px" align="center"></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
		</FORM>
	</body>
</HTML>
