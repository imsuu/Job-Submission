using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataManage;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        UserLogin();
    }

    public void UserLogin()
    {
        if (ddlSelect.SelectedValue == "教师")
        {
            TeacherManage tm = new TeacherManage();
            tm.TeacherLogin(txtName.Text.ToString().Trim(), txtPwd.Text.ToString().Trim());
        }
        else if (ddlSelect.SelectedValue == "学生")
        {

            btnLogin.Attributes.Add("onclick", "return confirm('学生');"); 
        }
        else
        {
            btnLogin.Attributes.Add("onclick", "return confirm('管理员');"); 
        }
    }
}
