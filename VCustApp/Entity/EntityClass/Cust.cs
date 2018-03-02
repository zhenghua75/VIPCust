
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   VCustApp
* �ļ���:   	Cust.cs
* ����:	     ֣��
* ��������:    2008-11-12
* ��������:    �ͻ���Ϣ��

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
	/// **�������ƣ��ͻ���Ϣ��ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbCust")]
	public class Cust: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private decimal _cnnCustID;
		private decimal _cnnParentCustID;
		private string _cnvcType = String.Empty;
		private string _cnvcName = String.Empty;
		private string _cnvcAddress = String.Empty;
		private string _cnvcPost = String.Empty;
		private string _cnvcPhone = String.Empty;
		private string _cnvcEmail = String.Empty;
		private string _cnvcFax = String.Empty;
		private string _cnvcIDType = String.Empty;
		private string _cnvcIDNbr = String.Empty;
		private string _cnvcIDAddress = String.Empty;
		private string _cnvcAreaID = String.Empty;
		private string _cnvcAreaCode = String.Empty;
		private DateTime _cndCreateDate;
		private DateTime _cndDestroyDate;
		private string _cnvcTradeType = String.Empty;
		private string _cnvcLevel = String.Empty;
		private string _cnvcIntro = String.Empty;
		private string _cnvcIT = String.Empty;
		private string _cnvcITPlan = String.Empty;
		private string _cnvcCompetitor = String.Empty;
		private decimal _cnnMonthFee;
		private string _cnvcRelativeDept = String.Empty;
		private string _cnvcRelativeDeptType = String.Empty;
		private string _cnvcBuyFlow = String.Empty;
		private string _cnvcPayAbility = String.Empty;
		private string _cnvcContractType = String.Empty;
		private string _cnvcOperID = String.Empty;
		private string _cnvcRelativeDept2 = String.Empty;
		private string _cnvcRelativeDept3 = String.Empty;
		private string _cnvcRelativeDept4 = String.Empty;
		private string _cnvcRelativeDept5 = String.Empty;
		private string _cnvcRelativeDeptType2 = String.Empty;
		private string _cnvcRelativeDeptType3 = String.Empty;
		private string _cnvcRelativeDeptType4 = String.Empty;
		private string _cnvcRelativeDeptType5 = String.Empty;
		private DateTime _cndOperDate;
		private string _cnvcCustMana= String.Empty;
		private string _cnvcCustTradeMana= String.Empty;
		
		#endregion
		
		#region ���캯��




		public Cust():base()
		{
		}
		
		public Cust(DataRow row):base(row)
		{
		}
		
		public Cust(DataTable table):base(table)
		{
		}
		
		public Cust(string  strXML):base(strXML)
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
		/// �ϼ��ͻ�ID
		/// </summary>
		[ColumnMapping("cnnParentCustID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnParentCustID
		{
			get {return _cnnParentCustID;}
			set {_cnnParentCustID = value;}
		}

		/// <summary>
		/// �ͻ�����
		/// </summary>
		[ColumnMapping("cnvcType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcType
		{
			get {return _cnvcType;}
			set {_cnvcType = value;}
		}

		/// <summary>
		/// �ͻ�����
		/// </summary>
		[ColumnMapping("cnvcName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcName
		{
			get {return _cnvcName;}
			set {_cnvcName = value;}
		}

		/// <summary>
		/// �ͻ���ַ
		/// </summary>
		[ColumnMapping("cnvcAddress",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcAddress
		{
			get {return _cnvcAddress;}
			set {_cnvcAddress = value;}
		}

		/// <summary>
		/// �ͻ��ʱ�
		/// </summary>
		[ColumnMapping("cnvcPost",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcPost
		{
			get {return _cnvcPost;}
			set {_cnvcPost = value;}
		}

		/// <summary>
		/// �ͻ��绰
		/// </summary>
		[ColumnMapping("cnvcPhone",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcPhone
		{
			get {return _cnvcPhone;}
			set {_cnvcPhone = value;}
		}

		/// <summary>
		/// �ͻ�����
		/// </summary>
		[ColumnMapping("cnvcEmail",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcEmail
		{
			get {return _cnvcEmail;}
			set {_cnvcEmail = value;}
		}

		/// <summary>
		/// �ͻ�����
		/// </summary>
		[ColumnMapping("cnvcFax",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFax
		{
			get {return _cnvcFax;}
			set {_cnvcFax = value;}
		}

		/// <summary>
		/// ֤������
		/// </summary>
		[ColumnMapping("cnvcIDType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcIDType
		{
			get {return _cnvcIDType;}
			set {_cnvcIDType = value;}
		}

		/// <summary>
		/// ֤������
		/// </summary>
		[ColumnMapping("cnvcIDNbr",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcIDNbr
		{
			get {return _cnvcIDNbr;}
			set {_cnvcIDNbr = value;}
		}

		/// <summary>
		/// ֤����ַ
		/// </summary>
		[ColumnMapping("cnvcIDAddress",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcIDAddress
		{
			get {return _cnvcIDAddress;}
			set {_cnvcIDAddress = value;}
		}

		/// <summary>
		/// ��������
		/// </summary>
		[ColumnMapping("cnvcAreaID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcAreaID
		{
			get {return _cnvcAreaID;}
			set {_cnvcAreaID = value;}
		}

		/// <summary>
		/// ������
		/// </summary>
		[ColumnMapping("cnvcAreaCode",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcAreaCode
		{
			get {return _cnvcAreaCode;}
			set {_cnvcAreaCode = value;}
		}

		/// <summary>
		/// ��ϵ����ʱ��
		/// </summary>
		[ColumnMapping("cndCreateDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndCreateDate
		{
			get {return _cndCreateDate;}
			set {_cndCreateDate = value;}
		}

		/// <summary>
		/// ��ֹʱ��
		/// </summary>
		[ColumnMapping("cndDestroyDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndDestroyDate
		{
			get {return _cndDestroyDate;}
			set {_cndDestroyDate = value;}
		}

		/// <summary>
		/// ��ҵ����
		/// </summary>
		[ColumnMapping("cnvcTradeType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcTradeType
		{
			get {return _cnvcTradeType;}
			set {_cnvcTradeType = value;}
		}

		/// <summary>
		/// �ͻ��ȼ�
		/// </summary>
		[ColumnMapping("cnvcLevel",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcLevel
		{
			get {return _cnvcLevel;}
			set {_cnvcLevel = value;}
		}

		/// <summary>
		/// ��λ����
		/// </summary>
		[ColumnMapping("cnvcIntro",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcIntro
		{
			get {return _cnvcIntro;}
			set {_cnvcIntro = value;}
		}

		/// <summary>
		/// ��Ϣ�����
		/// </summary>
		[ColumnMapping("cnvcIT",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcIT
		{
			get {return _cnvcIT;}
			set {_cnvcIT = value;}
		}

		/// <summary>
		/// ��Ϣ���ƻ�
		/// </summary>
		[ColumnMapping("cnvcITPlan",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcITPlan
		{
			get {return _cnvcITPlan;}
			set {_cnvcITPlan = value;}
		}

		/// <summary>
		/// ��������
		/// </summary>
		[ColumnMapping("cnvcCompetitor",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCompetitor
		{
			get {return _cnvcCompetitor;}
			set {_cnvcCompetitor = value;}
		}

		/// <summary>
		/// ��ͨ�ŷ�
		/// </summary>
		[ColumnMapping("cnnMonthFee",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnMonthFee
		{
			get {return _cnnMonthFee;}
			set {_cnnMonthFee = value;}
		}

		/// <summary>
		/// ��ز���
		/// </summary>
		[ColumnMapping("cnvcRelativeDept",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcRelativeDept
		{
			get {return _cnvcRelativeDept;}
			set {_cnvcRelativeDept = value;}
		}

		/// <summary>
		/// ��ز�������
		/// </summary>
		[ColumnMapping("cnvcRelativeDeptType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcRelativeDeptType
		{
			get {return _cnvcRelativeDeptType;}
			set {_cnvcRelativeDeptType = value;}
		}

		/// <summary>
		/// ��������
		/// </summary>
		[ColumnMapping("cnvcBuyFlow",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcBuyFlow
		{
			get {return _cnvcBuyFlow;}
			set {_cnvcBuyFlow = value;}
		}

		/// <summary>
		/// ֧������
		/// </summary>
		[ColumnMapping("cnvcPayAbility",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcPayAbility
		{
			get {return _cnvcPayAbility;}
			set {_cnvcPayAbility = value;}
		}

		/// <summary>
		/// Э�����
		/// </summary>
		[ColumnMapping("cnvcContractType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcContractType
		{
			get {return _cnvcContractType;}
			set {_cnvcContractType = value;}
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
		/// ��ز���2
		/// </summary>
		[ColumnMapping("cnvcRelativeDept2",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcRelativeDept2
		{
			get {return _cnvcRelativeDept2;}
			set {_cnvcRelativeDept2 = value;}
		}

		/// <summary>
		/// ��ز���3
		/// </summary>
		[ColumnMapping("cnvcRelativeDept3",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcRelativeDept3
		{
			get {return _cnvcRelativeDept3;}
			set {_cnvcRelativeDept3 = value;}
		}

		/// <summary>
		/// ��ز���4
		/// </summary>
		[ColumnMapping("cnvcRelativeDept4",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcRelativeDept4
		{
			get {return _cnvcRelativeDept4;}
			set {_cnvcRelativeDept4 = value;}
		}

		/// <summary>
		/// ��ز���5
		/// </summary>
		[ColumnMapping("cnvcRelativeDept5",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcRelativeDept5
		{
			get {return _cnvcRelativeDept5;}
			set {_cnvcRelativeDept5 = value;}
		}

		/// <summary>
		/// ��ز�������2
		/// </summary>
		[ColumnMapping("cnvcRelativeDeptType2",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcRelativeDeptType2
		{
			get {return _cnvcRelativeDeptType2;}
			set {_cnvcRelativeDeptType2 = value;}
		}
		/// <summary>
		/// ��ز�������3
		/// </summary>
		[ColumnMapping("cnvcRelativeDeptType3",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcRelativeDeptType3
		{
			get {return _cnvcRelativeDeptType3;}
			set {_cnvcRelativeDeptType3 = value;}
		}
		/// <summary>
		/// ��ز�������4
		/// </summary>
		[ColumnMapping("cnvcRelativeDeptType4",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcRelativeDeptType4
		{
			get {return _cnvcRelativeDeptType4;}
			set {_cnvcRelativeDeptType4 = value;}
		}
		/// <summary>
		/// ��ز�������5
		/// </summary>
		[ColumnMapping("cnvcRelativeDeptType5",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcRelativeDeptType5
		{
			get {return _cnvcRelativeDeptType5;}
			set {_cnvcRelativeDeptType5 = value;}
		}
		/// <summary>
		/// �ͻ�����
		/// </summary>
		[ColumnMapping("cnvcCustMana",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCustMana
		{
			get {return _cnvcCustMana;}
			set {_cnvcCustMana = value;}
		}
		/// <summary>
		/// ��ҵ����
		/// </summary>
		[ColumnMapping("cnvcCustTradeMana",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCustTradeMana
		{
			get {return _cnvcCustTradeMana;}
			set {_cnvcCustTradeMana = value;}
		}
		#endregion
	}	
}
