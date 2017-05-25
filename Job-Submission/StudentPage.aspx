<%@ Page Language="C#" MasterPageFile="~/StudentMasterPage.master" AutoEventWireup="true" CodeFile="StudentPage.aspx.cs" Inherits="StudentPage" Title="作业列表" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <table width="100%" border="0" class="tabaleContain">
        <tr>
            <td>作业列表</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="139px"
                    Width="100%" OnRowDeleting="GridView1_RowDeleting"
                    CssClass="mGrid"
                    PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="课程名称">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("课程名称") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("课程名称") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="作业次数">
                            <EditItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("作业次数") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("作业次数") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="提交期限" HeaderText="提交期限">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="成绩" HeaderText="成绩">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:CommandField ButtonType="Button" DeleteText="下作业载" ShowDeleteButton="True">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:CommandField>
                        <asp:HyperLinkField Text="提交作业" DataNavigateUrlFormatString="SubmitBusywork.aspx?course={0}&amp;time={1}" DataNavigateUrlFields="课程名称,作业次数">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

