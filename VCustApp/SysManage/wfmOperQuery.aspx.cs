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
	/// wfmOperQuery ��ժҪ˵����
	/// </summary>
	public class wfmOperQuery : wfmBase
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
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.ImageButton btnAdd;
		protected System.Web.UI.WebControls.ImageButton btnCancel;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!this.IsPostBack)
			{				
				this.BindDropDownList(this.ddlDept,ConstApp.A_DEPT,"",new ListItem("����","%"));
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
			this.btnOK.Click += new System.Web.UI.ImageClickEventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.Web.UI.ImageClickEventHandler(this.btnCancel_Click);
			this.btnAdd.Click += new System.Web.UI.ImageClickEventHandler(this.btnAdd_Click);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindGrid()
		{
			string strSql = "select *,'' as cnvcManagerComments from tbOper where 1=1 ";
			if(txtOperID.Text != "")
				strSql += " and cnvcOperID = '"+txtOperID.Text+"'";
			if(txtOperName.Text != "")
				strSql += " and cnvcOperName like '%"+txtOperName.Text+"%'";
			strSql += " and cnvcDeptID like '"+ddlDept.SelectedValue+"'";
			if(txtInvalidDate.Text.Trim() != "")
				strSql += " and cndInvalidDate < '"+txtInvalidDate.Text+"'";
			DataTable dtOper = Helper.Query(strSql);
			this.DataTableConvert(dtOper,"cnvcDeptID",ConstApp.A_DEPT,"");
			this.DataTableConvert(dtOper,"cnvcRoleCode",ConstApp.A_NAMECODE,"cnvcType='ROLE_CODE'");

			DataTable dtOper2 = dtOper.Copy();
			foreach(DataRow drOper in dtOper.Rows)
			{
				DataRow[] drOpers = dtOper2.Select("cnvcOperID='"+drOper["cnvcManager"].ToString()+"'");
				if(drOpers.Length > 0)
					drOper["cnvcManagerComments"] = drOpers[0]["cnvcOperName"];
			}
			//this.DataTableConvert(dtDept,"cnvcAreaCode",ConstApp.A_AREACODE,"");
			this.DataGrid1.DataSource = dtOper;
			this.DataGrid1.DataBind();
		}
		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				Oper oldOper = new Oper();
				oldOper.cnvcOperID = e.Item.Cells[0].Text;
				SysManageFacade.DeleteOper(oldOper,oper);

				DataTable dtOper2 = Helper.Query("select *,cnvcOperID as cnvcID,cnvcOperName as cnvcName from tbOper");
				Application[ConstApp.A_OPER] = dtOper2;	

				Popup("����Ա��ɾ���ɹ�");
				BindGrid();
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
			this.BindGrid();
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Item ||e.Item.ItemType == ListItemType.AlternatingItem)
			{								
				LinkButton btnDelete = (LinkButton)(e.Item.Cells[9].Controls[0]);
				btnDelete.Attributes.Add("onClick","JavaScript:return confirm('ȷ��ɾ����')");

				Button btnInit = (Button)(e.Item.Cells[11].Controls[0]);
				btnInit.Attributes.Add("onClick","JavaScript:return confirm('ȷ����ʼ�����룿')");
			} 
		}

		private void btnOK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.BindGrid();
		}

		private void btnCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.txtOperID.Text = "";
			this.txtOperName.Text = "";
			this.txtInvalidDate.Text = "";
		}

		private void btnAdd_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Response.Redirect("wfmNewUser.aspx");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				if(e.CommandName=="PWD")
				{
					Oper oldOper = new Oper();
					oldOper.cnvcOperID = e.Item.Cells[0].Text;
					SysManageFacade.InitPwd(oldOper,oper);

					DataTable dtOper2 = Helper.Query("select *,cnvcOperID as cnvcID,cnvcOperName as cnvcName from tbOper");
					Application[ConstApp.A_OPER] = dtOper2;	

					Popup("�����ѳ�ʼ��");
					//BindGrid();
				}
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}
	}
}
