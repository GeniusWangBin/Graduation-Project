using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdnanceWeb.Models
{
    public class DeptModel
    {
        public string Dept_ID { get; set; }
        public string Dept_Name { get; set; }
        public string Dept_PersonLiable { get; set; }
        public string  Dept_Phone { get; set; }
        public string Dept_CreateTime { get; set; }
    }
}