
/******************************************************************** FR 1.20E *******
* 项目名称：   VCustApp
* 文件名:   	SaleCost.cs
* 作者:	     郑华
* 创建日期:    2008-11-20
* 功能描述:    销售成本表 

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
	/// **功能名称：销售成本表 实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbSaleCost")]
	public class SaleCost: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private decimal _cnnCustID;
		private string _cnvcCustName = String.Empty;
		private string _cnvcYear = String.Empty;
		private decimal _cnnBudgetCost;
		private decimal _cnnRealSaleCost;
		private decimal _cnnCostUsed;
		private decimal _cnnUsed1;
		private decimal _cnnUsed2;
		private decimal _cnnUsed3;
		private decimal _cnnUsed4;
		private decimal _cnnUsed5;
		private decimal _cnnUsed6;
		private decimal _cnnUsed7;
		private decimal _cnnUsed8;
		private decimal _cnnUsed9;
		private decimal _cnnUsed10;
		private decimal _cnnUsed11;
		private decimal _cnnUsed12;
		
		#endregion
		
		#region 构造函数




		public SaleCost():base()
		{
		}
		
		public SaleCost(DataRow row):base(row)
		{
		}
		
		public SaleCost(DataTable table):base(table)
		{
		}
		
		public SaleCost(string  strXML):base(strXML)
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
		/// 年份
		/// </summary>
		[ColumnMapping("cnvcYear",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcYear
		{
			get {return _cnvcYear;}
			set {_cnvcYear = value;}
		}

		/// <summary>
		/// 预算销售成本
		/// </summary>
		[ColumnMapping("cnnBudgetCost",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnBudgetCost
		{
			get {return _cnnBudgetCost;}
			set {_cnnBudgetCost = value;}
		}

		/// <summary>
		/// 实际销售成本
		/// </summary>
		[ColumnMapping("cnnRealSaleCost",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnRealSaleCost
		{
			get {return _cnnRealSaleCost;}
			set {_cnnRealSaleCost = value;}
		}

		/// <summary>
		/// 成本费用使用进度
		/// </summary>
		[ColumnMapping("cnnCostUsed",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnCostUsed
		{
			get {return _cnnCostUsed;}
			set {_cnnCostUsed = value;}
		}

		/// <summary>
		/// 1月使用
		/// </summary>
		[ColumnMapping("cnnUsed1",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed1
		{
			get {return _cnnUsed1;}
			set {_cnnUsed1 = value;}
		}

		/// <summary>
		/// 2月使用
		/// </summary>
		[ColumnMapping("cnnUsed2",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed2
		{
			get {return _cnnUsed2;}
			set {_cnnUsed2 = value;}
		}

		/// <summary>
		/// 3月使用
		/// </summary>
		[ColumnMapping("cnnUsed3",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed3
		{
			get {return _cnnUsed3;}
			set {_cnnUsed3 = value;}
		}

		/// <summary>
		/// 4月使用
		/// </summary>
		[ColumnMapping("cnnUsed4",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed4
		{
			get {return _cnnUsed4;}
			set {_cnnUsed4 = value;}
		}

		/// <summary>
		/// 5月使用
		/// </summary>
		[ColumnMapping("cnnUsed5",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed5
		{
			get {return _cnnUsed5;}
			set {_cnnUsed5 = value;}
		}

		/// <summary>
		/// 6月使用
		/// </summary>
		[ColumnMapping("cnnUsed6",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed6
		{
			get {return _cnnUsed6;}
			set {_cnnUsed6 = value;}
		}

		/// <summary>
		/// 7月使用
		/// </summary>
		[ColumnMapping("cnnUsed7",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed7
		{
			get {return _cnnUsed7;}
			set {_cnnUsed7 = value;}
		}

		/// <summary>
		/// 8月使用
		/// </summary>
		[ColumnMapping("cnnUsed8",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed8
		{
			get {return _cnnUsed8;}
			set {_cnnUsed8 = value;}
		}

		/// <summary>
		/// 9月使用
		/// </summary>
		[ColumnMapping("cnnUsed9",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed9
		{
			get {return _cnnUsed9;}
			set {_cnnUsed9 = value;}
		}

		/// <summary>
		/// 10月使用
		/// </summary>
		[ColumnMapping("cnnUsed10",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed10
		{
			get {return _cnnUsed10;}
			set {_cnnUsed10 = value;}
		}

		/// <summary>
		/// 11月使用
		/// </summary>
		[ColumnMapping("cnnUsed11",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed11
		{
			get {return _cnnUsed11;}
			set {_cnnUsed11 = value;}
		}

		/// <summary>
		/// 12月使用
		/// </summary>
		[ColumnMapping("cnnUsed12",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed12
		{
			get {return _cnnUsed12;}
			set {_cnnUsed12 = value;}
		}
		#endregion
	}	
}
