using OrdnanceWeb.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrdnanceWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Home(string name,string userid,string roleid)
        {
            ViewBag.UserName = name;
            ViewBag.UserID = userid;
            ViewBag.RoleID = roleid;
            return View();
        }
        public ActionResult HomeChart(string name)
        {
            DataTable dt = new DataTable();
            HomeDal armyDal = new HomeDal();
            dt = armyDal.GetHomeChartData();
            List<string> data = new List<string>();
            List<string> seriesRuku = new List<string>();
            List<string> seriesJEku = new List<string>();
            List<string> seriesBF = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data.Add(dt.Rows[i]["Army_Name"].ToString());
                seriesRuku.Add(dt.Rows[i]["ReportNum"].ToString());
                seriesJEku.Add(dt.Rows[i]["BorrowNum"].ToString());
                seriesBF.Add(dt.Rows[i]["ScrapNum"].ToString());
            }
            return Json(new { data =data , seriesRuku = seriesRuku, seriesJEku= seriesJEku , seriesBF = seriesBF },JsonRequestBehavior.AllowGet);
        }
        
    }
}