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

public partial class SubmitBusywork : System.Web.UI.Page
{
    BusyworkManage bm = new BusyworkManage();
    TeacherManage tm = new TeacherManage();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (CheckTime() == true)
        {
            if (FUL.HasFile)
            {
                string busyworkname = bm.ReturnBusyworkName(Request.Cookies["StudentID"].Value.ToString(), Request.Cookies["StudentName"].Value.ToString(), Request.QueryString["time"].ToString());
                UploadFile(busyworkname);                
            }
            else
            {
                Response.Write("<Script language='JavaScript'>alert('" + "没有上传文件！" + "');</Script>");
            }
        }
        else
        {
            Response.Write("<Script language='JavaScript'>alert('" + "时间已经过期！" + "');</Script>");
        }
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentPage.aspx");
    }
    public void UploadFile(string name)
    {
        string coursename = Request.QueryString["course"].ToString() + "/";
        string path = Server.MapPath(BusyworkManage.Path + tm.ReturnTeacherID(Request.Cookies["StudentID"].Value.ToString()) + BusyworkManage.BusyworkPath + coursename + name+ ".doc");
        string fileExtension = System.IO.Path.GetExtension(FUL.PostedFile.FileName).ToLower();
        bool result = bm.CheckFileExtension(fileExtension);
        if (result == true)
        {
            FUL.PostedFile.SaveAs(path);
            bm.InsertBusyworkName(Request.QueryString["course"].ToString(), Request.QueryString["time"].ToString(), Request.Cookies["StudentID"].Value.ToString(), name);
            Response.Write("<Script language='JavaScript'>alert('" + "添加成功！" + "');</Script>");
        }
        else
        {
            Response.Write("<Script language='JavaScript'>alert('" + "格式不正确！" + "');</Script>");
        }
    }
    public bool CheckTime()
    {
        bool Result = false;
        DateTime Deadline = bm.ReturnDeadLine(Request.QueryString["time"].ToString());
        DateTime SystemTime = DateTime.Now;
        int result = SystemTime.CompareTo(Deadline);
        if (result < 0)
        {
            Result = true;
        }
        return Result;
    }
}
