
/******************************************************************** FR 1.20E *******
* 项目名称：   VCustApp
* 文件名:   	Project.cs
* 作者:	     郑华
* 创建日期:    2008-11-20
* 功能描述:    项目表

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
	/// **功能名称：项目表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbProject")]
	public class Project: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private decimal _cnnProjectID;
		private string _cnvcChanceName = String.Empty;
		private string _cnvcDeptID = String.Empty;
		private string _cnvcMgr = String.Empty;
		private string _cnvcTradeMgr = String.Empty;
		private decimal _cnnCustID;
		private decimal _cnnForecastIncome;
		private string _cnvcChanceType = String.Empty;
		private string _cnvcChanceSpeed = String.Empty;
		private DateTime _cndChanceDate;
		private string _cnvcComments = String.Empty;
		private string _cnvcIsSucess = String.Empty;
		private DateTime _cndSucessDate;
		private decimal _cnnSucessIncome;
		private string _cnvcProjectState = String.Empty;
		private string _cnvcOperID = String.Empty;
		private DateTime _cndOperDate;
		private string _cnvcContractNo = String.Empty;
		private string _cnvcProjectName = String.Empty;
		
		#endregion
		
		#region 构造函数




		public Project():base()
		{
		}
		
		public Project(DataRow row):base(row)
		{
		}
		
		public Project(DataTable table):base(table)
		{
		}
		
		public Project(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性




				
		/// <summary>
		/// 项目ID
		/// </summary>
		[ColumnMapping("cnnProjectID",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnProjectID
		{
			get {return _cnnProjectID;}
			set {_cnnProjectID = value;}
		}

		/// <summary>
		/// 商机名称
		/// </summary>
		[ColumnMapping("cnvcChanceName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcChanceName
		{
			get {return _cnvcChanceName;}
			set {_cnvcChanceName = value;}
		}

		/// <summary>
		/// 分公司
		/// </summary>
		[ColumnMapping("cnvcDeptID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptID
		{
			get {return _cnvcDeptID;}
			set {_cnvcDeptID = value;}
		}

		/// <summary>
		/// 客户经理
		/// </summary>
		[ColumnMapping("cnvcMgr",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMgr
		{
			get {return _cnvcMgr;}
			set {_cnvcMgr = value;}
		}

		/// <summary>
		/// 行业经理
		/// </summary>
		[ColumnMapping("cnvcTradeMgr",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcTradeMgr
		{
			get {return _cnvcTradeMgr;}
			set {_cnvcTradeMgr = value;}
		}

		/// <summary>
		/// 关联客户
		/// </summary>
		[ColumnMapping("cnnCustID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnCustID
		{
			get {return _cnnCustID;}
			set {_cnnCustID = value;}
		}

		/// <summary>
		/// 预测收入
		/// </summary>
		[ColumnMapping("cnnForecastIncome",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnForecastIncome
		{
			get {return _cnnForecastIncome;}
			set {_cnnForecastIncome = value;}
		}

		/// <summary>
		/// 商机类型
		/// </summary>
		[ColumnMapping("cnvcChanceType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcChanceType
		{
			get {return _cnvcChanceType;}
			set {_cnvcChanceType = value;}
		}

		/// <summary>
		/// 商机进展
		/// </summary>
		[ColumnMapping("cnvcChanceSpeed",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcChanceSpeed
		{
			get {return _cnvcChanceSpeed;}
			set {_cnvcChanceSpeed = value;}
		}

		/// <summary>
		/// 商机时间
		/// </summary>
		[ColumnMapping("cndChanceDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndChanceDate
		{
			get {return _cndChanceDate;}
			set {_cndChanceDate = value;}
		}

		/// <summary>
		/// 商机描述
		/// </summary>
		[ColumnMapping("cnvcComments",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcComments
		{
			get {return _cnvcComments;}
			set {_cnvcComments = value;}
		}

		/// <summary>
		/// 是否成功转化
		/// </summary>
		[ColumnMapping("cnvcIsSucess",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcIsSucess
		{
			get {return _cnvcIsSucess;}
			set {_cnvcIsSucess = value;}
		}

		/// <summary>
		/// 成功转化时间
		/// </summary>
		[ColumnMapping("cndSucessDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndSucessDate
		{
			get {return _cndSucessDate;}
			set {_cndSucessDate = value;}
		}

		/// <summary>
		/// 成功转化收入
		/// </summary>
		[ColumnMapping("cnnSucessIncome",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnSucessIncome
		{
			get {return _cnnSucessIncome;}
			set {_cnnSucessIncome = value;}
		}

		/// <summary>
		/// 项目状态
		/// </summary>
		[ColumnMapping("cnvcProjectState",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcProjectState
		{
			get {return _cnvcProjectState;}
			set {_cnvcProjectState = value;}
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
		/// 合同编号
		/// </summary>
		[ColumnMapping("cnvcContractNo",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcContractNo
		{
			get {return _cnvcContractNo;}
			set {_cnvcContractNo = value;}
		}

		/// <summary>
		/// 项目名称
		/// </summary>
		[ColumnMapping("cnvcProjectName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcProjectName
		{
			get {return _cnvcProjectName;}
			set {_cnvcProjectName = value;}
		}
		#endregion
	}	
}
