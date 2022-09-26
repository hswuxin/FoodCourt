<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newscontent.aspx.cs" Inherits="web.NewsListModular.newscontent" %>

<%@ Register Src="/AscxModular/header.ascx" TagName="head" TagPrefix="head" %>
<%@ Register Src="/AscxModular/footer.ascx" TagName="foot" TagPrefix="foot" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>美食坊-详情</title>
    <link rel="shortcut icon" type="favicon.ico" href="/images/logo-red.png">
    <link href="/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.min.js" type="text/javascript"></script>
    <script src="/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../css/newscontent.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--导航栏-->
    <head:head ID="head" runat="server"></head:head>
    <!--内容-->
    <div class="container contentbox">
        <h1 class="contentTitle">
            <%=newsTitle%>
        </h1>
        <h3 class="contentAuthor">
            更新于<%=newsAddTime %><span>|</span><%=newsAuthor %>
        </h3>
        <hr />
        <div class="newcontent">
            <%=newsContent %>
        </div>
    </div>
    <!--newscomment-->
    <div class="container commentbox">
        <hr />
        <div class="titlebox">
            <h4 class="commenttitle">
                评论&nbsp;<span class="commentsum"><%=countcomment %></span>
            </h4>
        </div>
        <div class="row">
            <div class="col-md-1 col-xs-2">
                <img src="../images/user.png" class="img-circle imgBox" width="64px" height="64px" />
            </div>
            <div class="col-md-10 col-xs-8">
                <asp:TextBox class="form-control commentBox" ID="commentBox" runat="server" placeholder="发布一条友善的评论"
                    Height="64px" TextMode="MultiLine" Rows="2"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="你还没有评论！"
                    ControlToValidate="commentBox" class="myrequire"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-1 col-xs-2">
                <asp:Button ID="commentBtn" Height="64px" class="btn  commentBtn col-md-12 col-xs-12"
                    runat="server" Text="发布" OnClick="commentBtn_Click" />
            </div>
        </div>
        <!--评论-->
        <%=commentString %>
    </div>
    </form>
    <!--底部导航-->
    <foot:foot ID="foot" runat="server"></foot:foot>
</body>
</html>
