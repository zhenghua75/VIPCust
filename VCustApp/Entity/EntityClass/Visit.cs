
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   VCustApp
* �ļ���:   	Visit.cs
* ����:	     ֣��
* ��������:    2008-11-12
* ��������:    ���ټ�¼��

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
	/// **�������ƣ����ټ�¼��ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbVisit")]
	public class Visit: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private decimal _cnnVisitSerialNo;
		private decimal _cnnProjectID;
		private decimal _cnnCustID;
		private string _cnvcMgr = String.Empty;
		private DateTime _cndVisitDate;
		private string _cnvcVisitContent = String.Empty;
		private string _cnvcVisitDept = String.Empty;
		private string _cnvcDeptType = String.Empty;
		private string _cnvcVisitMan = String.Empty;
		private string _cnvcManType = String.Empty;
		private string _cnvcAffect = String.Empty;
		private string _cnvcCustType = String.Empty;
		private string _cnvcWellType = String.Empty;
		private string _cnvcCorpRelation = String.Empty;
		private string _cnvcPrivateRelation = String.Empty;
		private string _cnvcProjectSpeed = String.Empty;
		private string _cnvcFour = String.Empty;
		private string _cnvcDemandType = String.Empty;
		private string _cnvcOperID = String.Empty;
		private DateTime _cndOperDate;
		private string _cnvcComments = String.Empty;

		#endregion
		
		#region ���캯��




		public Visit():base()
		{
		}
		
		public Visit(DataRow row):base(row)
		{
		}
		
		public Visit(DataTable table):base(table)
		{
		}
		
		public Visit(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������




				
		/// <summary>
		/// �ݷ���ˮ
		/// </summary>
		[ColumnMapping("cnnVisitSerialNo",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnVisitSerialNo
		{
			get {return _cnnVisitSerialNo;}
			set {_cnnVisitSerialNo = value;}
		}

		/// <summary>
		/// ��ĿID
		/// </summary>
		[ColumnMapping("cnnProjectID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnProjectID
		{
			get {return _cnnProjectID;}
			set {_cnnProjectID = value;}
		}

		/// <summary>
		/// �ͻ�ID
		/// </summary>
		[ColumnMapping("cnnCustID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnCustID
		{
			get {return _cnnCustID;}
			set {_cnnCustID = value;}
		}

		/// <summary>
		/// ��Ŀ����
		/// </summary>
		[ColumnMapping("cnvcMgr",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMgr
		{
			get {return _cnvcMgr;}
			set {_cnvcMgr = value;}
		}

		/// <summary>
		/// �ݷ�����
		/// </summary>
		[ColumnMapping("cndVisitDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndVisitDate
		{
			get {return _cndVisitDate;}
			set {_cndVisitDate = value;}
		}

		/// <summary>
		/// �ݷ�����
		/// </summary>
		[ColumnMapping("cnvcVisitContent",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcVisitContent
		{
			get {return _cnvcVisitContent;}
			set {_cnvcVisitContent = value;}
		}

		/// <summary>
		/// �ݷò���
		/// </summary>
		[ColumnMapping("cnvcVisitDept",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcVisitDept
		{
			get {return _cnvcVisitDept;}
			set {_cnvcVisitDept = value;}
		}

		/// <summary>
		/// ��������
		/// </summary>
		[ColumnMapping("cnvcDeptType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptType
		{
			get {return _cnvcDeptType;}
			set {_cnvcDeptType = value;}
		}

		/// <summary>
		/// ������
		/// </summary>
		[ColumnMapping("cnvcVisitMan",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcVisitMan
		{
			get {return _cnvcVisitMan;}
			set {_cnvcVisitMan = value;}
		}

		/// <summary>
		/// ����������
		/// </summary>
		[ColumnMapping("cnvcManType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcManType
		{
			get {return _cnvcManType;}
			set {_cnvcManType = value;}
		}

		/// <summary>
		/// Ӱ����
		/// </summary>
		[ColumnMapping("cnvcAffect",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcAffect
		{
			get {return _cnvcAffect;}
			set {_cnvcAffect = value;}
		}

		/// <summary>
		/// �ͻ�����
		/// </summary>
		[ColumnMapping("cnvcCustType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCustType
		{
			get {return _cnvcCustType;}
			set {_cnvcCustType = value;}
		}

		/// <summary>
		/// �����
		/// </summary>
		[ColumnMapping("cnvcWellType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcWellType
		{
			get {return _cnvcWellType;}
			set {_cnvcWellType = value;}
		}

		/// <summary>
		/// ��ҵ��ϵ�
		/// </summary>
		[ColumnMapping("cnvcCorpRelation",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCorpRelation
		{
			get {return _cnvcCorpRelation;}
			set {_cnvcCorpRelation = value;}
		}

		/// <summary>
		/// ˽�˹�ϵ�
		/// </summary>
		[ColumnMapping("cnvcPrivateRelation",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcPrivateRelation
		{
			get {return _cnvcPrivateRelation;}
			set {_cnvcPrivateRelation = value;}
		}

		/// <summary>
		/// ��Ŀ��չ�׶�
		/// </summary>
		[ColumnMapping("cnvcProjectSpeed",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcProjectSpeed
		{
			get {return _cnvcProjectSpeed;}
			set {_cnvcProjectSpeed = value;}
		}

		/// <summary>
		/// ���۽���������
		/// </summary>
		[ColumnMapping("cnvcFour",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFour
		{
			get {return _cnvcFour;}
			set {_cnvcFour = value;}
		}

		/// <summary>
		/// �ͻ��������
		/// </summary>
		[ColumnMapping("cnvcDemandType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDemandType
		{
			get {return _cnvcDemandType;}
			set {_cnvcDemandType = value;}
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
		/// ��ע
		/// </summary>
		[ColumnMapping("cnvcComments",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcComments
		{
			get {return _cnvcComments;}
			set {_cnvcComments = value;}
		}
		#endregion
	}	
}
