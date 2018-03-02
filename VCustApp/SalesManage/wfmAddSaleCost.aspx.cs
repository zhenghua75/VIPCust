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
	public class wfmAddSaleCost : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCustID;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.ImageButton btnOK;
		protected System.Web.UI.WebControls.ImageButton btnCance;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtQueryCustID;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtQueryCustName;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlYear;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.TextBox txtBudgetCost;
		protected System.Web.UI.WebControls.TextBox txtRealSaleCost;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!this.IsPostBack)
			{
				int curyear=DateTime.Now.Year;
				int addyear=0;
				for(int i=-3;i<=3;i++)
				{
					addyear=curyear+i;
					this.ddlYear.Items.Add(new ListItem(addyear.ToString(),addyear.ToString()));
				}
				this.ddlYear.SelectedIndex=3;
				this.RegisterStartupScript("hide","<script lanaguage=javascript>ShowHide('1','none');</script>");
			}
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
			this.btnOK.Click += new System.Web.UI.ImageClickEventHandler(this.btnOK_Click);
			this.btnCance.Click += new System.Web.UI.ImageClickEventHandler(this.btnCance_Click);
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCance_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Response.Redirect("wfmSaleCost.aspx");
		}

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

		private void btnOK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(txtCustID.Text.Trim()==""||this.ddlYear.SelectedValue=="")
				{
					Popup("请选择客户和年份！");
					return;
				}
				string strSql = "select * from tbSaleCost where cnnCustID = "+txtCustID.Text.Trim()+" and cnvcYear='"+this.ddlYear.SelectedValue+"'";
				DataTable dt = Helper.Query(strSql);
				if( dt.Rows.Count > 0)
				{
					Popup("本销售成本存在冲突");
					return;
				}

				if(this.JudgeIsNull(txtCustName.Text.Trim(),"客户名称"))
					return;
				if(this.JudgeIsNull(txtBudgetCost.Text.Trim(),"预算销售成本")||!this.JudgeIsNum(txtBudgetCost.Text.Trim(),"预算销售成本"))
					return;
				if(this.JudgeIsNull(txtRealSaleCost.Text.Trim(),"实际销售成本合计")||!this.JudgeIsNum(txtRealSaleCost.Text.Trim(),"实际销售成本合计"))
					return;
				
				SaleCost cost=new SaleCost();
				cost.cnnCustID=decimal.Parse(txtCustID.Text.Trim());
				cost.cnvcCustName=txtCustName.Text.Trim();
				cost.cnvcYear=ddlYear.SelectedValue;
				cost.cnnBudgetCost=decimal.Parse(txtBudgetCost.Text.Trim());
				cost.cnnRealSaleCost=decimal.Parse(txtRealSaleCost.Text.Trim());

				SalesManageFacade.AddSaleCost(cost,oper);
				Popup("销售成本添加成功");
				this.txtCustID.Text = "";
				this.txtCustName.Text = "";
				this.txtBudgetCost.Text = "";
				this.txtRealSaleCost.Text = "";
				
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}
	}
}
