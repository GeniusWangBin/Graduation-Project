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
    public class UserController : Controller
    {
        // GET: User
        public ActionResult User(string roleid)
        {
            ViewBag.RoleID = roleid;
            return View();
        }       
        /// <summary>
        /// 用户新增修改界面
        /// </summary>
        /// <param name="type"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult UserAddEdit(string type, string ID)
        {
            if (type == "2")
            {
                DataTable dt = new DataTable();
                UserDal userdal = new UserDal();
                dt = userdal.GetUser(ID, "", "");
                IList<UserModel> userlist = new List<UserModel>();
                userlist = ModelConvertHelper<UserModel>.ConvertToModel(dt);

                ViewBag.User_ID = userlist[0].User_ID;
                ViewBag.User_Name = userlist[0].User_Name;
                ViewBag.User_PassWord = userlist[0].User_PassWord;
                ViewBag.User_RoleID= userlist[0].Role_ID;
                ViewBag.User_Status= userlist[0].User_Status;
            }
            ViewBag.ID = ID == null ? "" : ID;
            ViewBag.Type = type == null ? "" : type; ;
            return View();
        }
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public ActionResult GetUser(string  ID,string name,string role)
        { 
           
            DataTable dt = new DataTable();
            UserDal userdal = new UserDal();
            dt = userdal.GetUser(ID,name,  role);
            IList<UserModel> userlist = new List<UserModel>();
            userlist=ModelConvertHelper<UserModel>.ConvertToModel(dt);

            return Json(new { code = 0, count= userlist.Count, data = userlist },JsonRequestBehavior.AllowGet);
           
        }

        /// <summary>
        /// 获取用户(数量)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public ActionResult GetUserCount(string User_Name)
        {

            UserDal userdal = new UserDal();
            int dt = userdal.GetUserCount( User_Name);
            return Json(dt, JsonRequestBehavior.AllowGet);

        }
        
        /// <summary>
        /// 获取角色
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRoleData()
        {

            DataTable dt = new DataTable();
            UserDal userdal = new UserDal();
            dt = userdal.GetRole();
            List<RoleModel> userlist = new List<RoleModel>();
            userlist = ModelConvertHelper<RoleModel>.ConvertToModel(dt).ToList();

            return Json(new { code = 0, count = userlist.Count, data = userlist }, JsonRequestBehavior.AllowGet);

        }
       

        public ActionResult DeleteUser(string User_ID)
        {

            UserDal userdal = new UserDal();
            bool dt = userdal.DeleteUser(User_ID);

            return Json(dt);

        }
        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="usermodel"></param>
        /// <returns></returns>
        public ActionResult AddUser(UserModel usermodel)
        {
            usermodel.User_ID = getGuid();
            usermodel.User_CreateTime = DateTime.Now.ToString();
            UserDal userdal = new UserDal();
            bool dt = userdal.AddUser(usermodel);

            return Json(dt);
        }

        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="usermodel"></param>
        /// <returns></returns>
        public ActionResult UpdateUser(UserModel usermodel)
        {
            UserDal userdal = new UserDal();
            bool dt = userdal.UpdateUser(usermodel);

            return Json(dt);
        }
        
        /// <summary>
        /// DataTable转List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ModelConvertHelper<T> where T : new()  // 此处一定要加上new()
        {
            public static IList<T> ConvertToModel(System.Data.DataTable dt)
            {

                IList<T> ts = new List<T>();// 定义集合
                Type type = typeof(T); // 获得此模型的类型
                string tempName = "";
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    T t = new T();
                    System.Reflection.PropertyInfo[] propertys = t.GetType().GetProperties();// 获得此模型的公共属性
                    foreach (System.Reflection.PropertyInfo pi in propertys)
                    {
                        tempName = pi.Name;
                        if (dt.Columns.Contains(tempName))
                        {
                            if (!pi.CanWrite) continue;
                            object value = dr[tempName];
                            if (pi.PropertyType.FullName == "System.Int32")//此处判断下Int32类型，如果是则强转
                                value = Convert.ToInt32(value);
                            if (value != DBNull.Value)
                                pi.SetValue(t, value, null);
                        }
                    }
                    ts.Add(t);
                }
                return ts;
            }
        }

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