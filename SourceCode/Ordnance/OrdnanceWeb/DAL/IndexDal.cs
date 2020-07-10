using OrdnanceWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrdnanceWeb.DAL
{
	public class IndexDal
	{
		#region  登录验证
		///<summary>
		///按照用户名和密码查询
		///</summary>
		public DataTable GetLoginLoggerData(string username, string password)
		{
			string sql = @"select * from Ord_UserTable OUT where User_Name='" + username + "' AND User_PassWord = '" + password + "';";

			DataTable dt = DBHelper.reDs(sql);
			return dt;
		}
		#endregion


		#region 登录首页总览
		///<summary>
		///总览信息第一行前四块
		/// </summary>
		public DataTable GetRukuData()
		{
			string sql = @"select * from Ord_ReportTable where Report_Status=3;";

			DataTable dt = DBHelper.reDs(sql);
			return dt;
		}
		///
		public DataTable GetChukuData()
		{
			string sql = @"select * from Ord_BorrowTable where Borrow_Status in (3,4) ;";

			DataTable dt = DBHelper.reDs(sql);
			return dt;
		}
		public DataTable GetBaofeiData()
		{
			string sql = @"select * from Ord_ScrapTable ;";

			DataTable dt = DBHelper.reDs(sql);
			return dt;
		}
		public DataTable GetUserData()
		{
			string sql = @"select * from Ord_UserTable;";

			DataTable dt = DBHelper.reDs(sql);
			return dt;
		}

		#endregion


		#region 首页后面四个表格 
		///<summary>
		///首页排名信息以及借永出库那四个表格的记录前十条排行榜
		/// </summary>
		/// 
		public DataTable ShouyePaiming()
		{
			string sql = @"select Borrow_ArmyID,SUM(Borrow_Num) Borrow_Num, OAT.Army_Name Borrow_ArmyName from Ord_BorrowTable OBT
                           left join  Ord_ArmyTable OAT on OAT.Army_ID=OBT.Borrow_ArmyID
                           group by Borrow_ArmyID,OAT.Army_Name;";

			DataTable dt = DBHelper.reDs(sql);
			return dt;
		}
		public DataTable ShouyeBorrow()
		{
			string sql = @"select * ,OAT.Army_Name Borrow_ArmyName from Ord_BorrowTable OBT
                          left join Ord_ArmyTable OAT on OAT.Army_ID=OBT.Borrow_ArmyID
                          order by Borrow_Time desc;";

			DataTable dt = DBHelper.reDs(sql);
			return dt;
		}

		public DataTable ShouyeRuku()
		{
						
			string sql = @"select * ,OAT.Army_Name Report_ArmyName,OWT.Warehouse_Name Report_WarehouseName  from Ord_ReportTable ORT
                          left join Ord_ArmyTable OAT on OAT.Army_ID=ORT.Report_ArmyID
                          left join Ord_WarehouseTable OWT on OWT.Warehouse_ID=ORT.Report_WarehouseID
                          order by Report_CreatTime desc;";

			DataTable dt = DBHelper.reDs(sql);
			return dt;
		}

		public DataTable ShouyeBaofei()
		{

			string sql = @"select * ,OAT.Army_Name Scrap_ArmyName,OWT.Warehouse_Name Scrap_WarehouseName  from Ord_ScrapTable OST
                          left join Ord_ArmyTable OAT on OAT.Army_ID=OST.Scrap_ArmyID
                          left join Ord_WarehouseTable OWT on OWT.Warehouse_ID=OST.Scrap_WarehouseID
                          order by Scrap_Time desc;";

			DataTable dt = DBHelper.reDs(sql);
			return dt;
		}
		#endregion




	}
}