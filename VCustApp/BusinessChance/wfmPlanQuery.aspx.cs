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
	/// wfmPlanQuery ��ժҪ˵����
	/// </summary>
	public class wfmPlanQuery : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button btnAddPlan;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		protected System.Web.UI.WebControls.Button Button2;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			BindGrid();
		}

		private void BindGrid()
		{
			DataTable dtPlan = new DataTable();
			dtPlan.Columns.Add("cnvcPlanName");
			dtPlan.Columns.Add("cndBeginDate");
			dtPlan.Columns.Add("cndEndDate");
			dtPlan.Columns.Add("cnvcPlanNeed");

			DataRow drNew = dtPlan.NewRow();
			drNew["cnvcPlanName"] = "���Լƻ�";
			drNew["cndBeginDate"] = "2008��11��12��";
			drNew["cndEndDate"] = "2008��12��1��";
			drNew["cnvcPlanNeed"] = "�����ĳĳĳ����";
			dtPlan.Rows.Add(drNew);

			drNew = dtPlan.NewRow();
			drNew["cnvcPlanName"] = "���Լƻ�";
			drNew["cndBeginDate"] = "2008��11��12��";
			drNew["cndEndDate"] = "2008��12��1��";
			drNew["cnvcPlanNeed"] = "�����ĳĳĳ����";
			dtPlan.Rows.Add(drNew);

			drNew = dtPlan.NewRow();
			drNew["cnvcPlanName"] = "���Լƻ�";
			drNew["cndBeginDate"] = "2008��11��12��";
			drNew["cndEndDate"] = "2008��12��1��";
			drNew["cnvcPlanNeed"] = "�����ĳĳĳ����";
			dtPlan.Rows.Add(drNew);

			drNew = dtPlan.NewRow();
			drNew["cnvcPlanName"] = "���Լƻ�";
			drNew["cndBeginDate"] = "2008��11��12��";
			drNew["cndEndDate"] = "2008��12��1��";
			drNew["cnvcPlanNeed"] = "�����ĳĳĳ����";
			dtPlan.Rows.Add(drNew);

			drNew = dtPlan.NewRow();
			drNew["cnvcPlanName"] = "���Լƻ�";
			drNew["cndBeginDate"] = "2008��11��12��";
			drNew["cndEndDate"] = "2008��12��1��";
			drNew["cnvcPlanNeed"] = "�����ĳĳĳ����";
			dtPlan.Rows.Add(drNew);

			drNew = dtPlan.NewRow();
			drNew["cnvcPlanName"] = "���Լƻ�";
			drNew["cndBeginDate"] = "2008��11��12��";
			drNew["cndEndDate"] = "2008��12��1��";
			drNew["cnvcPlanNeed"] = "�����ĳĳĳ����";
			dtPlan.Rows.Add(drNew);

			drNew = dtPlan.NewRow();
			drNew["cnvcPlanName"] = "���Լƻ�";
			drNew["cndBeginDate"] = "2008��11��12��";
			drNew["cndEndDate"] = "2008��12��1��";
			drNew["cnvcPlanNeed"] = "�����ĳĳĳ����";
			dtPlan.Rows.Add(drNew);

			drNew = dtPlan.NewRow();
			drNew["cnvcPlanName"] = "���Լƻ�";
			drNew["cndBeginDate"] = "2008��11��12��";
			drNew["cndEndDate"] = "2008��12��1��";
			drNew["cnvcPlanNeed"] = "�����ĳĳĳ����";
			dtPlan.Rows.Add(drNew);

			drNew = dtPlan.NewRow();
			drNew["cnvcPlanName"] = "���Լƻ�";
			drNew["cndBeginDate"] = "2008��11��12��";
			drNew["cndEndDate"] = "2008��12��1��";
			drNew["cnvcPlanNeed"] = "�����ĳĳĳ����";
			dtPlan.Rows.Add(drNew);

			this.DataGrid1.DataSource = dtPlan;
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
			this.btnAddPlan.Click += new System.EventHandler(this.btnAddPlan_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAddPlan_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("wfmAddPlan.aspx");
		}
	}
}
