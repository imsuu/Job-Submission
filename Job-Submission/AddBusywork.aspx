<%@ Page Language="C#" MasterPageFile="~/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="AddBusywork.aspx.cs" Inherits="AddBusywork" Title="添加作业" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <table width="100%" border="0" class="tabaleContain">
        <tr>
            <td height="45" colspan="6"><span style="font-size: medium">课程名：</span><asp:Label ID="Label1" runat="server" Width="108px"></asp:Label>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; 该门课程的最后一次作业是第<asp:Label ID="Label2" runat="server" ForeColor="Red">0</asp:Label>次</td>
        </tr>
        <tr>
            <td align="right" colspan="2" style="width: 38%">作业次数：</td>
            <td width="58%" colspan="4">
                <asp:TextBox ID="txtBusyworkTime" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBusyworkTime"
                    ErrorMessage="输入作业次数！"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtBusyworkTime"
                    ErrorMessage="输入不正确！" ValidationExpression="^([\d]|[1-9]\d|1[0-7][0-9]|180)$"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td align="right" colspan="2" style="width: 38%; height: 69px;">提交期限：</td>
            <td colspan="4" style="height: 69px">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Selected="True">2017</asp:ListItem>
                   
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                     <asp:ListItem>2021</asp:ListItem>
                    <asp:ListItem>2022</asp:ListItem>
                    <asp:ListItem>2023</asp:ListItem>
                    <asp:ListItem>2024</asp:ListItem>
                    <asp:ListItem>2025</asp:ListItem>
                    <asp:ListItem>2026</asp:ListItem>
                </asp:DropDownList>年<asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem Selected="True">1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>月<asp:DropDownList ID="DropDownList3" runat="server">
                    <asp:ListItem Selected="True">1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>26</asp:ListItem>
                    <asp:ListItem>27</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>
                    <asp:ListItem>29</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>31</asp:ListItem>
                </asp:DropDownList>日</td>
        </tr>
        <tr>
            <td align="right" colspan="2" style="width: 38%">上传作业：</td>
            <td colspan="4">
                <asp:FileUpload ID="FUL" runat="server" /></td>
        </tr>
        <tr>
            <td height="60" align="center">
                &nbsp;</td>
            <td height="60" align="right" >
                <asp:Button ID="btnAdd" runat="server"  Text="添加" Width="80px" OnClick="btnAdd_Click"  CssClass="button"/>
                </td>
           
            <td height="60" align="left">
                <asp:Button ID="btnReturn" runat="server" Text="返回" Width="80px" CausesValidation="False" 
                     OnClick="Button2_Click" CssClass="button" /></td>
            <td height="60" align="center">
                &nbsp;</td>
            <td height="60" align="center">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

