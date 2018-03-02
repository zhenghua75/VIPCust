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
using VCustApp.Entity.EntityClass;
using VCustApp.BusinessFacade;

namespace VCustApp.SysManage
{
	/// <summary>
	/// Summary description for ChangePassword.
	/// </summary>
	public class ChangePassword : wfmBase
	{
		protected System.Web.UI.WebControls.Label lblOldPwd;
		protected System.Web.UI.WebControls.Label lblNewPwd;
		protected System.Web.UI.WebControls.Label lblConfirmPwd;
		protected System.Web.UI.WebControls.TextBox txtNewPwd;
		protected System.Web.UI.WebControls.TextBox txtConfirmPwd;
		protected System.Web.UI.WebControls.ImageButton btnOK;
		protected System.Web.UI.WebControls.ImageButton btnCancel;
		protected System.Web.UI.WebControls.TextBox txtOldPwd;
	
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
			this.btnOK.Click += new System.Web.UI.ImageClickEventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.Web.UI.ImageClickEventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnOK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//确定修改密码
			try
			{
				if (txtOldPwd.Text.Length == 0 || txtNewPwd.Text.Length == 0 || txtConfirmPwd.Text.Length == 0)
				{
					throw new BusinessException("UpdatePwd","不能为空！");
				}
				if (txtOldPwd.Text.Equals(txtNewPwd.Text))
				{
					throw new BusinessException("UpdatePwd","新老密码一样！");
				}
				if (!txtNewPwd.Text.Equals(txtConfirmPwd.Text))
				{
					throw new BusinessException("UpdatePwd","确认密码和新密码不一致！");
				}				
				if (!txtOldPwd.Text.Equals(DataSecurity.Decrypt(oper.cnvcOperPwd)))
				{
					throw new BusinessException("UpdatePwd","输入的旧密码错误！");
				}
				oper.cnvcOperPwd = DataSecurity.Encrypt(txtNewPwd.Text);
				SysManageFacade.UpdatePwd(oper);
				Popup("密码修改成功！");
				//更新会话
				Session[ConstApp.S_OPER] = oper;
			}
			catch (Exception ex)
			{
				Popup(ex.Message);
			}			
		}

		private void btnCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//重置数据
			txtOldPwd.Text = "";
			txtNewPwd.Text = "";
			txtConfirmPwd.Text = "";
		}


//		private void btnOperName_Click(object sender, System.Web.UI.ImageClickEventArgs e)
//		{
//			//修改用户名称			
//			try
//			{
//				oper.cnvcOperName = txtOperName.Text;
//				SysManageFacade.UpdateOperName(oper);				
//				Session[ConstApp.S_OPER] = oper;
//				Popup("用户名称已修改！");
//			}
//			catch (BusinessException bex)
//			{
//				Popup(bex.Message);
//				return;
//			}		
//		}
	}
}
