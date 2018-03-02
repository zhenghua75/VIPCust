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
							Height="52">�̻�ά��</asp:label></td>
				</tr>
			</table>
			<table border="1" cellSpacing="0" cellPadding="0" width="100%" align="center">
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
					<td>
						<asp:label id="Label9" runat="server" CssClass="lable">�ͻ�����</asp:label></td>
					<td>
						<asp:dropdownlist id="ddlMgr" runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td>
						<asp:label id="Label7" runat="server" CssClass="lable">��ҵ����</asp:label></td>
					<td>
						<asp:dropdownlist id="ddlTradeMgr" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
					<td><asp:label id="Label8" runat="server" CssClass="lable">�̻���չ��</asp:label></td>
					<td>
						<asp:DropDownList id="ddlChanceSpeed" runat="server"></asp:DropDownList></td>
					<td colSpan="2" align="center">
						<asp:Button id="btnQuery" runat="server" Text="��ѯ"></asp:Button>
						<asp:Button id="btnCancel" runat="server" Text="ȡ��"></asp:Button>
						<asp:Button id="btnAddChance" runat="server" Text="���"></asp:Button>
						<asp:Button id="btnLoadChance" runat="server" Text="����"></asp:Button></td>
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
								<asp:BoundColumn DataField="cnvcDeptIDComments" HeaderText="�ֹ�˾">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="cnnProjectID" HeaderText="��ĿID"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcChanceName" HeaderText="�̻�����">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcCustName" HeaderText="�ͻ�����">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcCustomTradeMgr" HeaderText="�ͻ�����/��ҵ����">
									<ItemStyle Width="80px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcChanceSpeedComments" HeaderText="�̻���չ">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcChanceTypeComments" HeaderText="�̻�����">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnnForecastIncome" HeaderText="Ԥ�����루��Ԫ��">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cndChanceDate" HeaderText="�̻�ʱ��" DataFormatString="{0:yyyy��MM��dd��}">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcIsSucessComments" HeaderText="��ת��">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcContractNo" HeaderText="��ͬ���">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcProjectName" HeaderText="��Ŀ����">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnnSucessIncome" HeaderText="ת�����루��Ԫ��">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cndSucessDate" HeaderText="ת��ʱ��" DataFormatString="{0:yyyy��MM��dd��}">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:HyperLinkColumn Text="�޸�" DataNavigateUrlField="cnnProjectID" DataNavigateUrlFormatString="wfmModifyChance.aspx?cnnProjectID={0}"
									HeaderText="�޸�">
									<ItemStyle Width="50px"></ItemStyle>
								</asp:HyperLinkColumn>
								<asp:HyperLinkColumn Text="ת��" Target="_self" DataNavigateUrlField="cnnProjectID" DataNavigateUrlFormatString="wfmEndChance.aspx?cnnProjectID={0}"
									HeaderText="ת��">
									<ItemStyle Width="50px"></ItemStyle>
								</asp:HyperLinkColumn>
								<asp:ButtonColumn Text="ɾ��" HeaderText="ɾ��" CommandName="Delete">
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
