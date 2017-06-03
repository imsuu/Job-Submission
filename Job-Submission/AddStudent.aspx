<%@ Page Language="C#" MasterPageFile="~/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="AddStudent.aspx.cs" Inherits="AddStudentB" Title="添加学生" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server"><table width="100%" border="0" class="tabaleContain">
  <tr>
    <td height="36" colspan="2">
        添加学生</td>
  </tr>
  <tr>
    <td align="right">序号：</td>
    <td>
        <asp:TextBox ID="txtSeq" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSeq"
            ErrorMessage="需要输入序号！"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td align="right">学号：</td>
    <td>
        <asp:TextBox ID="txtNum" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNum"
            ErrorMessage="需要输入学号！"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td align="right">学生姓名：</td>
    <td>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
    <td align="right">专业班级：</td>
    <td>
        <asp:TextBox ID="txtClass" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
    <td align="right">密码：</td>
    <td>
        <asp:TextBox ID="txtPwd" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
    <td colspan="2" align="center" style="height: 62px">
        <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="Button1_Click1" CssClass="button"  />
        <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="Button2_Click" CausesValidation="False" CssClass="button" /></td>
  </tr>
</table>
</asp:Content>

