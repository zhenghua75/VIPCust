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

namespace VCustApp.BusinessChance
{
	/// <summary>
	/// wfmFour 的摘要说明。
	/// </summary>
	public class wfmFour : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;		
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtProjectName;		
		protected System.Web.UI.WebControls.Label Label4;					
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.DropDownList ddlOper;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Button btnCance;
		protected System.Web.UI.WebControls.Repeater Repeater1;
		protected System.Web.UI.WebControls.Repeater Repeater2;
		protected System.Web.UI.WebControls.Repeater Repeater3;
		protected System.Web.UI.WebControls.TextBox txtProjectID;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.DropDownList ddlTradeMgr;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!this.IsPostBack)
			{
				if(Request["cnnProjectID"] == null )
				{
					Popup("无效链接");
					return;
				}
				
				this.BindDropDownList(ddlDept,ConstApp.A_DEPT,"");
				this.BindDropDownList(ddlOper,ConstApp.A_OPER,"");
				this.BindDropDownList(ddlTradeMgr,ConstApp.A_OPER,"");
				string strProjectID = Request["cnnProjectID"].ToString();
				this.txtProjectID.Text = strProjectID;
				DataTable dtProject = Helper.Query("select * from tbProject where cnnProjectID="+strProjectID);
				if(dtProject.Rows.Count > 0)
				{
					Project project = new Project(dtProject);
					ListItem liDept = this.ddlDept.Items.FindByValue(project.cnvcDeptID);
					if(liDept != null)
						liDept.Selected = true;
					ListItem liOper = this.ddlOper.Items.FindByValue(project.cnvcMgr);
					if(liOper != null)
						liOper.Selected = true;
					ListItem liTradeMgr = this.ddlTradeMgr.Items.FindByValue(project.cnvcTradeMgr);
					if(liTradeMgr != null)
						liTradeMgr.Selected = true;
					this.txtProjectName.Text = project.cnvcChanceName;
					DataTable dtCust = Helper.Query("select * from tbCust where cnnCustID="+project.cnnCustID.ToString());
					if(dtCust.Rows.Count > 0)
					{
						Cust cust = new Cust(dtCust);
						this.txtCustName.Text = cust.cnvcName;
					}
				}
				//DataTable dtDeptType = (DataTable)Application[ConstApp.A_NAMECODE];
				string strSql = "select cnvcCode as cnvcDeptType,cnvcName as cnvcDeptTypeComments,'' as cnvcImage1,'' as cnvcComments from tbNameCode where cnvcType='DEPT_TYPE' order by cnnSeqNo";
				DataTable dtDeptType = Helper.Query(strSql);

				string strSql2 = "select *,'' as cnvcImage1,'' as cnvcImage2 from tbVisit where cnnProjectID="+txtProjectID.Text+" order by cndOperDate";
				DataTable dtVisit2 = Helper.Query(strSql2);
				DataTable dtVisit = dtVisit2.Copy();
				Hashtable htLaughDeptType = new Hashtable();
				Hashtable htCryDeptType = new Hashtable();
				int count = 0;
//				Hashtable htVisit = new Hashtable();
				foreach(DataRow drVisit in dtVisit2.Rows)
				{
					Visit visit = new Visit(drVisit);
					DataRow[] drVisits = dtVisit.Select("cnvcVisitMan='"+visit.cnvcVisitMan+"'");
					if(drVisits.Length > 1)
					{
						dtVisit.Rows.Remove(drVisits[0]);
					}
				}

				foreach(DataRow drVisit in dtVisit.Rows)
				{
					Visit visit = new Visit(drVisit);
					if((visit.cnvcCustType == "C001" || visit.cnvcCustType=="C002" ) && (visit.cnvcWellType == "W001" || visit.cnvcWellType == "W002"))
					{
						if(htLaughDeptType.ContainsKey(visit.cnvcDeptType))
						{
							count = Convert.ToInt32(htLaughDeptType[visit.cnvcDeptType]);
							htLaughDeptType[visit.cnvcDeptType] = count +1;
						}
						else
						{
							htLaughDeptType.Add(visit.cnvcDeptType,1);
						}
						//drVisit["cnvcImage2"] = "laugh.jpg";
					}
					else
					{
						if(htCryDeptType.ContainsKey(visit.cnvcDeptType))
						{
							count = Convert.ToInt32(htCryDeptType[visit.cnvcDeptType]);
							htCryDeptType[visit.cnvcDeptType] = count +1;
						}
						else
						{
							htCryDeptType.Add(visit.cnvcDeptType,1);
						}
						//drVisit["cnvcImage2"] = "cry.jpg";
					}
				}

			
				foreach(DataRow dr in dtDeptType.Rows)
				{
					string strDeptType = dr["cnvcDeptType"].ToString();
					if(htLaughDeptType.ContainsKey(strDeptType))
					{
						if(htCryDeptType.ContainsKey(strDeptType))
						{
							int iLaugh = Convert.ToInt32(htLaughDeptType[strDeptType]);
							int iCry = Convert.ToInt32(htCryDeptType[strDeptType]);
							if(iLaugh >= iCry)
							{
								dr["cnvcImage1"] = "sucess.png";
							}
							else
							{
								dr["cnvcImage1"] = "fail.png";
								dr["cnvcComments"] = "加强客户拜访，改善客户关系";
							}
						}
						else
						{
							dr["cnvcImage1"] = "sucess.png";
						}
					}
					else
					{
						dr["cnvcImage1"] = "fail.png";
						dr["cnvcComments"] = "加强客户拜访，改善客户关系";
					}
				}
				DataView dvDeptType = new DataView(dtDeptType);
				this.Repeater1.DataSource = dtDeptType;
				this.Repeater1.DataBind();
				
				//Bind(strProjectID);
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
			this.btnCance.Click += new System.EventHandler(this.btnCance_Click);
			this.Repeater1.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.Repeater1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void Bind(string strProjectID)
		{
			
			
		}
		private void btnCance_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("wfmFourChanceQuery.aspx");
		}

		private void Repeater1_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			string strSql = "select *,'' as cnvcImage1,'' as cnvcImage2 from tbVisit where cnnProjectID="+txtProjectID.Text+" order by cndOperDate";
			DataTable dtVisit2 = Helper.Query(strSql);
			DataTable dtVisit = dtVisit2.Copy();
			Hashtable htLaughDeptType = new Hashtable();
			Hashtable htCryDeptType = new Hashtable();
			int count = 0;
			foreach(DataRow drVisit in dtVisit2.Rows)
			{
				Visit visit = new Visit(drVisit);
				
				DataRow[] drVisits = dtVisit.Select("cnvcVisitMan='"+visit.cnvcVisitMan+"'");
				if(drVisits.Length > 1)
				{
					dtVisit.Rows.Remove(drVisits[0]);
				}
//				else
//				{
//					//object[] obj = drVisit.ItemArray;
//					dtVisit.Rows.Add(drVisit.ItemArray);
//				}
			}
			//整理图片
			//笑脸laugh.jpg
			//“客户类型”属于“积极型”或“悲观型”
			//C001 OR C002 
			//被访人的“客户态度”为“推荐”或“支持”
			//W001 OR W002
			foreach(DataRow drVisit in dtVisit.Rows)
			{
				Visit visit = new Visit(drVisit);
				if((visit.cnvcCustType == "C001" || visit.cnvcCustType=="C002" ) && (visit.cnvcWellType == "W001" || visit.cnvcWellType == "W002"))
				{
					if(htLaughDeptType.ContainsKey(visit.cnvcDeptType))
					{
						count = Convert.ToInt32(htLaughDeptType[visit.cnvcDeptType]);
						htLaughDeptType[visit.cnvcDeptType] = count +1;
					}
					else
					{
						htLaughDeptType.Add(visit.cnvcDeptType,1);
					}
					drVisit["cnvcImage2"] = "laugh.jpg";
				}
				else
				{
					if(htCryDeptType.ContainsKey(visit.cnvcDeptType))
					{
						count = Convert.ToInt32(htCryDeptType[visit.cnvcDeptType]);
						htCryDeptType[visit.cnvcDeptType] = count +1;
					}
					else
					{
						htCryDeptType.Add(visit.cnvcDeptType,1);
					}
					drVisit["cnvcImage2"] = "cry.jpg";
				}
			}
			
			this.DataTableConvert(dtVisit,"cnvcAffect",ConstApp.A_NAMECODE,"cnvcType='AFFECT_TYPE'");
			this.DataTableConvert(dtVisit,"cnvcCustType",ConstApp.A_NAMECODE,"cnvcType='CUSTOME_TYPE'");
			this.DataTableConvert(dtVisit,"cnvcWellType",ConstApp.A_NAMECODE,"cnvcType='WELL_TYPE'");			

			if (e.Item.ItemType == ListItemType.Item) 
			{
				Repeater rpt = (Repeater) e.Item.FindControl("Repeater2");				
				DataRowView rowv = (DataRowView)e.Item.DataItem;				
				string strDeptType = rowv["cnvcDeptType"].ToString();		
				DataView dv = new DataView(dtVisit);
				dv.RowFilter = "cnvcDeptType='"+strDeptType+"'";
				if(dv.Count == 0)
				{
					DataRowView drv = dv.AddNew();
					drv["cnvcVisitMan"] = "无";
					drv["cnvcAffectComments"] = "";
					drv["cnvcCustTypeComments"] = "";
					drv["cnvcWellTypeComments"] = "";
					drv["cnvcImage2"] = "cry.jpg";
				}
				rpt.DataSource = dv;
				rpt.DataBind();
			}
			if( e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Repeater rpt = (Repeater) e.Item.FindControl("Repeater3");				
				DataRowView rowv = (DataRowView)e.Item.DataItem;				
				string strDeptType = rowv["cnvcDeptType"].ToString();		
				DataView dv = new DataView(dtVisit);
				dv.RowFilter = "cnvcDeptType='"+strDeptType+"'";
				if(dv.Count == 0)
				{
					DataRowView drv = dv.AddNew();
					drv["cnvcVisitMan"] = "无";
					drv["cnvcAffectComments"] = "";
					drv["cnvcCustTypeComments"] = "";
					drv["cnvcWellTypeComments"] = "";
					drv["cnvcImage2"] = "cry.jpg";
				}
				rpt.DataSource = dv;
				rpt.DataBind();
			}
		}
	}
}
