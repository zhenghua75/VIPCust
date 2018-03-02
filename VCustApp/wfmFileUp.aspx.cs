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
	/// wfmFileUp 的摘要说明。
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
			// 在此处放置用户代码以初始化页面
			if(!this.IsPostBack)
			{
				if(Request["XlsType"] == null)
				{
					Popup("无效链接");
					return;
				}
				this.txtXlsType.Text = Request["XlsType"].ToString();
				switch(this.txtXlsType.Text)
				{
					case "Chance":
						txtSheet.Text = "商机管理统计表$";
						lblFileUp.Text = "商机管理统计表文件导入";
						break;
					case "AdvancePayment":
						txtSheet.Text = "预收账款管理$";
						lblFileUp.Text = "预收账款管理文件导入";
						break;
					case "AccountReceivable":
						txtSheet.Text = "应收管理$";
						lblFileUp.Text = "应收管理文件导入";
						break;
					case "CustInfo":
						txtSheet.Text = "客户基础信息$";
						lblFileUp.Text = "客户基础信息文件导入";
						break;
					case "SaleCost":
						txtSheet.Text = "销售成本管理$";
						lblFileUp.Text = "销售成本管理文件导入";
						break;
				}
				this.txtError.Text = "0";

				
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
					throw new Exception("无法识别的文件");
				DataSet ds = ReadFile(txtSheet.Text);
				//校验数据
				CheckFile(ds);
				Session["UpLoadFile"] = ds.Tables[0];
				this.DataGrid1.DataSource = ds;
				this.DataGrid1.DataBind();
				this.lblFileName.Text += "<br>错误数据数量："+txtError.Text;
				if(Convert.ToInt32(txtError.Text)>0)
					this.lblFileName.Text += "<br>请查看\"校验错误\"列";
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

			lblFileName.Text = "文件名为：" + filename;
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
			dt.Columns.Add("校验错误");
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
				string strDept = dr["分公司"].ToString();
				if(!htDept.ContainsKey(strDept))		
				{
					dr["校验错误"] += strDept+"：无此份公司";				
					iError += 1;
				}
				else
					dr["cnvcDeptID"] = htDept[strDept].ToString();

				string strChanceDate = dr["商机时间"].ToString();
				if(!this.JudgeIsDate(strChanceDate))
				{
					dr["校验错误"] += strChanceDate+"：日期格式不对";
					iError += 1;
				}
				else

					dr["cndChanceDate"] = DateTime.Parse(strChanceDate).ToString("yyyy-MM-dd");

				string strCust = dr["客户名称"].ToString();
				if(!htCust.ContainsKey(strCust))
				{
					dr["校验错误"] += strCust+"：请先导入此客户信息";
					iError += 1;
				}
				else
					dr["cnnCustID"] = htCust[strCust].ToString();
				
				string strChanceName = dr["项目名称（商机）"].ToString().Trim();
				if(strChanceName == "")
				{
					dr["校验错误"] += "：商机名称不能为空";
					iError += 1;
				}
				else
					dr["cnvcChanceName"] = strChanceName;

				if(htChanceName.ContainsKey(strChanceName))
				{
					dr["校验错误"] += strChanceName+"：商机名称已存在";
					iError += 1;
				}
				else
				{
					htChanceName.Add(strChanceName,strChanceName);
				}

				//string strOper = dr["客户经理/行业经理"].ToString();
				//string[] strOpers = strOper.Split('/');
				string strMgr = dr["客户经理"].ToString();//strOpers[0];
				string strTradeMgr = dr["行业经理"].ToString();//strOpers[1];

				if(strMgr != "")
				{
					if(!htMgr.ContainsKey(strMgr))
					{
						dr["校验错误"] += strMgr+"：无此客户经理";
						iError += 1;
					}
					else
						dr["cnvcMgr"] = htMgr[strMgr].ToString();
				}
				

				if(!htTradeMgr.ContainsKey(strTradeMgr))
				{
					dr["校验错误"] += strTradeMgr+"：无此行业经理";
					iError += 1;
				}
				else
					dr["cnvcTradeMgr"] = htTradeMgr[strTradeMgr].ToString();

				string strChanceType = dr["商机类型"].ToString();
				if(!htChanceType.ContainsKey(strChanceType))
				{
					dr["校验错误"] += strChanceType+"：无此商机类型";
					iError += 1;
				}
				else
					dr["cnvcChanceType"] = htChanceType[strChanceType].ToString();

				string strForecastIncome = dr["商机预测收入（万元）"].ToString();
				if(!this.JudgeIsNum(strForecastIncome))
				{
					dr["校验错误"] += strForecastIncome+"：不是数字";
					iError += 1;
				}
				else
					dr["cnnForecastIncome"] = strForecastIncome;

				string strChanceSpeed = dr["商机进展"].ToString();
				if(!htChanceSpeed.ContainsKey(strChanceSpeed))
				{
					dr["校验错误"] += strChanceSpeed+"：无此商机进展";
					iError += 1;
				}
				else
					dr["cnvcChanceSpeed"] = htChanceSpeed[strChanceSpeed].ToString();

				string strIsSucess = dr["是否成功转化"].ToString();
				if(!htYesNo.ContainsKey(strIsSucess))
				{
					dr["校验错误"] += strIsSucess +"：只有是和否";
					iError += 1;
				}
				else
					dr["cnvcIsSucess"] = htYesNo[strIsSucess].ToString();

				string strSucessDate = dr["成功转化时间"].ToString();
				string strSucessIncome = dr["成功转换商机收入（万元/年）"].ToString();
				string strProjectName = dr["（立项）项目名称"].ToString();
				if(strIsSucess == "是")
				{
					if(!this.JudgeIsDate(strSucessDate))
					{
						dr["校验错误"] += strSucessDate +"：日期格式不对";
						iError += 1;
					}
					else
						dr["cndSucessDate"] = DateTime.Parse(strSucessDate).ToString("yyyy-MM-dd");

					if(!this.JudgeIsNum(strSucessIncome))
					{
						dr["校验错误"] += strSucessIncome+"：不是数字";
						iError += 1;
					}
					else
						dr["cnnSucessIncome"] = strSucessIncome;
					
					if(strProjectName == "")
					{
						dr["校验错误"] += "（立项）项目名称不能为空";
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
			dt.Columns.Add("校验错误");
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
				
				string strCust = dr["客户名称"].ToString();
				if(!htCust.ContainsKey(strCust))
				{
					dr["校验错误"] += strCust+"：请先导入此客户信息";
					iError += 1;
				}
				else
				{
					dr["cnnCustID"] = htCust[strCust].ToString();
					dr["cnvcCustName"] = dr["客户名称"];
				}
				dr["cnvcProjectName"] = dr["项目名称"];
				dr["cnvcAcctName"] = dr["帐户名称"];
				dr["cnvcMgr"] = dr["客户经理"];

				string strPayDate = dr["交款时间"].ToString();
				if(!this.JudgeIsDate(strPayDate))
				{
					dr["校验错误"] += strPayDate+"：日期格式不对";
					iError += 1;
				}
				else
					dr["cndPayDate"] = DateTime.Parse(dr["交款时间"].ToString()).ToString("yyyy-MM-dd");
				dr["cnvcFeeName"] = dr["费用类型"];

				string strFeeDate = dr["费用计收时间"].ToString();
				if(!this.JudgeIsDate(strFeeDate))
				{
					dr["校验错误"] += strFeeDate+"：日期格式不对";
					iError += 1;
				}
				else
					dr["cndFeeDate"] = DateTime.Parse(dr["费用计收时间"].ToString()).ToString("yyyy-MM-dd");
				string strPayFee = dr["交款金额"].ToString();
				if(!this.JudgeIsNum(strPayFee))
				{
					dr["校验错误"] += strPayFee +"：不是数字";
					iError += 1;
					
				}
				else
					dr["cnnPayFee"] = strPayFee;
				string strPrepayFee = dr["缴预存款金额"].ToString();
				if(!this.JudgeIsNum(strPrepayFee))
				{
					dr["校验错误"] = strPrepayFee + "：不是数字";
					iError += 1;
				}
				else
					dr["cnnPrepayFee"] = strPrepayFee;
				dr["cnvcComments"] = dr["备注"];
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
			dt.Columns.Add("校验错误");
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
				//dr["cnnCustID"] = dr["客户ID"];
				//dr["cnvcCustName"] = dr["客户名称"];
				string strCust = dr["客户ID"].ToString().Trim();
				if(!htCust.ContainsKey(strCust))
				{
					dr["校验错误"] += strCust+"：请先导入此客户信息";
					iError += 1;
				}
				else
				{
					string strCustName = dr["客户名称"].ToString().Trim();
					if(strCustName != htCust[strCust].ToString())
					{
						dr["校验错误"] += strCustName+"：客户名称不符";
						iError += 1;
					}
					else
					{
						dr["cnnCustID"] = dr["客户ID"];
						dr["cnvcCustName"] = dr["客户名称"];
					}
				}
				dr["cnvcTradeType1"] = dr["一级行业属性"];
				dr["cnvcTradeType2"] = dr["二级行业属性"];
				dr["cnvcCustLevel"] = dr["客户等级"];
				dr["cnvcContractNo"] = dr["合同编号"];
				dr["cnvcProjectName"] = dr["项目名称"];
				dr["cnnAcctID"] = dr["客户卡号"];
				dr["cnvcAcctName"] = dr["帐户名称"];
				dr["cnvcSvcTypeName"] = dr["业务种类"];
				string strFee = dr["收入（万元）"].ToString();
				if(!this.JudgeIsNum(strFee))
				{
					dr["校验错误"] += strFee+"：不是数字";
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
			dt.Columns.Add("校验错误");
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
				string strCustID = dr["客户ID"].ToString();
				string strCustName = dr["客户名称"].ToString();
				if(strCustID.Trim()=="")
				{
					dr["校验错误"] += strCustID+"：客户ID为空；";
					iError += 1;
					continue;
				}
				if(htCustID.ContainsKey(strCustID))
				{
					dr["校验错误"] += strCustID+"：此客户ID已经存在；";
					iError += 1;
				}
				else if(htCustName.ContainsKey(strCustName))
				{
					dr["校验错误"] += strCustName+"：此客户名称已经存在；";
					iError += 1;
				}
				else
				{
					dr["cnnCustID"] = dr["客户ID"];
					dr["cnvcName"] = dr["客户名称"];
				}
				dr["cnvcPhone"]= dr["客户电话"];
				dr["cnvcEmail"]= dr["客户E邮箱"];
				dr["cnvcFax"]= dr["客户传真"];
				
				string strTradeType=dr["三级行业属性"].ToString();
				if(!htNameCode.ContainsKey("TRADE_TYPE"+strTradeType))
				{
					dr["校验错误"] += strTradeType+"：三级行业属性不正确；";
					iError += 1;
				}
				else
				{
					dr["cnvcTradeType"]= htNameCode["TRADE_TYPE"+strTradeType].ToString();
				}

				string strAreaCode=dr["公司名称"].ToString();
				if(!htAreeCode.ContainsKey(strAreaCode))
				{
					dr["校验错误"] += strAreaCode+"：公司名称不正确；";
					iError += 1;
				}
				else
				{
					dr["cnvcAreaCode"]= htAreeCode[strAreaCode].ToString();
				}
				
				string strLevel=dr["客户等级"].ToString();
				if(!htNameCode.ContainsKey("CUST_LEVEL"+strLevel))
				{
					dr["校验错误"] += strLevel+"：客户等级不正确；";
					iError += 1;
				}
				else
				{
					dr["cnvcLevel"]=  htNameCode["CUST_LEVEL"+strLevel].ToString();
				}
				
				dr["cnvcIntro"]= dr["单位介绍"];
				dr["cnvcAddress"]= dr["地址"];
				dr["cnvcPost"]= dr["客户邮编"];

				string strCreateDate = dr["客户关系建立时间"].ToString();
				if(!this.JudgeIsDate(strCreateDate))
				{
					dr["校验错误"] += strCreateDate+"：日期格式不对";
					iError += 1;
				}
				else
					dr["cndCreateDate"]= DateTime.Parse(dr["客户关系建立时间"].ToString()).ToString("yyyy-MM-dd");
				dr["cnvcIT"]= dr["信息化实施情况"];
				dr["cnvcCompetitor"]= dr["使用竞争对手产品情况"];

				string strMonthFee = dr["月通信使用费"].ToString();
				if(!this.JudgeIsNum(strMonthFee))
				{
					dr["校验错误"] += strMonthFee +"：不是数字；";
					iError += 1;
				}
				else
				{
					dr["cnnMonthFee"]= dr["月通信使用费"];
				}
				
				dr["cnvcITPlan"]= dr["信息化建设计划"];

				string strPayAbility=dr["支付能力"].ToString();
				if(!htNameCode.ContainsKey("PAY_ABILITY"+strPayAbility))
				{
					dr["校验错误"] += strPayAbility+"：支付能力不正确；";
					iError += 1;
				}
				else
				{
					dr["cnvcPayAbility"]= htNameCode["PAY_ABILITY"+strPayAbility].ToString();
				}

				string strContractType=dr["协议情况"].ToString();
				if(!htNameCode.ContainsKey("CONTRACT_TYPE"+strContractType))
				{
					dr["校验错误"] += strContractType+"：协议情况不正确；";
					iError += 1;
				}
				else
				{
					dr["cnvcContractType"]=htNameCode["CONTRACT_TYPE"+strContractType].ToString();
				}
				
				if(dr["相关部门1"].ToString()!="")
				{
					dr["cnvcRelativeDept"]= dr["相关部门1"];

					string strRelativeDeptType=dr["部门属性1"].ToString();
					if(!htNameCode.ContainsKey("RELATIVEDEPT_TYPE"+strRelativeDeptType))
					{
						dr["校验错误"] += strRelativeDeptType+"：部门属性1不正确；";
						iError += 1;
					}
					else
					{
						dr["cnvcRelativeDeptType"]= htNameCode["RELATIVEDEPT_TYPE"+strRelativeDeptType].ToString();
					}
				}

				if(dr["相关部门2"].ToString()!="")
				{
					dr["cnvcRelativeDept2"]= dr["相关部门2"];

					string strRelativeDeptType2=dr["部门属性2"].ToString();
					if(!htNameCode.ContainsKey("RELATIVEDEPT_TYPE"+strRelativeDeptType2))
					{
						dr["校验错误"] += strRelativeDeptType2+"：部门属性2不正确；";
						iError += 1;
					}
					else
					{
						dr["cnvcRelativeDeptType2"]= htNameCode["RELATIVEDEPT_TYPE"+strRelativeDeptType2].ToString();
					}
				}

				if(dr["相关部门3"].ToString()!="")
				{
					dr["cnvcRelativeDept3"]= dr["相关部门3"];

					string strRelativeDeptType3=dr["部门属性3"].ToString();
					if(!htNameCode.ContainsKey("RELATIVEDEPT_TYPE"+strRelativeDeptType3))
					{
						dr["校验错误"] += strRelativeDeptType3+"：部门属性3不正确；";
						iError += 1;
					}
					else
					{
						dr["cnvcRelativeDeptType3"]= htNameCode["RELATIVEDEPT_TYPE"+strRelativeDeptType3].ToString();
					}
				}

				if(dr["相关部门4"].ToString()!="")
				{
					dr["cnvcRelativeDept4"]= dr["相关部门4"];

					string strRelativeDeptType4=dr["部门属性4"].ToString();
					if(!htNameCode.ContainsKey("RELATIVEDEPT_TYPE"+strRelativeDeptType4))
					{
						dr["校验错误"] += strRelativeDeptType4+"：部门属性4不正确；";
						iError += 1;
					}
					else
					{
						dr["cnvcRelativeDeptType4"]=htNameCode["RELATIVEDEPT_TYPE"+strRelativeDeptType4].ToString();
					}
				}

				if(dr["相关部门5"].ToString()!="")
				{
					dr["cnvcRelativeDept5"]= dr["相关部门5"];

					string strRelativeDeptType5=dr["部门属性5"].ToString();
					if(!htNameCode.ContainsKey("RELATIVEDEPT_TYPE"+strRelativeDeptType5))
					{
						dr["校验错误"] += strRelativeDeptType5+"：部门属性5不正确；";
						iError += 1;
					}
					else
					{
						dr["cnvcRelativeDeptType5"]= htNameCode["RELATIVEDEPT_TYPE"+strRelativeDeptType5].ToString();
					}
				}

				if(dr["客户经理"].ToString().Trim()==""||dr["客户经理"].ToString().Trim()=="无")
				{
					string strCustTradeMana=dr["行业经理"].ToString();
					if(!htTradeMana.ContainsKey(strCustTradeMana))
					{
						dr["校验错误"] += strCustTradeMana+"：行业经理不存在；";
						iError += 1;
					}
					else
					{
						dr["cnvcCustMana"]="无";
						dr["cnvcCustTradeMana"]= htTradeMana[strCustTradeMana].ToString();
					}
				}
				else
				{
					string strCustMana=dr["客户经理"].ToString();
					string strCustTradeMana=dr["行业经理"].ToString();
					if(!htCustMana.ContainsKey(strCustMana))
					{
						dr["校验错误"] += strCustMana+"：客户经理不存在；";
						iError += 1;
					}
					else if(!htTradeMana.ContainsKey(strCustTradeMana))
					{
						dr["校验错误"] += strCustTradeMana+"：行业经理不存在；";
						iError += 1;
					}
					else if(!htManaRelation.ContainsKey(strCustMana))
					{
						dr["校验错误"] += strCustMana+"与"+strCustTradeMana+"：客户经理和行业经理对应关系不存在；";
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
			dt.Columns.Add("校验错误");
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
				string strCustID = dr["客户ID"].ToString();
				string strCustName = dr["客户名称"].ToString();
				if(strCustID.Trim()=="")
				{
					dr["校验错误"] += strCustID+"：客户ID为空；";
					iError += 1;
					continue;
				}
				if(!htCust.ContainsKey(strCustID))
				{
					dr["校验错误"] += strCustID+"：请先导入此客户信息；";
					iError += 1;
				}
				else if(strCustName!=htCust[strCustID].ToString())
				{
					dr["校验错误"] += strCustName+"：客户名称与现有客户资料不相符；";
					iError += 1;
				}
				else
				{
					dr["cnnCustID"] = dr["客户ID"];
					dr["cnvcCustName"] = dr["客户名称"];
				}

				string strYear=dr["年份"].ToString().Trim();
				if(strYear.Length!=4||!this.JudgeIsNum(strYear))
				{
					dr["校验错误"] +=strYear+"：年份格式不正确，应为4位数字；";
				}
				else
				{
					if(htSaleCost.ContainsKey(strCustID)&&htSaleCost[strCustID].ToString()==strYear)
					{
						dr["校验错误"] += strCustID+" "+strYear+"：销售成本数据已经存在；";
						iError += 1;
					}
					else
					{
						dr["cnvcYear"]= strYear;
					}
				}

				string strBugetCost = dr["预算销售成本（万元）"].ToString().Trim();
				if(strBugetCost==""||!this.JudgeIsNum(strBugetCost))
				{
					dr["校验错误"] += "预算成本:"+strBugetCost +"：不是数字；";
					iError += 1;
				}
				else
				{
					dr["cnnBudgetCost"]= strBugetCost;
				}

				string strRealSaleCost = dr["实际销售成本合计（万元）"].ToString().Trim();
				if(strRealSaleCost==""||!this.JudgeIsNum(strRealSaleCost))
				{
					dr["校验错误"] += "实际成本:"+strRealSaleCost +"：不是数字；";
					iError += 1;
				}
				else
				{
					dr["cnnRealSaleCost"]=strRealSaleCost;
				}

				double costsum=0;
				for(int k=1;k<=12;k++)
				{
					string strUsedtmp = dr[k.ToString()+"月"].ToString().Trim();
					if(strUsedtmp=="")
					{
						dr["cnnUsed"+k.ToString()]= "0";
					}
					else if(!this.JudgeIsNum(strUsedtmp))
					{
						dr["校验错误"] += k.ToString()+"月:"+strUsedtmp +"：不是数字；";
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
					throw new Exception("请首先读取文件");
				}
				DataTable dt = (DataTable)Session["UpLoadFile"];
				if(txtError.Text != "")
				{
					int iError = Convert.ToInt32(txtError.Text);
					if(iError > 0)
						throw new Exception("请首先规范数据");
				}
				switch(this.txtXlsType.Text)
				{
					case "Chance":
						AddChance(dt);
						Popup("商机导入成功");
						break;
					case "AdvancePayment":
						AddAdvancePayment(dt);
						Popup("预收账款导入成功");
						break;
					case "AccountReceivable":
						AddAccountReceivable(dt);
						Popup("应收导入成功");
						break;
					case "CustInfo":
						AddCustInfo(dt);
						Popup("客户基础信息导入成功");
						break;
					case "SaleCost":
						AddSaleCost(dt);
						Popup("销售成本导入成功");
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
