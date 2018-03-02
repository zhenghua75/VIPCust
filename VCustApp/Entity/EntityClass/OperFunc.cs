
/******************************************************************** FR 1.20E *******
* 项目名称：   VCustApp
* 文件名:   	OperFunc.cs
* 作者:	     郑华
* 创建日期:    2008-11-12
* 功能描述:    权限表

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
	/// **功能名称：权限表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbOperFunc")]
	public class OperFunc: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private string _cnvcOperID = String.Empty;
		private string _cnvcFuncCode = String.Empty;
		
		#endregion
		
		#region 构造函数




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
		
		#region 系统生成属性




				
		/// <summary>
		/// 操作员编码
		/// </summary>
		[ColumnMapping("cnvcOperID",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperID
		{
			get {return _cnvcOperID;}
			set {_cnvcOperID = value;}
		}

		/// <summary>
		/// 功能代码
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
