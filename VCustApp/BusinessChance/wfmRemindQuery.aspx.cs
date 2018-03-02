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
	/// wfmRemindQuery ��ժҪ˵����
	/// </summary>
	public class wfmRemindQuery : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox TextBox4;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button btnAddRemind;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button Button3;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			BindGrid();
		}

		private void BindGrid()
		{
			DataTable dtRemind = new DataTable();
			dtRemind.Columns.Add("cnvcCustomName");
			dtRemind.Columns.Add("cnvcRemind");
			dtRemind.Columns.Add("cndBeginDate");
			dtRemind.Columns.Add("cndEndDate");

			DataRow drNew = dtRemind.NewRow();
			drNew["cnvcCustomName"] = "����";
			drNew["cnvcRemind"] = "ĳĳĳ������";
			drNew["cndBeginDate"] = "2008��11��1��";
			drNew["cndEndDate"] = "2008��11��21��";
			dtRemind.Rows.Add(drNew);

			drNew = dtRemind.NewRow();
			drNew["cnvcCustomName"] = "����";
			drNew["cnvcRemind"] = "ĳĳĳ������";
			drNew["cndBeginDate"] = "2008��11��1��";
			drNew["cndEndDate"] = "2008��11��21��";
			dtRemind.Rows.Add(drNew);

			drNew = dtRemind.NewRow();
			drNew["cnvcCustomName"] = "����";
			drNew["cnvcRemind"] = "ĳĳĳ������";
			drNew["cndBeginDate"] = "2008��11��1��";
			drNew["cndEndDate"] = "2008��11��21��";
			dtRemind.Rows.Add(drNew);

			drNew = dtRemind.NewRow();
			drNew["cnvcCustomName"] = "����";
			drNew["cnvcRemind"] = "ĳĳĳ������";
			drNew["cndBeginDate"] = "2008��11��1��";
			drNew["cndEndDate"] = "2008��11��21��";
			dtRemind.Rows.Add(drNew);

			drNew = dtRemind.NewRow();
			drNew["cnvcCustomName"] = "����";
			drNew["cnvcRemind"] = "ĳĳĳ������";
			drNew["cndBeginDate"] = "2008��11��1��";
			drNew["cndEndDate"] = "2008��11��21��";
			dtRemind.Rows.Add(drNew);

			this.DataGrid1.DataSource = dtRemind;
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
			this.btnAddRemind.Click += new System.EventHandler(this.btnAddRemind_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAddRemind_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("wfmAddRemind.aspx");
		}
	}
}
