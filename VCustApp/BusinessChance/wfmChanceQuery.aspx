<%@ Page language="c#" Codebehind="wfmChanceQuery.aspx.cs" AutoEventWireup="false" Inherits="VCustApp.BusinessChance.wfmChanceQuery" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmChanceQuery</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../css/style.css">
		<script language="javascript">
		function applyWidth(oTr)
        {
            var oCells = oTr.cells;
            for(i = 0; i < oCells.length; i++)
            {
                if(oCells[i].firstChild != null && oCells[i].firstChild.tagName.toLowerCase() == "input")
                {
                    oCells[i].firstChild.style.width = oCells[i].clientWidth;
                }
            }
        }
        
        function checkValid(oGrid)
        {
            var rowIndex = -1;
            if(oGrid)
            {
                var oRows = oGrid.rows;
                for(i = 0; i < oRows.length; i++)
                {
                    var oCells = oRows[i].cells;
                    if(oCells.length > 0)
                    {
                        if(oCells[0].childNodes.length == 3)
                        {
                            rowIndex = i;
                            break;
                        }
                    }
                }
            }
            return rowIndex;
        }
        window.onload = function()
        {
            var oGrid = document.getElementById("DataGrid1");
            var rowIndex = checkValid(oGrid);
            if(rowIndex > -1)
            {
                applyWidth(oGrid.rows[rowIndex]);
            }
        }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table align="center">
				<tr>
					<td colSpan="2"><asp:label id="Label1" runat="server" style="FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #330033"
							Height="52">商机维护</asp:label></td>
				</tr>
			</table>
			<table border="1" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td><asp:label id="Label5" runat="server" CssClass="lable">分公司：</asp:label></td>
					<td><asp:dropdownlist id="ddlDept" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
					<td><asp:label id="Label2" runat="server" CssClass="lable">商机名称：</asp:label></td>
					<td><asp:textbox id="txtProjectName" runat="server" CssClass="textbox"></asp:textbox></td>
					<td><asp:label id="Label3" runat="server" CssClass="lable">商机类型：</asp:label></td>
					<td><asp:dropdownlist id="ddlChanceType" runat="server" AutoPostBack="True"></asp:dropdownlist><br>
						<asp:dropdownlist id="ddlChanceType2" runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td><asp:label id="Label4" runat="server" CssClass="lable">客户名称：</asp:label></td>
					<td><asp:textbox id="txtCustName" runat="server" CssClass="textbox"></asp:textbox></td>
					<td><asp:label id="Label6" runat="server" CssClass="lable">商机预测收入（万元）：</asp:label></td>
					<td><asp:textbox id="txtForecaseIncome" runat="server" CssClass="textbox"></asp:textbox></td>
					<td>
						<asp:label id="Label9" runat="server" CssClass="lable">客户经理：</asp:label></td>
					<td>
						<asp:dropdownlist id="ddlMgr" runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td>
						<asp:label id="Label7" runat="server" CssClass="lable">行业经理：</asp:label></td>
					<td>
						<asp:dropdownlist id="ddlTradeMgr" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
					<td><asp:label id="Label8" runat="server" CssClass="lable">商机进展：</asp:label></td>
					<td>
						<asp:DropDownList id="ddlChanceSpeed" runat="server"></asp:DropDownList></td>
					<td colSpan="2" align="center">
						<asp:Button id="btnQuery" runat="server" Text="查询"></asp:Button>
						<asp:Button id="btnCancel" runat="server" Text="取消"></asp:Button>
						<asp:Button id="btnAddChance" runat="server" Text="添加"></asp:Button>
						<asp:Button id="btnLoadChance" runat="server" Text="导入"></asp:Button></td>
				</tr>
			</table>
			<table cellSpacing="1" cellPadding="1" border="0" align="left" width="1600">
				<tr>
					<td align="left">
						<asp:datagrid id="DataGrid1" runat="server" Font-Size="X-Small" PageSize="15" AllowPaging="True"
							PagerStyle-HorizontalAlign="Right" BorderColor="Black" BorderWidth="1px" CellPadding="3" Font-Name="Verdana"
							HeaderStyle-BackColor="SteelBlue" AlternatingItemStyle-BackColor="#660033" Font-Names="Verdana"
							AutoGenerateColumns="False">
							<FooterStyle Wrap="False"></FooterStyle>
							<SelectedItemStyle Wrap="False"></SelectedItemStyle>
							<EditItemStyle Wrap="False"></EditItemStyle>
							<AlternatingItemStyle Wrap="False" ForeColor="Black" BackColor="#E6E6E6"></AlternatingItemStyle>
							<ItemStyle Wrap="False" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="Small" Font-Bold="True" Wrap="False" ForeColor="White" BackColor="#880028"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cnvcDeptIDComments" HeaderText="分公司">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="cnnProjectID" HeaderText="项目ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcChanceName" HeaderText="商机名称">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcCustName" HeaderText="客户名称">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcCustomTradeMgr" HeaderText="客户经理/行业经理">
									<ItemStyle Width="80px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcChanceSpeedComments" HeaderText="商机进展">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcChanceTypeComments" HeaderText="商机类型">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnnForecastIncome" HeaderText="预测收入（万元）">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cndChanceDate" HeaderText="商机时间" DataFormatString="{0:yyyy年MM月dd日}">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcIsSucessComments" HeaderText="已转化">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcContractNo" HeaderText="合同编号">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcProjectName" HeaderText="项目名称">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnnSucessIncome" HeaderText="转化收入（万元）">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cndSucessDate" HeaderText="转化时间" DataFormatString="{0:yyyy年MM月dd日}">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:HyperLinkColumn Text="修改" DataNavigateUrlField="cnnProjectID" DataNavigateUrlFormatString="wfmModifyChance.aspx?cnnProjectID={0}"
									HeaderText="修改">
									<ItemStyle Width="50px"></ItemStyle>
								</asp:HyperLinkColumn>
								<asp:HyperLinkColumn Text="转化" Target="_self" DataNavigateUrlField="cnnProjectID" DataNavigateUrlFormatString="wfmEndChance.aspx?cnnProjectID={0}"
									HeaderText="转化">
									<ItemStyle Width="50px"></ItemStyle>
								</asp:HyperLinkColumn>
								<asp:ButtonColumn Text="删除" HeaderText="删除" CommandName="Delete">
									<ItemStyle Width="50px"></ItemStyle>
								</asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
