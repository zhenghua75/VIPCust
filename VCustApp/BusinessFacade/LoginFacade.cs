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
	/// LoginFacade 的摘要说明。
	/// </summary>
	public class LoginFacade
	{
		public LoginFacade()
		{
			//
			// TODO: 在此处添加构造函数逻辑
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
					throw new Exception("无此用户");
				}
				if(oper.cndInvalidDate <= DateTime.MinValue)
				{
					throw new Exception("用户已失效");
				}
				if(oper.cnvcOperPwd != DataSecurity.Encrypt(strOperPwd))
				{
					throw new Exception("密码无效");
				}		
				//写登录日志
				BusiLog loginLog = new BusiLog();
				loginLog.cndOperDate = Helper.GetSysTime(conn);
				loginLog.cnnBusiSerialNo = Helper.GetSerialNo(conn);
				loginLog.cnvcFuncCode = "登录";
				loginLog.cnvcOperID = oper.cnvcOperID;
				loginLog.cnvcComments = "登录";
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
