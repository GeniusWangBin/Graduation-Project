using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdnanceWeb.Models
{
    public class LoginModel
    { 
        /// <summary>
       /// 登录ID
       /// </summary>
        public int Login_ID { get; set; }

        /// <summary>
        /// 登录人
        /// </summary>
        public string Login_UserID { get; set; }

        /// <summary>
        /// 登录姓名
        /// </summary>
        public string Login_UserName { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public string Login_Time { get; set; }
    }
}