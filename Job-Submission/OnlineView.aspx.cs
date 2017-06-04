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

public partial class OnlineView : System.Web.UI.Page
{
    BusyworkManage bm = new BusyworkManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowBusywork(Request.QueryString["id"].ToString());
    }

    public void ShowBusywork(string gradeID)
    {
        bool result = bm.CheckBusyworkName(gradeID);
        if (result == true)
        {
           
            string first = BusyworkManage.Path;
            string teacherid = Request.Cookies["TeacherID"].Value.ToString();
            string second = BusyworkManage.BusyworkPath;
            string courseName = bm.GetCourseName(gradeID) + "/";
            string busyworkName = bm.GetBusyworkName(gradeID) + ".doc";
            string path = Server.MapPath(first + teacherid + second + courseName + busyworkName);
            string fileName = courseName + busyworkName;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader( "Content-Disposition", "attachment;filename=" + fileName );
            Response.ContentType = "application/msword";
            Response.WriteFile(path);
            Response.Flush();
            Response.Close();
        }
        else
        {
            string alert = "该学生还没有提交作业！ ";
            HttpContext.Current.Response.Write( "<script language = 'javascript'>alert('" + alert + "');history.go(-1);</script>" );           
        }
    }
}
