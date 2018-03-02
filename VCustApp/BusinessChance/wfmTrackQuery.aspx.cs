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
	/// wfmTrackQuery 的摘要说明。
	/// </summary>
	public class wfmTrackQuery : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList DropDownList6;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button btnAddTrack;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			BindGrid();
		}

		private void BindGrid()
		{
			DataTable dtTrack = new DataTable();
			dtTrack.Columns.Add("cndTrackDate");
			dtTrack.Columns.Add("cnvcTrackMan");		
			
			DataRow drNew = dtTrack.NewRow();
			drNew["cndTrackDate"] = "2008年11月10日";
			drNew["cnvcTrackMan"] = "张三";
			dtTrack.Rows.Add(drNew);

			drNew = dtTrack.NewRow();
			drNew["cndTrackDate"] = "2008年11月10日";
			drNew["cnvcTrackMan"] = "张三";
			dtTrack.Rows.Add(drNew);

			drNew = dtTrack.NewRow();
			drNew["cndTrackDate"] = "2008年11月10日";
			drNew["cnvcTrackMan"] = "张三";
			dtTrack.Rows.Add(drNew);

			drNew = dtTrack.NewRow();
			drNew["cndTrackDate"] = "2008年11月10日";
			drNew["cnvcTrackMan"] = "张三";
			dtTrack.Rows.Add(drNew);

			drNew = dtTrack.NewRow();
			drNew["cndTrackDate"] = "2008年11月10日";
			drNew["cnvcTrackMan"] = "张三";
			dtTrack.Rows.Add(drNew);

			drNew = dtTrack.NewRow();
			drNew["cndTrackDate"] = "2008年11月10日";
			drNew["cnvcTrackMan"] = "张三";
			dtTrack.Rows.Add(drNew);

			drNew = dtTrack.NewRow();
			drNew["cndTrackDate"] = "2008年11月10日";
			drNew["cnvcTrackMan"] = "张三";
			dtTrack.Rows.Add(drNew);

			drNew = dtTrack.NewRow();
			drNew["cndTrackDate"] = "2008年11月10日";
			drNew["cnvcTrackMan"] = "张三";
			dtTrack.Rows.Add(drNew);

			drNew = dtTrack.NewRow();
			drNew["cndTrackDate"] = "2008年11月10日";
			drNew["cnvcTrackMan"] = "张三";
			dtTrack.Rows.Add(drNew);

			this.DataGrid1.DataSource = dtTrack;
			this.DataGrid1.DataBind();
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
			this.btnAddTrack.Click += new System.EventHandler(this.btnAddTrack_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAddTrack_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("wfmAddTrack.aspx");
		}
	}
}
