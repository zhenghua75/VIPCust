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
using VCustApp.Entity.EntityClass;
using VCustApp.BusinessFacade;
namespace VCustApp.BusinessChance
{
	/// <summary>
	/// wfmChanceQuery 的摘要说明。
	/// </summary>
	public class wfmFourChanceQuery : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.TextBox txtProjectName;
		protected System.Web.UI.WebControls.DropDownList ddlChanceType;
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.TextBox txtForecaseIncome;
		protected System.Web.UI.WebControls.ImageButton btnOK;
		protected System.Web.UI.WebControls.ImageButton btnCancel;
		protected System.Web.UI.WebControls.DropDownList ddlChanceType2;
		protected System.Web.UI.WebControls.DropDownList ddlChanceSpeed;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DropDownList ddlTradeMgr;
		protected System.Web.UI.WebControls.DropDownList ddlMgr;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			//BindGrid();
			if(!this.IsPostBack)
			{	
				Response.Expires = 0;
				Response.ExpiresAbsolute = System.DateTime.Now.AddDays(-1);
				Response.CacheControl = "no-cache";

				BindDDL();
				//BindDDL();
				if(oper.cnvcRoleCode == "customer")
				{
					this.BindDropDownList(ddlDept,ConstApp.A_DEPT,"");
					ListItem liDept = ddlDept.Items.FindByValue(oper.cnvcDeptID);
					if(liDept != null)
						liDept.Selected = true;

					this.BindDropDownList(ddlMgr,ConstApp.A_OPER,"cnvcManager='"+oper.cnvcManager+"'");
					ListItem liMgr = ddlMgr.Items.FindByValue(oper.cnvcOperID);
					if(liMgr != null)
						liMgr.Selected = true;
					this.BindDropDownList(ddlTradeMgr,ConstApp.A_OPER,"cnvcRoleCode='trade'");
					ListItem liTrade = ddlTradeMgr.Items.FindByValue(oper.cnvcManager);
					if(liTrade != null)
						liTrade.Selected = true;
					
					ddlMgr.Enabled = false;
					ddlTradeMgr.Enabled = false;
					ddlDept.Enabled = false;
				}
				else if(oper.cnvcRoleCode == "trade")
				{
					this.BindDropDownList(ddlDept,ConstApp.A_DEPT,"");
					ListItem liDept = ddlDept.Items.FindByValue(oper.cnvcDeptID);
					if(liDept != null)
						liDept.Selected = true;
					this.BindDropDownList(ddlTradeMgr,ConstApp.A_OPER,"cnvcRoleCode='trade'");
					ListItem liTrade = ddlTradeMgr.Items.FindByValue(oper.cnvcOperID);
					if(liTrade != null)
						liTrade.Selected = true;					
					this.BindDropDownList(ddlMgr,ConstApp.A_OPER,"cnvcManager='"+oper.cnvcOperID+"' and cnvcDeptID like '"+ddlDept.SelectedValue+"'",new ListItem("所有","%"));
					ddlTradeMgr.Enabled = false;
					ddlDept.Enabled = false;
					ddlMgr.Enabled = true;
				}
				else
				{
					this.BindDropDownList(ddlDept,ConstApp.A_DEPT,"",new ListItem("所有","%"));
					this.BindDropDownList(ddlMgr,ConstApp.A_OPER,"cnvcRoleCode='customer' and cnvcDeptID like '"+ddlDept.SelectedValue+"'",new ListItem("所有","%"));
					this.BindDropDownList(ddlTradeMgr,ConstApp.A_OPER,"cnvcRoleCode='trade' and cnvcDeptID like '"+ddlDept.SelectedValue+"'",new ListItem("所有","%"));

					ddlTradeMgr.Enabled = true;
					ddlDept.Enabled = true;
					ddlMgr.Enabled = true;
				}
			}
		}

		private void BindDDL()
		{
			//this.BindDropDownList(ddlDept,ConstApp.A_DEPT,"",new ListItem("所有","%"));
			this.BindDropDownList(ddlChanceType,ConstApp.A_NAMECODE,"cnvcType='CHANCE_TYPE'",new ListItem("所有","%"));
			this.BindDropDownList(ddlChanceType2,ConstApp.A_NAMECODE,"cnvcType like '"+ddlChanceType.SelectedValue+"' and cnvcType in ( 'QUESTION', 'VALUE')",new ListItem("所有","%"));
			//this.BindDropDownList(ddlMgr,ConstApp.A_OPER,"cnvcDeptID like '"+ddlDept.SelectedValue+"'",new ListItem("所有","%"));
			//this.BindDropDownList(ddlTradeMgr,ConstApp.A_OPER,"cnvcDeptID like '"+ddlDept.SelectedValue+"'",new ListItem("所有","%"));
			this.BindDropDownList(ddlChanceSpeed,ConstApp.A_NAMECODE,"cnvcType='CHANCE_SPEED'",new ListItem("所有","%"));
			
		}
		private void BindGrid()
		{
			string strSql = "select a.*,b.cnvcName as cnvcCustName,'' as cnvcCustomTradeMgr from tbProject a ";
			strSql += " left outer join tbCust b on a.cnnCustID=b.cnnCustID" ;
			strSql += " where a.cnvcDeptID like '"+ddlDept.SelectedValue+"' and a.cnvcMgr like '"+ddlMgr.SelectedValue+"' ";
			strSql += " and a.cnvcChanceType like  '"+ddlChanceType2.SelectedValue+"'";
			strSql += " and a.cnvcTradeMgr like '"+ddlTradeMgr.SelectedValue+"'";
			if(txtProjectName.Text != "")
				strSql += " and a.cnvcChanceName like '%"+txtProjectName.Text+"%'";
			if(txtForecaseIncome.Text != "")
				strSql += " and a.cnnForecastIncome > ="+txtForecaseIncome.Text;
			//if(txtChanceSpeed.Text != "")
				strSql += " and a.cnvcChanceSpeed like '"+ddlChanceSpeed.SelectedValue+"'";
			if(txtCustName.Text != "")
				strSql += " and b.cnvcName like '%"+txtCustName.Text+"%'";

			DataTable dtChance = Helper.Query(strSql);

			this.DataTableConvert(dtChance,"cnvcDeptID",ConstApp.A_DEPT,"");
			this.DataTableConvert(dtChance,"cnvcMgr",ConstApp.A_OPER,"");
			this.DataTableConvert(dtChance,"cnvcTradeMgr",ConstApp.A_OPER,"");
			//cnvcCustomTradeMgr
			this.DataTableConvert(dtChance,"cnvcChanceType",ConstApp.A_NAMECODE,"cnvcType in ( 'QUESTION', 'VALUE')");
			this.DataTableConvert(dtChance,"cnvcProjectState",ConstApp.A_NAMECODE,"cnvcType = 'PROJECT_STATE'");
			this.DataTableConvert(dtChance,"cnvcChanceSpeed",ConstApp.A_NAMECODE,"cnvcType = 'CHANCE_SPEED'");
			this.DataTableConvert(dtChance,"cnvcIsSucess",ConstApp.A_NAMECODE,"cnvcType='YES_NO'");
			foreach(DataRow dr in dtChance.Rows)
			{
				dr["cnvcCustomTradeMgr"] = dr["cnvcMgrComments"].ToString()+"/"+dr["cnvcTradeMgrComments"].ToString();
			}
			this.DataGrid1.DataSource = dtChance;
			this.DataGrid1.DataBind();

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
			this.btnOK.Click += new System.Web.UI.ImageClickEventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.Web.UI.ImageClickEventHandler(this.btnCancel_Click);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

//		private void btnAddChance_Click(object sender, System.EventArgs e)
//		{
//			this.Response.Redirect("wfmAddChance.aspx");
//		}

		private void ddlDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//this.BindDropDownList(ddlMgr,ConstApp.A_OPER,"cnvcDeptID='"+ddlDept.SelectedValue+"'",new ListItem("所有","%"));
			this.BindDropDownList(ddlMgr,ConstApp.A_OPER,"cnvcRoleCode='customer' and cnvcDeptID='"+ddlDept.SelectedValue+"'",new ListItem("所有","%"));
			this.BindDropDownList(ddlTradeMgr,ConstApp.A_OPER,"cnvcRoleCode='trade' and cnvcDeptID='"+ddlDept.SelectedValue+"'",new ListItem("所有","%"));
		}

		private void ddlChanceType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.BindDropDownList(ddlChanceType2,ConstApp.A_NAMECODE,"cnvcType like '"+ddlChanceType.SelectedValue+"' and cnvcType in ('QUESTION','VALUE')");
		}

		private void btnAdd_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Response.Redirect("wfmAddChance.aspx");
		}

		private void btnOK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.BindGrid();
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
			this.BindGrid();
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
//			try
//			{
//				if(e.CommandName == "Read")
//				{
//					string strSql = "select * from tbProject where cnnProjectID="+e.Item.Cells[1].Text;
//					DataTable dtProject = Helper.Query(strSql);
//					if(dtProject.Rows.Count > 0)
//					{						
//						Project project = new Project(dtProject);
//						if(project.cnvcProjectState != "P001")
//						{
//							throw new Exception("商机不在发布状态");
//						}
//						if(project.cnvcMgr != oper.cnvcOperID)
//							throw new Exception("只有客户经理才可以收阅");
//						project.cnvcProjectState = "P002";
//						ChanceFacade.UpdateProject(project,oper);
//						//Popup("已收阅");
//						this.BindGrid();
//					}
//				}
//			}
//			catch(Exception ex)
//			{
//				Popup(ex.Message);
//			}
		}

		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
