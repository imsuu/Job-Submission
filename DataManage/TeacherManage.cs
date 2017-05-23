using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Web;
using System.IO;

namespace DataManage
{
    public class TeacherManage
    {
        StudentManage sm = new StudentManage();
        //返回教师的姓名   
        static public string GetTeacherName
        {
            get
            {
                return (HttpContext.Current.Request.Cookies["TeacherName"] == null) ? null : HttpContext.Current.Request.Cookies["TeacherName"].Value;
            }
        }
        //教师用户登陆方法
        public void TeacherLogin(string username, string userpwd)
        {
            string sql = @"select TeacherID from TeacherList where UserName ='" + username + "'and Password ='" + userpwd + "'";
            SqlDataAccess DataAccess = new SqlDataAccess();
            string id = DataAccess.RunSql(sql);
            if (Equals(id, ""))
            {
                string alert = "用户名或密码不正确!";
                HttpContext.Current.Response.Write("<script language = 'javascript'>alert('" + alert + "');</script>");
            }
            else
            {
                string sqlReturnName = "select TeacherName from TeacherList where TeacherID = '"+ id +"'";
                SqlDataAccess access = new SqlDataAccess();
                string Name = access.RunSql(sqlReturnName);
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("TeacherID", id));
                HttpContext.Current.Request.Cookies["TeacherID"].Expires = DateTime.Now.AddHours(5);
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("TeacherName", Name));
                HttpContext.Current.Request.Cookies["TeacherName"].Expires = DateTime.Now.AddHours(5);
                HttpContext.Current.Response.Redirect("ViewCourse.aspx");
            }
        }
        //教师注销方法
        public void TeacherLogoOff()
        {
            if (!Equals(HttpContext.Current.Request.Cookies["TeacherID"].Value, null))
            {
                HttpContext.Current.Response.Cookies["TeacherID"].Expires = DateTime.Now.AddHours(-1);
                HttpContext.Current.Response.Cookies["TeacherName"].Expires = DateTime.Now.AddHours(-1);
                HttpContext.Current.Response.Redirect("Default.aspx");
            }
        }

        //验证用户名是否存在
        public bool VldUserName(string username)
        {
            bool result = false;
            string sql = "select * from TeacherList where UserName = '" + username + "'";
            SqlDataAccess sda = new SqlDataAccess();
            object obj = sda.RunSqlReturnFirstValue(sql);
            if (obj == null)
            {
                result = true;
            }
            return result;
        }

        //获取用户信息
        public SqlDataReader GetUser()
        {
            SqlDataAccess DataAccess = new SqlDataAccess();
            DataAccess.open();
            SqlDataReader sdr = DataAccess.RunProc("P_GetUser");
            DataAccess.close();
            return (sdr);
        }
        //管理员登陆方法
        public void AdminLogin(string username, string userpwd)
        {
            string sql = @"select AdminID from AdminList where UserName ='" + username + "'and Password ='" + userpwd + "'";
            SqlDataAccess DataAccess = new SqlDataAccess();
            string id = DataAccess.RunSql(sql);
            if (Equals(id, ""))
            {
                string alert = "用户名或密码不正确!";
                HttpContext.Current.Response.Write("<script language = 'javascript'>alert('" + alert + "');</script>");
            }
            else
            {
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("AdminID", id));
                HttpContext.Current.Request.Cookies["AdminID"].Expires = DateTime.Now.AddHours(5);
                HttpContext.Current.Response.Redirect("Admin.aspx");
            }
        }

    }
}
