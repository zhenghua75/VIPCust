using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using VCustApp.BusinessFacade;
namespace VCustApp 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
			Helper.LoadInitCode(this.Application);
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{
			//在会话结束时运行的代码。
　　		// 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
　　		// InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer
　　		// 或 SQLServer，则不会引发该事件。
//　　		VCustApp.Entity.EntityClass.Oper oper = Session[VCustApp.Common.ConstApp.S_OPER] as VCustApp.Entity.EntityClass.Oper;
//　　		ArrayList list = Application["GLOBAL_USER_LIST"] as ArrayList;
//　　		if (oper.cnvcOperID != null && list != null)
//　　		{
//　　			list.Remove(oper.cnvcOperID);
//　　			Application["GLOBAL_USER_LIST"] = list;
//　　		} 
		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

