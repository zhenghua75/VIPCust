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
	/// Summary description for wfmVisitInfo.
	/// </summary>
	public class wfmVisitInfo : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtCustID;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtProjectName;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			string strCustID=this.txtCustID.Text.Trim();
			string strCustName=this.txtCustName.Text.Trim();
			string strProject=this.txtProjectName.Text.Trim();
			string strCondition="";
			if(strCustID!="")
			{
				strCondition=" and b.cnnCustID="+strCustID;
			}
			if(strCustName!="")
			{
				strCondition+=" and a.cnvcName like '%"+strCustName+"%'";
			}
			if(strProject!="")
			{
				strCondition+=" and b.cnvcProjectName like '%"+strProject+"%'";
			}
			string strsql="select a.cnnCustID,a.cnvcName,b.cnnProjectID,b.cnvcProjectName,b.cnvcMgr from tbCust a,tbProject b where a.cnnCustID=b.cnnCustID ";
			DataTable dtout=Helper.Query(strsql);
			this.DataGrid1.DataSource=dtout;
			this.DataGrid1.DataBind();
		}

		private void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if(e.CommandName=="Select")
			{
				TableCell tcCustid=e.Item.Cells[0];
				TableCell tcProjectid=e.Item.Cells[2];
				Response.Redirect("wfmVisitDetail.aspx?cid="+tcCustid.Text+"&&pid="+tcProjectid.Text);
			}
		}
	}
}
