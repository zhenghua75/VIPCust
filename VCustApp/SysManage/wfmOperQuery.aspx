<%@ Page language="c#" Codebehind="wfmOperQuery.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.SysManage.wfmOperQuery" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>wfmOperQuery</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../css/style.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../script/calendar.js"></script>
</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%">
				<tr>
					<td vAlign="top" align="center">
						<table>
							<tr>
								<td style="FONT-SIZE: 12pt; FONT-WEIGHT: bold" align="center" colSpan="4">操作员维护</td>
							</tr>
							<tr>
								<td><asp:label id="lblOperID" runat="server">操作员ID：</asp:label></td>
								<td><asp:textbox id="txtOperID" runat="server"></asp:textbox></td>
								<td><asp:label id="lblOperName" runat="server">操作员姓名：</asp:label></td>
								<td><asp:textbox id="txtOperName" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td>
									<asp:Label id="Label4" runat="server">失效时间：</asp:Label></td>
								<td>
									<asp:TextBox id="txtInvalidDate" runat="server" onfocus="calendar()"></asp:TextBox></td>
								<td>
									<asp:Label id="Label1" runat="server">部门：</asp:Label></td>
								<td>
									<asp:DropDownList id="ddlDept" runat="server"></asp:DropDownList></td>
							</tr>
							<tr>
								<td align="center" colSpan="4"><asp:imagebutton id="btnOK" runat="server" ImageUrl="../Image/btnOk.gif"></asp:imagebutton><asp:imagebutton id="btnCancel" runat="server" ImageUrl="../Image/btnCancel.gif"></asp:imagebutton>
									<asp:ImageButton id="btnAdd" runat="server" ImageUrl="../image/btnAdd.gif"></asp:ImageButton></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td width="100%">
						<asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False" BorderColor="#3366CC"
							BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowPaging="True"
							Width="100%">
<FooterStyle ForeColor="#003399" BackColor="#99CCCC">
</FooterStyle>

<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999">
</SelectedItemStyle>

<ItemStyle ForeColor="#003399" BackColor="White">
</ItemStyle>

<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="cnvcOperID" HeaderText="操作员ID"></asp:BoundColumn>
<asp:BoundColumn DataField="cnvcOperName" HeaderText="操作员名称"></asp:BoundColumn>
<asp:BoundColumn DataField="cnvcDeptIDComments" HeaderText="部门"></asp:BoundColumn>
<asp:BoundColumn DataField="cnvcRoleCodeComments" HeaderText="职位"></asp:BoundColumn>
<asp:BoundColumn DataField="cnvcManagerComments" HeaderText="行业经理"></asp:BoundColumn>
<asp:BoundColumn DataField="cndCreateDate" HeaderText="创建时间" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
<asp:BoundColumn DataField="cndInvalidDate" HeaderText="失效时间" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
<asp:BoundColumn DataField="cnvcComments" HeaderText="描述"></asp:BoundColumn>
<asp:HyperLinkColumn Text="修改" Target="_self" DataNavigateUrlField="cnvcOperID" DataNavigateUrlFormatString="wfmModifyOper.aspx?cnvcOperID={0}" HeaderText="修改"></asp:HyperLinkColumn>
<asp:ButtonColumn Text="删除" HeaderText="删除" CommandName="Delete"></asp:ButtonColumn>
<asp:HyperLinkColumn Text="权限" Target="_self" DataNavigateUrlField="cnvcOperID" DataNavigateUrlFormatString="wfmAuthorization.aspx?cnvcOperID={0}" HeaderText="权限"></asp:HyperLinkColumn>
<asp:ButtonColumn Text="初始密码" ButtonType="PushButton" HeaderText="初始密码" CommandName="PWD"></asp:ButtonColumn>
</Columns>

<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages">
</PagerStyle>
						</asp:DataGrid></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
