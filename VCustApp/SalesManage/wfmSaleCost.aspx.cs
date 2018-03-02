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

namespace VCustApp.SalesManage
{
	/// <summary>
	/// wfmSaleCost 的摘要说明。
	/// </summary>
	public class wfmSaleCost : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.TextBox txtCustID;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlYear;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.Button btnExportIn;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!this.IsPostBack)
			{
				if(oper.cnvcRoleCode==null||oper.cnvcRoleCode=="")
				{
					this.btnAdd.Enabled=false;
				}
				int curyear=DateTime.Now.Year;
				int addyear=0;
				for(int i=-3;i<=3;i++)
				{
					addyear=curyear+i;
					this.ddlYear.Items.Add(new ListItem(addyear.ToString(),addyear.ToString()));
				}
				this.ddlYear.SelectedIndex=3;
			}
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
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnExportIn.Click += new System.EventHandler(this.btnExportIn_Click);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_CancelCommand);
			this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_EditCommand);
			this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_UpdateCommand);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindGrid()
		{
			if(this.txtCustID.Text.Trim()!=""&&!this.JudgeIsNum(this.txtCustID.Text.Trim(),"客户ID"))
				return;

			Session.Remove("QUERY");
			string strCustID=this.txtCustID.Text.Trim();
			string strCustName=this.txtCustName.Text.Trim();
			string strYear=this.ddlYear.SelectedValue;
			string strCondition="";
			if(strCustID!="")
			{
				strCondition=" and cnnCustID ="+strCustID;
			}
			if(strCustName!="")
			{
				strCondition+=" and cnvcCustName like '%"+strCustName+"%'";
			}
			
			strCondition+=" and cnnCustID in(select distinct cnnCustID from tbCust where ";

			switch(oper.cnvcRoleCode)
			{
				case "customer":
					strCondition+=" cnvcCustMana='"+oper.cnvcOperID+"'";
					break;
				case "trade":
					strCondition+=" cnvcCustTradeMana='"+oper.cnvcOperID+"'";
					break;
				case "admin":
					strCondition+=" 1=1";
					break;
				case "manager":
					strCondition+=" 1=1";
					break;
				default:
					strCondition+=" 1=2";
					break;
			}

			strCondition+=") ";
			string strsql="select * from tbSaleCost where cnvcYear='"+strYear+"' "+ strCondition+" order by cnnCustID,cnvcYear";
			DataTable dtout=Helper.Query(strsql);
			Session["QUERY"]=dtout;
			this.DataGrid1.DataSource=dtout;
			this.DataGrid1.DataBind();
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			this.BindGrid();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("wfmAddSaleCost.aspx");
		}

		private void DataGrid1_EditCommand(object source, DataGridCommandEventArgs e)
		{
			this.DataGrid1.EditItemIndex=e.Item.ItemIndex;
			this.DataGrid1.DataSource=(DataTable)Session["QUERY"];
			this.DataGrid1.DataBind();
		}

		private void DataGrid1_UpdateCommand(object source, DataGridCommandEventArgs e)
		{
			try
			{
				SaleCost cost=new SaleCost();
				decimal costsum=0;
				//1月
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[6].Controls[0]).Text.Trim(),"1月使用")||!this.JudgeIsNum(((TextBox)e.Item.Cells[6].Controls[0]).Text.Trim(),"1月使用"))
				{
					return;
				}
				else
				{
					cost.cnnUsed1=decimal.Parse(((TextBox)e.Item.Cells[6].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed1;
				}
				//2月
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[7].Controls[0]).Text.Trim(),"2月使用")||!this.JudgeIsNum(((TextBox)e.Item.Cells[7].Controls[0]).Text.Trim(),"2月使用"))
				{
					return;
				}
				else
				{
					cost.cnnUsed2=decimal.Parse(((TextBox)e.Item.Cells[7].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed2;
				}
				//3月
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[8].Controls[0]).Text.Trim(),"3月使用")||!this.JudgeIsNum(((TextBox)e.Item.Cells[8].Controls[0]).Text.Trim(),"3月使用"))
				{
					return;
				}
				else
				{
					cost.cnnUsed3=decimal.Parse(((TextBox)e.Item.Cells[8].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed3;
				}
				//4月
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[9].Controls[0]).Text.Trim(),"4月使用")||!this.JudgeIsNum(((TextBox)e.Item.Cells[9].Controls[0]).Text.Trim(),"4月使用"))
				{
					return;
				}
				else
				{
					cost.cnnUsed4=decimal.Parse(((TextBox)e.Item.Cells[9].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed4;
				}
				//5月
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[10].Controls[0]).Text.Trim(),"5月使用")||!this.JudgeIsNum(((TextBox)e.Item.Cells[10].Controls[0]).Text.Trim(),"5月使用"))
				{
					return;
				}
				else
				{
					cost.cnnUsed5=decimal.Parse(((TextBox)e.Item.Cells[10].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed5;
				}
				//6月
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[11].Controls[0]).Text.Trim(),"6月使用")||!this.JudgeIsNum(((TextBox)e.Item.Cells[11].Controls[0]).Text.Trim(),"6月使用"))
				{
					return;
				}
				else
				{
					cost.cnnUsed6=decimal.Parse(((TextBox)e.Item.Cells[11].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed6;
				}
				//7月
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[12].Controls[0]).Text.Trim(),"7月使用")||!this.JudgeIsNum(((TextBox)e.Item.Cells[12].Controls[0]).Text.Trim(),"7月使用"))
				{
					return;
				}
				else
				{
					cost.cnnUsed7=decimal.Parse(((TextBox)e.Item.Cells[12].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed7;
				}
				//8月
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[13].Controls[0]).Text.Trim(),"8月使用")||!this.JudgeIsNum(((TextBox)e.Item.Cells[13].Controls[0]).Text.Trim(),"8月使用"))
				{
					return;
				}
				else
				{
					cost.cnnUsed8=decimal.Parse(((TextBox)e.Item.Cells[13].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed8;
				}
				//9月
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[14].Controls[0]).Text.Trim(),"9月使用")||!this.JudgeIsNum(((TextBox)e.Item.Cells[14].Controls[0]).Text.Trim(),"9月使用"))
				{
					return;
				}
				else
				{
					cost.cnnUsed9=decimal.Parse(((TextBox)e.Item.Cells[14].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed9;
				}
				//10月
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[15].Controls[0]).Text.Trim(),"10月使用")||!this.JudgeIsNum(((TextBox)e.Item.Cells[15].Controls[0]).Text.Trim(),"10月使用"))
				{
					return;
				}
				else
				{
					cost.cnnUsed10=decimal.Parse(((TextBox)e.Item.Cells[15].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed10;
				}
				//11月
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[16].Controls[0]).Text.Trim(),"11月使用")||!this.JudgeIsNum(((TextBox)e.Item.Cells[16].Controls[0]).Text.Trim(),"11月使用"))
				{
					return;
				}
				else
				{
					cost.cnnUsed11=decimal.Parse(((TextBox)e.Item.Cells[16].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed11;
				}
				//12月
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[17].Controls[0]).Text.Trim(),"12月使用")||!this.JudgeIsNum(((TextBox)e.Item.Cells[17].Controls[0]).Text.Trim(),"12月使用"))
				{
					return;
				}
				else
				{
					cost.cnnUsed12=decimal.Parse(((TextBox)e.Item.Cells[17].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed12;
				}
				
				cost.cnnCustID=decimal.Parse(e.Item.Cells[0].Text.Trim());
				cost.cnvcCustName=e.Item.Cells[1].Text.Trim();
				cost.cnvcYear=e.Item.Cells[2].Text.Trim();
				cost.cnnBudgetCost=decimal.Parse(e.Item.Cells[3].Text.Trim());
				cost.cnnRealSaleCost=decimal.Parse(e.Item.Cells[4].Text.Trim());
				cost.cnnCostUsed=costsum;

				SalesManageFacade.UpdateSaleCost(cost,oper);
				Popup("销售成本修改成功");

				string strsql="select * from tbSaleCost where cnnCustID="+cost.cnnCustID+" and cnvcYear='"+cost.cnvcYear+"' order by cnnCustID,cnvcYear";
				DataTable dtout=Helper.Query(strsql);
				Session.Remove("QUERY");
				Session["QUERY"]=dtout;
				this.DataGrid1.EditItemIndex=-1;
				this.DataGrid1.DataSource=dtout;
				this.DataGrid1.DataBind();				
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}

		private void DataGrid1_CancelCommand(object source, DataGridCommandEventArgs e)
		{
			this.DataGrid1.EditItemIndex=-1;
			this.DataGrid1.DataSource=(DataTable)Session["QUERY"];
			this.DataGrid1.DataBind();
		}

		private void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.EditItem)
			{
				for(int i=6;i<=17;i++)
				if(e.Item.Cells[i].Controls[0].GetType().ToString()=="System.Web.UI.WebControls.TextBox") 
				{
					((TextBox)e.Item.Cells[i].Controls[0]).Width=Unit.Parse("50px");
				}
			}
		}

		private void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.DataGrid1.CurrentPageIndex=e.NewPageIndex;
			this.BindGrid();
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			this.DataGrid1.Columns[18].Visible = false;
			this.DataGridToExcel(this.DataGrid1,"销售成本管理报表");
		}

		public override void VerifyRenderingInServerForm(Control control)
		{
			// Confirms that an HtmlForm control is rendered for
		}

		private void btnExportIn_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("../wfmFileUp.aspx?XlsType=SaleCost");
		} 
	}
}
