<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditAdmin.aspx.cs" Inherits="EditAdmin" Title="管理员编辑" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" border="0" class="tabaleContain">
<tr><td>修改用户名和密码<br />
    <br />
</td></tr>
<tr><td align="center">
    用户名：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
        ErrorMessage="必须填入数据！"></asp:RequiredFieldValidator></td></tr>
<tr><td align="center">
    密&nbsp; 码：<asp:TextBox ID="txtPwd" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd"
        ErrorMessage="必须填入数据！"></asp:RequiredFieldValidator></td></tr>
<tr><td align="center">
    <br />
    <br />
        <asp:Button ID="btnSubmit" runat="server" Text="修改" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" CausesValidation="False" /><br />
    <br />
</td></tr>
    </table>
</asp:Content>

