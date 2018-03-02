<%@ Page language="c#" Codebehind="wfmCustRelationDeepReport.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.VCustInfo.wfmCustRelationDeepReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmCustRelationDeepReport</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="../script/calendar.js"></script>
		<script language="javascript" src="../script/scrol.js"></script>
	</HEAD>
	<body bgcolor="#f2f8fb" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="5" width="95%" border="0" align="center">
				<TR>
					<TD align="center" style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033">客户销售进度</TD>
				</TR>
			</TABLE>
			<table cellspacing="0" cellpadding="0" width="95%" border="1" align="center">
				<tr>
					<td>
						<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 146px; HEIGHT: 29px" align="right">
									<asp:label id="Label2" runat="server" Font-Size="10pt" Width="70px">客户编码</asp:label></TD>
								<TD style="WIDTH: 206px; HEIGHT: 29px" align="right">
									<asp:TextBox id="txtCustID" runat="server" Width="176px"></asp:TextBox></TD>
								<TD style="WIDTH: 163px; HEIGHT: 29px" align="right">
									<asp:label id="Label1" runat="server" Font-Size="10pt" Width="104px">客户名称</asp:label></TD>
								<TD style="WIDTH: 193px; HEIGHT: 29px" align="right"><FONT face="宋体">
										<asp:TextBox id="txtCustName" runat="server" Width="207px"></asp:TextBox></FONT></TD>
								<TD style="WIDTH: 231px; HEIGHT: 29px" align="right">
									<asp:label id="Label6" runat="server" Width="104px" Font-Size="10pt">项目名称</asp:label></TD>
								<TD style="WIDTH: 197px; HEIGHT: 29px"><FONT face="宋体">
										<asp:TextBox id="txtChanceName" runat="server" Width="207px"></asp:TextBox></FONT></TD>
								<TD style="HEIGHT: 29px">
									<asp:button id="btnQuery" runat="server" Width="64px" Text="查询"></asp:button></TD>
							</TR>
							<TR height="20">
								<TD style="WIDTH: 146px" align="right">
									<asp:label id="Label3" runat="server" Font-Size="10pt" Width="88px">开始时间</asp:label></TD>
								<TD style="WIDTH: 206px" align="right">
									<asp:TextBox id="txtBeginDate" runat="server" Width="176px" onfocus="calendar()"></asp:TextBox></TD>
								<TD style="WIDTH: 163px" align="right">
									<asp:label id="Label5" runat="server" Font-Size="10pt" Width="72px">结束时间</asp:label></TD>
								<TD style="WIDTH: 193px" align="right">
									<asp:TextBox id="txtEndDate" runat="server" Width="206px" onfocus="calendar()"></asp:TextBox></TD>
								<td style="WIDTH: 231px" align="left"></td>
								<TD style="WIDTH: 197px"></TD>
								<TD>
									<asp:button id="btnExcel" runat="server" Width="64px" Text="导出"></asp:button></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 146px" align="right"></TD>
								<TD style="WIDTH: 206px" align="right"></TD>
								<TD style="WIDTH: 163px" align="center"></TD>
								<TD style="WIDTH: 193px" align="right"></TD>
								<td style="WIDTH: 231px" align="right">
									<asp:label id="Label4" runat="server" Width="111px" Font-Size="10pt">当前客户编码：</asp:label></td>
								<TD style="WIDTH: 197px" align="center">
									<asp:label id="lblCustID" runat="server" Font-Size="10pt" Width="168px"></asp:label></TD>
								<TD>
									<asp:button id="btnAdd" runat="server" Width="72px" Text="新增维系"></asp:button></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="1600" border="0" align="left">
				<TR>
					<TD align="left"><asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" Font-Names="Verdana" Width="100%"
							AlternatingItemStyle-BackColor="#660033" HeaderStyle-BackColor="SteelBlue" Font-Size="X-Small" Font-Name="Verdana"
							CellPadding="3" BorderWidth="1px" BorderColor="Black" PagerStyle-HorizontalAlign="Right" AllowPaging="True">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle Wrap="False"></SelectedItemStyle>
							<EditItemStyle Wrap="False"></EditItemStyle>
							<AlternatingItemStyle Wrap="False" ForeColor="Black" BackColor="#E6E6E6"></AlternatingItemStyle>
							<ItemStyle Wrap="False" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="Small" Font-Bold="True" Wrap="False" ForeColor="White" BackColor="#880028"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="cnnVisitSerialNo" ReadOnly="True" HeaderText="维系流水"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnnCustID" ReadOnly="True" HeaderText="客户编码"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcName" ReadOnly="True" HeaderText="客户名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcChanceName" ReadOnly="True" HeaderText="项目名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcMgr" ReadOnly="True" HeaderText="行业经理"></asp:BoundColumn>
								<asp:BoundColumn DataField="cndVisitDate" ReadOnly="True" HeaderText="拜访日期"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcVisitContentComments" ReadOnly="True" HeaderText="拜访内容"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcVisitDept" ReadOnly="True" HeaderText="拜访部门"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcDeptTypeComments" ReadOnly="True" HeaderText="部门属性"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcFour" ReadOnly="True" HeaderText="被访人归属"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcVisitMan" ReadOnly="True" HeaderText="被访人"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcManTypeComments" ReadOnly="True" HeaderText="被访人属性"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcAffectComments" ReadOnly="True" HeaderText="影响力"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcCustTypeComments" ReadOnly="True" HeaderText="客户反应类型"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcWellTypeComments" ReadOnly="True" HeaderText="满意度"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcCorpRelationComments" ReadOnly="True" HeaderText="企业关系深化"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcPrivateRelationComments" ReadOnly="True" HeaderText="私人关系深化"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcProjectSpeedComments" ReadOnly="True" HeaderText="项目进展阶段"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcDemandTypeComments" ReadOnly="True" HeaderText="客户需求跟进"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcComments" ReadOnly="True" HeaderText="备注"></asp:BoundColumn>
								<asp:HyperLinkColumn Text="详细信息" DataNavigateUrlField="cnnVisitSerialNo" DataNavigateUrlFormatString="wfmVisitAddMod.aspx?type=mod&amp;&amp;vid={0}"
									HeaderText="查看"></asp:HyperLinkColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<tr>
					<td>
						<p style="MARGIN-LEFT: 150px">
							<iframe src="../script/购买影响因素表注意事项.htm" id="the_frame" width="800" height="100%" style="WIDTH: 750px; HEIGHT: 280px">
							</iframe>
						</p>
					</td>
				</tr>
			</TABLE>
		</FORM>
	</body>
</HTML>
