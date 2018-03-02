
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   VCustApp
* �ļ���:   	Link.cs
* ����:	     ֣��
* ��������:    2008-11-12
* ��������:    ��ϵ����Ϣ��

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
	/// **�������ƣ���ϵ����Ϣ��ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbLink")]
	public class Link: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private decimal _cnnLinkID;
		private decimal _cnnCustID;
		private string _cnvcName = String.Empty;
		private string _cnvcSex = String.Empty;
		private DateTime _cndBirthday;
		private string _cnvcEducation = String.Empty;
		private string _cnvcLinkType = String.Empty;
		private string _cnvcDeptName = String.Empty;
		private string _cnvcRelativeDeptType = String.Empty;
		private string _cnvcDuty = String.Empty;
		private string _cnvcJob = String.Empty;
		private string _cnvcPhone = String.Empty;
		private string _cnvcMobilePhone = String.Empty;
		private string _cnvcEmail = String.Empty;
		private string _cnvcAddress = String.Empty;
		private string _cnvcLike = String.Empty;
		private string _cnvcOperID = String.Empty;
		private DateTime _cndOperDate;
		
		#endregion
		
		#region ���캯��




		public Link():base()
		{
		}
		
		public Link(DataRow row):base(row)
		{
		}
		
		public Link(DataTable table):base(table)
		{
		}
		
		public Link(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������




				
		/// <summary>
		/// ��ϵ��ID
		/// </summary>
		[ColumnMapping("cnnLinkID",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public decimal cnnLinkID
		{
			get {return _cnnLinkID;}
			set {_cnnLinkID = value;}
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
		/// ����
		/// </summary>
		[ColumnMapping("cnvcName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcName
		{
			get {return _cnvcName;}
			set {_cnvcName = value;}
		}

		/// <summary>
		/// �Ա�
		/// </summary>
		[ColumnMapping("cnvcSex",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcSex
		{
			get {return _cnvcSex;}
			set {_cnvcSex = value;}
		}

		/// <summary>
		/// ����
		/// </summary>
		[ColumnMapping("cndBirthday",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndBirthday
		{
			get {return _cndBirthday;}
			set {_cndBirthday = value;}
		}

		/// <summary>
		/// �������
		/// </summary>
		[ColumnMapping("cnvcEducation",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcEducation
		{
			get {return _cnvcEducation;}
			set {_cnvcEducation = value;}
		}

		/// <summary>
		/// ��ϵ������
		/// </summary>
		[ColumnMapping("cnvcLinkType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcLinkType
		{
			get {return _cnvcLinkType;}
			set {_cnvcLinkType = value;}
		}

		/// <summary>
		/// ��������
		/// </summary>
		[ColumnMapping("cnvcDeptName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptName
		{
			get {return _cnvcDeptName;}
			set {_cnvcDeptName = value;}
		}

		/// <summary>
		/// ��������
		/// </summary>
		[ColumnMapping("cnvcRelativeDeptType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcRelativeDeptType
		{
			get {return _cnvcRelativeDeptType;}
			set {_cnvcRelativeDeptType = value;}
		}

		/// <summary>
		/// ְ��
		/// </summary>
		[ColumnMapping("cnvcDuty",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDuty
		{
			get {return _cnvcDuty;}
			set {_cnvcDuty = value;}
		}

		/// <summary>
		/// ������
		/// </summary>
		[ColumnMapping("cnvcJob",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcJob
		{
			get {return _cnvcJob;}
			set {_cnvcJob = value;}
		}

		/// <summary>
		/// ����
		/// </summary>
		[ColumnMapping("cnvcPhone",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcPhone
		{
			get {return _cnvcPhone;}
			set {_cnvcPhone = value;}
		}

		/// <summary>
		/// �ֻ�
		/// </summary>
		[ColumnMapping("cnvcMobilePhone",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMobilePhone
		{
			get {return _cnvcMobilePhone;}
			set {_cnvcMobilePhone = value;}
		}

		/// <summary>
		/// �����ʼ�
		/// </summary>
		[ColumnMapping("cnvcEmail",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcEmail
		{
			get {return _cnvcEmail;}
			set {_cnvcEmail = value;}
		}

		/// <summary>
		/// ͨ�ŵ�ַ
		/// </summary>
		[ColumnMapping("cnvcAddress",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcAddress
		{
			get {return _cnvcAddress;}
			set {_cnvcAddress = value;}
		}

		/// <summary>
		/// �����Ը�
		/// </summary>
		[ColumnMapping("cnvcLike",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcLike
		{
			get {return _cnvcLike;}
			set {_cnvcLike = value;}
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
		#endregion
	}	
}
