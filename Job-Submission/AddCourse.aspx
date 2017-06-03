<%@ Page Language="C#" MasterPageFile="~/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="AddCourse.aspx.cs" Inherits="AddCourse" Title="添加课程" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <table width="100%" border="0" class="tabaleContain">
        <tr>
            <td width="48%" align="right">课程名称：</td>
            <td width="52%">&nbsp;<asp:TextBox ID="txtCourseName" runat="server" Width="175px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCourseName"
                    ErrorMessage="需要输入课程名！"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right">
                <br />
                <br />
                <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" CssClass="button" />
            </td>
            <td>
                <br />
                <br />

                <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" CausesValidation="False" CssClass="button" /></td>
        </tr>
    </table>
</asp:Content>

