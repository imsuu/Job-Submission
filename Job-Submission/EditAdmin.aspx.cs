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

public partial class EditAdmin : System.Web.UI.Page
{
    TeacherManage tm = new TeacherManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        tm.ChangPwd(txtName.Text.ToString().Trim(), txtPwd.Text.ToString().Trim());
        string alert = "修改成功！!";
        Response.Write("<script language = 'javascript'>alert('" + alert + "');</script>");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin.aspx");
    }
}
