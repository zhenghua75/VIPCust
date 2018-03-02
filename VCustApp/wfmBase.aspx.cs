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
using System.Text.RegularExpressions;
using System.Data.SqlClient;
namespace VCustApp
{
	/// <summary>
	/// wfmBase 的摘要说明。
	/// </summary>
	public class wfmBase : System.Web.UI.Page
	{
		public Oper oper
		{
			get
			{
				return Session[ConstApp.S_OPER] as Oper;
			}
		}
		public Dept dept
		{
			get
			{
				Oper oper = (Oper)Session[ConstApp.S_OPER];
				DataTable dtDept = (DataTable)Application[ConstApp.A_DEPT];
				DataRow[] drDept = dtDept.Select("cnvcDeptID='"+oper.cnvcDeptID+"'");
				return new Dept(drDept[0]);
			}
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(Session[ConstApp.S_OPER]==null)
			{								
			
				Response.Redirect(this.Request.ApplicationPath+"/Exit.aspx");
				return;
			}
			Right();
		}

		public void Right()
		{
			//准备数据
			DataTable dtFunc = Application[ConstApp.A_FUNC] as DataTable;
			DataTable dtOperFunc = Helper.Query("select * from tbOperFunc");//Application[ConstApp.A_OPERFUNC] as DataTable;	
//			int i = 0;
//			if(this.GetType().ToString() == "ASP.wfmMainTop_aspx")
//				i++;
//			if(this.GetType().ToString() == "ASP.wfmSysManageMenu_aspx")
//				i++;
			foreach(Control ctrl in this.Controls)
			{
				
				if(ctrl is System.Web.UI.HtmlControls.HtmlForm)
				{
					foreach(Control ctrl2 in ctrl.Controls)
					{
						DataRow[] drFunc = dtFunc.Select("cnvcCtrlID='"+ctrl2.ID+"'");
						if(drFunc.Length > 0)
						{
							Func func = new Func(drFunc[0]);
							ctrl2.Visible = false;
							DataRow[] drOperFunc = dtOperFunc.Select("cnvcOperID='"+oper.cnvcOperID+"' and cnvcFuncCode='"+func.cnvcFuncCode+"'");
							if(drOperFunc.Length > 0)
							{
								ctrl2.Visible = true;
								//i++;
							}
						}
					}
				}
				
			}
			//2是否具有此功能
//			if(i == 0)
//			{
//				//wfmNoAuthorization.aspx
//				Response.Redirect(this.Request.ApplicationPath+"/SysManage/wfmNoAuthorization.aspx");
//
//			}
		}

		/// <summary>
		/// 弹出窗口
		/// </summary>
		/// <param name="strComments"></param>
		public void Popup(string strComments)
		{
			this.Response.Write("<script>alert('"+UrnHtml(strComments)+"');</script>");
		}
		public string UrnHtml(string strHtml)
		{
			string[] aryReg ={ "(",")","'", "<", ">", "%","\"\"", ",", ".", ">=", "=<", "-", "_", ";", "||", "[", "]", "&", "/", "-", "|"," ", };
			for (int i = 0; i < aryReg.Length; i++)
			{
				strHtml = strHtml.Replace(aryReg[i], string.Empty);
			}

			return strHtml;
		} 
		/// <summary>
		/// 判断是否为空
		/// </summary>
		/// <param name="strText"></param>
		/// <param name="strMessage"></param>
		/// <returns></returns>
		public bool JudgeIsNull(string strText,string strMessage)
		{
			if(strText.Trim().Length == 0)
			{
				Popup(strMessage+"不能为空");
				return true;
			}
			return false;
		}
		/// <summary>
		/// 判断是否是数字
		/// </summary>
		/// <param name="strText"></param>
		/// <param name="strMessage"></param>
		/// <returns></returns>
		public bool JudgeIsNum(string strText,string strMessage)
		{
			if(!Regex.IsMatch(strText,@"^[+|-]{0,1}(\d*)\.{0,1}\d{0,}$"))
			{
				Popup(strMessage+"请输入数字");
				return false;
			}
			return true;
		}
		public bool JudgeIsNum(string strText)
		{
			if(!Regex.IsMatch(strText,@"^[+|-]{0,1}(\d*)\.{0,1}\d{0,}$"))
			{				
				return false;
			}
			return true;
		}
		public bool JudgeIsDate(string strDate)
		{
			string strRegex = @"(?:(?:(?:(?:19|20)(?:(?:[02468][048])|(?:[13579][26]))-0?2-29))|(?:\d{4}-0?(?!(?:[4|6|9]-31)|(?:2-29)|(?:11-31)|(?:2-30)|(?:2-31))((?!0|(?:1[3-9]))(?:1?[0-9])-(?!0|(?:3[2-9]))(?:[1-3]?[0-9]))))\s+(?!(?:2[4-9]))(?:[1-2]?[0-9]):0?0:0?0";
			Regex re = new Regex(strRegex);
			if (re.IsMatch(strDate))
				return (true);
			else
				return (false);
		}
		public void BindDropDownList(DropDownList ddl,string strApplicationName,string strFilter)
		{
			if(Application[strApplicationName] == null)
			{
				Popup("参数异常");
				return;
			}
			DataTable dt = Application[strApplicationName] as DataTable;
			DataView dv = new DataView(dt);
			dv.RowFilter = strFilter;
			if(strApplicationName==ConstApp.A_NAMECODE)
			{
				dv.Sort="cnnSeqNo";
			}
			ddl.DataSource = dv;
			ddl.DataValueField = "cnvcID";
			ddl.DataTextField = "cnvcName";
			ddl.DataBind();
		}

