using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using VCustApp.Common;
using VCustApp.Entity.EntityClass;
using VCustApp.BusinessFacade;
namespace VCustApp.BusinessChance
{
	/// <summary>
	/// wfmChanceReport ��ժҪ˵����
	/// </summary>
	public class wfmChanceReport : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.TextBox txtBeginDate;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!this.IsPostBack)
			{
				this.BindDropDownList(ddlDept,ConstApp.A_DEPT,"",new ListItem("����","%"));
			}
		}

		private void BindGrid()
		{
			//1�ۼ��̻���
			string strChanceCountSql = "select cnvcDeptID,count(*) as cnnChanceCount from tbProject where cnvcDeptID like '"+ddlDept.SelectedValue+"' group by cnvcDeptID";
			DataTable dtChanceCount = Helper.Query(strChanceCountSql);

			//2���������̻���
			string strAddCountSql = "select cnvcDeptID,count(*) as cnnAddCount from tbProject where cnvcDeptID like '"+ddlDept.SelectedValue+"' ";
			if(txtBeginDate.Text != "")
				strAddCountSql += " and convert(char(10),cndChanceDate,121) >='"+txtBeginDate.Text+"'";
			if(txtEndDate.Text != "")
				strAddCountSql += " and convert(char(10),cndChanceDate,121) <='"+txtEndDate.Text+"'";
			strAddCountSql += " group by cnvcDeptID ";
			DataTable dtAddCount = Helper.Query(strAddCountSql);

			//3�ۼƳɹ�ת���̻���
			string strEndCountSql = "select cnvcDeptID,count(*) as cnnEndCount from tbProject where cnvcDeptID like '"+ddlDept.SelectedValue+"' and cnvcIsSucess='1' group by cnvcDeptID";
			DataTable dtEndCount = Helper.Query(strEndCountSql);

			//4�̻��ۼ�Ԥ������
			string strSumSql = "select cnvcDeptID,sum(cnnForecastIncome) as cnnSum from tbProject where cnvcDeptID like '"+ddlDept.SelectedValue+"' group by cnvcDeptID";
			DataTable dtSum = Helper.Query(strSumSql);

			//5��������Ԥ������
			string strMonthSumSql = "select cnvcDeptID,sum(cnnForecastIncome) as cnnMonthSum from tbProject where cnvcDeptID like '"+ddlDept.SelectedValue+"'";
			if(txtBeginDate.Text != "")
				strMonthSumSql += " and convert(char(10),cndChanceDate,121) >='"+txtBeginDate.Text+"'";
			if(txtEndDate.Text != "")
				strMonthSumSql += " and convert(char(10),cndChanceDate,121) <='"+txtEndDate.Text+"'";
			strMonthSumSql += " group by cnvcDeptID ";
			DataTable dtMonthSum = Helper.Query(strMonthSumSql);

			//6�̻�������
			string strChanceRateSql = "select a.cnvcDeptID,b.cnvcAreaCode,count(cnnCustID)  as cnnChanceRate,1 as cnnCustRate,0 as cnnRate from tbProject a ";
			strChanceRateSql += " left outer join tbDept b on a.cnvcDeptID=b.cnvcDeptID ";
			strChanceRateSql += " where a.cnvcDeptID like '"+ddlDept.SelectedValue+"'";
			strChanceRateSql += " group by a.cnvcDeptID,b.cnvcAreaCode ";
			DataTable dtChanceRate = Helper.Query(strChanceRateSql);
			
			string strCustRateSql = "select cnvcAreaCode,count(*) as cnnCustRate from tbCust group by cnvcAreaCode";
			DataTable dtCustRateSql = Helper.Query(strCustRateSql);

			foreach(DataRow drChanceRate in dtChanceRate.Rows)
			{
				string strAreaCode = drChanceRate["cnvcAreaCode"].ToString();
				DataRow[] drCustRates = dtCustRateSql.Select("cnvcAreaCode='"+strAreaCode+"'");
				if(drCustRates.Length > 0)
					drChanceRate["cnnCustRate"] = drCustRates[0]["cnnCustRate"];
				drChanceRate["cnnRate"] = Math.Round(Convert.ToDouble(drChanceRate["cnnChanceRate"])/Convert.ToDouble(drChanceRate["cnnCustRate"])*100,2);
			}

			//7�ۼƳɹ�ת���̻�����
			string strEndSumql = "select cnvcDeptID,sum(cnnSucessIncome) as cnnEndSum from tbProject where cnvcDeptID like '"+ddlDept.SelectedValue+"' and cnvcIsSucess='1' group by cnvcDeptID";
			DataTable dtEndSum = Helper.Query(strEndSumql);

			//8�����̻�ƽ��Ԥ������
			string strAverageSumql = "select cnvcDeptID,avg(cnnForecastIncome) as cnnAverageSum from tbProject where cnvcDeptID like '"+ddlDept.SelectedValue+"' and cnvcIsSucess='1' group by cnvcDeptID";
			DataTable dtAverageSum = Helper.Query(strAverageSumql);

			//�������
			DataTable dtDept = Helper.Query("select * from tbDept where cnvcDeptID like '"+ddlDept.SelectedValue+"'");//(DataTable)Application[ConstApp.A_DEPT];
			dtDept.Columns.Add("cnnChanceCount");
			dtDept.Columns.Add("cnnAddCount");
			dtDept.Columns.Add("cnnEndCount");
			dtDept.Columns.Add("cnnSum");
			dtDept.Columns.Add("cnnMonthSum");
			dtDept.Columns.Add("cnnRate");
			dtDept.Columns.Add("cnnEndSum");
			dtDept.Columns.Add("cnnAverageSum");
			foreach(DataRow drDept in dtDept.Rows)
			{
				Dept tDept = new Dept(drDept);
				//1
				DataRow[] drChanceCount = dtChanceCount.Select("cnvcDeptID='"+tDept.cnvcDeptID+"'");
				if(drChanceCount.Length >0)
					drDept["cnnChanceCount"] = drChanceCount[0]["cnnChanceCount"];
				//2
				DataRow[] drAddCount = dtAddCount.Select("cnvcDeptID='"+tDept.cnvcDeptID+"'");
				if(drAddCount.Length >0 )
					drDept["cnnAddCount"] = drAddCount[0]["cnnAddCount"];
				//3
				DataRow[] drEndCount = dtEndCount.Select("cnvcDeptID='"+tDept.cnvcDeptID+"'");
				if(drEndCount.Length >0)
					drDept["cnnEndCount"] = drEndCount[0]["cnnEndCount"];
				//4
				DataRow[] drSum = dtSum.Select("cnvcDeptID='"+tDept.cnvcDeptID+"'");
				if(drSum.Length>0)
					drDept["cnnSum"] = drSum[0]["cnnSum"];
				//5
				DataRow[] drMonthSum = dtMonthSum.Select("cnvcDeptID='"+tDept.cnvcDeptID+"'");
				if(drMonthSum.Length>0)
					drDept["cnnMonthSum"] = drMonthSum[0]["cnnMonthSum"];
				//6
				DataRow[] drRate = dtChanceRate.Select("cnvcDeptID='"+tDept.cnvcDeptID+"'");
				if(drRate.Length>0)
					drDept["cnnRate"] = drRate[0]["cnnRate"];
				//7
				DataRow[] drEndSum = dtEndSum.Select("cnvcDeptID='"+tDept.cnvcDeptID+"'");
				if(drEndSum.Length>0)
					drDept["cnnEndSum"] = drEndSum[0]["cnnEndSum"];
				//8
				DataRow[] drAverageSum = dtAverageSum.Select("cnvcDeptID='"+tDept.cnvcDeptID+"'");
				if(drAverageSum.Length>0)
					drDept["cnnAverageSum"] = drAverageSum[0]["cnnAverageSum"];
			}
		
			this.DataGrid1.DataSource = dtDept;
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
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.txtBeginDate.Text = "";
			this.txtEndDate.Text = "";
			this.DataGrid1.DataSource = null;
			this.DataGrid1.DataBind();
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			this.DataGridToExcel(this.DataGrid1,"�̻�����ͳ�Ʊ�");
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			this.BindGrid();
		}
	}
}
