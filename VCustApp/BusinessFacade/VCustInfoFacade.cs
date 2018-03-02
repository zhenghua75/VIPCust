using System;
using System.Data;
using System.Data.SqlClient;
using VCustApp.Entity.EntityClass;
using VCustApp.Entity.EntityBase;
using VCustApp.Common;

namespace VCustApp.BusinessFacade
{
	/// <summary>
	/// VCustInfoFacade 的摘要说明。
	/// </summary>
	public class VCustInfoFacade
	{
		public VCustInfoFacade()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public static void AddVCust(Cust newcust,Oper oper)
		{
			using (SqlConnection conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					DateTime dtSysTime = Helper.GetSysTime(trans);
					newcust.cndCreateDate = dtSysTime;
					newcust.cndOperDate=dtSysTime;
					EntityMapping.Create(newcust,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = "添加新大客户";
					busiLog.cnvcFuncCode = " 客户档案管理";
					busiLog.cnvcOperID = oper.cnvcOperID;
					busiLog.cnvcIPAddress = "";
					EntityMapping.Create(busiLog,trans);
					trans.Commit();
				}
				catch(SqlException sex)
				{
					trans.Rollback();
					LogAdapter.WriteDatabaseException(sex);
					throw sex;
				}
				catch(Exception ex)
				{
					trans.Rollback();
					LogAdapter.WriteFeaturesException(ex);
					throw ex;
				}
				finally
				{
					ConnectionPool.ReturnConnection(conn);
				}
			}
		}

		public static void UpdateVCust(Cust newcust,Oper oper)
		{
			using (SqlConnection conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					DateTime dtSysTime = Helper.GetSysTime(trans);
					newcust.cndCreateDate = dtSysTime;
					newcust.cndOperDate=dtSysTime;
					EntityMapping.Update(newcust,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = "修改大客户信息";
					busiLog.cnvcFuncCode = " 客户档案管理";
					busiLog.cnvcOperID = oper.cnvcOperID;
					busiLog.cnvcIPAddress = "";
					EntityMapping.Create(busiLog,trans);
					trans.Commit();
				}
				catch(SqlException sex)
				{
					trans.Rollback();
					LogAdapter.WriteDatabaseException(sex);
					throw sex;
				}
				catch(Exception ex)
				{
					trans.Rollback();
					LogAdapter.WriteFeaturesException(ex);
					throw ex;
				}
				finally
				{
					ConnectionPool.ReturnConnection(conn);
				}
			}
		}

		public static void AddLink(Link newlink,Oper oper)
		{
			using (SqlConnection conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					DateTime dtSysTime = Helper.GetSysTime(trans);
					newlink.cndOperDate=dtSysTime;
					EntityMapping.Create(newlink,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = "添加新联系人";
					busiLog.cnvcFuncCode = " 客户档案管理";
					busiLog.cnvcOperID = oper.cnvcOperID;
					busiLog.cnvcIPAddress = "";
					EntityMapping.Create(busiLog,trans);
					trans.Commit();
				}
				catch(SqlException sex)
				{
					trans.Rollback();
					LogAdapter.WriteDatabaseException(sex);
					throw sex;
				}
				catch(Exception ex)
				{
					trans.Rollback();
					LogAdapter.WriteFeaturesException(ex);
					throw ex;
				}
				finally
				{
					ConnectionPool.ReturnConnection(conn);
				}
			}
		}

		public static void UpdateLink(Link newlink,Oper oper)
		{
			using (SqlConnection conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					DateTime dtSysTime = Helper.GetSysTime(trans);
					newlink.cndOperDate=dtSysTime;
					EntityMapping.Update(newlink,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = "修改联系人信息";
					busiLog.cnvcFuncCode = " 客户档案管理";
					busiLog.cnvcOperID = oper.cnvcOperID;
					busiLog.cnvcIPAddress = "";
					EntityMapping.Create(busiLog,trans);
					trans.Commit();
				}
				catch(SqlException sex)
				{
					trans.Rollback();
					LogAdapter.WriteDatabaseException(sex);
					throw sex;
				}
				catch(Exception ex)
				{
					trans.Rollback();
					LogAdapter.WriteFeaturesException(ex);
					throw ex;
				}
				finally
				{
					ConnectionPool.ReturnConnection(conn);
				}
			}
		}

