<%@ Page Language="C#" MasterPageFile="~/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="ViewGradeList.aspx.cs" Inherits="ViewGradeList" Title="成绩列表" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <table width="100%" border="0" class="tabaleContain">
        <tr>
            <td align="center">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="147px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="1">按总成绩排序</asp:ListItem>
                    <asp:ListItem Value="2">按平均成绩排序</asp:ListItem>
                    <asp:ListItem Value="3">按学号排序</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="center" style="height: 163px">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                    CssClass="mGrid"
                    PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt">
                    <Columns>
                        <asp:BoundField DataField="学号" HeaderText="学号">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="姓名" HeaderText="姓名">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="总成绩" HeaderText="总成绩">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="平均成绩" HeaderText="平均成绩">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnOutExcel" runat="server" Text="导出到Excel表" CssClass="button" OnClick="Button1_Click" />
                <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="Button2_Click" CssClass="button"/></td>
        </tr>
    </table>
</asp:Content>

