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
	/// wfmPlanMan 的摘要说明。
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
			// 在此处放置用户代码以初始化页面
			BindGrid();
		}

		private void BindGrid()
		{
			DataTable dtMan = new DataTable();
			dtMan.Columns.Add("cnvcName");
			dtMan.Columns.Add("cnvcRead");
			dtMan.Columns.Add("cnvcSpeed");

			DataRow drNew = dtMan.NewRow();
			drNew["cnvcName"] = "张三";
			drNew["cnvcRead"] = "未读";
			drNew["cnvcSpeed"] = "未执行";
			dtMan.Rows.Add(drNew);

			drNew = dtMan.NewRow();
			drNew["cnvcName"] = "李四";
			drNew["cnvcRead"] = "未读";
			drNew["cnvcSpeed"] = "未执行";
			dtMan.Rows.Add(drNew);

			drNew = dtMan.NewRow();
			drNew["cnvcName"] = "王五";
			drNew["cnvcRead"] = "已读";
			drNew["cnvcSpeed"] = "已执行";
			dtMan.Rows.Add(drNew);

			this.DataGrid1.DataSource = dtMan;
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
