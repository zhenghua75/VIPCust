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
	/// wfmAddDept 的摘要说明。
	/// </summary>
	public class wfmAddDept : wfmBase
	{
		protected System.Web.UI.WebControls.Label lblOperID;
		protected System.Web.UI.WebControls.Label lblOperName;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.ImageButton btnOK;
		protected System.Web.UI.WebControls.ImageButton btnCancel;
		protected System.Web.UI.WebControls.TextBox txtDeptID;
		protected System.Web.UI.WebControls.TextBox txtDeptName;
		protected System.Web.UI.WebControls.TextBox txtComments;
		protected System.Web.UI.WebControls.DropDownList ddlAreaCode;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!this.IsPostBack)
			{
				this.BindDropDownList(ddlAreaCode,ConstApp.A_AREACODE,"");
				BindDept();
				//this.BindDropDownList(ddlDept,ConstApp.A_DEPT,"cnvcAreaCode='"+ddlAreaCode.SelectedValue+"'");
			}
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
			this.ddlAreaCode.SelectedIndexChanged += new System.EventHandler(this.ddlAreaCode_SelectedIndexChanged);
			this.btnOK.Click += new System.Web.UI.ImageClickEventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.Web.UI.ImageClickEventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Response.Redirect("wfmDeptQuery.aspx");
//			this.txtDeptID.Text = "";
//			this.txtDeptName.Text = "";
//			this.txtComments.Text = "";
		}

		private void btnOK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(this.JudgeIsNull(txtDeptID.Text,"部门ID"))
					return;
				if(this.JudgeIsNull(txtDeptName.Text,"部门名称"))
					return;
				DataTable dtDept = Helper.Query("select * from tbDept where cnvcDeptID='"+txtDeptID.Text+"'");
				if(dtDept.Rows.Count > 0)
					throw new Exception("相同部门ID已存在");
				Dept newDept = new Dept();
				newDept.cnvcAreaCode = ddlAreaCode.SelectedValue;
				newDept.cnvcComments = txtComments.Text;
				newDept.cnvcDeptID = txtDeptID.Text;
				newDept.cnvcDeptName = txtDeptName.Text;
				newDept.cnvcParentDeptID = ddlDept.SelectedValue;
				SysManageFacade.AddDept(newDept,oper);
				Popup("部门添加成功");
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}

		private void ddlAreaCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindDept();		
		}
		private void BindDept()
		{
			DataTable dtDept = Helper.Query("select * from tbDept where cnvcAreaCode = '"+ddlAreaCode.SelectedValue+"'  or isnull(cnvcParentDeptID,'')='yncnc'");
			this.ddlDept.DataSource = dtDept;
			this.ddlDept.DataTextField = "cnvcDeptName";
			this.ddlDept.DataValueField = "cnvcDeptID";
			this.ddlDept.DataBind();	
			this.ddlDept.Items.Add("");
		}
	}
}
