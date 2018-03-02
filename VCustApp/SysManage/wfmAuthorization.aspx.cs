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
using VCustApp.Entity.EntityClass;
using VCustApp.Common;

namespace VCustApp.SysManage
{
	/// <summary>
	/// Summary description for wfmAuthorization.
	/// 权限修改
	/// </summary>
	public class wfmAuthorization : wfmBase
	{
		protected System.Web.UI.WebControls.ImageButton btnOK;
		protected System.Web.UI.WebControls.ImageButton btnCancel;
		protected System.Web.UI.WebControls.TextBox txtOperID;
		protected System.Web.UI.WebControls.CheckBoxList cblFunctionList;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				//初始化操作员列表
				if(Request["cnvcOperID"] == null)
				{
					Popup("无效链接");
					return;
				}
				txtOperID.Text = Request["cnvcOperID"].ToString();
				FillFunctionCbl();
				rblOper_SelectedIndexChanged(null,null);
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
			this.btnOK.Click += new System.Web.UI.ImageClickEventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.Web.UI.ImageClickEventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void rblOper_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				//更新功能类别
				//清楚已选择的功能
				foreach (ListItem liFunctionList in this.cblFunctionList.Items)
				{
					if (liFunctionList.Selected)
					{
						liFunctionList.Selected = false;
					}
				}
				//选择的操作员
				string strOperID = txtOperID.Text;
				//查询某操作员已具有的功能
				DataTable dtOperFunction = Helper.Query("select * from tbOperFunc where cnvcOperID='"+strOperID+"'");

				foreach (ListItem liFunctionList in this.cblFunctionList.Items)
				{					
					foreach (DataRow drOperFunction in dtOperFunction.Rows)
					{
						if (drOperFunction["cnvcFuncCode"].ToString().Equals(liFunctionList.Value))
						{
							liFunctionList.Selected = true;
						}
					}
				}
			}
			catch (BusinessException bex)
			{
				Popup(bex.Message);
			}
			

		}

//		private void FillOperRbl()
//		{			
//			try
//			{
//				DataTable dtAllOper = Helper.Query("select * from tbOper");
//
//				rblOper.DataSource = dtAllOper;
//				rblOper.DataTextField = "cnvcOperName";
//				rblOper.DataValueField = "cnvcOperID";
//
//				rblOper.DataBind();
//			}
//			catch (BusinessException bex)
//			{
//				Popup(bex.Message);
//			}
//			
//		}

		private void FillFunctionCbl()
		{
			try
			{
				DataTable dtFunc = (DataTable)Application[ConstApp.A_FUNC];//Helper.Query("select * from tbFunc");

				cblFunctionList.DataSource = dtFunc;
				cblFunctionList.DataTextField = "cnvcFuncName";
				cblFunctionList.DataValueField = "cnvcFuncCode";		

				cblFunctionList.DataBind();
			}
			catch (BusinessException bex)
			{
				Popup(bex.Message);
			}
			
		}

		private void btnCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//初始化操作员和功能列表
//			foreach (ListItem liOper in rblOper.Items)
//			{
//				liOper.Selected = false;
//			}
//			foreach (ListItem liFunctionList in cblFunctionList.Items)
//			{
//				liFunctionList.Selected = false;
//			}

			this.Response.Redirect("wfmOperQuery.aspx");
		}

		private void btnOK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				//更新功能列表
//				if (rblOper.SelectedValue == "")
//				{
//					throw new BusinessException("tbOper","请选择操作员！");
//				}
				string strOperID = txtOperID.Text;//rblOper.SelectedValue;
				//查询某操作员已具有的功能
				DataTable dtHaveOperFunction = Helper.Query("select * from tbOperFunc where cnvcOperID='"+strOperID+"'");

				foreach (ListItem liOperFunction in cblFunctionList.Items)
				{
					if (liOperFunction.Selected)
					{

						OperFunc operFunc = new OperFunc();
						operFunc.cnvcOperID = strOperID;
						operFunc.cnvcFuncCode = liOperFunction.Value;
						bool bIsAdd = true;

						if (dtHaveOperFunction.Rows.Count > 0)
						{
							foreach (DataRow drHaveOperFunction in dtHaveOperFunction.Rows)
							{
								//已有的不做操作
								if (drHaveOperFunction["cnvcFuncCode"].ToString().Equals(liOperFunction.Value))
								{
									bIsAdd = false;
							
								}
							}
						}
						if(bIsAdd)
						{
							SysManageFacade.AddOperFunc(operFunc,oper);
						}										
					}
					else
					{
						//已有的取消了的删除
						foreach (DataRow drHaveOperFunction in dtHaveOperFunction.Rows)
						{
							if (dtHaveOperFunction.Rows.Count > 0)
							{
								if (drHaveOperFunction["cnvcFuncCode"].ToString().Equals(liOperFunction.Value))
								{
									OperFunc operFunc = new OperFunc();							
									operFunc.cnvcOperID = strOperID;
									operFunc.cnvcFuncCode = liOperFunction.Value;
							
									SysManageFacade.DeleteOperFunc(operFunc,oper);
								}
							}
							
						}
					}
				}
				Popup("权限修改成功！");
			}
			catch (BusinessException bex)
			{
				Popup(bex.Message);
			}
			
			
		}

	}
}
