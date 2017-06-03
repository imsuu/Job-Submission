<%@ Page Language="C#" MasterPageFile="~/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="AddStuToCou.aspx.cs" Inherits="AddStuToCouB" Title="添加学生到课程" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <table width="100%" border="0" class="tabaleContain">
        <tr>
            <td height="38" style="width: 473px">课程名称：<asp:Label ID="lblCourseName" runat="server" Text="" Width="119px"></asp:Label></td>
            <td width="47%">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 473px">已有该门课程的学生列表</td>
            <td>没有该门课程的学生列表</td>
        </tr>
        <tr>
            <td height="84" style="width: 473px">&nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="452px" OnRowDeleting="GridView1_RowDeleting"
                CssClass="mGrid"
                PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <EditItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="学号" HeaderText="学号">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="姓名" HeaderText="姓名">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                </Columns>
            </asp:GridView>
            </td>
            <td>&nbsp;<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="418px" OnRowDeleting="GridView2_RowDeleting"
                CssClass="mGrid"
                PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <EditItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="学号" HeaderText="学号">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="姓名" HeaderText="姓名">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:CommandField ButtonType="Button" DeleteText="添加" ShowDeleteButton="True">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                </Columns>
            </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="height: 24px; width: 473px;">&nbsp;</td>
            <td style="height: 24px" align="center">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="height: 52px" align="center">
                <br />
                <br />
                <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="Button2_Click"  CssClass="button"/></td>
        </tr>
    </table>
</asp:Content>

