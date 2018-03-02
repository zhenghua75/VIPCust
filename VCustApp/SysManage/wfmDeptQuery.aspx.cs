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
	/// wfmDeptQuery ��ժҪ˵����
	/// </summary>
	public class wfmDeptQuery : wfmBase
	{
		protected System.Web.UI.WebControls.Label lblOperID;
		protected System.Web.UI.WebControls.TextBox txtDeptID;
		protected System.Web.UI.WebControls.Label lblOperName;
		protected System.Web.UI.WebControls.TextBox txtDeptName;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlAreaCode;
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
				this.BindDropDownList(this.ddlAreaCode,ConstApp.A_AREACODE,"",new ListItem("����","%"));
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
			this.btnAdd.Click += new System.Web.UI.ImageClickEventHandler(this.btnAdd_Click);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAdd_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Response.Redirect("wfmAddDept.aspx");
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Item ||e.Item.ItemType == ListItemType.AlternatingItem)
			{								
				LinkButton btnDelete = (LinkButton)(e.Item.Cells[6].Controls[0]);
				btnDelete.Attributes.Add("onClick","JavaScript:return confirm('ȷ��ɾ����')");
			} 
		}

		private void BindGrid()
		{
			string strSql = "select * from tbDept where 1=1 ";
			if(txtDeptID.Text != "")
				strSql += " and cnvcDeptID = '"+txtDeptID.Text+"'";
			if(txtDeptName.Text != "")
				strSql += " and cnvcDeptName like '%"+txtDeptName.Text+"%'";
			strSql += " and cnvcAreaCode like '"+ddlAreaCode.SelectedValue+"'"+" and isnull(cnvcParentDeptID,'') like '"+ddlDept.SelectedValue+"'";
			DataTable dtDept = Helper.Query(strSql);
			this.DataTableConvert(dtDept,"cnvcParentDeptID",ConstApp.A_DEPT,"");
			this.DataTableConvert(dtDept,"cnvcAreaCode",ConstApp.A_AREACODE,"");
			this.DataGrid1.DataSource = dtDept;
			this.DataGrid1.DataBind();
		}
		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				Dept oldDept = new Dept();
				oldDept.cnvcDeptID = e.Item.Cells[0].Text;
				SysManageFacade.DeleteDept(oldDept,oper);
				Popup("ɾ�����ųɹ�");
				BindGrid();
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}

		private void btnOK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.DataGrid1.CurrentPageIndex = 0;
			BindGrid();
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
			this.BindGrid();
		}
	}
}
