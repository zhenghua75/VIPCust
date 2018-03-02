<%@ Page language="c#" Codebehind="wfmVCustMenu.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.VCustInfo.wfmVCustMenu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmVCustMenu</title>
		<meta name="vs_snapToGrid" content="False">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" background="image/coolwp2.jpg">
	  <form id="Form1" method="post" runat="server">
		<TABLE cellSpacing="1" cellPadding="1" width="146" border="0" align="left">
			<TR id="trnoprom" runat="server">
				<TD align="center" style="FONT-WEIGHT: bold; COLOR: #330033; HEIGHT: 38px" bgcolor="#ebf0ec">没有权限</TD>
			</TR>
			<TR id="trVCustInfo" runat="server">
				<TD align="center" style="HEIGHT: 38px" background="../image/anniu.jpg"><A style="FONT-SIZE: 12pt; COLOR: #ffffff; TEXT-DECORATION: none" onclick="parent.right.location='wfmVCustInfo.aspx'"
						href="javascript:">客户档案管理</A></TD>
			</TR>
			<TR id="trVisit" runat="server">
				<TD align="center" style="HEIGHT: 38px" background="../image/anniu.jpg"><A style="FONT-SIZE: 12pt; COLOR: #ffffff; TEXT-DECORATION: none" onclick="parent.right.location='wfmVisitInfo.aspx'"
						href="javascript:">客户拜访跟踪</A></TD>
			</TR>
			<TR id="trCustRelationReport1" runat="server">
				<TD align="center" style="HEIGHT: 38px" background="../image/anniu.jpg"><A style="FONT-SIZE: 12pt; COLOR: #ffffff; TEXT-DECORATION: none" onclick="parent.right.location='wfmCustRelationReport1.aspx'"
						href="javascript:">客户关系建立报表</A></TD>
			</TR>
			<TR id="trCustRelationReport2" runat="server">
				<TD align="center" style="HEIGHT: 38px" background="../image/anniu.jpg"><A style="FONT-SIZE: 12pt; COLOR: #ffffff; TEXT-DECORATION: none" onclick="parent.right.location='wfmCustRelationReport2.aspx'"
						href="javascript:">客户关系维护报表</A></TD>
			</TR>
			<TR id="trCustRelationDeepReport" runat="server">
				<TD align="center" style="HEIGHT: 38px" background="../image/anniu.jpg"><A style="FONT-SIZE: 12pt; COLOR: #ffffff; TEXT-DECORATION: none" onclick="parent.right.location='wfmCustRelationDeepReport.aspx'"
						href="javascript:">关系维深统计表</A></TD>
			</TR>			
		</TABLE>
		</form>
	</body>
</HTML>
