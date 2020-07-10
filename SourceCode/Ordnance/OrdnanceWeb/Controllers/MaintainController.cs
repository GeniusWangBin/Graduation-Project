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
	public class MaintainController : Controller
	{


		#region 维修计划表
		public ActionResult GetNeedMaintain(string roleid , string Userid)
		{
			ViewBag.RoleID = roleid;
			ViewBag.UserID = Userid;
            return View();
		}
		#endregion
		public ActionResult GetMaintainRecord()
		{
			return View();
		}
		#region 维修记录

		#endregion

		#region 武器维修数据
		public ActionResult GetMaintainData(string UserID,string Report_ArmyName, string Warehouse)
		{
			DataTable dt = new DataTable();
			MaintainDal maintainDal = new MaintainDal();
			dt = maintainDal.GetMaintainData(UserID ,Report_ArmyName, Warehouse);
			List<ReportModel> userlist = new List<ReportModel>();
			userlist = UserController.ModelConvertHelper<ReportModel>.ConvertToModel(dt).ToList();
			userlist = userlist.Where(a => Convert.ToDateTime(a.Report_MaintainTime).AddMonths(a.Report_RepairCycle) < DateTime.Now).ToList();

			return Json(new { code = 0, count = userlist.Count, data = userlist }, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region 进行武器维修
		public ActionResult MaintainReport(List<string> IDs)
		{

			MaintainDal maintaindal = new MaintainDal();
			bool dt = maintaindal.MaintainReport(IDs);

			return Json(dt);
		}
		#endregion

		#region 武器维修完成 
		/// 修改维修状态 并且返回数据库
		/// 
		public ActionResult FinishReport(List<string> IDs)
		{
			MaintainDal maintaindal = new MaintainDal();
			bool dt = maintaindal.FinishReport(IDs);

			return Json(dt);
		}

		#endregion

		#region 维修记录生成
		///<summary>
		///维修记录生成
		/// </summary>
		public ActionResult FinishRecord(MaintainModel maintainModel)
		{
			MaintainDal maintaindal = new MaintainDal();
			bool dt = maintaindal.FinishRecord(maintainModel);

			return Json(dt);
		}
		#endregion

		#region 维修记录
		///<summary>
		///获取维修记录
		/// </summary>
		public ActionResult GetRecord(string Maintain_Name,string Warehouse)
		{
			DataTable dt = new DataTable();
			MaintainDal maintaindal = new MaintainDal();
			dt = maintaindal.GetRecord(Maintain_Name,Warehouse);
			List<MaintainModel> userlist = new List<MaintainModel>();
			userlist = UserController.ModelConvertHelper<MaintainModel>.ConvertToModel(dt).ToList();

			return Json(new { code = 0, count = userlist.Count, data = userlist }, JsonRequestBehavior.AllowGet);
		}
		#endregion
	}

}