		public static void AddVisit(Visit newvisit,Oper oper)
		{
			using (SqlConnection conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					DateTime dtSysTime = Helper.GetSysTime(trans);
					newvisit.cndOperDate=dtSysTime;
					newvisit.cnnVisitSerialNo=Helper.GetSerialNo(trans);
					EntityMapping.Create(newvisit,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = newvisit.cnnVisitSerialNo;
					busiLog.cnvcComments = "添加新拜访记录";
					busiLog.cnvcFuncCode = " 拜访跟踪";
					busiLog.cnvcOperID = oper.cnvcOperID;
					busiLog.cnvcIPAddress = "";
					EntityMapping.Create(busiLog,trans);
					trans.Commit();
				}
				catch(SqlException sex)
				{
					trans.Rollback();
					LogAdapter.WriteDatabaseException(sex);
					throw sex;
				}
				catch(Exception ex)
				{
					trans.Rollback();
					LogAdapter.WriteFeaturesException(ex);
					throw ex;
				}
				finally
				{
					ConnectionPool.ReturnConnection(conn);
				}
			}
		}

		public static void UpdateVisit(Visit newvisit,Oper oper)
		{
			using (SqlConnection conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					DateTime dtSysTime = Helper.GetSysTime(trans);
					newvisit.cndOperDate=dtSysTime;
					EntityMapping.Update(newvisit,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = "修改拜访记录";
					busiLog.cnvcFuncCode = " 拜访跟踪";
					busiLog.cnvcOperID = oper.cnvcOperID;
					busiLog.cnvcIPAddress = "";
					EntityMapping.Create(busiLog,trans);
					trans.Commit();
				}
				catch(SqlException sex)
				{
					trans.Rollback();
					LogAdapter.WriteDatabaseException(sex);
					throw sex;
				}
				catch(Exception ex)
				{
					trans.Rollback();
					LogAdapter.WriteFeaturesException(ex);
					throw ex;
				}
				finally
				{
					ConnectionPool.ReturnConnection(conn);
				}
			}
		}

		public static void AddNewDeptType(NameCode newnc,Oper oper)
		{
			using (SqlConnection conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					DateTime dtSysTime = Helper.GetSysTime(trans);
					EntityMapping.Create(newnc,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = "添加新部门属性";
					busiLog.cnvcFuncCode = " 客户档案管理";
					busiLog.cnvcOperID = oper.cnvcOperID;
					busiLog.cnvcIPAddress = "";
					EntityMapping.Create(busiLog,trans);
					trans.Commit();
				}
				catch(SqlException sex)
				{
					trans.Rollback();
					LogAdapter.WriteDatabaseException(sex);
					throw sex;
				}
				catch(Exception ex)
				{
					trans.Rollback();
					LogAdapter.WriteFeaturesException(ex);
					throw ex;
				}
				finally
				{
					ConnectionPool.ReturnConnection(conn);
				}
			}
		}

		public static void BatchCustInfo(DataTable dt,Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);

					foreach(DataRow dr in dt.Rows)
					{
						Cust cu = new Cust(dr);
						cu.cnvcOperID=oper.cnvcOperID;
						cu.cndOperDate=dtSysTime;
						//newOper.cndCreateDate = dtSysTime;
						string strCount = SqlHelper.ExecuteScalar(trans,CommandType.Text,"select count(*) from tbCust where cnnCustID = "+cu.cnnCustID+" or cnvcName='"+cu.cnvcName+"'").ToString();
						if(Convert.ToInt32(strCount)>0)
							throw new Exception(cu.cnvcName+"已存在");

						EntityMapping.Create(cu,trans);
								
						BusiLog busiLog = new BusiLog();
						busiLog.cndOperDate = dtSysTime;
						busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
						busiLog.cnvcComments = cu.cnvcName;
						busiLog.cnvcFuncCode = " 批量添加客户档案";
						busiLog.cnvcOperID = oper.cnvcOperID;
						busiLog.cnvcIPAddress = "";
						EntityMapping.Create(busiLog,trans);
					}
					trans.Commit();
				}
				catch(SqlException sex)
				{
					trans.Rollback();
					LogAdapter.WriteDatabaseException(sex);
					throw sex;
				}
				catch(Exception ex)
				{
					trans.Rollback();
					LogAdapter.WriteFeaturesException(ex);
					throw ex;
				}
				finally
				{
					ConnectionPool.ReturnConnection(conn);
				}
			}
		}
	}
}
