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
	public class IndexController : Controller
	{
		// GET: Index
		public ActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// 登录记录
		/// </summary>
		/// <returns></returns>
		public ActionResult LoginLogger()
		{
			return View();
		}

		#region 登录
		/// <summary>
		/// 登录记录数据
		/// </summary>
		/// <returns></returns>
		public ActionResult GetLoginLoggerData(string username, string password)
		{
			string Role_Id = "";
			string User_Id = "";
			string User_Name = "";
			int User_Status = 0;

			DataTable dt = new DataTable();
			IndexDal indexDal = new IndexDal();
			dt = indexDal.GetLoginLoggerData(username, password);
			IList<UserModel> userlist = new List<UserModel>();
			userlist = UserController.ModelConvertHelper<UserModel>.ConvertToModel(dt);
			bool num = userlist.Count > 0;
			if (userlist.Count > 0)
			{
				Role_Id = userlist[0].Role_ID;
				User_Id = userlist[0].User_ID;
				User_Name = userlist[0].User_Name;
				User_Status = userlist[0].User_Status;
			}


			return Json(new { num = num, Role_Id = Role_Id, User_Id = User_Id, User_Name = User_Name, User_Status = User_Status }, JsonRequestBehavior.AllowGet);
		}
		#endregion



		/// <summary>
		/// 仓库
		/// </summary>
		/// <param name="name"></param>
		/// <param name="dept"></param>
		/// <param name="role"></param>
		/// <returns></returns>
		public ActionResult GetWarehouseData(string Warehouse_Name)
		{

			DataTable dt = new DataTable();
			ArmyDal armyDal = new ArmyDal();
			dt = armyDal.GetWarehouseData(Warehouse_Name);
			IList<WarehouseModel> userlist = new List<WarehouseModel>();
			userlist = UserController.ModelConvertHelper<WarehouseModel>.ConvertToModel(dt);
			var newlist = userlist;
			return Json(new { code = 0, count = userlist.Count, data = userlist }, JsonRequestBehavior.AllowGet);

		}


		#region 登录之后的总览信息
		///<summary>
		///登录总览信息 出入库数量  表格之类
		/// </summary>
		public ActionResult GetAllData()
		{
			//定义月初时间和当前时间
			DateTime yuechu = DateTime.Parse(DateTime.Now.ToString("yyyy-MM") + "-01");
			DateTime now = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));

			//获取入库的总数据 用linq再次查询总数
			int ruku = 0;
			int zruku = 0;
			DataTable dt1 = new DataTable();
			IndexDal indexDal1 = new IndexDal();
			dt1 = indexDal1.GetRukuData();
			IList<ReportModel> userlist1 = new List<ReportModel>();
			userlist1 = UserController.ModelConvertHelper<ReportModel>.ConvertToModel(dt1);
			ruku = userlist1.Where(a => (Convert.ToDateTime(a.Report_MaintainTime) >= yuechu) && (Convert.ToDateTime(a.Report_MaintainTime) <= now)).ToList().Sum(a => a.Report_Num);
			zruku = userlist1.Sum(a => a.Report_Num);

			//获取借出总数据 用linq再次查询总数以及月度数
			int chuku = 0;
			int zchuku = 0;
			DataTable dt2 = new DataTable();
			IndexDal indexDal2 = new IndexDal();
			dt2 = indexDal2.GetChukuData();
			IList<BorrowModel> userlist2 = new List<BorrowModel>();
			userlist2 = UserController.ModelConvertHelper<BorrowModel>.ConvertToModel(dt2);
			chuku = userlist2.Where(a => (Convert.ToDateTime(a.Borrow_Time) >= yuechu) && (Convert.ToDateTime(a.Borrow_Time) <= now)).ToList().Sum(a => a.Borrow_Num);
			zchuku = userlist2.Sum(a => a.Borrow_Num);


			//获取报废总数 用linq再次查询总数以及月度数
			int baofei = 0;
			int zbaofei = 0;
			DataTable dt3 = new DataTable();
			IndexDal indexDal = new IndexDal();
			dt3 = indexDal.GetBaofeiData();
			IList<ScrapModel> userlist3 = new List<ScrapModel>();
			userlist3 = UserController.ModelConvertHelper<ScrapModel>.ConvertToModel(dt3);
			baofei = userlist3.Where(a => (Convert.ToDateTime(a.Scrap_Time) >= yuechu) && (Convert.ToDateTime(a.Scrap_Time) <= now)).ToList().Sum(a => a.Scrap_Num);
			zbaofei = userlist3.Sum(a => a.Scrap_Num);


			//查询用户总数 用linq查询正常用户以及总用户
			int user = 0;
			int zuser = 0;
			DataTable dt4 = new DataTable();
			IndexDal indexDal4 = new IndexDal();
			dt4 = indexDal.GetUserData();
			IList<UserModel> userlist4 = new List<UserModel>();
			userlist4 = UserController.ModelConvertHelper<UserModel>.ConvertToModel(dt4);
			user = userlist4.Where(a => a.User_Status == 1).ToList().Count();
			zuser = userlist4.Count();

			return Json(new { ruku = ruku, zruku = zruku, chuku = chuku, zchuku = zchuku, baofei = baofei, zbaofei = zbaofei, user = user, zuser = zuser }, JsonRequestBehavior.AllowGet);
		}
		#endregion




		#region  年度借用排名
		/// <summary>
		/// 首页的排名信息借永
		/// </summary>
		public ActionResult ShouyePaiming()
		{

			DataTable dt = new DataTable();
			IndexDal indexDal = new IndexDal();
			dt = indexDal.ShouyePaiming();
			IList<BorrowModel> userlist = new List<BorrowModel>();
			userlist = UserController.ModelConvertHelper<BorrowModel>.ConvertToModel(dt);
			var newlist = userlist.OrderBy(a=>a.Borrow_Num).Take(6);
			return Json(new { code = 0, count = userlist.Count, data = newlist }, JsonRequestBehavior.AllowGet);

		}
		#endregion
		#region 首页军械借用记录表格
		/// <summary>
		/// 首页的排名信息借永
		/// </summary>
		public ActionResult ShouyeBorrow()
		{

			DataTable dt = new DataTable();
			IndexDal indexDal = new IndexDal();
			dt = indexDal.ShouyeBorrow();
			IList<BorrowModel> userlist = new List<BorrowModel>();
			userlist = UserController.ModelConvertHelper<BorrowModel>.ConvertToModel(dt);
			var newlist = userlist.Take(10);
			return Json(new { code = 0, count = userlist.Count, data = newlist }, JsonRequestBehavior.AllowGet);

		}
		#endregion
		#region  军械首页入库记录
		/// <summary>
		/// 首页的入库记录表格
		/// </summary>
		public ActionResult ShouyeRuku()
		{

			DataTable dt = new DataTable();
			IndexDal indexDal = new IndexDal();
			dt = indexDal.ShouyeRuku();
			IList<ReportModel> userlist = new List<ReportModel>();
			userlist = UserController.ModelConvertHelper<ReportModel>.ConvertToModel(dt);
			var newlist = userlist.Take(10);
			return Json(new { code = 0, count = userlist.Count, data = newlist }, JsonRequestBehavior.AllowGet);

		}
		#endregion
		#region  军械报废记录表格
		/// <summary>
		/// 首页的报废表格
		/// </summary>
		public ActionResult ShouyeBaofei()
		{

			DataTable dt = new DataTable();
			IndexDal indexDal = new IndexDal();
			dt = indexDal.ShouyeBaofei();
			IList<ScrapModel> userlist = new List<ScrapModel>();
			userlist = UserController.ModelConvertHelper<ScrapModel>.ConvertToModel(dt);
			var newlist = userlist.Take(10);
			return Json(new { code = 0, count = userlist.Count, data = newlist }, JsonRequestBehavior.AllowGet);

		}
		#endregion
	}
}