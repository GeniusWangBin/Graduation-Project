using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdnanceWeb.Models
{
    public class RecordModel
    {
        /// <summary>
        /// 巡查ID
        /// </summary>
        public int Record_ID { get; set; }

        /// <summary>
        /// 巡查人
        /// </summary>
        public string Record_UserID { get; set; }

        /// <summary>
        /// 巡查人
        /// </summary>
        public string Record_UserName { get; set; }

        /// <summary>
        /// 巡查时间
        /// </summary>
        public string Record_Time { get; set; }

        /// <summary>
        /// 巡查记录
        /// </summary>
        public string Record_Remarks { get; set; }
    }
}