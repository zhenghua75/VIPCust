
/******************************************************************** FR 1.20E *******
* 项目名称：   VCustApp
* 文件名:   	AdvancePayment.cs
* 作者:	     郑华
* 创建日期:    2008-11-19
* 功能描述:    预收账款

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
	/// **功能名称：预收账款实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbAdvancePayment")]
	public class AdvancePayment: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private decimal _cnnCustID;
		private string _cnvcCustName = String.Empty;
		private decimal _cnnProjectID;
		private string _cnvcProjectName = String.Empty;
		private decimal _cnnAcctID;
		private string _cnvcAcctName = String.Empty;
		private string _cnvcMgr = String.Empty;
		private DateTime _cndPayDate;
		private string _cnvcFeeCode = String.Empty;
		private string _cnvcFeeName = String.Empty;
		private DateTime _cndFeeDate;
		private decimal _cnnPayFee;
		private decimal _cnnPrepayFee;
		private string _cnvcComments = String.Empty;
		
		#endregion
		
		#region 构造函数




		public AdvancePayment():base()
		{
		}
		
		public AdvancePayment(DataRow row):base(row)
		{
		}
		
		public AdvancePayment(DataTable table):base(table)
		{
		}
		
		public AdvancePayment(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性




				
		/// <summary>
		/// 客户ID
		/// </summary>
		[ColumnMapping("cnnCustID",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnCustID
		{
			get {return _cnnCustID;}
			set {_cnnCustID = value;}
		}

		/// <summary>
		/// 客户名称
		/// </summary>
		[ColumnMapping("cnvcCustName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCustName
		{
			get {return _cnvcCustName;}
			set {_cnvcCustName = value;}
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
		/// 项目名称
		/// </summary>
		[ColumnMapping("cnvcProjectName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcProjectName
		{
			get {return _cnvcProjectName;}
			set {_cnvcProjectName = value;}
		}

		/// <summary>
		/// 账户ID
		/// </summary>
		[ColumnMapping("cnnAcctID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnAcctID
		{
			get {return _cnnAcctID;}
			set {_cnnAcctID = value;}
		}

		/// <summary>
		/// 账户名称
		/// </summary>
		[ColumnMapping("cnvcAcctName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcAcctName
		{
			get {return _cnvcAcctName;}
			set {_cnvcAcctName = value;}
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
		/// 交款时间
		/// </summary>
		[ColumnMapping("cndPayDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndPayDate
		{
			get {return _cndPayDate;}
			set {_cndPayDate = value;}
		}

		/// <summary>
		/// 费用类型代码
		/// </summary>
		[ColumnMapping("cnvcFeeCode",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFeeCode
		{
			get {return _cnvcFeeCode;}
			set {_cnvcFeeCode = value;}
		}

		/// <summary>
		/// 费用类型名称
		/// </summary>
		[ColumnMapping("cnvcFeeName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFeeName
		{
			get {return _cnvcFeeName;}
			set {_cnvcFeeName = value;}
		}

		/// <summary>
		/// 费用计收时间
		/// </summary>
		[ColumnMapping("cndFeeDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndFeeDate
		{
			get {return _cndFeeDate;}
			set {_cndFeeDate = value;}
		}

		/// <summary>
		/// 交款金额
		/// </summary>
		[ColumnMapping("cnnPayFee",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnPayFee
		{
			get {return _cnnPayFee;}
			set {_cnnPayFee = value;}
		}

		/// <summary>
		/// 缴预存金额
		/// </summary>
		[ColumnMapping("cnnPrepayFee",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnPrepayFee
		{
			get {return _cnnPrepayFee;}
			set {_cnnPrepayFee = value;}
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
