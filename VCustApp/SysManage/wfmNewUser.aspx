<%@ Page language="c#" Codebehind="wfmNewUser.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.SysManage.wfmNewUser" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmNewUser</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="../css/style.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../script/calendar.js"></script>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table height="100%" width="100%">
				<tr>
					<td vAlign="top" align="center">
						<table>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 12pt" align="center" colSpan="2">新建操作员</td>
							</tr>
							<tr>
								<td><asp:label id="lblOperID" runat="server">操作员ID：</asp:label></td>
								<td><asp:textbox id="txtOperID" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td><asp:label id="lblOperName" runat="server">操作员姓名：</asp:label></td>
								<td><asp:textbox id="txtOperName" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td>
									<asp:Label id="Label2" runat="server">密码：</asp:Label></td>
								<td>
									<asp:TextBox id="txtPwd" runat="server" TextMode="Password"></asp:TextBox></td>
							</tr>
							<tr>
								<td>
									<asp:Label id="Label3" runat="server">密码确认：</asp:Label></td>
								<td>
									<asp:TextBox id="txtPwdConfirm" runat="server" TextMode="Password"></asp:TextBox></td>
							</tr>
							<tr>
								<td>
									<asp:Label id="Label4" runat="server">失效时间：</asp:Label></td>
								<td>
									<asp:TextBox id="txtInvalidDate" runat="server" onfocus="calendar()"></asp:TextBox></td>
							</tr>
							<tr>
								<td>
									<asp:Label id="Label1" runat="server">部门：</asp:Label></td>
								<td>
									<asp:DropDownList id="ddlDept" runat="server" AutoPostBack="True"></asp:DropDownList></td>
							</tr>
							<tr>
								<td>
									<asp:Label id="Label6" runat="server">职位：</asp:Label></td>
								<td>
									<asp:DropDownList id="ddlRoleCode" runat="server" AutoPostBack="True"></asp:DropDownList></td>
							</tr>
							<tr>
								<td>
									<asp:Label id="Label7" runat="server">行业经理：</asp:Label></td>
								<td>
									<asp:DropDownList id="ddlManager" runat="server"></asp:DropDownList></td>
							</tr>
							<tr>
								<td style="HEIGHT: 52px">
									<asp:Label id="Label5" runat="server">描述：</asp:Label></td>
								<td style="HEIGHT: 52px">
									<asp:TextBox id="txtComments" runat="server" TextMode="MultiLine"></asp:TextBox></td>
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
