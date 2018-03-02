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
	/// wfmEndChance 的摘要说明。
	/// </summary>
	public class wfmEndChance : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.TextBox txtCustID;
		protected System.Web.UI.WebControls.TextBox txtProjectID;
		protected System.Web.UI.WebControls.TextBox txtProjectName;
		protected System.Web.UI.WebControls.DropDownList ddlChanceType;
		protected System.Web.UI.WebControls.DropDownList ddlChanceType2;
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.TextBox txtForecastIncome;
		protected System.Web.UI.WebControls.DropDownList ddlChanceSpeed;
		protected System.Web.UI.WebControls.DropDownList ddlMgr;
		protected System.Web.UI.WebControls.TextBox txtComments;
		protected System.Web.UI.WebControls.TextBox txtSucessDate;
		protected System.Web.UI.WebControls.TextBox txtSucessIncome;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtChanceDate;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.DropDownList ddlTradeMgr;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.TextBox txtContractNo;
		protected System.Web.UI.WebControls.TextBox txtProjectName2;
		protected System.Web.UI.WebControls.Label Label1;
	
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

				this.BindDropDownList(ddlMgr,ConstApp.A_OPER,"cnvcDeptID like '"+ddlDept.SelectedValue+"'");
				ListItem liMgr = ddlMgr.Items.FindByValue(project.cnvcMgr);
				if(liMgr != null)
					liMgr.Selected = true;
				this.BindDropDownList(ddlTradeMgr,ConstApp.A_OPER,"cnvcDeptID like '"+ddlDept.SelectedValue+"'");
				ListItem liTradeMgr = ddlTradeMgr.Items.FindByValue(project.cnvcMgr);
				if(liTradeMgr != null)
					liTradeMgr.Selected = true;
				txtChanceDate.Text = project.cndChanceDate.ToString("yyyy-MM-dd");
				txtComments.Text = project.cnvcComments;
			
				txtContractNo.Text = project.cnvcContractNo;
				txtProjectName2.Text = project.cnvcProjectName;
				if(project.cndSucessDate == DateTime.MinValue)
					txtSucessDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
				else
					txtSucessDate.Text = project.cndSucessDate.ToString("yyyy-MM-dd");
				txtSucessIncome.Text = project.cnnSucessIncome.ToString();
			}
			this.RegisterStartupScript("hide","<script lanaguage=javascript>ShowHide('1','none');</script>");
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(!this.JudgeIsNum(txtSucessIncome.Text,"转化收入"))
					return;
				if(this.JudgeIsNull(txtSucessDate.Text,"转化时间"))
					return;
				DataTable dtProject = Helper.Query("select * from tbProject where cnnProjectID="+txtProjectID.Text);
				Project project = new Project(dtProject);
				
				if(project.cnvcMgr != oper.cnvcOperID && project.cnvcTradeMgr != oper.cnvcOperID && project.cnvcOperID != oper.cnvcOperID)
				{
					throw new Exception("只有客户经理或者行业经理才可以转化");
				}
				if (this.txtContractNo.Text.Trim()==""|| this.txtProjectName2.Text.Trim()==""||this.txtSucessIncome.Text.Trim()=="0")
				{
					throw new Exception("请如实填写客户信息转化，有为空信息");
				}
				string strSucess = project.cnvcIsSucess;
				if(project.cnvcIsSucess != "0")
				{
					throw new Exception("商机已转化,不能再次操作！");
				}
				project.cnvcIsSucess = "1";
				project.cnvcProjectName = txtProjectName2.Text;
				project.cnvcContractNo = txtContractNo.Text;
				project.cndSucessDate = Convert.ToDateTime(txtSucessDate.Text);
				project.cnnSucessIncome = Convert.ToDecimal(txtSucessIncome.Text);
				project.cnvcProjectState = "P004";
				ChanceFacade.UpdateProject(project,oper);
				if(strSucess == "0")
					Popup("商机转化成功");	
				else
					Popup("商机转化信息修改成功");
				//this.CleanCtrl();
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("wfmChanceQuery.aspx");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			txtSucessDate.Text = "";
			txtSucessIncome.Text = "";
			txtProjectName2.Text = "";
			txtContractNo.Text = "";
		}
	}
}
