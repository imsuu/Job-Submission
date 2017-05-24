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

public partial class ViewGradeList : System.Web.UI.Page
{
    BusyworkManage bm = new BusyworkManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrade(Request.QueryString["courseid"].ToString());
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string url = "BusyworkPage.aspx?id=" + Request.QueryString["courseid"].ToString();
        Response.Redirect(url);
    }

    public void BindGrade(string courseid)
    {
        GridView1.DataSource = bm.BindGradeListBySum(courseid);
        GridView1.DataBind();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string result = DropDownList1.SelectedValue.ToString();
        if(result=="1")
        {
            GridView1.DataSource = bm.BindGradeListBySum(Request.QueryString["courseid"].ToString());
            GridView1.DataBind();
        }
        else if(result=="2")
        {
            GridView1.DataSource = bm.BindGradeListByAvg(Request.QueryString["courseid"].ToString());
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = bm.BindGradeListByNumber(Request.QueryString["courseid"].ToString());
            GridView1.DataBind();
        }
    }
    public override void VerifyRenderingInServerForm(Control control) { }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = false;
        Response.Charset = "GB2312";
        Response.AppendHeader("Content-Disposition", "attachment;filename=pkmv_de.xls");
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.ContentType = "application/ms-excel";
        Response.Write("<meta http-equiv=Content-Type content=\"text/html; charset=GB2312\">");
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
        HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);
        GridView1.RenderControl(oHtmlTextWriter);
        Response.Write(oStringWriter.ToString());
        Response.End();
    }
}
