using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdnanceWeb.Models
{
    public class UserModel
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string User_ID { get; set; }
        
        /// <summary>
        /// 用户名称
        /// </summary>
        public string User_Name { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string User_PassWord { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public string Role_ID { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public string Role_Name { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public int User_Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string User_CreateTime { get; set; }

    }
}