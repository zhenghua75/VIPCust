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
	/// wfmVCustLink ��ժҪ˵����
	/// </summary>
	public class wfmVCustLink :wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtCustID;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblCustID;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblCustName;
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
//				if(Request.QueryString.HasKeys())
//				{
//					string strCustID=Request.QueryString["cid"];
//					if(strCustID!=""||strCustID.Trim().Length>0)
//					{
//						DataTable dtout=Helper.Query("select a.*,b.cnvcName as cnvcCustName from tbLink a,tbCust b where a.cnnCustID=b.cnnCustID and a.cnnCustID="+strCustID);
//						if(dtout.Rows.Count==0)
//						{
//							DataTable dtCust=Helper.Query("select cnnCustID,cnvcName as cnvcCustName from tbCust where cnnCustID="+strCustID);
//							if(dtCust.Rows.Count==0)
//							{
//								this.Popup("�ͻ������ڣ�");
//								return;
//							}
//							else
//							{
//								this.lblCustID.Text=dtCust.Rows[0]["cnnCustID"].ToString();
//								this.lblCustName.Text=dtCust.Rows[0]["cnvcCustName"].ToString();
//							}
//						}
//						else
//						{
//							this.DataTableConvert(dtout,"cnvcSex",ConstApp.A_NAMECODE,"cnvcType='SEX_TYPE'");
//							this.DataTableConvert(dtout,"cnvcEducation",ConstApp.A_NAMECODE,"cnvcType='EDUCATION_TYPE'");
//							this.DataTableConvert(dtout,"cnvcLinkType",ConstApp.A_NAMECODE,"cnvcType='LINK_TYPE'");
//							this.DataTableConvert(dtout,"cnvcRelativeDeptType",ConstApp.A_NAMECODE,"cnvcType='RELATIVEDEPT_TYPE'");
//							this.lblCustID.Text=dtout.Rows[0]["cnnCustID"].ToString();
//							this.lblCustName.Text=dtout.Rows[0]["cnvcCustName"].ToString();
//						}
//						this.DataGrid1.DataSource=dtout;
//						this.DataGrid1.DataBind();
//					}
//				}
//				else
//				{
//					this.lblCustID.Text="";
//					this.lblCustName.Text="";
//				}
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
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.DataGrid1.PageIndexChanged+=new DataGridPageChangedEventHandler(DataGrid1_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			this.BindGrid();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			if(this.lblCustID.Text.Trim()==""||this.lblCustName.Text.Trim()=="")
			{
				this.Popup("�޵�ǰ�ͻ���Ϣ�������²�ѯ��");
				return;
			}
			else
			{
				this.Response.Redirect("wfmVCustLinkDetail.aspx?type=add&&cid="+this.lblCustID.Text.Trim());
			}
		}

		private void BindGrid()
		{
			string strCustID=this.txtCustID.Text.Trim();
			string strCustName=this.txtCustName.Text.Trim();
			if(strCustID==""&&strCustName=="")
			{
				this.Popup("������Ҫά����ϵ�˵Ŀͻ���Ϣ��");
				return;
			}
			else
			{
				string strCondition="";
				if(strCustID!="")
				{
					strCondition=" and a.cnnCustID="+strCustID;
				}
				if(strCustName!="")
				{
					strCondition+=" and b.cnvcName like '%"+strCustName+"%'";
				}
				switch(oper.cnvcRoleCode)
				{
					case "customer":
						strCondition+=" and b.cnvcCustMana='"+oper.cnvcOperID+"'";
						break;
					case "trade":
						strCondition+=" and b.cnvcCustTradeMana='"+oper.cnvcOperID+"'";
						break;
					case "admin":
						break;
					case "manager":
						break;
					default:
						strCondition+=" and 1=2";
						break;
				}
				DataTable dtout=Helper.Query("select a.*,b.cnvcName as cnvcCustName from tbLink a,tbCust b where a.cnnCustID=b.cnnCustID"+strCondition);
				if(dtout.Rows.Count==0)
				{
					strCondition="";
					string strsql="select cnnCustID,cnvcName as cnvcCustName from tbCust where ";
					if(strCustID!="")
					{
						strCondition+=" cnnCustID="+strCustID;
					}
					if(strCustName!="")
					{
						if(strCondition=="")
						{
							strCondition+=" cnvcName like '%"+strCustName+"%'";
						}
						else
						{
							strCondition+=" and cnvcName like '%"+strCustName+"%'";
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
					DataTable dtCust=Helper.Query(strsql+strCondition);
					if(dtCust.Rows.Count==0)
					{
						this.Popup("�ͻ������ڻ�����Ȩ�����ÿͻ���");
						return;
					}
					else
					{
						this.lblCustID.Text=dtCust.Rows[0]["cnnCustID"].ToString();
						this.lblCustName.Text=dtCust.Rows[0]["cnvcCustName"].ToString();
					}
				}
				else
				{
					this.DataTableConvert(dtout,"cnvcSex",ConstApp.A_NAMECODE,"cnvcType='SEX_TYPE'");
					this.DataTableConvert(dtout,"cnvcEducation",ConstApp.A_NAMECODE,"cnvcType='EDUCATION_TYPE'");
					this.DataTableConvert(dtout,"cnvcLinkType",ConstApp.A_NAMECODE,"cnvcType='LINK_TYPE'");
					this.DataTableConvert(dtout,"cnvcRelativeDeptType",ConstApp.A_NAMECODE,"cnvcType='RELATIVEDEPT_TYPE'");
					this.lblCustID.Text=dtout.Rows[0]["cnnCustID"].ToString();
					this.lblCustName.Text=dtout.Rows[0]["cnvcCustName"].ToString();
				}
				this.DataGrid1.DataSource=dtout;
				this.DataGrid1.DataBind();
			}
		}

		private void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.DataGrid1.CurrentPageIndex=e.NewPageIndex;
			this.BindGrid();
		}
	}
}
