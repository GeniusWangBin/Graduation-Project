using OrdnanceWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrdnanceWeb.DAL
{
	public class MaintainDal
	{

		#region 需要维修
		/// <summary>
		/// 获取需要维修的
		/// </summary>
		/// <returns></returns>
		/// 首次加载时只按照武器维修周期以及时间查询  
		public DataTable GetMaintainData(string UserID,string Report_ArmyName, string Warehouse)
		{
			string sql = @"select OAT.Army_Name Report_ArmyName,OAT.Army_RepairCycle Report_RepairCycle,OWT.Warehouse_Name Report_WarehouseName,* from Ord_ReportTable OST 
                                left join Ord_ArmyTable OAT on OAT.Army_ID = OST.Report_ArmyID
                                left join Ord_WarehouseTable OWT on OWT.Warehouse_ID = OST.Report_WarehouseID 
                            Where 1=1 ";
			// 执行查询时传参数执行sql 首次加载参数为空
			if (!string.IsNullOrEmpty(UserID.Trim()))
			{
				sql += "AND OWT.Warehouse_UserID ='" + UserID + "'";
			}
			if (!string.IsNullOrEmpty(Report_ArmyName))  //按照武器名字查询 不为空时执行
			{
				sql += " AND OAT.Army_Name like '%" + Report_ArmyName + "%'";
			}
			if (!string.IsNullOrEmpty(Warehouse))       //按照仓库ID查询 不为空时执行  
			{
				sql += " AND OST.Report_WarehouseID = '" + Warehouse + "'";
			}
			DataTable dt = DBHelper.reDs(sql);
			return dt;
		}
		#endregion

		#region 武器维修 
		// 武器维修时将维修状态改为0：维修中
		public bool MaintainReport(List<string> IDs)
		{
			string Sql = "";
			if (IDs != null)
			{
				for (int i = 0; i < IDs.Count; i++)
				{
					Sql += "update Ord_ReportTable set Report_MaintainStatus=0 where Report_ID='" + IDs[i] + "';";
				}
			}
			bool dt = DBHelper.ExSql(Sql);
			return dt;
		}
		#endregion



		#region 武器完毕
		//武器维修完成之后状态修改为1：正常状态
		public bool FinishReport(List<string> IDs)
		{

			string Sql = "";
			if (IDs != null)
			{
				string time = DateTime.Now.ToString("yyyy-MM-dd");
				for (int i = 0; i < IDs.Count; i++)
				{

					Sql += "update Ord_ReportTable set Report_MaintainTime = '" + time + "',Report_MaintainStatus=1 where Report_ID='" + IDs[i] + "';";
				}
			}
			bool dt = DBHelper.ExSql(Sql);
			return dt;
		}
		#endregion

		#region 维修记录的插入
		///<summary>
		///插入维修记录 哎
		/// </summary>
		public bool FinishRecord(MaintainModel maintainModel)
		{

			string Sql = "";
			if (maintainModel != null)
			{
				string time = DateTime.Now.ToString("yyyy-MM-dd");
				

					Sql = @"insert into Ord_MaintainTable (Maintain_Name,Maintain_Batch,Maintain_WarehouseID,Maintain_WarehouseName,Maintain_Num,Maintain_Time) 
                          values ('"+maintainModel.Maintain_Name+"','"+maintainModel.Maintain_Batch+"','"+maintainModel.Maintain_WarehouseID+"','"+maintainModel.Maintain_WarehouseName+"','"+maintainModel.Maintain_Num+"','"+time+"')";
				
			}
			bool dt = DBHelper.ExSql(Sql);
			return dt;
		}
		#endregion

		#region 维修记录获取
		///<summary>
		///获取维修记录 
		/// </summary>
		public DataTable GetRecord(string Maintain_Name, string Warehouse)
		{
			string sql = @"select * from Ord_MaintainTable OMT Where 1=1";
			// 执行查询时传参数执行sql 首次加载参数为空
			if (!string.IsNullOrEmpty(Maintain_Name))  //按照武器名字查询 不为空时执行
			{
				sql += " AND OMT.Maintain_Name like '%" + Maintain_Name + "%'";
			}
			if (!string.IsNullOrEmpty(Warehouse))       //按照仓库ID查询 不为空时执行  
			{
				sql += " AND OMT.Maintain_WarehouseID = '" + Warehouse + "'";
			}
			DataTable dt = DBHelper.reDs(sql);
			return dt;
		}
        #endregion
		

	}
}