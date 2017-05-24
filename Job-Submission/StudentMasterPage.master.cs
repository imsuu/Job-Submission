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

public partial class StudentMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblStudentName.Text = StudentManage.GetStudentName;
    }
    protected void btnQuit_Click(object sender, EventArgs e)
    {
        StudentManage sm = new StudentManage();
        sm.StudentLogoOff();
    }
}
