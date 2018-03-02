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
	/// wfmModifyChance 的摘要说明。
	/// </summary>
	public class wfmModifyChance : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DropDownList DropDownList4;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.DropDownList DropDownList5;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.DropDownList DropDownList6;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtQueryCustID;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtQueryCustName;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.DropDownList ddlChanceType;
		protected System.Web.UI.WebControls.DropDownList ddlChanceType2;
		protected System.Web.UI.WebControls.DropDownList ddlChanceSpeed;
		protected System.Web.UI.WebControls.DropDownList ddlMgr;
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.TextBox txtCustID;
		protected System.Web.UI.WebControls.TextBox txtProjectName;
		protected System.Web.UI.WebControls.TextBox txtForecastIncome;
		protected System.Web.UI.WebControls.TextBox txtProjectID;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtChanceDate;
		protected System.Web.UI.WebControls.DropDownList ddlTradeMgr;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.TextBox txtComments;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!this.IsPostBack)
			{
				if(Request["cnnProjectID"] == null)
				{
					Popup("无效链接");
					return;
				}
				string strProjectID = Request["cnnProjectID"].ToString();
				//BindDDL();
				DataTable dtProject = Helper.Query("select * from tbProject where cnnProjectID="+strProjectID);
				Project project = new Project(dtProject);
				txtProjectID.Text = project.cnnProjectID.ToString();
				txtProjectName.Text = project.cnvcChanceName;

				this.BindDropDownList(ddlDept,ConstApp.A_DEPT,"");
				ListItem liDept = ddlDept.Items.FindByValue(project.cnvcDeptID);
				if(liDept != null)
					liDept.Selected = true;

				this.BindDropDownList(ddlChanceType,ConstApp.A_NAMECODE,"cnvcType='CHANCE_TYPE'");
				if(project.cnvcChanceType.StartsWith("Q"))
				{
					ListItem liChanceType = ddlChanceType.Items.FindByValue("QUESTION");
					if(liChanceType != null)
						liChanceType.Selected = true;
				}
				else
				{
					ListItem liChanceType = ddlChanceType.Items.FindByValue("VALUE");
					if(liChanceType != null)
						liChanceType.Selected = true;
				}

				this.BindDropDownList(ddlChanceType2,ConstApp.A_NAMECODE,"cnvcType='"+ddlChanceType.SelectedValue+"'");
				ListItem liChanceType2 = ddlChanceType2.Items.FindByValue(project.cnvcChanceType);
				if(liChanceType2 != null)
					liChanceType2.Selected = true;

				txtCustID.Text = project.cnnCustID.ToString();
				DataTable dtCust = Helper.Query("select cnvcName from tbCust where cnnCustID="+txtCustID.Text);
				Cust cust = new Cust(dtCust);
				txtCustName.Text = cust.cnvcName;
				txtForecastIncome.Text = project.cnnForecastIncome.ToString();

				this.BindDropDownList(ddlChanceSpeed,ConstApp.A_NAMECODE,"cnvcType='CHANCE_SPEED'");
				ListItem liChanceSpeed = ddlChanceSpeed.Items.FindByValue(project.cnvcChanceSpeed);
				if(liChanceSpeed != null)
					liChanceSpeed.Selected = true;

				this.BindDropDownList(ddlTradeMgr,ConstApp.A_OPER,"cnvcRoleCode='trade' and cnvcDeptID like '"+ddlDept.SelectedValue+"'");
				ListItem liTradeMgr = ddlTradeMgr.Items.FindByValue(project.cnvcTradeMgr);
				if(liTradeMgr != null)
					liTradeMgr.Selected = true;

				this.BindDropDownList(ddlMgr,ConstApp.A_OPER,"cnvcRoleCode='customer' and cnvcDeptID like '"+ddlDept.SelectedValue+"' and cnvcManager='"+ddlTradeMgr.SelectedValue+"'");
				ListItem liMgr = ddlMgr.Items.FindByValue(project.cnvcMgr);
				if(liMgr != null)
					liMgr.Selected = true;
				txtComments.Text = project.cnvcComments;
				txtChanceDate.Text = project.cndChanceDate.ToString("yyyy-MM-dd");
				
				this.RegisterStartupScript("hide","<script lanaguage=javascript>ShowHide('1','none');</script>");
			}
		}

		private void BindDDL()
		{
			//this.BindDropDownList(ddlDept,ConstApp.A_DEPT,"");
			//this.BindDropDownList(ddlChanceType,ConstApp.A_NAMECODE,"cnvcType='CHANCE_TYPE'");
			//this.BindDropDownList(ddlChanceType2,ConstApp.A_NAMECODE,"cnvcType='"+ddlChanceType.SelectedValue+"'");
			//this.BindDropDownList(ddlMgr,ConstApp.A_OPER,"cnvcDeptID like '"+ddlDept.SelectedValue+"'");
			//this.BindDropDownList(ddlChanceSpeed,ConstApp.A_NAMECODE,"cnvcType='CHANCE_SPEED'");
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
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void ddlDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//this.BindDropDownList(ddlMgr,ConstApp.A_OPER,"cnvcRoleCode='customer' and cnvcDeptID='"+ddlDept.SelectedValue+"'");
			//this.BindDropDownList(ddlTradeMgr,ConstApp.A_OPER,"cnvcRoleCode='trade' and cnvcDeptID='"+ddlDept.SelectedValue+"'");
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


		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(this.JudgeIsNull(txtProjectName.Text,"商机名称"))
					return;
				if(!this.JudgeIsNum(txtForecastIncome.Text,"预测收入"))
					return;
				if(this.JudgeIsNull(txtChanceDate.Text,"商机时间"))
					return;
				DataTable dtProject = Helper.Query("select * from tbProject where cnnProjectID="+txtProjectID.Text);
				Project project = new Project(dtProject);
				
				if(project.cnvcMgr != oper.cnvcOperID && project.cnvcOperID != oper.cnvcOperID)
				{
					throw new Exception("只有发布者或者客户经理才可以修改");
				}
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
				
				ChanceFacade.UpdateProject(project,oper);
				Popup("商机修改成功");	
				//this.CleanCtrl();
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			DataTable dtProject = Helper.Query("select * from tbProject where cnnProjectID="+txtProjectID.Text);
			Project project = new Project(dtProject);
			//txtProjectID.Text = project.cnnProjectID.ToString();
			txtProjectName.Text = project.cnvcChanceName;

			this.BindDropDownList(ddlDept,ConstApp.A_DEPT,"");
			ListItem liDept = ddlDept.Items.FindByValue(project.cnvcDeptID);
			if(liDept != null)
				liDept.Selected = true;

			this.BindDropDownList(ddlChanceType,ConstApp.A_NAMECODE,"cnvcType='CHANCE_TYPE'");
			if(project.cnvcChanceType.StartsWith("Q"))
			{
				ListItem liChanceType = ddlChanceType.Items.FindByValue("QUESTION");
				if(liChanceType != null)
					liChanceType.Selected = true;
			}
			else
			{
				ListItem liChanceType = ddlChanceType.Items.FindByValue("VALUE");
				if(liChanceType != null)
					liChanceType.Selected = true;
			}

			this.BindDropDownList(ddlChanceType2,ConstApp.A_NAMECODE,"cnvcType='"+ddlChanceType.SelectedValue+"'");
			ListItem liChanceType2 = ddlChanceType2.Items.FindByValue(project.cnvcChanceType);
			if(liChanceType2 != null)
				liChanceType2.Selected = true;

			txtCustID.Text = project.cnnCustID.ToString();
			DataTable dtCust = Helper.Query("select cnvcName from tbCust where cnnCustID="+txtCustID.Text);
			Cust cust = new Cust(dtCust);
			txtCustName.Text = cust.cnvcName;
			txtForecastIncome.Text = project.cnnForecastIncome.ToString();

			this.BindDropDownList(ddlChanceSpeed,ConstApp.A_NAMECODE,"cnvcType='CHANCE_SPEED'");
			ListItem liChanceSpeed = ddlChanceSpeed.Items.FindByValue(project.cnvcChanceSpeed);
			if(liChanceSpeed != null)
				liChanceSpeed.Selected = true;

			this.BindDropDownList(ddlMgr,ConstApp.A_OPER,"cnvcRoleCode='customer' and cnvcDeptID like '"+ddlDept.SelectedValue+"'");
			ListItem liMgr = ddlMgr.Items.FindByValue(project.cnvcMgr);
			if(liMgr != null)
				liMgr.Selected = true;
			txtComments.Text = project.cnvcComments;
			txtChanceDate.Text = project.cndChanceDate.ToString("yyyy-MM-dd");
			this.BindDropDownList(ddlTradeMgr,ConstApp.A_OPER,"cnvcRoleCode='trade' and cnvcDeptID like '"+ddlDept.SelectedValue+"'");
			ListItem liTradeMgr = ddlTradeMgr.Items.FindByValue(project.cnvcTradeMgr);
			if(liTradeMgr != null)
				liTradeMgr.Selected = true;
			this.RegisterStartupScript("hide","<script lanaguage=javascript>ShowHide('1','none');</script>");
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("wfmChanceQuery.aspx");
		}

		private void ddlTradeMgr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.BindDropDownList(ddlMgr,ConstApp.A_OPER,"cnvcManager like '"+ddlTradeMgr.SelectedValue+"' and cnvcDeptID like '"+ddlDept.SelectedValue+"'");
		}
	}
}
