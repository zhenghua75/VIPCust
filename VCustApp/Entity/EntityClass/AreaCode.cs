
/******************************************************************** FR 1.20E *******
* 项目名称：   VCustApp
* 文件名:   	AreaCode.cs
* 作者:	     郑华
* 创建日期:    2008-11-12
* 功能描述:    本地网

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
	/// **功能名称：本地网实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbAreaCode")]
	public class AreaCode: EntityObjectBase
	{
		#region 数据表生成变量
		private string _cnvcAreaCode = String.Empty;
		private string _cnvcRealAreaCode = String.Empty;
		private string _cnvcComments = String.Empty;
		private string _cnvcTopFlag = String.Empty;
		
		#endregion
		
		#region 构造函数




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
		
		#region 系统生成属性




				
		/// <summary>
		/// 代码
		/// </summary>
		[ColumnMapping("cnvcAreaCode",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcAreaCode
		{
			get {return _cnvcAreaCode;}
			set {_cnvcAreaCode = value;}
		}

		/// <summary>
		/// 实际代码
		/// </summary>
		[ColumnMapping("cnvcRealAreaCode",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcRealAreaCode
		{
			get {return _cnvcRealAreaCode;}
			set {_cnvcRealAreaCode = value;}
		}

		/// <summary>
		/// 名称
		/// </summary>
		[ColumnMapping("cnvcComments",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcComments
		{
			get {return _cnvcComments;}
			set {_cnvcComments = value;}
		}

		/// <summary>
		/// 序号
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
