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
	/// Summary description for wfmVisitDetail.
	/// </summary>
	public class wfmVisitDetail : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtCustID;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.TextBox txtMgr;
		protected System.Web.UI.WebControls.TextBox txtProjectName;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtProjectID;
		protected System.Web.UI.WebControls.Button Button1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!this.IsPostBack)
			{
				string strCustid=Request.QueryString["cid"];
				string strProjectid=Request.QueryString["pid"];
				txtCustID.ReadOnly=true;
				txtCustName.ReadOnly=true;
				txtProjectName.ReadOnly=true;
				txtMgr.ReadOnly=true;

				if(strCustid==null||strCustid==""||strProjectid==null||strProjectid=="")
				{
					Popup("客户及项目信息错误！");
					Response.Write("<script>window.history.back();</script>");
					return;
				}

				DataTable dtbaseinfo=Helper.Query("select a.cnnCustID,a.cnvcName,b.cnvcProjectName,b.cnvcMgr from tbCust a,tbProject b where a.cnnCustID=b.cnnCustID and a.cnnCustID="+strCustid+" and b.cnnProjectID="+strProjectid);
				DataTable dtVisit=Helper.Query("select * from tbVisit where cnnCustID="+strCustid+ "and cnnProjectID="+strProjectid);
				if(dtbaseinfo==null||dtbaseinfo.Rows.Count==0)
				{
					Popup("查询出错，请重试！");
					Response.Write("<script>window.history.back();</script>");
					return;
				}
				else
				{
					this.txtCustID.Text=strCustid;
					this.txtProjectID.Text=strProjectid;
					this.txtCustName.Text=dtbaseinfo.Rows[0]["cnvcName"].ToString();
					this.txtProjectName.Text=dtbaseinfo.Rows[0]["cnvcProjectName"].ToString();
					this.txtMgr.Text=dtbaseinfo.Rows[0]["cnvcMgr"].ToString();

					this.DataTableConvert(dtVisit,"cnvcVisitContent",ConstApp.A_NAMECODE,"cnvcType in('COMPETE','SERVICE')");
					this.DataTableConvert(dtVisit,"cnvcWellType",ConstApp.A_NAMECODE,"cnvcType='WELL_TYPE'");
					this.DataGrid1.DataSource=dtVisit;
					this.DataGrid1.DataBind();
				}
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("wfmVisitInfo.aspx");
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			string strCustID=this.txtCustID.Text.Trim();
			string strProjectID=this.txtProjectID.Text.Trim();
			Response.Redirect("wfmVisitAddMod.aspx?type=add&&cid="+strCustID+"&&pid="+strProjectID);
		}
	}
}
