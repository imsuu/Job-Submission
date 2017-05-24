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
        BusyworkManage bm = new BusyworkManage();
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
        //添加教师方法
        public void AddTeacher(string strname, string strpwd,string teachername,string path)
        {
            string sql = "insert into TeacherList(UserName,Password,TeacherName) values('"+ strname +"','"+ strpwd +"','"+ teachername +"')";
            SqlDataAccess sda = new SqlDataAccess();
            sda.RunSqlNoReturn(sql);
            string insert = "select TeacherID from TeacherList where UserName='"+ strname +"'";
            string id =sda.RunSql(insert);
            string Path = path + id;
            string topic = Path + BusyworkManage.TopicPath;
            string busywork = Path + BusyworkManage.BusyworkPath;
            Directory.CreateDirectory(Path);
            Directory.CreateDirectory(topic);
            Directory.CreateDirectory(busywork);
            string alert = "添加成功！!";
            HttpContext.Current.Response.Write("<script language = 'javascript'>alert('" + alert + "');</script>");
        }
        //更新教师信息方法
        public void UpdateTeacher(string id,string username,string password,string name)
        {
            string sql = "update TeacherList set UserName='" + username + "',Password='" + password + "',TeacherName='" + name + "'where TeacherID = '" + id + "'";
            SqlDataAccess sda = new SqlDataAccess();
            sda.RunSqlNoReturn(sql);
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
        //修改密码
        public void ChangPwd(string strname, string strpwd)
        {
            string sql = "update AdminList set UserName='"+ strname +"',Password='"+ strpwd +"'where AdminID='1'";
            SqlDataAccess sda = new SqlDataAccess();
            sda.RunSqlNoReturn(sql);
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
        //删除教师用户
        public void DeleteTeacher(string teacherid)
        {
            SqlDataAccess sda = new SqlDataAccess();
            DataSet ds1 = sda.ReturnStudentIDDataSet(teacherid);
            string[] ListOfStudentID = new string[ds1.Tables["Student"].Rows.Count];
            for (int i = 0; i < ds1.Tables["Student"].Rows.Count;i++ )
            {
                ListOfStudentID[i] = ds1.Tables["Student"].Rows[i]["StudentID"].ToString();
            }
            foreach (string p1 in ListOfStudentID)
            {                
                sm.DeleteStudent(p1);
            }
            DataSet ds2 = sda.ReturnCourseIDDataSet(teacherid);
            string[] ListOfCourseID = new string[ds2.Tables["Course"].Rows.Count];
            for (int j = 0; j < ds2.Tables["Course"].Rows.Count; j++)
            {
                ListOfCourseID[j] = ds2.Tables["Course"].Rows[j]["CourseID"].ToString();
            }
            foreach (string p2 in ListOfCourseID)
            {
                bm.DeleteCourseByID(p2);
            }
            string sql = "delete from TeacherList where TeacherID = '"+ teacherid +"'";
            sda.RunSqlNoReturn(sql);            
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
        //管理员注销方法
        public void AdminLogoOff()
        {
            if (!Equals(HttpContext.Current.Request.Cookies["AdminID"].Value, null))
            {
                HttpContext.Current.Response.Cookies["AdminID"].Expires = DateTime.Now.AddHours(-1);
                HttpContext.Current.Response.Redirect("Default.aspx");
            }
        }
        //绑定教师列表
        public SqlDataReader TeacherListDataBind()
        {
            string sql = "select TeacherID as ID,UserName as 用户名,Password as 密码,TeacherName as 姓名 from TeacherList";
            SqlDataAccess sda = new SqlDataAccess();
            SqlDataReader sdr = sda.RunSqlReturnDataReader(sql);
            return sdr;
        }
        //删除属于教师的目录
        public void DeleteDirOfTeacher(string teacherid,string path)
        {
            string topic = path + BusyworkManage.TopicPath;
            string busywork = path + BusyworkManage.BusyworkPath;
            string sql = "select CL.CourseName from CourseList CL inner join TMCList as TMCL on CL.CourseID = TMCL.CourseID where TMCL.TeacherID = '"+ teacherid +"'";
            SqlDataAccess sda = new SqlDataAccess();
            DataSet ds = sda.ReturnCourseNameDataSet(sql);
            string[] ListOfCourseName = new string[ds.Tables["CourseName"].Rows.Count];
            for (int i = 0; i < ds.Tables["CourseName"].Rows.Count; i++)
            {
                ListOfCourseName[i] = ds.Tables["CourseName"].Rows[i]["CourseName"].ToString();
            }
            foreach (string p in ListOfCourseName)
            {
                bm.DeleteAllFileInDir(topic + p);
                bm.DeleteAllFileInDir(busywork + p);
            }
            bm.DeleteDir(topic);
            bm.DeleteDir(busywork);
            bm.DeleteDir(path);
        }
        //返回管理员用户名
        public string ReturnAdminName()
        {
            string sql = "select UserName from AdminList";
            SqlDataAccess sda = new SqlDataAccess();
            string name = sda.RunSql(sql);
            return name;
        }
        //返回管理员密码
        public string ReturnAdminPwd()
        {
            string sql = "select Password from AdminList";
            SqlDataAccess sda = new SqlDataAccess();
            string pwd = sda.RunSql(sql);
            return pwd;
        }
        //根据学生返回教师ID
        public string ReturnTeacherID(string stuID)
        {
            string sql = "select TeacherID from StudentList where StudentID = '"+ stuID +"'";
            SqlDataAccess sda = new SqlDataAccess();
            string result = sda.RunSql(sql);
            return result;
        }
    }
}
