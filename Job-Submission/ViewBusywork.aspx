<%@ Page Language="C#" MasterPageFile="~/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="ViewBusywork.aspx.cs" Inherits="ViewBusywork" Title="学生作业列表" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <table width="100%" border="0" class="tabaleContain">
        <tr>
            <td style="height: 45px">学生作业列表</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                    CssClass="mGrid"
                    PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <EditItemTemplate>
                                <asp:Label ID="LabelID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="作业次数">
                            <EditItemTemplate>
                                <asp:Label ID="TextBox3" runat="server" Text='<%# Bind("作业次数") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("作业次数") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="学生姓名">
                            <EditItemTemplate>
                                <asp:Label ID="TextBox4" runat="server" Text='<%# Bind("学生姓名") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("学生姓名") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="成绩">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("成绩") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("成绩") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField Text="查看/下载作业" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="OnlineView.aspx?id={0}">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                        <asp:CommandField ButtonType="Button" EditText="给出成绩" ShowEditButton="True">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td height="42" align="center">&nbsp;<asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" /></td>
        </tr>
    </table>
</asp:Content>

