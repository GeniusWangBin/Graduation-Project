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
    public class RecordController : Controller
    {
        #region 巡查
        //  巡查
        public ActionResult Record(string roleid)
        {
            ViewBag.RoleID = roleid;
            return View();
        }
        //  巡查
        public ActionResult GetRecordData( string Record_UserName,string Record_Time)
        {
            DataTable dt = new DataTable();
            RecordDal recordDal = new RecordDal();
            dt = recordDal.GetRecordData("", Record_UserName, Record_Time);
            List<RecordModel> userlist = new List<RecordModel>();
            userlist = UserController.ModelConvertHelper<RecordModel>.ConvertToModel(dt).ToList();

            return Json(new { code = 0, count = userlist.Count, data = userlist }, JsonRequestBehavior.AllowGet);
        }
        

        /// <summary>
        /// /巡查记录新增界面
        /// </summary>
        /// <returns></returns>
        public ActionResult RecordAddEdit(string type, string ID)
        {
            if (type == "2")
            {
                DataTable dt = new DataTable();
                RecordDal recordDal = new RecordDal();
                dt = recordDal.GetRecordData(ID, "", "");
                List <RecordModel> userlist = new List<RecordModel>();
                userlist = UserController.ModelConvertHelper<RecordModel>.ConvertToModel(dt).ToList();

                
                ViewBag.UserID = userlist[0].Record_UserID;
                ViewBag.Remarks = userlist[0].Record_Remarks;
            }
            ViewBag.ID = ID == null ? "" : ID;
            ViewBag.Type = type == null ? "" : type; ;
            return View();
        }
        /// <summary>
        /// 巡查新增
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public ActionResult AddRecord(string Record_UserID, string Record_Remarks)
        {

            RecordDal recordDal = new RecordDal();
            bool dt = recordDal.AddRecord(Record_UserID, Record_Remarks);
            return Json(dt);

        }
        /// <summary>
        /// 巡查修改
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public ActionResult UpdateRecord(string Record_ID, string Record_UserID, string Record_Remarks)
        {

            RecordDal recordDal = new RecordDal();
            bool dt = recordDal.UpdateRecord(Record_ID, Record_UserID, Record_Remarks);
            return Json(dt);

        }
        /// <summary>
        /// 巡查修改
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public ActionResult DeleteRecord(string RecordID)
        {

            RecordDal recordDal = new RecordDal();
            bool dt = recordDal.DeleteRecord(RecordID);
            return Json(dt);

        }
        #endregion


        #region  仓库
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public ActionResult Warehouse(string roleid)
        {
            ViewBag.RoleID = roleid;
            return View();
        }
        /// <summary>
        /// 修改新增
        /// </summary>
        /// <param name="type"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult WarehouseAddEdit(string type, string ID)
        {
            if (type == "2")
            {
                DataTable dt = new DataTable();
                RecordDal recordDal = new RecordDal();
                dt = recordDal.WarhouseDatas(ID);
                List<WarehouseModel> userlist = new List<WarehouseModel>();
                userlist = UserController.ModelConvertHelper<WarehouseModel>.ConvertToModel(dt).ToList();


                ViewBag.Warehouse_UserID = userlist[0].Warehouse_UserID;
                ViewBag.Warehouse_Name = userlist[0].Warehouse_Name;
            }
            ViewBag.ID = ID == null ? "" : ID;
            ViewBag.Type = type == null ? "" : type; ;
            return View();
        }
        //WarhouseData
        /// <summary>
        /// 仓库管理（数据查询）
        /// </summary>
        /// <param name="Record_UserName"></param>
        /// <param name="Record_Time"></param>
        /// <returns></returns>
        public ActionResult WarhouseData(string Warehouse_Name)
        {
            DataTable dt = new DataTable();
            RecordDal recordDal = new RecordDal();
            dt = recordDal.WarhouseData(Warehouse_Name);
            List<WarehouseModel> userlist = new List<WarehouseModel>();
            userlist = UserController.ModelConvertHelper<WarehouseModel>.ConvertToModel(dt).ToList();

            return Json(new { code = 0, count = userlist.Count, data = userlist }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="Warehouse_UserID"></param>
        /// <param name="Warehouse_Name"></param>
        /// <returns></returns>
        public ActionResult AddWarehouse(string Warehouse_UserID, string Warehouse_Name)
        {

            string wid = getGuid();
            RecordDal recordDal = new RecordDal();
            bool dt = recordDal.AddWarehouse(Warehouse_UserID, Warehouse_Name, wid);
            return Json(dt);

        }
        /// <summary>
        /// 生成ID值
        /// </summary>
        /// <returns></returns>
        public static string getGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString().Replace("-", "").ToUpper();

        }
        /// <su修改mmary>
        ///  x修改
        /// </summary>
        /// <returns></returns>
        public ActionResult updateWarehouse(string Warehouse_ID, string Warehouse_UserID, string Warehouse_Name)
        {
            RecordDal recordDal = new RecordDal();
            bool dt = recordDal.updateWarehouse(Warehouse_ID, Warehouse_UserID, Warehouse_Name);
            return Json(dt);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Warehouse_ID"></param>
        /// <returns></returns>
        public ActionResult DeletWarhouse(string Warehouse_ID)
        {
            RecordDal recordDal = new RecordDal();
            bool dt = recordDal.DeleteWarhouse(Warehouse_ID);
            return Json(dt);
        }
        #endregion

    }
}