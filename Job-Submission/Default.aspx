<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>在线作业提交批改系统</title>
    <link href="css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="Form1" name="form" runat="server">
<table width="100%" border="0">
  <tr>
    <td><img alt="Logo" src=" images/123.png"/></td>  </tr>
  <tr>
    <td><table id="Table1" width="100%" height="152" border="0" class="tabaleContain" runat="server">
  <tr>
    <td width="50%" align="right">选择登录类别：</td>
    <td width="50%" height="72" align="left">
        <asp:DropDownList ID="ddlSelect" runat="server" Width="98px">
            <asp:ListItem Selected="True">教师</asp:ListItem>
            <asp:ListItem>学生</asp:ListItem>
            <asp:ListItem>管理员</asp:ListItem>
        </asp:DropDownList></td>
  </tr>
  <tr>
    <td align="right">登录名：</td>
    <td align="left">
        <asp:TextBox ID="txtName" runat="server" Width="130px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
            ErrorMessage="请输入登录名！"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td align="right">
        密&nbsp; 码：</td>
    <td>
        <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="130px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPwd" runat="server" ControlToValidate="txtPwd"
            ErrorMessage="请输入密码！"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td colspan="2" align="center"><p>&nbsp;</p>
        <p>
            <asp:Button ID="btnLogin" runat="server" Text="登    录" Width="54px" OnClick="btnLogin_Click" />&nbsp;</p>
    </td>
  </tr>
</table></td>
  </tr>  
</table>
</form>
</body>
</html>
