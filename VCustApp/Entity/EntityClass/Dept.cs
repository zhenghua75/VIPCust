
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   VCustApp
* �ļ���:   	Dept.cs
* ����:	     ֣��
* ��������:    2008-11-12
* ��������:    ����

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
	/// **�������ƣ�����ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbDept")]
	public class Dept: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private string _cnvcDeptID = String.Empty;
		private string _cnvcDeptName = String.Empty;
		private string _cnvcParentDeptID = String.Empty;
		private string _cnvcAreaCode = String.Empty;
		private string _cnvcComments = String.Empty;
		
		#endregion
		
		#region ���캯��




		public Dept():base()
		{
		}
		
		public Dept(DataRow row):base(row)
		{
		}
		
		public Dept(DataTable table):base(table)
		{
		}
		
		public Dept(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������




				
		/// <summary>
		/// cnvcDeptID
		/// </summary>
		[ColumnMapping("cnvcDeptID",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptID
		{
			get {return _cnvcDeptID;}
			set {_cnvcDeptID = value;}
		}

		/// <summary>
		/// cnvcDeptName
		/// </summary>
		[ColumnMapping("cnvcDeptName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptName
		{
			get {return _cnvcDeptName;}
			set {_cnvcDeptName = value;}
		}

		/// <summary>
		/// cnvcParentDeptID
		/// </summary>
		[ColumnMapping("cnvcParentDeptID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcParentDeptID
		{
			get {return _cnvcParentDeptID;}
			set {_cnvcParentDeptID = value;}
		}

		/// <summary>
		/// cnvcAreaCode
		/// </summary>
		[ColumnMapping("cnvcAreaCode",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcAreaCode
		{
			get {return _cnvcAreaCode;}
			set {_cnvcAreaCode = value;}
		}

		/// <summary>
		/// cnvcComments
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
