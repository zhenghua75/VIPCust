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

namespace VCustApp.BusinessChance
{
	/// <summary>
	/// wfmAddMan ��ժҪ˵����
	/// </summary>
	public class wfmAddMan : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			BindGrid();
		}

		private void BindGrid()
		{
			DataTable dtOper = new DataTable();
			dtOper.Columns.Add("cnvcName");
			dtOper.Columns.Add("cnvcTask");

			DataRow drNew = dtOper.NewRow();
			drNew["cnvcName"] = "����";
			drNew["cnvcTask"] = "�ٶȼ��ٶ����";
			dtOper.Rows.Add(drNew);

			drNew = dtOper.NewRow();
			drNew["cnvcName"] = "����";
			drNew["cnvcTask"] = "�ٶȼ��ٶ����";
			dtOper.Rows.Add(drNew);

			drNew = dtOper.NewRow();
			drNew["cnvcName"] = "����";
			drNew["cnvcTask"] = "�ٶȼ��ٶ����";
			dtOper.Rows.Add(drNew);

			this.DataGrid1.DataSource = dtOper;
			this.DataGrid1.DataBind();
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
			this.DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_CancelCommand);
			this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_EditCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGrid1_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.DataGrid1.EditItemIndex = -1;
			this.BindGrid();
		}

		private void DataGrid1_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.DataGrid1.EditItemIndex = e.Item.ItemIndex;
			this.BindGrid();
		}
	}
}
