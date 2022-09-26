<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="videomanage.aspx.cs" Inherits="web.admin.videomanage" %>

<%@ Register Src="/AscxModular/header.ascx" TagName="head" TagPrefix="head" %>
<%@ Register Src="/AscxModular/footer.ascx" TagName="foot" TagPrefix="foot" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>美食坊-视频管理</title>
    <link rel="shortcut icon" type="favicon.ico" href="/images/logo-red.png">
    <link href="/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.min.js" type="text/javascript"></script>
    <script src="/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../css/search.css" rel="stylesheet" type="text/css" />
    <link href="../css/newlist.css" rel="stylesheet" type="text/css" />
    <link href="../css/newsmanage.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--导航栏-->
    <head:head ID="head" runat="server"></head:head>
    <!--搜索框-->
    <div class="container mysearch-box">
        <div class="input-group input-group-lg mysearch">
            <asp:TextBox ID="SearchBox" class="form-control" runat="server" placeholder="您要查找的标题"
                aria-describedby="basic-addon2"></asp:TextBox>
            <span class="input-group-addon" id="basic-addon2" style="padding: 8px 14px 8px 14px">
                <asp:Button ID="SearchBtn" runat="server" Text="搜索" onclick="SearchBtn_Click" 
                 /></span>
        </div>
    </div>
    <div class="container">
        <div class="">
            <h2 class="newslisth2">
                视频后台管理
            </h2>
            <a href="/admin/videoedit.aspx" class="btn btn-success pull-right addBtn">添加视频</a>
        </div>
        <table class="table table-hover">
            <tr>
                <th>
                    视频ID
                </th>
                <th>
                    视频标题
                </th>
                <th>
                    视频路径
                </th>
                <th>
                    添加时间
                </th>
                <th>
                    操作
                </th>
            </tr>
            <asp:ListView ID="VideoList" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("VideoID") %>
                        </td>
                        <td>
                            <%#Eval("VideoTitle") %>
                        </td>
                        <td>
                            <%#Eval("VideoURL") %>
                        </td>
                        <td>
                            <%#Eval("AddTime") %>
                        </td>
                        <td>
                            <a href="/admin/videoedit.aspx?id=<%#Eval("VideoID") %>" class="btn btn-primary">编辑</a>
                            <a href="/admin/videoedit.aspx?type=delete&id=<%#Eval("VideoID") %>" class="btn btn-danger">
                                删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>
        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="VideoList" 
            onprerender="DataPager1_PreRender">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False"
                    ShowPreviousPageButton="False" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False"
                    ShowPreviousPageButton="False" />
            </Fields>
        </asp:DataPager>
    </div>
    </form>
    <!--底部导航-->
    <foot:foot ID="foot" runat="server"></foot:foot>
