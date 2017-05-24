using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataManage;

public partial class StudentListB : System.Web.UI.Page
{
    StudentManage sm = new StudentManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataBind(Request.Cookies["TeacherID"].Value.ToString());
        }
    }
    public void DataBind(string teacherID)
    {
        GridView1.DataSource = sm.DataBindStudentList(teacherID);
        GridView1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewCourse.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddStudent.aspx");
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        DataBind(Request.Cookies["TeacherID"].Value.ToString());
        btnAddStudent.Visible = false;
        btnReturn.Visible = false;
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string id = ((Label)GridView1.Rows[e.RowIndex].Cells[0].FindControl("LabelID")).Text.ToString();
        string SequenceNumber = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("TextBox1")).Text.ToString().Trim();
        string Number = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].FindControl("TextBox2")).Text.ToString().Trim();
        string Name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].FindControl("TextBox3")).Text.ToString().Trim();
        string Class = ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].FindControl("TextBox4")).Text.ToString().Trim();
        string Password = ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].FindControl("TextBox5")).Text.ToString().Trim();
        sm.EditStudentList(SequenceNumber, Number, Name, Class, Password, id);
        DataBind(Request.Cookies["TeacherID"].Value.ToString());
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        DataBind(Request.Cookies["TeacherID"].Value.ToString());
        btnAddStudent.Visible = true;
        btnReturn.Visible = true;
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string studentid = ((Label)GridView1.Rows[e.RowIndex].Cells[0].FindControl("LabelID")).Text.ToString();
        sm.DeleteStudent(studentid);
        DataBind(Request.Cookies["TeacherID"].Value.ToString());
    }
}
