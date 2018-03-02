#region Import
using System;
using System.Data;
using System.Data.SqlClient;
using VCustApp.Common;
using VCustApp.Entity;
using VCustApp.Entity.EntityBase;
using VCustApp.Entity.EntityClass;
#endregion
namespace VCustApp.BusinessFacade
{
	/// <summary>
	/// Helper 的摘要说明。
	/// </summary>
	public class Helper
	{
		public Helper()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 前台查询方法
		/// </summary>
		/// <param name="strSql"></param>
		/// <returns></returns>
		public static DataTable Query(string strSql)
		{
			SqlConnection conn = ConnectionPool.BorrowConnection();
			DataTable dtRet = null;
			try
			{
				dtRet = SqlHelper.ExecuteDataTable(conn, CommandType.Text, strSql);
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
			return dtRet;
		}

		/// <summary>
		/// 导入基本参数
		/// </summary>
		/// <param name="app"></param>
		public static void LoadInitCode(System.Web.HttpApplicationState app)
		{
			SqlConnection conn = ConnectionPool.BorrowConnection();
			//DataTable dtRet = null;
			try
			{
				DataTable dtAreaCode = SqlHelper.ExecuteDataTable(conn, CommandType.Text, "select *,cnvcAreaCode as cnvcID,cnvcComments as cnvcName from tbAreaCode order by cnvcTopFlag");
				app[ConstApp.A_AREACODE] = dtAreaCode;	

				DataTable dtOper = SqlHelper.ExecuteDataTable(conn, CommandType.Text, "select *,cnvcOperID as cnvcID,cnvcOperName as cnvcName from tbOper");
				app[ConstApp.A_OPER] = dtOper;	

				DataTable dtFunc = SqlHelper.ExecuteDataTable(conn, CommandType.Text, "select * from tbFunc");
				app[ConstApp.A_FUNC] = dtFunc;	

				DataTable dtOperFunc = SqlHelper.ExecuteDataTable(conn, CommandType.Text, "select * from tbOperFunc");
				app[ConstApp.A_OPERFUNC] = dtOperFunc;	

				DataTable dtDept = SqlHelper.ExecuteDataTable(conn, CommandType.Text, "select *,cnvcDeptID as cnvcID,cnvcDeptName as cnvcName from tbDept");
				app[ConstApp.A_DEPT] = dtDept;			

				DataTable dtNameCode = SqlHelper.ExecuteDataTable(conn, CommandType.Text, "select *,cnvcCode as cnvcID from tbNameCode order by cnnSeqNo");
				app[ConstApp.A_NAMECODE] = dtNameCode;
			
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
		}

		/// <summary>
		/// 生成序列号
		/// </summary>
		/// <param name="trans"></param>
		/// <returns></returns>
		public static decimal GetSerialNo(SqlTransaction trans)
		{
			SerialNo serialNo = new SerialNo();
			serialNo.cnvcFill = "0";
			return Convert.ToDecimal(EntityMapping.Create(serialNo,trans));
		}
		public static decimal GetSerialNo(SqlConnection conn)
		{
			SerialNo serialNo = new SerialNo();
			serialNo.cnvcFill = "0";
			return Convert.ToDecimal(EntityMapping.Create(serialNo,conn));
		}
		public static DateTime GetSysTime(SqlTransaction trans)
		{
			string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
			return DateTime.Parse(strSysTime);
		}
		public static DateTime GetSysTime(SqlConnection conn)
		{
			string strSysTime = SqlHelper.ExecuteScalar(conn, CommandType.Text, "select getdate()").ToString();
			return DateTime.Parse(strSysTime);
		}
	}
}
