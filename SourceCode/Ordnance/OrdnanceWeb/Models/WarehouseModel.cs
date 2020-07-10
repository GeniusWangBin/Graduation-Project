using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdnanceWeb.Models
{
    public class WarehouseModel
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        public string Warehouse_ID { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string Warehouse_Name { get; set; }
        /// <summary>
        /// c仓库管理员ID
        /// </summary>
        public string Warehouse_UserID { get; set; }
        /// <summary>
        /// 仓库管理员名称
        /// </summary>
        public string User_Name { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string Warehouse_CreateTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Warehouse_Remarks { get; set; }
    }
}