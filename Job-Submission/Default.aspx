<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>在线作业提交批改系统</title>
    <link href="css/Style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            font-size: small;
        }
        .auto-style2 {
            font-size: small;
            height: 53px;
        }
        .auto-style3 {
            height: 53px;
        }
        .auto-style4 {
            font-size: small;
            height: 56px;
        }
        .auto-style5 {
            height: 56px;
        }
        .auto-style6 {
            width: 2%;
        }
        .auto-style7 {
            height: 53px;
            width: 2%;
        }
        .auto-style8 {
            height: 56px;
            width: 2%;
        }
        .auto-style9 {
            height: 257px;
        }
    </style>
</head>
<body>
<form id="Form1" name="form" runat="server">
<table width="100%" border="0">
  <tr>
    <td><img alt="Logo" src="images/123.png" /></td>
  </tr>
  <tr>
    <td class="auto-style9"><table id="Table1" width="100%" border="0"  runat="server"
        class="tabaleContain">
  <tr>
    <td width="50%" align="right" class="auto-style1">登录类别：</td>
    <td height="72" align="left" class="auto-style6">
        &nbsp;</td>
    <td width="50%" height="72" align="left">
        <asp:DropDownList ID="ddlSelect" runat="server" Width="98px">
            <asp:ListItem Selected="True">教师</asp:ListItem>
            <asp:ListItem>学生</asp:ListItem>
            <asp:ListItem>管理员</asp:ListItem>
        </asp:DropDownList></td>
  </tr>
  <tr>
    <td align="right" class="auto-style2">登录名称：</td>
    <td align="left" class="auto-style7">
        &nbsp;</td>
    <td align="left" class="auto-style3">
        <asp:TextBox ID="txtName" runat="server" Width="130px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
            ErrorMessage="请输入登录名称！"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td align="right" class="auto-style4">
        登录密码：</td>
    <td class="auto-style8">
        </td>
    <td class="auto-style5">
        <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="130px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPwd" runat="server" ControlToValidate="txtPwd"
            ErrorMessage="请输入登录密码！"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td colspan="3" align="center" ><p>&nbsp;</p>
        <p>
            <asp:Button ID="btnLogin" runat="server" Text="登    录"  OnClick="btnLogin_Click" CssClass="button"/></p>
    </td>
  </tr>
</table></td>
  </tr>  
</table>
</form>
</body>
</html>
