<%@ Page language="c#" Codebehind="wfmChanceMenu.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.BusinessChance.wfmChanceMenu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmChanceMenu</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="1" cellPadding="1" width="146" border="0" align="left">
				<TR id="trChanceQuery" runat="server">
					<TD align="center" style="HEIGHT: 38px" background="../image/anniu.jpg"><A style="COLOR: #ffffff; FONT-SIZE: 12pt; TEXT-DECORATION: none" onclick="parent.right.location='wfmChanceQuery.aspx'"
							href="javascript:">商机维护</A></TD>
				</TR>
				<TR id="trChanceReport" runat="server">
					<TD align="center" style="HEIGHT: 38px" background="../image/anniu.jpg"><A style="COLOR: #ffffff; FONT-SIZE: 12pt; TEXT-DECORATION: none" onclick="parent.right.location='wfmChanceReport.aspx'"
							href="javascript:">商机统计</A></TD>
				</TR>
				<TR id="trSalesFunnel" runat="server">
					<TD align="center" style="HEIGHT: 38px" background="../image/anniu.jpg"><A style="COLOR: #ffffff; FONT-SIZE: 12pt; TEXT-DECORATION: none" onclick="parent.right.location='wfmSalesFunnel.aspx'"
							href="javascript:">销售漏斗</A></TD>
				</TR>				
			</TABLE>
		</form>
	</body>
</HTML>
