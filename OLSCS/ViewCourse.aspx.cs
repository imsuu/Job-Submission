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
using DataManage;

public partial class ViewCourse : System.Web.UI.Page
{
    BusyworkManage bm = new BusyworkManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Databind(Request.Cookies["TeacherID"].Value.ToString());
        }
    }

    public void Databind(string id)
    {
        GridView1.DataSource = bm.CourseDataBind(id);
        GridView1.DataBind();
    }
    protected void btnAddCourse_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCourse.aspx");
    }
    protected void btnStudentList_Click(object sender, EventArgs e)
    {
        string url = "StudentList.aspx";
        Response.Redirect(url);
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string courseid = ((Label)GridView1.Rows[e.RowIndex].Cells[0].FindControl("Label1")).Text.ToString();
        string coursename = ((Label)GridView1.Rows[e.RowIndex].Cells[0].FindControl("Label2")).Text.ToString();
        string pathTopic = Server.MapPath(BusyworkManage.Path + Request.Cookies["TeacherID"].Value.ToString() + BusyworkManage.TopicPath + coursename);
        string pathBusywork = Server.MapPath(BusyworkManage.Path + Request.Cookies["TeacherID"].Value.ToString() + BusyworkManage.BusyworkPath + coursename);
        bm.DeleteAllFileInDir(pathBusywork);
        bm.DeleteAllFileInDir(pathTopic);
        bm.DeleteCourseByID(courseid);
        Databind(Request.Cookies["TeacherID"].Value.ToString());
    }
}
