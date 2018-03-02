
/******************************************************************** FR 1.20E *******
* 项目名称：   VCustApp
* 文件名:   	SerialNo.cs
* 作者:	     郑华
* 创建日期:    2008-11-12
* 功能描述:    序列号表

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
	/// **功能名称：序列号表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbSerialNo")]
	public class SerialNo: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private decimal _cnnSerialNo;
		private string _cnvcFill = String.Empty;
		
		#endregion
		
		#region 构造函数




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
		
		#region 系统生成属性




				
		/// <summary>
		/// 序列号
		/// </summary>
		[ColumnMapping("cnnSerialNo",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public decimal cnnSerialNo
		{
			get {return _cnnSerialNo;}
			set {_cnnSerialNo = value;}
		}

		/// <summary>
		/// 填充
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
