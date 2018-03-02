
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   VCustApp
* �ļ���:   	SerialNo.cs
* ����:	     ֣��
* ��������:    2008-11-12
* ��������:    ���кű�

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
	/// **�������ƣ����кű�ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbSerialNo")]
	public class SerialNo: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private decimal _cnnSerialNo;
		private string _cnvcFill = String.Empty;
		
		#endregion
		
		#region ���캯��




		public SerialNo():base()
		{
		}
		
		public SerialNo(DataRow row):base(row)
		{
		}
		
		public SerialNo(DataTable table):base(table)
		{
		}
		
		public SerialNo(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������




				
		/// <summary>
		/// ���к�
		/// </summary>
		[ColumnMapping("cnnSerialNo",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public decimal cnnSerialNo
		{
			get {return _cnnSerialNo;}
			set {_cnnSerialNo = value;}
		}

		/// <summary>
		/// ���
		/// </summary>
		[ColumnMapping("cnvcFill",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFill
		{
			get {return _cnvcFill;}
			set {_cnvcFill = value;}
		}
		#endregion
	}	
}
