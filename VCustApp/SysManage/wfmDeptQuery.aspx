<%@ Page language="c#" Codebehind="wfmDeptQuery.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.SysManage.wfmDeptQuery" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>wfmDeptQuery</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/style.css" type="text/css" rel="stylesheet">
		<LINK href="../DataGrid.css" type="text/css" rel="stylesheet">
		<script language="javascript" src='../script/calendar.js"'></script>
</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%">
				<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 12pt" align="center" colSpan="4">����ά��</td>
				</tr>
				<tr>
					<td vAlign="top" align="center">					
						<table align="center">
							
							<tr>
								<td><asp:label id="lblOperID" runat="server">����ID��</asp:label></td>
								<td><asp:textbox id="txtDeptID" runat="server"></asp:textbox></td>
								<td><asp:label id="lblOperName" runat="server">�������ƣ�</asp:label></td>
								<td><asp:textbox id="txtDeptName" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td><asp:label id="Label2" runat="server">��������</asp:label></td>
								<td><asp:dropdownlist id="ddlAreaCode" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
								<td><asp:label id="Label1" runat="server">�ϼ����ţ�</asp:label></td>
								<td><asp:dropdownlist id="ddlDept" runat="server"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="center" colSpan="4"><asp:imagebutton id="btnOK" runat="server" ImageUrl="../Image/btnOk.gif"></asp:imagebutton><asp:imagebutton id="btnCancel" runat="server" ImageUrl="../Image/btnCancel.gif"></asp:imagebutton><asp:imagebutton id="btnAdd" runat="server" ImageUrl="../image/btnAdd.gif"></asp:imagebutton></td>
							</tr>
						</table>
						
					</td>
				</tr>
				<tr>
					<td vAlign="top"><asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" AllowPaging="True" BorderColor="#3366CC"
							BorderWidth="1px" BorderStyle="None" BackColor="White" CellPadding="4" width="100%">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cnvcDeptID" HeaderText="����ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcDeptName" HeaderText="��������"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcParentDeptIDComments" HeaderText="�ϼ�����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcAreaCodeComments" HeaderText="������"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcComments" HeaderText="����"></asp:BoundColumn>
								<asp:HyperLinkColumn Text="�޸�" Target="_self" DataNavigateUrlField="cnvcDeptID" DataNavigateUrlFormatString="wfmModifyDept.aspx?cnvcDeptID={0}" 
 HeaderText="�޸�"></asp:HyperLinkColumn>
								<asp:ButtonColumn Text="ɾ��" HeaderText="ɾ��" CommandName="Delete"></asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
