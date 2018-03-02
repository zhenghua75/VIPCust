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
using VCustApp.BusinessFacade;
using VCustApp.Common;
using VCustApp.Entity.EntityClass;
namespace VCustApp.SalesManage
{
	/// <summary>
	/// wfmModifyAdvancePayment ��ժҪ˵����
	/// </summary>
	public class wfmModifyAdvancePayment : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.TextBox txtCustID;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtProjectName;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtAcctName;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtMgr;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtPayDate;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtFeeName;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtFeeDate;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtPayFee;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtPrepayFee;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtComments;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtQueryCustID;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtQueryCustName;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			this.RegisterStartupScript("hide","<script lanaguage=javascript>ShowHide('1','none');</script>");
			if(!this.IsPostBack)
			{
				if(Request["cnnCustID"] == null)
				{
					Popup("��Ч����");
					return;
				}
				string strCustID = Request["cnnCustID"].ToString();
				string strSql = "select * from tbAdvancePayment where cnnCustID = '"+strCustID+"'";
				DataTable dt = Helper.Query(strSql);
				if(dt.Rows.Count == 0 || dt.Rows.Count > 1)
				{
					Popup("δ�ҵ��ͻ�����ͻ����ڳ�ͻ");
					return;
				}
				AdvancePayment ap = new AdvancePayment(dt);
				txtFeeDate.Text       =     ap.cndFeeDate.ToString("yyyy-MM-dd")     ;
				txtPayDate.Text       =     ap.cndPayDate.ToString("yyyy-MM-dd")     ;
				txtCustID.Text     =     ap.cnnCustID.ToString()      ;
				txtPayFee.Text      =     ap.cnnPayFee.ToString()      ;
				txtPrepayFee.Text   =     ap.cnnPrepayFee.ToString()   ;
				txtAcctName.Text                      =     ap.cnvcAcctName   ;
				txtComments.Text                       =     ap.cnvcComments   ;
				txtCustName.Text                       =     ap.cnvcCustName   ;
				txtFeeName.Text                        =     ap.cnvcFeeName    ;
				txtMgr.Text                            =     ap.cnvcMgr        ;
				txtProjectName.Text                    =     ap.cnvcProjectName;

				this.txtCustID.Enabled = false;
				this.txtCustName.Enabled = false;
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
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			string strSql = "select top 10 * from tbCust where 1=1 ";
			if(txtQueryCustID.Text != "")
				strSql += " and cnnCustID="+txtQueryCustID.Text;
			if(txtQueryCustName.Text != "")
				strSql += " and cnvcName like '"+txtQueryCustName.Text+"'";
			DataTable dt = Helper.Query(strSql);
			this.DataTableConvert(dt,"cnvcTradeType",ConstApp.A_NAMECODE,"cnvcType='TRADE_TYPE'");
			this.DataGrid1.DataSource = dt;
			this.DataGrid1.DataBind();
		}

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DataGridItem item = this.DataGrid1.SelectedItem;
			this.txtCustID.Text = item.Cells[0].Text;
			this.txtCustName.Text = item.Cells[1].Text;
		}


		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				string strSql = "select * from tbAdvancePayment where cnnCustID = "+txtCustID.Text;
				DataTable dt = Helper.Query(strSql);
				if(dt.Rows.Count == 0 || dt.Rows.Count > 1)
				{
					Popup("δ�ҵ��ͻ�����ͻ����ڳ�ͻ");
					return;
				}
				AdvancePayment ap = new AdvancePayment(dt);

				//AdvancePayment ap = new AdvancePayment();
				ap.cndFeeDate = DateTime.Parse(txtFeeDate.Text);
				ap.cndPayDate = DateTime.Parse(txtPayDate.Text);
				ap.cnnCustID = Convert.ToDecimal(txtCustID.Text);
				ap.cnnPayFee = Convert.ToDecimal(txtPayFee.Text);
				ap.cnnPrepayFee = Convert.ToDecimal(txtPrepayFee.Text);
				ap.cnvcAcctName = txtAcctName.Text;
				ap.cnvcComments = txtComments.Text;
				ap.cnvcCustName = txtCustName.Text;
				ap.cnvcFeeName = txtFeeName.Text;
				ap.cnvcMgr = txtMgr.Text;
				ap.cnvcProjectName = txtProjectName.Text;

				SalesManageFacade.UpdateAdvancePayment(ap,oper);
				Popup("Ԥ���˿��޸ĳɹ�");
				
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			try
			{
				string strSql = "select * from tbAdvancePayment where cnnCustID = '"+txtCustID.Text+"'";
				DataTable dt = Helper.Query(strSql);
				if(dt.Rows.Count == 0 || dt.Rows.Count > 1)
				{
					Popup("δ�ҵ��ͻ�����ͻ����ڳ�ͻ");
					return;
				}
				AdvancePayment ap = new AdvancePayment(dt);
				txtFeeDate.Text       =     ap.cndFeeDate.ToString("yyyy-MM-dd")     ;
				txtPayDate.Text       =     ap.cndPayDate.ToString("yyyy-MM-dd")     ;
				txtCustID.Text     =     ap.cnnCustID.ToString()      ;
				txtPayFee.Text      =     ap.cnnPayFee.ToString()      ;
				txtPrepayFee.Text   =     ap.cnnPrepayFee.ToString()   ;
				txtAcctName.Text                      =     ap.cnvcAcctName   ;
				txtComments.Text                       =     ap.cnvcComments   ;
				txtCustName.Text                       =     ap.cnvcCustName   ;
				txtFeeName.Text                        =     ap.cnvcFeeName    ;
				txtMgr.Text                            =     ap.cnvcMgr        ;
				txtProjectName.Text                    =     ap.cnvcProjectName;
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("wfmAdvancePayment.aspx");
		}
	}
}
