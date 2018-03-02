using System;
using System.Data;
using System.Data.SqlClient;
using VCustApp.Entity.EntityClass;
using VCustApp.Entity.EntityBase;
using VCustApp.Common;

namespace VCustApp.BusinessFacade
{
	/// <summary>
	/// ChanceFacade ��ժҪ˵����
	/// </summary>
	public class ChanceFacade
	{
		public ChanceFacade()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public static void BatchProject(DataTable dt,Oper oper)
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
						Project project = new Project(dr);
						string strCount = SqlHelper.ExecuteScalar(trans,CommandType.Text,"select count(*) from tbProject where cnvcChanceName = '"+project.cnvcChanceName+"'").ToString();
						if(Convert.ToInt32(strCount)>0)
							throw new Exception(project.cnvcChanceName+"�Ѵ���");
						project.cnvcOperID= oper.cnvcOperID;
						project.cndOperDate = dtSysTime;
						//project.cndCreateDate = dtSysTime;
						project.cnnProjectID = Helper.GetSerialNo(trans);
						//project.cnvcIsSucess = "0";
						if(project.cnvcMgr == oper.cnvcOperID || project.cnvcTradeMgr == oper.cnvcOperID)
							project.cnvcProjectState = "P002";
						else
							project.cnvcProjectState = "P001";
						EntityMapping.Create(project,trans);
								
						BusiLog busiLog = new BusiLog();
						busiLog.cndOperDate = dtSysTime;
						busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
						busiLog.cnvcComments = project.cnvcProjectName;
						busiLog.cnvcFuncCode = " ��������̻�";
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

		public static void AddProject(Project project,Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);

					project.cnvcOperID= oper.cnvcOperID;
					project.cndOperDate = dtSysTime;
					//project.cndCreateDate = dtSysTime;
					project.cnnProjectID = Helper.GetSerialNo(trans);
					project.cnvcIsSucess = "0";
					if(project.cnvcMgr == oper.cnvcOperID || project.cnvcTradeMgr == oper.cnvcOperID)
						project.cnvcProjectState = "P002";
					else
						project.cnvcProjectState = "P001";
					EntityMapping.Create(project,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = project.cnvcProjectName;
					busiLog.cnvcFuncCode = " ����̻�";
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

		public static void UpdateProject(Project project,Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);

					project.cnvcOperID = oper.cnvcOperID;
					project.cndOperDate = dtSysTime;
					//project.cnnProjectID = Helper.GetSerialNo(trans);
					EntityMapping.Update(project,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = project.cnvcProjectName;
					busiLog.cnvcFuncCode = " �޸��̻�";
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

		public static void DeleteProject(Project project,Oper oper)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);
					
					EntityMapping.Delete(project,trans);
								
					BusiLog busiLog = new BusiLog();
					busiLog.cndOperDate = dtSysTime;
					busiLog.cnnBusiSerialNo = Helper.GetSerialNo(trans);
					busiLog.cnvcComments = project.cnvcProjectName;
					busiLog.cnvcFuncCode = " ɾ���̻�";
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
