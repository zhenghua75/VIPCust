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
using VCustApp.Common;
using VCustApp.BusinessFacade;
using VCustApp.Entity.EntityClass;

namespace VCustApp.BusinessChance
{
	/// <summary>
	/// wfmAddChance 的摘要说明。
	/// </summary>
	public class wfmAddChance : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.DropDownList ddlChanceType;
		protected System.Web.UI.WebControls.DropDownList ddlMgr;
		protected System.Web.UI.WebControls.TextBox txtComments;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.DropDownList ddlChanceType2;
		protected System.Web.UI.WebControls.TextBox txtCustID;
		protected System.Web.UI.WebControls.TextBox txtForecastIncome;
		protected System.Web.UI.WebControls.TextBox txtProjectName;
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.DropDownList ddlChanceSpeed;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.TextBox txtQueryCustID;
		protected System.Web.UI.WebControls.TextBox txtQueryCustName;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.DropDownList ddlTradeMgr;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtChanceDate;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!this.IsPostBack)
			{
				BindDDL();				
				this.RegisterStartupScript("hide","<script lanaguage=javascript>ShowHide('1','none');</script>");
			}
			
		}
		private void BindDDL()
		{
			this.BindDropDownList(ddlDept,ConstApp.A_DEPT,"");
			this.BindDropDownList(ddlChanceType,ConstApp.A_NAMECODE,"cnvcType='CHANCE_TYPE'");
			this.BindDropDownList(ddlChanceType2,ConstApp.A_NAMECODE,"cnvcType='"+ddlChanceType.SelectedValue+"'");
			this.BindDropDownList(ddlMgr,ConstApp.A_OPER,"cnvcRoleCode='customer' and cnvcDeptID like '"+ddlDept.SelectedValue+"'");
			this.BindDropDownList(ddlTradeMgr,ConstApp.A_OPER,"cnvcRoleCode='trade' and cnvcDeptID like '"+ddlDept.SelectedValue+"'");
			this.BindDropDownList(ddlChanceSpeed,ConstApp.A_NAMECODE,"cnvcType='CHANCE_SPEED'");
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
			this.ddlDept.SelectedIndexChanged += new System.EventHandler(this.ddlDept_SelectedIndexChanged);
			this.ddlChanceType.SelectedIndexChanged += new System.EventHandler(this.ddlChanceType_SelectedIndexChanged);
			this.ddlTradeMgr.SelectedIndexChanged += new System.EventHandler(this.ddlTradeMgr_SelectedIndexChanged);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ddlDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
			this.BindDropDownList(ddlTradeMgr,ConstApp.A_OPER,"cnvcRoleCode='trade' and cnvcDeptID='"+ddlDept.SelectedValue+"'");
			this.BindDropDownList(ddlMgr,ConstApp.A_OPER,"cnvcRoleCode='customer' and cnvcManager='"+ddlTradeMgr.SelectedValue+"' and cnvcDeptID='"+ddlDept.SelectedValue+"'");
		}

		private void ddlChanceType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.BindDropDownList(ddlChanceType2,ConstApp.A_NAMECODE,"cnvcType='"+ddlChanceType.SelectedValue+"'");
		}		
	

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			try
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

		private void CleanCtrl()
		{
			this.txtProjectName.Text = "";
			this.txtCustName.Text = "";
			this.txtCustID.Text = "";
			this.txtComments.Text = "";
			this.txtForecastIncome.Text = "";
			this.txtChanceDate.Text = "";
			this.RegisterStartupScript("hide","<script lanaguage=javascript>ShowHide('1','none');</script>");
		}

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.txtCustID.Text = this.DataGrid1.SelectedItem.Cells[0].Text;
			this.txtCustName.Text = this.DataGrid1.SelectedItem.Cells[1].Text;
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("wfmChanceQuery.aspx");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			CleanCtrl();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(this.JudgeIsNull(txtProjectName.Text,"商机名称"))
					return;
				if(!this.JudgeIsNum(txtForecastIncome.Text,"预测收入"))
					return;
				if(this.JudgeIsNull(txtChanceDate.Text,"商机时间"))
					return;
				if(this.JudgeIsNull(txtCustName.Text,"客户名称"))
					return;
				string strSql = "select * from tbProject where cnvcProjectName = '"+txtProjectName.Text+"'";
				DataTable dtProject = Helper.Query(strSql);
				if(dtProject.Rows.Count > 0)
					throw new Exception("相同名称商机已存在");
				Project project = new Project();
				project.cnvcChanceName = txtProjectName.Text;
				project.cnnCustID = Convert.ToDecimal(txtCustID.Text);
				project.cnnForecastIncome = Convert.ToDecimal(txtForecastIncome.Text);
				project.cnvcChanceSpeed = ddlChanceSpeed.SelectedValue;
				project.cnvcChanceType = ddlChanceType2.SelectedValue;
				project.cnvcComments = txtComments.Text;
				project.cnvcDeptID = ddlDept.SelectedValue;
				project.cnvcMgr = ddlMgr.SelectedValue;
				project.cnvcTradeMgr = ddlTradeMgr.SelectedValue;
				project.cndChanceDate = Convert.ToDateTime(txtChanceDate.Text);
				
				ChanceFacade.AddProject(project,oper);
				Popup("商机添加成功");	
				this.CleanCtrl();
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}

		private void ddlTradeMgr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.BindDropDownList(ddlMgr,ConstApp.A_OPER,"cnvcManager like '"+ddlTradeMgr.SelectedValue+"' and cnvcDeptID like '"+ddlDept.SelectedValue+"'");
		}

	}
}
