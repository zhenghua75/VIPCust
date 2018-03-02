using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using VCustApp.Common;
using VCustApp.BusinessFacade;
using VCustApp.Entity.EntityClass;
using Dundas.Charting.WebControl;
namespace VCustApp.BusinessChance
{
	/// <summary>
	/// wfmSalesFunnel 的摘要说明。
	/// </summary>
	public class wfmSalesFunnel : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtBeginDate;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.ImageButton btnOK;
		protected Dundas.Charting.WebControl.Chart Chart1;
		protected Dundas.Charting.WebControl.Chart Chart2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.DropDownList ddlTradeMgr;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.DropDownList ddlMgr;
		protected System.Web.UI.WebControls.TextBox txtChanceSpeed;
		protected System.Web.UI.WebControls.ImageButton btnCancel;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!this.IsPostBack)
			{
				//				this.BindDropDownList(ddlDept,ConstApp.A_DEPT,"",new ListItem("所有","%"));
				//				BindDropDownList(ddlTradeMgr,ConstApp.A_OPER,"cnvcRoleCode='trade' and cnvcDeptID like '"+ddlDept.SelectedValue+"'",new ListItem("所有","%"));
				//				BindDropDownList(ddlTradeMgr,ConstApp.A_OPER,"cnvcRoleCode='customer' and cnvcDeptID like '"+ddlDept.SelectedValue+"'",new ListItem("所有","%"));

				Response.Expires = 0;
				Response.ExpiresAbsolute = System.DateTime.Now.AddDays(-1);
				Response.CacheControl = "no-cache";

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
			else
			{
				if(Request["__EVENTTARGET"] != null) 
				{

					string strgrid = Request["__EVENTTARGET"].ToString();
					if(strgrid == "bindgrid")
					{
						if(Request["__EVENTARGUMENT"] != null)
						{
							string strChanceSpeed = Request["__EVENTARGUMENT"].ToString();
							txtChanceSpeed.Text = strChanceSpeed;
							BindChart();
							BindGrid(strChanceSpeed);
							
						}
					}
				}
			}
		}

		private void BindChart()
		{
			string strSql1= "select cnvcChanceSpeed,count(*) as cnnChanceCount,sum(cnnForecastIncome) as cnnChanceSum,0 as cnnRate,0 as cnnSumRate ,'' as cnvcComments from tbProject where cnvcDeptID like '"+ddlDept.SelectedValue+"'";
			strSql1 += " and cnvcMgr like '"+ddlMgr.SelectedValue+"'";
			strSql1 += " and cnvcTradeMgr like '"+ddlTradeMgr.SelectedValue+"'";
			if(txtBeginDate.Text != "")
				strSql1 += " and convert(char(10),cndChanceDate,121)>='"+txtBeginDate.Text+"'";
			if(txtEndDate.Text != "")
				strSql1 += " and convert(char(10),cndChanceDate,121)<='"+txtEndDate.Text+"'";
			strSql1 += " group by cnvcChanceSpeed";

			string strSql2= "select count(*) as cnnCount from tbProject where 1=1 ";
			strSql2 += " and cnvcMgr like '"+ddlMgr.SelectedValue+"'";
			strSql2 += " and cnvcTradeMgr like '"+ddlTradeMgr.SelectedValue+"'";
			if(txtBeginDate.Text != "")
				strSql2 += " and convert(char(10),cndChanceDate,121)>='"+txtBeginDate.Text+"'";
			if(txtEndDate.Text != "")
				strSql2 += " and convert(char(10),cndChanceDate,121)<='"+txtEndDate.Text+"'";
			
			string strSql3 = "select sum(cnnForecastIncome) as cnnSum from tbProject where 1=1 ";
			strSql3 += " and cnvcMgr like '"+ddlMgr.SelectedValue+"'";
			strSql3 += " and cnvcTradeMgr like '"+ddlTradeMgr.SelectedValue+"'";
			if(txtBeginDate.Text != "")
				strSql3 += " and convert(char(10),cndChanceDate,121)>='"+txtBeginDate.Text+"'";
			if(txtEndDate.Text != "")
				strSql3 += " and convert(char(10),cndChanceDate,121)<='"+txtEndDate.Text+"'";

			DataTable dtChance = Helper.Query(strSql1);
			DataTable dtChance2 = Helper.Query(strSql2);
			DataTable dtChance3 = Helper.Query(strSql3);
			
			double dCount = 1;
			double dSum = 0.00;
			if(dtChance2.Rows.Count > 0)
			{
				string strCount = dtChance2.Rows[0]["cnnCount"].ToString();
				if(strCount!="")
				{
					dCount = Convert.ToDouble(strCount);
					if(dCount == 0)
					{
						dCount =1;
					}
				}
			}
			if(dtChance3.Rows.Count > 0)
			{
				string strSum = dtChance3.Rows[0]["cnnSum"].ToString();
				if(strSum!="")
				{
					dSum = Convert.ToDouble(strSum);
					if(dSum == 0)
					{
						dSum =1;
					}
				}
			}
			foreach(DataRow drChance in dtChance.Rows)
			{
				double dChanceCount = Convert.ToDouble(drChance["cnnChanceCount"]);
				double dRate = Math.Round(dChanceCount/dCount*100,2);
				drChance["cnnRate"] = dRate;

				double dChanceSum = Convert.ToDouble(drChance["cnnChanceSum"]);
				double dSumRate = Math.Round(dChanceSum/dSum*100,2);
				drChance["cnnSumRate"] = dSumRate;
			}
			this.DataTableConvert(dtChance,"cnvcChanceSpeed",ConstApp.A_NAMECODE,"cnvcType='CHANCE_SPEED'");
			//dtChance.Columns.Remove("cnvcChanceSpeed");
			foreach(DataRow dr in dtChance.Rows)
			{
				Dundas.Charting.WebControl.DataPoint dp = new Dundas.Charting.WebControl.DataPoint();
				dp.XValue = Convert.ToDouble(dr["cnnChanceCount"]);
				dp.YValues[0] = Convert.ToDouble(dr["cnnRate"]);
				dp.Label = "商机数："+dr["cnnChanceCount"].ToString()+"\n比例："+dr["cnnRate"].ToString()+"%";
				dp.LegendText = dr["cnvcChanceSpeedComments"].ToString();
				dp.LegendHref = "javascript:__doPostBack('bindgrid','"+dr["cnvcChanceSpeed"].ToString()+"');";
				
				Chart1.Series["Series1"].Points.Add(dp);

				Dundas.Charting.WebControl.DataPoint dp2 = new Dundas.Charting.WebControl.DataPoint();
				dp2.XValue = Convert.ToDouble(dr["cnnChanceSum"]);
				dp2.YValues[0] = Convert.ToDouble(dr["cnnSumRate"]);
				dp2.Label = "金额："+dr["cnnChanceSum"].ToString()+"万元\n比例："+dr["cnnSumRate"].ToString()+"%";
				dp2.LegendText = dr["cnvcChanceSpeedComments"].ToString();
				dp2.LegendHref = "javascript:__doPostBack('bindgrid','"+dr["cnvcChanceSpeed"].ToString()+"');";

				Chart2.Series["Series1"].Points.Add(dp2);
		
			}		


			Chart1.Series[0]["FunnelPointGap"] = "5";
			Chart2.Series[0]["FunnelPointGap"] = "5";

			this.DataGrid1.DataSource = null;
			this.DataGrid1.DataBind();

		}

		private void BindGrid(string strChanceSpeed)
		{
			string strSql = "select a.*,b.cnvcName as cnvcCustName,'' as cnvcCustomTradeMgr from tbProject a ";
			strSql += " left outer join tbCust b on a.cnnCustID=b.cnnCustID" ;
			strSql += " where a.cnvcMgr like '"+ddlMgr.SelectedValue+"'";
			strSql += " and a.cnvcTradeMgr like '"+ddlTradeMgr.SelectedValue+"'";
			strSql += " and a.cnvcChanceSpeed='"+strChanceSpeed+"'";
			if(txtBeginDate.Text != "")
				strSql += " and convert(char(10),a.cndChanceDate,121)>='"+txtBeginDate.Text+"'";
			if(txtEndDate.Text != "")
				strSql += " and convert(char(10),a.cndChanceDate,121)<='"+txtEndDate.Text+"'";

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
			this.ddlTradeMgr.SelectedIndexChanged += new System.EventHandler(this.ddlTradeMgr_SelectedIndexChanged);
			this.btnOK.Click += new System.Web.UI.ImageClickEventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.Web.UI.ImageClickEventHandler(this.btnCancel_Click);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//取消
			this.txtBeginDate.Text = "";
			this.txtEndDate.Text = "";

			this.DataGrid1.DataSource = null;
			this.DataGrid1.DataBind();
		}

		private void btnOK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.BindChart();
		}

		private void ddlDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.BindDropDownList(ddlMgr,ConstApp.A_OPER,"cnvcRoleCode='customer' and cnvcDeptID='"+ddlDept.SelectedValue+"'",new ListItem("所有","%"));
			this.BindDropDownList(ddlTradeMgr,ConstApp.A_OPER,"cnvcRoleCode='trade' and cnvcDeptID='"+ddlDept.SelectedValue+"'",new ListItem("所有","%"));

		}

		private void ddlTradeMgr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.BindDropDownList(ddlMgr,ConstApp.A_OPER,"cnvcManager like '"+ddlTradeMgr.SelectedValue+"' and cnvcDeptID like '"+ddlDept.SelectedValue+"'",new ListItem("所有","%"));
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
			this.BindGrid(txtChanceSpeed.Text);
		}
	}
}
