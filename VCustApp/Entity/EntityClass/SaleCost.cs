
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   VCustApp
* �ļ���:   	SaleCost.cs
* ����:	     ֣��
* ��������:    2008-11-20
* ��������:    ���۳ɱ��� 

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
	/// **�������ƣ����۳ɱ��� ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbSaleCost")]
	public class SaleCost: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
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
		
		#region ���캯��




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
		
		#region ϵͳ��������




				
		/// <summary>
		/// �ͻ�ID
		/// </summary>
		[ColumnMapping("cnnCustID",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnCustID
		{
			get {return _cnnCustID;}
			set {_cnnCustID = value;}
		}

		/// <summary>
		/// �ͻ�����
		/// </summary>
		[ColumnMapping("cnvcCustName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCustName
		{
			get {return _cnvcCustName;}
			set {_cnvcCustName = value;}
		}

		/// <summary>
		/// ���
		/// </summary>
		[ColumnMapping("cnvcYear",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcYear
		{
			get {return _cnvcYear;}
			set {_cnvcYear = value;}
		}

		/// <summary>
		/// Ԥ�����۳ɱ�
		/// </summary>
		[ColumnMapping("cnnBudgetCost",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnBudgetCost
		{
			get {return _cnnBudgetCost;}
			set {_cnnBudgetCost = value;}
		}

		/// <summary>
		/// ʵ�����۳ɱ�
		/// </summary>
		[ColumnMapping("cnnRealSaleCost",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnRealSaleCost
		{
			get {return _cnnRealSaleCost;}
			set {_cnnRealSaleCost = value;}
		}

		/// <summary>
		/// �ɱ�����ʹ�ý���
		/// </summary>
		[ColumnMapping("cnnCostUsed",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnCostUsed
		{
			get {return _cnnCostUsed;}
			set {_cnnCostUsed = value;}
		}

		/// <summary>
		/// 1��ʹ��
		/// </summary>
		[ColumnMapping("cnnUsed1",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed1
		{
			get {return _cnnUsed1;}
			set {_cnnUsed1 = value;}
		}

		/// <summary>
		/// 2��ʹ��
		/// </summary>
		[ColumnMapping("cnnUsed2",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed2
		{
			get {return _cnnUsed2;}
			set {_cnnUsed2 = value;}
		}

		/// <summary>
		/// 3��ʹ��
		/// </summary>
		[ColumnMapping("cnnUsed3",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed3
		{
			get {return _cnnUsed3;}
			set {_cnnUsed3 = value;}
		}

		/// <summary>
		/// 4��ʹ��
		/// </summary>
		[ColumnMapping("cnnUsed4",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed4
		{
			get {return _cnnUsed4;}
			set {_cnnUsed4 = value;}
		}

		/// <summary>
		/// 5��ʹ��
		/// </summary>
		[ColumnMapping("cnnUsed5",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed5
		{
			get {return _cnnUsed5;}
			set {_cnnUsed5 = value;}
		}

		/// <summary>
		/// 6��ʹ��
		/// </summary>
		[ColumnMapping("cnnUsed6",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed6
		{
			get {return _cnnUsed6;}
			set {_cnnUsed6 = value;}
		}

		/// <summary>
		/// 7��ʹ��
		/// </summary>
		[ColumnMapping("cnnUsed7",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed7
		{
			get {return _cnnUsed7;}
			set {_cnnUsed7 = value;}
		}

		/// <summary>
		/// 8��ʹ��
		/// </summary>
		[ColumnMapping("cnnUsed8",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed8
		{
			get {return _cnnUsed8;}
			set {_cnnUsed8 = value;}
		}

		/// <summary>
		/// 9��ʹ��
		/// </summary>
		[ColumnMapping("cnnUsed9",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed9
		{
			get {return _cnnUsed9;}
			set {_cnnUsed9 = value;}
		}

		/// <summary>
		/// 10��ʹ��
		/// </summary>
		[ColumnMapping("cnnUsed10",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed10
		{
			get {return _cnnUsed10;}
			set {_cnnUsed10 = value;}
		}

		/// <summary>
		/// 11��ʹ��
		/// </summary>
		[ColumnMapping("cnnUsed11",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnUsed11
		{
			get {return _cnnUsed11;}
			set {_cnnUsed11 = value;}
		}

		/// <summary>
		/// 12��ʹ��
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
