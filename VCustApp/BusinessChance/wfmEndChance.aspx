<%@ Page language="c#" Codebehind="wfmEndChance.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.BusinessChance.wfmEndChance" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmEndChance</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="../script/calendar.js"></script>
		<LINK href="../css/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table align="center">
				<tr>
					<td colspan="2">
						<asp:Label id="Label1" runat="server" style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033">�̻�ת��</asp:Label></td>
				</tr>
			</table>
			<table align="center">
				<tr>
					<td>
						<asp:Label id="Label5" runat="server">�ֹ�˾��</asp:Label></td>
					<td>
						<asp:DropDownList id="ddlDept" runat="server" AutoPostBack="True" Enabled="False"></asp:DropDownList>
						<asp:TextBox id="txtCustID" runat="server" Visible="False"></asp:TextBox>
						<asp:TextBox id="txtProjectID" runat="server" Visible="False"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label2" runat="server">�̻����ƣ�</asp:Label></td>
					<td>
						<asp:TextBox id="txtProjectName" runat="server" Enabled="False"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label3" runat="server">�̻����ͣ�</asp:Label></td>
					<td>
						<asp:DropDownList id="ddlChanceType" runat="server" AutoPostBack="True" Enabled="False"></asp:DropDownList>
						<asp:DropDownList id="ddlChanceType2" runat="server" Enabled="False"></asp:DropDownList></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label4" runat="server">�����ͻ���</asp:Label></td>
					<td>
						<asp:TextBox id="txtCustName" runat="server" Enabled="False"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label7" runat="server">�̻�ʱ�䣺</asp:Label></td>
					<td>
						<asp:TextBox id="txtChanceDate" runat="server" onfocus="calendar()" Enabled="False"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label6" runat="server">Ԥ�����루��Ԫ����</asp:Label></td>
					<td>
						<asp:TextBox id="txtForecastIncome" runat="server" Enabled="False"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label8" runat="server">�̻���չ��</asp:Label></td>
					<td>
						<asp:DropDownList id="ddlChanceSpeed" runat="server" Enabled="False"></asp:DropDownList></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label9" runat="server">�ͻ�����</asp:Label></td>
					<td>
						<asp:DropDownList id="ddlMgr" runat="server" Enabled="False"></asp:DropDownList></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label12" runat="server">��ҵ����</asp:Label></td>
					<td>
						<asp:DropDownList id="ddlTradeMgr" runat="server" Enabled="False"></asp:DropDownList></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label10" runat="server">�̻�������</asp:Label></td>
					<td>
						<asp:TextBox id="txtComments" runat="server" TextMode="MultiLine" Width="240px" Height="128px"
							Enabled="False"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="2" align="center">
						<asp:Label id="Label11" runat="server" CssClass="title">ת������</asp:Label></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label15" runat="server">��ͬ��ţ�</asp:Label></td>
					<td>
						<asp:TextBox id="txtContractNo" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label16" runat="server">��Ŀ���ƣ�</asp:Label></td>
					<td>
						<asp:TextBox id="txtProjectName2" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label13" runat="server">ת��ʱ�䣺</asp:Label></td>
					<td>
						<asp:TextBox id="txtSucessDate" runat="server" onfocus="calendar()"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label14" runat="server">ת�����룺</asp:Label></td>
					<td>
						<asp:TextBox id="txtSucessIncome" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="2" align="center">
						<asp:Button id="btnOK" runat="server" Text="����"></asp:Button>
						<asp:Button id="btnCancel" runat="server" Text="ȡ��"></asp:Button>
						<asp:Button id="btnReturn" runat="server" Text="����"></asp:Button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
