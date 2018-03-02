
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   VCustApp
* �ļ���:   	AccountReceivable.cs
* ����:	     ֣��
* ��������:    2008-11-19
* ��������:    Ӧ�չ���

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
	/// **�������ƣ�Ӧ�չ���ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbAccountReceivable")]
	public class AccountReceivable: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private decimal _cnnCustID;
		private string _cnvcCustName = String.Empty;
		private decimal _cnnProjectID;
		private string _cnvcProjectName = String.Empty;
		private decimal _cnnAcctID;
		private string _cnvcAcctName = String.Empty;
		private string _cnvcTradeType1 = String.Empty;
		private string _cnvcTradeType2 = String.Empty;
		private string _cnvcCustLevel = String.Empty;
		private string _cnvcContractNo = String.Empty;
		private string _cnvcSvcType = String.Empty;
		private string _cnvcSvcTypeName = String.Empty;
		private decimal _cnnFee;
		
		#endregion
		
		#region ���캯��




		public AccountReceivable():base()
		{
		}
		
		public AccountReceivable(DataRow row):base(row)
		{
		}
		
		public AccountReceivable(DataTable table):base(table)
		{
		}
		
		public AccountReceivable(string  strXML):base(strXML)
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
		/// һ����ҵ����
		/// </summary>
		[ColumnMapping("cnvcTradeType1",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcTradeType1
		{
			get {return _cnvcTradeType1;}
			set {_cnvcTradeType1 = value;}
		}

		/// <summary>
		/// ������ҵ����
		/// </summary>
		[ColumnMapping("cnvcTradeType2",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcTradeType2
		{
			get {return _cnvcTradeType2;}
			set {_cnvcTradeType2 = value;}
		}

		/// <summary>
		/// �ͻ��ȼ�
		/// </summary>
		[ColumnMapping("cnvcCustLevel",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCustLevel
		{
			get {return _cnvcCustLevel;}
			set {_cnvcCustLevel = value;}
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
		/// ҵ�����ʹ���
		/// </summary>
		[ColumnMapping("cnvcSvcType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcSvcType
		{
			get {return _cnvcSvcType;}
			set {_cnvcSvcType = value;}
		}

		/// <summary>
		/// ҵ����������
		/// </summary>
		[ColumnMapping("cnvcSvcTypeName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcSvcTypeName
		{
			get {return _cnvcSvcTypeName;}
			set {_cnvcSvcTypeName = value;}
		}

		/// <summary>
		/// ����(��Ԫ)
		/// </summary>
		[ColumnMapping("cnnFee",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnFee
		{
			get {return _cnnFee;}
			set {_cnnFee = value;}
		}
		#endregion
	}	
}
