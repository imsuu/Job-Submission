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

public partial class AddCourse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewCourse.aspx");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        TeacherAddCourse();
    }
    public void TeacherAddCourse()
    {
        string path = BusyworkManage.Path;
        string teacherid = Request.Cookies["TeacherID"].Value.ToString();
        string topic = Server.MapPath(path + teacherid + BusyworkManage.TopicPath);
        string busywork = Server.MapPath(path + teacherid + BusyworkManage.BusyworkPath);
        string coursename = txtCourseName.Text.ToString().Trim();
        BusyworkManage bm = new BusyworkManage();
        bool result = bm.TeacherAddCourse(teacherid,coursename, topic, busywork);
        if (result == true)
        {
            Response.Write("<Script language='JavaScript'>alert('" + "添加成功！" + "');</Script>");
        }
        else
        {
            Response.Write("<Script language='JavaScript'>alert('" + "添加失败！" + "');</Script>");
        }
    }
}
