
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   VCustApp
* �ļ���:   	Oper.cs
* ����:	     ֣��
* ��������:    2008-11-12
* ��������:    ����Ա

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
	/// **�������ƣ�����Աʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbOper")]
	public class Oper: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private string _cnvcOperID = String.Empty;
		private string _cnvcOperName = String.Empty;
		private string _cnvcDeptID = String.Empty;
		private string _cnvcOperPwd = String.Empty;
		private string _cnvcRoleCode = String.Empty;
		private string _cnvcManager = String.Empty;
		private DateTime _cndCreateDate;
		private DateTime _cndInvalidDate;
		private string _cnvcComments = String.Empty;
		
		#endregion
		
		#region ���캯��




		public Oper():base()
		{
		}
		
		public Oper(DataRow row):base(row)
		{
		}
		
		public Oper(DataTable table):base(table)
		{
		}
		
		public Oper(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������




				
		/// <summary>
		/// ����Ա����
		/// </summary>
		[ColumnMapping("cnvcOperID",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperID
		{
			get {return _cnvcOperID;}
			set {_cnvcOperID = value;}
		}

		/// <summary>
		/// ����Ա����
		/// </summary>
		[ColumnMapping("cnvcOperName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperName
		{
			get {return _cnvcOperName;}
			set {_cnvcOperName = value;}
		}

		/// <summary>
		/// ���ű���
		/// </summary>
		[ColumnMapping("cnvcDeptID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptID
		{
			get {return _cnvcDeptID;}
			set {_cnvcDeptID = value;}
		}

		/// <summary>
		/// ����
		/// </summary>
		[ColumnMapping("cnvcOperPwd",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperPwd
		{
			get {return _cnvcOperPwd;}
			set {_cnvcOperPwd = value;}
		}

		/// <summary>
		/// ����ʱ��
		/// </summary>
		[ColumnMapping("cndCreateDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndCreateDate
		{
			get {return _cndCreateDate;}
			set {_cndCreateDate = value;}
		}

		/// <summary>
		/// ʧЧʱ��
		/// </summary>
		[ColumnMapping("cndInvalidDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndInvalidDate
		{
			get {return _cndInvalidDate;}
			set {_cndInvalidDate = value;}
		}

		/// <summary>
		/// ����
		/// </summary>
		[ColumnMapping("cnvcComments",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcComments
		{
			get {return _cnvcComments;}
			set {_cnvcComments = value;}
		}
		/// <summary>
		/// ��ɫ
		/// </summary>
		[ColumnMapping("cnvcRoleCode",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcRoleCode
		{
			get {return _cnvcRoleCode;}
			set {_cnvcRoleCode = value;}
		}
		/// <summary>
		/// ��ҵ����
		/// </summary>
		[ColumnMapping("cnvcManager",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcManager
		{
			get {return _cnvcManager;}
			set {_cnvcManager = value;}
		}
		#endregion
	}	
}
