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
using VCustApp.Entity.EntityClass;
using VCustApp.BusinessFacade;

namespace VCustApp.VCustInfo
{
	/// <summary>
	/// wfmVisitAddMod 的摘要说明。
	/// </summary>
	public class wfmVisitAddMod : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCustID;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.Label Label24;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.Label Label29;
		protected System.Web.UI.WebControls.Button btnMod;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtMgr;
		protected System.Web.UI.WebControls.DropDownList ddlConType;
		protected System.Web.UI.WebControls.DropDownList ddlVisitContent;
		protected System.Web.UI.WebControls.TextBox txtVisitDept;
		protected System.Web.UI.WebControls.DropDownList ddlDeptType;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlManType;
		protected System.Web.UI.WebControls.DropDownList ddlAffect;
		protected System.Web.UI.WebControls.DropDownList ddlCustType;
		protected System.Web.UI.WebControls.DropDownList ddlWellType;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.DropDownList ddlCorpRelation;
		protected System.Web.UI.WebControls.DropDownList ddlPrivateRelation;
		protected System.Web.UI.WebControls.DropDownList ddlProjectSpeed;
		protected System.Web.UI.WebControls.DropDownList ddlDemandType;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtVisitID;
		protected System.Web.UI.WebControls.DropDownList ddlProject;
		protected System.Web.UI.WebControls.Label lblVisitDate;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtComments;
		protected System.Web.UI.WebControls.DropDownList ddlVisitMan;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!this.IsPostBack)
			{
				string strOperType=this.Request.QueryString["type"];
				string strCustID=this.Request.QueryString["cid"];
				string strVisitID=this.Request.QueryString["vid"];
				this.BindDropDownList(this.ddlConType,ConstApp.A_NAMECODE,"cnvcType='VISIT_CONTENT'");
				this.BindDropDownList(this.ddlVisitContent,ConstApp.A_NAMECODE,"cnvcType='"+ddlConType.SelectedValue+"'");
				this.BindDropDownList(this.ddlDeptType,ConstApp.A_NAMECODE,"cnvcType='DEPT_TYPE'");
				this.BindDropDownList(this.ddlManType,ConstApp.A_NAMECODE,"cnvcType='MAN_TYPE'");
				this.BindDropDownList(this.ddlAffect,ConstApp.A_NAMECODE,"cnvcType='AFFECT_TYPE'");
				this.BindDropDownList(this.ddlCustType,ConstApp.A_NAMECODE,"cnvcType='CUSTVISIT_TYPE'");
				this.BindDropDownList(this.ddlWellType,ConstApp.A_NAMECODE,"cnvcType='WELL_TYPE'");
				this.BindDropDownList(this.ddlCorpRelation,ConstApp.A_NAMECODE,"cnvcType='CORP_RELATION'");
				this.BindDropDownList(this.ddlPrivateRelation,ConstApp.A_NAMECODE,"cnvcType='PRIVATE_RELATION'");
				this.BindDropDownList(this.ddlProjectSpeed,ConstApp.A_NAMECODE,"cnvcType='PROJECT_SPEED'");
				this.BindDropDownList(this.ddlDemandType,ConstApp.A_NAMECODE,"cnvcType='DEMAND_TYPE'");
				this.txtCustID.ReadOnly=true;
				this.txtVisitID.ReadOnly=true;
				this.txtVisitDept.ReadOnly=true;
				this.txtMgr.ReadOnly=true;
				if(strOperType=="add")
				{
					this.btnMod.Enabled=false;
					this.txtVisitID.Enabled=false;
					this.lblVisitDate.Text=DateTime.Now.ToShortDateString();
					this.txtMgr.Text=oper.cnvcOperName;
					if(strCustID==null||strCustID=="")
					{
						Popup("客户编号不正确！");
						Response.Write("<script>window.history.back();</script>");
						return;
					}
					this.txtCustID.Text=strCustID;
					DataTable dtChance=Helper.Query("select cnnProjectID,cnvcChanceName from tbProject where cnnCustID="+strCustID);
					this.ddlProject.DataSource=dtChance;
					ddlProject.DataValueField = "cnnProjectID";
					ddlProject.DataTextField = "cnvcChanceName";
					this.ddlProject.DataBind();

					DataTable dtLink=Helper.Query("select cnvcName,cnvcLinkType,cnvcDeptName from tbLink where cnnCustID="+strCustID+" order by cnvcName");
					Session["CustLink"]=dtLink.Copy();
					this.ddlVisitMan.DataSource=dtLink;
					ddlVisitMan.DataValueField = "cnvcName";
					ddlVisitMan.DataTextField = "cnvcName";
					this.ddlVisitMan.DataBind();
					for(int i=0;i<dtLink.Rows.Count;i++)
					{
						if(ddlVisitMan.SelectedValue==dtLink.Rows[i]["cnvcName"].ToString())
						{
							this.txtVisitDept.Text=dtLink.Rows[i]["cnvcDeptName"].ToString();
							break;
						}
					}
				}
				else
				{
					this.btnAdd.Enabled=false;
					this.txtVisitDept.ReadOnly=true;
					this.ddlVisitMan.Enabled=false;
					if(strVisitID==null||strVisitID=="")
					{
						Popup("拜访流水不正确！");
						Response.Write("<script>window.history.back();</script>");
						return;
					}
					this.txtVisitID.Text=strVisitID;
					DataTable dtout=Helper.Query("select * from tbVisit where cnnVisitSerialNo="+strVisitID);
					if(dtout==null||dtout.Rows.Count==0)
					{
						Popup("拜访记录不存在！");
						Response.Write("<script>window.history.back();</script>");
						return;
					}
					else
					{
						Visit newvisit=new Visit(dtout.Rows[0]);
						DataTable dtChance=Helper.Query("select cnnProjectID,cnvcChanceName from tbProject where cnnCustID="+newvisit.cnnCustID);
						this.ddlProject.DataSource=dtChance;
						ddlProject.DataValueField = "cnnProjectID";
						ddlProject.DataTextField = "cnvcChanceName";
						this.ddlProject.DataBind();

						this.txtCustID.Text=newvisit.cnnCustID.ToString();
						this.ddlProject.SelectedIndex=ddlProject.Items.IndexOf(ddlProject.Items.FindByValue(newvisit.cnnProjectID.ToString()));
						this.lblVisitDate.Text=newvisit.cndVisitDate.ToShortDateString();
						this.ddlVisitContent.SelectedIndex=ddlVisitContent.Items.IndexOf(ddlVisitContent.Items.FindByValue(newvisit.cnvcVisitContent));
						this.txtVisitDept.Text=newvisit.cnvcVisitDept;
						this.ddlDeptType.SelectedIndex=ddlDeptType.Items.IndexOf(ddlDeptType.Items.FindByValue(newvisit.cnvcDeptType));
						this.ddlVisitMan.Items.Add(new ListItem(newvisit.cnvcVisitMan,newvisit.cnvcVisitMan));
						this.ddlManType.SelectedIndex=ddlManType.Items.IndexOf(ddlManType.Items.FindByValue(newvisit.cnvcManType));
						this.ddlAffect.SelectedIndex=ddlAffect.Items.IndexOf(ddlAffect.Items.FindByValue(newvisit.cnvcAffect));
						this.ddlCustType.SelectedIndex=ddlCustType.Items.IndexOf(ddlCustType.Items.FindByValue(newvisit.cnvcCustType));
						this.ddlWellType.SelectedIndex=ddlWellType.Items.IndexOf(ddlWellType.Items.FindByValue(newvisit.cnvcWellType));
						this.ddlCorpRelation.SelectedIndex=ddlCorpRelation.Items.IndexOf(ddlCorpRelation.Items.FindByValue(newvisit.cnvcCorpRelation));
						this.ddlPrivateRelation.SelectedIndex=ddlPrivateRelation.Items.IndexOf(ddlPrivateRelation.Items.FindByValue(newvisit.cnvcPrivateRelation));
						this.ddlProjectSpeed.SelectedIndex=ddlProjectSpeed.Items.IndexOf(ddlProjectSpeed.Items.FindByValue(newvisit.cnvcProjectSpeed));
						this.ddlDemandType.SelectedIndex=ddlDemandType.Items.IndexOf(ddlDemandType.Items.FindByValue(newvisit.cnvcDemandType));
						this.txtComments.Text=newvisit.cnvcComments;
						this.txtMgr.Text=newvisit.cnvcMgr;
					}
				}
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
			this.ddlConType.SelectedIndexChanged += new System.EventHandler(this.ddlConType_SelectedIndexChanged);
			this.ddlVisitMan.SelectedIndexChanged += new System.EventHandler(this.ddlVisitMan_SelectedIndexChanged);
			this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnMod_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(this.JudgeIsNull(this.ddlVisitMan.SelectedValue,"拜访人"))
					return;
				if(this.JudgeIsNull(this.txtVisitDept.Text.Trim(),"拜访部门"))
					return;
				Visit newvisit=new Visit();
				newvisit.cnnVisitSerialNo=decimal.Parse(this.txtVisitID.Text.Trim());
				if(this.ddlProject.SelectedValue=="")
				{
					newvisit.cnnProjectID=0;
				}
				else
				{
					newvisit.cnnProjectID=decimal.Parse(this.ddlProject.SelectedValue);
				}
				newvisit.cnnCustID=decimal.Parse(this.txtCustID.Text.Trim());
				newvisit.cnvcMgr=this.txtMgr.Text.Trim();
				newvisit.cndVisitDate=DateTime.Parse(this.lblVisitDate.Text.Trim());
				newvisit.cnvcVisitContent=this.ddlVisitContent.SelectedValue;
				newvisit.cnvcVisitDept=this.txtVisitDept.Text.Trim();
				newvisit.cnvcDeptType=this.ddlDeptType.SelectedValue;
				newvisit.cnvcVisitMan=this.ddlVisitMan.SelectedValue;
				newvisit.cnvcManType=this.ddlManType.SelectedValue;
				newvisit.cnvcAffect=this.ddlAffect.SelectedValue;
				newvisit.cnvcCustType=this.ddlCustType.SelectedValue;
				newvisit.cnvcWellType=this.ddlWellType.SelectedValue;
				newvisit.cnvcCorpRelation=this.ddlCorpRelation.SelectedValue;
				newvisit.cnvcPrivateRelation=this.ddlPrivateRelation.SelectedValue;
				newvisit.cnvcProjectSpeed=this.ddlProjectSpeed.SelectedValue;
//				newvisit.cnvcFour=this.ddlManBelong.SelectedValue;
				newvisit.cnvcFour=this.ddlDeptType.SelectedValue;
				newvisit.cnvcDemandType=this.ddlDemandType.SelectedValue;
				newvisit.cnvcOperID=oper.cnvcOperID;
				newvisit.cnvcComments=this.txtComments.Text.Trim();

				VCustInfoFacade.UpdateVisit(newvisit,oper);
				Popup("拜访记录修改成功");
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(this.JudgeIsNull(this.ddlVisitMan.SelectedValue,"拜访人"))
					return;
				if(this.JudgeIsNull(this.txtVisitDept.Text.Trim(),"拜访部门"))
					return;
				Visit newvisit=new Visit();
				if(this.ddlProject.SelectedValue=="")
				{
					newvisit.cnnProjectID=0;
				}
				else
				{
					newvisit.cnnProjectID=decimal.Parse(this.ddlProject.SelectedValue);
				}
				newvisit.cnnCustID=decimal.Parse(this.txtCustID.Text.Trim());
				newvisit.cnvcMgr=this.txtMgr.Text.Trim();
				newvisit.cndVisitDate=DateTime.Parse(this.lblVisitDate.Text.Trim());
				newvisit.cnvcVisitContent=this.ddlVisitContent.SelectedValue;
				newvisit.cnvcVisitDept=this.txtVisitDept.Text.Trim();
				newvisit.cnvcDeptType=this.ddlDeptType.SelectedValue;
				newvisit.cnvcVisitMan=this.ddlVisitMan.SelectedValue;
				newvisit.cnvcManType=this.ddlManType.SelectedValue;
				newvisit.cnvcAffect=this.ddlAffect.SelectedValue;
				newvisit.cnvcCustType=this.ddlCustType.SelectedValue;
				newvisit.cnvcWellType=this.ddlWellType.SelectedValue;
				newvisit.cnvcCorpRelation=this.ddlCorpRelation.SelectedValue;
				newvisit.cnvcPrivateRelation=this.ddlPrivateRelation.SelectedValue;
				newvisit.cnvcProjectSpeed=this.ddlProjectSpeed.SelectedValue;
				newvisit.cnvcDemandType=this.ddlDemandType.SelectedValue;
				newvisit.cnvcOperID=oper.cnvcOperID;
				newvisit.cnvcComments=this.txtComments.Text.Trim();

				VCustInfoFacade.AddVisit(newvisit,oper);
				Popup("新拜访记录添加成功");
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("wfmCustRelationDeepReport.aspx");
		}

		private void ddlConType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.BindDropDownList(this.ddlVisitContent,ConstApp.A_NAMECODE,"cnvcType='"+ddlConType.SelectedValue+"'");
		}

		private void ddlVisitMan_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DataTable dtlink=(DataTable)Session["CustLink"];
			if(dtlink!=null||dtlink.Rows.Count>0)
			{
				for(int i=0;i<dtlink.Rows.Count;i++)
				{
					if(ddlVisitMan.SelectedValue==dtlink.Rows[i]["cnvcName"].ToString())
					{
						this.txtVisitDept.Text=dtlink.Rows[i]["cnvcDeptName"].ToString();
						break;
					}
				}
			}
		}
	}
}
