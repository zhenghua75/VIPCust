
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   VCustApp
* �ļ���:   	AdvancePayment.cs
* ����:	     ֣��
* ��������:    2008-11-19
* ��������:    Ԥ���˿�

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
	/// **�������ƣ�Ԥ���˿�ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbAdvancePayment")]
	public class AdvancePayment: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private decimal _cnnCustID;
		private string _cnvcCustName = String.Empty;
		private decimal _cnnProjectID;
		private string _cnvcProjectName = String.Empty;
		private decimal _cnnAcctID;
		private string _cnvcAcctName = String.Empty;
		private string _cnvcMgr = String.Empty;
		private DateTime _cndPayDate;
		private string _cnvcFeeCode = String.Empty;
		private string _cnvcFeeName = String.Empty;
		private DateTime _cndFeeDate;
		private decimal _cnnPayFee;
		private decimal _cnnPrepayFee;
		private string _cnvcComments = String.Empty;
		
		#endregion
		
		#region ���캯��




		public AdvancePayment():base()
		{
		}
		
		public AdvancePayment(DataRow row):base(row)
		{
		}
		
		public AdvancePayment(DataTable table):base(table)
		{
		}
		
		public AdvancePayment(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������




				
		/// <summary>
		/// �ͻ�ID
		/// </summary>
		[ColumnMapping("cnnCustID",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnCustID
		{
			get {return _cnnCustID;}
			set {_cnnCustID = value;}
		}

		/// <summary>
		/// �ͻ�����
		/// </summary>
		[ColumnMapping("cnvcCustName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCustName
		{
			get {return _cnvcCustName;}
			set {_cnvcCustName = value;}
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
		/// ��Ŀ����
		/// </summary>
		[ColumnMapping("cnvcProjectName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcProjectName
		{
			get {return _cnvcProjectName;}
			set {_cnvcProjectName = value;}
		}

		/// <summary>
		/// �˻�ID
		/// </summary>
		[ColumnMapping("cnnAcctID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnAcctID
		{
			get {return _cnnAcctID;}
			set {_cnnAcctID = value;}
		}

		/// <summary>
		/// �˻�����
		/// </summary>
		[ColumnMapping("cnvcAcctName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcAcctName
		{
			get {return _cnvcAcctName;}
			set {_cnvcAcctName = value;}
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
		/// ����ʱ��
		/// </summary>
		[ColumnMapping("cndPayDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndPayDate
		{
			get {return _cndPayDate;}
			set {_cndPayDate = value;}
		}

		/// <summary>
		/// �������ʹ���
		/// </summary>
		[ColumnMapping("cnvcFeeCode",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFeeCode
		{
			get {return _cnvcFeeCode;}
			set {_cnvcFeeCode = value;}
		}

		/// <summary>
		/// ������������
		/// </summary>
		[ColumnMapping("cnvcFeeName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFeeName
		{
			get {return _cnvcFeeName;}
			set {_cnvcFeeName = value;}
		}

		/// <summary>
		/// ���ü���ʱ��
		/// </summary>
		[ColumnMapping("cndFeeDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndFeeDate
		{
			get {return _cndFeeDate;}
			set {_cndFeeDate = value;}
		}

		/// <summary>
		/// ������
		/// </summary>
		[ColumnMapping("cnnPayFee",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnPayFee
		{
			get {return _cnnPayFee;}
			set {_cnnPayFee = value;}
		}

		/// <summary>
		/// ��Ԥ����
		/// </summary>
		[ColumnMapping("cnnPrepayFee",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnPrepayFee
		{
			get {return _cnnPrepayFee;}
			set {_cnnPrepayFee = value;}
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
