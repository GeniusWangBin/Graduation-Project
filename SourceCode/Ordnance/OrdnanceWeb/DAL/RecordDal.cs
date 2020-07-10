using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrdnanceWeb.DAL
{
    public class RecordDal
    {

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetRecordData(string ID, string Record_UserName, string Record_Time)
        {
            string Sql = @"SELECT [Record_ID]
                  ,[Record_UserID]
                  ,[Record_Time],
	              User_Name Record_UserName
                  ,[Record_Remarks]
              FROM [dbo].[Ord_RecordTable] ORT
              left join Ord_UserTable OUT on ORT.[Record_UserID]=OUT.User_ID Where 1=1 ";
            string startime = DateTime.MinValue.ToString("yyyy-MM-dd");
            string endtime = DateTime.MaxValue.ToString("yyyy-MM-dd");
            if (!string.IsNullOrEmpty(ID))
            {
                Sql += "AND Record_ID ='" + ID + "'";
            }
            if (!string.IsNullOrEmpty(Record_UserName))
            {
                Sql += "AND User_Name like'%" + Record_UserName + "%'";
            }
            if (!string.IsNullOrEmpty(Record_Time))
            {
                var time = Record_Time.Split('~');
                startime = DateTime.Parse(time[0]).ToString("yyyy-MM-dd");
                endtime = DateTime.Parse(time[1]).AddDays(1).ToString("yyyy-MM-dd");
            }
            Sql += "AND Record_Time >='" + startime + "' AND Record_Time <'" + endtime + "'";
            DataTable dt = DBHelper.reDs(Sql);
            return dt;
        }
        /// <summary>
        /// 新增巡查
        /// </summary>
        /// <param name="Record_ArmyID"></param>
        /// <param name="Record_Remarks"></param>
        /// <returns></returns>
        public bool AddRecord(string Record_UserID, string Record_Remarks)
        {

            string SQL = @"INSERT INTO [dbo].[Ord_RecordTable]([Record_UserID],[Record_Time],[Record_Remarks]) VALUES ('"+ Record_UserID + "','"+DateTime.Now.ToString("yyyy-MM-dd")+"','"+Record_Remarks+"')";
            bool dt = DBHelper.ExSql(SQL);
            return dt;

        }
        /// <summary>
        /// 修改巡查
        /// </summary>
        /// <returns></returns>
        public bool UpdateRecord(string Record_ID, string Record_UserID, string Record_Remarks)
        {
            string Sql = @"Update  [dbo].[Ord_RecordTable] SET Record_UserID=" + Record_UserID + ",Record_Remarks='"+ Record_Remarks + "' Where  Record_ID=" + Record_ID + ";";
            bool dt = DBHelper.ExSql(Sql);
            return dt;
        }

        /// <summary>
        /// 巡查数据删除
        /// </summary>
        /// <returns></returns>
        public bool DeleteRecord(string RecordID)
        {
            string Sql = "delete Ord_RecordTable where Record_ID='" + RecordID + "';";
            bool dt = DBHelper.ExSql(Sql);
            return dt;
        }
        #region   仓库
        /// <summary>
        /// 仓库管理查询
        /// </summary>
        /// <param name="Warehouse_Name">仓库名称</param>
        /// <returns></returns>
        public DataTable WarhouseData(string Warehouse_Name)
        {
            string Sql = @"select  a.*,b.User_Name  from Ord_WarehouseTable a 
            left join Ord_UserTable b  on a.Warehouse_UserID=b.User_ID  Where 1=1 ";

            if (!string.IsNullOrEmpty(Warehouse_Name))
            {
                Sql += "AND a.Warehouse_Name like'%" + Warehouse_Name + "%'";
            }
            DataTable dt = DBHelper.reDs(Sql);
            return dt;
        }
        /// <summary>
        /// 仓库管理新增
        /// </summary>
        /// <param name="Warehouse_UserID"></param>
        /// <param name="Warehouse_Name"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        public bool AddWarehouse(string Warehouse_UserID, string Warehouse_Name, string wid)
        {

            string SQL = @"INSERT INTO Ord_WarehouseTable(Warehouse_ID,Warehouse_Name,Warehouse_UserID,Warehouse_CreateTime) 
            VALUES ('" + wid + "','" + Warehouse_Name + "','" + Warehouse_UserID + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
            bool dt = DBHelper.ExSql(SQL);
            return dt;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataTable WarhouseDatas(string ID)
        {
            string Sql = @"select  a.*,b.User_Name  from Ord_WarehouseTable a 
            left join Ord_UserTable b  on a.Warehouse_UserID=b.User_ID  Where 1=1 ";

            if (!string.IsNullOrEmpty(ID))
            {
                Sql += "AND a.Warehouse_ID ='" + ID + "'";
            }
            DataTable dt = DBHelper.reDs(Sql);
            return dt;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Warehouse_ID"></param>
        /// <param name="Warehouse_UserID"></param>
        /// <param name="Warehouse_Name"></param>
        /// <returns></returns>
        public bool updateWarehouse(string Warehouse_ID, string Warehouse_UserID, string Warehouse_Name)
        {
            string Sql = @"Update  [dbo].[Ord_WarehouseTable] 
            SET Warehouse_UserID=" + Warehouse_UserID + ",Warehouse_Name='" + Warehouse_Name + "' Where  Warehouse_ID='" + Warehouse_ID + "';";
            bool dt = DBHelper.ExSql(Sql);
            return dt;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Warehouse_ID"></param>
        /// <returns></returns>
        public bool DeleteWarhouse(string Warehouse_ID)
        {
            string Sql = "delete Ord_WarehouseTable where Warehouse_ID='" + Warehouse_ID + "';";
            bool dt = DBHelper.ExSql(Sql);
            return dt;
        }
        #endregion
    }
}