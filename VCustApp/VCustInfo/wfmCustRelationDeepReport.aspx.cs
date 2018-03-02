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
	/// wfmCustRelationDeepReport 的摘要说明。
	/// </summary>
	public class wfmCustRelationDeepReport : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtCustID;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblCustID;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtBeginDate;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtChanceName;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!this.IsPostBack)
			{
				this.btnAdd.Enabled=false;
				this.txtBeginDate.Text=DateTime.Now.ToShortDateString();
				this.txtEndDate.Text=DateTime.Now.ToShortDateString();
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
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindGrid()
		{
			this.lblCustID.Text="";
			string strCustID=this.txtCustID.Text.Trim();
			string strCustName=this.txtCustName.Text.Trim();
			string strBeginDate=this.txtBeginDate.Text.Trim();
			string strEndDate=this.txtEndDate.Text.Trim();
			string strChanceName=this.txtChanceName.Text.Trim();
			if(strBeginDate==""||strEndDate=="")
			{
				this.Popup("开始和结束日期不能为空");
				return;
			}
			string strCondition="";
			if(strCustID!="")
			{
				strCondition=" and a.cnnCustID = "+strCustID;
			}
			if(strCustName!="")
			{
				strCondition+=" and a.cnvcName like '%"+strCustName+"%'";
			}
			switch(oper.cnvcRoleCode)
			{
				case "customer":
					strCondition+=" and a.cnvcCustMana='"+oper.cnvcOperID+"'";
					break;
				case "trade":
					strCondition+=" and a.cnvcCustTradeMana='"+oper.cnvcOperID+"'";
					break;
				case "admin":
					break;
				case "manager":
					break;
				default:
					strCondition+=" and 1=2";
					break;
			}
			string strsql="";
			if(strChanceName=="")
			{
				strsql="select c.cnnVisitSerialNo,a.cnnCustID as cnnCustID,a.cnvcName,b.cnvcChanceName,c.cnvcMgr,convert(char(10),c.cndVisitDate,120) as cndVisitDate,c.cnvcVisitContent,c.cnvcVisitDept,c.cnvcDeptType,c.cnvcVisitMan,c.cnvcManType,c.cnvcAffect,c.cnvcCustType,c.cnvcWellType,c.cnvcCorpRelation,";
				strsql+="c.cnvcPrivateRelation,c.cnvcProjectSpeed,c.cnvcFour,c.cnvcDemandType,c.cnvcComments from tbCust a,tbProject b,tbVisit c where a.cnnCustID=b.cnnCustID and a.cnnCustID=c.cnnCustID and b.cnnProjectID=c.cnnProjectID and c.cndVisitDate between '"+strBeginDate+"' and '"+strEndDate+"' "+strCondition;
				strsql+=" union select b.cnnVisitSerialNo,a.cnnCustID as cnnCustID,a.cnvcName,'' as cnvcChanceName,b.cnvcMgr,convert(char(10),b.cndVisitDate,120) as cndVisitDate,b.cnvcVisitContent,b.cnvcVisitDept,b.cnvcDeptType,b.cnvcVisitMan,b.cnvcManType,b.cnvcAffect,b.cnvcCustType,b.cnvcWellType,b.cnvcCorpRelation,";
				strsql+="b.cnvcPrivateRelation,b.cnvcProjectSpeed,b.cnvcFour,b.cnvcDemandType,b.cnvcComments from tbCust a,tbVisit b where b.cnnProjectID=0 and a.cnnCustID=b.cnnCustID and b.cndVisitDate between '"+strBeginDate+"' and '"+strEndDate+"' "+strCondition;
				if(strCustID!="")
				{
					strsql+=" and b.cnnProjectID not in(select distinct cnnProjectID from tbProject where cnnCustID="+strCustID+")";
				}
			}
			else
			{
				strsql="select c.cnnVisitSerialNo,a.cnnCustID as cnnCustID,a.cnvcName,b.cnvcChanceName,c.cnvcMgr,convert(char(10),c.cndVisitDate,120) as cndVisitDate,c.cnvcVisitContent,c.cnvcVisitDept,c.cnvcDeptType,c.cnvcVisitMan,c.cnvcManType,c.cnvcAffect,c.cnvcCustType,c.cnvcWellType,c.cnvcCorpRelation,";
				strsql+="c.cnvcPrivateRelation,c.cnvcProjectSpeed,c.cnvcFour,c.cnvcDemandType,c.cnvcComments from tbCust a,tbProject b,tbVisit c where a.cnnCustID=b.cnnCustID and a.cnnCustID=c.cnnCustID and b.cnnProjectID=c.cnnProjectID and c.cndVisitDate between '"+strBeginDate+"' and '"+strEndDate+"' and b.cnvcChanceName like '%"+strChanceName+"%'"+strCondition;
			}

			strsql+=" order by cnnVisitSerialNo ";
			DataTable dtout=Helper.Query(strsql);
			if(dtout.Rows.Count==0)
			{
				if(strCondition!="")
				{
					DataTable dtCust=Helper.Query("select a.cnnCustID from tbCust a where "+strCondition.Substring(4,strCondition.Length-4));
					if(dtCust.Rows.Count==0)
					{
						this.Popup("客户不存在或你无权操作该客户！");
						return;
					}
					else
					{
						this.lblCustID.Text=dtCust.Rows[0]["cnnCustID"].ToString();
					}
				}
			}
			else
			{
				this.DataTableConvert(dtout,"cnvcVisitContent",ConstApp.A_NAMECODE,"cnvcType in('COMPETE','SERVICE')");
				this.DataTableConvert(dtout,"cnvcDeptType",ConstApp.A_NAMECODE,"cnvcType='DEPT_TYPE'");
				this.DataTableConvert(dtout,"cnvcManType",ConstApp.A_NAMECODE,"cnvcType='MAN_TYPE'");
				this.DataTableConvert(dtout,"cnvcAffect",ConstApp.A_NAMECODE,"cnvcType='AFFECT_TYPE'");
				this.DataTableConvert(dtout,"cnvcCustType",ConstApp.A_NAMECODE,"cnvcType='CUSTVISIT_TYPE'");
				this.DataTableConvert(dtout,"cnvcWellType",ConstApp.A_NAMECODE,"cnvcType='WELL_TYPE'");
				this.DataTableConvert(dtout,"cnvcCorpRelation",ConstApp.A_NAMECODE,"cnvcType='CORP_RELATION'");
				this.DataTableConvert(dtout,"cnvcPrivateRelation",ConstApp.A_NAMECODE,"cnvcType='PRIVATE_RELATION'");
				this.DataTableConvert(dtout,"cnvcProjectSpeed",ConstApp.A_NAMECODE,"cnvcType='PROJECT_SPEED'");
				this.DataTableConvert(dtout,"cnvcDemandType",ConstApp.A_NAMECODE,"cnvcType='DEMAND_TYPE'");
				this.DataTableConvert(dtout,"cnvcFour",ConstApp.A_NAMECODE,"cnvcType='VISITER_BELONG'");
				this.lblCustID.Text=dtout.Rows[0]["cnnCustID"].ToString();
			}
			this.DataGrid1.DataSource=dtout;
			this.DataGrid1.DataBind();

			if(this.lblCustID.Text.Trim().Length>0)
			{
				this.btnAdd.Enabled=true;
			}
			else
			{
				this.btnAdd.Enabled=false;
			}
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			this.BindGrid();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			string strCustID=this.lblCustID.Text.Trim();
			if(strCustID=="")
			{
				this.Popup("无当前客户信息，请重新查询！");
				return;
			}
			else
			{
				Response.Redirect("wfmVisitAddMod.aspx?type=add&&cid="+strCustID);
			}
		}

		private void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.DataGrid1.CurrentPageIndex=e.NewPageIndex;
			this.BindGrid();
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			this.DataGrid1.Columns[20].Visible = false;
			this.DataGridToExcel(this.DataGrid1,"客户销售进度报表");
		}

		public override void VerifyRenderingInServerForm(Control control)
		{
			// Confirms that an HtmlForm control is rendered for
		} 
	}
}
