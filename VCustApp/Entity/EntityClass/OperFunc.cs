
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   VCustApp
* �ļ���:   	OperFunc.cs
* ����:	     ֣��
* ��������:    2008-11-12
* ��������:    Ȩ�ޱ�

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
	/// **�������ƣ�Ȩ�ޱ�ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbOperFunc")]
	public class OperFunc: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private string _cnvcOperID = String.Empty;
		private string _cnvcFuncCode = String.Empty;
		
		#endregion
		
		#region ���캯��




		public OperFunc():base()
		{
		}
		
		public OperFunc(DataRow row):base(row)
		{
		}
		
		public OperFunc(DataTable table):base(table)
		{
		}
		
		public OperFunc(string  strXML):base(strXML)
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
		/// ���ܴ���
		/// </summary>
		[ColumnMapping("cnvcFuncCode",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFuncCode
		{
			get {return _cnvcFuncCode;}
			set {_cnvcFuncCode = value;}
		}
		#endregion
	}	
}
