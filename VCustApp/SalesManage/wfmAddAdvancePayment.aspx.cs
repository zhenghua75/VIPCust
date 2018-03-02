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
	/// wfmAddAdvancePayment 的摘要说明。
	/// </summary>
	public class wfmAddAdvancePayment : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCustID;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtProjectName;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtComments;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtQueryCustID;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtQueryCustName;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtAcctName;
		protected System.Web.UI.WebControls.TextBox txtMgr;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtPayDate;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtFeeName;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtFeeDate;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtPayFee;
		protected System.Web.UI.WebControls.TextBox txtPrepayFee;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
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
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DataGridItem item = this.DataGrid1.SelectedItem;
			this.txtCustID.Text = item.Cells[0].Text;
			this.txtCustName.Text = item.Cells[1].Text;
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			string strSql = "select top 10 * from tbCust where ";
			switch(oper.cnvcRoleCode)
			{
				case "customer":
					strSql+=" cnvcCustMana='"+oper.cnvcOperID+"'";
					break;
				case "trade":
					strSql+=" cnvcCustTradeMana='"+oper.cnvcOperID+"'";
					break;
				case "admin":
					strSql+=" 1=1";
					break;
				case "manager":
					strSql+=" 1=1";
					break;
				default:
					strSql+=" 1=2";
					break;
			}
			if(txtQueryCustID.Text != "")
				strSql += " and cnnCustID="+txtQueryCustID.Text;
			if(txtQueryCustName.Text != "")
				strSql += " and cnvcName like '"+txtQueryCustName.Text+"'";
			DataTable dt = Helper.Query(strSql);
			this.DataTableConvert(dt,"cnvcTradeType",ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE'");
			this.DataGrid1.DataSource = dt;
			this.DataGrid1.DataBind();

		}


		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				string strSql = "select * from tbAdvancePayment where cnnCustID = "+txtCustID.Text;
				DataTable dt = Helper.Query(strSql);
				if( dt.Rows.Count > 0)
				{
					Popup("客户存在冲突");
					return;
				}
				if(this.JudgeIsNull(txtCustName.Text,"客户"))
					return;
				if(this.JudgeIsNull(txtCustName.Text,"客户名称"))
					return;
				if(this.JudgeIsNull(txtFeeDate.Text,"费用计收时间"))
					return;
				if(this.JudgeIsNull(txtPayDate.Text,"交款时间"))
					return;
				AdvancePayment ap = new AdvancePayment();
				ap.cndFeeDate = DateTime.Parse(txtFeeDate.Text);
				ap.cndPayDate = DateTime.Parse(txtPayDate.Text);
				ap.cnnCustID = Convert.ToDecimal(txtCustID.Text);
				ap.cnnPayFee = Convert.ToDecimal(txtPayFee.Text);
				ap.cnnPrepayFee = Convert.ToDecimal(txtPrepayFee.Text);
				ap.cnvcAcctName = txtAcctName.Text;
				ap.cnvcComments = txtComments.Text;
				ap.cnvcCustName = txtCustName.Text;
				ap.cnvcFeeName = txtFeeName.Text;
				ap.cnvcMgr = txtMgr.Text;
				ap.cnvcProjectName = txtProjectName.Text;

				SalesManageFacade.AddAdvancePayment(ap,oper);
				Popup("预收账款添加成功");
				this.txtCustName.Text = "";
				this.txtProjectName.Text = "";
				this.txtAcctName.Text = "";
				this.txtMgr.Text = "";
				this.txtPayDate.Text = "";
				this.txtFeeName.Text = "";
				this.txtFeeDate.Text = "";
				this.txtPayFee.Text = "";
				this.txtPrepayFee.Text = "";
				this.txtComments.Text = "";
				
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
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
			this.txtComments.Text = "";
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("wfmAdvancePayment.aspx");
		}
	}
}
