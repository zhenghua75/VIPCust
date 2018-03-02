
/******************************************************************** FR 1.20E *******
* 项目名称：   VCustApp
* 文件名:   	BusiLog.cs
* 作者:	     郑华
* 创建日期:    2008-11-12
* 功能描述:    操作日志

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
	/// **功能名称：操作日志实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbBusiLog")]
	public class BusiLog: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private decimal _cnnBusiSerialNo;
		private string _cnvcOperID = String.Empty;
		private DateTime _cndOperDate;
		private string _cnvcIPAddress = String.Empty;
		private string _cnvcFuncCode = String.Empty;
		private string _cnvcComments = String.Empty;
		
		#endregion
		
		#region 构造函数




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
		
		#region 系统生成属性




				
		/// <summary>
		/// 日志流水
		/// </summary>
		[ColumnMapping("cnnBusiSerialNo",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnBusiSerialNo
		{
			get {return _cnnBusiSerialNo;}
			set {_cnnBusiSerialNo = value;}
		}

		/// <summary>
		/// 操作员
		/// </summary>
		[ColumnMapping("cnvcOperID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperID
		{
			get {return _cnvcOperID;}
			set {_cnvcOperID = value;}
		}

		/// <summary>
		/// 操作时间
		/// </summary>
		[ColumnMapping("cndOperDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndOperDate
		{
			get {return _cndOperDate;}
			set {_cndOperDate = value;}
		}

		/// <summary>
		/// IP地址
		/// </summary>
		[ColumnMapping("cnvcIPAddress",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcIPAddress
		{
			get {return _cnvcIPAddress;}
			set {_cnvcIPAddress = value;}
		}

		/// <summary>
		/// 功能代码
		/// </summary>
		[ColumnMapping("cnvcFuncCode",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFuncCode
		{
			get {return _cnvcFuncCode;}
			set {_cnvcFuncCode = value;}
		}

		/// <summary>
		/// 描述
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
