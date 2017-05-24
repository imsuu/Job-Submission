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

public partial class AddStudentB : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void Button1_Click1(object sender, EventArgs e)
    {
        StudentAdd();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentList.aspx");
    }
    public void StudentAdd()
    {
        string seq = txtSeq.Text.ToString().Trim();
        string num = txtNum.Text.ToString().Trim();
        string name = txtName.Text.ToString().Trim();
        string clas = txtClass.Text.ToString().Trim();
        string pwd = txtPwd.Text.ToString().Trim();
        string teacherid = Request.Cookies["TeacherID"].Value.ToString();
        StudentManage sm = new StudentManage();
        int result = sm.AddStudent(teacherid, seq, num, name, clas, pwd);
        if(result==1)
        {
            Response.Write("<Script language='JavaScript'>alert('" + "序号重复！" + "');</Script>");
        }
        else if(result==2)
        {
            Response.Write("<Script language='JavaScript'>alert('" + "学号重复！" + "');</Script>");
        }
        else
        {
            Response.Write("<Script language='JavaScript'>alert('" + "添加成功！" + "');</Script>");
        }
    }
}
