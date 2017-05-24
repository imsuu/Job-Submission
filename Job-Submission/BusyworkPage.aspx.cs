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

public partial class BusyworkPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataBind(Request.QueryString["id"].ToString());
        }
    }

    public void DataBind(string courseID)
    {
        BusyworkManage bm = new BusyworkManage();
        Label1.Text = bm.ReturnCourseName(courseID);
        GridView1.DataSource = bm.BusyworkDataBind(courseID);
        GridView1.DataBind();
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewCourse.aspx");
    }
    protected void btnAddWork_Click(object sender, EventArgs e)
    {
        string url = "AddBusywork.aspx?courseid=" + Request.QueryString["id"].ToString();
        Response.Redirect(url);
    }
    protected void btnViewGrade_Click(object sender, EventArgs e)
    {
        string url = "ViewGradeList.aspx?courseid=" + Request.QueryString["id"].ToString();
        Response.Redirect(url);
    }
}
