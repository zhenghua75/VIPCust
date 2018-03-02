using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using VCustApp.Common;
using VCustApp.Entity.EntityClass;
using VCustApp.BusinessFacade;

namespace VCustApp
{
	/// <summary>
	/// wfmFileUp ��ժҪ˵����
	/// </summary>
	public class wfmFileUp : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnReadFile;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button btnWriteFile;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileUpLoad;
		protected System.Web.UI.WebControls.Label lblFileName;
		protected System.Web.UI.WebControls.TextBox txtXlsType;
		protected System.Web.UI.WebControls.TextBox txtSheet;
		protected System.Web.UI.WebControls.Label lblFileUp;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.TextBox txtError;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!this.IsPostBack)
			{
				if(Request["XlsType"] == null)
				{
					Popup("��Ч����");
					return;
				}
				this.txtXlsType.Text = Request["XlsType"].ToString();
				switch(this.txtXlsType.Text)
				{
					case "Chance":
						txtSheet.Text = "�̻�����ͳ�Ʊ�$";
						lblFileUp.Text = "�̻�����ͳ�Ʊ��ļ�����";
						break;
					case "AdvancePayment":
						txtSheet.Text = "Ԥ���˿����$";
						lblFileUp.Text = "Ԥ���˿�����ļ�����";
						break;
					case "AccountReceivable":
						txtSheet.Text = "Ӧ�չ���$";
						lblFileUp.Text = "Ӧ�չ����ļ�����";
						break;
					case "CustInfo":
						txtSheet.Text = "�ͻ�������Ϣ$";
						lblFileUp.Text = "�ͻ�������Ϣ�ļ�����";
						break;
					case "SaleCost":
						txtSheet.Text = "���۳ɱ�����$";
						lblFileUp.Text = "���۳ɱ������ļ�����";
						break;
				}
				this.txtError.Text = "0";

				
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
			this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
			this.btnWriteFile.Click += new System.EventHandler(this.btnWriteFile_Click);
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.DataGrid1.ItemDataBound+=new DataGridItemEventHandler(DataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnReadFile_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(txtSheet.Text == "")
					throw new Exception("�޷�ʶ����ļ�");
				DataSet ds = ReadFile(txtSheet.Text);
				//У������
				CheckFile(ds);
				Session["UpLoadFile"] = ds.Tables[0];
				this.DataGrid1.DataSource = ds;
				this.DataGrid1.DataBind();
				this.lblFileName.Text += "<br>��������������"+txtError.Text;
				if(Convert.ToInt32(txtError.Text)>0)
					this.lblFileName.Text += "<br>��鿴\"У�����\"��";
			}
			catch(Exception ex)
			{
				txtError.Text = "1";
				Popup(ex.Message);
			}
		}

		private DataSet ReadFile(string strSheet)
		{
				
			string str = fileUpLoad.PostedFile.FileName;
			int i = str.LastIndexOf("\\");
			string filename=str.Substring(i+1);
			string strFileName = oper.cnvcOperName+"_"+DateTime.Now.ToString("yyyyMMdd")+"_"+System.Guid.NewGuid().ToString();
			string strFileUpPath = System.Configuration.ConfigurationSettings.AppSettings["FileUppath"];
			fileUpLoad.PostedFile.SaveAs(@strFileUpPath + strFileName);

			lblFileName.Text = "�ļ���Ϊ��" + filename;
			string strConn = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source =" + @strFileUpPath + strFileName + ";Extended Properties=Excel 8.0";
			OleDbConnection conn = new OleDbConnection(strConn);
			conn.Open();
			string Sql = "select * from ["+strSheet+"]";
			OleDbDataAdapter cmd = new OleDbDataAdapter(Sql, conn);
			DataSet ds = new DataSet();
			cmd.Fill(ds);
			conn.Close();
			System.IO.File.Delete(@strFileUpPath + strFileName);
			return ds;
		}

		private DataSet CheckFile(DataSet ds)
		{
			DataSet dsOut = null;
			switch(this.txtXlsType.Text)
			{
				case "Chance":
					dsOut = CheckChance(ds);
					break;
				case "AdvancePayment":
					dsOut = CheckAdvancePayment(ds);
					break;
				case "AccountReceivable":
					dsOut = CheckAccountReceivable(ds);
					break;
				case "CustInfo":
					dsOut = CheckCustInfo(ds);
					break;
				case "SaleCost":
					dsOut = CheckSaleCost(ds);
					break;
			}
			return dsOut;
		}
		private DataSet CheckChance(DataSet ds)
		{
			int iError = 0;
			DataTable dtDept = Application[ConstApp.A_DEPT] as DataTable;
			Hashtable htDept = new Hashtable();
			foreach(DataRow dr in dtDept.Rows)
			{
				Dept tDept = new Dept(dr);
				htDept.Add(tDept.cnvcDeptName,tDept.cnvcDeptID);
			}
			
			DataTable dtCust = Helper.Query("select cnnCustID,cnvcName from tbCust");
			Hashtable htCust = new Hashtable();
			foreach(DataRow dr in dtCust.Rows)
			{
				Cust tCust = new Cust(dr);
				htCust.Add(tCust.cnvcName,tCust.cnnCustID);
			}
			DataTable dtOper = Application[ConstApp.A_OPER] as DataTable;
			DataRow[] drMgr = dtOper.Select("cnvcRoleCode='customer'");
			Hashtable htMgr = new Hashtable();
			foreach(DataRow dr in drMgr)
			{
				Oper tOper = new Oper(dr);
				htMgr.Add(tOper.cnvcOperName,tOper.cnvcOperID);
			}
			DataRow[] drTradeMgr = dtOper.Select("cnvcRoleCode='trade'");
			Hashtable htTradeMgr = new Hashtable();
			foreach(DataRow dr in drTradeMgr)
			{
				Oper tOper = new Oper(dr);
				htTradeMgr.Add(tOper.cnvcOperName,tOper.cnvcOperID);
			}
			DataTable dtNameCode = Application[ConstApp.A_NAMECODE] as DataTable;

			DataRow[] drChanceType = dtNameCode.Select("cnvcType in ('QUESTION','VALUE')");
			Hashtable htChanceType = new Hashtable();
			foreach(DataRow dr in drChanceType)
			{
				NameCode tNameCode = new NameCode(dr);
				htChanceType.Add(tNameCode.cnvcName,tNameCode.cnvcCode);
			}

			DataRow[] drChanceSpeed = dtNameCode.Select("cnvcType = 'CHANCE_SPEED'");
			Hashtable htChanceSpeed = new Hashtable();
			foreach(DataRow dr in drChanceSpeed)
			{
				NameCode tNameCode = new NameCode(dr);
				htChanceSpeed.Add(tNameCode.cnvcName,tNameCode.cnvcCode);
			}

			DataRow[] drYesNo = dtNameCode.Select("cnvcType = 'YES_NO'");
			Hashtable htYesNo = new Hashtable();
			foreach(DataRow dr in drYesNo)
			{
				NameCode tNameCode = new NameCode(dr);
				htYesNo.Add(tNameCode.cnvcName,tNameCode.cnvcCode);
			}
			
			DataTable dt = ds.Tables[0];
			dt.Columns.Add("У�����");
			dt.Columns.Add("cnvcDeptID");
			dt.Columns.Add("cndChanceDate");
			dt.Columns.Add("cnnCustID");
			dt.Columns.Add("cnvcChanceName");
			dt.Columns.Add("cnvcMgr");
			dt.Columns.Add("cnvcTradeMgr");
			dt.Columns.Add("cnvcChanceType");
			dt.Columns.Add("cnnForecastIncome");
			dt.Columns.Add("cnvcChanceSpeed");
			dt.Columns.Add("cnvcIsSucess");
			dt.Columns.Add("cnnSucessIncome");
			dt.Columns.Add("cndSucessDate");
			dt.Columns.Add("cnvcProjectName");
			Hashtable htChanceName = new Hashtable();
			foreach(DataRow dr in dt.Rows)
			{
				string strDept = dr["�ֹ�˾"].ToString();
				if(!htDept.ContainsKey(strDept))		
				{
					dr["У�����"] += strDept+"���޴˷ݹ�˾";				
					iError += 1;
				}
				else
					dr["cnvcDeptID"] = htDept[strDept].ToString();

				string strChanceDate = dr["�̻�ʱ��"].ToString();
				if(!this.JudgeIsDate(strChanceDate))
				{
					dr["У�����"] += strChanceDate+"�����ڸ�ʽ����";
					iError += 1;
				}
				else

					dr["cndChanceDate"] = DateTime.Parse(strChanceDate).ToString("yyyy-MM-dd");

				string strCust = dr["�ͻ�����"].ToString();
				if(!htCust.ContainsKey(strCust))
				{
					dr["У�����"] += strCust+"�����ȵ���˿ͻ���Ϣ";
					iError += 1;
				}
				else
					dr["cnnCustID"] = htCust[strCust].ToString();
				
				string strChanceName = dr["��Ŀ���ƣ��̻���"].ToString().Trim();
				if(strChanceName == "")
				{
					dr["У�����"] += "���̻����Ʋ���Ϊ��";
					iError += 1;
				}
				else
					dr["cnvcChanceName"] = strChanceName;

				if(htChanceName.ContainsKey(strChanceName))
				{
					dr["У�����"] += strChanceName+"���̻������Ѵ���";
					iError += 1;
				}
				else
				{
					htChanceName.Add(strChanceName,strChanceName);
				}

				//string strOper = dr["�ͻ�����/��ҵ����"].ToString();
				//string[] strOpers = strOper.Split('/');
				string strMgr = dr["�ͻ�����"].ToString();//strOpers[0];
				string strTradeMgr = dr["��ҵ����"].ToString();//strOpers[1];

				if(strMgr != "")
				{
					if(!htMgr.ContainsKey(strMgr))
					{
						dr["У�����"] += strMgr+"���޴˿ͻ�����";
						iError += 1;
					}
					else
						dr["cnvcMgr"] = htMgr[strMgr].ToString();
				}
				

				if(!htTradeMgr.ContainsKey(strTradeMgr))
				{
					dr["У�����"] += strTradeMgr+"���޴���ҵ����";
					iError += 1;
				}
				else
					dr["cnvcTradeMgr"] = htTradeMgr[strTradeMgr].ToString();

				string strChanceType = dr["�̻�����"].ToString();
				if(!htChanceType.ContainsKey(strChanceType))
				{
					dr["У�����"] += strChanceType+"���޴��̻�����";
					iError += 1;
				}
				else
					dr["cnvcChanceType"] = htChanceType[strChanceType].ToString();

				string strForecastIncome = dr["�̻�Ԥ�����루��Ԫ��"].ToString();
				if(!this.JudgeIsNum(strForecastIncome))
				{
					dr["У�����"] += strForecastIncome+"����������";
					iError += 1;
				}
				else
					dr["cnnForecastIncome"] = strForecastIncome;

				string strChanceSpeed = dr["�̻���չ"].ToString();
				if(!htChanceSpeed.ContainsKey(strChanceSpeed))
				{
					dr["У�����"] += strChanceSpeed+"���޴��̻���չ";
					iError += 1;
				}
				else
					dr["cnvcChanceSpeed"] = htChanceSpeed[strChanceSpeed].ToString();

				string strIsSucess = dr["�Ƿ�ɹ�ת��"].ToString();
				if(!htYesNo.ContainsKey(strIsSucess))
				{
					dr["У�����"] += strIsSucess +"��ֻ���Ǻͷ�";
					iError += 1;
				}
				else
					dr["cnvcIsSucess"] = htYesNo[strIsSucess].ToString();

				string strSucessDate = dr["�ɹ�ת��ʱ��"].ToString();
				string strSucessIncome = dr["�ɹ�ת���̻����루��Ԫ/�꣩"].ToString();
				string strProjectName = dr["�������Ŀ����"].ToString();
				if(strIsSucess == "��")
				{
					if(!this.JudgeIsDate(strSucessDate))
					{
						dr["У�����"] += strSucessDate +"�����ڸ�ʽ����";
						iError += 1;
					}
					else
						dr["cndSucessDate"] = DateTime.Parse(strSucessDate).ToString("yyyy-MM-dd");

					if(!this.JudgeIsNum(strSucessIncome))
					{
						dr["У�����"] += strSucessIncome+"����������";
						iError += 1;
					}
					else
						dr["cnnSucessIncome"] = strSucessIncome;
					
					if(strProjectName == "")
					{
						dr["У�����"] += "�������Ŀ���Ʋ���Ϊ��";
						iError += 1;
					}
					else
						dr["cnvcProjectName"] = strProjectName;

				}
				
			}
			this.txtError.Text= iError.ToString();
			return ds;
		}
		private DataSet CheckAdvancePayment(DataSet ds)
		{
			DataTable dtCust = Helper.Query("select cnnCustID,cnvcName from tbCust");
			Hashtable htCust = new Hashtable();
			foreach(DataRow dr in dtCust.Rows)
			{
				Cust tCust = new Cust(dr);
				htCust.Add(tCust.cnvcName,tCust.cnnCustID);
			}

			int iError = 0;
			DataTable dt = ds.Tables[0];
			dt.Columns.Add("У�����");
			dt.Columns.Add("cnnCustID");
			dt.Columns.Add("cnvcCustName");
			dt.Columns.Add("cnvcProjectName");
			dt.Columns.Add("cnvcAcctName");
			dt.Columns.Add("cnvcMgr");
			dt.Columns.Add("cndPayDate");
			dt.Columns.Add("cnvcFeeName");
			dt.Columns.Add("cndFeeDate");
			dt.Columns.Add("cnnPayFee");
			dt.Columns.Add("cnnPrepayFee");
			dt.Columns.Add("cnvcComments");
			foreach(DataRow dr in dt.Rows)
			{
				
				string strCust = dr["�ͻ�����"].ToString();
				if(!htCust.ContainsKey(strCust))
				{
					dr["У�����"] += strCust+"�����ȵ���˿ͻ���Ϣ";
					iError += 1;
				}
				else
				{
					dr["cnnCustID"] = htCust[strCust].ToString();
					dr["cnvcCustName"] = dr["�ͻ�����"];
				}
				dr["cnvcProjectName"] = dr["��Ŀ����"];
				dr["cnvcAcctName"] = dr["�ʻ�����"];
				dr["cnvcMgr"] = dr["�ͻ�����"];

				string strPayDate = dr["����ʱ��"].ToString();
				if(!this.JudgeIsDate(strPayDate))
				{
					dr["У�����"] += strPayDate+"�����ڸ�ʽ����";
					iError += 1;
				}
				else
					dr["cndPayDate"] = DateTime.Parse(dr["����ʱ��"].ToString()).ToString("yyyy-MM-dd");
				dr["cnvcFeeName"] = dr["��������"];

				string strFeeDate = dr["���ü���ʱ��"].ToString();
				if(!this.JudgeIsDate(strFeeDate))
				{
					dr["У�����"] += strFeeDate+"�����ڸ�ʽ����";
					iError += 1;
				}
				else
					dr["cndFeeDate"] = DateTime.Parse(dr["���ü���ʱ��"].ToString()).ToString("yyyy-MM-dd");
				string strPayFee = dr["������"].ToString();
				if(!this.JudgeIsNum(strPayFee))
				{
					dr["У�����"] += strPayFee +"����������";
					iError += 1;
					
				}
				else
					dr["cnnPayFee"] = strPayFee;
				string strPrepayFee = dr["��Ԥ�����"].ToString();
				if(!this.JudgeIsNum(strPrepayFee))
				{
					dr["У�����"] = strPrepayFee + "����������";
					iError += 1;
				}
				else
					dr["cnnPrepayFee"] = strPrepayFee;
				dr["cnvcComments"] = dr["��ע"];
			}
			this.txtError.Text = iError.ToString();
			return ds;
		}
		private DataSet CheckAccountReceivable(DataSet ds)
		{
			DataTable dtCust = Helper.Query("select cnnCustID,cnvcName from tbCust");
			Hashtable htCust = new Hashtable();
			foreach(DataRow dr in dtCust.Rows)
			{
				Cust tCust = new Cust(dr);
				htCust.Add(tCust.cnnCustID.ToString(),tCust.cnvcName);
			}

			int iError = 0;
			DataTable dt = ds.Tables[0];
			dt.Columns.Add("У�����");
			dt.Columns.Add("cnnCustID");
			dt.Columns.Add("cnvcCustName");
			dt.Columns.Add("cnvcTradeType1");
			dt.Columns.Add("cnvcTradeType2");
			dt.Columns.Add("cnvcCustLevel");
			dt.Columns.Add("cnvcContractNo");
			dt.Columns.Add("cnvcProjectName");
			dt.Columns.Add("cnnAcctID");
			dt.Columns.Add("cnvcAcctName");
			dt.Columns.Add("cnvcSvcTypeName");
			dt.Columns.Add("cnnFee");
			foreach(DataRow dr in dt.Rows)
			{
				//dr["cnnCustID"] = dr["�ͻ�ID"];
				//dr["cnvcCustName"] = dr["�ͻ�����"];
				string strCust = dr["�ͻ�ID"].ToString().Trim();
				if(!htCust.ContainsKey(strCust))
				{
					dr["У�����"] += strCust+"�����ȵ���˿ͻ���Ϣ";
					iError += 1;
				}
				else
				{
					string strCustName = dr["�ͻ�����"].ToString().Trim();
					if(strCustName != htCust[strCust].ToString())
					{
						dr["У�����"] += strCustName+"���ͻ����Ʋ���";
						iError += 1;
					}
					else
					{
						dr["cnnCustID"] = dr["�ͻ�ID"];
						dr["cnvcCustName"] = dr["�ͻ�����"];
					}
				}
				dr["cnvcTradeType1"] = dr["һ����ҵ����"];
				dr["cnvcTradeType2"] = dr["������ҵ����"];
				dr["cnvcCustLevel"] = dr["�ͻ��ȼ�"];
				dr["cnvcContractNo"] = dr["��ͬ���"];
				dr["cnvcProjectName"] = dr["��Ŀ����"];
				dr["cnnAcctID"] = dr["�ͻ�����"];
				dr["cnvcAcctName"] = dr["�ʻ�����"];
				dr["cnvcSvcTypeName"] = dr["ҵ������"];
				string strFee = dr["���루��Ԫ��"].ToString();
				if(!this.JudgeIsNum(strFee))
				{
					dr["У�����"] += strFee+"����������";
					iError += 1;
				}
				else
					dr["cnnFee"] = strFee;
			}
			this.txtError.Text = iError.ToString();
			return ds;
		}

		private DataSet CheckCustInfo(DataSet ds)
		{
			DataTable dtCust = Helper.Query("select cnnCustID,cnvcName from tbCust");
			Hashtable htCustID = new Hashtable();
			Hashtable htCustName = new Hashtable();
			foreach(DataRow dr1 in dtCust.Rows)
			{
				Cust tCust = new Cust(dr1);
				htCustID.Add(tCust.cnnCustID.ToString(),tCust.cnvcName);
			}
			foreach(DataRow dr2 in dtCust.Rows)
			{
				Cust tCust = new Cust(dr2);
				htCustName.Add(tCust.cnvcName,tCust.cnnCustID.ToString());
			}

			DataTable dtNameCode = Helper.Query("select distinct cnvcType+cnvcName as cnvcName,cnvcCode from tbNameCode where cnvcType<>'TRADE_TYPE' or (cnvcType='TRADE_TYPE' and len(cnvcCode)=6)");
			Hashtable htNameCode = new Hashtable();
			foreach(DataRow dr3 in dtNameCode.Rows)
			{
				htNameCode.Add(dr3["cnvcName"].ToString(),dr3["cnvcCode"].ToString());
			}

			DataTable dtAreaCode = Helper.Query("select cnvcAreaCode,cnvcComments from tbAreaCode");
			Hashtable htAreeCode = new Hashtable();
			foreach(DataRow dr4 in dtAreaCode.Rows)
			{
				htAreeCode.Add(dr4["cnvcComments"].ToString(),dr4["cnvcAreaCode"].ToString());
			}

			DataTable dtManaRelation = Helper.Query("select distinct a.cnvcOperName as cnvcMana,b.cnvcOperName as cnvcTradeMana from tbOper a,tbOper b where a.cnvcManager=b.cnvcOperID");
			Hashtable htManaRelation = new Hashtable();
			foreach(DataRow dr5 in dtManaRelation.Rows)
			{
				htManaRelation.Add(dr5["cnvcMana"].ToString(),dr5["cnvcTradeMana"].ToString());
			}

			DataTable dtTradeMana = Helper.Query("select distinct cnvcOperID,cnvcOperName from tbOper where cnvcRoleCode='trade'");
			Hashtable htTradeMana = new Hashtable();
			foreach(DataRow dr6 in dtTradeMana.Rows)
			{
				htTradeMana.Add(dr6["cnvcOperName"].ToString(),dr6["cnvcOperID"].ToString());
			}

			DataTable dtCustMana = Helper.Query("select distinct cnvcOperID,cnvcOperName from tbOper where cnvcRoleCode='customer'");
			Hashtable htCustMana = new Hashtable();
			foreach(DataRow dr7 in dtCustMana.Rows)
			{
				htCustMana.Add(dr7["cnvcOperName"].ToString(),dr7["cnvcOperID"].ToString());
			}

			int iError = 0;
			DataTable dt = ds.Tables[0];
			dt.Columns.Add("У�����");
			dt.Columns.Add("cnnCustID");
			dt.Columns.Add("cnvcName");
			dt.Columns.Add("cnvcPhone");
			dt.Columns.Add("cnvcEmail");
			dt.Columns.Add("cnvcFax");
			dt.Columns.Add("cnvcTradeType");
			dt.Columns.Add("cnvcAreaCode");
			dt.Columns.Add("cnvcLevel");
			dt.Columns.Add("cnvcIntro");
			dt.Columns.Add("cnvcAddress");
			dt.Columns.Add("cnvcPost");
			dt.Columns.Add("cndCreateDate");
			dt.Columns.Add("cnvcIT");
			dt.Columns.Add("cnvcCompetitor");
			dt.Columns.Add("cnnMonthFee");
			dt.Columns.Add("cnvcITPlan");
			dt.Columns.Add("cnvcPayAbility");
			dt.Columns.Add("cnvcContractType");
			dt.Columns.Add("cnvcRelativeDept");
			dt.Columns.Add("cnvcRelativeDeptType");
			dt.Columns.Add("cnvcRelativeDept2");
			dt.Columns.Add("cnvcRelativeDeptType2");
			dt.Columns.Add("cnvcRelativeDept3");
			dt.Columns.Add("cnvcRelativeDeptType3");
			dt.Columns.Add("cnvcRelativeDept4");
			dt.Columns.Add("cnvcRelativeDeptType4");
			dt.Columns.Add("cnvcRelativeDept5");
			dt.Columns.Add("cnvcRelativeDeptType5");
			dt.Columns.Add("cnvcCustMana");
			dt.Columns.Add("cnvcCustTradeMana");		
			foreach(DataRow dr in dt.Rows)
			{
				string strCustID = dr["�ͻ�ID"].ToString();
				string strCustName = dr["�ͻ�����"].ToString();
				if(strCustID.Trim()=="")
				{
					dr["У�����"] += strCustID+"���ͻ�IDΪ�գ�";
					iError += 1;
					continue;
				}
				if(htCustID.ContainsKey(strCustID))
				{
					dr["У�����"] += strCustID+"���˿ͻ�ID�Ѿ����ڣ�";
					iError += 1;
				}
				else if(htCustName.ContainsKey(strCustName))
				{
					dr["У�����"] += strCustName+"���˿ͻ������Ѿ����ڣ�";
					iError += 1;
				}
				else
				{
					dr["cnnCustID"] = dr["�ͻ�ID"];
					dr["cnvcName"] = dr["�ͻ�����"];
				}
				dr["cnvcPhone"]= dr["�ͻ��绰"];
				dr["cnvcEmail"]= dr["�ͻ�E����"];
				dr["cnvcFax"]= dr["�ͻ�����"];
				
				string strTradeType=dr["������ҵ����"].ToString();
				if(!htNameCode.ContainsKey("TRADE_TYPE"+strTradeType))
				{
					dr["У�����"] += strTradeType+"��������ҵ���Բ���ȷ��";
					iError += 1;
				}
				else
				{
					dr["cnvcTradeType"]= htNameCode["TRADE_TYPE"+strTradeType].ToString();
				}

				string strAreaCode=dr["��˾����"].ToString();
				if(!htAreeCode.ContainsKey(strAreaCode))
				{
					dr["У�����"] += strAreaCode+"����˾���Ʋ���ȷ��";
					iError += 1;
				}
				else
				{
					dr["cnvcAreaCode"]= htAreeCode[strAreaCode].ToString();
				}
				
				string strLevel=dr["�ͻ��ȼ�"].ToString();
				if(!htNameCode.ContainsKey("CUST_LEVEL"+strLevel))
				{
					dr["У�����"] += strLevel+"���ͻ��ȼ�����ȷ��";
					iError += 1;
				}
				else
				{
					dr["cnvcLevel"]=  htNameCode["CUST_LEVEL"+strLevel].ToString();
				}
				
				dr["cnvcIntro"]= dr["��λ����"];
				dr["cnvcAddress"]= dr["��ַ"];
				dr["cnvcPost"]= dr["�ͻ��ʱ�"];

				string strCreateDate = dr["�ͻ���ϵ����ʱ��"].ToString();
				if(!this.JudgeIsDate(strCreateDate))
				{
					dr["У�����"] += strCreateDate+"�����ڸ�ʽ����";
					iError += 1;
				}
				else
					dr["cndCreateDate"]= DateTime.Parse(dr["�ͻ���ϵ����ʱ��"].ToString()).ToString("yyyy-MM-dd");
				dr["cnvcIT"]= dr["��Ϣ��ʵʩ���"];
				dr["cnvcCompetitor"]= dr["ʹ�þ������ֲ�Ʒ���"];

				string strMonthFee = dr["��ͨ��ʹ�÷�"].ToString();
				if(!this.JudgeIsNum(strMonthFee))
				{
					dr["У�����"] += strMonthFee +"���������֣�";
					iError += 1;
				}
				else
				{
					dr["cnnMonthFee"]= dr["��ͨ��ʹ�÷�"];
				}
				
				dr["cnvcITPlan"]= dr["��Ϣ������ƻ�"];

				string strPayAbility=dr["֧������"].ToString();
				if(!htNameCode.ContainsKey("PAY_ABILITY"+strPayAbility))
				{
					dr["У�����"] += strPayAbility+"��֧����������ȷ��";
					iError += 1;
				}
				else
				{
					dr["cnvcPayAbility"]= htNameCode["PAY_ABILITY"+strPayAbility].ToString();
				}

				string strContractType=dr["Э�����"].ToString();
				if(!htNameCode.ContainsKey("CONTRACT_TYPE"+strContractType))
				{
					dr["У�����"] += strContractType+"��Э���������ȷ��";
					iError += 1;
				}
				else
				{
					dr["cnvcContractType"]=htNameCode["CONTRACT_TYPE"+strContractType].ToString();
				}
				
				if(dr["��ز���1"].ToString()!="")
				{
					dr["cnvcRelativeDept"]= dr["��ز���1"];

					string strRelativeDeptType=dr["��������1"].ToString();
					if(!htNameCode.ContainsKey("RELATIVEDEPT_TYPE"+strRelativeDeptType))
					{
						dr["У�����"] += strRelativeDeptType+"����������1����ȷ��";
						iError += 1;
					}
					else
					{
						dr["cnvcRelativeDeptType"]= htNameCode["RELATIVEDEPT_TYPE"+strRelativeDeptType].ToString();
					}
				}

				if(dr["��ز���2"].ToString()!="")
				{
					dr["cnvcRelativeDept2"]= dr["��ز���2"];

					string strRelativeDeptType2=dr["��������2"].ToString();
					if(!htNameCode.ContainsKey("RELATIVEDEPT_TYPE"+strRelativeDeptType2))
					{
						dr["У�����"] += strRelativeDeptType2+"����������2����ȷ��";
						iError += 1;
					}
					else
					{
						dr["cnvcRelativeDeptType2"]= htNameCode["RELATIVEDEPT_TYPE"+strRelativeDeptType2].ToString();
					}
				}

				if(dr["��ز���3"].ToString()!="")
				{
					dr["cnvcRelativeDept3"]= dr["��ز���3"];

					string strRelativeDeptType3=dr["��������3"].ToString();
					if(!htNameCode.ContainsKey("RELATIVEDEPT_TYPE"+strRelativeDeptType3))
					{
						dr["У�����"] += strRelativeDeptType3+"����������3����ȷ��";
						iError += 1;
					}
					else
					{
						dr["cnvcRelativeDeptType3"]= htNameCode["RELATIVEDEPT_TYPE"+strRelativeDeptType3].ToString();
					}
				}

				if(dr["��ز���4"].ToString()!="")
				{
					dr["cnvcRelativeDept4"]= dr["��ز���4"];

					string strRelativeDeptType4=dr["��������4"].ToString();
					if(!htNameCode.ContainsKey("RELATIVEDEPT_TYPE"+strRelativeDeptType4))
					{
						dr["У�����"] += strRelativeDeptType4+"����������4����ȷ��";
						iError += 1;
					}
					else
					{
						dr["cnvcRelativeDeptType4"]=htNameCode["RELATIVEDEPT_TYPE"+strRelativeDeptType4].ToString();
					}
				}

				if(dr["��ز���5"].ToString()!="")
				{
					dr["cnvcRelativeDept5"]= dr["��ز���5"];

					string strRelativeDeptType5=dr["��������5"].ToString();
					if(!htNameCode.ContainsKey("RELATIVEDEPT_TYPE"+strRelativeDeptType5))
					{
						dr["У�����"] += strRelativeDeptType5+"����������5����ȷ��";
						iError += 1;
					}
					else
					{
						dr["cnvcRelativeDeptType5"]= htNameCode["RELATIVEDEPT_TYPE"+strRelativeDeptType5].ToString();
					}
				}

				if(dr["�ͻ�����"].ToString().Trim()==""||dr["�ͻ�����"].ToString().Trim()=="��")
				{
					string strCustTradeMana=dr["��ҵ����"].ToString();
					if(!htTradeMana.ContainsKey(strCustTradeMana))
					{
						dr["У�����"] += strCustTradeMana+"����ҵ�������ڣ�";
						iError += 1;
					}
					else
					{
						dr["cnvcCustMana"]="��";
						dr["cnvcCustTradeMana"]= htTradeMana[strCustTradeMana].ToString();
					}
				}
				else
				{
					string strCustMana=dr["�ͻ�����"].ToString();
					string strCustTradeMana=dr["��ҵ����"].ToString();
					if(!htCustMana.ContainsKey(strCustMana))
					{
						dr["У�����"] += strCustMana+"���ͻ��������ڣ�";
						iError += 1;
					}
					else if(!htTradeMana.ContainsKey(strCustTradeMana))
					{
						dr["У�����"] += strCustTradeMana+"����ҵ�������ڣ�";
						iError += 1;
					}
					else if(!htManaRelation.ContainsKey(strCustMana))
					{
						dr["У�����"] += strCustMana+"��"+strCustTradeMana+"���ͻ��������ҵ�����Ӧ��ϵ�����ڣ�";
						iError += 1;
					}
					else
					{
						dr["cnvcCustMana"]= htCustMana[strCustMana].ToString();
						dr["cnvcCustTradeMana"]= htTradeMana[strCustTradeMana].ToString();
					}
				}
			}
			this.txtError.Text = iError.ToString();
			return ds;
		}

		private DataSet CheckSaleCost(DataSet ds)
		{
			DataTable dtCust = Helper.Query("select cnnCustID,cnvcName from tbCust");
			Hashtable htCust = new Hashtable();
			foreach(DataRow dr1 in dtCust.Rows)
			{
				Cust tCust = new Cust(dr1);
				htCust.Add(tCust.cnnCustID.ToString(),tCust.cnvcName);
			}

			DataTable dtSaleCost = Helper.Query("select cnnCustID,cnvcYear from tbSaleCost");
			Hashtable htSaleCost = new Hashtable();
			foreach(DataRow dr3 in dtSaleCost.Rows)
			{
				htSaleCost.Add(dr3["cnnCustID"].ToString(),dr3["cnvcYear"].ToString());
			}

			int iError = 0;
			DataTable dt = ds.Tables[0];
			dt.Columns.Add("У�����");
			dt.Columns.Add("cnnCustID");
			dt.Columns.Add("cnvcCustName");
			dt.Columns.Add("cnvcYear");
			dt.Columns.Add("cnnBudgetCost");
			dt.Columns.Add("cnnRealSaleCost");
			dt.Columns.Add("cnnCostUsed");
			dt.Columns.Add("cnnUsed1");
			dt.Columns.Add("cnnUsed2");
			dt.Columns.Add("cnnUsed3");
			dt.Columns.Add("cnnUsed4");
			dt.Columns.Add("cnnUsed5");
			dt.Columns.Add("cnnUsed6");
			dt.Columns.Add("cnnUsed7");
			dt.Columns.Add("cnnUsed8");
			dt.Columns.Add("cnnUsed9");
			dt.Columns.Add("cnnUsed10");
			dt.Columns.Add("cnnUsed11");
			dt.Columns.Add("cnnUsed12");
		
			foreach(DataRow dr in dt.Rows)
			{
				string strCustID = dr["�ͻ�ID"].ToString();
				string strCustName = dr["�ͻ�����"].ToString();
				if(strCustID.Trim()=="")
				{
					dr["У�����"] += strCustID+"���ͻ�IDΪ�գ�";
					iError += 1;
					continue;
				}
				if(!htCust.ContainsKey(strCustID))
				{
					dr["У�����"] += strCustID+"�����ȵ���˿ͻ���Ϣ��";
					iError += 1;
				}
				else if(strCustName!=htCust[strCustID].ToString())
				{
					dr["У�����"] += strCustName+"���ͻ����������пͻ����ϲ������";
					iError += 1;
				}
				else
				{
					dr["cnnCustID"] = dr["�ͻ�ID"];
					dr["cnvcCustName"] = dr["�ͻ�����"];
				}

				string strYear=dr["���"].ToString().Trim();
				if(strYear.Length!=4||!this.JudgeIsNum(strYear))
				{
					dr["У�����"] +=strYear+"����ݸ�ʽ����ȷ��ӦΪ4λ���֣�";
				}
				else
				{
					if(htSaleCost.ContainsKey(strCustID)&&htSaleCost[strCustID].ToString()==strYear)
					{
						dr["У�����"] += strCustID+" "+strYear+"�����۳ɱ������Ѿ����ڣ�";
						iError += 1;
					}
					else
					{
						dr["cnvcYear"]= strYear;
					}
				}

				string strBugetCost = dr["Ԥ�����۳ɱ�����Ԫ��"].ToString().Trim();
				if(strBugetCost==""||!this.JudgeIsNum(strBugetCost))
				{
					dr["У�����"] += "Ԥ��ɱ�:"+strBugetCost +"���������֣�";
					iError += 1;
				}
				else
				{
					dr["cnnBudgetCost"]= strBugetCost;
				}

				string strRealSaleCost = dr["ʵ�����۳ɱ��ϼƣ���Ԫ��"].ToString().Trim();
				if(strRealSaleCost==""||!this.JudgeIsNum(strRealSaleCost))
				{
					dr["У�����"] += "ʵ�ʳɱ�:"+strRealSaleCost +"���������֣�";
					iError += 1;
				}
				else
				{
					dr["cnnRealSaleCost"]=strRealSaleCost;
				}

				double costsum=0;
				for(int k=1;k<=12;k++)
				{
					string strUsedtmp = dr[k.ToString()+"��"].ToString().Trim();
					if(strUsedtmp=="")
					{
						dr["cnnUsed"+k.ToString()]= "0";
					}
					else if(!this.JudgeIsNum(strUsedtmp))
					{
						dr["У�����"] += k.ToString()+"��:"+strUsedtmp +"���������֣�";
						iError += 1;
					}
					else
					{
						dr["cnnUsed"+k.ToString()]= strUsedtmp;
						costsum+=Math.Round(double.Parse(strUsedtmp),2);
					}
				}

				dr["cnnCostUsed"]=(Math.Round(costsum,2)).ToString();

			}
			this.txtError.Text = iError.ToString();
			return ds;
		}

		private void AddChance(DataTable dt)
		{

			ChanceFacade.BatchProject(dt,oper);
		}
		private void AddAdvancePayment(DataTable dt)
		{
			SalesManageFacade.BatchAdvancePayment(dt,oper);
		}
		private void AddAccountReceivable(DataTable dt)
		{
			SalesManageFacade.BatchAccountReceivable(dt,oper);
		}
		private void AddCustInfo(DataTable dt)
		{
			VCustInfoFacade.BatchCustInfo(dt,oper);
		}
		private void AddSaleCost(DataTable dt)
		{
			SalesManageFacade.BatchSaleCost(dt,oper);
		}
		private void btnWriteFile_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(Session["UpLoadFile"] == null)
				{
					throw new Exception("�����ȶ�ȡ�ļ�");
				}
				DataTable dt = (DataTable)Session["UpLoadFile"];
				if(txtError.Text != "")
				{
					int iError = Convert.ToInt32(txtError.Text);
					if(iError > 0)
						throw new Exception("�����ȹ淶����");
				}
				switch(this.txtXlsType.Text)
				{
					case "Chance":
						AddChance(dt);
						Popup("�̻�����ɹ�");
						break;
					case "AdvancePayment":
						AddAdvancePayment(dt);
						Popup("Ԥ���˿��ɹ�");
						break;
					case "AccountReceivable":
						AddAccountReceivable(dt);
						Popup("Ӧ�յ���ɹ�");
						break;
					case "CustInfo":
						AddCustInfo(dt);
						Popup("�ͻ�������Ϣ����ɹ�");
						break;
					case "SaleCost":
						AddSaleCost(dt);
						Popup("���۳ɱ�����ɹ�");
						break;
				}
				Session["UpLoadFile"] = null;
				this.lblFileName.Text = "";
				this.txtError.Text = "0";
				this.DataGrid1.DataSource = null;
				this.DataGrid1.DataBind();
				
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			switch(this.txtXlsType.Text)
			{
				case "Chance":
					this.Response.Redirect("BusinessChance/wfmChanceQuery.aspx");
					break;
				case "AdvancePayment":
					this.Response.Redirect("SalesManage/wfmAdvancePayment.aspx");
					break;
				case "AccountReceivable":
					this.Response.Redirect("SalesManage/wfmAccountReceivable.aspx");
					break;
				case "CustInfo":
					this.Response.Redirect("VCustInfo/wfmVCustInfo.aspx");
					break;
				case "SaleCost":
					this.Response.Redirect("SalesManage/wfmSaleCost.aspx");
					break;
			}
		}

		private void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			if(this.txtXlsType.Text=="CustInfo")
			{
				for(int i=31;i<61;i++)
				{
					e.Item.Cells[i].Visible=false;
				}
			}
		}
	}
}
