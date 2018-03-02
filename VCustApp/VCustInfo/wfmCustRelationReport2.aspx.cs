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

namespace VCustApp.VCustInfo
{
	/// <summary>
	/// wfmCustRelationReport2 的摘要说明。
	/// </summary>
	public class wfmCustRelationReport2 : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtCustID;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnExcel;
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
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindGrid()
		{
			string strCustID=this.txtCustID.Text.Trim();
			string strCustName=this.txtCustName.Text.Trim();
			string strCondition="";
			if(strCustID!="")
			{
				strCondition=" and a.cnnCustID = "+strCustID+"";
			}
			if(strCustName!="")
			{
				strCondition+=" and a.cnvcName like '%"+strCustName+"%'";
			}
			switch(oper.cnvcRoleCode)
			{
				case "customer":
					strCondition+=" and a.cnvcCustMana='"+oper.cnvcOperID+"'";
					break;
				case "trade":
					strCondition+=" and a.cnvcCustTradeMana='"+oper.cnvcOperID+"'";
					break;
				case "admin":
					break;
				case "manager":
					break;
				default:
					strCondition+=" and 1=2";
					break;
			}
			string strsql="select a.cnnCustID,a.cnvcName,a.cnvcTradeType,a.cnvcLevel,b.cnvcName as cnvcLinkName,b.cnvcSex,b.cndBirthday,b.cnvcEducation,b.cnvcLinkType,b.cnvcDeptName,b.cnvcRelativeDeptType,b.cnvcDuty,b.cnvcJob,b.cnvcPhone,b.cnvcMobilePhone,b.cnvcEmail,b.cnvcLike,b.cnvcAddress from tbCust a,tbLink b where a.cnnCustID=b.cnnCustID "+strCondition;

			DataTable dtout=Helper.Query(strsql);
			this.DataTableConvert(dtout,"cnvcTradeType",ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE'");
			this.DataTableConvert(dtout,"cnvcLevel",ConstApp.A_NAMECODE,"cnvcType='CUST_LEVEL'");
			this.DataTableConvert(dtout,"cnvcSex",ConstApp.A_NAMECODE,"cnvcType='SEX_TYPE'");
			this.DataTableConvert(dtout,"cnvcEducation",ConstApp.A_NAMECODE,"cnvcType='EDUCATION_TYPE'");
			this.DataTableConvert(dtout,"cnvcLinkType",ConstApp.A_NAMECODE,"cnvcType='LINK_TYPE'");
			this.DataTableConvert(dtout,"cnvcRelativeDeptType",ConstApp.A_NAMECODE,"cnvcType='DEPT_TYPE'");
			this.DataGrid1.DataSource=dtout;
			this.DataGrid1.DataBind();
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			this.BindGrid();
		}

		private void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.DataGrid1.CurrentPageIndex=e.NewPageIndex;
			this.BindGrid();
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			this.DataGridToExcel(this.DataGrid1,"客户关系维护报表");
		}

		public override void VerifyRenderingInServerForm(Control control)
		{
			// Confirms that an HtmlForm control is rendered for
		} 
	}
}
