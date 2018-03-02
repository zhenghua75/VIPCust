<%@ Page language="c#" Codebehind="wfmPlanQuery.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.BusinessChance.wfmPlanQuery" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmPlanQuery</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../css/DataGrid.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table align="center">
				<tr>
					<td colspan="2">
						<asp:Label id="Label1" runat="server" CssClass="title">���ۼƻ�ά��</asp:Label></td>
				</tr>
			</table>
			<table align="center">
				<tr>
					<td>
						<asp:Label id="Label2" runat="server">���ۼƻ����ƣ�</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox1" runat="server"></asp:TextBox></td>				
					<td>
						<asp:Label id="Label3" runat="server">�������ڣ�</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox2" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label4" runat="server">�������ڣ�</asp:Label></td>
					<td>
						<asp:TextBox id="TextBox3" runat="server"></asp:TextBox></td>			
					<td>
						<asp:Label id="Label7" runat="server">����״̬��</asp:Label></td>
					<td>
						<asp:DropDownList id="DropDownList3" runat="server">
							<asp:ListItem Value="�ѷ���">�ѷ���</asp:ListItem>
							<asp:ListItem Value="δ����">δ����</asp:ListItem>
						</asp:DropDownList></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label5" runat="server">��ȡ״̬��</asp:Label></td>
					<td>
						<asp:DropDownList id="DropDownList1" runat="server">
							<asp:ListItem Value="������">������</asp:ListItem>
							<asp:ListItem Value="δ����">δ����</asp:ListItem>
						</asp:DropDownList></td>				
					<td>
						<asp:Label id="Label6" runat="server">��������</asp:Label></td>
					<td>
						<asp:DropDownList id="DropDownList2" runat="server">
							<asp:ListItem Value="�����">�����</asp:ListItem>
							<asp:ListItem Value="δ���">δ���</asp:ListItem>
						</asp:DropDownList></td>
				</tr>
				<tr>
					<td colspan="4" align="center">
						<asp:Button id="Button1" runat="server" Width="63px" Text="��ѯ"></asp:Button>
						<asp:Button id="Button2" runat="server" Width="61px" Text="ȡ��"></asp:Button>
						<asp:Button id="btnAddPlan" runat="server" Width="54px" Text="���"></asp:Button></td>
				</tr>
			</table>
			<table align="center" width="100%">
				<tr>
					<td align="center">
						<asp:DataGrid id="DataGrid1" runat="server" Font-Size="X-Small" Width="100%" PageSize="15" AllowPaging="True"
							PagerStyle-HorizontalAlign="Right" BorderColor="Black" BorderWidth="1px" CellPadding="3" Font-Name="Verdana"
							HeaderStyle-BackColor="SteelBlue" AlternatingItemStyle-BackColor="#660033" Font-Names="Verdana" AutoGenerateColumns="False">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle Wrap="False"></SelectedItemStyle>
							<EditItemStyle Wrap="False"></EditItemStyle>
							<AlternatingItemStyle Wrap="False" ForeColor="Black" BackColor="#E6E6E6"></AlternatingItemStyle>
							<ItemStyle Wrap="False" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="Small" Font-Bold="True" Wrap="False" ForeColor="White" BackColor="#880028"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cnvcPlanName" HeaderText="�ƻ�����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cndBeginDate" HeaderText="��������"></asp:BoundColumn>
								<asp:BoundColumn DataField="cndEndDate" HeaderText="��ֹ����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcPlanNeed" HeaderText="�ƻ�Ҫ��"></asp:BoundColumn>
								<asp:HyperLinkColumn Text="�޸�" DataNavigateUrlField="cnvcPlanName" DataNavigateUrlFormatString="wfmModifyPlan.aspx"
									HeaderText="�޸�"></asp:HyperLinkColumn>
								<asp:HyperLinkColumn Text="������Ա" DataNavigateUrlField="cnvcPlanName" DataNavigateUrlFormatString="wfmPlanMan.aspx"
									HeaderText="������Ա"></asp:HyperLinkColumn>
								<asp:ButtonColumn Text="����" HeaderText="����" CommandName="Select"></asp:ButtonColumn>
								<asp:ButtonColumn Text="����" HeaderText="��ȡ�ƻ�" CommandName="Select"></asp:ButtonColumn>
								<asp:ButtonColumn Text="���" HeaderText="��չ״̬" CommandName="Select"></asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
