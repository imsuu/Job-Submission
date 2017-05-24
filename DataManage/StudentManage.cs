using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace DataManage
{
    public class StudentManage
    {
        //绑定学生列表
        public SqlDataReader DataBindStudentList(string id)
        {
            string sql = "select StudentID as ID,SequenceNumber as 序号,Number as 学号,Name as 姓名,Class as 专业班级,Password as 密码 from StudentList where TeacherID ='" + id + "'";
            SqlDataAccess sda = new SqlDataAccess();
            SqlDataReader dr = sda.RunSqlReturnDataReader(sql);
            return dr;
        }
        //编辑学生列表
        public void EditStudentList(string SequenceNumber, string Number, string Name, string Class, string Password, string id)
        {
            string sql = "update StudentList set SequenceNumber='" + SequenceNumber + "',Number='" + Number + "',Name='" + Name + "',Class='" + Class + "',Password='" + Password + "'where StudentID = '" + id + "'";
            SqlDataAccess sda = new SqlDataAccess();
            sda.RunSqlNoReturn(sql);
        }
        //检查学号是否重复
        public bool CheckNumber(string number)
        {
            bool result = false;
            string sql = "select Number from StudentList where Number ='" + number + "'";
            SqlDataAccess sda = new SqlDataAccess();
            object Number = sda.RunSqlReturnFirstValue(sql);
            if (Number == null)
            {
                result = true;
            }
            return result;
        }
        //检查序号是否重复
        public bool CheckSequenceNumber(string sequencenumber)
        {
            bool result = false;
            string sql = "select SequenceNumber from StudentList where SequenceNumber ='" + sequencenumber + "'";
            SqlDataAccess sda = new SqlDataAccess();
            object Number = sda.RunSqlReturnFirstValue(sql);
            if (Number == null)
            {
                result = true;
            }
            return result;
        }
        //添加学生用户
        public int AddStudent(string teacherid, string sequence, string number, string name, string clas, string password)
        {
            int result = 0;
            bool Seq = CheckSequenceNumber(sequence);
            bool Num = CheckNumber(number);
            if (Seq == true)
            {
                if (Num == true)
                {
                    string sql = "insert into StudentList(SequenceNumber,Number,Name,Class,Password,TeacherID)values('" + sequence + "','" + number + "','" + name + "','" + clas + "','" + password + "','" + teacherid + "')";
                    SqlDataAccess sda = new SqlDataAccess();
                    sda.RunSqlNoReturn(sql);
                }
                else
                {
                    result = 2;
                }
            }
            else
            {
                result = 1;
            }
            return result;
        }
        //删除学生用户
        public void DeleteStudent(string studentID)
        {
            string delGradelist = "delete from GradeList where StudentID='" + studentID + "'";
            string delSMClist = "delete from SMCList where StudentID='" + studentID + "'";
            string delStudentlist = "delete from StudentList where StudentID='" + studentID + "'";
            SqlDataAccess sda = new SqlDataAccess();
            sda.RunSqlNoReturn(delGradelist);
            sda.RunSqlNoReturn(delSMClist);
            sda.RunSqlNoReturn(delStudentlist);
        }
        //绑定作业列表
        public SqlDataReader BusyworkListBind(string studentID)
        {
            string sql = "select GradeID as ID,CourseName as 课程名称,BusyworkTime as 作业次数,Deadline as 提交期限,Grade as 成绩 from StudentBusyworkBind where StudentID ='" + studentID + "'";
            SqlDataAccess sda = new SqlDataAccess();
            SqlDataReader sdr = sda.RunSqlReturnDataReader(sql);
            return sdr;
        }
        //返回学生的姓名   
        static public string GetStudentName
        {
            get
            {
                return (HttpContext.Current.Request.Cookies["StudentName"] == null) ? null : HttpContext.Current.Request.Cookies["StudentName"].Value;
            }
        }
        //学生用户登陆方法
        public void StudentLogin(string username, string userpwd)
        {
            string sql = @"select StudentID from StudentList where Number ='" + username + "'and Password ='" + userpwd + "'";
            SqlDataAccess DataAccess = new SqlDataAccess();
            string id = DataAccess.RunSql(sql);
            if (Equals(id, ""))
            {
                string alert = "用户名或密码不正确!";
                HttpContext.Current.Response.Write("<script language = 'javascript'>alert('" + alert + "');</script>");
            }
            else
            {
                string sqlReturnName = "select Name from StudentList where StudentID = '" + id + "'";
                SqlDataAccess access = new SqlDataAccess();
                string Name = access.RunSql(sqlReturnName);
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("StudentID", id));
                HttpContext.Current.Request.Cookies["StudentID"].Expires = DateTime.Now.AddHours(5);
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("StudentName", Name));
                HttpContext.Current.Request.Cookies["StudentName"].Expires = DateTime.Now.AddHours(5);
                HttpContext.Current.Response.Redirect("StudentPage.aspx");
            }
        }
        //学生注销方法
        public void StudentLogoOff()
        {
            if (!Equals(HttpContext.Current.Request.Cookies["StudentID"].Value, null))
            {
                HttpContext.Current.Response.Cookies["StudentID"].Expires = DateTime.Now.AddHours(-1);
                HttpContext.Current.Response.Cookies["StudentName"].Expires = DateTime.Now.AddHours(-1);
                HttpContext.Current.Response.Redirect("Default.aspx");
            }
        }
    }
}
