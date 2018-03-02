
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   VCustApp
* �ļ���:   	Project.cs
* ����:	     ֣��
* ��������:    2008-11-20
* ��������:    ��Ŀ��

*                                                           Copyright(C) 2008 zhenghua
*************************************************************************************/
#region Import NameSpace
using System;
using System.Data;
using VCustApp.Entity.EntityBase;
#endregion

namespace VCustApp.Entity.EntityClass
{
	/// <summary>
	/// **�������ƣ���Ŀ��ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbProject")]
	public class Project: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private decimal _cnnProjectID;
		private string _cnvcChanceName = String.Empty;
		private string _cnvcDeptID = String.Empty;
		private string _cnvcMgr = String.Empty;
		private string _cnvcTradeMgr = String.Empty;
		private decimal _cnnCustID;
		private decimal _cnnForecastIncome;
		private string _cnvcChanceType = String.Empty;
		private string _cnvcChanceSpeed = String.Empty;
		private DateTime _cndChanceDate;
		private string _cnvcComments = String.Empty;
		private string _cnvcIsSucess = String.Empty;
		private DateTime _cndSucessDate;
		private decimal _cnnSucessIncome;
		private string _cnvcProjectState = String.Empty;
		private string _cnvcOperID = String.Empty;
		private DateTime _cndOperDate;
		private string _cnvcContractNo = String.Empty;
		private string _cnvcProjectName = String.Empty;
		
		#endregion
		
		#region ���캯��




		public Project():base()
		{
		}
		
		public Project(DataRow row):base(row)
		{
		}
		
		public Project(DataTable table):base(table)
		{
		}
		
		public Project(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������




				
		/// <summary>
		/// ��ĿID
		/// </summary>
		[ColumnMapping("cnnProjectID",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnProjectID
		{
			get {return _cnnProjectID;}
			set {_cnnProjectID = value;}
		}

		/// <summary>
		/// �̻�����
		/// </summary>
		[ColumnMapping("cnvcChanceName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcChanceName
		{
			get {return _cnvcChanceName;}
			set {_cnvcChanceName = value;}
		}

		/// <summary>
		/// �ֹ�˾
		/// </summary>
		[ColumnMapping("cnvcDeptID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptID
		{
			get {return _cnvcDeptID;}
			set {_cnvcDeptID = value;}
		}

		/// <summary>
		/// �ͻ�����
		/// </summary>
		[ColumnMapping("cnvcMgr",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMgr
		{
			get {return _cnvcMgr;}
			set {_cnvcMgr = value;}
		}

		/// <summary>
		/// ��ҵ����
		/// </summary>
		[ColumnMapping("cnvcTradeMgr",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcTradeMgr
		{
			get {return _cnvcTradeMgr;}
			set {_cnvcTradeMgr = value;}
		}

		/// <summary>
		/// �����ͻ�
		/// </summary>
		[ColumnMapping("cnnCustID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnCustID
		{
			get {return _cnnCustID;}
			set {_cnnCustID = value;}
		}

		/// <summary>
		/// Ԥ������
		/// </summary>
		[ColumnMapping("cnnForecastIncome",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnForecastIncome
		{
			get {return _cnnForecastIncome;}
			set {_cnnForecastIncome = value;}
		}

		/// <summary>
		/// �̻�����
		/// </summary>
		[ColumnMapping("cnvcChanceType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcChanceType
		{
			get {return _cnvcChanceType;}
			set {_cnvcChanceType = value;}
		}

		/// <summary>
		/// �̻���չ
		/// </summary>
		[ColumnMapping("cnvcChanceSpeed",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcChanceSpeed
		{
			get {return _cnvcChanceSpeed;}
			set {_cnvcChanceSpeed = value;}
		}

		/// <summary>
		/// �̻�ʱ��
		/// </summary>
		[ColumnMapping("cndChanceDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndChanceDate
		{
			get {return _cndChanceDate;}
			set {_cndChanceDate = value;}
		}

		/// <summary>
		/// �̻�����
		/// </summary>
		[ColumnMapping("cnvcComments",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcComments
		{
			get {return _cnvcComments;}
			set {_cnvcComments = value;}
		}

		/// <summary>
		/// �Ƿ�ɹ�ת��
		/// </summary>
		[ColumnMapping("cnvcIsSucess",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcIsSucess
		{
			get {return _cnvcIsSucess;}
			set {_cnvcIsSucess = value;}
		}

		/// <summary>
		/// �ɹ�ת��ʱ��
		/// </summary>
		[ColumnMapping("cndSucessDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndSucessDate
		{
			get {return _cndSucessDate;}
			set {_cndSucessDate = value;}
		}

		/// <summary>
		/// �ɹ�ת������
		/// </summary>
		[ColumnMapping("cnnSucessIncome",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnSucessIncome
		{
			get {return _cnnSucessIncome;}
			set {_cnnSucessIncome = value;}
		}

		/// <summary>
		/// ��Ŀ״̬
		/// </summary>
		[ColumnMapping("cnvcProjectState",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcProjectState
		{
			get {return _cnvcProjectState;}
			set {_cnvcProjectState = value;}
		}

		/// <summary>
		/// ����Ա
		/// </summary>
		[ColumnMapping("cnvcOperID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperID
		{
			get {return _cnvcOperID;}
			set {_cnvcOperID = value;}
		}

		/// <summary>
		/// ����ʱ��
		/// </summary>
		[ColumnMapping("cndOperDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndOperDate
		{
			get {return _cndOperDate;}
			set {_cndOperDate = value;}
		}

		/// <summary>
		/// ��ͬ���
		/// </summary>
		[ColumnMapping("cnvcContractNo",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcContractNo
		{
			get {return _cnvcContractNo;}
			set {_cnvcContractNo = value;}
		}

		/// <summary>
		/// ��Ŀ����
		/// </summary>
		[ColumnMapping("cnvcProjectName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcProjectName
		{
			get {return _cnvcProjectName;}
			set {_cnvcProjectName = value;}
		}
		#endregion
	}	
}
