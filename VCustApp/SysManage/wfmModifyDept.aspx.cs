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
using VCustApp.Entity.EntityClass;
namespace VCustApp.SysManage
{
	/// <summary>
	/// wfmModifyDept ��ժҪ˵����
	/// </summary>
	public class wfmModifyDept : wfmBase
	{
		protected System.Web.UI.WebControls.Label lblOperID;
		protected System.Web.UI.WebControls.TextBox txtDeptID;
		protected System.Web.UI.WebControls.Label lblOperName;
		protected System.Web.UI.WebControls.TextBox txtDeptName;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlAreaCode;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtComments;
		protected System.Web.UI.WebControls.ImageButton btnOK;
		protected System.Web.UI.WebControls.ImageButton btnCancel;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!this.IsPostBack)
			{
				if(Request["cnvcDeptID"] == null)
				{
					Popup("��Ч����");						
					return;
				}
				this.BindDropDownList(ddlAreaCode,ConstApp.A_AREACODE,"");
				
				string strDeptID = Request["cnvcDeptID"].ToString();
				DataTable dtDept = Helper.Query("select * from tbDept where cnvcDeptID='"+strDeptID+"'");
				Dept oldDept = new Dept(dtDept);
				this.txtDeptID.Text = oldDept.cnvcDeptID;
				this.txtDeptName.Text = oldDept.cnvcDeptName;
				ListItem li = this.ddlAreaCode.Items.FindByValue(oldDept.cnvcAreaCode);
				if(li != null)
					li.Selected = true;
//				int i = this.ddlDept.Items.IndexOf(this.ddlDept.Items.FindByValue(oldDept.cnvcParentDeptID));
//				if(i > 0)
//					this.ddlDept.SelectedIndex = i;

				BindDept();
				foreach(ListItem li1 in this.ddlDept.Items)
				{
					li1.Selected = false;
				}
				ListItem liParentDept = this.ddlDept.Items.FindByValue(oldDept.cnvcParentDeptID);
				if(liParentDept != null)
				{
					//if(ddlDept.SelectedValue != liParentDept.Value)						
					liParentDept.Selected = true;					
				}
				this.txtComments.Text = oldDept.cnvcComments;

				this.txtDeptID.Enabled = false;
			}
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
		}
		private void BindDept()
		{
			DataTable dtDept = Helper.Query("select * from tbDept where cnvcAreaCode = '"+ddlAreaCode.SelectedValue+"' or isnull(cnvcParentDeptID,'')='yncnc'");
			this.ddlDept.DataSource = dtDept;
			this.ddlDept.DataTextField = "cnvcDeptName";
			this.ddlDept.DataValueField = "cnvcDeptID";
			this.ddlDept.DataBind();
			this.ddlDept.Items.Add("");
			//this.ddlDept.Items.Insert(0,new ListItem("",""));
		}
		private void btnOK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(this.JudgeIsNull(txtDeptName.Text,"��������"))
					return;				
				DataTable dtDept = Helper.Query("select * from tbDept where cnvcDeptID='"+txtDeptID.Text+"'");
				if(dtDept.Rows.Count == 0)
					throw new Exception("�޴˲���");
				Dept oldDept = new Dept(dtDept);
				oldDept.cnvcAreaCode = ddlAreaCode.SelectedValue;
				oldDept.cnvcComments = txtComments.Text;
				
				oldDept.cnvcDeptName = txtDeptName.Text;
				oldDept.cnvcParentDeptID = ddlDept.SelectedValue;
				SysManageFacade.ModifyDept(oldDept,oper);
				Popup("�����޸ĳɹ�");
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
	}
}
