
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   VCustApp
* �ļ���:   	Func.cs
* ����:	     ֣��
* ��������:    2008-11-12
* ��������:    �����б�

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
	/// **�������ƣ������б�ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbFunc")]
	public class Func: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private string _cnvcFuncCode = String.Empty;
		private string _cnvcFuncName = String.Empty;
		private string _cnvcCtrlID = String.Empty;
		private string _cnvcComments = String.Empty;
		
		#endregion
		
		#region ���캯��




		public Func():base()
		{
		}
		
		public Func(DataRow row):base(row)
		{
		}
		
		public Func(DataTable table):base(table)
		{
		}
		
		public Func(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������




				
		/// <summary>
		/// ���ܴ���
		/// </summary>
		[ColumnMapping("cnvcFuncCode",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFuncCode
		{
			get {return _cnvcFuncCode;}
			set {_cnvcFuncCode = value;}
		}

		/// <summary>
		/// ��������
		/// </summary>
		[ColumnMapping("cnvcFuncName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFuncName
		{
			get {return _cnvcFuncName;}
			set {_cnvcFuncName = value;}
		}

		/// <summary>
		/// �ؼ�ID
		/// </summary>
		[ColumnMapping("cnvcCtrlID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCtrlID
		{
			get {return _cnvcCtrlID;}
			set {_cnvcCtrlID = value;}
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
		#endregion
	}	
}
