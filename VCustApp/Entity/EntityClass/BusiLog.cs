
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   VCustApp
* �ļ���:   	BusiLog.cs
* ����:	     ֣��
* ��������:    2008-11-12
* ��������:    ������־

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
	/// **�������ƣ�������־ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbBusiLog")]
	public class BusiLog: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private decimal _cnnBusiSerialNo;
		private string _cnvcOperID = String.Empty;
		private DateTime _cndOperDate;
		private string _cnvcIPAddress = String.Empty;
		private string _cnvcFuncCode = String.Empty;
		private string _cnvcComments = String.Empty;
		
		#endregion
		
		#region ���캯��




		public BusiLog():base()
		{
		}
		
		public BusiLog(DataRow row):base(row)
		{
		}
		
		public BusiLog(DataTable table):base(table)
		{
		}
		
		public BusiLog(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������




				
		/// <summary>
		/// ��־��ˮ
		/// </summary>
		[ColumnMapping("cnnBusiSerialNo",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnBusiSerialNo
		{
			get {return _cnnBusiSerialNo;}
			set {_cnnBusiSerialNo = value;}
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
		/// IP��ַ
		/// </summary>
		[ColumnMapping("cnvcIPAddress",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcIPAddress
		{
			get {return _cnvcIPAddress;}
			set {_cnvcIPAddress = value;}
		}

		/// <summary>
		/// ���ܴ���
		/// </summary>
		[ColumnMapping("cnvcFuncCode",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFuncCode
		{
			get {return _cnvcFuncCode;}
			set {_cnvcFuncCode = value;}
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
