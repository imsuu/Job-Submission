using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using DataManage;

public partial class StudentPage : System.Web.UI.Page
{
    StudentManage sm = new StudentManage();
    TeacherManage tm = new TeacherManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            StudentBusyworkDataBind(Request.Cookies["StudentID"].Value.ToString());
        }
    }

    public void StudentBusyworkDataBind(string studentID)
    {
        GridView1.DataSource = sm.BusyworkListBind(studentID);
        GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string courseName = ((Label)GridView1.Rows[e.RowIndex].Cells[1].FindControl("Label1")).Text.ToString();
        string time = ((Label)GridView1.Rows[e.RowIndex].Cells[2].FindControl("Label2")).Text.ToString();
        string tempPath = BusyworkManage.Path + tm.ReturnTeacherID(Request.Cookies["StudentID"].Value.ToString()) +BusyworkManage.TopicPath + courseName + "/" + courseName + "_" + time + ".doc";
        string path = Server.MapPath(tempPath);
        FileInfo fInfo = new FileInfo(path);
        string fname = fInfo.Name;
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fname));
        Response.AddHeader("Content-Length", fInfo.Length.ToString());
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(fInfo.FullName);
        Response.Flush();
        Response.End();
    }
}
