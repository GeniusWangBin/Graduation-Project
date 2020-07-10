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
    public class ArmyController : Controller
    {
        #region 武器列表界面
        /// <summary>
        /// /武器列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Army( string roleid)
        {
            ViewBag.RoleID = roleid;
            return View();
        }
        /// <summary>
        /// /武器新增界面
        /// </summary>
        /// <returns></returns>
        public ActionResult ArmyAddEdit(string type, string ID)
        {
            if (type == "2")
            {
                DataTable dt = new DataTable();
                ArmyDal armyDal = new ArmyDal();
                dt = armyDal.GetArmyDataByID(ID);
                List<ArmyModel> userlist = new List<ArmyModel>();
                userlist = UserController.ModelConvertHelper<ArmyModel>.ConvertToModel(dt).ToList();
              
                ViewBag.ArmyName = userlist[0].Army_Name;
                ViewBag.ArmyRepairCycle = userlist[0].Army_RepairCycle;
            }
            ViewBag.ArmyID = ID==null? "":ID;   //只有在viewbag的情况下才能传值 也是传值
            ViewBag.Type = type == null ? "" : type; ;
            return View();
        }

        /// <summary>
        /// /军械数据
        /// </summary>
        /// <returns></returns>
        public ActionResult ReportMainCal()
        {
            return View();
        }
        

        /// <summary>
        /// /武器列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetArmyData(string Army_Name)
        {
            DataTable dt = new DataTable();
            ArmyDal armyDal = new ArmyDal();
            dt = armyDal.GetArmyData(Army_Name);
            List<ArmyModel> userlist = new List<ArmyModel>();
            userlist = UserController.ModelConvertHelper<ArmyModel>.ConvertToModel(dt).ToList();

            return Json(new { code = 0, count = userlist.Count, data = userlist }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 采购入库信息表查询列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetReportCount(string Army_ID)
        {
            ArmyDal armyDal = new ArmyDal();
            int dt = armyDal.GetReportCount(Army_ID);
            

            return Json(dt, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 采购入库信息表查询列表（查询符合批次名称的数量）
        /// </summary>
        /// <returns></returns>
        public ActionResult GetReportBatchCount(string Army_Batch)
        {
            ArmyDal armyDal = new ArmyDal();
            int dt = armyDal.GetReportBatchCount(Army_Batch);


            return Json(dt, JsonRequestBehavior.AllowGet);
        }
        
        /// <summary>
        /// 军械删除
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public ActionResult DeleteArmy(string DelID)
        {

            ArmyDal armyDal = new ArmyDal();
            bool dt = armyDal.DeleteArmy(DelID);
            return Json(dt);

        }

        /// <summary>
        /// 军械新增
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public ActionResult AddArmy(string Army_Name,string Army_RepairCycle)
        {

            ArmyDal armyDal = new ArmyDal();
            bool dt = armyDal.AddArmy(Army_Name, Army_RepairCycle);
            return Json(dt);

        }

        /// <summary>
        /// 军械修改
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public ActionResult UpdateArmy(string Army_Name, string Army_ID, string Army_RepairCycle)
        {

            ArmyDal armyDal = new ArmyDal();
            bool dt = armyDal.UpdateArmy( Army_Name,  Army_ID,  Army_RepairCycle);
            return Json(dt);

        }
        
        /// <summary>
        /// 某武器列表数量查询
        /// </summary>
        /// <returns></returns>
        public ActionResult GetArmyCount(string Army_Name)
        {
            ArmyDal armyDal = new ArmyDal();
            int dt = armyDal.GetArmyCount(Army_Name);
         

            return Json(dt, JsonRequestBehavior.AllowGet);
        }

        

        #endregion

        #region 武器借用
        /// <summary>
        /// 武器借用界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Borrow(string roleid,string Userid)
        {
            ViewBag.RoleID = roleid;
			ViewBag.UserID = Userid;
            return View();
        }
        /// <summary>
        /// 武器修改编辑界面
        /// </summary>
        /// <returns></returns>
        public ActionResult BorrowAddEdit(string type, string ID)
        {
            if (type == "2")
            {
                //DataTable dt = new DataTable();
                //ArmyDal armyDal = new ArmyDal();
                //dt = armyDal.GetArmyDataByID(ID);
                //List<ArmyModel> userlist = new List<ArmyModel>();
                //userlist = UserController.ModelConvertHelper<ArmyModel>.ConvertToModel(dt).ToList();

                //ViewBag.ArmyName = userlist[0].Army_Name;
                //ViewBag.ArmyRepairCycle = userlist[0].Army_RepairCycle;
            }
            ViewBag.ID = ID == null ? "" : ID;
            ViewBag.Type = type == null ? "" : type; ;
            return View();
        }
        

        /// <summary>
        /// 武器借用数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetBorrowData(string UserID,string Borrow_ArmyName, string Borrow_UserName, string Borrow_WarehouseID, string Borrow_CreatTime, string Borrow_Status)
        {
            DataTable dt = new DataTable();
            ArmyDal armyDal = new ArmyDal();
            dt = armyDal.GetBorrowData(UserID, Borrow_ArmyName,  Borrow_UserName, Borrow_WarehouseID, Borrow_CreatTime,  Borrow_Status);
            List<BorrowModel> userlist = new List<BorrowModel>();
            userlist = UserController.ModelConvertHelper<BorrowModel>.ConvertToModel(dt).ToList();

            return Json(new { code = 0, count = userlist.Count, data = userlist }, JsonRequestBehavior.AllowGet);
        }

        /// 根据武器id获取入库数据
        /// </summary>
        /// <returns></returns>
        public List<ReportModel> GetReportDataByReport(string Army_ID,string Army_Name)
        {
            DataTable dt = new DataTable();
            ArmyDal armyDal = new ArmyDal();
            dt = armyDal.GetReportDataByID("",Army_ID, Army_Name, "3");
            List<ReportModel> userlist = new List<ReportModel>();
            userlist = UserController.ModelConvertHelper<ReportModel>.ConvertToModel(dt).ToList();

            return userlist;
        }


        /// <summary>
        /// 根据武器id获取武器的仓库
        /// </summary>
        /// <returns></returns>
        public ActionResult GetWarehouseByReport(string Army_ID)
        {
            List<ReportModel> reportModel = GetReportDataByReport(Army_ID, "");
            var newlist = reportModel.Select(a => new { Borrow_WarehouseName = a.Report_WarehouseName, Borrow_WarehouseID = a.Report_WarehouseID }).GroupBy(a => new { a.Borrow_WarehouseName ,a.Borrow_WarehouseID }).ToList();
            List<BorrowModel> borrowlist = new List<BorrowModel>();
            foreach (var item in newlist)
            {
                BorrowModel borrowmodel = new BorrowModel();
                borrowmodel.Borrow_WarehouseID = item.Key.Borrow_WarehouseID;
                borrowmodel.Borrow_WarehouseName = item.Key.Borrow_WarehouseName;
                borrowlist.Add(borrowmodel);
            }
            return Json(borrowlist, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 根据武器和仓库查询批次数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetBatchByReport(string Army_Name,string WarehouseID)
        {
            List<ReportModel> reportModel = GetReportDataByReport("", Army_Name);
            var newlist = reportModel.Where(a=>a.Report_WarehouseID== WarehouseID).Select(a=> new { Borrow_Batch=a.Report_Batch });

            return Json(newlist, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据武器和仓库查询批次数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCountByReport(string Army_Name, string WarehouseName,string Batch)
        {
            int armyCount = 0;
            List<ReportModel> reportModel = GetReportDataByReport("", Army_Name);
            var newlist = reportModel.Where(a => a.Report_WarehouseName == WarehouseName&&a.Report_Batch==Batch).ToList();
            if (newlist != null && newlist.Count() > 0)
            {
                armyCount = newlist[0].Report_InventoryNum;
            }
            return Json(armyCount, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据武器和仓库查询军械批次状态和可借数量
        /// </summary>
        /// <returns></returns>
        public ActionResult GetBorrowByReport(string armyid, string WarehouseID, string Batch)
        {
            int armyCount = 0;
            int status = 0;
            List<ReportModel> reportModel = GetReportDataByReport(armyid, "");
            var newlist = reportModel.Where(a => a.Report_WarehouseID == WarehouseID && a.Report_Batch == Batch).ToList();
            if (newlist != null && newlist.Count() > 0)
            {
                armyCount = newlist[0].Report_InventoryNum;
                status = newlist[0].Report_MaintainStatus;
            }
            return Json(new{ status = status,count= armyCount }, JsonRequestBehavior.AllowGet);
        }
        
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public ActionResult AddBorrow(BorrowModel borrowModel)
        {
            borrowModel.Borrow_Status = 0;
            borrowModel.Borrow_Time = DateTime.Now.ToString("yyyy-MM-dd");
         
            ArmyDal armyDal = new ArmyDal();
            bool dt = armyDal.AddBorrow(borrowModel);
            return Json(dt);

        }

        /// <summary>
        /// 功能操作
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public ActionResult UpdateBorrow(string IDs, string state,string Borrow_Num, string armyid, string WarehouseID , string Batch)
        {

            ArmyDal armyDal = new ArmyDal();
            bool dt = armyDal.UpdateBorrow(IDs, state, Borrow_Num, armyid,  WarehouseID,  Batch);
            return Json(dt);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public ActionResult DeleteBorrow(List<string> IDs)
        {

            ArmyDal armyDal = new ArmyDal();
            bool dt = armyDal.DeleteBorrow(IDs);
            return Json(dt);

        }

        #endregion

        #region 军械采购入库

        /// <summary>
        /// 军械采购入库界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Report(string roleid,string Userid)
        {
            ViewBag.RoleID = roleid;
			ViewBag.UserID = Userid;

			return View();
        }        
        
        /// <summary>
        /// 军械采购入库新增编辑界面
        /// </summary>
        /// <returns></returns>
        public ActionResult ReportAddEdit(string type,string ID)
        {
            List<ReportModel> userlist = new List<ReportModel>();
            if (type == "2")
            {
                DataTable dt = new DataTable();
                ArmyDal armyDal = new ArmyDal();
                dt = armyDal.GetReportDataByID(ID,"", "","");             
                userlist = UserController.ModelConvertHelper<ReportModel>.ConvertToModel(dt).ToList();
                ViewBag.Report_ArmyID = userlist[0].Report_ArmyID;
                ViewBag.Report_Batch = userlist[0].Report_Batch;
                ViewBag.Report_UserID = userlist[0].Report_UserID;
                ViewBag.Report_WarehouseID = userlist[0].Report_WarehouseID;
                ViewBag.Report_TransportName = userlist[0].Report_TransportName;
                ViewBag.Report_TransportPhone = userlist[0].Report_TransportPhone;
                ViewBag.Report_Num = userlist[0].Report_Num;
            }
            ViewBag.ID = ID == null ? "" : ID;
            ViewBag.Type = type == null ? "" : type; ;
          
            return View();
        }
        
        /// <summary>
        /// 军械采购入库数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetReportData(string UserID,string Report_ArmyName, string Report_UserName, string Warehouse,string Report_CreatTime, string Report_Status)
        {
            DataTable dt = new DataTable();
            ArmyDal armyDal = new ArmyDal();
            dt = armyDal.GetReportData( UserID, Report_ArmyName,  Report_UserName, Warehouse, Report_CreatTime,  Report_Status);
            List<ReportModel> userlist = new List<ReportModel>();
            userlist = UserController.ModelConvertHelper<ReportModel>.ConvertToModel(dt).ToList();

            return Json(new { code = 0, count = userlist.Count, data = userlist }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 军械采购入库数据（军械数据界面）
        /// </summary>
        /// <returns></returns>
        public ActionResult GetReportMainCalData(string Report_ArmyName,  string Warehouse, string Report_CreatTime)
        {
            DataTable dt = new DataTable();
            ArmyDal armyDal = new ArmyDal();
            dt = armyDal.GetReportData("",Report_ArmyName, "", Warehouse, Report_CreatTime, "3");
            List<ReportModel> userlist = new List<ReportModel>();
            userlist = UserController.ModelConvertHelper<ReportModel>.ConvertToModel(dt).ToList();

            return Json(new { code = 0, count = userlist.Count, data = userlist }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public ActionResult DeleteReport(List<string> IDs)
        {

            ArmyDal armyDal = new ArmyDal();
            bool dt = armyDal.DeleteReport(IDs);
            return Json(dt);

        }       
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public ActionResult AddReport(ReportModel reportModel)
        {
            reportModel.Report_Status = 0;
            reportModel.Report_CreatTime = DateTime.Now.ToString("yyyy-MM-dd");
            reportModel.Report_InventoryNum = reportModel.Report_Num;
            reportModel.Report_BorrowNum = 0;
            reportModel.Report_ScrapNum = 0;
            reportModel.Report_MaintainStatus = 1;
            reportModel.Report_MaintainTime = DateTime.Now.ToString("yyyy-MM-dd");


            ArmyDal armyDal = new ArmyDal();
            bool dt = armyDal.AddReport(reportModel);
            return Json(dt);

        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public ActionResult UpdateReportData(ReportModel reportModel)
        {
            ArmyDal armyDal = new ArmyDal();
            bool dt = armyDal.UpdateReportData(reportModel);
            return Json(dt);

        }
        /// <summary>
        /// 功能额操作修改
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public ActionResult UpdateReport(string IDs,string state)
        {
           

            ArmyDal armyDal = new ArmyDal();
            bool dt = armyDal.UpdateReport(IDs,state);
            return Json(dt);

        }
        
        

        #endregion




        /// <summary>
        /// 获得32位字符长度的ID
        /// </summary>
        /// <param name="information">获得32位字符长度的ID</param>
        public static string getGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString().Replace("-", "").ToUpper();

        }

    }
}