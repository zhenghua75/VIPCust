<%@ Page language="c#" Codebehind="wfmAddMan.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.BusinessChance.wfmAddMan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmAddMan</title>
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
						<asp:Label id="Label1" runat="server" CssClass="title">添加人员</asp:Label></td>
				</tr>
			</table>
			<table align="center" width="100%">
				<tr>
					<td align="center">
						<asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False" BorderColor="#CCCCCC"
							BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" Width="444px">
							<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
							<ItemStyle ForeColor="#000066"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cnvcName" HeaderText="姓名"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="任务纪要">
									<ItemTemplate>
										<asp:Label id=Label2 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cnvcTask") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox id=TextBox1 runat="server" Width="235px" Text='<%# DataBinder.Eval(Container, "DataItem.cnvcTask") %>' Height="95px" TextMode="MultiLine">
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="编辑"></asp:EditCommandColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
