using System;
using System.Data;
using System.Data.SqlClient;
using VCustApp.Entity.EntityClass;
using VCustApp.Entity.EntityBase;
using VCustApp.Common;
namespace VCustApp.BusinessFacade
{
	/// <summary>
	/// SalesManageFacade ��ժҪ˵����
	/// </summary>
	public class SalesManageFacade
	{
		public SalesManageFacade()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public static void AddAdvancePayment(AdvancePayment payment,Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);
					//newOper.cndCreateDate = dtSysTime;
					EntityMapping.Create(payment,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = payment.cnvcCustName;
					busiLog.cnvcFuncCode = " ���Ԥ���˿�";
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

		public static void BatchAdvancePayment(DataTable dt,Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);
					//newOper.cndCreateDate = dtSysTime;

					foreach(DataRow dr in dt.Rows)
					{
						

						AdvancePayment payment = new AdvancePayment(dr);

						string strCount = SqlHelper.ExecuteScalar(trans,CommandType.Text,"select count(*) from tbAdvancePayment where cnnCustID = "+payment.cnnCustID).ToString();
						if(Convert.ToInt32(strCount)>0)
							throw new Exception(payment.cnvcCustName+"�Ѵ���");

						EntityMapping.Create(payment,trans);
								
						BusiLog busiLog = new BusiLog();
						busiLog.cndOperDate = dtSysTime;
						busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
						busiLog.cnvcComments = payment.cnvcCustName;
						busiLog.cnvcFuncCode = " �������Ԥ���˿�";
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
		public static void UpdateAdvancePayment(AdvancePayment payment,Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);
					//newOper.cndCreateDate = dtSysTime;
					EntityMapping.Update(payment,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = payment.cnvcCustName;
					busiLog.cnvcFuncCode = " �޸�Ԥ���˿�";
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

		public static void AddAccountReceivable(AccountReceivable ar,Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);
					//newOper.cndCreateDate = dtSysTime;
					EntityMapping.Create(ar,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = ar.cnvcCustName;
					busiLog.cnvcFuncCode = " ���Ӧ��";
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
		public static void BatchAccountReceivable(DataTable dt,Oper oper)
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
						AccountReceivable ar = new AccountReceivable(dr);
						//newOper.cndCreateDate = dtSysTime;
						string strCount = SqlHelper.ExecuteScalar(trans,CommandType.Text,"select count(*) from tbAccountReceivable where cnnCustID = "+ar.cnnCustID).ToString();
						if(Convert.ToInt32(strCount)>0)
							throw new Exception(ar.cnvcCustName+"�Ѵ���");

						EntityMapping.Create(ar,trans);
								
						BusiLog busiLog = new BusiLog();
						busiLog.cndOperDate = dtSysTime;
						busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
						busiLog.cnvcComments = ar.cnvcCustName;
						busiLog.cnvcFuncCode = " �������Ӧ��";
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
		public static void UpdateAccountReceivable(AccountReceivable ar,Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);
					//newOper.cndCreateDate = dtSysTime;
					EntityMapping.Update(ar,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = ar.cnvcCustName;
					busiLog.cnvcFuncCode = " �޸�Ӧ��";
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

		public static void AddSaleCost(SaleCost cost,Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);
					//newOper.cndCreateDate = dtSysTime;
					EntityMapping.Create(cost,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = cost.cnvcCustName;
					busiLog.cnvcFuncCode = " ������۳ɱ�";
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

		public static void UpdateSaleCost(SaleCost cost,Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);
					//newOper.cndCreateDate = dtSysTime;
					EntityMapping.Update(cost,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = cost.cnvcCustName;
					busiLog.cnvcFuncCode = " �޸����۳ɱ�";
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

		public static void BatchSaleCost(DataTable dt,Oper oper)
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
						SaleCost sc = new SaleCost(dr);
						//newOper.cndCreateDate = dtSysTime;
						string strCount = SqlHelper.ExecuteScalar(trans,CommandType.Text,"select count(*) from tbSaleCost where cnnCustID = "+sc.cnnCustID+" and cnvcYear='"+sc.cnvcYear+"'").ToString();
						if(Convert.ToInt32(strCount)>0)
							throw new Exception(sc.cnnCustID+"��"+sc.cnvcYear+"��ɱ������Ѵ���");

						EntityMapping.Create(sc,trans);
								
						BusiLog busiLog = new BusiLog();
						busiLog.cndOperDate = dtSysTime;
						busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
						busiLog.cnvcComments = sc.cnvcCustName;
						busiLog.cnvcFuncCode = " ����������۳ɱ�";
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
