using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdnanceWeb.Models
{
    /// <summary>
    /// 军械入库类
    /// </summary>
    public class ReportModel
    {
        /// <summary>
        /// 入库ID
        /// </summary>
        public int Report_ID { get; set; }

        /// <summary>
        /// 军械ID
        /// </summary>
        public string Report_ArmyID { get; set; }

        /// <summary>
        /// 军械名称
        /// </summary>
        public string Report_ArmyName { get; set; }

        /// <summary>
        /// 申请人ID
        /// </summary>
        public string Report_UserID { get; set; }

        /// <summary>
        /// 申请人姓名
        /// </summary>
        public string Report_UserName { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public string Report_WarehouseID { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string Report_WarehouseName { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        public int Report_Num { get; set; }

        /// <summary>
        /// 入库批次
        /// </summary>
        public string Report_Batch { get; set; }
        

        /// <summary>
        /// 申请时间
        /// </summary>
        public string Report_CreatTime { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Report_Status { get; set; }

        /// <summary>
        /// 在库数量
        /// </summary>
        public int Report_InventoryNum { get; set; }

        /// <summary>
        /// 借用数量
        /// </summary>
        public int Report_BorrowNum { get; set; }

        /// <summary>
        /// 报废数量
        /// </summary>
        public int Report_ScrapNum { get; set; }

        /// <summary>
        /// 运送人员姓名
        /// </summary>
        public string Report_TransportName { get; set; }

        /// <summary>
        /// 运送人员联系方式
        /// </summary>
        public string Report_TransportPhone { get; set; }

        /// <summary>
        /// 运送人员联系方式
        /// </summary>
        public string Report_Remarks { get; set; }

        /// <summary>
        /// 军械上次维护时间
        /// </summary>
        public string Report_MaintainTime { get; set; }

        /// <summary>
        /// 军械状态
        /// </summary>
        public int Report_MaintainStatus { get; set; }

        /// <summary>
        /// 军械维护周期
        /// </summary>
        public int Report_RepairCycle { get; set; }
        
    }
}