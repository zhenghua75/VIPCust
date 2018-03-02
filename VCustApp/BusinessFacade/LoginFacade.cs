using System;
using System.Data;
using System.Data.SqlClient;
using VCustApp.Common;
using VCustApp.Entity;
using VCustApp.Entity.EntityBase;
using VCustApp.Entity.EntityClass;
using VCustApp.BusinessFacade;
namespace VCustApp.BusinessFacade
{
	/// <summary>
	/// LoginFacade ��ժҪ˵����
	/// </summary>
	public class LoginFacade
	{
		public LoginFacade()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public static Oper IsUser(string strOperID,string strOperPwd)
		{
			SqlConnection conn = ConnectionPool.BorrowConnection();
			Oper oper = null;
			try
			{
				oper = new Oper();
				oper.cnvcOperID = strOperID;
				oper = EntityMapping.Get(oper,conn) as Oper;
				if(null == oper)
				{
					throw new Exception("�޴��û�");
				}
				if(oper.cndInvalidDate <= DateTime.MinValue)
				{
					throw new Exception("�û���ʧЧ");
				}
				if(oper.cnvcOperPwd != DataSecurity.Encrypt(strOperPwd))
				{
					throw new Exception("������Ч");
				}		
				//д��¼��־
				BusiLog loginLog = new BusiLog();
				loginLog.cndOperDate = Helper.GetSysTime(conn);
				loginLog.cnnBusiSerialNo = Helper.GetSerialNo(conn);
				loginLog.cnvcFuncCode = "��¼";
				loginLog.cnvcOperID = oper.cnvcOperID;
				loginLog.cnvcComments = "��¼";
				EntityMapping.Create(loginLog,conn);
				
			}
			catch(Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw ex;
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}	
			return oper;
		}
	}
}
