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

namespace VCustApp
{
	/// <summary>
	/// Summary description for wfmMainTop.
	/// </summary>
	public class wfmMainTop : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lbloper;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.HtmlControls.HtmlTableRow trVCustInfo;
		protected System.Web.UI.WebControls.HyperLink trVisitInfo;
		protected System.Web.UI.HtmlControls.HtmlTableRow trCustRelationReport1;
		protected System.Web.UI.HtmlControls.HtmlTableRow trCustRelationReport2;
		protected System.Web.UI.HtmlControls.HtmlTableRow trCustRelationDeepReport;
		protected System.Web.UI.HtmlControls.HtmlTableRow trVisit;
		protected System.Web.UI.HtmlControls.HtmlTableRow trChanceQuery;
		protected System.Web.UI.HtmlControls.HtmlTableRow trChanceReport;
		protected System.Web.UI.HtmlControls.HtmlTableRow trSalesFunnel;
		protected System.Web.UI.HtmlControls.HtmlTableRow trDeptQuery;
		protected System.Web.UI.HtmlControls.HtmlTableRow trOperQuery;
		protected System.Web.UI.HtmlControls.HtmlTableRow trChangePassword;
		protected System.Web.UI.HtmlControls.HtmlTableRow trParaFlash;
		protected System.Web.UI.HtmlControls.HtmlTableRow trVCustLink;
		protected System.Web.UI.WebControls.Label lblDept;
		protected System.Web.UI.HtmlControls.HtmlTableRow trHel;
		protected System.Web.UI.HtmlControls.HtmlTableRow trHelp;
		protected System.Web.UI.HtmlControls.HtmlTableRow trSaleCost;
		protected System.Web.UI.HtmlControls.HtmlTableRow trAdvancePayment;
		protected System.Web.UI.HtmlControls.HtmlTableRow trAccountReceivable;
		protected System.Web.UI.HtmlControls.HtmlTableRow trFourChanceQuery;
		protected bool Condition=false;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			//DateTime dtnow=DateTime.Now;
			//this.Label1.Text= "部门："+dept.cnvcDeptName;
			
			this.lblDept.Text="部门："+dept.cnvcDeptName;
			this.lbloper.Text="操作员："+oper.cnvcOperName;
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	}
}
