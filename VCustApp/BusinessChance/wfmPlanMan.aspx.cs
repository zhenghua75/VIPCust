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
	/// wfmPlanMan ��ժҪ˵����
	/// </summary>
	public class wfmPlanMan : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			BindGrid();
		}

		private void BindGrid()
		{
			DataTable dtMan = new DataTable();
			dtMan.Columns.Add("cnvcName");
			dtMan.Columns.Add("cnvcRead");
			dtMan.Columns.Add("cnvcSpeed");

			DataRow drNew = dtMan.NewRow();
			drNew["cnvcName"] = "����";
			drNew["cnvcRead"] = "δ��";
			drNew["cnvcSpeed"] = "δִ��";
			dtMan.Rows.Add(drNew);

			drNew = dtMan.NewRow();
			drNew["cnvcName"] = "����";
			drNew["cnvcRead"] = "δ��";
			drNew["cnvcSpeed"] = "δִ��";
			dtMan.Rows.Add(drNew);

			drNew = dtMan.NewRow();
			drNew["cnvcName"] = "����";
			drNew["cnvcRead"] = "�Ѷ�";
			drNew["cnvcSpeed"] = "��ִ��";
			dtMan.Rows.Add(drNew);

			this.DataGrid1.DataSource = dtMan;
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
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button3_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("wfmAddMan.aspx");
		}
	}
}
