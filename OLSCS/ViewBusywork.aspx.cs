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

public partial class ViewBusywork : System.Web.UI.Page
{
    BusyworkManage bm = new BusyworkManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataBindList(Request.QueryString["Time"].ToString(), Request.QueryString["Course"].ToString());
        }
    }

    public void DataBindList(string time, string course)
    {
        GridView1.DataSource = bm.BusyworkCheck(course, time);
        GridView1.DataBind();
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        string url = "BusyworkPage.aspx?id=" + Request.QueryString["Course"].ToString();
        Response.Redirect(url);
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        DataBindList(Request.QueryString["Time"].ToString(), Request.QueryString["Course"].ToString());
        btnReturn.Visible = false;
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string id = ((Label)GridView1.Rows[e.RowIndex].Cells[0].FindControl("LabelID")).Text.ToString();
        string grade = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].FindControl("TextBox1")).Text.ToString();
        bm.ChangeGrade(grade, id);
        DataBindList(Request.QueryString["Time"].ToString(), Request.QueryString["Course"].ToString());
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        DataBindList(Request.QueryString["Time"].ToString(), Request.QueryString["Course"].ToString());
        btnReturn.Visible = true;
    }
}
