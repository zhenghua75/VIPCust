
/******************************************************************** FR 1.20E *******
* 项目名称：   VCustApp
* 文件名:   	Link.cs
* 作者:	     郑华
* 创建日期:    2008-11-12
* 功能描述:    联系人信息表

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
	/// **功能名称：联系人信息表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbLink")]
	public class Link: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private decimal _cnnLinkID;
		private decimal _cnnCustID;
		private string _cnvcName = String.Empty;
		private string _cnvcSex = String.Empty;
		private DateTime _cndBirthday;
		private string _cnvcEducation = String.Empty;
		private string _cnvcLinkType = String.Empty;
		private string _cnvcDeptName = String.Empty;
		private string _cnvcRelativeDeptType = String.Empty;
		private string _cnvcDuty = String.Empty;
		private string _cnvcJob = String.Empty;
		private string _cnvcPhone = String.Empty;
		private string _cnvcMobilePhone = String.Empty;
		private string _cnvcEmail = String.Empty;
		private string _cnvcAddress = String.Empty;
		private string _cnvcLike = String.Empty;
		private string _cnvcOperID = String.Empty;
		private DateTime _cndOperDate;
		
		#endregion
		
		#region 构造函数




		public Link():base()
		{
		}
		
		public Link(DataRow row):base(row)
		{
		}
		
		public Link(DataTable table):base(table)
		{
		}
		
		public Link(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性




				
		/// <summary>
		/// 联系人ID
		/// </summary>
		[ColumnMapping("cnnLinkID",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public decimal cnnLinkID
		{
			get {return _cnnLinkID;}
			set {_cnnLinkID = value;}
		}

		/// <summary>
		/// 客户ID
		/// </summary>
		[ColumnMapping("cnnCustID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnCustID
		{
			get {return _cnnCustID;}
			set {_cnnCustID = value;}
		}

		/// <summary>
		/// 姓名
		/// </summary>
		[ColumnMapping("cnvcName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcName
		{
			get {return _cnvcName;}
			set {_cnvcName = value;}
		}

		/// <summary>
		/// 性别
		/// </summary>
		[ColumnMapping("cnvcSex",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcSex
		{
			get {return _cnvcSex;}
			set {_cnvcSex = value;}
		}

		/// <summary>
		/// 生日
		/// </summary>
		[ColumnMapping("cndBirthday",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndBirthday
		{
			get {return _cndBirthday;}
			set {_cndBirthday = value;}
		}

		/// <summary>
		/// 教育情况
		/// </summary>
		[ColumnMapping("cnvcEducation",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcEducation
		{
			get {return _cnvcEducation;}
			set {_cnvcEducation = value;}
		}

		/// <summary>
		/// 联系人属性
		/// </summary>
		[ColumnMapping("cnvcLinkType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcLinkType
		{
			get {return _cnvcLinkType;}
			set {_cnvcLinkType = value;}
		}

		/// <summary>
		/// 部门名称
		/// </summary>
		[ColumnMapping("cnvcDeptName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptName
		{
			get {return _cnvcDeptName;}
			set {_cnvcDeptName = value;}
		}

		/// <summary>
		/// 部门属性
		/// </summary>
		[ColumnMapping("cnvcRelativeDeptType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcRelativeDeptType
		{
			get {return _cnvcRelativeDeptType;}
			set {_cnvcRelativeDeptType = value;}
		}

		/// <summary>
		/// 职务
		/// </summary>
		[ColumnMapping("cnvcDuty",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDuty
		{
			get {return _cnvcDuty;}
			set {_cnvcDuty = value;}
		}

		/// <summary>
		/// 负责工作
		/// </summary>
		[ColumnMapping("cnvcJob",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcJob
		{
			get {return _cnvcJob;}
			set {_cnvcJob = value;}
		}

		/// <summary>
		/// 座机
		/// </summary>
		[ColumnMapping("cnvcPhone",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcPhone
		{
			get {return _cnvcPhone;}
			set {_cnvcPhone = value;}
		}

		/// <summary>
		/// 手机
		/// </summary>
		[ColumnMapping("cnvcMobilePhone",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMobilePhone
		{
			get {return _cnvcMobilePhone;}
			set {_cnvcMobilePhone = value;}
		}

		/// <summary>
		/// 电子邮件
		/// </summary>
		[ColumnMapping("cnvcEmail",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcEmail
		{
			get {return _cnvcEmail;}
			set {_cnvcEmail = value;}
		}

		/// <summary>
		/// 通信地址
		/// </summary>
		[ColumnMapping("cnvcAddress",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcAddress
		{
			get {return _cnvcAddress;}
			set {_cnvcAddress = value;}
		}

		/// <summary>
		/// 爱好性格
		/// </summary>
		[ColumnMapping("cnvcLike",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcLike
		{
			get {return _cnvcLike;}
			set {_cnvcLike = value;}
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
		#endregion
	}	
}
