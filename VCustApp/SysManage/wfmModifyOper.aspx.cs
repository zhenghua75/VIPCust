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
	/// wfmModifyOper ��ժҪ˵����
	/// </summary>
	public class wfmModifyOper : wfmBase
	{
		protected System.Web.UI.WebControls.Label lblOperID;
		protected System.Web.UI.WebControls.TextBox txtOperID;
		protected System.Web.UI.WebControls.Label lblOperName;
		protected System.Web.UI.WebControls.TextBox txtOperName;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtInvalidDate;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.ImageButton btnOK;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtComments;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.DropDownList ddlRoleCode;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DropDownList ddlManager;
		protected System.Web.UI.WebControls.ImageButton btnCancel;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!this.IsPostBack)
			{				
				if(Request["cnvcOperID"] == null)
				{
					Popup("��Ч����");
				}
				string strOperID = Request["cnvcOperID"].ToString();
				DataTable dtOper = Helper.Query("select * from tbOper where cnvcOperID='"+strOperID+"'");
				if(dtOper.Rows.Count == 0)
				{
					Popup("�޴��û���Ϣ");
					return;
				}
				Oper oldOper = new Oper(dtOper);
				txtOperID.Text = oldOper.cnvcOperID;
				txtOperName.Text = oldOper.cnvcOperName;
				txtInvalidDate.Text = oldOper.cndInvalidDate.ToString("yyyy-MM-dd");
				this.BindDropDownList(this.ddlDept,ConstApp.A_DEPT,"");
				ListItem li = this.ddlDept.Items.FindByValue(oldOper.cnvcDeptID);
				if(li != null)
					li.Selected = true;
				this.BindDropDownList(this.ddlRoleCode,ConstApp.A_NAMECODE,"cnvcType='ROLE_CODE' ");
				ListItem liRole = this.ddlRoleCode.Items.FindByValue(oldOper.cnvcRoleCode);
				if(liRole != null)
					liRole.Selected = true;

				BindOper(ddlDept.SelectedValue);
				OperDisp();

				txtComments.Text = oldOper.cnvcComments;
				this.txtOperID.Enabled = false;
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
			this.ddlDept.SelectedIndexChanged += new System.EventHandler(this.ddlDept_SelectedIndexChanged);
			this.ddlRoleCode.SelectedIndexChanged += new System.EventHandler(this.ddlRoleCode_SelectedIndexChanged);
			this.btnOK.Click += new System.Web.UI.ImageClickEventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.Web.UI.ImageClickEventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnOK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{	
			try
			{
				DataTable dtOper = Helper.Query("select * from tbOper where cnvcOperID='"+txtOperID.Text+"'");
				if(dtOper.Rows.Count == 0)
				{
					Popup("�޴��û���Ϣ");
					return;
				}
				if(this.JudgeIsNull(txtOperName.Text,"����Ա����"))
					return;
				if(this.JudgeIsNull(txtInvalidDate.Text,"ʧЧʱ��"))
					return;
				Oper newOper = new Oper(dtOper);
				newOper.cnvcOperName = txtOperName.Text;
				newOper.cndInvalidDate = DateTime.Parse(txtInvalidDate.Text);
				newOper.cnvcDeptID = ddlDept.SelectedValue;

				newOper.cnvcRoleCode = ddlRoleCode.SelectedValue;
				if(newOper.cnvcRoleCode == "customer")
				{
					newOper.cnvcManager = ddlManager.SelectedValue;
				}
				else
				{
					newOper.cnvcManager = "";
				}
				newOper.cnvcComments = txtComments.Text;
				SysManageFacade.UpdateOper(newOper,oper);

				DataTable dtOper2 = Helper.Query("select *,cnvcOperID as cnvcID,cnvcOperName as cnvcName from tbOper");
				Application[ConstApp.A_OPER] = dtOper2;	

				Popup("����Ա��Ϣ�޸ĳɹ�");
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}

		private void btnCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Response.Redirect("wfmOperQuery.aspx");
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


		private void BindOper(string strDeptID)
		{
			DataTable dtOper = Helper.Query("select * from tbOper where cndInvalidDate >= getdate() and cnvcRoleCode='trade' and cnvcDeptID='"+strDeptID+"'");
			ddlManager.DataSource = dtOper;
			ddlManager.DataTextField = "cnvcOperName";
			ddlManager.DataValueField = "cnvcOperID";
			ddlManager.DataBind();
		}
		private void ddlDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindOper(ddlDept.SelectedValue);
		}

		private void ddlRoleCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			OperDisp();
		}
	}
}
