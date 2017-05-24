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

public partial class AddBusywork : System.Web.UI.Page
{
    BusyworkManage bm = new BusyworkManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CourseNameBind(Request.QueryString["courseid"].ToString());
        }
    }

    public void CourseNameBind(string courseID)
    {        
        Label1.Text = bm.ReturnCourseName(courseID);
        Label2.Text = bm.ReturnLastBusyworkTime(courseID);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string url = "BusyworkPage.aspx?id=" + Request.QueryString["courseid"].ToString();
        Response.Redirect(url);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (bm.CheckBusyworkTime(txtBusyworkTime.Text.ToString(), Request.QueryString["courseid"].ToString()) == true)
        {
            if (CheckTime() == true)
            {
                if (FUL.HasFile)
                {
                    bm.TeacherUploadBusywork(txtBusyworkTime.Text.ToString(), Request.QueryString["courseid"].ToString(), bm.GetTimeString(DropDownList1.SelectedValue, DropDownList2.SelectedValue, DropDownList3.SelectedValue));
                    UploadFile(txtBusyworkTime.Text.ToString());
                    bm.AddGradeList(txtBusyworkTime.Text.ToString(), Request.QueryString["courseid"].ToString());
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
        else
        {
            Response.Write("<Script language='JavaScript'>alert('" + "作业次数已经存在！" + "');</Script>");
        }
    }

    public void UploadFile(string time)
    {
        string coursename = bm.ReturnCourseName(Request.QueryString["courseid"].ToString());
        //string postfileName = FUL.PostedFile.FileName.Substring(FUL.PostedFile.FileName.LastIndexOf("\\"), FUL.PostedFile.FileName.Length - FUL.PostedFile.FileName.LastIndexOf("\\"));
        string postfileName = coursename + "_" + time + ".doc";
        string path = Server.MapPath(BusyworkManage.Path + Request.Cookies["TeacherID"].Value.ToString() + BusyworkManage.TopicPath + coursename + "/" + postfileName);
        string fileExtension = System.IO.Path.GetExtension(FUL.PostedFile.FileName).ToLower();
        bool result = bm.CheckFileExtension(fileExtension);
        if(result==true)
        {
            FUL.PostedFile.SaveAs(path);
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
        int year = Convert.ToInt16(DropDownList1.SelectedValue);
        int month = Convert.ToInt16(DropDownList2.SelectedValue);
        int day = Convert.ToInt16(DropDownList3.SelectedValue);
        DateTime SelectTime = new DateTime(year, month, day);
        DateTime SystemTime = DateTime.Now;
        int result = SystemTime.CompareTo(SelectTime);
        if(result<0)
        {
            Result = true;
        }
        return Result;
    }
    
}
