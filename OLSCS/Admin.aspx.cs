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

public partial class Admin : System.Web.UI.Page
{
    TeacherManage tm = new TeacherManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TeacherListBind();
        }
    }

    public void TeacherListBind()
    {
        GridView1.DataSource = tm.TeacherListDataBind();
        GridView1.DataBind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        TeacherListBind();
        btnAddTeacher.Visible = false;
        btnEditAdmin.Visible = false;
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string id = ((Label)GridView1.Rows[e.RowIndex].Cells[0].FindControl("LabelID")).Text.ToString();
        string username = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("TextBox1")).Text.ToString().Trim();
        string password = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].FindControl("TextBox2")).Text.ToString().Trim();
        string teachername = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].FindControl("TextBox3")).Text.ToString().Trim();
        tm.UpdateTeacher(id, username, password, teachername);
        TeacherListBind();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        TeacherListBind();
        btnAddTeacher.Visible = true;
        btnEditAdmin.Visible = true;
    }
    protected void btnAddTeacher_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddTeacher.aspx");
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = ((Label)GridView1.Rows[e.RowIndex].Cells[0].FindControl("LabelID")).Text.ToString();
        string path = Server.MapPath(BusyworkManage.Path + id);
        tm.DeleteDirOfTeacher(id, path);
        tm.DeleteTeacher(id);
        TeacherListBind();

    }
    protected void btnEditAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditAdmin.aspx");
    }
}
