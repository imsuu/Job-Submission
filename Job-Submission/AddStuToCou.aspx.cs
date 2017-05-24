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

public partial class AddStuToCouB : System.Web.UI.Page
{
    BusyworkManage bm = new BusyworkManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataBindListDouble(Request.QueryString["id"].ToString());
        }
    }

    public void DataBindListDouble(string courseID)
    {
        lblCourseName.Text = bm.ReturnCourseName(courseID);
        GridView1.DataSource = bm.HaveCourseStudentListBind(courseID);
        GridView1.DataBind();
        GridView2.DataSource = bm.HaveNoCourseStudentListBind(courseID,Request.Cookies["TeacherID"].Value.ToString());
        GridView2.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewCourse.aspx");
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string smcid = ((Label)GridView1.Rows[e.RowIndex].Cells[0].FindControl("Label1")).Text.ToString();
        bm.DeleteStudentFromCourse(smcid);
        bm.DeleteStudentFromGradeList(smcid, Request.QueryString["id"].ToString());
        DataBindListDouble(Request.QueryString["id"].ToString());
    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string studentid = ((Label)GridView2.Rows[e.RowIndex].Cells[0].FindControl("Label1")).Text.ToString();
        bm.AddStudentToCourse(Request.QueryString["id"].ToString(), studentid);
        bm.AddStudentToGradeList(studentid, Request.QueryString["id"].ToString());
        DataBindListDouble(Request.QueryString["id"].ToString());
    }
}
