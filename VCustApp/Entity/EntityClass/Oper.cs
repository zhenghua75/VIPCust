
/******************************************************************** FR 1.20E *******
* 项目名称：   VCustApp
* 文件名:   	Oper.cs
* 作者:	     郑华
* 创建日期:    2008-11-12
* 功能描述:    操作员

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
	/// **功能名称：操作员实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbOper")]
	public class Oper: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private string _cnvcOperID = String.Empty;
		private string _cnvcOperName = String.Empty;
		private string _cnvcDeptID = String.Empty;
		private string _cnvcOperPwd = String.Empty;
		private string _cnvcRoleCode = String.Empty;
		private string _cnvcManager = String.Empty;
		private DateTime _cndCreateDate;
		private DateTime _cndInvalidDate;
		private string _cnvcComments = String.Empty;
		
		#endregion
		
		#region 构造函数




		public Oper():base()
		{
		}
		
		public Oper(DataRow row):base(row)
		{
		}
		
		public Oper(DataTable table):base(table)
		{
		}
		
		public Oper(string  strXML):base(strXML)
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
		/// 操作员名称
		/// </summary>
		[ColumnMapping("cnvcOperName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperName
		{
			get {return _cnvcOperName;}
			set {_cnvcOperName = value;}
		}

		/// <summary>
		/// 部门编码
		/// </summary>
		[ColumnMapping("cnvcDeptID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptID
		{
			get {return _cnvcDeptID;}
			set {_cnvcDeptID = value;}
		}

		/// <summary>
		/// 密码
		/// </summary>
		[ColumnMapping("cnvcOperPwd",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperPwd
		{
			get {return _cnvcOperPwd;}
			set {_cnvcOperPwd = value;}
		}

		/// <summary>
		/// 创建时间
		/// </summary>
		[ColumnMapping("cndCreateDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndCreateDate
		{
			get {return _cndCreateDate;}
			set {_cndCreateDate = value;}
		}

		/// <summary>
		/// 失效时间
		/// </summary>
		[ColumnMapping("cndInvalidDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndInvalidDate
		{
			get {return _cndInvalidDate;}
			set {_cndInvalidDate = value;}
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
		/// <summary>
		/// 角色
		/// </summary>
		[ColumnMapping("cnvcRoleCode",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcRoleCode
		{
			get {return _cnvcRoleCode;}
			set {_cnvcRoleCode = value;}
		}
		/// <summary>
		/// 行业经理
		/// </summary>
		[ColumnMapping("cnvcManager",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcManager
		{
			get {return _cnvcManager;}
			set {_cnvcManager = value;}
		}
		#endregion
	}	
}
