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

namespace VCustApp.VCustInfo
{
	/// <summary>
	/// Summary description for wfmVCustInfo.
	/// </summary>
	public class wfmVCustInfo : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.DropDownList ddlTrade1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlTrade2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlCustLevel;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Button btnExportIn;
		protected System.Web.UI.WebControls.DropDownList ddlTrade3;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!this.IsPostBack)
			{
				this.BindDropDownList(this.ddlTrade1,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=2","全部");
				this.BindDropDownList(this.ddlTrade2,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=4","全部");
				this.BindDropDownList(this.ddlTrade3,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=6","全部");
				this.BindDropDownList(this.ddlCustLevel,ConstApp.A_NAMECODE,"cnvcType='CUST_LEVEL'","全部");
				if(oper.cnvcRoleCode==null||oper.cnvcRoleCode=="")
				{
					this.btnAdd.Enabled=false;
				}
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.ddlTrade1.SelectedIndexChanged += new System.EventHandler(this.ddlTrade1_SelectedIndexChanged);
			this.ddlTrade2.SelectedIndexChanged += new System.EventHandler(this.ddlTrade2_SelectedIndexChanged);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.btnExportIn.Click += new System.EventHandler(this.btnExportIn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("wfmVCustDetail.aspx?type=add");
		}

		private void ddlTrade1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.ddlTrade1.SelectedValue!="全部")
			{
				this.BindDropDownList(this.ddlTrade2,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=4 and cnvcCode like '"+this.ddlTrade1.SelectedValue+"%'","全部");
				if(this.ddlTrade2.SelectedValue!="全部")
				{
					this.BindDropDownList(this.ddlTrade3,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=6 and cnvcCode like '"+this.ddlTrade2.SelectedValue+"%'","全部");
				}
				else
				{
					this.BindDropDownList(this.ddlTrade3,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=6 and cnvcCode like '"+this.ddlTrade1.SelectedValue+"%'","全部");
				}
			}
			else
			{
				this.BindDropDownList(this.ddlTrade2,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=4","全部");
				this.BindDropDownList(this.ddlTrade3,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=6","全部");
			}
		}

		private void ddlTrade2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.ddlTrade2.SelectedValue!="全部")
			{
				this.BindDropDownList(this.ddlTrade3,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=6 and cnvcCode like '"+this.ddlTrade2.SelectedValue+"%'","全部");
			}
			else
			{
				if(this.ddlTrade1.SelectedValue!="全部")
				{
					this.BindDropDownList(this.ddlTrade3,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=6 and cnvcCode like '"+this.ddlTrade1.SelectedValue+"%'","全部");
				}
				else
				{
					this.BindDropDownList(this.ddlTrade3,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=6","全部");
				}
			}
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			this.BindGrid();
		}

		private void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
			this.BindGrid();
		}

		private void BindGrid()
		{
			string strCustName=this.txtCustName.Text.Trim();
			string strLevel=this.ddlCustLevel.SelectedValue;
			string strTrade1=this.ddlTrade1.SelectedValue;
			string strTrade2=this.ddlTrade2.SelectedValue;
			string strTrade3=this.ddlTrade3.SelectedValue;
			string strCondition="";
			if(strCustName!="")
			{
				strCondition=" cnvcName like '%"+strCustName+"%'";
			}
			if(strLevel!="全部")
			{
				if(strCondition=="")
				{
					strCondition+=" cnvcLevel='"+strLevel+"'";
				}
				else
				{
					strCondition+=" and cnvcLevel='"+strLevel+"'";
				}
			}
			if(strTrade3!="全部")
			{
				if(strCondition=="")
				{
					strCondition+=" cnvcTradeType='"+strTrade3+"'";
				}
				else
				{
					strCondition+=" and cnvcTradeType='"+strTrade3+"'";
				}
			}
			else if(strTrade2!="全部")
			{
				if(strCondition=="")
				{
					strCondition+=" cnvcTradeType like '"+strTrade2+"%'";
				}
				else
				{
					strCondition+=" and cnvcTradeType like '"+strTrade2+"%'";
				}
			}
			else if(strTrade1!="全部")
			{
				if(strCondition=="")
				{
					strCondition+=" cnvcTradeType like '"+strTrade1+"%'";
				}
				else
				{
					strCondition+=" and cnvcTradeType like '"+strTrade1+"%'";
				}
			}
			switch(oper.cnvcRoleCode)
			{
				case "customer":
					if(strCondition=="")
					{
						strCondition+=" cnvcCustMana='"+oper.cnvcOperID+"'";
					}
					else
					{
						strCondition+=" and cnvcCustMana='"+oper.cnvcOperID+"'";
					}
					break;
				case "trade":
					if(strCondition=="")
					{
						strCondition+=" cnvcCustTradeMana='"+oper.cnvcOperID+"'";
					}
					else
					{
						strCondition+=" and cnvcCustTradeMana='"+oper.cnvcOperID+"'";
					}
					break;
				case "admin":
					break;
				case "manager":
					break;
				default:
					if(strCondition=="")
					{
						strCondition+=" 1=2";
					}
					else
					{
						strCondition+=" and 1=2";
					}
					break;
			}
			string strsql="select cnnCustID,cnvcName,cnvcLevel,cnvcAddress from tbCust";
			if(strCondition!="")
			{
				strsql+=" where "+strCondition;	
			}
			DataTable dtout=Helper.Query(strsql);
			this.DataTableConvert(dtout,"cnvcLevel",ConstApp.A_NAMECODE,"cnvcType='CUST_LEVEL'");
			this.DataGrid1.DataSource=dtout;
			this.DataGrid1.DataBind();
		}

		private void btnExportIn_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("../wfmFileUp.aspx?XlsType=CustInfo");
		}
	}
}
