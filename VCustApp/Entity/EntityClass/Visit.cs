
/******************************************************************** FR 1.20E *******
* 项目名称：   VCustApp
* 文件名:   	Visit.cs
* 作者:	     郑华
* 创建日期:    2008-11-12
* 功能描述:    跟踪记录表

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
	/// **功能名称：跟踪记录表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbVisit")]
	public class Visit: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private decimal _cnnVisitSerialNo;
		private decimal _cnnProjectID;
		private decimal _cnnCustID;
		private string _cnvcMgr = String.Empty;
		private DateTime _cndVisitDate;
		private string _cnvcVisitContent = String.Empty;
		private string _cnvcVisitDept = String.Empty;
		private string _cnvcDeptType = String.Empty;
		private string _cnvcVisitMan = String.Empty;
		private string _cnvcManType = String.Empty;
		private string _cnvcAffect = String.Empty;
		private string _cnvcCustType = String.Empty;
		private string _cnvcWellType = String.Empty;
		private string _cnvcCorpRelation = String.Empty;
		private string _cnvcPrivateRelation = String.Empty;
		private string _cnvcProjectSpeed = String.Empty;
		private string _cnvcFour = String.Empty;
		private string _cnvcDemandType = String.Empty;
		private string _cnvcOperID = String.Empty;
		private DateTime _cndOperDate;
		private string _cnvcComments = String.Empty;

		#endregion
		
		#region 构造函数




		public Visit():base()
		{
		}
		
		public Visit(DataRow row):base(row)
		{
		}
		
		public Visit(DataTable table):base(table)
		{
		}
		
		public Visit(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性




				
		/// <summary>
		/// 拜访流水
		/// </summary>
		[ColumnMapping("cnnVisitSerialNo",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnVisitSerialNo
		{
			get {return _cnnVisitSerialNo;}
			set {_cnnVisitSerialNo = value;}
		}

		/// <summary>
		/// 项目ID
		/// </summary>
		[ColumnMapping("cnnProjectID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnProjectID
		{
			get {return _cnnProjectID;}
			set {_cnnProjectID = value;}
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
		/// 项目经理
		/// </summary>
		[ColumnMapping("cnvcMgr",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMgr
		{
			get {return _cnvcMgr;}
			set {_cnvcMgr = value;}
		}

		/// <summary>
		/// 拜访日期
		/// </summary>
		[ColumnMapping("cndVisitDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndVisitDate
		{
			get {return _cndVisitDate;}
			set {_cndVisitDate = value;}
		}

		/// <summary>
		/// 拜访内容
		/// </summary>
		[ColumnMapping("cnvcVisitContent",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcVisitContent
		{
			get {return _cnvcVisitContent;}
			set {_cnvcVisitContent = value;}
		}

		/// <summary>
		/// 拜访部门
		/// </summary>
		[ColumnMapping("cnvcVisitDept",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcVisitDept
		{
			get {return _cnvcVisitDept;}
			set {_cnvcVisitDept = value;}
		}

		/// <summary>
		/// 部门属性
		/// </summary>
		[ColumnMapping("cnvcDeptType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptType
		{
			get {return _cnvcDeptType;}
			set {_cnvcDeptType = value;}
		}

		/// <summary>
		/// 被访人
		/// </summary>
		[ColumnMapping("cnvcVisitMan",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcVisitMan
		{
			get {return _cnvcVisitMan;}
			set {_cnvcVisitMan = value;}
		}

		/// <summary>
		/// 被访人属性
		/// </summary>
		[ColumnMapping("cnvcManType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcManType
		{
			get {return _cnvcManType;}
			set {_cnvcManType = value;}
		}

		/// <summary>
		/// 影响力
		/// </summary>
		[ColumnMapping("cnvcAffect",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcAffect
		{
			get {return _cnvcAffect;}
			set {_cnvcAffect = value;}
		}

		/// <summary>
		/// 客户类型
		/// </summary>
		[ColumnMapping("cnvcCustType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCustType
		{
			get {return _cnvcCustType;}
			set {_cnvcCustType = value;}
		}

		/// <summary>
		/// 满意度
		/// </summary>
		[ColumnMapping("cnvcWellType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcWellType
		{
			get {return _cnvcWellType;}
			set {_cnvcWellType = value;}
		}

		/// <summary>
		/// 企业关系深化
		/// </summary>
		[ColumnMapping("cnvcCorpRelation",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCorpRelation
		{
			get {return _cnvcCorpRelation;}
			set {_cnvcCorpRelation = value;}
		}

		/// <summary>
		/// 私人关系深化
		/// </summary>
		[ColumnMapping("cnvcPrivateRelation",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcPrivateRelation
		{
			get {return _cnvcPrivateRelation;}
			set {_cnvcPrivateRelation = value;}
		}

		/// <summary>
		/// 项目进展阶段
		/// </summary>
		[ColumnMapping("cnvcProjectSpeed",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcProjectSpeed
		{
			get {return _cnvcProjectSpeed;}
			set {_cnvcProjectSpeed = value;}
		}

		/// <summary>
		/// 销售进程四象限
		/// </summary>
		[ColumnMapping("cnvcFour",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFour
		{
			get {return _cnvcFour;}
			set {_cnvcFour = value;}
		}

		/// <summary>
		/// 客户需求跟进
		/// </summary>
		[ColumnMapping("cnvcDemandType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDemandType
		{
			get {return _cnvcDemandType;}
			set {_cnvcDemandType = value;}
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
		/// 备注
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
