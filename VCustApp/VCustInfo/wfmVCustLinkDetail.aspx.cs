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
	/// wfmVCustLink 的摘要说明。
	/// </summary>
	public class wfmVCustLinkDetail : wfmBase
	{
		protected System.Web.UI.WebControls.TextBox txtLinkAddress;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.Label Label29;
		protected System.Web.UI.WebControls.TextBox txtLinkMobilePhone;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.TextBox txtLinkDeskPhone;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.TextBox txtLinkWorkRange;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.TextBox txtLinkOfficer;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.DropDownList ddlLinkDeptType;
		protected System.Web.UI.WebControls.Label Label24;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.DropDownList ddlLinkType;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.DropDownList ddlLinkDegree;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.DropDownList ddlLinkSex;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.TextBox txtLinkName;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCustID;
		protected System.Web.UI.WebControls.Button btnMod;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.Label Label32;
		protected System.Web.UI.WebControls.TextBox txtLove;
		protected System.Web.UI.WebControls.Label Label30;
		protected System.Web.UI.WebControls.TextBox txtBirthday;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtLinkID;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!this.IsPostBack)
			{
				this.RegisterStartupScript("hide","<script lanaguage=javascript>ShowHide('1','none');</script>");
				string strOperType=this.Request.QueryString["type"];
				string strCustID=this.Request.QueryString["cid"];
				string strLinkID=this.Request.QueryString["lid"];
				this.BindDropDownList(this.ddlLinkSex,ConstApp.A_NAMECODE,"cnvcType='SEX_TYPE'");
				this.BindDropDownList(this.ddlLinkDegree,ConstApp.A_NAMECODE,"cnvcType='EDUCATION_TYPE'");
				this.BindDropDownList(this.ddlLinkType,ConstApp.A_NAMECODE,"cnvcType='LINK_TYPE'");
				this.BindDropDownList(this.ddlLinkDeptType,ConstApp.A_NAMECODE,"cnvcType='RELATIVEDEPT_TYPE'");
				this.txtCustID.ReadOnly=true;
				this.txtLinkID.ReadOnly=true;
				this.ddlLinkDeptType.Enabled=false;
				if(strOperType=="add")
				{
					this.btnMod.Enabled=false;
					if(strCustID==null||strCustID=="")
					{
						Popup("客户编号不正确！");
						Response.Write("<script>window.history.back();</script>");
						return;
					}
					this.txtCustID.Text=strCustID;
					this.txtBirthday.Text=DateTime.Now.ToShortDateString();
					DataTable dtCustDept=Helper.Query("select cnvcRelativeDept,cnvcRelativeDeptType,cnvcRelativeDept2,cnvcRelativeDeptType2,cnvcRelativeDept3,cnvcRelativeDeptType3,cnvcRelativeDept4,cnvcRelativeDeptType4,cnvcRelativeDept5,cnvcRelativeDeptType5 from tbCust where cnnCustID="+strCustID);
					Hashtable htCustDeptType=new Hashtable();
					string strDeptField="cnvcRelativeDept";
					string strDeptTypeField="cnvcRelativeDeptType";
					if(dtCustDept.Rows[0]["cnvcRelativeDept"].ToString()!="")
					{
						this.ddlDept.Items.Add(new ListItem(dtCustDept.Rows[0]["cnvcRelativeDept"].ToString(),dtCustDept.Rows[0]["cnvcRelativeDept"].ToString()));
						htCustDeptType.Add("1",dtCustDept.Rows[0]["cnvcRelativeDeptType"].ToString());
					}
					for(int i=2;i<=5;i++)
					{
						if(dtCustDept.Rows[0][strDeptField+i.ToString()].ToString()!="")
						{
							this.ddlDept.Items.Add(new ListItem(dtCustDept.Rows[0][strDeptField+i.ToString()].ToString(),dtCustDept.Rows[0][strDeptField+i.ToString()].ToString()));
							htCustDeptType.Add(i.ToString(),dtCustDept.Rows[0][strDeptTypeField+i.ToString()].ToString());
						}
					}
					Session["CustDeptType"]=htCustDeptType;
				}
				else
				{
					this.btnAdd.Enabled=false;
					if(strLinkID==null||strLinkID=="")
					{
						Popup("联系人不正确！");
						Response.Write("<script>window.history.back();</script>");
						return;
					}
					this.txtLinkID.Text=strLinkID;
					DataTable dtout=Helper.Query("select * from tbLink where cnnLinkID="+strLinkID);
					if(dtout==null||dtout.Rows.Count==0)
					{
						Popup("联系人不存在！");
						Response.Write("<script>window.history.back();</script>");
						return;
					}
					else
					{
						Link newlink=new Link(dtout.Rows[0]);
						this.txtCustID.Text=newlink.cnnCustID.ToString();

						DataTable dtCustDept=Helper.Query("select cnvcRelativeDept,cnvcRelativeDeptType,cnvcRelativeDept2,cnvcRelativeDeptType2,cnvcRelativeDept3,cnvcRelativeDeptType3,cnvcRelativeDept4,cnvcRelativeDeptType4,cnvcRelativeDept5,cnvcRelativeDeptType5 from tbCust where cnnCustID="+newlink.cnnCustID.ToString());
						Hashtable htCustDeptType=new Hashtable();
						string strDeptField="cnvcRelativeDept";
						string strDeptTypeField="cnvcRelativeDeptType";
						if(dtCustDept.Rows[0]["cnvcRelativeDept"].ToString()!="")
						{
							this.ddlDept.Items.Add(new ListItem(dtCustDept.Rows[0]["cnvcRelativeDept"].ToString(),dtCustDept.Rows[0]["cnvcRelativeDept"].ToString()));
							htCustDeptType.Add("1",dtCustDept.Rows[0]["cnvcRelativeDeptType"].ToString());
						}
						for(int i=2;i<=5;i++)
						{
							if(dtCustDept.Rows[0][strDeptField+i.ToString()].ToString()!="")
							{
								this.ddlDept.Items.Add(new ListItem(dtCustDept.Rows[0][strDeptField+i.ToString()].ToString(),dtCustDept.Rows[0][strDeptField+i.ToString()].ToString()));
								htCustDeptType.Add(i.ToString(),dtCustDept.Rows[0][strDeptTypeField+i.ToString()].ToString());
							}
						}
						Session["CustDeptType"]=htCustDeptType;

						this.txtLinkName.Text=newlink.cnvcName;
						this.ddlLinkSex.SelectedIndex=ddlLinkSex.Items.IndexOf(ddlLinkSex.Items.FindByValue(newlink.cnvcSex));
						this.txtBirthday.Text=newlink.cndBirthday.ToShortDateString();
						this.ddlLinkDegree.SelectedIndex=ddlLinkDegree.Items.IndexOf(ddlLinkDegree.Items.FindByValue(newlink.cnvcEducation));
						this.ddlLinkType.SelectedIndex=ddlLinkType.Items.IndexOf(ddlLinkType.Items.FindByValue(newlink.cnvcLinkType));
						this.ddlDept.SelectedIndex=ddlDept.Items.IndexOf(ddlDept.Items.FindByValue(newlink.cnvcDeptName));
						this.ddlLinkDeptType.SelectedIndex=ddlLinkDeptType.Items.IndexOf(ddlLinkDeptType.Items.FindByValue(newlink.cnvcRelativeDeptType));
						this.txtLinkOfficer.Text=newlink.cnvcDuty;
						this.txtLinkWorkRange.Text=newlink.cnvcJob;
						this.txtLinkDeskPhone.Text=newlink.cnvcPhone;
						this.txtLinkMobilePhone.Text=newlink.cnvcMobilePhone;
						this.txtEmail.Text=newlink.cnvcEmail;
						this.txtLove.Text=newlink.cnvcLike;
						this.txtLinkAddress.Text=newlink.cnvcAddress;
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
			this.ddlDept.SelectedIndexChanged += new System.EventHandler(this.ddlDept_SelectedIndexChanged);
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
				if(this.JudgeIsNull(txtLinkName.Text.Trim(),"姓名"))
					return;
				Link newlink=new Link();
				newlink.cnnLinkID=decimal.Parse(this.txtLinkID.Text.Trim());
				newlink.cnnCustID=decimal.Parse(this.txtCustID.Text.Trim());
				newlink.cnvcName=this.txtLinkName.Text.Trim();
				newlink.cnvcSex=ddlLinkSex.SelectedValue;
				newlink.cndBirthday=DateTime.Parse(this.txtBirthday.Text.Trim());
				newlink.cnvcEducation=this.ddlLinkDegree.SelectedValue;
				newlink.cnvcLinkType=this.ddlLinkType.SelectedValue;
				newlink.cnvcDeptName=this.ddlDept.SelectedValue;
				newlink.cnvcRelativeDeptType=this.ddlLinkDeptType.SelectedValue;
				newlink.cnvcDuty=this.txtLinkOfficer.Text.Trim();
				newlink.cnvcJob=this.txtLinkWorkRange.Text.Trim();
				newlink.cnvcPhone=this.txtLinkDeskPhone.Text.Trim();
				newlink.cnvcMobilePhone=this.txtLinkMobilePhone.Text.Trim();
				newlink.cnvcEmail=this.txtEmail.Text.Trim();
				newlink.cnvcLike=this.txtLove.Text.Trim();
				newlink.cnvcAddress=this.txtLinkAddress.Text.Trim();
				newlink.cnvcOperID=oper.cnvcOperID;
				VCustInfoFacade.UpdateLink(newlink,oper);
				Popup("修改联系人信息成功");
				this.RegisterStartupScript("hide","<script lanaguage=javascript>ShowHide('1','none');</script>");
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
				if(this.JudgeIsNull(txtLinkName.Text.Trim(),"姓名"))
					return;
				Link newlink=new Link();
				newlink.cnnCustID=decimal.Parse(this.txtCustID.Text.Trim());
				newlink.cnvcName=this.txtLinkName.Text.Trim();
				newlink.cnvcSex=ddlLinkSex.SelectedValue;
				newlink.cndBirthday=DateTime.Parse(this.txtBirthday.Text.Trim());
				newlink.cnvcEducation=this.ddlLinkDegree.SelectedValue;
				newlink.cnvcLinkType=this.ddlLinkType.SelectedValue;
				newlink.cnvcDeptName=this.ddlDept.SelectedValue;
				newlink.cnvcRelativeDeptType=this.ddlLinkDeptType.SelectedValue;
				newlink.cnvcDuty=this.txtLinkOfficer.Text.Trim();
				newlink.cnvcJob=this.txtLinkWorkRange.Text.Trim();
				newlink.cnvcPhone=this.txtLinkDeskPhone.Text.Trim();
				newlink.cnvcMobilePhone=this.txtLinkMobilePhone.Text.Trim();
				newlink.cnvcEmail=this.txtEmail.Text.Trim();
				newlink.cnvcLike=this.txtLove.Text.Trim();
				newlink.cnvcAddress=this.txtLinkAddress.Text.Trim();
				newlink.cnvcOperID=oper.cnvcOperID;

				VCustInfoFacade.AddLink(newlink,oper);
				Popup("新联系人信息添加成功");
				this.RegisterStartupScript("hide","<script lanaguage=javascript>ShowHide('1','none');</script>");
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			if(this.txtCustID.Text.Trim()!="")
			{
				this.Response.Redirect("wfmVCustLink.aspx?cid="+this.txtCustID.Text.Trim());
			}			
		}

		private void ddlDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Hashtable htdepttype=(Hashtable)Session["CustDeptType"];
			string strIndex=(this.ddlDept.SelectedIndex+1).ToString();
			this.ddlLinkDeptType.SelectedIndex=ddlLinkDeptType.Items.IndexOf(ddlLinkDeptType.Items.FindByValue(htdepttype[strIndex].ToString()));
		}
	}
}
