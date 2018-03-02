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
	/// Summary description for wfmVCustDetail.
	/// </summary>
	public class wfmVCustDetail : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList ddlTrade1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlTrade2;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtCustID;
		protected System.Web.UI.WebControls.DropDownList ddlCustLevel;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtCompanyInstruction;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.DropDownList ddlPayAbility;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.TextBox txtMonthCons;
		protected System.Web.UI.WebControls.TextBox txtInfoDoneState;
		protected System.Web.UI.WebControls.TextBox txtCompetitorState;
		protected System.Web.UI.WebControls.TextBox txtInfoPlan;
		protected System.Web.UI.WebControls.Button btnMod;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DropDownList ddlConferState;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.DropDownList ddlTrade3;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.DropDownList ddlCustType;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.TextBox txtFax;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.TextBox txtPost;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.Label Label29;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.DropDownList ddlAreaCode;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Button btnAddNewLink;
		protected System.Web.UI.WebControls.TextBox txtDept5;
		protected System.Web.UI.WebControls.DropDownList ddlDeptType2;
		protected System.Web.UI.WebControls.TextBox txtDept;
		protected System.Web.UI.WebControls.DropDownList ddlDeptType;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.TextBox txtDept2;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.TextBox txtDept3;
		protected System.Web.UI.WebControls.Label Label24;
		protected System.Web.UI.WebControls.DropDownList ddlDeptType3;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.TextBox txtDept4;
		protected System.Web.UI.WebControls.Label Label30;
		protected System.Web.UI.WebControls.DropDownList ddlDeptType4;
		protected System.Web.UI.WebControls.Label Label31;
		protected System.Web.UI.WebControls.Label Label32;
		protected System.Web.UI.WebControls.DropDownList ddlDeptType5;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.DropDownList ddlCustMana;
		protected System.Web.UI.WebControls.Label Label33;
		protected System.Web.UI.WebControls.DropDownList ddlCustTradeMana;
		protected System.Web.UI.WebControls.Button btnAdd;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!this.IsPostBack)
			{
				this.RegisterStartupScript("hide","<script lanaguage=javascript>ShowHide('1','none');</script>");
				string strOperType=this.Request.QueryString["type"];
				string strCustID=this.Request.QueryString["id"];
				this.BindDropDownList(this.ddlTrade1,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=2");
				this.BindDropDownList(this.ddlTrade2,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=4 and cnvcCode like '"+this.ddlTrade1.SelectedValue+"%'");
				this.BindDropDownList(this.ddlTrade3,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=6 and cnvcCode like '"+this.ddlTrade2.SelectedValue+"%'");
				this.BindDropDownList(this.ddlCustLevel,ConstApp.A_NAMECODE,"cnvcType='CUST_LEVEL'");
				this.BindDropDownList(this.ddlDeptType,ConstApp.A_NAMECODE,"cnvcType='RELATIVEDEPT_TYPE'");
				this.BindDropDownList(this.ddlDeptType2,ConstApp.A_NAMECODE,"cnvcType='RELATIVEDEPT_TYPE'");
				this.BindDropDownList(this.ddlDeptType3,ConstApp.A_NAMECODE,"cnvcType='RELATIVEDEPT_TYPE'");
				this.BindDropDownList(this.ddlDeptType4,ConstApp.A_NAMECODE,"cnvcType='RELATIVEDEPT_TYPE'");
				this.BindDropDownList(this.ddlDeptType5,ConstApp.A_NAMECODE,"cnvcType='RELATIVEDEPT_TYPE'");
				this.BindDropDownList(this.ddlPayAbility,ConstApp.A_NAMECODE,"cnvcType='PAY_ABILITY'");
				this.BindDropDownList(this.ddlConferState,ConstApp.A_NAMECODE,"cnvcType='CONTRACT_TYPE'");
				this.BindDropDownList(this.ddlCustType,ConstApp.A_NAMECODE,"cnvcType='CUST_TYPE'");
				this.BindDropDownList(this.ddlAreaCode,ConstApp.A_AREACODE,"");
				this.txtCustID.ReadOnly=true;
				if(strOperType=="add")
				{
					this.btnAddNewLink.Enabled=false;
					this.btnMod.Enabled=false;
					DataTable dtout=Helper.Query("select isnull(Max(cnnCustID),0)+1 from tbCust where cnnCustID>700000");
					string strMaxCustID=dtout.Rows[0][0].ToString();
					if(strMaxCustID=="1")
					{
						this.txtCustID.Text="700001";
					}
					else
					{
						this.txtCustID.Text=strMaxCustID;
					}
					switch(oper.cnvcRoleCode)
					{
						case "customer":
							this.ddlCustMana.Items.Add(new ListItem(oper.cnvcOperName,oper.cnvcOperID));
							this.ddlCustMana.Enabled=false;
							this.BindDropDownList(this.ddlCustTradeMana,ConstApp.A_OPER,"cnvcOperID='"+oper.cnvcManager+"'");
							this.ddlCustTradeMana.Enabled=false;
							break;
						case "trade":
							this.BindDropDownList(this.ddlCustMana,ConstApp.A_OPER,"cnvcManager='"+oper.cnvcOperID+"'");
							this.ddlCustMana.Items.Add(new ListItem("无","无"));
							this.ddlCustTradeMana.Items.Add(new ListItem(oper.cnvcOperName,oper.cnvcOperID));
							this.ddlCustTradeMana.Enabled=false;
							break;
						case "admin":
							this.BindDropDownList(this.ddlCustMana,ConstApp.A_OPER,"cnvcRoleCode='customer'");
							this.BindDropDownList(this.ddlCustTradeMana,ConstApp.A_OPER,"cnvcRoleCode='trade'");
							break;
						case "manager":
							this.BindDropDownList(this.ddlCustMana,ConstApp.A_OPER,"cnvcRoleCode='customer'");
							this.BindDropDownList(this.ddlCustTradeMana,ConstApp.A_OPER,"cnvcRoleCode='trade'");
							break;
						default:
							this.ddlCustMana.Items.Clear();
							this.ddlCustTradeMana.Items.Clear();
							break;							
					}
				}
				else
				{
					this.btnAddNewLink.Enabled=true;
					this.btnAdd.Enabled=false;
					if(strCustID==null||strCustID=="")
					{
						Popup("客户编号不正确！");
						Response.Write("<script>window.history.back();</script>");
						return;
					}
					else
					{
						DataTable dtout=Helper.Query("select * from tbCust where cnnCustID="+strCustID);
						if(dtout==null||dtout.Rows.Count==0)
						{
							Popup("客户不存在！");
							Response.Write("<script>window.history.back();</script>");
							return;
						}
						else
						{
							Cust newcust=new Cust(dtout.Rows[0]);
							this.txtCustID.Text=strCustID;
							this.txtCustName.Text=newcust.cnvcName;
							this.ddlCustType.SelectedIndex=ddlCustType.Items.IndexOf(ddlCustType.Items.FindByValue(newcust.cnvcType));
							this.txtPhone.Text=newcust.cnvcPhone;
							this.txtEmail.Text=newcust.cnvcEmail;
							this.txtFax.Text=newcust.cnvcFax;
							this.txtAddress.Text=newcust.cnvcAddress;
							this.txtPost.Text=newcust.cnvcPost;

							this.ddlTrade1.SelectedIndex=ddlTrade1.Items.IndexOf(ddlTrade1.Items.FindByValue(newcust.cnvcTradeType.Substring(0,2)));
							this.BindDropDownList(this.ddlTrade2,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=4 and cnvcCode like '"+this.ddlTrade1.SelectedValue+"%'");
							this.BindDropDownList(this.ddlTrade3,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=6 and cnvcCode like '"+this.ddlTrade2.SelectedValue+"%'");

							this.ddlTrade2.SelectedIndex=ddlTrade2.Items.IndexOf(ddlTrade2.Items.FindByValue(newcust.cnvcTradeType.Substring(0,4)));
							this.ddlTrade3.SelectedIndex=ddlTrade3.Items.IndexOf(ddlTrade3.Items.FindByValue(newcust.cnvcTradeType));
							this.ddlAreaCode.SelectedIndex=ddlAreaCode.Items.IndexOf(ddlAreaCode.Items.FindByValue(newcust.cnvcAreaCode));
							this.ddlCustLevel.SelectedIndex=ddlCustLevel.Items.IndexOf(ddlCustLevel.Items.FindByValue(newcust.cnvcLevel));
							this.ddlPayAbility.SelectedIndex=ddlPayAbility.Items.IndexOf(ddlPayAbility.Items.FindByValue(newcust.cnvcPayAbility));
							this.txtMonthCons.Text=newcust.cnnMonthFee.ToString();
							this.ddlConferState.SelectedIndex=ddlConferState.Items.IndexOf(ddlConferState.Items.FindByValue(newcust.cnvcContractType));
							this.txtDept.Text=newcust.cnvcRelativeDept;
							this.txtDept2.Text=newcust.cnvcRelativeDept2;
							this.txtDept3.Text=newcust.cnvcRelativeDept3;
							this.txtDept4.Text=newcust.cnvcRelativeDept4;
							this.txtDept5.Text=newcust.cnvcRelativeDept5;
							this.ddlDeptType.SelectedIndex=ddlDeptType.Items.IndexOf(ddlDeptType.Items.FindByValue(newcust.cnvcRelativeDeptType));
							this.ddlDeptType2.SelectedIndex=ddlDeptType2.Items.IndexOf(ddlDeptType2.Items.FindByValue(newcust.cnvcRelativeDeptType2));
							this.ddlDeptType3.SelectedIndex=ddlDeptType3.Items.IndexOf(ddlDeptType3.Items.FindByValue(newcust.cnvcRelativeDeptType3));
							this.ddlDeptType4.SelectedIndex=ddlDeptType4.Items.IndexOf(ddlDeptType4.Items.FindByValue(newcust.cnvcRelativeDeptType4));
							this.ddlDeptType5.SelectedIndex=ddlDeptType5.Items.IndexOf(ddlDeptType5.Items.FindByValue(newcust.cnvcRelativeDeptType5));
							this.txtCompanyInstruction.Text=newcust.cnvcIntro;
							this.txtInfoDoneState.Text=newcust.cnvcIT;
							this.txtCompetitorState.Text=newcust.cnvcCompetitor;
							this.txtInfoPlan.Text=newcust.cnvcITPlan;

							switch(oper.cnvcRoleCode)
							{
								case "customer":
									this.BindDropDownList(this.ddlCustMana,ConstApp.A_OPER,"cnvcOperID='"+newcust.cnvcCustMana+"'");
									this.BindDropDownList(this.ddlCustTradeMana,ConstApp.A_OPER,"cnvcOperID='"+newcust.cnvcCustTradeMana+"'");
									this.ddlCustMana.Enabled=false;
									this.ddlCustTradeMana.Enabled=false;
									break;
								case "trade":
									this.BindDropDownList(this.ddlCustMana,ConstApp.A_OPER,"cnvcRoleCode='customer' and cnvcManager='"+oper.cnvcOperID+"'");
									this.ddlCustMana.Items.Add(new ListItem("无","无"));
									this.ddlCustMana.SelectedIndex=ddlCustMana.Items.IndexOf(ddlCustMana.Items.FindByValue(newcust.cnvcCustMana));
									this.ddlCustMana.Enabled=true;
									this.BindDropDownList(this.ddlCustTradeMana,ConstApp.A_OPER,"cnvcOperID='"+newcust.cnvcCustTradeMana+"'");
									this.ddlCustTradeMana.Enabled=false;
									break;
								case "admin":
									//如果客户经理或行业经理发生变动，原来的将在此页面关联不到，必须由领导或管理员修改客户经理和行业经理为新的。
									this.BindDropDownList(this.ddlCustMana,ConstApp.A_OPER,"cnvcRoleCode='customer'");
									this.BindDropDownList(this.ddlCustTradeMana,ConstApp.A_OPER,"cnvcRoleCode='trade'");
									this.ddlCustMana.Items.Add(new ListItem("无","无"));
									this.ddlCustMana.SelectedIndex=ddlCustMana.Items.IndexOf(ddlCustMana.Items.FindByValue(newcust.cnvcCustMana));
									this.ddlCustTradeMana.SelectedIndex=ddlCustTradeMana.Items.IndexOf(ddlCustTradeMana.Items.FindByValue(newcust.cnvcCustTradeMana));
									break;
								case "manager":
									//如果客户经理或行业经理发生变动，原来的将在此页面关联不到，必须由领导或管理员修改客户经理和行业经理为新的。
									this.BindDropDownList(this.ddlCustMana,ConstApp.A_OPER,"cnvcRoleCode='customer'");
									this.BindDropDownList(this.ddlCustTradeMana,ConstApp.A_OPER,"cnvcRoleCode='trade'");
									this.ddlCustMana.Items.Add(new ListItem("无","无"));
									this.ddlCustMana.SelectedIndex=ddlCustMana.Items.IndexOf(ddlCustMana.Items.FindByValue(newcust.cnvcCustMana));
									this.ddlCustTradeMana.SelectedIndex=ddlCustTradeMana.Items.IndexOf(ddlCustTradeMana.Items.FindByValue(newcust.cnvcCustTradeMana));
									break;
								default:
									this.ddlCustMana.Items.Clear();
									this.ddlCustTradeMana.Items.Clear();
									break;							
							}
						}
					}
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
			this.ddlTrade1.SelectedIndexChanged += new System.EventHandler(this.ddlTrade1_SelectedIndexChanged);
			this.ddlTrade2.SelectedIndexChanged += new System.EventHandler(this.ddlTrade2_SelectedIndexChanged);
			this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnAddNewLink.Click += new System.EventHandler(this.btnAddNewLink_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("wfmVCustInfo.aspx");
		}

		private void ddlTrade1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.BindDropDownList(this.ddlTrade2,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=4 and cnvcCode like '"+this.ddlTrade1.SelectedValue+"%'");
			this.BindDropDownList(this.ddlTrade3,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=6 and cnvcCode like '"+this.ddlTrade2.SelectedValue+"%'");
		}

		private void ddlTrade2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.BindDropDownList(this.ddlTrade3,ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE' and len(cnvcCode)=6 and cnvcCode like '"+this.ddlTrade2.SelectedValue+"%'");
		}

		private void btnMod_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(this.JudgeIsNull(txtCustID.Text.Trim(),"客户编号")&&!this.JudgeIsNum(txtCustID.Text.Trim(),"客户编号"))
					return;
				if(this.JudgeIsNull(txtCustName.Text.Trim(),"客户名称"))
					return;
				DataTable dtout=Helper.Query("select * from tbCust where cnvcName='"+txtCustName.Text.Trim()+"' and cnnCustID<>"+txtCustID.Text.Trim());
				if(dtout.Rows.Count>0)
				{
					this.Popup("该客户名称已经存在，请检查！");
					return;
				}
				if(txtMonthCons.Text.Trim()!="")
				{
					if(!this.JudgeIsNum(txtMonthCons.Text.Trim(),"月通信使用费"))
						return;
				}

				Cust newcust=new Cust();
				newcust.cnnCustID=decimal.Parse(txtCustID.Text.Trim());
				newcust.cnvcName=txtCustName.Text.Trim();
				newcust.cnvcType=ddlCustType.SelectedValue;
				newcust.cnvcPhone=this.txtPhone.Text.Trim();
				newcust.cnvcEmail=this.txtEmail.Text.Trim();
				newcust.cnvcFax=this.txtFax.Text.Trim();
				newcust.cnvcAddress=this.txtAddress.Text.Trim();
				newcust.cnvcPost=this.txtPost.Text.Trim();
				newcust.cnvcTradeType=this.ddlTrade3.SelectedValue;
				newcust.cnvcAreaCode=this.ddlAreaCode.SelectedValue;
				newcust.cnvcLevel=this.ddlCustLevel.SelectedValue;
				newcust.cnvcPayAbility=this.ddlPayAbility.SelectedValue;
				if(this.txtMonthCons.Text.Trim()!="")
				{
					newcust.cnnMonthFee=decimal.Parse(this.txtMonthCons.Text.Trim());
				}
				newcust.cnvcContractType=this.ddlConferState.SelectedValue;
				if(this.txtDept.Text.Trim()!="")
				{
					newcust.cnvcRelativeDept=this.txtDept.Text.Trim();
					newcust.cnvcRelativeDeptType=this.ddlDeptType.SelectedValue;
				}
				if(this.txtDept2.Text.Trim()!="")
				{
					newcust.cnvcRelativeDept2=this.txtDept2.Text.Trim();
					newcust.cnvcRelativeDeptType2=this.ddlDeptType2.SelectedValue;
				}
				if(this.txtDept3.Text.Trim()!="")
				{
					newcust.cnvcRelativeDept3=this.txtDept3.Text.Trim();
					newcust.cnvcRelativeDeptType3=this.ddlDeptType3.SelectedValue;
				}
				if(this.txtDept4.Text.Trim()!="")
				{
					newcust.cnvcRelativeDept4=this.txtDept4.Text.Trim();
					newcust.cnvcRelativeDeptType4=this.ddlDeptType4.SelectedValue;
				}
				if(this.txtDept5.Text.Trim()!="")
				{
					newcust.cnvcRelativeDept5=this.txtDept5.Text.Trim();
					newcust.cnvcRelativeDeptType5=this.ddlDeptType5.SelectedValue;
				}
				newcust.cnvcIntro=this.txtCompanyInstruction.Text.Trim();
				newcust.cnvcIT=this.txtInfoDoneState.Text.Trim();
				newcust.cnvcCompetitor=this.txtCompetitorState.Text.Trim();
				newcust.cnvcITPlan=this.txtInfoPlan.Text.Trim();
				newcust.cnvcOperID=oper.cnvcOperID;
				newcust.cnvcCustMana=this.ddlCustMana.SelectedValue;
				newcust.cnvcCustTradeMana=this.ddlCustTradeMana.SelectedValue;
				VCustInfoFacade.UpdateVCust(newcust,oper);
				Popup("修改大客户资料成功");
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
				if(this.JudgeIsNull(txtCustID.Text.Trim(),"客户编号")&&!this.JudgeIsNum(txtCustID.Text.Trim(),"客户编号"))
					return;
				if(this.JudgeIsNull(txtCustName.Text.Trim(),"客户名称"))
					return;
				DataTable dtout=Helper.Query("select * from tbCust where cnvcName='"+txtCustName.Text.Trim()+"' and cnnCustID<>"+txtCustID.Text.Trim());
				if(dtout.Rows.Count>0)
				{
					this.Popup("该客户名称已经存在，请检查！");
					return;
				}
				if(txtMonthCons.Text.Trim()!="")
				{
					if(!this.JudgeIsNum(txtMonthCons.Text.Trim(),"月通信使用费"))
						return;
				}
				Cust newcust=new Cust();
				newcust.cnnCustID=decimal.Parse(txtCustID.Text.Trim());
				newcust.cnvcName=txtCustName.Text.Trim();
				newcust.cnvcType=ddlCustType.SelectedValue;
				newcust.cnvcPhone=this.txtPhone.Text.Trim();
				newcust.cnvcEmail=this.txtEmail.Text.Trim();
				newcust.cnvcFax=this.txtFax.Text.Trim();
				newcust.cnvcAddress=this.txtAddress.Text.Trim();
				newcust.cnvcPost=this.txtPost.Text.Trim();
				newcust.cnvcTradeType=this.ddlTrade3.SelectedValue;
				newcust.cnvcAreaCode=this.ddlAreaCode.SelectedValue;
				newcust.cnvcLevel=this.ddlCustLevel.SelectedValue;
				newcust.cnvcPayAbility=this.ddlPayAbility.SelectedValue;
				if(this.txtMonthCons.Text.Trim()!="")
				{
					newcust.cnnMonthFee=decimal.Parse(this.txtMonthCons.Text.Trim());
				}
				newcust.cnvcContractType=this.ddlConferState.SelectedValue;
				if(this.txtDept.Text.Trim()!="")
				{
					newcust.cnvcRelativeDept=this.txtDept.Text.Trim();
					newcust.cnvcRelativeDeptType=this.ddlDeptType.SelectedValue;
				}
				if(this.txtDept2.Text.Trim()!="")
				{
					newcust.cnvcRelativeDept2=this.txtDept2.Text.Trim();
					newcust.cnvcRelativeDeptType2=this.ddlDeptType2.SelectedValue;
				}
				if(this.txtDept3.Text.Trim()!="")
				{
					newcust.cnvcRelativeDept3=this.txtDept3.Text.Trim();
					newcust.cnvcRelativeDeptType3=this.ddlDeptType3.SelectedValue;
				}
				if(this.txtDept4.Text.Trim()!="")
				{
					newcust.cnvcRelativeDept4=this.txtDept4.Text.Trim();
					newcust.cnvcRelativeDeptType4=this.ddlDeptType4.SelectedValue;
				}
				if(this.txtDept5.Text.Trim()!="")
				{
					newcust.cnvcRelativeDept5=this.txtDept5.Text.Trim();
					newcust.cnvcRelativeDeptType5=this.ddlDeptType5.SelectedValue;
				}
				newcust.cnvcIntro=this.txtCompanyInstruction.Text.Trim();
				newcust.cnvcIT=this.txtInfoDoneState.Text.Trim();
				newcust.cnvcCompetitor=this.txtCompetitorState.Text.Trim();
				newcust.cnvcITPlan=this.txtInfoPlan.Text.Trim();
				newcust.cnvcOperID=oper.cnvcOperID;
				newcust.cnvcCustMana=this.ddlCustMana.SelectedValue;
				newcust.cnvcCustTradeMana=this.ddlCustTradeMana.SelectedValue;
				VCustInfoFacade.AddVCust(newcust,oper);
				Popup("新大客户资料添加成功");

				this.btnAddNewLink.Enabled=true;
				this.btnAdd.Enabled=false;

			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}

		private void btnAddNewLink_Click(object sender, System.EventArgs e)
		{
			string strcustid=this.txtCustID.Text.Trim();
			if(strcustid=="")
			{
				Popup("客户信息有误，无法添加联系人，请重试！");
				Response.Write("<script>window.history.back();</script>");
				return;
			}
			else
			{
				this.Response.Redirect("wfmVCustLinkDetail.aspx?type=add&&cid="+strcustid);
			}
		}
	}
}
