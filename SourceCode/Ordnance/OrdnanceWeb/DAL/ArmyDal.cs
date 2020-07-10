using OrdnanceWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrdnanceWeb.DAL
{
    public class ArmyDal
    {
        #region 军械列表相关操作
        /// <summary>
        /// 获取军械列表数据
        /// </summary>
        /// <param name="Army_Name"></param>
        /// <param name="Warehouse"></param>
        /// <returns></returns>
        public DataTable GetArmyData(string Army_Name)
        {
            string sql = @"select OAT.* from Ord_ArmyTable OAT  where 1=1";
            if (!string.IsNullOrEmpty(Army_Name))
            {
                sql += " AND Army_Name like '%" + Army_Name + "%'";
            }
            DataTable dt = DBHelper.reDs(sql);
            return dt;
        }

        /// <summary>
        /// 获取军械列表数据(ID)
        /// </summary>
        /// <param name="Army_Name"></param>
        /// <param name="Warehouse"></param>
        /// <returns></returns>
        public DataTable GetArmyDataByID(string ID)
        {
            string sql = @"select OAT.* from Ord_ArmyTable OAT  where   Army_ID = '" + ID + "'";
            DataTable dt = DBHelper.reDs(sql);
            return dt;
        }
        
        /// <summary>
        /// 数据删除
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public bool DeleteArmy(string DelID)
        {
            string  Sql = "delete Ord_ArmyTable where Army_ID='" + DelID + "';";
            bool dt = DBHelper.ExSql(Sql);
            return dt;
        }
          

        /// <summary>
        /// 数据新增
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public bool AddArmy(string Army_Name, string Army_RepairCycle)
        {
            string Sql = @"INSERT INTO [dbo].[Ord_ArmyTable]([Army_ID],[Army_Name],[Army_CreateTime],[Army_RepairCycle])VALUES";
            string values = "( '"+ getGuid() + "','" + Army_Name + "' , '" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + Army_RepairCycle + "')";
            bool dt = DBHelper.ExSql(Sql+values);
            return dt;
        }

        /// <summary>
        /// 数据修改
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public bool UpdateArmy(string Army_Name, string Army_ID, string Army_RepairCycle)
        {
            string Sql = @"UPDATE [dbo].[Ord_ArmyTable] SET [Army_Name] =  '"+Army_Name+"'  ,[Army_RepairCycle] = "+Army_RepairCycle+" WHERE Army_ID = '"+Army_ID+"'";
          
            bool dt = DBHelper.ExSql(Sql );
            return dt;
        }



        /// <summary>
        /// 获取军械数量
        /// </summary>
        /// <param name="Army_Name"></param>
        /// <param name="Warehouse"></param>
        /// <returns></returns>
        public int GetArmyCount(string Army_Name)
        {
            string sql = @"select OAT.* from Ord_ArmyTable OAT  where 1=1";
            if (!string.IsNullOrEmpty(Army_Name))
            {
                sql += " AND Army_Name = '" + Army_Name + "'";
            }
            else
            {
                sql += " AND Army_Name = ''";
            }
            int dt = DBHelper.DataCount(sql);
            return dt;
        }

        /// <summary>
        /// 获取符合条件的采购入库数据数量
        /// </summary>
        /// <param name="Army_Name"></param>
        /// <param name="Warehouse"></param>
        /// <returns></returns>
        public int GetReportCount(string Army_ID)
        {
            if (string.IsNullOrEmpty(Army_ID))
            {
                Army_ID = "";
            }
            string sql = @"select OAT.* from Ord_ReportTable OAT  where Report_ArmyID='"+ Army_ID + "'";
            int dt = DBHelper.DataCount(sql);
            return dt;
        }

        /// <summary>
        /// 采购入库信息表查询列表（查询符合批次名称的数量）
        /// </summary>
        /// <param name="Army_Name"></param>
        /// <param name="Warehouse"></param>
        /// <returns></returns>
        public int GetReportBatchCount(string Army_Batch)
        {
            if (string.IsNullOrEmpty(Army_Batch))
            {
                Army_Batch = "";
            }
            string sql = @"select OAT.* from Ord_ReportTable OAT  where Report_Batch='" + Army_Batch + "'";
            int dt = DBHelper.DataCount(sql);
            return dt;
        }
        
        /// <summary>
        /// 获得32位字符长度的ID
        /// </summary>
        /// <param name="information">获得32位字符长度的ID</param>
        public static string getGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString().Replace("-", "").ToUpper();

        }
        #endregion

        #region 采购入库相关操作
        /// <summary>
        /// 获取采购入库数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetReportData(string UserID, string Report_ArmyName, string Report_UserName, string Warehouse, string Report_CreatTime, string Report_Status)
        {
            string Sql = @"select *,OAT.Army_Name Report_ArmyName,OWT.Warehouse_Name Report_WarehouseName,ORUT.User_Name Report_UserName from Ord_ReportTable OST 
	                            Left Join Ord_UserTable ORUT on ORUT.User_ID=OST.Report_UserID
                                left join Ord_ArmyTable OAT on OAT.Army_ID = OST.Report_ArmyID
                                left join Ord_WarehouseTable OWT on OWT.Warehouse_ID = OST.Report_WarehouseID   Where 1=1 ";
            string startime = DateTime.MinValue.ToString("yyyy-MM-dd");
            string endtime = DateTime.MaxValue.ToString("yyyy-MM-dd");
			if (!string.IsNullOrEmpty(UserID.Trim()))
			{
				Sql += "AND OWT.Warehouse_UserID ='" + UserID + "'";
			}
			if (!string.IsNullOrEmpty(Report_ArmyName))
            {
                Sql += "AND OAT.Army_Name like'%"+ Report_ArmyName + "%'";
            }
            if (!string.IsNullOrEmpty(Report_UserName))
            {
                Sql += "AND ORUT.User_Name like'%" + Report_UserName + "%'";
            }
            if (!string.IsNullOrEmpty(Warehouse))
            {
                Sql += "AND Report_WarehouseID ='" + Warehouse + "'";
            }
            if (!string.IsNullOrEmpty(Report_Status))
            {
                Sql += "AND Report_Status =" + Report_Status + "";
            }
            if (!string.IsNullOrEmpty(Report_CreatTime))
            {
                var time = Report_CreatTime.Split('~');
                startime = DateTime.Parse(time[0]).ToString("yyyy-MM-dd");
                endtime =DateTime.Parse(time[1]).AddDays(1).ToString("yyyy-MM-dd");
            }
            Sql += "AND OST.Report_CreatTime >='" + startime + "' AND OST.Report_CreatTime <'" + endtime + "'";
            DataTable dt = DBHelper.reDs(Sql);
            return dt;
        }
        /// <summary>
        /// 获取采购入库数据ByID
        /// </summary>
        /// <returns></returns>
        public DataTable GetReportDataByID(string ID,string Army_ID, string Army_Name, string Report_Status)
        {
            string Sql = @"select *,OAT.Army_Name Report_ArmyName,OWT.Warehouse_Name Report_WarehouseName,ORUT.User_Name Report_UserName from Ord_ReportTable OST 
	                            Left Join Ord_UserTable ORUT on ORUT.User_ID=OST.Report_UserID
                                left join Ord_ArmyTable OAT on OAT.Army_ID = OST.Report_ArmyID
                                left join Ord_WarehouseTable OWT on OWT.Warehouse_ID = OST.Report_WarehouseID 
                            Where 1=1  ";
            
             if (!string.IsNullOrEmpty(ID))
            {
                Sql += "AND OST.Report_ID ='" + ID + "'";
            }
            if (!string.IsNullOrEmpty(Army_ID))
            {
                Sql += "AND OST.Report_ArmyID ='" + Army_ID + "'";
            }
            if (!string.IsNullOrEmpty(Army_Name))
            {
                Sql += "AND OAT.Army_Name ='" + Army_Name + "'";
            }

            if (!string.IsNullOrEmpty(Report_Status))
            {
                Sql += "AND Report_Status =" + Report_Status + "";
            }
           
            DataTable dt = DBHelper.reDs(Sql);
            return dt;
        }
        /// <summary>
        /// 采购入库数据删除
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public bool DeleteReport(List<string> IDs)
        {
            string Sql = "";
            if (IDs != null)
            {
                for (int i = 0; i < IDs.Count; i++)
                {
                    Sql += "delete Ord_ReportTable where Report_ID='" + IDs[0] + "';";
                }
            }
            bool dt = DBHelper.ExSql(Sql);
            return dt;
        }

        /// <summary>
        /// 采购入库新增
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public bool AddReport(ReportModel reportModel)
        {
            string Sql = @"INSERT INTO [dbo].[Ord_ReportTable]
           ([Report_ArmyID]
           ,[Report_WarehouseID]
           ,[Report_Batch]
           ,[Report_Num]
           ,[Report_UserID]
           ,[Report_Status]
           ,[Report_CreatTime]
           ,[Report_Remarks]
           ,[Report_InventoryNum]
           ,[Report_BorrowNum]
           ,[Report_ScrapNum]
           ,[Report_TransportName]
           ,[Report_TransportPhone],Report_MaintainTime,Report_MaintainStatus)
     VALUES";
            string values="( '"+ reportModel.Report_ArmyID + "','" + reportModel.Report_WarehouseID + "','" + reportModel.Report_Batch + "','" + reportModel.Report_Num + "','" + reportModel.Report_UserID + "'," + reportModel.Report_Status + ",'" + reportModel.Report_CreatTime + "','" + reportModel.Report_Remarks + "'," + reportModel.Report_InventoryNum + "," + reportModel.Report_BorrowNum + "," + reportModel.Report_ScrapNum + ",'" + reportModel.Report_TransportName + "','" + reportModel.Report_TransportPhone+ "','" + reportModel.Report_MaintainTime + "'," + reportModel.Report_MaintainStatus + ")";
            bool dt = DBHelper.ExSql(Sql+values);
            return dt;
        }
        
        /// <summary>
        /// 采购入库修改
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public bool UpdateReportData(ReportModel reportmodel)
        {
            string Sql = @"Update  [dbo].[Ord_ReportTable] SET Report_ArmyID='" + reportmodel.Report_ArmyID + "', Report_WarehouseID='" + reportmodel.Report_WarehouseID + "', Report_UserID='" + reportmodel.Report_UserID + "', Report_Batch='" + reportmodel.Report_Batch + "', Report_Num=" + reportmodel.Report_Num + ", Report_TransportName='" + reportmodel.Report_TransportName + "', Report_TransportPhone='" + reportmodel.Report_TransportPhone + "' Where  Report_ID=" + reportmodel.Report_ID + ";";
            bool dt = DBHelper.ExSql(Sql);
            return dt;
        }
        /// <summary>
        /// 采购入库修改
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public bool UpdateReport( string IDs, string state)
        {
            string Sql = @"Update  [dbo].[Ord_ReportTable] SET Report_Status="+ state + " Where  Report_ID="+ IDs + ";";
            bool dt = DBHelper.ExSql(Sql);
            return dt;
        }

        #endregion

        #region 借用
        /// <summary>
        /// 获取借出数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetBorrowData(string UserID,string Borrow_ArmyName, string Borrow_UserName,string Borrow_WarehouseID, string Borrow_CreatTime, string Borrow_Status)
        {
            string Sql = @"select *,OAT.Army_Name Borrow_ArmyName,OWT.Warehouse_Name Borrow_WarehouseName,ORUT.User_Name Borrow_UserName 
                                from Ord_BorrowTable OST 
	                            Left Join Ord_UserTable ORUT on ORUT.User_ID=OST.Borrow_UserID
                                left join Ord_ArmyTable OAT on OAT.Army_ID = OST.Borrow_ArmyID
                                left join Ord_WarehouseTable OWT on OWT.Warehouse_ID = OST.Borrow_WarehouseID  
                            Where 1=1  ";
            string startime = DateTime.MinValue.ToString("yyyy-MM-dd");
            string endtime = DateTime.MaxValue.ToString("yyyy-MM-dd");
			if (!string.IsNullOrEmpty(UserID.Trim()))
			{
				Sql += "AND OWT.Warehouse_UserID ='" + UserID + "'";
			}
			if (!string.IsNullOrEmpty(Borrow_ArmyName))
            {
                Sql += "AND OAT.Army_Name like'%" + Borrow_ArmyName + "%'";
            }
            if (!string.IsNullOrEmpty(Borrow_UserName))
            {
                Sql += "AND ORUT.User_Name like'%" + Borrow_UserName + "%'";
            }
            if (!string.IsNullOrEmpty(Borrow_WarehouseID))
            {
                Sql += "AND Borrow_WarehouseID ='" + Borrow_WarehouseID + "'";
            }
            if (!string.IsNullOrEmpty(Borrow_Status))
            {
                Sql += "AND Borrow_Status =" + Borrow_Status + "";
            }
            if (!string.IsNullOrEmpty(Borrow_CreatTime))
            {
                var time = Borrow_CreatTime.Split('~');
                startime = DateTime.Parse(time[0]).ToString("yyyy-MM-dd");
                endtime = DateTime.Parse(time[1]).AddDays(1).ToString("yyyy-MM-dd");
            }
            Sql += "AND OST.Borrow_Time >='" + startime + "' AND OST.Borrow_Time <'" + endtime + "'";
            DataTable dt = DBHelper.reDs(Sql);
            return dt;
        }
        /// <summary>
        /// 根据军械id获取入库记录中的所有所在仓库        
        /// </summary>
        /// <returns></returns>
        public bool AddBorrow(BorrowModel borrowModel)
        {
            string Sql = @"INSERT INTO [dbo].[Ord_BorrowTable]
           ([Borrow_ArmyID]
           ,[Borrow_WarehouseID]
           ,[Borrow_Batch]
           ,[Borrow_UserID]
           ,[Borrow_Num]
           ,[Borrow_Status]
           ,[Borrow_Time]
           ,[Borrow_TransportName]
           ,[Borrow_TransportPhone]) values";
            string values = "( '" + borrowModel.Borrow_ArmyID + "','" + borrowModel.Borrow_WarehouseID + "','" + borrowModel.Borrow_Batch + "','" + borrowModel.Borrow_UserID + "','" + borrowModel.Borrow_Num + "'," + borrowModel.Borrow_Status + ",'" + borrowModel.Borrow_Time + "','"+borrowModel.Borrow_TransportName + "','"+borrowModel.Borrow_TransportPhone+"')";
            bool dt = DBHelper.ExSql(Sql + values);
            return dt;
        }
        /// <summary>
        /// 采购入库新增
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public bool  UpdateBorrow(string IDs, string state, string Borrow_Num, string armyid, string WarehouseID, string Batch)
        {
            if (string.IsNullOrEmpty(Borrow_Num))
            {
                Borrow_Num = "0";
            }
            string Sql = "";
            if (state == "4")
            {
                Sql = @"Update  [dbo].[Ord_BorrowTable] SET Borrow_Status=" + state + " ,Borrow_ReturnTime='"+DateTime.Now.ToString("yyyy-MM-dd")+"'  Where  Borrow_ID=" + IDs + ";";
                Sql += "Update  [dbo].[Ord_ReportTable] SET Report_BorrowNum=Report_BorrowNum-" + Convert.ToInt32(Borrow_Num) + ", Report_InventoryNum=Report_InventoryNum+" + Convert.ToInt32(Borrow_Num) + " Where  Report_ArmyID='" + armyid + "' and  Report_WarehouseID ='" + WarehouseID + "' and  Report_Batch='" + Batch + "';";
            }
            else
            {
                Sql = @"Update  [dbo].[Ord_BorrowTable] SET Borrow_Status=" + state + " Where  Borrow_ID=" + IDs + ";";
            }
            if (state == "1")
            {
                Sql += "Update  [dbo].[Ord_ReportTable] SET Report_BorrowNum=Report_BorrowNum+" + Convert.ToInt32(Borrow_Num) + ", Report_InventoryNum=Report_InventoryNum-" + Convert.ToInt32(Borrow_Num) + " Where  Report_ArmyID='" + armyid + "' and  Report_WarehouseID ='" + WarehouseID + "' and  Report_Batch='" + Batch + "';";
            }
            bool dt = DBHelper.ExSql(Sql);
            return dt;
        }



         #endregion




        /// <summary>
        /// 获取仓库数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetWarehouseData( string Warehouse_Name)
        {
            string Sql = @"select *
                            from Ord_WarehouseTable";
            DataTable dt = DBHelper.reDs(Sql);
            return dt;
        }
        /// <summary>
        /// 获取登录信息数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetLoginLoggerData(string Login_UserName, string Login_Time)
        {
            string Sql = @"select *
                            from Ord_LoginTable";
            DataTable dt = DBHelper.reDs(Sql);
            return dt;
        }

        /// <summary>
        /// 采购入库数据删除
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public bool DeleteBorrow(List<string> IDs)
        {
            string Sql = "";
            if (IDs != null)
            {
                for (int i = 0; i < IDs.Count; i++)
                {
                    Sql += "delete Ord_BorrowTable where Borrow_ID='" + IDs[0] + "';";
                }
            }
            bool dt = DBHelper.ExSql(Sql);
            return dt;
        }

    }
}