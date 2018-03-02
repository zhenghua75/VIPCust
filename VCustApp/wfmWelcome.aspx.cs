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
	/// Summary description for wfmWelcome.
	/// </summary>
	public class wfmWelcome : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblwel;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
//			if(Session["Login"]==null)
//			{
//				Response.Redirect("Exit.aspx");
//			}
			this.lblwel.Text="欢迎进入大客户管理系统";
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
