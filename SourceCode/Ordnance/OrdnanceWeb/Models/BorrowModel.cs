using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdnanceWeb.Models
{
    /// <summary>
    /// 军械借用类
    /// </summary>
    public class BorrowModel
    {
        /// <summary>
        /// 借用ID
        /// </summary>
        public int Borrow_ID { get; set; }

        /// <summary>
        /// 军械ID
        /// </summary>
        public string Borrow_ArmyID { get; set; }

        /// <summary>
        /// 军械名称
        /// </summary>
        public string Borrow_ArmyName { get; set; }

        /// <summary>
        /// 申请人ID
        /// </summary>
        public string Borrow_UserID { get; set; }

        /// <summary>
        /// 申请人ID
        /// </summary>
        public string Borrow_UserName { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public string Borrow_WarehouseID { get; set; }

        /// <summary>
        /// 申请人名称
        /// </summary>
        public string Borrow_WarehouseName { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        public string Borrow_Batch { get; set; }

        
        /// <summary>
        /// 借出数量
        /// </summary>
        public int Borrow_Num { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        public string Borrow_Time { get; set; }

        /// <summary>
        /// 归还时间
        /// </summary>
        public string Borrow_ReturnTime { get; set; }

        /// <summary>
        /// 提取人
        /// </summary>
        public string Borrow_TransportName { get; set; }


        /// <summary>
        /// 提取电话
        /// </summary>
        public string Borrow_TransportPhone { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Borrow_Remarks { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Borrow_Status { get; set; }
    }
}