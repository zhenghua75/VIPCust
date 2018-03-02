<%@ Page language="c#" Codebehind="wfmModifyDept.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.SysManage.wfmModifyDept" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmModifyDept</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/style.css" type="text/css" rel="stylesheet">
		<script language="javascript" src='../script/calendar.js"'></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table height="100%" width="100%">
				<tr>
					<td vAlign="top" align="center">
						<table>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 12pt" align="center" colSpan="2">修改部门</td>
							</tr>
							<tr>
								<td><asp:label id="lblOperID" runat="server">部门ID：</asp:label></td>
								<td><asp:textbox id="txtDeptID" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td><asp:label id="lblOperName" runat="server">部门名称：</asp:label></td>
								<td><asp:textbox id="txtDeptName" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td><asp:label id="Label2" runat="server">本地网：</asp:label></td>
								<td><asp:dropdownlist id="ddlAreaCode" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td><asp:label id="Label1" runat="server">上级部门：</asp:label></td>
								<td><asp:dropdownlist id="ddlDept" runat="server"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td><asp:label id="Label4" runat="server">描述：</asp:label></td>
								<td><asp:textbox id="txtComments" runat="server" TextMode="MultiLine" Width="135px" Height="56px"></asp:textbox></td>
							</tr>
							<tr>
								<td align="center" colSpan="2"><asp:imagebutton id="btnOK" runat="server" ImageUrl="../Image/btnOk.gif"></asp:imagebutton><asp:imagebutton id="btnCancel" runat="server" ImageUrl="../Image/btnCancel.gif"></asp:imagebutton></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
