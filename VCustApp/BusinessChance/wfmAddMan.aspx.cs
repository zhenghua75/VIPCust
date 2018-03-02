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
	/// wfmAddMan 的摘要说明。
	/// </summary>
	public class wfmAddMan : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			BindGrid();
		}

		private void BindGrid()
		{
			DataTable dtOper = new DataTable();
			dtOper.Columns.Add("cnvcName");
			dtOper.Columns.Add("cnvcTask");

			DataRow drNew = dtOper.NewRow();
			drNew["cnvcName"] = "张三";
			drNew["cnvcTask"] = "速度加速度完成";
			dtOper.Rows.Add(drNew);

			drNew = dtOper.NewRow();
			drNew["cnvcName"] = "李四";
			drNew["cnvcTask"] = "速度加速度完成";
			dtOper.Rows.Add(drNew);

			drNew = dtOper.NewRow();
			drNew["cnvcName"] = "王五";
			drNew["cnvcTask"] = "速度加速度完成";
			dtOper.Rows.Add(drNew);

			this.DataGrid1.DataSource = dtOper;
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
