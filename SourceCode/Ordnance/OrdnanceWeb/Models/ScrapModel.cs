using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdnanceWeb.Models
{
    /// <summary>
    /// 报废军械类
    /// </summary>
    public class ScrapModel
    { 
        /// <summary>
        /// 报废ID
        /// </summary>
        public int Scrap_ID { get; set; }


        /// <summary>
        /// 军械ID
        /// </summary>
        public string Scrap_ArmyID { get; set; }

        /// <summary>
        /// 军械名称
        /// </summary>
        public string Scrap_ArmyName { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public string Scrap_WarehouseID { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string Scrap_WarehouseName { get; set; }

        /// <summary>
        /// 报废数量
        /// </summary>
        public int Scrap_Num { get; set; }

        /// <summary>
        /// 报废批次
        /// </summary>
        public string Scrap_Batch { get; set; }


        /// <summary>
        /// 报废时间
        /// </summary>
        public string Scrap_Time { get; set; }

        
        /// <summary>
        /// 备注
        /// </summary>
        public string Scrap_Remarks { get; set; }
    }
}