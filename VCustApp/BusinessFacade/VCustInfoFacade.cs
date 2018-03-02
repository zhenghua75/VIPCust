using System;
using System.Data;
using System.Data.SqlClient;
using VCustApp.Entity.EntityClass;
using VCustApp.Entity.EntityBase;
using VCustApp.Common;

namespace VCustApp.BusinessFacade
{
	/// <summary>
	/// VCustInfoFacade ��ժҪ˵����
	/// </summary>
	public class VCustInfoFacade
	{
		public VCustInfoFacade()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
					busiLog.cnvcComments = "����´�ͻ�";
					busiLog.cnvcFuncCode = " �ͻ���������";
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
					busiLog.cnvcComments = "�޸Ĵ�ͻ���Ϣ";
					busiLog.cnvcFuncCode = " �ͻ���������";
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
					busiLog.cnvcComments = "�������ϵ��";
					busiLog.cnvcFuncCode = " �ͻ���������";
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
					busiLog.cnvcComments = "�޸���ϵ����Ϣ";
					busiLog.cnvcFuncCode = " �ͻ���������";
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
					busiLog.cnvcComments = "����°ݷü�¼";
					busiLog.cnvcFuncCode = " �ݷø���";
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
					busiLog.cnvcComments = "�޸İݷü�¼";
					busiLog.cnvcFuncCode = " �ݷø���";
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
					busiLog.cnvcComments = "����²�������";
					busiLog.cnvcFuncCode = " �ͻ���������";
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
							throw new Exception(cu.cnvcName+"�Ѵ���");

						EntityMapping.Create(cu,trans);
								
						BusiLog busiLog = new BusiLog();
						busiLog.cndOperDate = dtSysTime;
						busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
						busiLog.cnvcComments = cu.cnvcName;
						busiLog.cnvcFuncCode = " ������ӿͻ�����";
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
