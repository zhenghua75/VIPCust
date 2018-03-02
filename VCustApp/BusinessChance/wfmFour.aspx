<%@ Page language="c#" Codebehind="wfmFour.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.BusinessChance.wfmFour" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>wfmFour</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/style.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../script/calendar.js"></script>
		<script language="javascript" src="../script/scrol.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		
		<form id="Form1" method="post" runat="server">						
			<table align="center">
				<tr>
					<td colSpan="2"><asp:label id="Label1" style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033" runat="server">销售影响因素表</asp:label></td>
				</tr>
			</table>
			<table align="center">
				<tr>
					<td><asp:label id="Label5" runat="server">分公司：</asp:label></td>
					<td><asp:dropdownlist id="ddlDept" runat="server" Enabled="False"></asp:dropdownlist>
						<asp:TextBox id="txtProjectID" runat="server" Visible="False"></asp:TextBox></td>
					<td><asp:label id="Label3" runat="server">商机名称：</asp:label></td>
					<td><asp:textbox id="txtProjectName" runat="server" Enabled="False"></asp:textbox></td>
					<td><asp:label id="Label4" runat="server">客户名称：</asp:label></td>
					<td><asp:textbox id="txtCustName" runat="server" Enabled="False"></asp:textbox></td>
					<td><asp:label id="Label2" runat="server">客户经理：</asp:label></td>
					<td><asp:dropdownlist id="ddlOper" runat="server" Enabled="False"></asp:dropdownlist></td>
					<td><asp:label id="Label6" runat="server">行业经理：</asp:label></td>
					<td><asp:dropdownlist id="ddlTradeMgr" runat="server" Enabled="False"></asp:dropdownlist></td>
					<td>
						<asp:Button id="btnCance" runat="server" Width="64px" Text="返回"></asp:Button></td>
				</tr>
			</table>
			<table width="800" align="center">
				<TBODY>
					<tr>
						<td>
							<asp:Repeater id="Repeater1" runat="server">
								<HeaderTemplate>
									<table border="1" bordercolor="black" cellpadding="0" cellspacing="0" width="100%">
								</HeaderTemplate>
								<ItemTemplate>
									<tr>
										<td valign="top">
											<!--<img src="../image/<%# DataBinder.Eval(Container.DataItem, "cnvcImage1") %>" style="padding: 3px; float: right;" align=right>-->
											<b style="FONT-WEIGHT: bold; FONT-SIZE: 12pt; COLOR: #330033"><%# DataBinder.Eval(Container.DataItem, "cnvcDeptTypeComments") %></b>
											
											<br>
											<b style="COLOR: red;FONT-WEIGHT: bold; FONT-SIZE: 11pt"><%# DataBinder.Eval(Container.DataItem, "cnvcComments") %></b>
											<asp:Repeater ID="Repeater2" Runat="server">
												<HeaderTemplate>
													<table>
												</HeaderTemplate>
												<ItemTemplate>
													<div style="display:none"><%# DataBinder.Eval(Container.DataItem, "cnvcDeptType") %></div>
													<tr>
														<td valign="top">
															<li>
																
																<b style="COLOR: #330033;FONT-WEIGHT: bold; FONT-SIZE: 11pt">
																<%# DataBinder.Eval(Container.DataItem, "cnvcVisitMan")  %>	</b>
																<b style=" FONT-WEIGHT: normal;FONT-SIZE: 11pt">																
																<%# DataBinder.Eval(Container.DataItem, "cnvcAffectComments") %>
																<%# DataBinder.Eval(Container.DataItem, "cnvcCustTypeComments") %>
																<%# DataBinder.Eval(Container.DataItem, "cnvcWellTypeComments") %>
																<img src="../image/<%# DataBinder.Eval(Container.DataItem, "cnvcImage2") %>"> 
															</li>
														</td>
													</tr>
												</ItemTemplate>
												<FooterTemplate>
			</table>
			</FooterTemplate> 
			</asp:Repeater> 
			
			</td> 			
			</ItemTemplate>
			<AlternatingItemTemplate>
									<td>		
					<!--<img src="../image/<%# DataBinder.Eval(Container.DataItem, "cnvcImage1") %>" style="float: right;" >-->
					<b style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033"><%# DataBinder.Eval(Container.DataItem, "cnvcDeptTypeComments") %></b>
					
					<br>
					<b style="COLOR: red"><%# DataBinder.Eval(Container.DataItem, "cnvcComments") %></b>
					<asp:Repeater ID="Repeater3" Runat="server">
						<HeaderTemplate>
							<table>
						</HeaderTemplate>
						<ItemTemplate>
							<div style="display:none"><%# DataBinder.Eval(Container.DataItem, "cnvcDeptType") %></div>
							<tr>
								<td valign="top">
									<li>
										<b style="COLOR: #330033;FONT-WEIGHT: bold; FONT-SIZE: 11pt">
										<%# DataBinder.Eval(Container.DataItem, "cnvcVisitMan") %>	</b>
										<b style="FONT-WEIGHT: normal; FONT-SIZE: 11pt">									
										<%# DataBinder.Eval(Container.DataItem, "cnvcAffectComments") %>
										<%# DataBinder.Eval(Container.DataItem, "cnvcCustTypeComments") %>
										<%# DataBinder.Eval(Container.DataItem, "cnvcWellTypeComments") %></b>	
										<img src="../image/<%# DataBinder.Eval(Container.DataItem, "cnvcImage2") %>">
									</li>
								</td>
							</tr>
						</ItemTemplate>
						<FooterTemplate>
							</table>
						</FooterTemplate>
					</asp:Repeater>
					
				</td>
										</tr>	
								</AlternatingItemTemplate>
			<FooterTemplate></table></FooterTemplate>
			</asp:Repeater></TD></TR></TBODY></TABLE>
		</form>
		<p align=center>
			<iframe src="../script/购买影响因素表注意事项.htm" id="the_frame" width="800px" height="100%" style="WIDTH: 800px; HEIGHT: 280px"></iframe>
		</p>

	</body>
</HTML>
