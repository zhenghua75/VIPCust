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
	/// wfmSaleCost ��ժҪ˵����
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
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
			if(this.txtCustID.Text.Trim()!=""&&!this.JudgeIsNum(this.txtCustID.Text.Trim(),"�ͻ�ID"))
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
				//1��
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[6].Controls[0]).Text.Trim(),"1��ʹ��")||!this.JudgeIsNum(((TextBox)e.Item.Cells[6].Controls[0]).Text.Trim(),"1��ʹ��"))
				{
					return;
				}
				else
				{
					cost.cnnUsed1=decimal.Parse(((TextBox)e.Item.Cells[6].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed1;
				}
				//2��
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[7].Controls[0]).Text.Trim(),"2��ʹ��")||!this.JudgeIsNum(((TextBox)e.Item.Cells[7].Controls[0]).Text.Trim(),"2��ʹ��"))
				{
					return;
				}
				else
				{
					cost.cnnUsed2=decimal.Parse(((TextBox)e.Item.Cells[7].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed2;
				}
				//3��
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[8].Controls[0]).Text.Trim(),"3��ʹ��")||!this.JudgeIsNum(((TextBox)e.Item.Cells[8].Controls[0]).Text.Trim(),"3��ʹ��"))
				{
					return;
				}
				else
				{
					cost.cnnUsed3=decimal.Parse(((TextBox)e.Item.Cells[8].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed3;
				}
				//4��
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[9].Controls[0]).Text.Trim(),"4��ʹ��")||!this.JudgeIsNum(((TextBox)e.Item.Cells[9].Controls[0]).Text.Trim(),"4��ʹ��"))
				{
					return;
				}
				else
				{
					cost.cnnUsed4=decimal.Parse(((TextBox)e.Item.Cells[9].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed4;
				}
				//5��
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[10].Controls[0]).Text.Trim(),"5��ʹ��")||!this.JudgeIsNum(((TextBox)e.Item.Cells[10].Controls[0]).Text.Trim(),"5��ʹ��"))
				{
					return;
				}
				else
				{
					cost.cnnUsed5=decimal.Parse(((TextBox)e.Item.Cells[10].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed5;
				}
				//6��
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[11].Controls[0]).Text.Trim(),"6��ʹ��")||!this.JudgeIsNum(((TextBox)e.Item.Cells[11].Controls[0]).Text.Trim(),"6��ʹ��"))
				{
					return;
				}
				else
				{
					cost.cnnUsed6=decimal.Parse(((TextBox)e.Item.Cells[11].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed6;
				}
				//7��
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[12].Controls[0]).Text.Trim(),"7��ʹ��")||!this.JudgeIsNum(((TextBox)e.Item.Cells[12].Controls[0]).Text.Trim(),"7��ʹ��"))
				{
					return;
				}
				else
				{
					cost.cnnUsed7=decimal.Parse(((TextBox)e.Item.Cells[12].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed7;
				}
				//8��
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[13].Controls[0]).Text.Trim(),"8��ʹ��")||!this.JudgeIsNum(((TextBox)e.Item.Cells[13].Controls[0]).Text.Trim(),"8��ʹ��"))
				{
					return;
				}
				else
				{
					cost.cnnUsed8=decimal.Parse(((TextBox)e.Item.Cells[13].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed8;
				}
				//9��
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[14].Controls[0]).Text.Trim(),"9��ʹ��")||!this.JudgeIsNum(((TextBox)e.Item.Cells[14].Controls[0]).Text.Trim(),"9��ʹ��"))
				{
					return;
				}
				else
				{
					cost.cnnUsed9=decimal.Parse(((TextBox)e.Item.Cells[14].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed9;
				}
				//10��
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[15].Controls[0]).Text.Trim(),"10��ʹ��")||!this.JudgeIsNum(((TextBox)e.Item.Cells[15].Controls[0]).Text.Trim(),"10��ʹ��"))
				{
					return;
				}
				else
				{
					cost.cnnUsed10=decimal.Parse(((TextBox)e.Item.Cells[15].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed10;
				}
				//11��
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[16].Controls[0]).Text.Trim(),"11��ʹ��")||!this.JudgeIsNum(((TextBox)e.Item.Cells[16].Controls[0]).Text.Trim(),"11��ʹ��"))
				{
					return;
				}
				else
				{
					cost.cnnUsed11=decimal.Parse(((TextBox)e.Item.Cells[16].Controls[0]).Text.Trim());
					costsum+=cost.cnnUsed11;
				}
				//12��
				if(this.JudgeIsNull(((TextBox)e.Item.Cells[17].Controls[0]).Text.Trim(),"12��ʹ��")||!this.JudgeIsNum(((TextBox)e.Item.Cells[17].Controls[0]).Text.Trim(),"12��ʹ��"))
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
				Popup("���۳ɱ��޸ĳɹ�");

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
			this.DataGridToExcel(this.DataGrid1,"���۳ɱ�������");
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
