using OrdnanceWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrdnanceWeb.DAL
{
    public class UserDal
    {
        public DataTable GetUser(string ID, string name, string role)
        {
            string sql = "select *,Role_Name from Ord_UserTable OUT Left Join Ord_RoleTable ORT on OUT.Role_ID=ORT.Role_ID  where 1=1 ";
            if (!string.IsNullOrEmpty(ID))
            {
                sql += " and User_ID = '" + ID + "'";
            }
            if (!string.IsNullOrEmpty(name))
            {
                sql += " and User_Name like '%" + name + "%'";
            }         
            if (!string.IsNullOrEmpty(role))
            {
                sql += " and OUT.Role_ID='" + role + "'";
            }
            DataTable dt= DBHelper.reDs(sql);
            return dt;

        }

        public int GetUserCount( string name)
        {
            string sql = "select *,Role_Name from Ord_UserTable OUT Left Join Ord_RoleTable ORT on OUT.Role_ID=ORT.Role_ID  where 1=1 ";

            if (!string.IsNullOrEmpty(name))
            {
                sql += " and User_Name = '" + name + "'";
            }   
            int dt = DBHelper.DataCount(sql);
            return dt;

        }
        

        public DataTable GetRole()
        {
            DataTable dt = DBHelper.reDs("select * from Ord_RoleTable");
            return dt;
        }
        public bool DeleteUser(string User_ID)
        {
            if (string.IsNullOrEmpty(User_ID))
            {
                return false;
            }
            string  Sql = "delete Ord_UserTable where User_ID='"+ User_ID+"'";
            bool dt = DBHelper.ExSql(Sql);
            return dt;
        }
        public bool AddUser(UserModel usermodel)
        {
            string Sql = "";
            if (usermodel != null)
            {
                Sql = @"Insert into Ord_UserTable( User_ID, User_Name,User_PassWord,  Role_ID,  User_Status , User_CreateTime ) 
                    values('" + usermodel.User_ID+ "', '" + usermodel.User_Name + "', '"+usermodel.User_PassWord+"', '" + usermodel.Role_ID + "',  " + usermodel.User_Status + " , '" + usermodel.User_CreateTime+"')";
               
            }
            bool dt = DBHelper.ExSql(Sql);
            return dt;
        }

        public bool UpdateUser(UserModel usermodel)
        {
            string Sql = "";
            if (usermodel != null)
            {
                Sql = @"UPDATE [dbo].[Ord_UserTable]
                    SET [User_PassWord] = '" + usermodel.User_PassWord + "',[User_Name] = '"+ usermodel.User_Name +"'  ,[Role_ID] =  '"+ usermodel.Role_ID +"'  ,[User_Status] =  '"+ usermodel.User_Status +"'WHERE User_ID = '"+usermodel.User_ID+"'";

            }
            bool dt = DBHelper.ExSql(Sql);
            return dt;
        }
        

        public DataTable GetWarehouse()
        {
            DataTable dt = DBHelper.reDs("select * from Ord_WarehouseTable");
            return dt;
        }
        

    }
}