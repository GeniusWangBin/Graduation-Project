using OrdnanceWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrdnanceWeb.DAL
{
    public class ScrapDal
    {
        /// <summary>
        /// 获取报废数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetScrapData(string UserID,string Scrap_ArmyName, string Scrap_WarehouseID, string Scrap_Time)
        {
            
            string Sql = @"SELECT [Scrap_ID]
                          ,[Scrap_ArmyID]             
                          ,[Scrap_WarehouseID],
	                      Warehouse_Name  Scrap_WarehouseName,
	                      Army_Name as Scrap_ArmyName
                          ,[Scrap_Batch]
                          ,[Scrap_Num]
                          ,[Scrap_Time]
                          ,[Scrap_Remarks]
                      FROM [dbo].[Ord_ScrapTable] OST
                       left join Ord_ArmyTable OAT on OAT.Army_ID = OST.Scrap_ArmyID
                       left join Ord_WarehouseTable OWT on OWT.Warehouse_ID = OST.[Scrap_WarehouseID] 
                       Where 1=1  ";
            string startime = DateTime.MinValue.ToString("yyyy-MM-dd");
            string endtime = DateTime.MaxValue.ToString("yyyy-MM-dd");
			if (!string.IsNullOrEmpty(UserID.Trim()))
			{
				Sql += "AND OWT.Warehouse_UserID ='" + UserID + "'";
			}
			if (!string.IsNullOrEmpty(Scrap_ArmyName))
            {
                Sql += "AND OAT.Army_Name like'%" + Scrap_ArmyName + "%'";
            }
            if (!string.IsNullOrEmpty(Scrap_WarehouseID))
            {
                Sql += "AND Scrap_WarehouseID ='" + Scrap_WarehouseID + "'";
            }
            if (!string.IsNullOrEmpty(Scrap_Time))
            {
                var time = Scrap_Time.Split('~');
                startime = DateTime.Parse(time[0]).ToString("yyyy-MM-dd");
                endtime = DateTime.Parse(time[1]).AddDays(1).ToString("yyyy-MM-dd");
            }
            Sql += "AND Scrap_Time >='" + startime + "' AND Scrap_Time <'" + endtime + "'";
            DataTable dt = DBHelper.reDs(Sql);
            return dt;
        }

        /// <summary>
        /// 根据军械id获取入库记录中的所有所在仓库        
        /// </summary>
        /// <returns></returns>
        public bool AddScrap(ScrapModel scrapModel)
        {
            string Sql = @"INSERT INTO [dbo].[Ord_ScrapTable]
           ([Scrap_ArmyID]
           ,[Scrap_WarehouseID]
           ,[Scrap_Batch]
           ,[Scrap_Num]
           ,[Scrap_Time]) values";
            string values = "( '" + scrapModel.Scrap_ArmyID + "','" + scrapModel.Scrap_WarehouseID + "','" + scrapModel.Scrap_Batch + "','" + scrapModel.Scrap_Num + "','" + scrapModel.Scrap_Time + "');";
            string  Sql2 = "Update  [dbo].[Ord_ReportTable] SET Report_ScrapNum=Report_ScrapNum+" + Convert.ToInt32(scrapModel.Scrap_Num) + ", Report_InventoryNum=Report_InventoryNum-" + Convert.ToInt32(scrapModel.Scrap_Num) + " Where  Report_ArmyID='" + scrapModel.Scrap_ArmyID + "' and  Report_WarehouseID ='" + scrapModel.Scrap_WarehouseID + "' and  Report_Batch='" + scrapModel.Scrap_Batch + "';";

            bool dt = DBHelper.ExSql(Sql + values+ Sql2);
            return dt;
        }

    }
}