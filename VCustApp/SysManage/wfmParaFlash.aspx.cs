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
namespace VCustApp.SysManage
{
	/// <summary>
	/// wfmParaFlash ��ժҪ˵����
	/// </summary>
	public class wfmParaFlash : wfmBase
	{
		protected System.Web.UI.WebControls.Button btnOK;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnOK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				Helper.LoadInitCode(Application);
				Popup("����ˢ�³ɹ�");
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				Helper.LoadInitCode(Application);
				Popup("����ˢ�³ɹ�");
			}
			catch(Exception ex)
			{
				Popup(ex.Message);
			}
		}
	}
}
