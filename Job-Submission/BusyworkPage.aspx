<%@ Page Language="C#" MasterPageFile="~/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="BusyworkPage.aspx.cs" Inherits="BusyworkPage" Title="作业列表" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <table width="100%" border="0" class="tabaleContain">
        <tr>
            <td height="45" colspan="2">课程名：<asp:Label ID="Label1" runat="server" Width="137px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">作业列表</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                    CssClass="mGrid"
                    PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt">
                    <Columns>
                        <asp:BoundField DataField="课程ID" HeaderText="课程ID">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="作业次数" DataField="作业次数">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:HyperLinkField Text="查看学生作业" DataNavigateUrlFields="作业次数,课程ID" DataNavigateUrlFormatString="ViewBusywork.aspx?Time={0}&amp;Course={1}">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <br />
                <br />
                <asp:Button ID="btnAddWork" runat="server" Text="添加作业" OnClick="btnAddWork_Click" Width="53px" />
                <asp:Button ID="btnViewGrade" runat="server" Text="查看成绩" Width="54px" OnClick="btnViewGrade_Click" />
                <asp:Button ID="btnReturn" runat="server" Text="返回" Width="44px" OnClick="btnReturn_Click" /></td>
        </tr>
    </table>
</asp:Content>

