using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdnanceWeb.Models
{
    /// <summary>
    /// 军械类
    /// </summary>
    public class ArmyModel
    {
        /// <summary>
        /// 军械ID
        /// </summary>
        public string Army_ID { get; set; }

        /// <summary>
        /// 军械名称
        /// </summary>
        public string Army_Name { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string Army_CreateTime { get; set; }

        /// <summary>
        /// 维护周期（月）
        /// </summary>
        public int Army_RepairCycle { get; set; }
        

    }
}