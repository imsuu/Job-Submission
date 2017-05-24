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

public partial class AddTeacher : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        TeacherManage tm = new TeacherManage();
        bool result = tm.VldUserName(txtUserName.Text.ToString().Trim());
        if (result == true)
        {
            string path = Server.MapPath(BusyworkManage.Path);
            tm.AddTeacher(txtUserName.Text.ToString().Trim(), txtPWD.Text.ToString().Trim(), txtTeacherName.Text.ToString().Trim(), path);
        }
        else
        {
            string alert = "用户名已经存在！";
            HttpContext.Current.Response.Write("<script language = 'javascript'>alert('" + alert + "');</script>");
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin.aspx");
    }
}
