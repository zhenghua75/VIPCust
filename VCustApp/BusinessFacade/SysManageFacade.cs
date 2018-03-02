using System;
using System.Data;
using System.Data.SqlClient;
using VCustApp.Entity.EntityClass;
using VCustApp.Entity.EntityBase;
using VCustApp.Common;
namespace VCustApp.BusinessFacade
{
	/// <summary>
	/// SysManageFacade ��ժҪ˵����
	/// </summary>
	public class SysManageFacade
	{
		public SysManageFacade()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public static void AddOper(Oper newOper,Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);
					newOper.cndCreateDate = dtSysTime;
					EntityMapping.Create(newOper,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = newOper.cnvcOperName;
					busiLog.cnvcFuncCode = " ����û�";
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

		public static void UpdatePwd(Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);

					Oper oldOper = new Oper();
					oldOper.cnvcOperID = oper.cnvcOperID;
					oldOper = EntityMapping.Get(oldOper,trans) as Oper;
					if(null == oldOper)
						throw new Exception("�޴��û�");
					oldOper.cnvcOperPwd = oper.cnvcOperPwd;//DataSecurity.Encrypt(oper.cnvcOperPwd);
					EntityMapping.Update(oldOper,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = "�޸�����";
					busiLog.cnvcFuncCode = "�޸�����";
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

		public static void UpdateOper(Oper updateOper,Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);

					EntityMapping.Update(updateOper,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = "�޸��û�";
					busiLog.cnvcFuncCode = "�޸��û�";
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

		public static void DeleteOper(Oper oldOper,Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);
					
					EntityMapping.Delete(oldOper,trans);

					SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"delete from tbOperFunc where cnvcOperID='"+oldOper.cnvcOperID+"'");
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = oldOper.cnvcOperName;
					busiLog.cnvcFuncCode = " ɾ���û�";
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

		public static void InitPwd(Oper oldOper,Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);
					
					//EntityMapping.Delete(oldOper,trans);

					SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbOper set cnvcOperPwd='"+DataSecurity.Encrypt("123456")+"' where cnvcOperID='"+oldOper.cnvcOperID+"'");
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					//busiLog.cnvcComments = oldOper.cnvcOperName;
					busiLog.cnvcFuncCode = "��ʼ����";
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
		public static void AddOperFunc(OperFunc operFunc,Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);

					EntityMapping.Create(operFunc,trans);
					
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = operFunc.cnvcFuncCode;
					busiLog.cnvcFuncCode = "���Ȩ��";
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

		public static void DeleteOperFunc(OperFunc operFunc,Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);

					EntityMapping.Delete(operFunc,trans);
					
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = operFunc.cnvcFuncCode;
					busiLog.cnvcFuncCode = "ɾ��Ȩ��";
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

		public static void AddDept(Dept dept,Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);
					oper.cndCreateDate = dtSysTime;
					EntityMapping.Create(dept,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = oper.cnvcOperName;
					busiLog.cnvcFuncCode = " ��Ӳ���";
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

		public static void DeleteDept(Dept dept,Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);
					//oper.cndCreateDate = dtSysTime;
					EntityMapping.Delete(dept,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = oper.cnvcOperName;
					busiLog.cnvcFuncCode = " ɾ������";
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

		public static void ModifyDept(Dept dept,Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);
					//oper.cndCreateDate = dtSysTime;
					EntityMapping.Update(dept,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = oper.cnvcOperName;
					busiLog.cnvcFuncCode = " �޸Ĳ���";
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

	}
}
