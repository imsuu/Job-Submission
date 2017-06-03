using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Util;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

namespace DataManage
{
    public class BusyworkManage
    {
        //
        public static string Path = "UploadFile/";
        //题目路径
        public static string TopicPath = "/Topic/";
        //作业路径
        public static string BusyworkPath = "/Busywork/";
        //课程列表绑定
        public SqlDataReader CourseDataBind(string id)
        {
            string sql = @"SELECT CL.CourseID as 课程编号, CL.CourseName as 课程名称 FROM CourseList CL inner join TMCList as TMCL on CL.CourseID = TMCL.CourseID where TMCL.TeacherID ='" + id + "'";
            SqlDataAccess sda = new SqlDataAccess();
            SqlDataReader dr = sda.RunSqlReturnDataReader(sql);
            return dr;
        }
        //作业列表绑定
        public SqlDataReader BusyworkDataBind(string CourseID)
        {

            string sql = "select BusyworkTimeList.CourseID as 课程ID,CourseName as 课程名称,BusyworkTime as 作业次数 ,Deadline as 作业截止日期 from "
            + "BusyworkTimeList,CourseList where BusyworkTimeList.CourseID ='" + CourseID + "' and  BusyworkTimeList.CourseID=CourseList.CourseID";
            SqlDataAccess sda = new SqlDataAccess();
            SqlDataReader dr = sda.RunSqlReturnDataReader(sql);
            return dr;
        }
        //返回课程名称
        public string ReturnCourseName(string CourseID)
        {
            string sql = "select CourseName from CourseList where CourseID='" + CourseID + "'";
            SqlDataAccess sda = new SqlDataAccess();
            string courseName = sda.RunSql(sql);
            return courseName;
        }
        //作业查看评定列表绑定
        public SqlDataReader BusyworkCheck(string courseID,string time)
        {
            string sql = "select GL.GradeID as ID,BTL.BusyworkTime as 作业次数,SL.Name as 学生姓名,GL.Grade as 成绩 from GradeList GL inner join BusyworkTimeList as BTL on GL.TimeID = BTL.TimeID inner join StudentList as SL on GL.StudentID = SL.StudentID where GL.CourseID = '" + courseID + "' and BTL.BusyworkTime = '" + time + "'";
            SqlDataAccess sda = new SqlDataAccess();
            SqlDataReader dr = sda.RunSqlReturnDataReader(sql);
            return dr;
        }
        //修改成绩
        public void ChangeGrade(string grade,string gradeID)
        {
            string sql = "update GradeList set Grade='" + grade + "'where GradeID='" + gradeID + "'";
            SqlDataAccess sda = new SqlDataAccess();
            sda.RunSqlNoReturn(sql);
        }
        //有课程的学生列表
        public SqlDataReader HaveCourseStudentListBind(string courseID)
        {
            string sql = "select SMCL.SMCID as ID,SL.Number as 学号,SL.Name as 姓名 from SMCList SMCL inner join StudentList as SL on SMCL.StudentID = SL.StudentID where SMCL.CourseID ='" + courseID + "'";
            SqlDataAccess sda = new SqlDataAccess();
            SqlDataReader dr = sda.RunSqlReturnDataReader(sql);
            return dr;
        }
        //没有课程的学生列表
        public SqlDataReader HaveNoCourseStudentListBind(string courseID,string teacherID)
        {
            SqlDataReader dr;
            SqlDataAccess sda = new SqlDataAccess();
            string testsql = "select * from SMCList where CourseID = '"+ courseID +"'";
            object obj = sda.RunSqlReturnFirstValue(testsql);
            if (obj == null)
            {
                string selectStu = "select StudentID as ID,Number as 学号,Name as 姓名 from StudentList where TeacherID = '" + teacherID + "'";
                dr = sda.RunSqlReturnDataReader(selectStu);
            }
            else
            {
                string sql = "select StudentID as ID,Number as 学号,Name as 姓名 from StudentList where StudentID not in(select StudentID from SMCList where CourseID='"+ courseID +"')and TeacherID ='"+ teacherID +"'";
                dr = sda.RunSqlReturnDataReader(sql);
            }
            return dr;
        }
        //检查作业次数是否存在
        public bool CheckBusyworkTime(string busyworkTime,string courseID)
        {
            bool result = false;
            string sql = "select * from BusyworkTimeList where BusyworkTime = '"+ busyworkTime +"' and CourseID = '"+ courseID +"'";
            SqlDataAccess sda = new SqlDataAccess();
            object number = sda.RunSqlReturnFirstValue(sql);
            if(number==null)
            {
                result = true;
            }
            return result;
        }
        //返回时间字符串
        public string GetTimeString(string year,string month,string day)
        {
            string timestring = year + "-" + month + "-" + day;
            return timestring;
        }
        //检查上传作业的格式
        public bool CheckFileExtension(string extensionName)
        {
            bool result = false;
            if(extensionName==".doc")
            {
                result = true;
            }
            return result;
        }
        //教师上传作业
        public void TeacherUploadBusywork(string busyworkTime,string courseID,string datetime)
        {
            string sql = "insert into BusyworkTimeList(BusyworkTime,CourseID,Deadline)values('"+ busyworkTime +"','"+ courseID +"','"+ datetime +"')";
            SqlDataAccess sda = new SqlDataAccess();
            sda.RunSqlNoReturn(sql);
        }
        //添加课程
        public bool TeacherAddCourse(string teacherID,string courseName,string topicPath,string busyworkPath)
        {
            bool result = true;
            string sqlInsertCourse = "insert into CourseList(CourseName)values('"+ courseName +"')";
            SqlDataAccess sda = new SqlDataAccess();
            sda.RunSqlNoReturn(sqlInsertCourse);
            string selectID = "select CourseID from CourseList where CourseName ='"+ courseName +"'";
            string courseid = sda.RunSql(selectID);
            string sql = "insert into TMCList(CourseID,TeacherID)values('"+ courseid +"','"+ teacherID +"')";
            sda.RunSqlNoReturn(sql);
            string Topic = topicPath + courseName;
            string Busywork = busyworkPath + courseName;
            if (Directory.Exists(Topic))
            {
                result = false;
            }
            else
            {
                Directory.CreateDirectory(Topic);
                Directory.CreateDirectory(Busywork);
            }
            return result;
        }
        //返回最后一次作业的次数
        public string ReturnLastBusyworkTime(string courseID)
        {
            string sql = "select BusyworkTime from BusyworkTimeList where CourseID = '" + courseID + "'order by BusyworkTime DESC";
            SqlDataAccess sda = new SqlDataAccess();
            string result = sda.RunSql(sql);
            return result;
        }
        //返回作业名称
        public string GetBusyworkName(string gradeID)
        {
            string sql = "select BusyworkName from GradeList where GradeID='" + gradeID + "'";
            SqlDataAccess sda = new SqlDataAccess();
            string str = (sda.RunSql(sql)).Trim();
            return str;
        }
        //根据成绩ID返回课程名称
        public string GetCourseName(string gradeID)
        {
            string sql = "select CourseName from CourseList where CourseID=(select CourseID from GradeList where GradeID='" + gradeID + "')";
            SqlDataAccess sda = new SqlDataAccess();
            string str = sda.RunSql(sql);
            return str;
        }
        //
        public SqlDataReader BindGradeListBySum(string courseid)
        {
            string sql = "select Number as 学号,Name as 姓名,sum(Grade)as 总成绩,avg(Grade)as 平均成绩 from StudentToGrade where CourseID ='"+ courseid +"' group by Number,Name order by sum(Grade) DESC";
            SqlDataAccess sda = new SqlDataAccess();
            SqlDataReader sdr = sda.RunSqlReturnDataReader(sql);
            return sdr;
        }
        public SqlDataReader BindGradeListByAvg(string courseid)
        {
            string sql = "select Number as 学号,Name as 姓名,sum(Grade)as 总成绩,avg(Grade)as 平均成绩 from StudentToGrade where CourseID ='" + courseid + "' group by Number,Name order by avg(Grade) DESC";
            SqlDataAccess sda = new SqlDataAccess();
            SqlDataReader sdr = sda.RunSqlReturnDataReader(sql);
            return sdr;
        }
        public SqlDataReader BindGradeListByNumber(string courseid)
        {
            string sql = "select Number as 学号,Name as 姓名,sum(Grade)as 总成绩,avg(Grade)as 平均成绩 from StudentToGrade where CourseID ='" + courseid + "' group by Number,Name order by Number DESC";
            SqlDataAccess sda = new SqlDataAccess();
            SqlDataReader sdr = sda.RunSqlReturnDataReader(sql);
            return sdr;
        }
        //删除指定ID课程
        public void DeleteCourseByID(string courseID)
        {
            string delCourselist = "delete from CourseList where CourseID = '"+ courseID +"'";
            string delTMClist = "delete from TMCList where CourseID = '" + courseID + "'";
            string delSMClist = "delete from SMCList where CourseID = '" + courseID + "'";
            string delBusyworkTimelist = "delete from BusyworkTimeList where CourseID = '" + courseID + "'";
            string delGradelist = "delete from GradeList where CourseID = '" + courseID + "'";
            SqlDataAccess sda = new SqlDataAccess();
            sda.RunSqlNoReturn(delTMClist);
            sda.RunSqlNoReturn(delSMClist);
            sda.RunSqlNoReturn(delGradelist);
            sda.RunSqlNoReturn(delBusyworkTimelist);
            sda.RunSqlNoReturn(delCourselist);
        }
        //删除目录和目录下所有的文件
        public void DeleteAllFileInDir(string Dirpath)
        {
            foreach (string file in Directory.GetFiles(Dirpath))
            {
                File.Delete(file);
            }
            DeleteDir(Dirpath);
        }
        //删除目录
        public void DeleteDir(string dirpath)
        {
            if(Directory.Exists(dirpath))
            {
                Directory.Delete(dirpath);
            }
        }
        //从该门课程中删除学生
        public void DeleteStudentFromCourse(string smcID)
        {
            string sql = "delete from SMCList where SMCID ='"+ smcID +"'";
            SqlDataAccess sda = new SqlDataAccess();
            sda.RunSqlNoReturn(sql);
        }
        //向课程中添加学生
        public void AddStudentToCourse(string courseID,string studentID)
        {
            string sql = "insert into SMCList(CourseID,StudentID)values('"+ courseID +"','"+ studentID +"')";
            SqlDataAccess sda = new SqlDataAccess();
            sda.RunSqlNoReturn(sql);
        }
        //返回作业名称
        public string ReturnBusyworkName(string stuID,string stuName,string time)
        {
            string classsql = "select Class from StudentList where StudentID='"+ stuID +"'";
            string sequencesql = "select SequenceNumber from StudentList where StudentID='"+ stuID +"'";
            SqlDataAccess sda = new SqlDataAccess();
            string strclass = (sda.RunSql(classsql)).Trim();
            string strsequence = (sda.RunSql(sequencesql)).Trim();
            string result = strclass + "_" + strsequence + "_" + stuName + "_" + time;
            return result;
        }
        //返回提交时间
        public DateTime ReturnDeadLine(string time)
        {
            string sql = "select Deadline from BusyworkTimeList where BusyworkTime = '" + time + "'";
            SqlDataAccess sda = new SqlDataAccess();
            string temptime = sda.RunSql(sql);
            DateTime deadline = Convert.ToDateTime(temptime);
            return deadline;
        }
        //添加到GradeList表
        public void AddGradeList(string time,string courseID)
        {
            string timesql = "select TimeID from BusyworkTimeList where BusyworkTime ='"+ time +"'";
            SqlDataAccess sda = new SqlDataAccess();
            string timeID = sda.RunSql(timesql);
            string stusql = "select StudentID from SMCList where CourseID ='"+ courseID +"'";
            DataSet ds = sda.ReturnStudentIDFromSMCListDataSet(courseID);
            string[] ListOfStudentID = new string[ds.Tables["StudentID"].Rows.Count];
            for (int i = 0; i < ds.Tables["StudentID"].Rows.Count; i++)
            {
                ListOfStudentID[i] = ds.Tables["StudentID"].Rows[i]["StudentID"].ToString();
            }
            foreach (string p in ListOfStudentID)
            {
                string insertsql = "insert into GradeList(TimeID,StudentID,CourseID)values('" + timeID + "','"+ p +"','"+ courseID +"')";
                sda.RunSqlNoReturn(insertsql);
            }
        }
        //检查作业名
        public bool CheckBusyworkName(string GradeID)
        {
            bool result = true;
            SqlDataAccess sda = new SqlDataAccess();
            string sql = "select BusyworkName from GradeList where GradeID='"+ GradeID +"'";
            string obj = sda.RunSql(sql);
            if(obj=="")
            {
                result = false;
            }
            return result;
        }
        //添加学生到成绩列表
        public void AddStudentToGradeList(string stuID,string courseID)
        {
            string timesql = "select TimeID from BusyworkTimeList where CourseID = '"+ courseID +"'";
            SqlDataAccess sda = new SqlDataAccess();
            DataSet ds = sda.ReturnTimeIDDataSet(timesql);
            string[] ListOfTimeID = new string[ds.Tables["TimeID"].Rows.Count];
            for (int i = 0; i < ds.Tables["TimeID"].Rows.Count; i++)
            {
                ListOfTimeID[i] = ds.Tables["TimeID"].Rows[i]["TimeID"].ToString();
            }
            foreach (string p in ListOfTimeID)
            {
                string insertsql = "insert into GradeList(TimeID,StudentID,CourseID)values('" + p + "','" + stuID + "','" + courseID + "')";
                sda.RunSqlNoReturn(insertsql);
            }
        }
        //从成绩列表中删除学生
        public void DeleteStudentFromGradeList(string smcID,string courseID)
        {
            string stusql = "select StudentID from SMCList where SMCID ='"+ smcID +"'";
            SqlDataAccess sda = new SqlDataAccess();
            string stuID = sda.RunSql(stusql);
            string sql = "delete from GradeList where StudentID='"+ stuID +"'and CourseID='"+ courseID +"'";
            sda.RunSqlNoReturn(sql);
        }
        //插入作业名称
        public void InsertBusyworkName(string courseName,string time,string stuID,string busyworkName)
        {
            string couNamesql = "select CourseID from CourseList where CourseName='"+ courseName +"'";
            SqlDataAccess sda = new SqlDataAccess();
            string couID = sda.RunSql(couNamesql);
            string timeIDsql = "select TimeID from BusyworkTimeList where CourseID='"+ couID +"'and BusyworkTime='"+ time +"'";
            string timeID = sda.RunSql(timeIDsql);
            string sql = "update GradeList set BusyworkName='"+ busyworkName +"'where TimeID='"+ timeID +"'and StudentID='"+ stuID +"'and CourseID='"+ couID +"'";
            sda.RunSqlNoReturn(sql);
        }
    }
}
