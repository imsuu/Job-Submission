using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace DataManage
{
    public class SqlDataAccess
    {
        //获取连接字符串
        private readonly string connectionstring = ConfigurationManager.ConnectionStrings["ConnectToDatabase"].ConnectionString;
        //创建一个新的连接cn
        private SqlConnection cn;
        //打开连接
        public void open()
        {
            cn = new SqlConnection(connectionstring);
            cn.Open();
        }
        //关闭连接
        public void close()
        {
            if (cn != null)
            {
                cn.Close();
                cn.Dispose();
            }
        }
        //执行SQL语句，不返回结果
        public void RunSqlNoReturn(string sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            close();
        }
        //执行SQL语句，返回影响行数
        public int RunSqlReturnNumber(string sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(sql, cn);
            int number = cmd.ExecuteNonQuery();
            return number;
            close();
        }
        //执行SQL语句，并返回第一行第一列的值
        public object RunSqlReturnFirstValue(string Sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(Sql, cn);
            object obj = cmd.ExecuteScalar();
            close();
            return obj;
        }
        //执行SQL语句，并返回第一行第一列的值
        public string RunSql(string Sql)
        {
            string str = "";
            open();
            try
            {
                SqlCommand cmd = new SqlCommand(Sql, cn);
                str = cmd.ExecuteScalar().ToString();
                close();
            }
            catch
            {
            }
            return str;
        }
        //执行SQL语句，并返回数据集
        public SqlDataReader RunSqlReturnDataReader(string Sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(Sql, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            return (dr);                        
        }
        //执行存储过程
        public SqlDataReader RunProc(string procName)
        {
            SqlConnection cn = new SqlConnection(connectionstring);
            SqlCommand cmd;
            cmd = new SqlCommand(procName, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cn;
            cn.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            return (dataReader);
        }
        public SqlDataReader RunPro(string ProcName, SqlParameter[] prams)
        {
            open();
            SqlCommand cmd = new SqlCommand(ProcName, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (prams != null)
            {
                foreach (SqlParameter parammeter in prams)
                    cmd.Parameters.Add(parammeter);
            }
            SqlDataReader dr = cmd.ExecuteReader();
            //close();
            return dr;
        }
        //执行SQL语句并返回DataSet
        public DataSet ReturnStudentIDDataSet(string teacherid)
        {
            string sql = "select StudentID from StudentList where TeacherID = '"+ teacherid +"'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, connectionstring);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Student");
            return ds;
        }
        public DataSet ReturnCourseIDDataSet(string teacherid)
        {
            string sql = "select CourseID from TMCList where TeacherID = '"+ teacherid +"'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, connectionstring);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Course");
            return ds;
        }
        public DataSet ReturnCourseNameDataSet(string sql)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sql, connectionstring);
            DataSet ds = new DataSet();
            sda.Fill(ds, "CourseName");
            return ds;
        }
        public DataSet ReturnStudentIDFromSMCListDataSet(string courseID)
        {
            string sql = "select StudentID from SMCList where CourseID = '" + courseID + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, connectionstring);
            DataSet ds = new DataSet();
            sda.Fill(ds, "StudentID");
            return ds;
        }
        public DataSet ReturnTimeIDDataSet(string sql)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sql, connectionstring);
            DataSet ds = new DataSet();
            sda.Fill(ds, "TimeID");
            return ds;
        }
        //执行带有输入参数的存储过程
        public void RunProc(string procName, SqlParameter[] prams)
        {
            open();
            SqlCommand cmdd = new SqlCommand(procName, cn);
            cmdd.CommandType = CommandType.StoredProcedure;
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                    cmdd.Parameters.Add(parameter);
            }
            cmdd.ExecuteNonQuery();
            close();
        }
        //输入参数
        public SqlParameter InParam(string ParamName, SqlDbType DbType, int size, ParameterDirection direction, object value)
        {
            SqlParameter param = new SqlParameter(ParamName, DbType, size);
            param.Direction = direction;
            param.Value = value;
            return param;
        }               
    }
}