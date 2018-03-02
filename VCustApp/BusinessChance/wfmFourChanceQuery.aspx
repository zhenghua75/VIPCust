<%@ Page language="c#" Codebehind="wfmFourChanceQuery.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.BusinessChance.wfmFourChanceQuery" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmChanceQuery</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table align="center">
				<tr>
					<td colSpan="2"><asp:label id="Label1" style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033" runat="server"
							Height="52">����Ӱ�����ر�</asp:label></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="1">
				<tr>
					<td><asp:label id="Label5" runat="server" CssClass="lable">�ֹ�˾��</asp:label></td>
					<td><asp:dropdownlist id="ddlDept" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
					<td><asp:label id="Label2" runat="server" CssClass="lable">�̻����ƣ�</asp:label></td>
					<td><asp:textbox id="txtProjectName" runat="server" CssClass="textbox"></asp:textbox></td>
					<td><asp:label id="Label3" runat="server" CssClass="lable">�̻����ͣ�</asp:label></td>
					<td><asp:dropdownlist id="ddlChanceType" runat="server" AutoPostBack="True"></asp:dropdownlist><br>
						<asp:dropdownlist id="ddlChanceType2" runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td><asp:label id="Label4" runat="server" CssClass="lable">�ͻ����ƣ�</asp:label></td>
					<td><asp:textbox id="txtCustName" runat="server" CssClass="textbox"></asp:textbox></td>
					<td><asp:label id="Label6" runat="server" CssClass="lable">�̻�Ԥ�����루��Ԫ����</asp:label></td>
					<td><asp:textbox id="txtForecaseIncome" runat="server" CssClass="textbox"></asp:textbox></td>
					<td><asp:label id="Label9" runat="server" CssClass="lable">�ͻ�����</asp:label></td>
					<td><asp:dropdownlist id="ddlMgr" runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td><asp:label id="Label7" runat="server" CssClass="lable">��ҵ����</asp:label></td>
					<td><asp:dropdownlist id="ddlTradeMgr" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
					<td><asp:label id="Label8" runat="server" CssClass="lable">�̻���չ��</asp:label></td>
					<td><asp:dropdownlist id="ddlChanceSpeed" runat="server"></asp:dropdownlist></td>
					<td align="center" colSpan="2"><asp:imagebutton id="btnOK" runat="server" ImageUrl="../image/btnOk.gif"></asp:imagebutton><asp:imagebutton id="btnCancel" runat="server" ImageUrl="../image/btnCancel.gif"></asp:imagebutton></td>
				</tr>
			</table>
			<table align="left" width="1600">
				<tr>
					<td align="left"><asp:datagrid id="DataGrid1" runat="server" Font-Size="X-Small" PageSize="15" AllowPaging="True"
							PagerStyle-HorizontalAlign="Right" BorderColor="Black" BorderWidth="1px" CellPadding="3" Font-Name="Verdana"
							HeaderStyle-BackColor="SteelBlue" AlternatingItemStyle-BackColor="#660033" Font-Names="Verdana" AutoGenerateColumns="False">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle Wrap="False"></SelectedItemStyle>
							<EditItemStyle Wrap="False"></EditItemStyle>
							<AlternatingItemStyle Wrap="False" ForeColor="Black" BackColor="#E6E6E6"></AlternatingItemStyle>
							<ItemStyle Wrap="False" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="Small" Font-Bold="True" Wrap="False" ForeColor="White" BackColor="#880028"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cnvcDeptIDComments" HeaderText="�ֹ�˾">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="cnnProjectID" HeaderText="��ĿID">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcChanceName" HeaderText="�̻�����">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcCustName" HeaderText="�ͻ�����">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcCustomTradeMgr" HeaderText="�ͻ�����/��ҵ����">
								<ItemStyle Width="90px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcChanceSpeedComments" HeaderText="�̻���չ">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcChanceTypeComments" HeaderText="�̻�����">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnnForecastIncome" HeaderText="Ԥ������">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cndChanceDate" HeaderText="�̻�ʱ��" DataFormatString="{0:yyyy��MM��dd��}">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:HyperLinkColumn Text="����Ӱ�����ر�" DataNavigateUrlField="cnnProjectID" DataNavigateUrlFormatString="wfmFour.aspx?cnnProjectID={0}"
									HeaderText="����Ӱ�����ر�">
									<ItemStyle Width="70px"></ItemStyle>
									</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="cnvcIsSucessComments" HeaderText="��ת��">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnnSucessIncome" HeaderText="ת������">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cndSucessDate" HeaderText="ת��ʱ��" DataFormatString="{0:yyyy��MM��dd��}">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcProjectStateComments" HeaderText="�̻�״̬">
								<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
