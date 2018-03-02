using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using VCustApp.BusinessFacade;
using VCustApp.Common;
using VCustApp.Entity.EntityClass;

namespace VCustApp.SalesManage
{
	/// <summary>
	/// wfmAccountReceivable 的摘要说明。
	/// </summary>
	public class wfmAccountReceivable : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.DropDownList ddlTradeType1;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.DropDownList ddlTradeType2;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.DropDownList ddlCustLevel;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtContractNo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtProjectName;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtAcctID;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtAcctName;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtCustID;
		protected System.Web.UI.WebControls.Button btnLoadAccountReceivable;
		protected System.Web.UI.WebControls.Button btnExcel;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!this.IsPostBack)
			{
				BindDDL();
			}
		}

		private void BindDDL()
		{
			this.BindDropDownList(ddlTradeType1,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=2",new ListItem("所有","%"));
			this.BindDropDownList(ddlTradeType2,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=4",new ListItem("所有","%"));
			this.BindDropDownList(ddlCustLevel,ConstApp.A_NAMECODE,"cnvcType='CUST_LEVEL'",new ListItem("所有","%"));
		}
		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.btnLoadAccountReceivable.Click += new System.EventHandler(this.btnLoadAccountReceivable_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			string strSql = "select * from tbAccountReceivable where 1=1 ";
			strSql += " and cnvcTradeType1 like '"+ddlTradeType1.SelectedValue+"'";
			strSql += " and cnvcTradeType2 like '"+ddlTradeType2.SelectedValue+"'";
			strSql += " and cnvcCustLevel like '"+ddlCustLevel.SelectedValue+"'";
			if(txtCustID.Text != "")
				strSql += " and cnnCustID = "+txtCustID.Text;
			if(txtCustName.Text != "")
				strSql += " and cnvcCustName like '%"+txtCustName.Text+"%'";
			if(txtContractNo.Text != "")
				strSql += " and cnvcContractNo like '%"+txtContractNo.Text+"%'";
			if(txtProjectName.Text != "")
				strSql += " and cnvcProjectName like '%"+txtProjectName.Text+"%'";
			if(txtAcctID.Text != "")
				strSql += " and cnnAcctID = "+txtAcctID.Text;
			if(txtAcctName.Text != "")
				strSql += " and cnvcAcctName like '%"+txtAcctName.Text+"%'";
			DataTable dt = Helper.Query(strSql);
			this.DataTableConvert(dt,"cnvcTradeType1",ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=2");
			this.DataTableConvert(dt,"cnvcTradeType2",ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=4");
			this.DataTableConvert(dt,"cnvcCustLevel",ConstApp.A_NAMECODE,"cnvcType='CUST_LEVEL'");
			this.DataGrid1.DataSource = dt;
			this.DataGrid1.DataBind();
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
			this.btnQuery_Click(null,null);
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("wfmAddAccountReceivable.aspx");
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			this.DataGrid1.Columns[11].Visible = false;
			this.DataGridToExcel(this.DataGrid1,"应收管理");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			txtCustID.Text = "";
			txtCustName.Text = "";
			txtContractNo.Text = "";
			txtProjectName.Text = "";
			txtAcctID.Text = "";
			txtAcctName.Text = "";
			//txtSvcTypeName.Text = "";
			//txtFee.Text = "";
		}

		private void btnLoadAccountReceivable_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("../wfmFileUp.aspx?XlsType=AccountReceivable");
		}
	}
}
