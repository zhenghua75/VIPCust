<%@ Page language="c#" Codebehind="wfmModifyOper.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.SysManage.wfmModifyOper" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>wfmModifyOper</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="../script/calendar.js"></script>
		<script language="javascript" src="../script/datetime.js"></script>
		<LINK href="../css/style.css" type="text/css" rel="stylesheet">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table height="100%" width="100%">
				<tr>
					<td vAlign="top" align="center">
						<table>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 12pt" align="center" colSpan="2">�޸Ĳ���Ա</td>
							</tr>
							<tr>
								<td><asp:label id="lblOperID" runat="server">����ԱID��</asp:label></td>
								<td><asp:textbox id="txtOperID" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td><asp:label id="lblOperName" runat="server">����Ա������</asp:label></td>
								<td><asp:textbox id="txtOperName" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td><asp:label id="Label4" runat="server">ʧЧʱ�䣺</asp:label></td>
								<td><asp:textbox id="txtInvalidDate" onfocus="calendar()" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td><asp:label id="Label1" runat="server">���ţ�</asp:label></td>
								<td><asp:dropdownlist id="ddlDept" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td>
									<asp:Label id="Label6" runat="server">ְλ��</asp:Label></td>
								<td>
									<asp:DropDownList id="ddlRoleCode" runat="server" AutoPostBack="True"></asp:DropDownList></td>
							</tr>
							<tr>
								<td>
									<asp:Label id="Label7" runat="server">��ҵ����</asp:Label></td>
								<td>
									<asp:DropDownList id="ddlManager" runat="server"></asp:DropDownList></td>
							</tr>
							<tr>
								<td>
									<asp:Label id="Label2" runat="server">������</asp:Label></td>
								<td>
									<asp:TextBox id="txtComments" runat="server" TextMode="MultiLine" Width="135px" Height="50px"></asp:TextBox></td>
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
