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
	/// wfmModifyAccountReceivable 的摘要说明。
	/// </summary>
	public class wfmModifyAccountReceivable : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.TextBox txtCustID;
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
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtFee;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtQueryCustID;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtQueryCustName;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtSvcTypeName;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			this.RegisterStartupScript("hide","<script lanaguage=javascript>ShowHide('1','none');</script>");
			if(!this.IsPostBack)
			{
				if(Request["cnnCustID"] == null)
				{
					Popup("无效链接");
					return;
				}
				BindDDL();
				string strCustID = Request["cnnCustID"].ToString();
				DataTable dt = Helper.Query("select * from tbAccountReceivable where cnnCustID = "+strCustID);
				AccountReceivable ar = new AccountReceivable(dt);

				txtCustID.Text = ar.cnnCustID.ToString();
				txtCustName.Text = ar.cnvcCustName;
				ListItem li1 = ddlTradeType1.Items.FindByValue(ar.cnvcTradeType1);
				if(li1 != null)
					li1.Selected = true;
				ListItem li2 = ddlTradeType2.Items.FindByValue(ar.cnvcTradeType2);
				if(li2 != null)
					li2.Selected = true;
				ListItem liCustLevel = ddlCustLevel.Items.FindByValue(ar.cnvcCustLevel);
				if(liCustLevel != null)
					liCustLevel.Selected = true;
				txtContractNo.Text = ar.cnvcContractNo;
				txtProjectName.Text = ar.cnvcProjectName;
				txtAcctID.Text = ar.cnnAcctID.ToString();
				txtAcctName.Text = ar.cnvcAcctName;
				txtSvcTypeName.Text = ar.cnvcSvcTypeName;
				txtFee.Text = ar.cnnFee.ToString();

				
				
			}
		}

		private void BindDDL()
		{
			this.BindDropDownList(ddlTradeType1,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=2");
			this.BindDropDownList(ddlTradeType2,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=4");
			this.BindDropDownList(ddlCustLevel,ConstApp.A_NAMECODE,"cnvcType='CUST_LEVEL'");
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
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			try
			{
				string strSql = "select top 10 * from tbCust where 1=1";
				if(txtQueryCustID.Text!="")
					strSql += " and cnnCustID="+txtQueryCustID.Text;
				if(txtQueryCustName.Text != "")
					strSql += " and cnvcName like '%"+txtQueryCustName.Text+"%'";
				strSql += " order by cnnCustID";
				DataTable dtCust = Helper.Query(strSql);
				this.DataTableConvert(dtCust,"cnvcTradeType",ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE'");
				this.DataGrid1.DataSource = dtCust;
				this.DataGrid1.DataBind();
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.txtCustID.Text = this.DataGrid1.SelectedItem.Cells[0].Text;
			this.txtCustName.Text = this.DataGrid1.SelectedItem.Cells[1].Text;
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("wfmAccountReceivable.aspx");

		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(this.JudgeIsNull(txtCustID.Text,"客户"))
					return;
				if(this.JudgeIsNull(txtCustName.Text,"客户名称"))
					return;
				if(!this.JudgeIsNum(txtFee.Text,"收入"))
					return;
				DataTable dt = Helper.Query("select * from tbAccountReceivable where cnnCustID = "+txtCustID.Text);

				AccountReceivable ar = new AccountReceivable(dt);
				ar.cnnAcctID = Convert.ToDecimal(txtAcctID.Text);
				//ar.cnnCustID = Convert.ToDecimal(txtCustID.Text);
				ar.cnnFee = Convert.ToDecimal(txtFee.Text);
				
				ar.cnvcAcctName = txtAcctName.Text;
				ar.cnvcContractNo = txtContractNo.Text;
				ar.cnvcCustLevel = ddlCustLevel.SelectedValue;
				ar.cnvcCustName = txtCustName.Text;
				ar.cnvcProjectName = txtProjectName.Text;
				ar.cnvcSvcTypeName = txtSvcTypeName.Text;
				ar.cnvcTradeType1 = ddlTradeType1.SelectedValue;
				ar.cnvcTradeType2 = ddlTradeType2.SelectedValue;
				
				SalesManageFacade.UpdateAccountReceivable(ar,oper);
				Popup("成功修改应收");
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			try
			{
				BindDDL();
				DataTable dt = Helper.Query("select * from tbAccountReceivable where cnnCustID = "+txtCustID.Text);
				AccountReceivable ar = new AccountReceivable(dt);

				txtCustID.Text = ar.cnnCustID.ToString();
				txtCustName.Text = ar.cnvcCustName;
				ListItem li1 = ddlTradeType1.Items.FindByValue(ar.cnvcTradeType1);
				if(li1 != null)
					li1.Selected = true;
				ListItem li2 = ddlTradeType2.Items.FindByValue(ar.cnvcTradeType2);
				if(li2 != null)
					li2.Selected = true;
				ListItem liCustLevel = ddlCustLevel.Items.FindByValue(ar.cnvcCustLevel);
				if(liCustLevel != null)
					liCustLevel.Selected = true;
				txtContractNo.Text = ar.cnvcContractNo;
				txtProjectName.Text = ar.cnvcProjectName;
				txtAcctID.Text = ar.cnnAcctID.ToString();
				txtAcctName.Text = ar.cnvcAcctName;
				txtSvcTypeName.Text = ar.cnvcSvcTypeName;
				txtFee.Text = ar.cnnFee.ToString();
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}
	}
}
