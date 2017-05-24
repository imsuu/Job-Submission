<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddTeacher.aspx.cs" Inherits="AddTeacher" Title="添加教师" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" border="0" class="tabaleContain">
<tr>
<td>
    添加教师</td></tr>
<tr>
<td align="center">
    用 户 名：<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
        ErrorMessage="请输入用户名！">*</asp:RequiredFieldValidator></td></tr>
<tr>
<td align="center">
    密 &nbsp;&nbsp; 码：<asp:TextBox ID="txtPWD" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPWD"
        ErrorMessage="请输入密码！">*</asp:RequiredFieldValidator></td></tr>
<tr>
<td align="center">
    教师姓名：<asp:TextBox ID="txtTeacherName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTeacherName"
        ErrorMessage="请输入教师姓名！">*</asp:RequiredFieldValidator></td></tr>
<tr>
<td align="center">
    <br />
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="返回" OnClick="btnCancel_Click" CausesValidation="False" /><br />
</td></tr>
</table>
</asp:Content>

