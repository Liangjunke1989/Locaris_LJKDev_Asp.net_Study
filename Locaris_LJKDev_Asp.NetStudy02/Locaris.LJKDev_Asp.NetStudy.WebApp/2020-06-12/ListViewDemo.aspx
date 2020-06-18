<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListViewDemo.aspx.cs" Inherits="Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_12.ListViewDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 1163px">
            <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" InsertItemPosition="LastItem" style="margin-bottom: 0px">
                <AlternatingItemTemplate>
                    <tr style="background-color: #FFFFFF; color: #284775;">
                        <td>
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                        </td>
                        <td>
                            <asp:Label ID="UserIdLabel" runat="server" Text='<%# Eval("UserId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="UserPwdLabel" runat="server" Text='<%# Eval("UserPwd") %>' />
                        </td>
                        <td>
                            <asp:Label ID="UserAgeLabel" runat="server" Text='<%# Eval("UserAge") %>' />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <tr style="background-color: #999999;">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                        </td>
                        <td>
                            <asp:TextBox ID="UserIdTextBox" runat="server" Text='<%# Bind("UserId") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="UserNameTextBox" runat="server" Text='<%# Bind("UserName") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="UserPwdTextBox" runat="server" Text='<%# Bind("UserPwd") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="UserAgeTextBox" runat="server" Text='<%# Bind("UserAge") %>' />
                        </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                        <tr>
                            <td>未返回数据。</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                        </td>
                        <td>
                            <asp:TextBox ID="UserIdTextBox" runat="server" Text='<%# Bind("UserId") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="UserNameTextBox" runat="server" Text='<%# Bind("UserName") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="UserPwdTextBox" runat="server" Text='<%# Bind("UserPwd") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="UserAgeTextBox" runat="server" Text='<%# Bind("UserAge") %>' />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="background-color: #E0FFFF; color: #333333;">
                        <td>
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                        </td>
                        <td>
                            <asp:Label ID="UserIdLabel" runat="server" Text='<%# Eval("UserId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="UserPwdLabel" runat="server" Text='<%# Eval("UserPwd") %>' />
                        </td>
                        <td>
                            <asp:Label ID="UserAgeLabel" runat="server" Text='<%# Eval("UserAge") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr runat="server" style="background-color: #E0FFFF; color: #333333;">
                                        <th runat="server"></th>
                                        <th runat="server">UserId</th>
                                        <th runat="server">UserName</th>
                                        <th runat="server">UserPwd</th>
                                        <th runat="server">UserAge</th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF">
                                <asp:DataPager ID="DataPager2" runat="server">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <tr style="background-color: #E2DED6; font-weight: bold; color: #333333;">
                        <td>
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                        </td>
                        <td>
                            <asp:Label ID="UserIdLabel" runat="server" Text='<%# Eval("UserId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="UserPwdLabel" runat="server" Text='<%# Eval("UserPwd") %>' />
                        </td>
                        <td>
                            <asp:Label ID="UserAgeLabel" runat="server" Text='<%# Eval("UserAge") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>

            <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1">
                <Fields>
                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                </Fields>

            </asp:DataPager>

            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Locaris.LJKDev_Asp.NetStudy.Model.UserInfoEntity" DeleteMethod="RemoveUserInfo" InsertMethod="AddUserInfo" SelectMethod="GetPageListView" TypeName="Locaris.LJKDev_Asp.NetStudy.BLL.UserInfoService" UpdateMethod="EditUserInfo" EnablePaging="True" SelectCountMethod="GetRecordCount"></asp:ObjectDataSource>
        </div>
    </form>

</body>
</html>