		public void BindDropDownList(DropDownList ddl,string strApplicationName,string strFilter,string strNewItem)
		{
			BindDropDownList(ddl,strApplicationName,strFilter);
			ddl.Items.Insert(0,strNewItem);	
		}
		public void BindDropDownList(DropDownList ddl,string strApplicationName,string strFilter,ListItem li)
		{
			BindDropDownList(ddl,strApplicationName,strFilter);

			ddl.Items.Insert(0,li);	
		}
		/// <summary>		
		/// DataTable里面的代码转换
		/// </summary>
		/// <param name="dt">需要转换的DataTable</param>
		/// <param name="columnName">需要转换的列</param>
		/// <param name="strApplicationName">进行转换的Application名称</param>
		/// <param name="strIDColumnName">ID列</param>
		/// <param name="strCommentsColumnName">名称列</param>
		/// <param name="filter">过滤字符串</param>
		public void DataTableConvert(DataTable dt,string columnName,string strApplicationName,string strIDColumnName,string strCommentsColumnName,string filter)
		{
			if(dt == null)
			{
				Popup("无查询结果");
				return;
			}
			string strTemp ;			
			string strCommentColumnName = columnName+"Comments";
			//判断新列是否存在，已经存在就不添加，不存在就添加
			if(dt.Columns[strCommentColumnName]==null)
			{			
				dt.Columns.Add(strCommentColumnName,typeof(string));
			}
			foreach (DataRow dr in dt.Rows)
			{
				strTemp = this.CodeConvert(strApplicationName,strIDColumnName,dr[columnName].ToString(),strCommentsColumnName,filter);					
				dr[strCommentColumnName] = strTemp;					
			}
		}		

		public void DataTableConvert(DataTable dt,string columnName,string strApplicationName,string filter)
		{
			DataTableConvert(dt,columnName,strApplicationName,"cnvcID","cnvcName",filter);
		}		

		//根据 selectId 返回tbCodeName  表中的 中文注释
		public string CodeConvert(string strApplicationName,string strIDColumnName,string selectId,string strCommentsColumnName,string filter)
		{
			//this.FillApplication(strApplicationName);
			DataTable dt=(DataTable)Application[strApplicationName];			
			string strRemark ;
			if(dt==null)
			{
				throw new Exception("Application 中代码没有找到！");
			}			
			DataView dw = new DataView(dt);			
			string strfilter = "";
			if(filter == "")
			{
				strfilter = strIDColumnName+" = '"+selectId+"'"; 
			}
			else
			{
				strfilter = filter +" and "+strIDColumnName+" = '"+selectId+"'"; 
			}
			
			dw.RowFilter = strfilter;			
			if(dw.Count == 1)
			{
				strRemark = dw[0].Row[strCommentsColumnName].ToString();
			}
			else
			{
				strRemark = selectId;
			}
			return strRemark;				
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
			this.Error += new System.EventHandler(this.wfmBase_Error);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void wfmBase_Error(object sender, System.EventArgs e)
		{
			// 记录错误日志 
			Exception errorLast = Server.GetLastError();

			if (errorLast is ConcurrentException || errorLast.InnerException is ConcurrentException)
			{
				Server.ClearError();
				Popup("其它用户修改或删除了当前信息，页面刷新获取了最新的数据！");
				Server.Transfer(Request.Url.PathAndQuery);
				return;
			}
			else if (errorLast is SqlException)
			{
				SqlException se = errorLast as SqlException;
				if (SqlErrorCode.Duplicate_Key == se.Number)
				{
					Server.ClearError();
					Popup("非常抱歉，将要创建的信息已存在！");
					Server.Transfer(Request.Url.PathAndQuery);
					return;
				}
			}

			LogAdapter.WriteInterfaceException(errorLast);

			Response.Redirect(this.Request.ApplicationPath+"/wfmError.aspx");
		}

		public int GetLength(string strIn)
		{
			int lens = strIn.Length;
			char[] chars = strIn.ToCharArray();
			for(int i=0;i<chars.Length;i++)
			{         
				if(System.Convert.ToInt32( chars[i] )>255)
				{
					lens++;
				}
			} 
			return lens;
		}
		public void DataGridToExcel(DataGrid dg,string strFileName)
		{
			Response.Clear();
			//Response.AddHeader("content-disposition", "attachment;filename="+strFileName+".xls");
			Response.AddHeader("content-disposition", "attachment;filename="+System.Web.HttpUtility.UrlEncode(strFileName)+".xls");
			//Response.Charset = "";
			Response.Charset = "GB2312";
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.ContentType = "application/vnd.xls";
			System.IO.StringWriter stringWrite = new System.IO.StringWriter();
			System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
			dg.RenderControl(htmlWrite);
			Response.Write(stringWrite.ToString());
			Response.End();
		}
	}
}
