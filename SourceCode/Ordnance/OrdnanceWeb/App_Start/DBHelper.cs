﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;//引入数据库所需的命名空间

/// <summary>
/// DB 的摘要说明
/// </summary>
public class DBHelper
{

    /// <summary>
    /// 配置连接字符串
    /// </summary>
    /// <returns>返回SqlConnection对象</returns>
    public static SqlConnection GetCon()
    {
        return new SqlConnection("server=CLASSICRIVER\\SA;database=Ordnance;;Trusted_Connection=SSPI");//配置连接字符串
    }

    /// <summary>
    /// 执行SQL语句
    /// </summary>
    /// <param name="P_str_cmdtxt">用来执行的SQL语句</param>
    /// <returns>返回是否成功,成功返回True,否则返回False</returns>
    public static bool ExSql(string P_str_cmdtxt)
    {
        SqlConnection con = DBHelper.GetCon();//连接数据库
        con.Open();//打开连接
        SqlCommand cmd = new SqlCommand(P_str_cmdtxt, con);
        try
        {
            cmd.ExecuteNonQuery();//执行SQL 语句并返回受影响的行数
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
        finally
        {
            con.Dispose();//释放连接对象资源
        }
    }

    /// <summary>
    /// 返回DataSet结果集
    /// </summary>
    /// <param name="P_str_cmdtxt">用来查询的SQL语句</param>
    /// <returns>结果集</returns>
    public static DataTable reDs(string P_str_cmdtxt)
    {
        SqlConnection con = DBHelper.GetCon();//连接上数据库
        SqlDataAdapter da = new SqlDataAdapter(P_str_cmdtxt, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds.Tables[0];//返回DataSet对象
    }

    /// <summary>
    /// 返回数量
    /// </summary>
    /// <param name="P_str_cmdtxt">用来查询的SQL语句</param>
    /// <returns>结果集</returns>
    public static int DataCount(string P_str_cmdtxt)
    {
        SqlConnection con = DBHelper.GetCon();//连接上数据库
        SqlDataAdapter da = new SqlDataAdapter(P_str_cmdtxt, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds.Tables[0].Rows.Count;//返回DataSet对象
    }
}
