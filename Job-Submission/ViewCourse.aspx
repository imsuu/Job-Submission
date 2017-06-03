<%@ Page Language="C#" MasterPageFile="~/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="ViewCourse.aspx.cs" Inherits="ViewCourse" Title="课程列表" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">

    <table width="100%" border="0" class="tabaleContain">
        <tr>
            <td width="48%" height="46">课程列表</td>
            <td style="width: 50%">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="课程编号" OnRowDeleting="GridView1_RowDeleting"
                    CssClass="mGrid"
                    PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt">

                    <Columns>
                        <asp:TemplateField HeaderText="课程编号" InsertVisible="False" SortExpression="课程编号">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("课程编号") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("课程编号") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="课程名称" SortExpression="课程名称">
                            <EditItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("课程名称") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("课程名称") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField DataNavigateUrlFields="课程编号" DataNavigateUrlFormatString="BusyworkPage.aspx?id={0}"
                            Text="查看课程">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                        <asp:HyperLinkField Text="该课程的学生情况" DataNavigateUrlFields="课程编号" DataNavigateUrlFormatString="AddStuToCou.aspx?id={0}">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="True">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:CommandField>
                    </Columns>
                    <EmptyDataTemplate>
                        添加学生
                    </EmptyDataTemplate>
                </asp:GridView>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="height: 93px">
                <p>&nbsp;</p>
                <asp:Button ID="btnAddCourse" runat="server" Text="添 加 课 程" CssClass="button" class="Button" OnClick="btnAddCourse_Click" />
                <asp:Button ID="btnStudentList" runat="server" Text="学 生 列 表" CssClass="button" OnClick="btnStudentList_Click" /></td>
        </tr>
    </table>
</asp:Content>

