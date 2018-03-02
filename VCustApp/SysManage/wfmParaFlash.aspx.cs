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
namespace VCustApp.SysManage
{
	/// <summary>
	/// wfmParaFlash 的摘要说明。
	/// </summary>
	public class wfmParaFlash : wfmBase
	{
		protected System.Web.UI.WebControls.Button btnOK;
	
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
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnOK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				Helper.LoadInitCode(Application);
				Popup("参数刷新成功");
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				Helper.LoadInitCode(Application);
				Popup("参数刷新成功");
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}
	}
}
