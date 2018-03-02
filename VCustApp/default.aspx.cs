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
namespace VCustApp
{
	/// <summary>
	/// Summary description for _default.
	/// </summary>
	public class _default : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox txtLoginID;
		protected System.Web.UI.WebControls.TextBox txtPwd;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtMACAddr;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtIPAddr;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtDNSName;
	
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void Button1_Click(object sender, System.EventArgs e)
		{
			
			try
			{				
				Oper oper = LoginFacade.IsUser(txtLoginID.Text,txtPwd.Text);
//				ArrayList list = Application["GLOBAL_USER_LIST"] as ArrayList;
//				if (list == null)
//　　			{
//　　				list = new ArrayList();
//　　			}
//　　			for (int i = 0; i < list.Count; i++)
//　　			{
//　　				if (txtLoginID.Text == (list[i] as string))
//　　				{
//　　					//已经登录了，提示错误信息
//						throw new Exception("此用户已经登录");　　					
//　　				}
//　　			}
//　　			list.Add(txtLoginID.Text); 
//				Application["GLOBAL_USER_LIST"]  = list;
				Session[ConstApp.S_OPER] = oper; 
				Response.Redirect("wfmMain.aspx",false);
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}

		//弹出窗口
		private void Popup(string strComments)
		{
			this.Response.Write("<script>alert('"+strComments+"');</script>");
		}
	}
}