//			try
//			{
//				if(!e.Item.Cells[8].Text.Equals("否"))
//					throw new Exception("商机已转化无法删除");					
//				Project project = new Project();
//				project.cnnProjectID = Convert.ToDecimal(e.Item.Cells[1].Text);
//				ChanceFacade.DeleteProject(project,oper);
//				this.BindGrid();
//			}
//			catch(Exception ex)
//			{
//				Popup(ex.Message);
//			}
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
//			if(e.Item.ItemType == ListItemType.Item ||e.Item.ItemType == ListItemType.AlternatingItem)
//			{								
//				LinkButton btnDelete = (LinkButton)(e.Item.Cells[15].Controls[0]);
//				btnDelete.Attributes.Add("onClick","JavaScript:return confirm('确定删除？')");
//			} 
		}

		private void btnCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.txtCustName.Text = "";
			this.txtForecaseIncome.Text = "";
			this.txtProjectName.Text = "";			
			this.DataGrid1.DataSource = null;
			this.DataGrid1.DataBind();
		}

		private void ddlTradeMgr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.BindDropDownList(ddlMgr,ConstApp.A_OPER,"cnvcManager like '"+ddlTradeMgr.SelectedValue+"' and cnvcDeptID like '"+ddlDept.SelectedValue+"'",new ListItem("所有","%"));
		}
	}
}
