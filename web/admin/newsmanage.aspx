<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newsmanage.aspx.cs" Inherits="web.admin.newsmanage" %>

<%@ Register Src="/AscxModular/header.ascx" TagName="head" TagPrefix="head" %>
<%@ Register Src="/AscxModular/footer.ascx" TagName="foot" TagPrefix="foot" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>美食坊-文章后台管理</title>
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
                <asp:Button ID="SearchBtn" runat="server" Text="搜索" OnClick="SearchBtn_Click" /></span>
        </div>
    </div>
    <div class="container newslist table-responsive">
        <div class="">
            <h2 class="newslisth2">
                文章后台管理
            </h2>
            <a href="NewsEdit.aspx" class="btn btn-success pull-right addBtn">添加文章</a>
        </div>
        <table class="table table-hover">
            <tr>
                <th>
                    ID
                </th>
                <th>
                    标题
                </th>
                <th>
                    作者
                </th>
                <th>
                    添加时间
                </th>
                <th>
                    操作
                </th>
            </tr>
            <asp:ListView ID="NewsList" runat="server" 
                onpagepropertieschanged="NewsList_PagePropertiesChanged">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("NewsID") %>
                        </td>
                        <td>
                            <a href="/NewsListModular/newscontent.aspx?id=<%#Eval("NewsID") %>">
                                <%#Eval("NewsTitle") %>
                            </a>
                        </td>
                        <td>
                            <%#Eval("NewsAuthor") %>
                        </td>
                        <td>
                            <%#Eval("NewsAddTime") %>
                        </td>
                        <td>
                            <a class="btn btn-primary" href="NewsEdit.aspx?id=<%#Eval("NewsID")%>">编辑</a>
                            <a class="btn btn-danger" href="NewsEdit.aspx?type=delete&id=<%#Eval("NewsID")%>">删除</a>
                            <a class="btn btn-info" href="/admin/commentmanage.aspx?newids=<%#Eval("NewsID")%>">评论管理</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>
        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="NewsList" 
            onprerender="DataPager1_PreRender">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False"
                    ShowPreviousPageButton="False" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                    ShowNextPageButton="False" ShowPreviousPageButton="False" />
            </Fields>
        </asp:DataPager>
    </div>
    </form>
    <!--底部导航-->
    <foot:foot ID="foot" runat="server"></foot:foot>
</body>
</html>
