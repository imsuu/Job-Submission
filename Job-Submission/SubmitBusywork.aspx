<%@ Page Language="C#" MasterPageFile="~/StudentMasterPage.master" AutoEventWireup="true" CodeFile="SubmitBusywork.aspx.cs" Inherits="SubmitBusywork" Title="提作业交" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<table width="100%" border="0" class="tabaleContain">
<tr>
<td align="center">
    <br />
    <br />
    <br />
    <asp:FileUpload ID="FUL" runat="server" /><br />
    <br />
    <br />
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="提作业交" CssClass="button" OnClick="btnSubmit_Click" />
    <asp:Button ID="btnReturn" runat="server" Text="取消" CssClass="button" OnClick="btnReturn_Click" /></td>
</tr>
</table>
</asp:Content>

