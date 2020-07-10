using OrdnanceWeb.DAL;
using OrdnanceWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrdnanceWeb.Controllers
{
    public class DeptController : Controller
    {
        // GET: Dept
        public ActionResult Dept()
        {
            return View();
        }
        public ActionResult Warehouse()
        {
            return View();
        }
        public ActionResult GetWarehouseData()
        {
            DataTable dt = new DataTable();
            UserDal userdal = new UserDal();
            dt = userdal.GetWarehouse();
            List<WarehouseModel> userlist = new List<WarehouseModel>();
            userlist = UserController.ModelConvertHelper<WarehouseModel>.ConvertToModel(dt).ToList();

            return Json(new { code = 0, count = userlist.Count, data = userlist }, JsonRequestBehavior.AllowGet);
        }
        

    }
}