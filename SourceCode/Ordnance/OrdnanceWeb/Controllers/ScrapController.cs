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
    public class ScrapController : Controller
    {
        #region 武器报废

        /// <summary>
        /// 武器报废界面
        /// </summary>
        public ActionResult Scrap(string roleid,string Userid)
        {
            ViewBag.RoleID = roleid;
			ViewBag.UserID = Userid;
            return View();
        }
        /// <summary>
        /// 武器修改编辑界面
        /// </summary>
        /// <returns></returns>
        public ActionResult ScrapAddEdit(string type, string ID)
        {
            ViewBag.ID = ID == null ? "" : ID;
            ViewBag.Type = type == null ? "" : type; ;
            return View();
        }

        /// <summary>
        /// 获取武器报废数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetScrapData(string UserID,string Scrap_ArmyName, string Scrap_WarehouseID, string Scrap_Time)
        {
            DataTable dt = new DataTable();
            ScrapDal scrapDal = new ScrapDal();
            dt = scrapDal.GetScrapData(UserID , Scrap_ArmyName, Scrap_WarehouseID, Scrap_Time);
            List<ScrapModel> userlist = new List<ScrapModel>();
            userlist = UserController.ModelConvertHelper<ScrapModel>.ConvertToModel(dt).ToList();

            return Json(new { code = 0, count = userlist.Count, data = userlist }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public ActionResult AddScrap(ScrapModel scrapModel)
        {
            scrapModel.Scrap_Time = DateTime.Now.ToString("yyyy-MM-dd");

            ScrapDal armyDal = new ScrapDal();
            bool dt = armyDal.AddScrap(scrapModel);
            return Json(dt);

        }
        #endregion
    }
}