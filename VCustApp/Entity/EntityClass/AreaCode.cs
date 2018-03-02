
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   VCustApp
* �ļ���:   	AreaCode.cs
* ����:	     ֣��
* ��������:    2008-11-12
* ��������:    ������

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
	/// **�������ƣ�������ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbAreaCode")]
	public class AreaCode: EntityObjectBase
	{
		#region ���ݱ����ɱ���
		private string _cnvcAreaCode = String.Empty;
		private string _cnvcRealAreaCode = String.Empty;
		private string _cnvcComments = String.Empty;
		private string _cnvcTopFlag = String.Empty;
		
		#endregion
		
		#region ���캯��




		public AreaCode():base()
		{
		}
		
		public AreaCode(DataRow row):base(row)
		{
		}
		
		public AreaCode(DataTable table):base(table)
		{
		}
		
		public AreaCode(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������




				
		/// <summary>
		/// ����
		/// </summary>
		[ColumnMapping("cnvcAreaCode",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcAreaCode
		{
			get {return _cnvcAreaCode;}
			set {_cnvcAreaCode = value;}
		}

		/// <summary>
		/// ʵ�ʴ���
		/// </summary>
		[ColumnMapping("cnvcRealAreaCode",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcRealAreaCode
		{
			get {return _cnvcRealAreaCode;}
			set {_cnvcRealAreaCode = value;}
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
		/// ���
		/// </summary>
		[ColumnMapping("cnvcTopFlag",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcTopFlag
		{
			get {return _cnvcTopFlag;}
			set {_cnvcTopFlag = value;}
		}
		#endregion
	}	
}
