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
	/// Summary description for wfmNewUser.
	/// </summary>
	public class wfmNewUser : wfmBase
	{
		protected System.Web.UI.WebControls.Label lblOperID;
		protected System.Web.UI.WebControls.TextBox txtOperID;
		protected System.Web.UI.WebControls.Label lblOperName;
		protected System.Web.UI.WebControls.TextBox txtOperName;
		protected System.Web.UI.WebControls.ImageButton btnOK;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvOperID;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvOperName;
		protected System.Web.UI.WebControls.RangeValidator rvOper;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtPwd;
		protected System.Web.UI.WebControls.TextBox txtPwdConfirm;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtInvalidDate;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtComments;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DropDownList ddlManager;
		protected System.Web.UI.WebControls.DropDownList ddlRoleCode;
		protected System.Web.UI.WebControls.ImageButton btnCancel;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!this.IsPostBack)
			{
				this.BindDropDownList(this.ddlDept,ConstApp.A_DEPT,"");
				this.BindDropDownList(this.ddlRoleCode,ConstApp.A_NAMECODE,"cnvcType='ROLE_CODE' ");

				BindOper(ddlDept.SelectedValue);
				OperDisp();

				this.txtInvalidDate.Text = "9999-12-31";
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
			this.ddlDept.SelectedIndexChanged += new System.EventHandler(this.ddlDept_SelectedIndexChanged);
			this.ddlRoleCode.SelectedIndexChanged += new System.EventHandler(this.ddlRoleCode_SelectedIndexChanged);
			this.btnOK.Click += new System.Web.UI.ImageClickEventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.Web.UI.ImageClickEventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void BindOper(string strDeptID)
		{
			DataTable dtOper = Helper.Query("select * from tbOper where cndInvalidDate >= getdate() and cnvcRoleCode='trade' and cnvcDeptID='"+strDeptID+"'");
			ddlManager.DataSource = dtOper;
			ddlManager.DataTextField = "cnvcOperName";
			ddlManager.DataValueField = "cnvcOperID";
			ddlManager.DataBind();
		}
		private void btnOK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//添加用户
			try
			{				
				if(this.JudgeIsNull(txtOperID.Text,"操作员编码"))
					return;
				if(this.JudgeIsNull(txtOperName.Text,"操作员名称"))
					return;
				if(this.JudgeIsNull(this.txtPwd.Text,"密码"))
					return;
				if(this.JudgeIsNull(txtPwdConfirm.Text,"密码确认"))
					return;
				if (GetLength(txtOperID.Text) >50)
				{
					throw new Exception("操作员ID过长！");
				}
				if (GetLength(txtOperName.Text) >50)
				{
					throw new Exception("操作员姓名过长！");
				}
				if(txtPwd.Text != txtPwdConfirm.Text)
					throw new Exception("密码不一致");
				Oper newOper = new Oper();
				newOper.cnvcOperID = txtOperID.Text;
				DataTable dtOper = Helper.Query("select * from tbOper where cnvcOperID='"+newOper.cnvcOperID+"'");				
				if (dtOper.Rows.Count == 0)
				{
					newOper.cnvcOperName = txtOperName.Text;
					newOper.cnvcOperPwd = DataSecurity.Encrypt(txtPwd.Text);
					newOper.cnvcDeptID = ddlDept.SelectedValue;

					if(txtInvalidDate.Text.Trim() == "")
						newOper.cndInvalidDate = DateTime.Parse("9999-12-31");
					else
						newOper.cndInvalidDate = DateTime.Parse(txtInvalidDate.Text);
					newOper.cnvcRoleCode = ddlRoleCode.SelectedValue;
					if(newOper.cnvcRoleCode == "customer")
						newOper.cnvcManager = ddlManager.SelectedValue;
					newOper.cnvcComments = txtComments.Text;
					SysManageFacade.AddOper(newOper,oper);

					DataTable dtOper2 = Helper.Query("select *,cnvcOperID as cnvcID,cnvcOperName as cnvcName from tbOper");
					Application[ConstApp.A_OPER] = dtOper2;	

					Popup("新建用户成功！");
					Clear();

				}
				else
				{
					Popup("用户已存在！");
				}								
				
			}
			catch (Exception bex)
			{
				Popup(bex.Message);
			}
			
		}

		private void Clear()
		{
			this.txtOperID.Text = "";
			this.txtOperName.Text = "";
			this.txtInvalidDate.Text = "9999-12-31";
			this.txtComments.Text = "";
		}

		private void btnCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Response.Redirect("wfmOperQuery.aspx");
//			txtOperID.Text = "";
//			txtOperName.Text = "";
//			txtPwd.Text = "";
//			txtPwdConfirm.Text = "";
		}

		private void ddlRoleCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			OperDisp();
		}
		private void OperDisp()
		{
			if(ddlRoleCode.SelectedValue == "customer")
			{
				ddlManager.Visible = true;
				Label7.Visible = true;
			}
			else
			{
				ddlManager.Visible = false;
				Label7.Visible = false;
			}
		}

		private void ddlDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindOper(ddlDept.SelectedValue);
		}

		
	}
}
