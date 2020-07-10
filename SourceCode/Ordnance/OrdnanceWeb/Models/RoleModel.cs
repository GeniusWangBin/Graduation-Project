using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdnanceWeb.Models
{
    public class RoleModel
    {
        public string Role_ID { get; set; }
        public string Role_Name { get; set; }
        public string Role_CreateTime { get; set; }
        public int Role_Status { get; set; }
    }
}