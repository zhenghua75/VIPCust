
/******************************************************************** FR 1.20E *******
* 项目名称：   VCustApp
* 文件名:   	Func.cs
* 作者:	     郑华
* 创建日期:    2008-11-12
* 功能描述:    功能列表

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
	/// **功能名称：功能列表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbFunc")]
	public class Func: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private string _cnvcFuncCode = String.Empty;
		private string _cnvcFuncName = String.Empty;
		private string _cnvcCtrlID = String.Empty;
		private string _cnvcComments = String.Empty;
		
		#endregion
		
		#region 构造函数




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
		
		#region 系统生成属性




				
		/// <summary>
		/// 功能代码
		/// </summary>
		[ColumnMapping("cnvcFuncCode",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFuncCode
		{
			get {return _cnvcFuncCode;}
			set {_cnvcFuncCode = value;}
		}

		/// <summary>
		/// 功能名称
		/// </summary>
		[ColumnMapping("cnvcFuncName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFuncName
		{
			get {return _cnvcFuncName;}
			set {_cnvcFuncName = value;}
		}

		/// <summary>
		/// 控件ID
		/// </summary>
		[ColumnMapping("cnvcCtrlID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCtrlID
		{
			get {return _cnvcCtrlID;}
			set {_cnvcCtrlID = value;}
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
