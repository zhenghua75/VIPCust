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

namespace VCustApp.VCustInfo
{
	/// <summary>
	/// Summary description for wfmParaMenu.
	/// </summary>
	public class wfmVCustMenu : wfmBase
	{
		//protected System.Web.UI.HtmlControls.HtmlTable tblParaMenu;		
		protected System.Web.UI.HtmlControls.HtmlTableRow trVCustInfo;
		protected System.Web.UI.HtmlControls.HtmlTableRow trVisit;
		protected System.Web.UI.HtmlControls.HtmlTableRow trCustRelationReport1;
		protected System.Web.UI.HtmlControls.HtmlTableRow trCustRelationReport2;
		protected System.Web.UI.HtmlControls.HtmlTableRow trCustRelationDeepReport;
		protected System.Web.UI.HtmlControls.HtmlTableRow trnoprom;
		//protected System.Web.UI.HtmlControls.HtmlTableRow trSysParaSet;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
//			CMSMStruct.LoginStruct ls1=new CommCenter.CMSMStruct.LoginStruct();
//			if(Session["Login"]==null)
//			{
//				Response.Redirect("Exit.aspx");
//			}
//			else
//			{
//				ls1=(CMSMStruct.LoginStruct)Session["Login"];
//			}

			#region �������в˵�Ϊ����
			trnoprom.Visible=false;
//			trParaRefresh.Visible = false;
//			trGoods.Visible = false;
//			trLoginOper.Visible = false;
//			trLoginPwd.Visible  = false;
//			trNotice.Visible  = false;
//			trSysParaSet.Visible = false;
			#endregion

			#region ���Ƶ�ǰ��ʾ�˵�
//			Hashtable htOperFunc=(Hashtable)Application["OperFunc"];
//			ArrayList almenu=(ArrayList)htOperFunc[ls1.strLoginID];
//			if(almenu!=null)
//			{
//				for(int i=0;i<almenu.Count;i++)
//				{
//					CMSMStruct.MenuStruct ms1=(CMSMStruct.MenuStruct)almenu[i];
//					HtmlTableRow trCurrent = tblParaMenu.FindControl("tr" + ms1.strFuncAddress.Replace("wfm",String.Empty)) as HtmlTableRow;
//					if(trCurrent!=null)
//					{
//						trCurrent.Visible = true;
//						trnoprom.Visible=false;
//					}
//				}
//			}
			#endregion
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
