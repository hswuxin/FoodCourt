<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="commentmanage.aspx.cs"
    Inherits="web.admin.commentmanage" %>

<%@ Register Src="/AscxModular/header.ascx" TagName="head" TagPrefix="head" %>
<%@ Register Src="/AscxModular/footer.ascx" TagName="foot" TagPrefix="foot" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>美食坊-评论管理</title>
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
    <div class="container newslist table-responsive">
        <div class="">
            <h2 class="newslisth2">
                文章后台管理
            </h2>
        </div>
        <table class="table table-hover">
            <tr>
                <th>
                    评论编号
                </th>
                <th>
                    用户编号
                </th>
                <th>
                    文章编号
                </th>
                <th>
                    评论内容
                </th>
                <th>
                    添加时间
                </th>
                <th>
                    操作
                </th>
            </tr>
            <asp:ListView ID="CommentList" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("CommentID")%>
                        </td>
                        <td>
                            <%#Eval("UserID")%>
                        </td>
                        <td>
                            <%#Eval("NewsID")%>
                        </td>
                        <td>
                            <%#Eval("CommentContent")%>
                        </td>
                        <td>
                            <%#Eval("AddTime")%>
                        </td>
                        <td>
                            <a class="btn btn-primary" href="/admin/deletecomment.aspx?id=<%#Eval("CommentID")%>">删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>
        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="CommentList">
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
</body>
</html>
