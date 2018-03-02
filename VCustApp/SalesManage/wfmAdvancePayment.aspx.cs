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
	/// wfmAdvancePayment 的摘要说明。
	/// </summary>
	public class wfmAdvancePayment : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtProjectName;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtAcctName;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtMgr;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtPayDate;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtFeeName;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtFeeDate;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtPayFee;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.Button btnLoadAdvancePayment;
		protected System.Web.UI.WebControls.TextBox txtPrepayFee;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
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
			this.btnLoadAdvancePayment.Click += new System.EventHandler(this.btnLoadAdvancePayment_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("wfmAddAdvancePayment.aspx");
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			BindGrid();
		}

		private void BindGrid()
		{
			if(!this.JudgeIsNum(txtPayFee.Text,"交款金额"))
				return;
			if(!this.JudgeIsNum(txtPrepayFee.Text,"缴预存款金额"))
				return;
			string strSql = "select * from tbAdvancePayment where 1=1 ";
			if(txtCustName.Text != "")
				strSql += " and cnvcCustName like '%"+txtCustName.Text+"%'";
			if(txtProjectName.Text != "")
				strSql += " and cnvcProjectName like '%"+txtProjectName.Text+"%'";
			if(txtAcctName.Text != "")
				strSql += " and cnvcAcctName like '%"+txtAcctName.Text+"%'";
			if(txtMgr.Text != "")
				strSql += " and cnvcMgr like '%"+txtMgr.Text+"%'";
			if(txtPayDate.Text != "")
				strSql += " and convert(char(10),cndPayDate,121) <='"+txtPayDate.Text+"'";
			if(txtFeeName.Text != "")
				strSql += " and cnvcFeeName like '%"+txtFeeName.Text+"%'";
			if(txtFeeDate.Text != "")
				strSql += " and convert(char(10),cndFeeDate,121) <='"+txtFeeDate.Text+"'";
			if(txtPayFee.Text != "")
				strSql += " and cnnPayFee <="+txtPayFee.Text;
			if(txtPrepayFee.Text != "")
				strSql += " and cnnPrepayFee <="+txtPrepayFee.Text;
			DataTable dt = Helper.Query(strSql);
			this.DataGrid1.DataSource = dt;
			this.DataGrid1.DataBind();
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
			this.BindGrid();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.txtCustName.Text = "";
			this.txtProjectName.Text = "";
			this.txtAcctName.Text = "";
			this.txtMgr.Text = "";
			this.txtPayDate.Text = "";
			this.txtFeeName.Text = "";
			this.txtFeeDate.Text = "";
			this.txtPayFee.Text = "";
			this.txtPrepayFee.Text = "";

		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			//DataGridColumn dgc = this.DataGrid1.Columns[10];
			//this.DataGrid1.Columns.Remove(dgc);
			//this.DataGrid1.Columns.RemoveAt(10);
			this.DataGrid1.Columns[11].Visible = false;
			this.DataGridToExcel(this.DataGrid1,"预收账款");
			//this.DataGrid1.Columns.Add(dgc);
		}

		private void btnLoadAdvancePayment_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("../wfmFileUp.aspx?XlsType=AdvancePayment");
		}
	}
}
